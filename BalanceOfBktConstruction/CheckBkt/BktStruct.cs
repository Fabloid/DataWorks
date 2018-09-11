using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckBkt
{
    public class BktStruct
    {
        //check brace sequence
        public static string Check(string construction)
        {
            string open = "[{(";
            string close = "]})";
            int bracket = 0;
            Dictionary<char, char> dict = new Dictionary<char, char>
            {
                {']','[' },
                {'}','{' },
                {')','(' }
            };
            Stack<char> state = new Stack<char>();            
            foreach (var item in construction)
            {
                if (open.IndexOf(item) != -1)
                {
                    state.Push(item);
                    bracket++;
                }
                else
                if (close.IndexOf(item) != -1)
                {
                    if (state.Count != 0)
                    {
                        if (state.First() == dict[item])
                        {
                            state.Pop();
                        }
                        else
                        {
                            throw new Exception($"Предыдущая скобка не закрыта - \"{state.First()}\"");
                        }
                    }
                    else
                    {
                        throw new Exception($"Структура не может начинаться с закрывающей скобки - \"{item}\"");
                    }
                    bracket++;
                }                
            }

            if (state.Count != 0)
            {
                string not_closed = null;
                while (state.Count > 0)
                {
                    not_closed += state.Pop() + " ";
                }
                throw new Exception($"Последовательность содержит не закрытые скобки - {not_closed}");
            }

            if (bracket == 0)
            {
                throw new Exception("Выражение не содержит скобок");
            }

            return "Cкобочная последовательность корректна";
        }
    }
}
