using System.Collections.Generic;

namespace hashcode.Models
{
    public class Input
    {
        public int Max { get; set; }
        public int TypeCount { get; set; }

        public  List<int> SlicesPerType { get; set; }
    }
}
