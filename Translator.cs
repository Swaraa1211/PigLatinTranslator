namespace PigLatinTranslator
{
    internal class Translator
    {
        
        static void Main(string[] args)
        {
            //word
            Console.WriteLine("Enter Word");
            string word = Console.ReadLine();
            string wordLatin = pigLatinWord(word);
            if (wordLatin == "-1")
                Console.WriteLine("There's no vowel in the give word. \nPig Latin Translation failed for the given word!");
            else
                Console.WriteLine(wordLatin);


            //sentence
            Console.WriteLine("Enter Sentence");
            string sentence = Console.ReadLine();
            string extra = sentence.Remove(sentence.Length - 1, 1);
            char lastChar = sentence[sentence.Length - 1];

            Console.WriteLine(pigLatinSentence(extra, lastChar));


        }

        static bool VowelCheck(char vowel)
        {
            return (vowel == 'A' || vowel == 'E' || vowel == 'I' || vowel == 'O' || vowel == 'U' || 
                    vowel == 'a' || vowel == 'e' || vowel == 'i' || vowel == 'o' || vowel == 'u');
        }
        static string pigLatinWord(string s)
        {
            int len = s.Length;
            int indexOfVowel = -1;
            for (int eachLetter = 0; eachLetter < len; eachLetter++)
            {
                if (VowelCheck(s[eachLetter]))
                {
                    indexOfVowel = eachLetter;
                    break;
                }
            }
            if (indexOfVowel == -1)
                return "-1";
            return s.Substring(indexOfVowel) + s.Substring(0, indexOfVowel) + "ay";
        }
        public static string pigLatinSentence(string s, char c)
        {
            string s2 = s.ToLower();
            string[] separate_word = s2.Split(' ');
            string ans = "";
            string latinWord = "";

            for(int eachWord = 0; eachWord<separate_word.Length; eachWord++)
            {
                latinWord = pigLatinWord(separate_word[eachWord]);
                if (ans.Length == 0)
                {
                    ans = ans + latinWord;
                }
                else
                {
                    ans = ans + " " + latinWord;
                }
            }
            char first = ans[0];
            string firstUpper = first.ToString().ToUpper();
            string removed = ans.Remove(0, 1);
            string newWord = firstUpper + removed + c;
            return newWord;
        }
    }
}