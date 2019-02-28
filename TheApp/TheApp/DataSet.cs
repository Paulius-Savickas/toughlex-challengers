using System.Collections.Generic;

namespace TheApp
{
    public class Picture {
        public string Orientation;
        public int TagNumber;
        public HashSet<string> Tags;
    }

    public class DataSet
    {
        public DataSet()
        {
            Pictures = new List<Picture>();
        }
        public int RowNumber;
        public List<Picture> Pictures;
    }
}
