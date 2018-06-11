using System;
using System.Drawing;
using System.Collections.Generic;
using UClass;
using UHelpers;
namespace UGameDE
{
    public class TGameDE
    {
        public TPlayer[] Players;
        public TPlayer LosePlayer = null;
        public List<List<TMatch>> MainRound;
        public List<List<TMatch>> LoseRound;
        public int LevelMain = 0;
        public int LevelLose = 0;
        public int LevelSteps = 0;
        public int LenMain = 0;
        public int LenLose = 0;
        public int CurrentMatch = 0;
        public int[] MainSteps;
        public int[] LoseSteps;
        public List<List<int>> JumpSlots;
        public bool HandlingMain = false;
        public DateTime TimeStarted;
        public TSettings Settings = null;
        public bool ShortLoseRound = false;
        //Constructor  Create( Candidates,  Settings)
        public TGameDE(TPlayer[] Candidates, TSettings Settings)
        {
            int nGame;
            int nPlayers;
            int i;
            int j;
            int[] scrambled;
            this.Settings = Settings;
            nPlayers = Candidates.Length;
            TimeStarted = DateTime.MinValue; //done in GetNextMatch
            nGame = 8;
            while ((nGame < nPlayers))
            {
                nGame = nGame * 2;
            }
            // Copy Players to own List, Create LosePlayer
            Players = new TPlayer[nPlayers];
            for (i = 0; i < nPlayers; i++)
            {
                Players[i] = Candidates[i];
                Players[i].ID = i;
            }
            LosePlayer = new TPlayer();
            LosePlayer.ID = Units.Class.ID_LOSE_PLAYER;
            LosePlayer.Lastname = "-";
            LosePlayer.Prename = "";
            // playertostr will autmatically skip the prename if not present
            // Init Main
            LenMain = (int)(Math.Log(nGame) / Math.Log(2.0));
            MainRound = new List<List<TMatch>>();
            for (i = 0; i < LenMain; i++)
            {
                int size = (int)Math.Floor(nGame / Math.Pow(2.0, i + 1));
                MainRound.Add(new List<TMatch>(size));
                for (j = 0; j < size; j++)
                {
                    MainRound[i].Add(new TMatch());
                }
            }
            // Scramble Players and set to first Level
            scrambled = UHelpers.UHelpers.GenPlayerList(nGame);
            for (i = 0; i < Math.Floor(nGame / 2.0); i++)
            {
                if (scrambled[2 * i] - 1 < nPlayers)
                {
                    MainRound[0][i].PlayerA = Players[scrambled[2 * i] - 1];
                }
                else
                {
                    MainRound[0][i].PlayerA = LosePlayer;
                }
                if (scrambled[(2 * i) + 1] - 1 < nPlayers)
                {
                    MainRound[0][i].PlayerB = Players[scrambled[(2 * i) + 1] - 1];
                }
                else
                {
                    MainRound[0][i].PlayerB = LosePlayer;
                }
            }
            // Init Lose
            LoseRound = new List<List<TMatch>>();
            if ((Settings.ShortLoseRound == -1) || (Math.Pow(2.0, Settings.ShortLoseRound) >= nGame))
            {
                ShortLoseRound = false;
                LenLose = (int)(Math.Floor(Math.Log(nGame / 2) / Math.Log(2.0)) - 1) * 2;
                for (i = 0; i < LenLose; i++)
                {
                    int size = (int)Math.Floor(nGame / Math.Pow(2.0, Math.Ceiling((i + 3) / 2.0))); //TODO used to round up with comment screw this, verify
                    LoseRound.Add(new List<TMatch>(size));
                    for (j = 0; j < size; j++)
                    {
                        LoseRound[i].Add(new TMatch());
                    }
                }
            }
            else
            {
                // short LoseRound
                ShortLoseRound = true;
                LenLose = 2;
                LoseRound.Add(new List<TMatch>(2));
                LoseRound[0].Add(new TMatch());
                LoseRound[0].Add(new TMatch());
                LoseRound.Add(new List<TMatch>(2));
                LoseRound[1].Add(new TMatch());
                LoseRound[1].Add(new TMatch());
            }
            // Init JumpSlots
            if (!ShortLoseRound)
            {
                JumpSlots = UHelpers.UHelpers.GenJumpSlotLists(nGame, Settings);
            }
            else
            {
                JumpSlots = UHelpers.UHelpers.GenJumpSlotLists(8, Settings);
            }
            // Init CurrentStat
            MainSteps = new int[LenMain - 1];
            // M
            MainSteps[0] = 2;
            // 2
            for (i = 1; i <= LenMain - 2; i++)
            {
                // 1
                MainSteps[i] = 1;
            }
            // ...
            LoseSteps = new int[LenMain - 2];
            // L
            if (!ShortLoseRound)
            {
                if (!Settings.SwitchStepsSystemAt32 || (nPlayers <= 16))
                {
                    // only 8 and 16
                    // M 2 1 ... 1
                    // L 2 2 ...
                    for (i = 0; i <= LenMain - 3; i++)
                    {
                        // 2
                        LoseSteps[i] = 2;
                    }
                    // ...
                }
                else
                {
                    // M 2 1 1 ... 1 1
                    // L 1 1 2 ... 4
                    LoseSteps[0] = 1;
                    // 1
                    LoseSteps[1] = 1;
                    // 1
                    for (i = 2; i <= LenMain - 3; i++)
                    {
                        // 2
                        LoseSteps[i] = 2;
                    }
                    // ...
                    LoseSteps[LenMain - 3] = 4;
                    // 4
                }
            }
            else
            {
                // short LoseRound
                // there are only two steps
                // M 2 1 ... 1 1
                // L 0 0 ... 2
                for (i = 0; i <= LenMain - 3; i++)
                {
                    // 0
                    LoseSteps[i] = 0;
                }
                // ...
                LoseSteps[LenMain - 3] = 2;
                // 2
            }
            LevelMain = 0;
            LevelLose = 0;
            LevelSteps = 0;
            HandlingMain = true;
            CurrentMatch = -1;
            // Autoforward	    
            Autoforward();

        }
        //Constructor  FromString( s,  Settings)
        public TGameDE(string s, TSettings Settings)
        {
            string[] a;
            string[] b;
            int nGame;
            int nPlayers;
            int i;
            int j;
            int ctr;
            this.Settings = Settings;
            LosePlayer = new TPlayer();
            LosePlayer.ID = Units.Class.ID_LOSE_PLAYER;
            LosePlayer.Lastname = "-";
            LosePlayer.Prename = "";
            // playertostr will autmatically skip the prename if not present
            a = UHelpers.UHelpers.Explode(s, Units.Class.SEP_GAME);
            // Players + JumpSlots
            b = UHelpers.UHelpers.Explode(a[1], Units.Class.SEP_LIST);
            nPlayers = b.Length;
            Players = new TPlayer[nPlayers];
            for (i = 0; i < nPlayers; i++)
            {
                Players[i] = new TPlayer(b[i]);
            }
            nGame = 8;
            while ((nGame < nPlayers))
            {
                nGame = nGame * 2;
            }
            if (!ShortLoseRound)
            {
                JumpSlots = UHelpers.UHelpers.GenJumpSlotLists(nGame, Settings);
            }
            else
            {
                JumpSlots = UHelpers.UHelpers.GenJumpSlotLists(8, Settings);
            }
            // LevelMain,LevelLose,LevelSteps,LenMain,LenLose,CurrentMatch,HandlingMain,TimeStarted,ShortLoseRound
            b = UHelpers.UHelpers.Explode(a[2], Units.Class.SEP_LIST);
            LevelMain = Convert.ToInt32(b[0]);
            LevelLose = Convert.ToInt32(b[1]);
            LevelSteps = Convert.ToInt32(b[2]);
            LenMain = Convert.ToInt32(b[3]);
            LenLose = Convert.ToInt32(b[4]);
            CurrentMatch = Convert.ToInt32(b[5]);
            HandlingMain = Convert.ToBoolean(b[6]);
            TimeStarted = Convert.ToDateTime(b[7]);
            ShortLoseRound = Convert.ToBoolean(b[8]);
            // MainRound
            b = UHelpers.UHelpers.Explode(a[3], Units.Class.SEP_LIST);
            MainRound = new List<List<TMatch>>();
            ctr = 0;
            for (i = 0; i < LenMain; i++)
            {
                int size = (int)Math.Floor(nGame / Math.Pow(2.0, i + 1));
                MainRound.Add(new List<TMatch>(size));
                for (j = 0; j < size; j++)
                {
                    MainRound[i].Add(new TMatch(b[ctr], Players, LosePlayer));
                    ctr = ctr + 1;
                }
            }
            // LoseRound
            b = UHelpers.UHelpers.Explode(a[4], Units.Class.SEP_LIST);
            LoseRound = new List<List<TMatch>>();
            if (ShortLoseRound)
            {
                LoseRound.Add(new List<TMatch>(2));
                LoseRound[0].Add(new TMatch(b[0], Players, LosePlayer));
                LoseRound[0].Add(new TMatch(b[1], Players, LosePlayer));
                LoseRound.Add(new List<TMatch>(2));
                LoseRound[1].Add(new TMatch(b[2], Players, LosePlayer));
                LoseRound[1].Add(new TMatch(b[3], Players, LosePlayer));
            }
            else
            {
                ctr = 0;
                for (i = 0; i < LenLose; i++)
                {
                    int size = (int)Math.Floor(nGame / Math.Pow(2.0, Math.Ceiling((i + 3) / 2.0))); //TODO used to round up with comment screw this, verify
                    LoseRound.Add(new List<TMatch>(size));
                    for (j = 0; j < size; j++)
                    {
                        LoseRound[i].Add(new TMatch(b[ctr], Players, LosePlayer));
                        ctr = ctr + 1;
                    }
                }
            }
            // MainSteps
            b = UHelpers.UHelpers.Explode(a[5], Units.Class.SEP_LIST);
            MainSteps = new int[LenMain - 1];
            for (i = 0; i <= LenMain - 2; i++)
            {
                MainSteps[i] = Convert.ToInt32(b[i]);
            }
            // LoseSteps
            b = UHelpers.UHelpers.Explode(a[6], Units.Class.SEP_LIST);
            LoseSteps = new int[LenMain - 2];
            for (i = 0; i <= LenMain - 3; i++)
            {
                LoseSteps[i] = Convert.ToInt32(b[i]);
            }
        }
        public string ToString()
        {
            string result;
            int i;
            int j;
            result = "DE" + Units.Class.SEP_GAME;
            // Players + JumpSlots
            for (i = 0; i < Players.Length; i++)
            {
                if (i != 0)
                {
                    result = result + Units.Class.SEP_LIST;
                }
                result = result + Players[i].ToString();
            }
            result = result + Units.Class.SEP_GAME;
            // LevelMain,LevelLose,LevelSteps,LenMain,LenLose,CurrentMatch,HandlingMain,TimeStarted,ShortLoseRound
            result = result + (LevelMain).ToString() + Units.Class.SEP_LIST + (LevelLose).ToString() + Units.Class.SEP_LIST + (LevelSteps).ToString() + Units.Class.SEP_LIST + (LenMain).ToString() + Units.Class.SEP_LIST + (LenLose).ToString() + Units.Class.SEP_LIST + (CurrentMatch).ToString() + Units.Class.SEP_LIST + UHelpers.UHelpers.BoolToStr(HandlingMain) + Units.Class.SEP_LIST + (TimeStarted).ToString("o") + Units.Class.SEP_LIST + UHelpers.UHelpers.BoolToStr(ShortLoseRound) + Units.Class.SEP_GAME;
            // MainRound
            for (i = 0; i < LenMain; i++)
            {
                for (j = 0; j < MainRound[i].Count; j++)
                {
                    if ((i + j != 0))
                    {
                        result = result + Units.Class.SEP_LIST;
                    }
                    result = result + MainRound[i][j].ToString();
                }
            }
            result = result + Units.Class.SEP_GAME;
            // LoseRound
            for (i = 0; i < LenLose; i++)
            {
                for (j = 0; j < LoseRound[i].Count; j++)
                {
                    if ((i + j != 0))
                    {
                        result = result + Units.Class.SEP_LIST;
                    }
                    result = result + LoseRound[i][j].ToString();
                }
            }
            result = result + Units.Class.SEP_GAME;
            // MainSteps
            for (i = 0; i <= LenMain - 2; i++)
            {
                if (i != 0)
                {
                    result = result + Units.Class.SEP_LIST;
                }
                result = result + (MainSteps[i]).ToString();
            }
            result = result + Units.Class.SEP_GAME;
            // LoseSteps
            for (i = 0; i <= LenMain - 3; i++)
            {
                if (i != 0)
                {
                    result = result + Units.Class.SEP_LIST;
                }
                result = result + (LoseSteps[i]).ToString();
            }
            // not required: LosePlayer, Settings

            return result;
        }

