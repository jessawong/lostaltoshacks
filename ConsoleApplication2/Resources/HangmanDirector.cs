//using System.Collections.Generic;

//namespace DemoTest
//{
//    public class HangmanDirector
//    {
//        private List<string> listOfWords;
//        private string patternString;
//        private int max;
//        private List<char> listOfGuesses;

//        public HangmanDirector(List<string> dictionary, int length, int max)
//        {
//            listOfWords = new List<string>();
//            this.max = max;
//            patternString = "-";
//            listOfGuesses = new List<char>();
//            for (int i = 0; i < length; i++)
//            {
//                patternString += " -";
//            }

//            for (int i = 0; i < dictionary.Count; i++)
//            {
//                if (dictionary[i].Length == length)
//                {
//                    listOfWords.Add(dictionary[i]);
//                }
//            }


//        }

//        public List<string> words()
//        {
//            return listOfWords;
//        }

//        public int guessesLeft()
//        {
//            return this.max;
//        }

//        public string pattern()
//        {
//            return patternString;
//        }

//        public List<char> guesses()
//        {
//            return listOfGuesses;
//        }

//        public int record(char character)
//        {
            

//        }
//    }
//}