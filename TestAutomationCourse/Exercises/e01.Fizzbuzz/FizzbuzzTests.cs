using NUnit.Framework;

namespace TestAutomationCourse.Exercises.e01.Fizzbuzz
{
    [TestFixture]
    internal class FizzbuzzTests
    {
        [Test]
        public void FirstTest()
        {
            FizzbuzzCalculator fizzbuzzCalculator = new FizzbuzzCalculator();
            Assert.AreEqual("1\n2\n", fizzbuzzCalculator.CountFizzBuzzes(2));

            string [] arrayFizz =fizzbuzzCalculator.CountFizzBuzzes(15).Split("13");
            Assert.AreEqual("\n14\nFizzBuzz\n",arrayFizz[1]);
        }
    }
} 
