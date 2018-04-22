using System;
using System.Drawing;
using System.IO;
using UHelpers;

namespace UClass
{
    public class TPlayer
    {
        public int ID = 0;
        public string Prename = String.Empty;
        public string Lastname = String.Empty;
        public string Club = String.Empty;

        public TPlayer() { }

        //Constructor  FromString( s)
        public TPlayer(string s)
        {
            string[] a;
            a = UHelpers.UHelpers.Explode(s, Units.Class.SEP_PLAYER);
            ID = Convert.ToInt32(a[0]);
            Prename = a[1];
            Lastname = a[2];
            Club = a[3];
        }
        public string ToString()
        {
            string result;
            result = (ID).ToString() + Units.Class.SEP_PLAYER + Prename + Units.Class.SEP_PLAYER + Lastname + Units.Class.SEP_PLAYER + Club;
            return result;
        }

    } // end TPlayer

    public class TMatch
    {
        public TPlayer PlayerA = null;
        public TPlayer PlayerB = null;
        public int PlayerAPoints = 0;
        public int PlayerBPoints = 0;
        public int FightTime = 0;
        //Constructor  Create()
        public TMatch()
        {
            PlayerA = null;
            PlayerB = null;
            PlayerAPoints = 0;
            PlayerBPoints = 0;
            FightTime = 0;
        }
        //Constructor  FromString( s,  Players,  LosePlayer)
        public TMatch(string s, TPlayer[] Players, TPlayer LosePlayer)
        {
            string[] a;
            a = UHelpers.UHelpers.Explode(s, Units.Class.SEP_MATCH);
            if (a[0] == Units.Class.ID_NO_PLAYER_STR)
            {
                PlayerA = null;
            }
            else if (a[0] == Units.Class.ID_LOSE_PLAYER_STR)
            {
                PlayerA = LosePlayer;
            }
            else
            {
                PlayerA = Players[Convert.ToInt32(a[0])];
            }
            if (a[1] == Units.Class.ID_NO_PLAYER_STR)
            {
                PlayerB = null;
            }
            else if (a[1] == Units.Class.ID_LOSE_PLAYER_STR)
            {
                PlayerB = LosePlayer;
            }
            else
            {
                PlayerB = Players[Convert.ToInt32(a[1])];
            }
            PlayerAPoints = Convert.ToInt32(a[2]);
            PlayerBPoints = Convert.ToInt32(a[3]);
            FightTime = Convert.ToInt32(a[4]);
        }
        public string ToString()
        {
            string result;
            if (PlayerA == null)
            {
                result = Units.Class.ID_NO_PLAYER_STR + Units.Class.SEP_MATCH;
            }
            else
            {
                result = (PlayerA.ID).ToString() + Units.Class.SEP_MATCH;
            }
            if (PlayerB == null)
            {
                result = result + Units.Class.ID_NO_PLAYER_STR + Units.Class.SEP_MATCH;
            }
            else
            {
                result = result + (PlayerB.ID).ToString() + Units.Class.SEP_MATCH;
            }
            result = result + (PlayerAPoints).ToString() + Units.Class.SEP_MATCH + (PlayerBPoints).ToString() + Units.Class.SEP_MATCH + (FightTime).ToString();
            return result;
        }

        public TPlayer Winner()
        {
            TPlayer result;
            if (FightTime == 0)
            {
                result = null;
            }
            else if (PlayerAPoints > PlayerBPoints)
            {
                result = PlayerA;
            }
            else
            {
                result = PlayerB;
            }
            return result;
        }

        public TPlayer Loser()
        {
            TPlayer result;
            if (FightTime == 0)
            {
                result = null;
            }
            else if (PlayerAPoints < PlayerBPoints)
            {
                result = PlayerA;
            }
            else
            {
                result = PlayerB;
            }
            return result;
        }

    } // end TMatch

    public class TSettings
    {
        public bool AutoResizeForm = false;
        public bool UseRedForPlayerA = false;
        public int ShortLoseRound = 0;
        public int FightDuration = 0;
        public bool SwitchStepsSystemAt32 = false;
        public bool SwitchJumpSlotOrderAt32 = false;
        public bool SaveToIni = false;
        public Bitmap Logo = null;
        //Constructor  Create()
        public TSettings()
        {
            Reset();
        }

