using System.Text.RegularExpressions;

namespace CodeGeneratorConsoleApp
{
    public class CodeGenerator
    {
        private static string allowedCharacters = "ACDEFGHKLMNPRTXYZ234579";

        // HasSequentialOrSameCharacters - Check sequential or same characters side by side with the given code.
        private static bool HasSequentialOrSameCharacters(string code)
        {
            char previousCharacter = '\0';
            foreach (char currentCharacter in code.ToCharArray())
            {
                // Check if the current character is the same as the previous character
                if (currentCharacter == previousCharacter)
                {
                    return true;
                }

                // Check if the current character is sequential to the previous character
                if (previousCharacter != '\0' && currentCharacter == previousCharacter + 1)
                {
                    return true;
                }

                previousCharacter = currentCharacter;
            }

            return false;
        }

        // CheckModeSixByTotalIndexOfCode - Check total number index of array mode 6 with the given code.
        private static bool CheckModeSixByTotalIndexOfCode(string code)
        {
            int total = 0;

            foreach (char currentCharacter in code.ToCharArray())
            {
                total += Array.IndexOf(allowedCharacters.ToCharArray(), currentCharacter);
            }

            if (total % 6 == 0)
                return true;

            return false;
        }

        // GetTotalIndexOfCode - Get total number index of array with the given code.
        public static int GetTotalIndexOfCode(string code)
        {
            int total = 0;

            foreach (char currentCharacter in code.ToCharArray())
            {
                total += Array.IndexOf(allowedCharacters.ToCharArray(), currentCharacter);
            }

            return total;
        }

        // GenerateUniqueString - Generate unique string with time tick and random number given size.
        public static string GenerateUniqueString(int size)
        {
            // Use the date and time, along with the random number, to create a unique 8-character string
            string uniqueString = "";
            for (int i = 0; i < size; i++)
            {
                DateTime currentTime = DateTime.Now;

                // Generate a random number between 0 and 99999999
                Random random = new Random();
                int randomNumber = random.Next(0, 99999999);
                int value = (int)((currentTime.Ticks + randomNumber) % allowedCharacters.Length);
                uniqueString += allowedCharacters[value];
            }
            return uniqueString;
        }

        // IsValidString - Check 3 case of input.
        // RegexMatch if the code contains in allowed character.
        // Check mode 6 by total of input characters in array
        // Check sequential characters or same characters contains side by side.
        public static bool IsValidString(string input)
        {
            bool regexMatch = Regex.IsMatch(input, @"^[ACDEFGHKLMNPRTXYZ234579]+$");
            bool checkModeSix = CheckModeSixByTotalIndexOfCode(input);
            bool hasSequentialOrSameCharacters = HasSequentialOrSameCharacters(input);
            if (regexMatch && checkModeSix && !hasSequentialOrSameCharacters)
                return true;

            return false;
        }

    }
}
