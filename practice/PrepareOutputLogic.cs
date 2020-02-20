using System.Collections.Generic;
using System.Linq;
using hashcode.Models;

namespace hashcode
{
    class PrepareOutputLogic
    {
        public static Output PrepareOutput(Input input)
        {
            var outputs = new List<Output>();
            var output = new Output();
            var typeCount = input.TypeCount;
            
            while (typeCount > 0 && input.SlicesPerType.Take(typeCount).Sum() > input.Max - 1 && output.Sum < input.Max - 1)
            {
                output = Logic(input, typeCount);
                if (output.Sum == input.Max - 1)
                {
                    return output;
                }

                outputs.Add(output);
                typeCount--;
            }

            return outputs.First(a => a.Sum == outputs.Max(a => a.Sum));
        }

        private static Output Logic(Input input, int typeCount)
        {
            var output = new Output();

            for (var i = typeCount - 1; i >= 0; i--)
            {
                if (output.Sum + input.SlicesPerType[i] >= input.Max)
                {
                    continue;
                }

                output.OrderingPizzas.Add(i);
                output.Sum += input.SlicesPerType[i];

                if (output.Sum == input.Max - 1)
                {
                    return output;
                }
            }

            return output;
        }
    }
}