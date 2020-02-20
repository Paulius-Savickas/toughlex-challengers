using System.Collections.Generic;

namespace TheApp
{
    public class Picture
    {
        public int Id;
        public string Orientation;
        public int TagNumber;
        public HashSet<string> Tags;
        public bool Used;
    }

    public class DataSet
    {
        public DataSet()
        {
            Pictures = new LinkedList<Picture>();
        }
        public int RowNumber;
        public LinkedList<Picture> Pictures;
    }
}