        public void Autoforward()
        {
            int _LevelMain;
            int _LevelLose;
            int _LevelSteps;
            int _CurrentMatch;
            bool _HandlingMain;
            int[] _MainSteps;
            int[] _LoseSteps;
            TMatch tmpmatch;
            // back up CurrentStat
            _LevelMain = LevelMain;
            _LevelLose = LevelLose;
            _LevelSteps = LevelSteps;
            _CurrentMatch = CurrentMatch;
            _HandlingMain = HandlingMain;
            _MainSteps = new int[MainSteps.Length];
            UHelpers.UHelpers.CopyToArray(MainSteps, ref _MainSteps, 0);
            _LoseSteps = new int[LoseSteps.Length];
            UHelpers.UHelpers.CopyToArray(LoseSteps, ref _LoseSteps, 0);
            tmpmatch = GetNextMatch(true);
            while (tmpmatch != null)
            {
                if ((tmpmatch.PlayerA != null) && (tmpmatch.PlayerB != null))
                {
                    if ((tmpmatch.PlayerA == LosePlayer) && (tmpmatch.PlayerB == LosePlayer))
                    {
                        FinishCurrentMatch(-1, -1, -1, false);
                    }
                    else if (tmpmatch.PlayerA == LosePlayer)
                    {
                        FinishCurrentMatch(-1, 0, -1, false);
                    }
                    else if (tmpmatch.PlayerB == LosePlayer)
                    {
                        FinishCurrentMatch(0, -1, -1, false);
                    }
                }
                else if (tmpmatch.PlayerA != null)
                {
                    if (tmpmatch.PlayerA == LosePlayer)
                    {
                        FinishCurrentMatch(-1, 0, -1, false, false);
                    }
                }
                else if (tmpmatch.PlayerB != null)
                {
                    if (tmpmatch.PlayerB == LosePlayer)
                    {
                        FinishCurrentMatch(0, -1, -1, false, false);
                    }
                }
                tmpmatch = GetNextMatch(true);
            }
            // restore CurrentStat
            LevelMain = _LevelMain;
            LevelLose = _LevelLose;
            LevelSteps = _LevelSteps;
            CurrentMatch = _CurrentMatch;
            HandlingMain = _HandlingMain;
            UHelpers.UHelpers.CopyToArray(_MainSteps, ref MainSteps, 0);
            UHelpers.UHelpers.CopyToArray(_LoseSteps, ref LoseSteps, 0);
        }

