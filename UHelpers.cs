using System;
using System.Drawing;
using System.Collections.Generic;
using UClass;
namespace UHelpers
{
    public class UHelpers
    {
        public static int[] GenPlayerList(int nPlayers)
        {
            int[] result;
            int[] L1;
            int[] L2;
            int i;
            int sublen;
            if (nPlayers == 2)
            {
                L1 = new int[0];
                L2 = new int[0];
                result = new int[2];
                result[0] = 1;
                result[1] = 2;
            }
            else
            {
                sublen = (int)Math.Round(nPlayers / 2.0);
                L1 = GenPlayerList(sublen);
                // L2 := GenPlayerList(sublen);
                L2 = new int[sublen];
                CopyToArray(L1, ref L2, 0);
                for (i = 0; i < sublen; i ++ )
                {
                    L1[i] = L1[i] * 2 - 1;
                }
                for (i = 0; i < sublen; i ++ )
                {
                    L2[i] = L2[i] * 2;
                }
                result = new int[nPlayers];
                CopyToArray(L1, ref result, 0);
                CopyToArray(L2, ref result, sublen);
            }
            return result;
        }

        public static List<List<int>> GenJumpSlotLists(int nPlayers, TSettings Settings, bool firstcall)
        {
            System.Diagnostics.Trace.Assert(nPlayers % 2 == 0 && nPlayers % 4 == 0);
            List<List<int>> result = new List<List<int>>();
            int i;
            int sublen;
            int nLosers;
            int by4;
            List<List<int>> prev;
            int[] tmp;
            nLosers = nPlayers / 2;
            if (firstcall)
            {
                // First looks always special
                if ((nPlayers > 16) && (Settings.SwitchJumpSlotOrderAt32))
                {
                    prev = GenJumpSlotLists(nPlayers / 2, Settings, false);
                    // First Level is 765...
                    result.Add(new List<int>(nLosers));
                    by4 = nLosers / 4;
                    for (i = 0; i < by4; i ++ )
                    {
                        result[0].Add((nLosers - 1) - (i * 4 + 3));
                        result[0].Add((nLosers - 1) - (i * 4 + 2));
                        result[0].Add((nLosers - 1) - (i * 4 + 1));
                        result[0].Add((nLosers - 1) - (i * 4));
                    }

                    result.AddRange(prev);
                }
                else
                {
                    if (nPlayers == 16)
                    {
                        // special: 16
                        prev = new List<List<int>>(2);
                        prev.Add(new List<int>(4));
                        prev[0].Add(2);
                        prev[0].Add(3);
                        prev[0].Add(0);
                        prev[0].Add(1);
                        prev.Add(new List<int>(2));
                        prev[1].Add(0);
                        prev[1].Add(1);
                    }
                    else if (nPlayers == 8)
                    {
                        // special: 8
                        prev = new List<List<int>>(1);
                        prev.Add(new List<int>(2));
                        prev[0].Add(1);
                        prev[0].Add(0);
                    }
                    else
                    {
                        // normal recursion
                        prev = GenJumpSlotLists(nPlayers / 2, Settings, false);
                    }
                    // First Level is 01234...
                    result.Add(new List<int>(nLosers));
                    for (i = 0; i < nLosers; i ++ )
                    {
                        result[0].Add(i);
                    }

                    result.AddRange(prev);
                }
            }
            else
            {
                if (nPlayers > 8)
                {
                    prev = GenJumpSlotLists((int)Math.Round(nPlayers / 2.0), Settings, false);
                    result.Add(new List<int>(nLosers));
                    sublen = prev[0].Count;
                    tmp = new int[sublen];
                    for (i = 0; i < sublen; i ++ )
                    {
                        tmp[i] = prev[0][i] + sublen;
                    }
                    if ((prev.Count + 1) % 2 == 0)
                    {
                        result[0].AddRange(prev[0]);
                        result[0].AddRange(tmp);
                    }
                    else
                    {
                        result[0].AddRange(tmp);
                        result[0].AddRange(prev[0]);
                    }

                    result.AddRange(prev);
                }
                else
                {
                    result = new List<List<int>>(2);
                    result.Add(new List<int>(4));
                    result[0][0] = 0;
                    result[0][1] = 1;
                    result[0][2] = 2;
                    result[0][3] = 3;
                    result.Add(new List<int>(2));
                    result[1][0] = 1;
                    result[1][1] = 0;
                }
            }
            return result;
        }

        public static List<List<int>> GenJumpSlotLists(int nPlayers, TSettings Settings)
        {
            return GenJumpSlotLists(nPlayers, Settings, true);
        }

        public static string TableStr(string s, int l, byte p)
        {
            string result;
            if (s.Length > l)
            {
                result = s.Substring(1 - 1 ,l);
            }
            else
            {
                result = s;
                if (p == 1)
                {
                    // left
                    while (result.Length < l)
                    {
                        result = result + ' ';
                    }
                }
                else if (p == 2)
                {
                    // right
                    while (result.Length < l)
                    {
                        result = ' ' + result;
                    }
                }
                else
                {
                    // center
                    while (result.Length < (l - 1))
                    {
                        result = ' ' + result + ' ';
                    }
                    if (result.Length == (l - 1))
                    {
                        result = result + ' ';
                    }
                }
            }
            return result;
        }

