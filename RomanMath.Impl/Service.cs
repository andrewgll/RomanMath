using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanMath.Impl
{
	public static class Service
	{
            /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static Dictionary<char, int> nums_ = new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };
        public static int Evaluate(string expression)
        {
            if (expression.Length == 0)
                throw new ArgumentException("You missing expression.");

            var romanNums = expression.Split(new[] { '+', '-', '*', '/' });
            var operands = expression.Split(nums_.Keys.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            var nums = romanNums.Select(x => RomanToInt(x)).ToList();

            if (operands.Count != nums.Count - 1)
                throw new ArgumentException("Not a valid math expression.");

            for (int i = 0; i < operands.Count(); i++)
            {
                if (operands[i] == "*")
                {
                    nums[i] *= nums[i + 1];
                    nums.RemoveAt(i + 1);
                    operands.RemoveAt(i);
                    i--;
                }
                else if (operands[i] == "/")
                {
                    nums[i] /= nums[i + 1];
                    nums.RemoveAt(i + 1);
                    operands.RemoveAt(i);
                    i--;
                }
                else if (operands[i] == "-")
                {
                    nums[i + 1] *= -1;
                }
            }
            return nums.Sum();
        }
        private static int RomanToInt(string num)
        {
           
            List<int> list = new List<int>();
            for (int i = 0; i < num.Length; i++)
            {
                if (nums_.TryGetValue(num[i], out int value))
                {
                    if (list.Count != 0 && list.Last() < value)
                    {
                        if(i !=num.Length -1)
                            throw new ArgumentException("Incorrect roman number format.");
                        return -1 * list.Sum() + value;
                    }
                    list.Add(value);
                }
                else if (num[i] != ' ')
                {
                    throw new ArgumentException("Incorrect input character.");
                }
            }
            return list.Sum();
        }
    }
}
