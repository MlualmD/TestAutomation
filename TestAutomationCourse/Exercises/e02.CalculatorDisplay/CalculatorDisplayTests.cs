using NUnit.Framework;
using TestAutomationCourse.Demos.d01.Nunit;

namespace TestAutomationCourse.Exercises.e02.CalculatorDisplay_1
{
    [TestFixture]
    internal class CalculatorDisplayTests
    {
        CalculatorDisplay _calculatorDisplay;
        [SetUp]
        public void SetUp()
        {
            _calculatorDisplay = new CalculatorDisplay();
        }
        [Test]
        public void Test_One_String()
        {
            _calculatorDisplay.Press("5");
            Assert.AreEqual("5", _calculatorDisplay.getDisplay());
        }
        [Test]
        public void Press_One_And_Oprator()
        {
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("+");
            Assert.AreEqual("5", _calculatorDisplay.getDisplay());
        }
        [Test]
        public void Test_two_String_get_Result_plus()
        {
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("+");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("=");
            Assert.AreEqual("10", _calculatorDisplay.getDisplay());
        }
        [Test]
        public void Test_two_String_get_Result_div()
        {
           _calculatorDisplay.Press("9");
            _calculatorDisplay.Press("/");
            _calculatorDisplay.Press("3");
            _calculatorDisplay.Press("=");
            Assert.AreEqual("3", _calculatorDisplay.getDisplay());
        }
        [Test]

        //[Ignore("Not Work Yet")]
        public void Test_two_String_click_twices_to_result()
        {
            _calculatorDisplay.Press("1");
            _calculatorDisplay.Press("+");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("=");
            _calculatorDisplay.Press("=");
            Assert.AreEqual("6", _calculatorDisplay.getDisplay());
        }
        [Test]
        public void Test_TwoResult()
        { 
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("+");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("=");
            _calculatorDisplay.Press("3");
            _calculatorDisplay.Press("+");
            _calculatorDisplay.Press("3");
            _calculatorDisplay.Press("=");
            Assert.AreEqual("6", _calculatorDisplay.getDisplay());
        }

        [Ignore("Not Work Becuse is not over in 9999")]
        [Test]
        public void Test_And_Six_Numbers()
        {
           
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("5");
            _calculatorDisplay.Press("+");
            _calculatorDisplay.Press("1");
            _calculatorDisplay.Press("1");
            _calculatorDisplay.Press("1");
            _calculatorDisplay.Press("1");
            _calculatorDisplay.Press("=");
            Assert.AreEqual("6666", _calculatorDisplay.getDisplay());
        }

        [Test]
        [TestCase("6","6")]

        public void PressOneStringForResult(string input, string expected)
        {
            _calculatorDisplay.Press(input);
            Assert.AreEqual(expected,_calculatorDisplay.getDisplay());
        }

    }
}
