using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanToInt.RomanNumber
{
    public class Roman
    {
        private string _number;

        private readonly Dictionary<char, int> _values = new Dictionary<char, int>
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };

        public Roman(string number)
        {
            Number = number;
        }

        //verification of the entered value according to the rules for the formation of Roman numerals
        public string Number
        {
            get { return _number; }
            set
            {
                Regex number = new Regex(@"[^IVXLCDM]|[I]{4}|[V]{2}|[X]{4}|[L]{2}|[C]{4}|[D]{2}|[M]{4}",RegexOptions.IgnoreCase);
                if (number.IsMatch(value))
                {
                    string s=null;
                    foreach (var item in _values)
                    {
                        s += item.Key + "=" + item.Value+" ";
                    }
                    throw new Exception("Does not conform to the rules for the formation of Roman numbers:" +
                        $"\n1. Should only contain {s}" +
                        "\n2. Less than four characters in a row" +
                        "\n3. V, L, D can not repeat in a row");
                }
                else
                    _number = value.ToUpper(); 
            }
        }

        public int RomanToInt()
        {
            List<int> temp = Converting();

            return SumNumbers(temp);
        }

        //converting Roman characters to numbers, record to list
        private List<int> Converting()
        {
            List<int> numbers = new List<int>();
            int next = 0;
            int i = 0;

            while (i < _number.Length)
            {
                bool error = false;
                int current = _values[_number[i]];
                if (i < _number.Length - 1)
                    next = _values[_number[i + 1]];
                else next = 0;

                if (current >= next)
                {
                    numbers.Add(current);
                }
                else
                {
                    switch (current)
                    {
                        case 1:
                            {
                                if (next > 10)
                                    error = true;
                                break;
                            }
                        case 5:
                            {
                                error = true;
                                break;
                            }
                        case 10:
                            {
                                if (next > 100)
                                    error = true;
                                break;
                            }
                        case 50:
                            {
                                error = true;
                                break;
                            }
                        case 500:
                            {
                                error = true;
                                break;
                            }
                    }
                    if (error)
                    {
                        throw new Exception("Invalid order");
                    }
                    else
                    {
                        numbers.Add(next - current);
                        i++;
                    }
                }
                i++;
            }

            return numbers;
        }

        //summation of numbers with verification of order correctness
        private int SumNumbers(List<int> numbers)
        {
            int result = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                bool error = false;
                switch (numbers[i - 1])
                {
                    case 900:
                        {
                            if (numbers[i - 1] < 100)
                                error = true;
                            break;
                        }
                    case 400:
                        {
                            if (numbers[i - 1] < 100)
                                error = true;
                            break;
                        }
                    case 90:
                        {
                            if (numbers[i - 1] < 10)
                                error = true;
                            break;
                        }
                    case 40:
                        {
                            if (numbers[i - 1] < 10)
                                error = true;
                            break;
                        }
                    case 9:
                        {
                            if (numbers[i - 1] > 0)
                                error = true;
                            break;
                        }
                    case 4:
                        {
                            if (numbers[i - 1] > 0)
                                error = true;
                            break;
                        }
                }
                if (error)
                    throw new Exception("Invalid order");
                else
                    result += numbers[i];
            }

            return result;
        }
    }
}
