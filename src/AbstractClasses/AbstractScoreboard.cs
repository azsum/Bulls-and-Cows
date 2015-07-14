
namespace BullsAndCows.AbstractClasses
{
    using System;
    using System.Collections.Generic;

    public abstract class AbstractScoreboard
    {
        protected static int LastPlayerScore = Int32.MinValue;
        protected static readonly List<KeyValuePair<string, int>> ListDict = new List<KeyValuePair<string, int>>();
        protected static readonly Dictionary<string, int> TopScoreBoard = new Dictionary<string, int>();

        protected virtual int SortDictionary(KeyValuePair<string, int> left, KeyValuePair<string, int> right)
        {
            return left.Value.CompareTo(right.Value);
        }

        public virtual void SortScoreBoard()
        {
        }

        public virtual void PrintScoreBoard()
        {
        }

        public virtual void AddPlayerToScoreBoard(int score)
        {
        }

    }
}
