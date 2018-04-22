using System;
using System.Drawing;
using System.Collections.Generic;
using UClass;
using UHelpers;
namespace UGameRR
{
    public class TGameRR
    {
        public class TGameRRResultLine
        {
            public TGameRRResultLine(int position, TPlayer player, int winPoints, int lossPoints)
            {
                this.position = position;
                this.player = player;
                this.winPoints = winPoints;
                this.lossPoints = lossPoints;
            }

            public int position;
            public TPlayer player;
            public int winPoints;
            public int lossPoints;
        }

        public TPlayer[] Players;
        public int[,] PointsGrid;
        public int[,] TimeGrid;
        public int[] CountList;
        public TMatch CurrentMatch = null;
        public int CurrentA = 0;
        public int CurrentB = 0;
        public int nPlayers = 0;
        public DateTime TimeStarted;
        public TSettings Settings = null;
        //Constructor  Create( Candidates,  Settings)
        public TGameRR(TPlayer[] Candidates, TSettings Settings)
        {
            int i;
            int j;
            this.Settings = Settings;
            nPlayers = Candidates.Length;
            TimeStarted = DateTime.MinValue; //done in GetNextMatch
            // Copy Players to own List
            Players = new TPlayer[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                Players[i] = Candidates[i];
                Players[i].ID = i;
            }
            // Init Matrix and Counter Table
            PointsGrid = new int[nPlayers, nPlayers];
            TimeGrid = new int[nPlayers, nPlayers];
            CountList = new int[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = 0; j < nPlayers; j ++ )
                {
                    if (i == j)
                    {
                        PointsGrid[i,j] =  -1;
                        TimeGrid[i,j] =  -1;
                    }
                    else
                    {
                        PointsGrid[i,j] = 0;
                        TimeGrid[i,j] = 0;
                    }
                }
                CountList[i] = 99;
            }
            // Create Match to point on later
            CurrentMatch = new TMatch();
            CurrentA = 0;
            CurrentB = 0;
        }
        //Constructor  FromString( s,  Settings)
        public TGameRR(string s, TSettings Settings)
        {
            string[] a;
            string[] b;
            int i;
            int j;
            this.Settings = Settings;
            // Create Match to point on later
            CurrentMatch = new TMatch();
            CurrentA = 0;
            CurrentB = 0;
            a = UHelpers.UHelpers.Explode(s, Units.Class.SEP_GAME);
            // Players + nPlayers
            b = UHelpers.UHelpers.Explode(a[1], Units.Class.SEP_LIST);
            nPlayers = b.Length;
            Players = new TPlayer[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                Players[i] = new TPlayer(b[i]);
            }
            // PointsGrid
            b = UHelpers.UHelpers.Explode(a[2], Units.Class.SEP_LIST);
            PointsGrid = new int[nPlayers, nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = 0; j < nPlayers; j ++ )
                {
                    PointsGrid[i, j] = Convert.ToInt32(b[i * nPlayers + j]);
                }
            }
            // TimeGrid
            b = UHelpers.UHelpers.Explode(a[3], Units.Class.SEP_LIST);
            PointsGrid = new int[nPlayers, nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = 0; j < nPlayers; j ++ )
                {
                    TimeGrid[i, j] = Convert.ToInt32(b[i * nPlayers + j]);
                }
            }
            // CountList
            b = UHelpers.UHelpers.Explode(a[4], Units.Class.SEP_LIST);
            CountList = new int[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                CountList[i] = Convert.ToInt32(b[i]);
            }
            // TimeStarted
            TimeStarted = Convert.ToDateTime(a[5]);
        }
        public string ToString()
        {
            string result;
            int i;
            int j;
            result = "RR" + Units.Class.SEP_GAME;
            // Players + nPlayers
            for (i = 0; i < Players.Length; i ++ )
            {
                if (i != 0)
                {
                    result = result + Units.Class.SEP_LIST;
                }
                result = result + Players[i].ToString();
            }
            result = result + Units.Class.SEP_GAME;
            // PointsGrid
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = 0; j < nPlayers; j ++ )
                {
                    if ((i + j != 0))
                    {
                        result = result + Units.Class.SEP_LIST;
                    }
                    result = result + (PointsGrid[i, j]).ToString();
                }
            }
            result = result + Units.Class.SEP_GAME;
            // TimeGrid
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = 0; j < nPlayers; j ++ )
                {
                    if ((i + j != 0))
                    {
                        result = result + Units.Class.SEP_LIST;
                    }
                    result = result + (TimeGrid[i, j]).ToString();
                }
            }
            result = result + Units.Class.SEP_GAME;
            // CountList
            for (i = 0; i < nPlayers; i ++ )
            {
                if (i != 0)
                {
                    result = result + Units.Class.SEP_LIST;
                }
                result = result + (CountList[i]).ToString();
            }
            result = result + Units.Class.SEP_GAME;
            // TimeStarted
            result = result + (TimeStarted).ToString();
            // TODO: unix?
            // not required: CurrentMatch, CurrentA, CurrentB, Settings

            return result;
        }

        public TMatch GetNextMatch()
        {
            TMatch result;
            int i;
            int i1;
            int v1;
            int i2;
            int v2;
            if (TimeStarted == DateTime.MinValue)
            {
                TimeStarted = DateTime.Now;
            }
            v1 = 0;
            v2 = 0;
            i1 =  -1;
            i2 =  -1;
            // First Player
            for (i = 0; i < nPlayers; i ++ )
            {
                if (CountList[i] > v1)
                {
                    i1 = i;
                    v1 = CountList[i];
                }
            }
            // Second Player
            for (i = 0; i < nPlayers; i ++ )
            {
                if ((CountList[i] > v2) && (TimeGrid[i1,i] == 0))
                {
                    i2 = i;
                    v2 = CountList[i];
                }
            }
            if (i2 ==  -1)
            {
                // TODO: understand why i did this part
                if (i1 == nPlayers - 1)
                {
                    result = null;
                }
                else
                {
                    CountList[i1] = 0;
                    result = GetNextMatch();
                }
            }
            else
            {
                // Fake Match
                if (i1 < i2)
                {
                    CurrentMatch.PlayerA = Players[i1];
                    CurrentMatch.PlayerB = Players[i2];
                    CurrentA = i1;
                    CurrentB = i2;
                }
                else
                {
                    CurrentMatch.PlayerA = Players[i2];
                    CurrentMatch.PlayerB = Players[i1];
                    CurrentA = i2;
                    CurrentB = i1;
                }
                result = CurrentMatch;
            }
            return result;
        }

        public TMatch GetPreparingMatch(bool bIncludeAuto)
        {
            TMatch result;
            int[] _CountList;
            int _CurrentA;
            int _CurrentB;
            int _FightTimeAB;
            int _FightTimeBA;
            int i;
            _FightTimeAB = TimeGrid[CurrentA,CurrentB];
            _FightTimeBA = TimeGrid[CurrentB,CurrentA];
            _CurrentA = CurrentA;
            _CurrentB = CurrentB;
            _CountList = new int[CountList.Length];
            UHelpers.UHelpers.CopyToArray(CountList, ref _CountList, 0);
            TimeGrid[CurrentA,CurrentB] = 1;
            TimeGrid[CurrentB,CurrentA] = 1;
            for (i = 0; i < nPlayers; i ++ )
            {
                CountList[i] = CountList[i] + 1;
            }
            CountList[CurrentA] = 1;
            CountList[CurrentB] = 1;
            result = GetNextMatch();
            CurrentA = _CurrentA;
            CurrentB = _CurrentB;
            UHelpers.UHelpers.CopyToArray(_CountList, ref CountList, 0);
            TimeGrid[CurrentA,CurrentB] = _FightTimeAB;
            TimeGrid[CurrentB,CurrentA] = _FightTimeBA;
            return result;
        }

        public TMatch GetPreparingMatch()
        {
            return GetPreparingMatch(false);
        }

        public void FinishCurrentMatch(int PlayerAPoints, int PlayerBPoints, int FightTime)
        {
            int i;
            // Save data
            PointsGrid[CurrentA,CurrentB] = PlayerAPoints;
            PointsGrid[CurrentB,CurrentA] = PlayerBPoints;
            if (FightTime == 0)
            {
                FightTime = 1;
            }
            TimeGrid[CurrentA,CurrentB] = FightTime;
            TimeGrid[CurrentB,CurrentA] = FightTime;
            for (i = 0; i < nPlayers; i ++ )
            {
                CountList[i] = CountList[i] + 1;
            }
            CountList[CurrentA] = 1;
            CountList[CurrentB] = 1;
        }

        public List<TGameRRResultLine> ResultList(TGameRR StoredGame)
        {
            List<TGameRRResultLine> result = new List<TGameRRResultLine>();
            int i;
            int j;
            int k;
            int l;
            int n;
            int index;
            int nbad;
            int[] tmplist;
            int[] sumwin;
            int[] sumwin2;
            int[] sumcount2;
            int[] sumpoints;
            bool[] dealtwith;
            bool bad;
            List<TGameRRResultLine> StoreResult;
            sumwin = new int[nPlayers];
            sumpoints = new int[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                sumwin[i] = 0;
                sumpoints[i] = 0;
                for (j = 0; j < nPlayers; j ++ )
                {
                    if (PointsGrid[i,j] !=  -1)
                    {
                        sumpoints[i] = sumpoints[i] + (PointsGrid[i,j] - PointsGrid[j,i]);
                    }
                    if (PointsGrid[i,j] > PointsGrid[j,i])
                    {
                        sumwin[i] = sumwin[i] + 1;
                    }
                }
            }
            // Order by Wins/Points/DirectResult
            tmplist = new int[nPlayers];
            for (i = 0; i < nPlayers; i ++ )
            {
                tmplist[i] = i;
            }
            for (n = 0; n < nPlayers; n ++ )
            {
                index = 0;
                // Find best Player
                for (i = 0; i < nPlayers - n; i++)
                {
                    if (i != index)
                    {
                        if (sumwin[tmplist[i]] > sumwin[tmplist[index]])
                        {
                            index = i;
                        }
                        else if (sumwin[tmplist[i]] == sumwin[tmplist[index]])
                        {
                            if (sumpoints[tmplist[i]] > sumpoints[tmplist[index]])
                            {
                                index = i;
                            }
                            else if (sumpoints[tmplist[i]] == sumpoints[tmplist[index]])
                            {
                                if (PointsGrid[tmplist[i],tmplist[index]] > PointsGrid[tmplist[index],tmplist[i]])
                                {
                                    index = i;
                                // TODO: dreiecksschlag erkennen
                                // end else begin //this means two players are fully equal
                                // equalwithnext := TRUE;
                                }
                            }
                        }
                    }
                }
                result.Add(new TGameRRResultLine(n + 1, Players[tmplist[index]], sumwin[tmplist[index]], sumpoints[tmplist[index]]));
                for (i = index; i <= tmplist.Length - 2; i ++ )
                {
                    tmplist[i] = tmplist[i + 1];
                }
            }
            // Check for circles
            tmplist = new int[0];
            dealtwith = new bool[nPlayers];
            nbad = 0;
            for (i = 0; i < nPlayers; i ++ )
            {
                dealtwith[i] = false;
            }
            for (i = 0; i < nPlayers; i ++ )
            {
                if (dealtwith[i] == false)
                {
                    tmplist = new int[1];
                    tmplist[0] = i;
                    dealtwith[i] = true;
                    for (j = 0; j < nPlayers; j ++ )
                    {
                        if (!dealtwith[j] && (sumwin[i] == sumwin[j]) && (sumpoints[i] == sumpoints[j]))
                        {
                            tmplist = new int[tmplist.Length + 1];
                            tmplist[tmplist.Length - 1] = j;
                            dealtwith[j] = true;
                        }
                    }
                    if (tmplist.Length > 2)
                    {
                        // more than 2 players with that score means we have to verify they havent beaten each other in a circle
                        bad = false;
                        sumwin2 = new int[tmplist.Length];
                        sumcount2 = new int[tmplist.Length];
                        for (k = 0; k < tmplist.Length; k ++ )
                        {
                            sumcount2[k] = 0;
                        }
                        for (k = 0; k < tmplist.Length; k ++ )
                        {
                            sumwin2[k] = 0;
                            for (l = 0; l < tmplist.Length; l ++ )
                            {
                                if (PointsGrid[tmplist[k],tmplist[l]] > PointsGrid[tmplist[l],tmplist[k]])
                                {
                                    sumwin2[tmplist[k]] = sumwin2[tmplist[k]] + 1;
                                }
                            }
                            sumcount2[sumwin2[k]] = sumcount2[sumwin2[k]] + 1;
                        }
                        for (k = 0; k <= tmplist.Length - 2; k ++ )
                        {
                            if (sumcount2[k] > 2)
                            {
                                bad = true;
                            }
                        }
                        if (bad)
                        {
                            for (k = 0; k < nPlayers; k ++ )
                            {
                                for (l = 0; l < tmplist.Length; l ++ )
                                {
                                    if (result[k].player == Players[tmplist[l]])
                                    {
                                        result[k].position =  -1 - nbad;
                                    }
                                }
                            }
                            nbad = nbad + 1;
                        }
                    }
                }
            }
            if (StoredGame != null)
            {
                // combine both lists
                StoreResult = StoredGame.ResultList();
                for (i = 0; i < result.Count; i ++ )
                {
                    StoreResult[i].position = StoreResult[i].position ==  -1 ? result[i].position : StoreResult[i].position;
                    StoreResult[i].player = StoreResult[i].player;
                    StoreResult[i].winPoints = StoreResult[i].winPoints + result[i].winPoints;
                    StoreResult[i].lossPoints = StoreResult[i].lossPoints + result[i].lossPoints;
                }
                result = StoreResult;
            }
            return result;
        }

        public List<TGameRRResultLine> ResultList()
        {
            return ResultList(null);
        }

        public Bitmap ResultBitmap(TGameRR StoredGame)
        {
            Bitmap result;
            List<TGameRRResultLine> list;
            int i;
            list = ResultList(StoredGame);
            result = new Bitmap(300, 20 * list.Count + 40);
            Graphics graphics = Graphics.FromImage(result);
            Font bigFont = new Font("Arial", 20);
            Font font = new Font("Arial", 11);
            UHelpers.UHelpers.CanvasStr(graphics, 20, 5, "Ergebnisse",  -1, bigFont, System.Drawing.ContentAlignment.TopLeft);
            for (i = 0; i < list.Count; i ++ )
            {
                if (list[i].position != 0)
                {
                    UHelpers.UHelpers.CanvasStr(graphics, 20, 40 + i * 20, (list[i].position).ToString() + ". " + UHelpers.UHelpers.PlayerToStr(list[i].player) + " [" + (list[i].winPoints).ToString() + '/' + (list[i].lossPoints).ToString() + ']',  -1, font, System.Drawing.ContentAlignment.TopLeft);
                }
                else
                {
                    UHelpers.UHelpers.CanvasStr(graphics, 20, 25 + i * 20, (list[i].position).ToString() + ". ?", -1, font, System.Drawing.ContentAlignment.TopLeft);
                }
            }
            // CanvasLine(Result,0,0,Result.Width,Result.Height,clRed);
            // CanvasLine(Result,0,Result.Height,Result.Width,0,clRed);

            return result;
        }

        public Bitmap ResultBitmap()
        {
            return ResultBitmap(null);
        }

        public string DebugString()
        {
            string result;
            int i;
            int j;
            int sumwin;
            int sumpoints;
            int sumlosepoints;
            result = UHelpers.UHelpers.TableStr("", 30);
            for (j = 0; j < nPlayers; j ++ )
            {
                result = result + UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(Players[j], false, false));
            }
            result = result + UHelpers.UHelpers.TableStr("Siege", 6) + UHelpers.UHelpers.TableStr("Punkte", 12);
            result = result + (char)(13);
            for (i = 0; i < nPlayers; i ++ )
            {
                result = result + UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(Players[i]), 30, 2);
                sumwin = 0;
                sumpoints = 0;
                sumlosepoints = 0;
                for (j = 0; j < nPlayers; j ++ )
                {
                    if (PointsGrid[i,j] !=  -1)
                    {
                        sumpoints = sumpoints + PointsGrid[i,j];
                    }
                    if (PointsGrid[i,j] !=  -1)
                    {
                        sumlosepoints = sumlosepoints - PointsGrid[j,i];
                    }
                    if (PointsGrid[i,j] > PointsGrid[j,i])
                    {
                        sumwin = sumwin + 1;
                    }
                    if (TimeGrid[i,j] == 0)
                    {
                        result = result + UHelpers.UHelpers.TableStr("?");
                    }
                    else if (TimeGrid[i,j] ==  -1)
                    {
                        result = result + UHelpers.UHelpers.TableStr("-");
                    }
                    else
                    {
                        result = result + UHelpers.UHelpers.TableStr((PointsGrid[i,j]).ToString());
                    }
                }
                result = result + UHelpers.UHelpers.TableStr((sumwin).ToString(), 6) + UHelpers.UHelpers.TableStr((sumpoints).ToString(), 2) + UHelpers.UHelpers.TableStr(":", 1) + UHelpers.UHelpers.TableStr((sumlosepoints).ToString(), 3) + UHelpers.UHelpers.TableStr(" ", 1) + UHelpers.UHelpers.TableStr('(' + (sumpoints + sumlosepoints).ToString() + ')', 5);
                result = result + (char)(13);
            }
            // CurrentStat Stuff
            // Result := Result + chr(13);
            // for i := 0 to nPlayers-1 do
            // Result := Result + TableStr(inttostr(i),5);
            // Result := Result + chr(13);
            // for i := 0 to nPlayers-1 do
            // Result := Result + TableStr(inttostr(CountList[i]),5);

            return result;
        }

        public Bitmap ToBitmap(TGameRR StoredGame, int FontSize)
        {
            Bitmap result;
            int i;
            int j;
            int sumwin;
            int sumpoints;
            int sumlosepoints;
            int chh;
            int chw;
            int lh;
            int width;
            int height;
            int fcw;
            int cw;
            int wcw;
            int pcw;
            int ox;
            int oy;
            Bitmap StoreResult;
            int origWidth;
            int origHeight;
            result = new Bitmap(300, 300);
            Graphics graphics = Graphics.FromImage(result);
            Font font = new Font("Arial", FontSize);
            Pen pen = new Pen(Color.Gray);

            // master offset for nice printing / display
            ox = 10;
            oy = 10;
            // height of one captial Char in current Font
            chh = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Height);
            lh = chh + 1;
            // line height
            // col widths (load dynamically?)
            // width of one Char in current Font
            chw = (int)Math.Ceiling(graphics.MeasureString("A", font).Width * 0.8);
            fcw = 15 * chw;
            // first col, long names
            cw = 10 * chw;
            // normal col len
            wcw = 5 * chw;
            // wins
            pcw = 10 * chw;
            // points
            width = fcw + nPlayers * cw + wcw + pcw + 1;
            height = lh * (nPlayers + 1) + 1;

            result = new Bitmap(2 * ox + width, 2 * oy + height);
            graphics = Graphics.FromImage(result);
            // Result.Canvas.Pen.Color := clGray;
            // Result.Canvas.Rectangle(0,0,width,height);
            //@ Unsupported property or method(C): 'Canvas'
            //@ Unsupported property or method(D): 'Pen'
            //@ Unsupported property or method(D): 'Color'
            UHelpers.UHelpers.CanvasLine(graphics, ox, oy, ox + width, oy, System.Drawing.Color.Gray);
            UHelpers.UHelpers.CanvasLine(graphics, ox, oy, ox, oy + height, System.Drawing.Color.Gray);
            for (j = 0; j < nPlayers; j ++ )
            {
                UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + j * cw, oy + 1, UHelpers.UHelpers.PlayerToStr(Players[j], false, false), cw, font, System.Drawing.ContentAlignment.TopRight);
            }
            UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + nPlayers * cw, oy + 1, "Siege", wcw, font);
            UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + nPlayers * cw + wcw, oy + 1, "Punkte", pcw, font);
            UHelpers.UHelpers.CanvasLine(graphics, ox, oy + chh + 1, ox + width, oy + chh + 1, System.Drawing.Color.Gray);
            for (i = 0; i < nPlayers; i ++ )
            {
                UHelpers.UHelpers.CanvasStr(graphics, ox + 1, oy + lh * (i + 1) + 1, UHelpers.UHelpers.PlayerToStr(Players[i]), fcw - 2, font, System.Drawing.ContentAlignment.TopLeft);
                sumwin = 0;
                sumpoints = 0;
                sumlosepoints = 0;
                for (j = 0; j < nPlayers; j ++ )
                {
                    if (PointsGrid[i,j] !=  -1)
                    {
                        sumpoints = sumpoints + PointsGrid[i,j];
                    }
                    if (PointsGrid[i,j] !=  -1)
                    {
                        sumlosepoints = sumlosepoints - PointsGrid[j,i];
                    }
                    if (PointsGrid[i,j] > PointsGrid[j,i])
                    {
                        sumwin = sumwin + 1;
                    }
                    if (TimeGrid[i,j] == 0)
                    {
                        UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + j * cw, oy + lh * (i + 1) + 1, "?", cw, font);
                    }
                    else if (TimeGrid[i,j] !=  -1)
                    {
                        // CanvasStr(Result,ox+fcw+j*cw,oy+lh*(i+1)+1,'-',cw)
                        // else
                        UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + j * cw, oy + lh * (i + 1) + 1, (PointsGrid[i, j]).ToString(), cw, font);
                    }
                }
                UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + nPlayers * cw, oy + lh * (i + 1) + 1, (sumwin).ToString(), wcw, font);
                UHelpers.UHelpers.CanvasStr(graphics, ox + fcw + nPlayers * cw + wcw, oy + lh * (i + 1) + 1, (sumpoints).ToString() + ':' + (sumlosepoints).ToString() + " (" + (sumpoints + sumlosepoints).ToString() + ')', pcw, font);
                UHelpers.UHelpers.CanvasLine(graphics, ox, oy + lh * (i + 1) + 1 + chh, ox + width, oy + lh * (i + 1) + 1 + chh, System.Drawing.Color.Gray);
            }
            UHelpers.UHelpers.CanvasLine(graphics, ox + fcw, oy, ox + fcw, oy + height, System.Drawing.Color.Gray);
            for (j = 0; j < nPlayers; j ++ )
            {
                UHelpers.UHelpers.CanvasLine(graphics, ox + fcw + (j + 1) * cw, ox, ox + fcw + (j + 1) * cw, oy + height, System.Drawing.Color.Gray);
            }
            UHelpers.UHelpers.CanvasLine(graphics, ox + fcw + nPlayers * cw + wcw, oy, ox + fcw + nPlayers * cw + wcw, oy + height, System.Drawing.Color.Gray);
            UHelpers.UHelpers.CanvasLine(graphics, ox + fcw + nPlayers * cw + wcw + pcw, oy, ox + fcw + nPlayers * cw + wcw + pcw, oy + height, System.Drawing.Color.Gray);
            if (StoredGame != null)
            {
                // combine both images
                origWidth = result.Width;
                origHeight = result.Height;
                StoreResult = StoredGame.ToBitmap();
                Bitmap thisResult = result;
                result = new Bitmap(StoreResult.Width > origWidth ? StoreResult.Width : origWidth, StoreResult.Height + 5 + origHeight);
                graphics = Graphics.FromImage(result);
                graphics.DrawImage(thisResult, new Rectangle(0, StoreResult.Height + 5, origWidth, origHeight), new Rectangle(0, 0, origWidth, origHeight), GraphicsUnit.Pixel);
                graphics.DrawImage(thisResult, new Rectangle(0, 0, StoreResult.Width, StoreResult.Height), new Rectangle(0, 0, StoreResult.Width, StoreResult.Height), GraphicsUnit.Pixel);
            }
            return result;
        }

        public Bitmap ToBitmap()
        {
            return ToBitmap(null);
        }

        public Bitmap ToBitmap(TGameRR StoredGame)
        {
            return ToBitmap(StoredGame, 8);
        }

        public Bitmap ToBitmapResult(TGameRR StoredGame, Bitmap Logo, int FontSize)
        {
            Bitmap result;
            Bitmap GameBitmap;
            Bitmap ListBitmap;
            int sw;
            // Distance between Table and List
            sw = 20;
            GameBitmap = ToBitmap(StoredGame, FontSize);
            ListBitmap = ResultBitmap(StoredGame);
            result = new Bitmap(GameBitmap.Width < ListBitmap.Width + 200 ? ListBitmap.Width + 200 : GameBitmap.Width, GameBitmap.Height + sw + 200);
            Graphics graphics = Graphics.FromImage(result);
            graphics.DrawImage(GameBitmap, new Rectangle(0, 0, GameBitmap.Width, GameBitmap.Height), new Rectangle(0, 0, GameBitmap.Width, GameBitmap.Height), GraphicsUnit.Pixel);
            graphics.DrawImage(ListBitmap, new Rectangle(0, GameBitmap.Height + sw, ListBitmap.Width, ListBitmap.Height), new Rectangle(0, 0, ListBitmap.Width, ListBitmap.Height), GraphicsUnit.Pixel);
            if (Logo != null)
            {
                graphics.DrawImage(Logo, new Rectangle(result.Width - 200, result.Height - 200, 200, 200), new Rectangle(0, 0, Logo.Width, Logo.Height), GraphicsUnit.Pixel);
            }
            return result;
        }

        public Bitmap ToBitmapResult()
        {
            return ToBitmapResult(null);
        }

        public Bitmap ToBitmapResult(TGameRR StoredGame)
        {
            return ToBitmapResult(StoredGame, null);
        }

        public Bitmap ToBitmapResult(TGameRR StoredGame, Bitmap Logo)
        {
            return ToBitmapResult(StoredGame, Logo, 8);
        }

        public TGameStats GetStats()
        {
            TGameStats result;
            int i;
            int j;
            result.FightsDone = 0;
            result.FightsTotal = 0;
            result.TimeDone = 0;
            result.TimeTotalAssumed = 0;
            result.FightTimeDone = 0;
            result.FightTimeTotalAssumed = 0;
            for (i = 0; i < nPlayers; i ++ )
            {
                for (j = i + 1; j < nPlayers; j ++ )
                {
                    if (TimeGrid[i,j] != 0)
                    {
                        result.FightsDone = result.FightsDone + 1;
                        result.FightTimeDone = result.FightTimeDone + TimeGrid[i,j];
                    }
                    result.FightsTotal = result.FightsTotal + 1;
                }
            }
            result.TimeDone = (int)(DateTime.Now - TimeStarted).TotalSeconds;
            if (result.FightsDone != 0)
            {
                result.TimeTotalAssumed = (int)Math.Round((double)result.TimeDone / result.FightsDone * result.FightsTotal);
                result.FightTimeTotalAssumed = (int)Math.Round((double)result.FightTimeDone / result.FightsDone * result.FightsTotal);
            }
            return result;
        }

    } // end TGameRR

}

