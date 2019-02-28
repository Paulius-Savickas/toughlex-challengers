using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheApp
{
    class HorizontalSet
    {
        HorizontalSet()
        {

        }

        public int gettagcount(hashset<string> tags1, hashset<string> tags2)
        {
            var union = tags1.union(tags2);
            return union.count();
        }
    }
}
