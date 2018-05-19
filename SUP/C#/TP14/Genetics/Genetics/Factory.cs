using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;


namespace Genetics
{
    public static class Factory
    {
        #region Attributes

        private static List<Player> _listPlayer;
        private static string _pathLoad;
        private static string _pathSave;

        #endregion

        #region Getters

        public static List<Player> GetListPlayer()
        {
            return _listPlayer;
        }

        public static void SetListPlayer(List<Player> li)
        {
            _listPlayer = li;
        }

        public static Player GetBestPlayer()
        {
            SimpleSort();
            return _listPlayer[_listPlayer.Count - 1];
        }

        public static Player GetNthPlayer(int nth)
        {
            SimpleSort();
            return _listPlayer[nth];
        }

        #endregion

        #region LoadAndSave

        public static void SetPathLoad(string path)
        {
            _pathLoad = path;
        }

        public static void SetPathSave(string path)
        {
            _pathSave = path;

        }

        public static void SetPathLoadAndSave(string path)
        {
            _pathLoad = path;
            _pathSave = path;
        }

        public static String GetPathLoad()
        {
            return _pathLoad;
        }
        public static String GetPathSave()
        {
            return _pathSave;
        }

        public static void SaveState()
        {
            if (!File.Exists(_pathSave))
                throw new FileNotFoundException("the save file do not exists");
            SaveAndLoad.Save(_pathSave, _listPlayer);
        }

        #endregion

        #region Init

        public static void InitNew(int size = 200)
        {
            _listPlayer = new List<Player>(200);
        }

        public static void Init()
        {
            if (File.Exists(_pathLoad))
                SaveAndLoad.Load(_pathLoad);
            else
                InitNew();
        }

        #endregion

        #region Display

        public static void PrintScore()
        {
            for (int i = 0; i < _listPlayer.Count; ++i)
            {
                Console.WriteLine("Player {0} has a score of {1}", i, _listPlayer[i].GetScore());
            }
        }

        #endregion

        #region Training

        public static void TrainWithNew(int generationNumber)
        {
            Train(generationNumber, false);
        }

        public static void Train(int generationNumber, bool replaceWithMutation = true)
        {
            Map map = RessourceLoad.GetCurregcyntMap();
            int timeout = map.Timeout;

            for (int i = 0; i < generationNumber; ++i)
            {
                int j = 0;
                for (int i = 0; uf)
                {
                    player.ResetScore();
                    player.SetStart(map);
                    for (int k = 0; k < timeout; ++k)
                    {
                        player.PlayAFrame();
                    }
                    Console.WriteLine("{0}-{1} : {2}%", i, j, (i / _listPlayer.Count) * 100);
                    ++j;
                }

                Regenerate(replaceWithMutation);
            }
        }

        private static void Regenerate(bool replace_with_mutation = true)
        {
            SimpleSort();
            int length = _listPlayer.Count;
            for (int i = 0; i < length / 2; ++i)
            {
                _listPlayer[i].Replace(_listPlayer[length - i - 1], replace_with_mutation);
            }
        }


        public static void SimpleSort()
        {
            //Ptn malo je t'aime
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 1; i < _listPlayer.Count; i++)
                {
                    if (_listPlayer[i].GetScore() < _listPlayer[i - 1].GetScore())
                    {
                        Player swap = _listPlayer[i];
                        _listPlayer[i] = _listPlayer[i - 1];
                        _listPlayer[i - 1] = swap;

                        sorted = false;
                    }
                }
            }
        }

        #endregion
    }
}