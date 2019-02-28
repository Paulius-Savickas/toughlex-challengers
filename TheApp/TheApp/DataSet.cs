using System.Collections.Generic;

namespace TheApp
{
    public class Slide
    {
        public int Id;
        public string Orientation;
        public int TagNumber;
        public HashSet<string> Tags;
    }

    public class DataSet
    {
        public DataSet()
        {
            Slides = new List<Slide>();
        }
        public int RowNumber;
        public List<Slide> Slides;
    }
}