        public TMatch GetNextMatch(bool includeAuto)
        {
            TMatch result;
            if (TimeStarted == DateTime.MinValue)
            {
                TimeStarted = DateTime.Now;
            }
            if (CurrentMatch == -1)
            {
                // Change Main/Lose only when previous finished
                if (LevelSteps == MainSteps.Length - 1)
                {
                    // game is over
                    result = null;
                    return result;
                }
                else if (MainSteps[LevelSteps] > 0)
                {
                    HandlingMain = true;
                    MainSteps[LevelSteps] = MainSteps[LevelSteps] - 1;
                }
                else if (LoseSteps[LevelSteps] > 0)
                {
                    HandlingMain = false;
                    LoseSteps[LevelSteps] = LoseSteps[LevelSteps] - 1;
                }
                else
                {
                    LevelSteps = LevelSteps + 1;
                    HandlingMain = true;
                    MainSteps[LevelSteps] = MainSteps[LevelSteps] - 1;
                }
            }
            if (HandlingMain)
            {
                // Handle current Main
                if (CurrentMatch == MainRound[LevelMain].Count - 1)
                {
                    // Set finished state and chose again
                    LevelMain = LevelMain + 1;
                    CurrentMatch = -1;
                    result = GetNextMatch(includeAuto);
                }
                else
                {
                    // Advance normally
                    CurrentMatch = CurrentMatch + 1;
                    result = MainRound[LevelMain][CurrentMatch];
                }
            }
            else
            {
                // or Lose
                if (CurrentMatch == LoseRound[LevelLose].Count - 1)
                {
                    // Set finished state and chose again
                    LevelLose = LevelLose + 1;
                    CurrentMatch = -1;
                    result = GetNextMatch(includeAuto);
                }
                else
                {
                    // Advance normally
                    CurrentMatch = CurrentMatch + 1;
                    result = LoseRound[LevelLose][CurrentMatch];
                }
            }
            // Autoforward has been done already, so games with just one player are skiped
            if ((result != null) && !includeAuto)
            {
                if (result.FightTime == -1)
                {
                    // skip
                    result = GetNextMatch(includeAuto);
                }
            }
            return result;
        }

        public TMatch GetNextMatch()
        {
            return GetNextMatch(false);
        }

        public TMatch GetPreparingMatch(bool bIncludeAuto)
        {
            TMatch result;
            int _LevelMain;
            int _LevelLose;
            int _LevelSteps;
            int _CurrentMatch;
            bool _HandlingMain;
            int[] _MainSteps;
            int[] _LoseSteps;
            // basically the same idea as autoforward, we just dont finish any game
            // back up CurrentStat
            _LevelMain = LevelMain;
            _LevelLose = LevelLose;
            _LevelSteps = LevelSteps;
            _CurrentMatch = CurrentMatch;
            _HandlingMain = HandlingMain;
            _MainSteps = new int[MainSteps.Length];
            UHelpers.UHelpers.CopyToArray(MainSteps, ref _MainSteps, 0);
            _LoseSteps = new int[LoseSteps.Length];
            UHelpers.UHelpers.CopyToArray(LoseSteps, ref _LoseSteps, 0);
            result = GetNextMatch(false);
            // restore CurrentStat
            LevelMain = _LevelMain;
            LevelLose = _LevelLose;
            LevelSteps = _LevelSteps;
            CurrentMatch = _CurrentMatch;
            HandlingMain = _HandlingMain;
            UHelpers.UHelpers.CopyToArray(_MainSteps, ref MainSteps, 0);
            UHelpers.UHelpers.CopyToArray(_LoseSteps, ref LoseSteps, 0);
            return result;
        }

        public TMatch GetPreparingMatch()
        {
            return GetPreparingMatch(false);
        }

