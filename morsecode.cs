using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode
{
    public static class MorseCode
    {
        public static Exception EmptyStringException = new Exception("String is empty!");
        public static Exception UnrecognizedSymbolException = new Exception("Unrecognized symbol was found!");

        public enum Lang
        {
            RU,
            EN
        }
        public static Dictionary<char, string> intl = new Dictionary<char, string>
            {
                {'1', "*----"},
                {'2', "**---"},
                {'3', "***--"},
                {'4', "****-"},
                {'5', "*****"},
                {'6', "-****"},
                {'7', "--***"},
                {'8', "---**"},
                {'9', "----*"},
                {'0', "-----"}
            };
        public static Dictionary<char, string> en = new Dictionary<char, string>
            {
                {'A', "*-"},
                {'B', "-***"},
                {'C', "-*-*"},
                {'D', "-**"},
                {'E', "*"},
                {'F', "**-*"},
                {'G', "--*"},
                {'H', "****"},
                {'I', "**"},
                {'J', "*---"},
                {'K', "-*-"},
                {'L', "*-**"},
                {'M', "--"},
                {'N', "-*"},
                {'O', "---"},
                {'P', "*--*"},
                {'Q', "--*-"},
                {'R', "*-*"},
                {'S', "***"},
                {'T', "-"},
                {'U', "**-"},
                {'V', "***-"},
                {'W', "*--"},
                {'X', "-**-"},
                {'Y', "-*--"},
                {'Z', "--**"}
            };
        public static Dictionary<char, string> ru = new Dictionary<char, string>
            {
                {'А', "*-"},
                {'Б', "-***"},
                {'В', "*--"},
                {'Г', "--*"},
                {'Д', "-**"},
                {'Е', "*"},
                {'Ё', "*"},
                {'Ж', "***-"},
                {'З', "--**"},
                {'И', "**"},
                {'Й', "*---"},
                {'К', "-*-"},
                {'Л', "*-**"},
                {'М', "--"},
                {'Н', "-*"},
                {'О', "---"},
                {'П', "*--*"},
                {'Р', "*-*"},
                {'С', "***"},
                {'Т', "-"},
                {'У', "**-"},
                {'Ф', "**-*"},
                {'Х', "****"},
                {'Ц', "-*-*"},
                {'Ч', "---*"},
                {'Ш', "----"},
                {'Щ', "--*-"},
                {'Ь', "-**-"},
                {'Ы', "-*--"},
                {'Э', "**-**"},
                {'Ю', "**--"},
                {'Я', "*-*-"}
            };
        public static String toMorse(String str, Lang lang)
        {
            if (str.Length == 0) throw EmptyStringException;
            str = str.ToUpper();
            Dictionary<char, string> dict = lang == Lang.RU ? ru : en;
            String output = null;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == ' ')
                {
                    output += output == null ? "  " : " ";
                    continue;
                }
                foreach (KeyValuePair<char, string> pair in dict) if (pair.Key == str[i])
                    {
                        output += pair.Value + ' ';
                        goto LoopExit;
                    }
                foreach (KeyValuePair<char, string> pair in intl) if (pair.Key == str[i])
                    {
                        output += pair.Value + ' ';
                        goto LoopExit;
                    }
                throw UnrecognizedSymbolException;
            LoopExit: continue;
            }
            return output;
        }
        public static String toNormal(String str, Lang lang)
        {
            if (str.Length == 0) throw EmptyStringException;
            str = str.ToUpper();
            Dictionary<char, string> dict = lang == Lang.RU ? ru : en;
            String output = null;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] == ' ')
                {
                    output += ' ';
                    continue;
                }
                {
                    String temp = null;
                    for (int j = 0; i + j < str.Length && str[i + j] != ' '; ++j) temp += str[i + j];
                    if (dict.Any(x => x.Value.Equals(temp, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        output += dict.FirstOrDefault(x => x.Value == temp).Key.ToString();
                        i += dict.FirstOrDefault(x => x.Value == temp).Value.Length;
                        goto LoopExit;
                    }
                    if (intl.Any(x => x.Value.Equals(temp, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        output += intl.FirstOrDefault(x => x.Value == temp).Key.ToString();
                        i += intl.FirstOrDefault(x => x.Value == temp).Value.Length;
                        goto LoopExit;
                    }
                }
                throw UnrecognizedSymbolException;
            LoopExit: continue;
            }
            return output;
        }
    }
}