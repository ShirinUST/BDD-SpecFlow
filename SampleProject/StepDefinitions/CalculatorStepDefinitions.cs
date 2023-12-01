using NUnit.Framework;

namespace SampleProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private int firstNumber,secondNumber,result,difference;
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {

            this.firstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this.secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            this.result=this.firstNumber+this.secondNumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
           Assert.AreEqual(this.result,result);
        }

        [When(@"the second number is subtracted from the first number")]
        public void WhenTheSecondNumberIsSubtractedFromTheFirstNumber()
        {
            this.difference=this.firstNumber-this.secondNumber;
        }

        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int difference)
        {
            Assert.AreEqual(difference,this.difference);
        }

    }
}