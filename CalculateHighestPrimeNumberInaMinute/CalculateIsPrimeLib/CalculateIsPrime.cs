using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateIsPrimeLib
{
    public class CalculateIsPrime
    {

        #region prime number helpers
        /// <summary>
        /// Determines if the number is Prime or the Highest Prime Number
        /// </summary>
        /// <param name="current_natural_number">Current counter</param>
        public int calculatePrime(int current_natural_number)
        {
            for (int current_number = current_natural_number; current_number > 2; current_number--)
            {

                if (isPrimeNumber(current_number))
                {
                    //if (!primeArray.Contains(current_number))
                    //    primeArray.Add(current_number);
                    //break;
                    return current_number;
                }

            }
            return 0;
        }
        /// <summary>
        /// Determines if the number is Prime.
        /// </summary>
        /// <param name="cheeckIfPrimeOrNextSmallestPrim">Number to test</param>
        /// <returns></returns>
        public bool isPrimeNumber(int cheeckIfPrimeOrNextSmallestPrim)
        {
            if(cheeckIfPrimeOrNextSmallestPrim > int.MaxValue -1  )
            {
                throw new ArgumentException("Number is out of range.");
            }
            if(cheeckIfPrimeOrNextSmallestPrim < 0 )
            {
                throw new ArgumentException("Number cannot be less than zero.");
            }
            if (cheeckIfPrimeOrNextSmallestPrim == 1)
            {
                throw new ArgumentException("Number has be greater than One.");
            }
            if (cheeckIfPrimeOrNextSmallestPrim == 2)
                return true;
            try
            {

                if (cheeckIfPrimeOrNextSmallestPrim % 2 == 0) return false;

                int root = (int)Math.Sqrt(cheeckIfPrimeOrNextSmallestPrim);
                for (int leastNumber = 3; leastNumber <= root; leastNumber += 2)
                {
                    if (cheeckIfPrimeOrNextSmallestPrim % leastNumber == 0)
                    {

                        return false;
                    }

                }



            }
            catch (Exception e)
            {
                System.Diagnostics.EventLog appLog =
                new System.Diagnostics.EventLog();
                appLog.Source = "CalculateHighestPrimeNumber";
                appLog.WriteEntry(e.InnerException.ToString());
            }
            return true;
        }
        #endregion
    }
}
