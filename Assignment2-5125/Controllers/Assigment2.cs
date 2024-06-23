using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Assignment2_5125.Controllers
{
    public class Assignment2Controller : Controller
    {
        // J1 Problem: Calorie Counter
        // GET: Assignment2/J1/Menu/{burger}/{drink}/{side}/{dessert}
        public ActionResult J1Menu(int burger, int drink, int side, int dessert)
        {
            // Arrays to store calorie values for different menu items
            int[] burgerCalories = { 0, 461, 431, 420, 0 };
            int[] drinkCalories = { 0, 130, 160, 118, 0 };
            int[] sideCalories = { 0, 100, 57, 70, 0 };
            int[] dessertCalories = { 0, 167, 266, 75, 0 };

            // Calculate total calories based on selected menu items
            int totalCalories = burgerCalories[burger] + drinkCalories[drink] + sideCalories[side] + dessertCalories[dessert];

            // Return the total calories as a formatted string response
            return Content($"Your total calorie count is {totalCalories}");
        }

        // J2 Problem: Roll the Dice
        // GET: Assignment2/J2/DiceGame/{m}/{n}
        public ActionResult J2DiceGame(int m, int n)
        {
            // Initialize variable to count ways to get sum 10
            int ways = 0;

            // Nested loops to simulate rolling two dice with m and n sides
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    // Check if sum of dice is 10
                    if (i + j == 10)
                    {
                        ways++; // Increment count of ways
                    }
                }
            }

            // Generate result message based on number of ways
            string resultMessage = ways == 1 ? "There is 1 way to get the sum 10." : $"There are {ways} ways to get the sum 10.";

            // Return the result message as a formatted string response
            return Content(resultMessage);
        }

        // J3 Problem: Cell Phone Messaging
        private static readonly Dictionary<char, string> PhoneKeyMapping = new Dictionary<char, string>
        {
            { '2', "ABC" }, { '3', "DEF" },
            { '4', "GHI" }, { '5', "JKL" },
            { '6', "MNO" }, { '7', "PQRS" },
            { '8', "TUV" }, { '9', "WXYZ" }
        };

        // GET: Assignment2/J3/CellPhoneMessage/{input}
        public ActionResult J3CellPhoneMessage(string input)
        {
            // StringBuilder to build the resulting message
            var result = new StringBuilder();

            // Iterate through each character in the input string
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                // Check if the character exists in the phone key mapping
                if (PhoneKeyMapping.ContainsKey(currentChar))
                {
                    int pressCount = 1;

                    // Count consecutive occurrences of the same character
                    while (i + 1 < input.Length && input[i + 1] == currentChar)
                    {
                        pressCount++;
                        i++;
                    }

                    // Get the corresponding letters from the phone key mapping
                    string letters = PhoneKeyMapping[currentChar];

                    // Calculate the index of the letter based on press count
                    int letterIndex = (pressCount - 1) % letters.Length;

                    // Append the letter to the result
                    result.Append(letters[letterIndex]);
                }
            }

            // Return the resulting message as a formatted string response
            return Content(result.ToString());
        }
    }
}
