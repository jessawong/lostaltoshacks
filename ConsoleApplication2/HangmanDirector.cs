using System.Collections.Generic;

namespace DemoTest
{
    public class HangmanDirector
    {
        private List<string> listOfWords;
        private string patternString;
        private int max;
        private List<char> listOfGuesses;

        public HangmanDirector(List<string> dictionary, int length, int max)
        {
            listOfWords = new List<string>();
            this.max = max;
            patternString = "-";
            listOfGuesses = new List<char>();
            for (int i = 0; i < length; i++)
            {
                patternString += " -";
            }

            for (int i = 0; i < dictionary.Count; i++)
            {
                if (dictionary[i].Length == length)
                {
                    listOfWords.Add(dictionary[i]);
                }
            }


        }

        public List<string> words()
        {
            return listOfWords;
        }

        public int guessesLeft()
        {
            return this.max;
        }

        public string pattern()
        {
            return patternString;
        }

        public List<char> guesses()
        {
            return listOfGuesses;
        }

        public int record(char character)
        {
            var currentCounts = new Dictionary<string, List<string>>();
            listOfGuesses.Add(character);
            var mostWords = 0;
            foreach (string word in listOfWords)
            {
                string newPattern = "";
                foreach (char letter in word)
                {
                    if (!listOfGuesses.Contains(letter))
                    {
                        newPattern += "- ";
                    }
                    else
                    {
                        newPattern += letter + " ";
                    }
                }
                newPattern = newPattern.Trim();
                if (!currentCounts.ContainsKey(newPattern))
                {
                    currentCounts.Add(newPattern, new List<string>());
                }

                currentCounts[newPattern].Add(word);
                if (currentCounts[newPattern].Count > mostWords)
                {
                    mostWords = currentCounts[newPattern].Count;
                    listOfWords = currentCounts[newPattern];
                    patternString = newPattern;
                }

            }
            int times = 0;
            foreach (char letter in patternString)
            {
                if (letter == character)
                {
                    times++;
                }
            }

            if (times == 0)
            {
                max--;
            }
            return times;

        }
    }
}