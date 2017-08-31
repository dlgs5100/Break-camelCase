using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Break_camelCase
{
    [TestFixture]
    public class Sample_Tests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("camelCasing").Returns("camel Casing");
                yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
            }
        }

        [Test, TestCaseSource("testCases")]
        public string Test(string str) => Kata.BreakCamelCase(str);
    }

    public class Kata
    {
        public static string BreakCamelCase(string str)
        {
            int cut = 0;
            string result="";

            foreach(var item in str.Select((v, i) => new { Value = v, Index = i }))
            {
                if (Char.IsUpper(item.Value) && item.Index + 1 == str.Length)
                {
                    result += str.Substring(cut, item.Index - cut) + " ";
                    result += item.Value.ToString();
                }
                else if (Char.IsUpper(item.Value))
                {
                    result += str.Substring(cut, item.Index - cut) + " ";
                    cut = item.Index;
                }
                else if (item.Index + 1 == str.Length)
                    result += str.Substring(cut, item.Index - cut + 1);
                
            }
            return result;
        }
    }
}
