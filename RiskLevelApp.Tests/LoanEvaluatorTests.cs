//integration 
using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorIntegrationTests
    {
        private readonly LoanEvaluator _evaluator = new LoanEvaluator();

        [Fact]
        public void Should_Return_NotEligible_When_IncomeIsTooLow()
        {
            var result = _evaluator.GetLoanEligibility(1500, true, 750, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Should_Return_Eligible_When_Employed_WithHighCredit_AndNoDependents()
        {
            var result = _evaluator.GetLoanEligibility(3000, true, 720, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Should_Return_ReviewManually_When_Employed_WithHighCredit_AndOneDependent()
        {
            var result = _evaluator.GetLoanEligibility(3000, true, 720, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Should_Return_NotEligible_When_Employed_WithLowCredit_AndNoHouse()
        {
            var result = _evaluator.GetLoanEligibility(3000, true, 650, 0, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Should_Return_Eligible_When_Unemployed_WithHighCredit_AndHighIncome_AndOwnsHouse()
        {
            var result = _evaluator.GetLoanEligibility(6000, false, 760, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Should_Return_ReviewManually_When_Unemployed_WithMidCredit_AndNoDependents()
        {
            var result = _evaluator.GetLoanEligibility(3000, false, 660, 0, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Should_Return_NotEligible_When_Unemployed_WithLowCredit()
        {
            var result = _evaluator.GetLoanEligibility(3000, false, 640, 0, true);
            Assert.Equal("Not Eligible", result);
        }
    }
}








/* seperat function
using Xunit;
using LoanApp; // أو RiskLevelApp.Core حسب اسم الـ namespace

namespace LoanApp.Tests // أو RiskLevelApp.Tests
{
    public class LoanEvaluatorTests
    {
        [Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(1500, true, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Eligible_When_Employed_With_HighCredit_And_NoDependents()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, true, 750, 0, false);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_ReviewManually_When_Employed_With_MidCredit_And_OwnsHouse()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, true, 650, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Employed_With_LowCredit()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, true, 500, 0, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_Eligible_When_Unemployed_HighIncome_HighCredit_OwnsHouse()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 760, 1, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_ReviewManually_When_Unemployed_MidCredit_NoDependents()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, false, 660, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_Return_NotEligible_When_Unemployed_LowCredit_WithDependents()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(4000, false, 600, 2, false);
            Assert.Equal("Not Eligible", result);
        }
    }
}*/





/* befor factoring
using Xunit;
using LoanApp;
namespace LoanApp.Tests
{
 public class LoanEvaluatorTests
 {

  [Fact]
  public void GetLoanEligibility_Should_Return_NotEligible_When_Income_Low()
  {
   var evaluator=new LoanEvaluator();
   var result=evaluator.GetLoanEligibility(1500, true, 800, 5, true);
   Assert.Equal("Not Eligible", result);
  }
 }
}*/