        public static string TableStr(string s)
        {
            return TableStr(s, 10);
        }

        public static string TableStr(string s, int l)
        {
            return TableStr(s, l, 0);
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, int l, Font font, ContentAlignment p, Brush brush, bool f, Pen fpen)
        {
            b.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            SizeF textSize = b.MeasureString(s, font);
            if ((l !=  -1) && (textSize.Width > l))
            {
                while (textSize.Width > l)
                {
                    s = s.Substring(0, s.Length - 1);
                    textSize = b.MeasureString(s + "…", font);
                }
                b.DrawString(s + "…", font, brush, x, y);
            }
            else
            {
                if (p == System.Drawing.ContentAlignment.TopLeft)
                {
                    // left
                    b.DrawString(s, font, brush, x, y);
                }
                else if (p == System.Drawing.ContentAlignment.TopRight)
                {
                    // right
                    b.DrawString(s, font, brush, x + l - textSize.Width, y);
                }
                else
                {
                    // center
                    b.DrawString(s, font, brush, (float)(x + Math.Floor((l - textSize.Width) / 2.0f)), y);
                }
            }
            if (f)
            {
                b.DrawRectangle(fpen, x, y, l, textSize.Height + 1);
            }
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, Font font)
        {
            CanvasStr(b, x, y, s, 100, font);
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, int l, Font font)
        {
            CanvasStr(b, x, y, s, l, font, System.Drawing.ContentAlignment.TopCenter);
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, int l, Font font, ContentAlignment p)
        {
            CanvasStr(b, x, y, s, l, font, p, new SolidBrush(Color.Black));
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, int l, Font font, ContentAlignment p, Brush brush)
        {
            CanvasStr(b, x, y, s, l, font, p, brush, false, null);
        }

        public static void CanvasStr(Graphics b, int x, int y, string s, int l, Font font, ContentAlignment p, Brush brush, bool f)
        {
            CanvasStr(b, x, y, s, l, font, p, brush, f, new Pen(Color.Gray));
        }

        public static void CanvasLine(Graphics b, int x1, int y1, int x2, int y2, Color pencl)
        {
            b.DrawLine(new Pen(pencl), x1, y1, x2, y2);
        }

        public static string BoolToStr(bool b)
        {
            string result;
            if (b)
            {
                result = "true";
            }
            else
            {
                result = "false";
            }
            return result;
        }

        public static string TimeToStr(int t, TIMEFORMAT fmt)
        {
            if (t ==  -1)
            {
                switch(fmt)
                {
                    case UClass.TIMEFORMAT.TIMEFMT_HMS:
                        return "-:--:--";
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_HM:
                        return "-:--";
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_MS:
                        return "-:--";
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_S:
                        return "-";
                        break;
                }
            }
            else
            {
                TimeSpan ts = TimeSpan.FromSeconds(t);
                switch(fmt)
                {
                    case UClass.TIMEFORMAT.TIMEFMT_HMS:
                        return string.Format("{0:D}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_HM:
                        return string.Format("{0:D}:{1:D2}", ts.Hours, ts.Minutes);
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_MS:
                        return string.Format("{0:D}:{1:D2}", ts.Minutes, ts.Seconds);
                        break;
                    case UClass.TIMEFORMAT.TIMEFMT_S:
                        return t.ToString();
                        break;
                }
            }
            return "-";
        }

        public static string TimeToStr(int t)
        {
            return TimeToStr(t, UClass.TIMEFORMAT.TIMEFMT_MS);
        }

        public static string PlayerToStr(TPlayer p, bool includePrename, bool includeClub)
        {
            string result;
            if (p != null)
            {
                if ((p.Club != "") && includeClub)
                {
                    if ((p.Prename != "") && includePrename)
                    {
                        result = p.Lastname + ", " + p.Prename + " (" + p.Club + ')';
                    }
                    else
                    {
                        result = p.Lastname + " (" + p.Club + ')';
                    }
                }
                else if ((p.Prename != "") && includePrename)
                {
                    result = p.Lastname + ", " + p.Prename;
                }
                else
                {
                    result = p.Lastname;
                }
            }
            else
            {
                result = "?";
            }
            return result;
        }

        public static string PlayerToStr(TPlayer p)
        {
            return PlayerToStr(p, true);
        }

        public static string PlayerToStr(TPlayer p, bool includePrename)
        {
            return PlayerToStr(p, includePrename, true);
        }

        public static void CopyToArray(int[] src, ref int[] dest, int index)
        {
            int i;
            for (i = 0; i < src.Length; i ++ )
            {
                dest[index + i] = src[i];
            }
        }

        // TODO: Find better/faster version, builtin version
        public static string[] Explode(string s, char sep)
        {
            string[] result;
            int i;
            int p;
            result = new string[0];
            p = 0;
            // = Length(Result) - 1
            result = new string[1];
            for (i = 1; i <= s.Length; i ++ )
            {
                if (s[i] == sep)
                {
                    p = p + 1;
                    result = new string[p + 1];
                }
                else
                {
                    result[p] = result[p] + s[i];
                }
            }
            return result;
        }

    } // end UHelpers

}

