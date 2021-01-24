using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("LongYatziUnitTests")]
namespace LongYatzi
{

    internal class Dice
    {
        private int _diceAmount = 5;
        private int _throw = 0;
        List<Die> _diceList = new List<Die>();
        public void ThrowDice()
        {
            Random rand = new Random();
            if (_throw == 3)
            {
                ResetHeld();
                _throw = 0;
            }
            foreach (Die die in _diceList)
            {
                if (!die.Held)
                {
                    die.EyeCount = rand.Next(1, 7);
                }
            }
            _throw++;
        }
        public void AddDie(int _eyecount)
        {
            _diceList.Add(new Die(_eyecount));
        }
        public List<Die> ReadDice()
        {
            return _diceList;
        }
        public int ThrowCount()
        {
            return _throw;
        }
        public void ThrowCount(int throwcount)
        {
            _throw = throwcount;
        }
        public void Initialize()
        {
            for (int i = 0; i < _diceAmount; i++)
            {
                _diceList.Add(new Die(1));
            }
        }
        public void Hold(int die)
        {
            _diceList[die].Held = true;
        }
        public void ResetHeld()
        {
            foreach (Die die in _diceList)
            {
                die.Held = false;
            }
        }
        public int GetThrow()
        {
            return _throw;
        }
        public bool HandContains(int _eyecount)
        {
            foreach (Die die in _diceList)
            {
                if (die.EyeCount == _eyecount)
                    return true;
            }
            return false;
        }
        #region Dice Validators
        internal int Validate(int _eyecount) //validate category from upper section.
        {
            return ((-3 + Count(_eyecount)) * _eyecount); //if you get 3 same, you get 0 points. Less if you have less and more if you have more...
        }
        internal int ValidatePair()
        {
            for (int _eyecount = 6; _eyecount > 0; _eyecount--)
            {
                if (Count(_eyecount)>=2) return _eyecount*2;
            }
            return 0;
        }
        internal int ValidateTwoPairs() // Error with Full House
        {
            if (ValidateFourSame() > 0) return ValidateFourSame();//if there is 4 of the highest non checked number, there is 2 pairs of it which is same as four same
            for(int _eyecount = ValidatePair() / 2-1; _eyecount>0;_eyecount--)//start searching for smaller pair, _eyecount skips already found pair and bigger numbers
            {
                if (Count(_eyecount) >= 2) return ValidatePair()+_eyecount*2;
            }
            return 0;
        }
        internal int ValidateThreeSame()
        {
            for (int _eyecount = 6; _eyecount > 0; _eyecount--)
            {
                if (Count(_eyecount) >= 3) return _eyecount * 3;
            }
            return 0;
        }

        internal int ValidateFourSame()
        {
            for (int _eyecount = 6; _eyecount > 0; _eyecount--)
            {
                if (Count(_eyecount) >= 4) return _eyecount * 4;
            }
            return 0;
        }
        internal int ValidateSmallStraight()
        {
            if (!HandContains(6) && ValidatePair() == 0) return 15;
            return 0;
        }
        internal int ValidateBigStraight()
        {
            if (!HandContains(1) && ValidatePair()==0) return 20;
            return 0;
        }
        internal int ValidateFullHouse()
        {
            if (ValidateThreeSame()>0 && ValidateTwoPairs() > 0 && (ValidateFourSame() ==0 || ValidateYatzy() > 0)) return Sum();//if the hand is both three same, and two pairs, it must be full house, so return sum of all the dice (if it's not four sames but is yatzy)
            return 0;
        }
        internal int Sum()
        {
            return _diceList.Sum(die => die.EyeCount);
        }
        internal int ValidateYatzy()
        {

            if (Count(_diceList[0].EyeCount) == 5) return 50;
            return 0;
        }
        internal int Count(int _eyecount)
        {
            return _diceList.Count(die => die.EyeCount == _eyecount);
        }
        #endregion

    }
}