        public void Reset()
        {
            AutoResizeForm = true;
            UseRedForPlayerA = false;
            ShortLoseRound = 6;
            FightDuration = 180;
            SwitchStepsSystemAt32 = true;
            SwitchJumpSlotOrderAt32 = true;
            SaveToIni = false;
            Logo = null;
        }

        public void WriteToFile(string Filename)
        {
            IniFile.IniFile IniFile = new IniFile.IniFile(Filename);
            IniFile.Write("AutoResizeForm", AutoResizeForm.ToString(), Units.Class.APPNAME);
            IniFile.Write("UseRedForPlayerA", UseRedForPlayerA.ToString(), Units.Class.APPNAME);
            IniFile.Write("ShortLoseRound", ShortLoseRound.ToString(), Units.Class.APPNAME);
            IniFile.Write("FightDuration", 180.ToString(), Units.Class.APPNAME);
            IniFile.Write("SwitchStepsSystemAt32", SwitchStepsSystemAt32.ToString(), Units.Class.APPNAME);
            IniFile.Write("SwitchJumpSlotOrderAt32", SwitchJumpSlotOrderAt32.ToString(), Units.Class.APPNAME);
        }

        public void ReadFromFile(string Filename)
        {
            Reset();
            if (File.Exists(Filename))
            {
                IniFile.IniFile IniFile = new IniFile.IniFile(Filename);
                if (IniFile.KeyExists("AutoResizeForm", Units.Class.APPNAME)) {
                    bool tmp;
                    int tmpInt;
                    AutoResizeForm = Boolean.TryParse(IniFile.Read("AutoResizeForm", Units.Class.APPNAME), out tmp) ? tmp : true;
                    UseRedForPlayerA = Boolean.TryParse(IniFile.Read("UseRedForPlayerA", Units.Class.APPNAME), out tmp) ? tmp : false;
                    ShortLoseRound = Int32.TryParse(IniFile.Read("ShortLoseRound", Units.Class.APPNAME), out tmpInt) ? tmpInt : 6;
                    FightDuration = Int32.TryParse(IniFile.Read("FightDuration", Units.Class.APPNAME), out tmpInt) ? tmpInt : 180;
                    SwitchStepsSystemAt32 = Boolean.TryParse(IniFile.Read("SwitchStepsSystemAt32", Units.Class.APPNAME), out tmp) ? tmp : true;
                    SwitchJumpSlotOrderAt32 = Boolean.TryParse(IniFile.Read("SwitchJumpSlotOrderAt32", Units.Class.APPNAME), out tmp) ? tmp : true;
                    SaveToIni = true;
                // obviously, there would not be a file otherwise
                }
            }
        }

        public void LoadImageFromFile(string Filename)
        {
            try {
                Logo = new Bitmap(Filename);
            }
            catch {
                Logo = null;
            }
        }

    } // end TSettings

    public struct TGameStats
    {
        public int FightsDone;
        public int FightsTotal;
        public int TimeDone;
        public int TimeTotalAssumed;
        public int FightTimeDone;
        public int FightTimeTotalAssumed;
    } // end TGameStats

    public enum TIMEFORMAT
    {
        TIMEFMT_HMS,
        TIMEFMT_HM,
        TIMEFMT_MS,
        TIMEFMT_S
    } // end TIMEFORMAT

}

namespace Units
{
    public class Class
    {
        public const string APPNAME = "Judoplaner";
        public const string VERSION = "0.6";
        public const string PRINTMARK = "Created with Judoplaner 0.6";
        public const string FILEEXT = ".jpgame";
        public const string LOGOFILE = "logo";
        public const string INIFILE = APPNAME;
        public const string BACKUPFILE = APPNAME + ".running";
        public const string STDSTR = "ABCDEFGHIJKLMOPQRSTUVWXYZ1234567890!\"§$%&/()=?²³{[]}\\,.;:<>|^°ß´`-#+_\'*~";
        // For To/FromString
        public const char SEP_PLAYER = '|';
        public const char SEP_MATCH = '|';
        // See TGroupForm.AddPlayerButtonClick when changing
        public const char SEP_LIST = '#';
        public const char SEP_GAME = '~';
        public const int ID_LOSE_PLAYER =  -1;
        public const string ID_LOSE_PLAYER_STR = "-1";
        public const char ID_NO_PLAYER = '-';
        public const string ID_NO_PLAYER_STR = "-";
    } // end UClass

}

