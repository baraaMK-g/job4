//after factoring
namespace LoanApp
{ 
    public static class LoanEvaluator
    {
        public static string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
        {
            if (income < 2000)
                return "Not Eligible";

            if (hasJob)
                return EvaluateEmployed(creditScore, dependents, ownsHouse);

            return EvaluateUnemployed(income, creditScore, dependents, ownsHouse);
        }

        private static string EvaluateEmployed(int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 700)
            {
                if (dependents == 0)
                    return "Eligible";
                if (dependents <= 2)
                    return "Review Manually";
                return "Not Eligible";
            }

            if (creditScore >= 600)
                return ownsHouse ? "Review Manually" : "Not Eligible";

            return "Not Eligible";
        }

        private static string EvaluateUnemployed(int income, int creditScore, int dependents, bool ownsHouse)
        {
            if (creditScore >= 750 && income > 5000 && ownsHouse)
                return "Eligible";

            if (creditScore >= 650 && dependents == 0)
                return "Review Manually";

            return "Not Eligible";
        }
    }
}

/* befor factoring
namespace LoanApp
{
 public class LoanEvaluator
 {
  public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
  {
   if(income<2000)
   return"Not Eligible";
   if(hasJob)
   {
     if(creditScore>=700)
     {
       if(dependents==0)
          return"Eligible";
       else if(dependents<=2)
          return"Review Manually";
       else
          return"Not Eligible";
     }
     else if(creditScore>=600)
     {
      if(ownsHouse)
         return"Review Manually";
      else
         return"Not Eligible";
     }
     else
     {
       return"Not Eligible";
     }
   }
   else
   {
    if(creditScore>=750&&income>5000&&ownsHouse)
          return"Eligible";
    else if(creditScore>=650&&dependents==0)
          return"Review Manually";
    else
          return"Not Eligible";
   }
  }
 }
}
*/