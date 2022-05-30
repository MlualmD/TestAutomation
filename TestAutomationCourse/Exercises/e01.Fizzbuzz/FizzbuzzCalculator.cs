namespace TestAutomationCourse.Exercises.e01.Fizzbuzz
{
    public class FizzbuzzCalculator
    {
        public string CountFizzBuzzes(int count)
        {
            string name = "";
            for (int i = 1; i <=count; i++)
            {
                name += $"{FizzBuzz(i)}\n";
               
            }
            return name;
        }
        public string FizzBuzz(int input)
        {
            string s = "";
            if (input % 3 == 0)
            {
                s += "Fizz";
            }
            if (input % 5 == 0)
            {
                s += "Buzz";
            }
            if (s.Length == 0)
            {
                s = "" + input;
            }
            return s;
        }
    }
}
