using System.Collections.Generic;

namespace hashcode.Models
{
    public class Output
    {
        public int TypeCount => OrderingPizzas.Count;
        public List<int> OrderingPizzas { get; set; } = new List<int>();
        public int Sum { get; set; }
    }
}
