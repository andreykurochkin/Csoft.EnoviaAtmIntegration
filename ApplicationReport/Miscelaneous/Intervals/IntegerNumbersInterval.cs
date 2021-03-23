using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// creates interval of integers from string
    /// </summary>
    public class IntegerNumbersInterval : NumbersInterval
    {
        public IntegerNumbersInterval(string input) : base(input) { }

        public override List<int> Split()
        {
            var listOfSubstrings = new SubstringsOfIntegersRegex().SplitSilent(input);
            var rawListOfIntegers = listOfSubstrings.ToListImmutable();

            if (rawListOfIntegers.Count == 0) return new List<int>();

            if (rawListOfIntegers.Count == 1)
            {
                var digits = Utility.GetDigits(rawListOfIntegers.ElementAt(0));

                if (digits.Count == 0) return new List<int>();
                if (digits.Count == 1) return new List<int>() { digits.ElementAt(0) };

                // duplicate code
                if (Utility.AllItemsAreSame(digits)) return new List<int>() { digits.ElementAt(0) };
                if (digits.Count == 2) return Utility.GetRange(digits.ElementAt(0), digits.ElementAt(1));
                return digits;
            }

            // duplicate code
            if (Utility.AllItemsAreSame(rawListOfIntegers)) return new List<int>() { rawListOfIntegers.ElementAt(0) };
            if (rawListOfIntegers.Count == 2) return Utility.GetRange(rawListOfIntegers.ElementAt(0), rawListOfIntegers.ElementAt(1));
            return rawListOfIntegers;
        }
    }
}