        public void FinishCurrentMatch(int PlayerAPoints, int PlayerBPoints, int FightTime, bool includeAuto, bool forwardPlayers)
        {
            int pos;
            TPlayer Winner;
            TPlayer Loser;
            if (HandlingMain)
            {
                // Save data
                MainRound[LevelMain][CurrentMatch].PlayerAPoints = PlayerAPoints;
                MainRound[LevelMain][CurrentMatch].PlayerBPoints = PlayerBPoints;
                if (FightTime == 0)
                {
                    FightTime = 1;
                }
                MainRound[LevelMain][CurrentMatch].FightTime = FightTime;
                if (forwardPlayers)
                {
                    // Determine winner
                    if (PlayerAPoints > PlayerBPoints)
                    {
                        Winner = MainRound[LevelMain][CurrentMatch].PlayerA;
                        Loser = MainRound[LevelMain][CurrentMatch].PlayerB;
                    }
                    else
                    {
                        Winner = MainRound[LevelMain][CurrentMatch].PlayerB;
                        Loser = MainRound[LevelMain][CurrentMatch].PlayerA;
                    }
                    if (LevelMain < LenMain - 1)
                    {
                        // Only when next round exists
                        // Place winner in next round
                        if (CurrentMatch % 2 == 0)
                        {
                            MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA = Winner;
                        }
                        else
                        {
                            MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB = Winner;
                        }
                        // Autoforward
                        if (includeAuto)
                        {
                            if ((MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA != null) && (MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB != null))
                            {
                                if ((MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA == LosePlayer) || (MainRound[LevelMain + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB == LosePlayer))
                                {
                                    Autoforward();
                                }
                            }
                        }
                        // Place loser in next round
                        pos = -1;
                        // Compiler
                        if (!ShortLoseRound)
                        {
                            if (LevelMain == 0)
                            {
                                pos = JumpSlots[LevelMain][CurrentMatch];
                                if (pos % 2 == 0)
                                {
                                    LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA = Loser;
                                }
                                else
                                {
                                    LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB = Loser;
                                }
                            }
                            else
                            {
                                LoseRound[LevelMain * 2 - 1][JumpSlots[LevelMain][CurrentMatch]].PlayerB = Loser;
                            }
                        }
                        else
                        {
                            if (LevelMain == LenMain - 3)
                            {
                                pos = JumpSlots[0][CurrentMatch];
                                if (pos % 2 == 0)
                                {
                                    LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA = Loser;
                                }
                                else
                                {
                                    LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB = Loser;
                                }
                            }
                            else if (LevelMain == LenMain - 2)
                            {
                                LoseRound[1][JumpSlots[1][CurrentMatch]].PlayerB = Loser;
                            }
                        }
                        // Autoforward
                        if (includeAuto)
                        {
                            if (!ShortLoseRound)
                            {
                                if (LevelMain == 0)
                                {
                                    if ((LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA != null) && (LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB != null))
                                    {
                                        if ((LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA == LosePlayer) || (LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB == LosePlayer))
                                        {
                                            Autoforward();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((LoseRound[LevelMain * 2 - 1][JumpSlots[LevelMain][CurrentMatch]].PlayerA != null) && (LoseRound[LevelMain * 2 - 1][JumpSlots[LevelMain][CurrentMatch]].PlayerB != null))
                                    {
                                        if ((LoseRound[LevelMain * 2 - 1][JumpSlots[LevelMain][CurrentMatch]].PlayerA == LosePlayer) || (LoseRound[LevelMain * 2 - 1][JumpSlots[LevelMain][CurrentMatch]].PlayerB == LosePlayer))
                                        {
                                            Autoforward();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (LevelMain == LenMain - 3)
                                {
                                    if ((LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA != null) && (LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB != null))
                                    {
                                        if ((LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerA == LosePlayer) || (LoseRound[0][(int)Math.Floor(pos / 2.0)].PlayerB == LosePlayer))
                                        {
                                            Autoforward();
                                        }
                                    }
                                }
                                else if (LevelMain == LenMain - 2)
                                {
                                    if ((LoseRound[1][JumpSlots[1][CurrentMatch]].PlayerA != null) && (LoseRound[1][JumpSlots[1][CurrentMatch]].PlayerB != null))
                                    {
                                        if ((LoseRound[1][JumpSlots[1][CurrentMatch]].PlayerA == LosePlayer) || (LoseRound[1][JumpSlots[1][CurrentMatch]].PlayerB == LosePlayer))
                                        {
                                            Autoforward();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // Save data
                LoseRound[LevelLose][CurrentMatch].PlayerAPoints = PlayerAPoints;
                LoseRound[LevelLose][CurrentMatch].PlayerBPoints = PlayerBPoints;
                if (FightTime == 0)
                {
                    FightTime = 1;
                }
                LoseRound[LevelLose][CurrentMatch].FightTime = FightTime;
                if (forwardPlayers)
                {
                    // Determine winner
                    if (PlayerAPoints > PlayerBPoints)
                    {
                        Winner = LoseRound[LevelLose][CurrentMatch].PlayerA;
                    }
                    else
                    {
                        Winner = LoseRound[LevelLose][CurrentMatch].PlayerB;
                    }
                    if (LevelLose < LenLose - 1)
                    {
                        // Only when next round exists
                        // Place winner in next round
                        if ((LevelLose + 1) % 2 == 0)
                        {
                            if (CurrentMatch % 2 == 0)
                            {
                                LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA = Winner;
                            }
                            else
                            {
                                LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB = Winner;
                            }
                        }
                        else
                        {
                            // next round is jumpin round
                            //@ Unsupported property or method(D): 'PlayerA'
                            LoseRound[LevelLose + 1][CurrentMatch].PlayerA = Winner;
                        }
                        // Autoforward
                        if (includeAuto)
                        {
                            if ((LevelLose + 1) % 2 == 0)
                            {
                                if ((LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA != null) && (LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB != null))
                                {
                                    if ((LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerA == LosePlayer) || (LoseRound[LevelLose + 1][(int)Math.Floor(CurrentMatch / 2.0)].PlayerB == LosePlayer))
                                    {
                                        Autoforward();
                                    }
                                }
                            }
                            else
                            {
                                if ((LoseRound[LevelLose + 1][CurrentMatch].PlayerA != null) && (LoseRound[LevelLose + 1][CurrentMatch].PlayerB != null))
                                {
                                    if ((LoseRound[LevelLose + 1][CurrentMatch].PlayerA == LosePlayer) || (LoseRound[LevelLose + 1][CurrentMatch].PlayerB == LosePlayer))
                                    {
                                        Autoforward();
                                    }
                                }
                            }
                        }
                        // Ignore Loser
                    }
                }
            }
        }

        public void FinishCurrentMatch(int PlayerAPoints, int PlayerBPoints, int FightTime)
        {
            FinishCurrentMatch(PlayerAPoints, PlayerBPoints, FightTime, true);
        }

        public void FinishCurrentMatch(int PlayerAPoints, int PlayerBPoints, int FightTime, bool includeAuto)
        {
            FinishCurrentMatch(PlayerAPoints, PlayerBPoints, FightTime, includeAuto, true);
        }

        public List<KeyValuePair<int, TPlayer>> ResultList()
        {
            List<KeyValuePair<int, TPlayer>> result = new List<KeyValuePair<int, TPlayer>>(8);
            result.Add(new KeyValuePair<int, TPlayer>(1, MainRound[LenMain - 1][0].Winner()));
            result.Add(new KeyValuePair<int, TPlayer>(2, MainRound[LenMain - 1][0].Loser()));
            result.Add(new KeyValuePair<int, TPlayer>(3, MainRound[LenLose - 1][0].Winner()));
            result.Add(new KeyValuePair<int, TPlayer>(3, MainRound[LenLose - 1][1].Winner()));
            result.Add(new KeyValuePair<int, TPlayer>(5, MainRound[LenLose - 1][0].Loser()));
            result.Add(new KeyValuePair<int, TPlayer>(5, MainRound[LenLose - 1][1].Loser()));
            result.Add(new KeyValuePair<int, TPlayer>(7, MainRound[LenLose - 2][0].Loser()));
            result.Add(new KeyValuePair<int, TPlayer>(7, MainRound[LenLose - 2][1].Loser()));
            return result;
        }

        public Bitmap ResultBitmap()
        {
            Bitmap result;
            List<KeyValuePair<int, TPlayer>> list;
            int i;
            list = ResultList();
            result = new Bitmap(300, 20 * list.Count + 40);
            Graphics graphics = Graphics.FromImage(result);
            Font bigFont = new Font("Arial", 20);
            Font font = new Font("Arial", 11);
            UHelpers.UHelpers.CanvasStr(graphics, 20, 5, "Ergebnisse", -1, bigFont, System.Drawing.ContentAlignment.TopLeft);
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Value != null)
                {
                    UHelpers.UHelpers.CanvasStr(graphics, 20, 40 + i * 20, (list[i].Key).ToString() + ". " + UHelpers.UHelpers.PlayerToStr(list[i].Value), -1, font, System.Drawing.ContentAlignment.TopLeft);
                }
                else
                {
                    UHelpers.UHelpers.CanvasStr(graphics, 20, 25 + i * 20, (list[i].Key).ToString() + ". ?", -1, font, System.Drawing.ContentAlignment.TopLeft);
                }
            }
            // CanvasLine(Result,0,0,Result.Width,Result.Height,clRed);
            // CanvasLine(Result,0,Result.Height,Result.Width,0,clRed);

            return result;
        }

        public string DebugString()
        {
            /*
            string result;
            int i;
            int j;
            int k;
            int sp;
            int hs;
            string s;
            string[] m;
            string[] l;
            bool splast;
            s = "";
            sp = 1;
            // see down
            m = new string[(MainRound.Count + 1) * 2];
            for (i = 0; i < m.Length; i ++ )
            {
                //@ Unsupported function or procedure: 'SetLength'
                m[i].Length = MainRound[0].Length * 4 - 1;
            }
            for (i = 0; i < Math.Round(m.Length / 2); i ++ )
            {
                for (j = 0; j < m[i].Length; j ++ )
                {
                    m[i * 2, j] = UHelpers.UHelpers.TableStr("");
                    m[i * 2 + 1, j] = UHelpers.UHelpers.TableStr("", 3);
                }
            }
            // first one is special
            for (j = 0; j < m[0].Length; j ++ )
            {
                m[0, j] = UHelpers.UHelpers.TableStr("", 30);
            }
            // Genius maths creating an array of Strings we can print easily
            for (i = 1; i < MainRound.Length; i ++ )
            {
                // we dont start a 0 because 0 will be done later
                // therefore sp does not start at 0 but at 1
                for (j = 0; j < MainRound[i].Length; j ++ )
                {
                    m[i * 2, j * (4 * sp + 4) + sp] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerA, false, false));
                    if ((MainRound[i][j].PlayerAPoints != 0) || (MainRound[i][j].PlayerBPoints != 0))
                    {
                        if (MainRound[i][j].FightTime !=  -1)
                        {
                            m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr((MainRound[i][j].PlayerAPoints).ToString() + '|' + (MainRound[i][j].PlayerBPoints).ToString() + '|' + UHelpers.UHelpers.TimeToStr(MainRound[i][j].FightTime));
                        }
                        else
                        {
                            m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("-|-|-:--");
                        }
                    }
                    else
                    {
                        m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("?|?|?");
                    }
                    m[i * 2 + 1, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("---", 3);
                    m[i * 2, j * (4 * sp + 4) + 3 * sp + 2] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerB, false, false));
                }
                sp = sp * 2 + 1;
            }
            // We want to see the winner of the final (which is no TMatch)
            i = MainRound.Length - 1;
            j = 0;
            sp = Math.Round((sp - 1) / 2);
            m[i * 2 + 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(MainRound[i][j].Winner(), false, false));
            // Special: first one complete name
            sp = 0;
            i = 0;
            for (j = 0; j < MainRound[0].Length; j ++ )
            {
                m[i * 2, j * (4 * sp + 4) + sp] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerA), 30, 1);
                if ((MainRound[i][j].PlayerAPoints != 0) || (MainRound[i][j].PlayerBPoints != 0))
                {
                    if (MainRound[i][j].FightTime !=  -1)
                    {
                        m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr((MainRound[i][j].PlayerAPoints).ToString() + '|' + (MainRound[i][j].PlayerBPoints).ToString() + '|' + UHelpers.UHelpers.TimeToStr(MainRound[i][j].FightTime), 30);
                    }
                    else
                    {
                        m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("-|-|-:--", 30);
                    }
                }
                else
                {
                    m[i * 2, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("?|?|?", 30);
                }
                m[i * 2 + 1, j * (4 * sp + 4) + 2 * sp + 1] = UHelpers.UHelpers.TableStr("---", 3);
                m[i * 2, j * (4 * sp + 4) + 3 * sp + 2] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerB), 30, 1);
            }
            // --------------------------------
            sp = 0;
            hs = 0;
            splast = true;
            l = new string[(LoseRound.Length + 1) * 2];
            for (i = 0; i < l.Length; i ++ )
            {
                //@ Unsupported function or procedure: 'SetLength'
                l[i].Length = LoseRound[0].Length * 4 - 1 + LoseRound.Length;
            }
            //@ Undeclared identifier(3): 'rmDown'
            //@ Undeclared identifier(3): 'SetRoundMode'
            SetRoundMode(rmDown);
            for (i = 0; i < Math.Round(l.Length / 2); i ++ )
            {
                for (j = 0; j < l[i].Length; j ++ )
                {
                    l[i * 2, j] = UHelpers.UHelpers.TableStr("");
                    l[i * 2 + 1, j] = UHelpers.UHelpers.TableStr("", 3);
                }
            }
            //@ Undeclared identifier(3): 'rmNearest'
            //@ Undeclared identifier(3): 'SetRoundMode'
            SetRoundMode(rmNearest);
            // Genius maths creating an array of Strings we can print easily
            // in the loseround, sp will be increased only every second time
            for (i = 0; i < LoseRound.Length; i ++ )
            {
                for (j = 0; j < LoseRound[i].Length; j ++ )
                {
                    l[i * 2, j * (4 * sp + 4) + sp + hs] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].PlayerA, false, false));
                    if ((LoseRound[i][j].PlayerAPoints != 0) || (LoseRound[i][j].PlayerBPoints != 0))
                    {
                        if (LoseRound[i][j].FightTime !=  -1)
                        {
                            l[i * 2, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr((LoseRound[i][j].PlayerAPoints).ToString() + '|' + (LoseRound[i][j].PlayerBPoints).ToString() + '|' + UHelpers.UHelpers.TimeToStr(LoseRound[i][j].FightTime));
                        }
                        else
                        {
                            l[i * 2, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr("-|-|-:--");
                        }
                    }
                    else
                    {
                        l[i * 2, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr("?|?|?");
                    }
                    l[i * 2 + 1, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr("---", 3);
                    l[i * 2, j * (4 * sp + 4) + 3 * sp + 2 + hs] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].PlayerB, false, false));
                }
                if (!splast)
                {
                    sp = sp * 2 + 1;
                    splast = true;
                }
                else
                {
                    splast = false;
                    hs = hs * 2 + 1;
                }
            }
            // We want to see the winner of the finals (which is no TMatch)
            i = LoseRound.Length - 1;
            j = 0;
            sp = Math.Round((sp - 1) / 2);
            l[i * 2 + 2, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].Winner(), false, false));
            j = 1;
            l[i * 2 + 2, j * (4 * sp + 4) + 2 * sp + 1 + hs] = UHelpers.UHelpers.TableStr(UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].Winner(), false, false));
            for (j = 0; j < m[0].Length; j ++ )
            {
                for (i = 0; i < m.Length; i ++ )
                {
                    if (m[i][j] != "")
                    {
                        s = s + m[i][j];
                    }
                    else
                    {
                        s = s + UHelpers.UHelpers.TableStr("<wtf>");
                    }
                }
                //@ Undeclared identifier(3): 'rmDown'
                //@ Undeclared identifier(3): 'SetRoundMode'
                SetRoundMode(rmDown);
                k = j - Math.Round((m[0].Length - l[0].Length) / 2);
                //@ Undeclared identifier(3): 'rmNearest'
                //@ Undeclared identifier(3): 'SetRoundMode'
                SetRoundMode(rmNearest);
                if ((k >= 0) && (k < l[0].Length))
                {
                    for (i = 0; i < l.Length; i ++ )
                    {
                        if (l[i, k] != "")
                        {
                            s = s + l[i, k];
                        }
                        else
                        {
                            s = s + UHelpers.UHelpers.TableStr("<wtf>");
                        }
                    }
                }
                s = s + (char)(13);
            }
            // CurrentStat stuff
            s = s + (char)(13);
            s = s + "M ";
            for (i = 0; i < MainSteps.Length; i ++ )
            {
                s = s + (MainSteps[i]).ToString() + ' ';
            }
            s = s + (char)(13);
            s = s + "L ";
            for (i = 0; i < LoseSteps.Length; i ++ )
            {
                s = s + (LoseSteps[i]).ToString() + ' ';
            }
            s = s + "x ";
            s = s + (char)(13);
            s = s + "  ";
            for (i = 0; i < MainSteps.Length; i ++ )
            {
                if (LevelSteps == i)
                {
                    s = s + "^ ";
                }
                else
                {
                    s = s + "  ";
                }
            }
            s = s + (char)(13);
            s = s + "Main: " + (LevelMain + 1).ToString() + '/' + (LenMain).ToString() + " Lose: " + (LevelLose + 1).ToString() + '/' + (LenLose).ToString() + " Current: " + (CurrentMatch + 1).ToString() + '/' + UHelpers.UHelpers.BoolToStr(HandlingMain);
            result = s;
            return result;
             */
            return "TODO";
        }

        public Bitmap WinBitmap(int FontSize)
        {
            Bitmap result;
            int sp;
            int hs;
            int i;
            int j;
            int chh;
            int chw;
            int lh;
            int hlh;
            int fcw;
            int cw;
            int scw;
            int width;
            int height;
            int lx;
            int ly;
            bool splast;
            result = new Bitmap(300, 300);
            Graphics graphics = Graphics.FromImage(result);
            Font font = new Font("Arial", FontSize);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            Pen pen = new Pen(Color.Black);
            // height of one captial Char in current Font
            chh = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Height);
            lh = chh + 1;
            // line height
            hlh = (int)Math.Round(lh / 2.0);
            // half line height
            // col widths
            chw = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Width / Units.Class.STDSTR.Length);
            fcw = 25 * chw;
            // fist col: full name
            cw = 10 * chw;
            // standard col
            scw = 14 * chw;
            // separator col
            width = fcw + MainRound.Count * (cw + scw) + cw;
            height = lh * (MainRound[0].Count * 4 - 1);
            result = new Bitmap(width, height);
            graphics = Graphics.FromImage(result);
            // Result.Canvas.Pen.Color := clGray;
            // Result.Canvas.Rectangle(0,0,width,height);
            // Special: first one complete name
            sp = 0;
            i = 0;
            for (j = 0; j < MainRound[0].Count; j++)
            {
                UHelpers.UHelpers.CanvasStr(graphics, 2, (j * (4 * sp + 4) + sp) * lh, UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerA), fcw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                if ((MainRound[i][j].PlayerAPoints != 0) || (MainRound[i][j].PlayerBPoints != 0))
                {
                    if (MainRound[i][j].FightTime != -1)
                    {
                        UHelpers.UHelpers.CanvasStr(graphics, fcw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, (MainRound[i][j].PlayerAPoints).ToString() + ":" + (MainRound[i][j].PlayerBPoints).ToString() + " | " + UHelpers.UHelpers.TimeToStr(MainRound[i][j].FightTime), scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                    }
                    else
                    {
                        UHelpers.UHelpers.CanvasStr(graphics, fcw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, "-:- | -:--", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                    }
                }
                else
                {
                    UHelpers.UHelpers.CanvasStr(graphics, fcw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, "?:? | ?", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                }
                UHelpers.UHelpers.CanvasStr(graphics, 2, (j * (4 * sp + 4) + 3 * sp + 2) * lh, UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerB), fcw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                UHelpers.UHelpers.CanvasLine(graphics, fcw + 1, (j * (4 * sp + 4) + sp) * lh + hlh, fcw + 5, (j * (4 * sp + 4) + sp) * lh + hlh, System.Drawing.Color.Gray);            // -|
                UHelpers.UHelpers.CanvasLine(graphics, fcw + 5, (j * (4 * sp + 4) + sp) * lh + hlh, fcw + 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);                 //  |
                UHelpers.UHelpers.CanvasLine(graphics, fcw + 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, fcw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);            //  | -
                UHelpers.UHelpers.CanvasLine(graphics, fcw + scw - 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, fcw + scw, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);       //  | -
                UHelpers.UHelpers.CanvasLine(graphics, fcw + 5, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, fcw + 5, (j * (4 * sp + 4) + 3 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);             //  |
                UHelpers.UHelpers.CanvasLine(graphics, fcw + 1, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, fcw + 5, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, System.Drawing.Color.Gray);             // -|
            }
            // Main
            sp = 1;
            for (i = 1; i < MainRound.Count; i++)
            {
                for (j = 0; j < MainRound[i].Count; j++)
                {
                    UHelpers.UHelpers.CanvasStr(graphics, fcw + i * scw + (i - 1) * cw + 2, (j * (4 * sp + 4) + sp) * lh, UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerA, false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                    if ((MainRound[i][j].PlayerAPoints != 0) || (MainRound[i][j].PlayerBPoints != 0))
                    {
                        if (MainRound[i][j].FightTime != -1)
                        {
                            UHelpers.UHelpers.CanvasStr(graphics, fcw + i * scw + i * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, (MainRound[i][j].PlayerAPoints).ToString() + ":" + (MainRound[i][j].PlayerBPoints).ToString() + " | " + UHelpers.UHelpers.TimeToStr(MainRound[i][j].FightTime), scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                        }
                        else
                        {
                            UHelpers.UHelpers.CanvasStr(graphics, fcw + i * scw + i * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, "-:- | -:--", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                        }
                    }
                    else
                    {
                        UHelpers.UHelpers.CanvasStr(graphics, fcw + i * scw + i * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, "?:? | ?", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                    }
                    UHelpers.UHelpers.CanvasStr(graphics, fcw + i * scw + (i - 1) * cw + 2, (j * (4 * sp + 4) + 3 * sp + 2) * lh, UHelpers.UHelpers.PlayerToStr(MainRound[i][j].PlayerB, false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + 1, (j * (4 * sp + 4) + sp) * lh + hlh, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + sp) * lh + hlh, System.Drawing.Color.Gray);                            // -|
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + sp) * lh + hlh, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);                    //  |
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, fcw + i * scw + i * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);           //  | -
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + scw - 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, fcw + i * scw + i * cw + scw, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);    //  | -
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + 2 * sp + 1) * lh + hlh, System.Drawing.Color.Gray);            //  |
                    UHelpers.UHelpers.CanvasLine(graphics, fcw + i * scw + i * cw + 1, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, fcw + i * scw + i * cw + 5, (j * (4 * sp + 4) + 3 * sp + 2) * lh + hlh, System.Drawing.Color.Gray);            // -|
                }
                sp = sp * 2 + 1;
            }
            // We want to see the winner of the final (which is no TMatch)
            i = MainRound.Count - 1;
            j = 0;
            sp = (int)Math.Round((sp - 1) / 2.0);
            UHelpers.UHelpers.CanvasStr(graphics, fcw + (i + 1) * scw + i * cw + 2, (j * (4 * sp + 4) + 2 * sp + 1) * lh, UHelpers.UHelpers.PlayerToStr(MainRound[i][j].Winner(), false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
            return result;
        }

        public Bitmap WinBitmap()
        {
            return WinBitmap(8);
        }

        public Bitmap LoseBitmap(int FontSize)
        {
            Bitmap result;
            int sp;
            int hs;
            int i;
            int j;
            int chh;
            int chw;
            int lh;
            int hlh;
            int cw;
            int scw;
            int width;
            int height;
            bool splast;
            result = new Bitmap(300, 300);
            Graphics graphics = Graphics.FromImage(result);
            Font font = new Font("Arial", FontSize);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            Pen pen = new Pen(Color.Black);
            // height of one captial Char in current Font
            chh = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Height);
            lh = chh + 1;
            // line height
            hlh = (int)Math.Round(lh / 2.0);
            // half line height
            // col widths
            chw = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Width / Units.Class.STDSTR.Length);
            cw = 10 * chw;
            // standard col
            scw = 14 * chw;
            // separator col
            width = LoseRound.Count * (cw + scw) + cw;
            height = lh * (LoseRound[0].Count * 4 - 1 + (int)Math.Round(Math.Pow(2.0, Math.Round(LoseRound.Count / 2.0) - 1)));
            result = new Bitmap(width, height);
            graphics = Graphics.FromImage(result);
            // Result.Canvas.Pen.Color := clGray;
            // Result.Canvas.Rectangle(0,0,width,height);
            sp = 0;
            hs = 0;
            splast = true;
            // Lose
            for (i = 0; i < LoseRound.Count; i++)
            {
                for (j = 0; j < LoseRound[i].Count; j++)
                {
                    UHelpers.UHelpers.CanvasStr(graphics, i * scw + i * cw + 2, (j * (4 * sp + 4) + sp + hs) * lh, UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].PlayerA, false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                    if ((LoseRound[i][j].PlayerAPoints != 0) || (LoseRound[i][j].PlayerBPoints != 0))
                    {
                        if (LoseRound[i][j].FightTime != -1)
                        {
                            UHelpers.UHelpers.CanvasStr(graphics, i * scw + (i + 1) * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1 + hs) * lh + hlh, (LoseRound[i][j].PlayerAPoints).ToString() + ":" + (LoseRound[i][j].PlayerBPoints).ToString() + " | " + UHelpers.UHelpers.TimeToStr(LoseRound[i][j].FightTime), scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                        }
                        else
                        {
                            UHelpers.UHelpers.CanvasStr(graphics, i * scw + (i + 1) * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1 + hs) * lh + hlh, "-:- | -:--", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                        }
                    }
                    else
                    {
                        UHelpers.UHelpers.CanvasStr(graphics, i * scw + (i + 1) * cw + 10, (j * (4 * sp + 4) + 2 * sp + 1 + hs) * lh + hlh, "?:? | ?", scw - 15, font, System.Drawing.ContentAlignment.TopCenter, grayBrush, true);
                    }
                    UHelpers.UHelpers.CanvasStr(graphics, i * scw + i * cw + 2, (j * (4 * sp + 4) + 3 * sp + 2 + hs) * lh, UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].PlayerB, false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + 1, (j * (4 * sp + 4) + sp + hs) * lh + hlh, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + sp + hs) * lh + hlh, System.Drawing.Color.Gray);// -|
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + sp + hs) * lh + hlh, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, System.Drawing.Color.Gray);                 //  |
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, i * scw + (i + 1) * cw + 10, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, System.Drawing.Color.Gray);            //  | -
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + scw - 5, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, i * scw + (i + 1) * cw + scw, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, System.Drawing.Color.Gray);       //  | -
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + 3 * sp + 2 + hs) * lh + hlh, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + 2 * sp + hs + 1) * lh + hlh, System.Drawing.Color.Gray);             //  |
                    UHelpers.UHelpers.CanvasLine(graphics, i * scw + (i + 1) * cw + 1, (j * (4 * sp + 4) + 3 * sp + 2 + hs) * lh + hlh, i * scw + (i + 1) * cw + 5, (j * (4 * sp + 4) + 3 * sp + hs + 2) * lh + hlh, System.Drawing.Color.Gray);             // -|
                }
                if (!splast)
                {
                    sp = sp * 2 + 1;
                    splast = true;
                }
                else
                {
                    splast = false;
                    hs = hs * 2 + 1;
                }
            }
            // We want to see the winner of the finals (which is no TMatch)
            i = LoseRound.Count - 1;
            j = 0;
            sp = (int)Math.Round((sp - 1) / 2.0);
            UHelpers.UHelpers.CanvasStr(graphics, (i + 1) * scw + (i + 1) * cw + 2, (j * (4 * sp + 4) + 2 * sp + 1 + hs) * lh, UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].Winner(), false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
            j = 1;
            UHelpers.UHelpers.CanvasStr(graphics, (i + 1) * scw + (i + 1) * cw + 2, (j * (4 * sp + 4) + 2 * sp + 1 + hs) * lh, UHelpers.UHelpers.PlayerToStr(LoseRound[i][j].Winner(), false, false), cw - 4, font, System.Drawing.ContentAlignment.TopLeft);
            return result;
        }

        public Bitmap LoseBitmap()
        {
            return LoseBitmap(8);
        }

        public Bitmap ToBitmap(int FontSize)
        {
            Bitmap result;
            int chh;
            int chw;
            int lh;
            int fcw;
            int cw;
            int scw;
            int ms;
            int wmain;
            int wlose;
            int hmain;
            int hlose;
            int width;
            int height;
            int ox;
            int oy;
            int lx;
            int ly;
            int cx;
            int cy;
            Bitmap WinBitmap;
            Bitmap LoseBitmap;
            result = new Bitmap(300, 300);
            Graphics graphics = Graphics.FromImage(result);
            Font font = new Font("Arial", FontSize);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            Pen pen = new Pen(Color.Black);
            // master offset for nice printing / display
            ox = 10;
            oy = 10;
            // height of one captial Char in current Font
            chh = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Height);
            lh = chh + 1;
            // line height
            // col widths
            chw = (int)Math.Ceiling(graphics.MeasureString(Units.Class.STDSTR, font).Width / Units.Class.STDSTR.Length);
            fcw = 25 * chw;
            // fist col: full name
            cw = 10 * chw;
            // standard col
            scw = 14 * chw;
            // separator col
            // separator
            ms = 5 * chw;
            // master separator col/height (main/loseround)
            wmain = fcw + MainRound.Count * (cw + scw) + cw;
            wlose = LoseRound.Count * (cw + scw) + cw;
            hmain = lh * (MainRound[0].Count * 4 - 1);
            hlose = lh * (LoseRound[0].Count * 4 - 1 + (int)Math.Round(Math.Pow(2.0, Math.Round(LoseRound.Count / 2.0) - 1)));
            if (MainRound[0].Count <= 16)
            {
                // Length(MainRound[0]) is Number of TMatches!
                // composed
                // offsets (negative into main)
                cx = (int)Math.Round(wmain / 3.0);
                cy = (int)Math.Round(hmain / 8.0);
                width = wmain - cx + wlose;
                height = hmain - cy + hlose;
                lx = wmain - cx;
                ly = hmain - cy;
            }
            else
            {
                // horiz
                width = wmain + ms + wlose;
                height = hmain + 1;
                // always bigger
                lx = wmain + ms;
                // where loseround part starts
                ly = (int)Math.Round((height - hlose) / 2.0);
                // vertic
                // width := ifthen(wmain>wlose,wmain,wlose);
                // height := hmain+ms+hlose+1;
                // lx := 0; // where loseround part starts
                // ly := hmain+ms;
            }
            result = new Bitmap(2 * ox + width, 2 * oy + height);
            graphics = Graphics.FromImage(result);
            // Result.Canvas.Pen.Color := clGray;
            // Result.Canvas.Rectangle(0,0,width,height);
            WinBitmap = this.WinBitmap(FontSize);
            graphics.DrawImage(WinBitmap, new Rectangle(ox, oy, wmain, hmain), new Rectangle(0, 0, wmain, hmain), GraphicsUnit.Pixel);
            WinBitmap.Save("win.bmp");
            LoseBitmap = this.LoseBitmap(FontSize);
            LoseBitmap.Save("lose.bmp");
            graphics.DrawImage(LoseBitmap, new Rectangle(ox + lx, oy + ly, wlose, hlose), new Rectangle(0, 0, wlose, hlose), GraphicsUnit.Pixel);
            result.Save("de.bmp");
            return result;
        }

        public Bitmap ToBitmap()
        {
            return ToBitmap(8);
        }

        public Bitmap ToBitmapResult(Bitmap Logo, int FontSize)
        {
            Bitmap result;
            Bitmap GameBitmap;
            Bitmap ListBitmap;
            int lx;
            int ly;
            GameBitmap = this.ToBitmap(FontSize);
            ListBitmap = this.ResultBitmap();
            // Offset for ResultList
            if (GameBitmap.Height < 600)
            {
                // Put ResultList on the Right
                lx = GameBitmap.Width + 20;
                if (Logo != null)
                {
                    ly = 200;
                }
                else
                {
                    ly = 20;
                }
                result = new Bitmap(GameBitmap.Width + 20 + ListBitmap.Width, GameBitmap.Height);
            }
            else
            {
                if (Logo != null)
                {
                    lx = GameBitmap.Width - 500;
                }
                else
                {
                    lx = GameBitmap.Width - 300;
                }
                ly = 20;
                result = new Bitmap(GameBitmap.Width + 20 + ListBitmap.Width, GameBitmap.Height);
            }
            Graphics graphics = Graphics.FromImage(result);
            graphics.DrawImage(GameBitmap, new Rectangle(0, 0, GameBitmap.Width, GameBitmap.Height), new Rectangle(0, 0, GameBitmap.Width, GameBitmap.Height), GraphicsUnit.Pixel);
            graphics.DrawImage(ListBitmap, new Rectangle(lx, ly, ListBitmap.Width, ListBitmap.Height), new Rectangle(0, 0, ListBitmap.Width, ListBitmap.Height), GraphicsUnit.Pixel);
            if (Logo != null)
            {
                graphics.DrawImage(Logo, new Rectangle(result.Width - 200, 0, 200, 200), new Rectangle(0, 0, Logo.Width, Logo.Height), GraphicsUnit.Pixel);
            }
            return result;
        }

        public Bitmap ToBitmapResult()
        {
            return ToBitmapResult(null);
        }

        public Bitmap ToBitmapResult(Bitmap Logo)
        {
            return ToBitmapResult(Logo, 8);
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
            for (i = 0; i < MainRound.Count; i++)
            {
                for (j = 0; j < MainRound[i].Count; j++)
                {
                    //@ Unsupported property or method(D): 'FightTime'
                    if (MainRound[i][j].FightTime != -1)
                    {
                        //@ Unsupported property or method(D): 'FightTime'
                        if (MainRound[i][j].FightTime != 0)
                        {
                            result.FightsDone = result.FightsDone + 1;
                            //@ Unsupported property or method(D): 'FightTime'
                            result.FightTimeDone = result.FightTimeDone + MainRound[i][j].FightTime;
                        }
                        result.FightsTotal = result.FightsTotal + 1;
                    }
                }
            }
            for (i = 0; i < LoseRound.Count; i++)
            {
                for (j = 0; j < LoseRound[i].Count; j++)
                {
                    //@ Unsupported property or method(D): 'FightTime'
                    if (LoseRound[i][j].FightTime != -1)
                    {
                        //@ Unsupported property or method(D): 'FightTime'
                        if (LoseRound[i][j].FightTime != 0)
                        {
                            result.FightsDone = result.FightsDone + 1;
                            //@ Unsupported property or method(D): 'FightTime'
                            result.FightTimeDone = result.FightTimeDone + LoseRound[i][j].FightTime;
                        }
                        result.FightsTotal = result.FightsTotal + 1;
                    }
                }
            }
            //@ Unsupported function or procedure: 'SecondsBetween'
            result.TimeDone = (int)(DateTime.Now - TimeStarted).TotalSeconds;
            if (result.FightsDone != 0)
            {
                result.TimeTotalAssumed = (int)Math.Round((double)result.TimeDone / result.FightsDone * result.FightsTotal);
                result.FightTimeTotalAssumed = (int)Math.Round((double)result.FightTimeDone / result.FightsDone * result.FightsTotal);
            }
            return result;
        }

    } // end TGameDE

}

