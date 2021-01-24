using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("LongYatziUnitTests")]
namespace LongYatzi
{
    class ScoreBoard
    {
        internal int?[,] upperSection = new int?[4, 6]; //x = throw 1-3, y = dice eye count - 1
        internal int?[,] lowerSection = new int?[4, 9]; //x = throw 1-3, y = category of points
        /*0 = pairs
         *1 = 2 pairs
         *2 = 3 sames
         *3 = four same
         *4 = small straight
         *5 = big straight
         *6 = full house
         *7 = random
         *8 = yatzy
         */
        int?[] bonuses = new int?[4];
        internal void StoreScoreUp(int _throw,int _eyecount,int _score)
        {
            _eyecount--;
            _throw--;
            upperSection[_throw, _eyecount] = _score;
            
        }
        internal void StoreScoreDown(int _throw, int _category, int _score)
        {

                _throw--;
                lowerSection[_throw, _category] = _score;
        }
        internal int? GetScoreUp(int _throw, int _eyecount)
        {
            _eyecount--;
            _throw--;
            return upperSection[_throw, _eyecount];
        }
        internal int? GetScoreDown(int _throw, int _category)
        {
            _throw--;
            return lowerSection[_throw, _category];
        }
        internal bool RoomForThrow(int _throw)
        {
            if(_throw==0)
            {
                return true;
            }
            if (_throw == 2 || _throw == 1)
            {
                if (!UpperSectionFull(2) || !LowerSectionFull(2))
                {
                    return true;
                }
                if (!UpperSectionFull(3) || !LowerSectionFull(3))
                {
                    return true;
                }
            }
            if (_throw == 1)
            {
                if (!UpperSectionFull(1) || !LowerSectionFull(1))
                {
                    return true;
                }
            }
            return false;
        }

        public List<int> GetActiveForceCells()
        {
            for(int i = 1;i<7;i++)
            {
                if (GetScoreUp(4, i) == null) return new List<int>{ i - 1};
            }
            int listcount = 6;
            for (int i = 0; i < 9; i++)
            {
                if (GetScoreDown(4, i) != null) listcount++;
            }
            if (listcount == 10 && GetScoreDown(4, 4) == null) return new List<int> { 10,11};//this line and line below are so that small straight and big straight can be played in any order
            if (listcount == 11 && GetScoreDown(4, 4) == null) return new List<int> { 10 };
            return new List<int> { listcount };
        }
        public bool UpperSectionFull(int column)
        {
            for (int i = 0; i < 6; i++)
            {
                if (upperSection[column, i] == null)
                {
                    return false;
                }
            }
            if(UpperSectionTotal(column)>=0)
            {
                bonuses[column] = 50;
            }
            return true;
        }

        private bool LowerSectionFull(int column)
        {
            for (int i = 0; i < 9; i++)
            {
                if (lowerSection[column, i] == null)
                {
                    return false;
                }
            }
            return true;
        }
        public int? UpperSectionTotal(int column)
        {
            int? total = 0;
            for(int i = 0;i<6;i++)
            {
                if(upperSection[column,i]!=null) total += upperSection[column, i];
            }
            return total;
        }
        public int? LowerSectionTotal(int column)
        {
            int? total = 0;
            for (int i = 0; i < 9; i++)
            {

                if (lowerSection[column, i] != null) total += lowerSection[column, i];
            }
            return total;
        }
        public int? Total(int column)
        {
            int? total = 0;
            if (UpperSectionTotal(column) != null) total += UpperSectionTotal(column);
            if (bonuses[column] != null) total += bonuses[column];
            if (LowerSectionTotal(column) != null) total += LowerSectionTotal(column);
            return total;
        }
        public int? Total()
        {
            return Total(0) + Total(1) + Total(2) + Total(3);
        }
        public int? GetBonus(int column)
        {
            return bonuses[column];
        }
    }
}
