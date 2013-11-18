using System;
using System.Threading;
using CodedUI.Specs.UIMap1Classes;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Calculator.Specs
{    
    [Binding]
    public class AddTwoNumbersViewModelSteps
    {
        private Calculator.CalculatorViewModel viewModel = new Calculator.CalculatorViewModel();

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            viewModel.Screen = p0;
        }
            
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0, viewModel.Screen);
        }

        [Given(@"I have press plus")]
        public void GivenIHavePressPlus()
        {
            viewModel.Plus.Execute(null);
        }

        [When(@"I press =")]
        public void WhenIPress()
        {
            viewModel.Equal.Execute(null);
        }
    }

    [Binding, Scope(Tag="ui")]
    public class AddTwoNumbersCodedUISteps
    {
        private UIMainWindowWindow win = new UIMainWindowWindow();
        private ApplicationUnderTest aut;

        [BeforeScenario]
        public void Setup()
        {
            Playback.Cleanup();          
            Playback.Initialize();
            aut = ApplicationUnderTest.Launch(@"..\..\..\Calculator\bin\Debug\Calculator.exe");            
        }

        [AfterScenario]
        public void TearDown()
        {
            Playback.Cleanup();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)        
        {           
            win.Screen.Text = p0.ToString();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.AreEqual(p0.ToString(), win.Screen.Text);
        }

        [Given(@"I have press plus")]
        public void GivenIHavePressPlus()
        {
            Mouse.Click(win.PlusButton);
        }

        [When(@"I press =")]
        public void WhenIPress()
        {
            Mouse.Click(win.EqualButton);
        }
    }
}
