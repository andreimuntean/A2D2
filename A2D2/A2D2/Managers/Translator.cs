using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2D2
{
    static class Translator
    {
        private static List<char> humanCharacters;
        private static List<string> machineCharacters;

        static Translator()
        {
            humanCharacters = new List<char>()
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0',
                '1', '2', '3', '4', '5', '6', '7', '8', '9',
                ' '
            };

            machineCharacters = new List<string>()
            {
                "10", "0111", "0101", "011", "1", "1101", "001", "1111", "11",
                "1000", "010", "1011", "00", "01", "000", "1001", "0010", "101",
                "111", "0", "110", "1110", "100", "0110", "0100", "0011", "00000",
                "10000", "11000", "11100", "11110", "11111", "01111", "00111", "00011", "00001",
                "2"
            };
        }

        /// <summary>
        /// Translates from machine to human.
        /// </summary>
        /// <param name="message">Message to be translated.</param>
        /// <returns></returns>
        public static string ToHuman(string message)
        {
            // Example: "INFO 2014" = "11 01 1101 000 2 11000 00000 10000 11110"
            var result = "";
            var start = 0;

            if (message.Length > 0)
            {
                for (var i = 0; i < message.Length; ++i)
                {
                    if (i == message.Length - 1)
                    {
                        var character = message.Substring(start, i - start);
                        var index = machineCharacters.IndexOf(character);
                        if (index != -1) result += humanCharacters[index];
                        else result += '?';
                    }
                    else if (message[i] == ' ')
                    {
                        var character = message.Substring(start, i - start);
                        var index = machineCharacters.IndexOf(character);
                        if (index != -1) result += humanCharacters[index];
                        else result += '?';
                        start = i + 1;
                    }
                }
            }
            else result = "?";

            return result;
        }
        
        /// <summary>
        /// Translates from human to machine.
        /// </summary>
        /// <param name="message">Message to be translated.</param>
        /// <returns></returns>
        public static string ToMachine(string message)
        {
            var result = "";

            foreach (var character in message)
            {
                var index = humanCharacters.IndexOf(character);
                if (index != -1) result += machineCharacters[index] + " ";
            }

            if (result != "")
            {
                return result.Substring(0, result.Length - 1);
            }
            else return "";
        }
    }
}
