namespace Problems.Algorithms
{
    public class MathematicalAlogrithmsHelper
    {
        //Write an Efficient Method to Check if a Number is Multiple of 3
        public static bool IsMultipleOfThree(int number)
        {
            if (number == 0)
                return false;

            return number % 3 == 0; // modular % is costlier operation to use
        }

        // program to print all permutations of a given string
        public static void PrintAllPermutationOfString(string word)
        {
            foreach (char letter in word)
            {

            }
        }
    }
}
