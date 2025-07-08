using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    /// <summary>
    /// Provides functionality to decode text input from an old-style phone keypad.
    /// </summary>
    public static class PhonePad
    {
        /// <summary>
        /// Decodes a string of key presses from an old phone keypad into text.
        /// </summary>
        /// <param name="input">The input string representing key presses (ends with '#').</param>
        /// <returns>The decoded message as a string.</returns>
        public static string Decode(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var result = new StringBuilder();
            var keyMap = new Dictionary<char, string>
            {
                {'1', "&'("},
                {'2', "ABC"},
                {'3', "DEF"},
                {'4', "GHI"},
                {'5', "JKL"},
                {'6', "MNO"},
                {'7', "PQRS"},
                {'8', "TUV"},
                {'9', "WXYZ"},
                {'0', " "}
            };

            char prevKey = '\0';
            int pressCount = 0;

            foreach (char ch in input)
            {
                if (ch == '#')
                {
                    // Finalize last key press before sending
                    AppendCharacter();
                    break;
                }
                else if (ch == '*')
                {
                    // Backspace
                    AppendCharacter();
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);
                    prevKey = '\0';
                    pressCount = 0;
                }
                else if (ch == ' ')
                {
                    // Pause - finalize current character
                    AppendCharacter();
                    prevKey = '\0';
                    pressCount = 0;
                }
                else if (char.IsDigit(ch))
                {
                    if (ch == prevKey)
                    {
                        pressCount++;
                    }
                    else
                    {
                        AppendCharacter();
                        prevKey = ch;
                        pressCount = 1;
                    }
                }
                // Ignore other characters

            }

            return result.ToString();

            void AppendCharacter()
            {
                if (prevKey != '\0' && keyMap.ContainsKey(prevKey))
                {
                    var chars = keyMap[prevKey];
                    int index = (pressCount - 1) % chars.Length;
                    result.Append(chars[index]);
                }
            }
        }
    }
}
