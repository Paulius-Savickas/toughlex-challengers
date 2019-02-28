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

        public static List<Picture> GetVPicturesList(List<Picture> Pictures)
        {
            return Pictures.Where(p => p.Orientation == "V").ToList();
        }

        public static InputOutput.Slide JoinVPictures(Picture pic1, Picture pic2)
        {
            InputOutput.Slide slide = new InputOutput.Slide(pic1);
            slide.Pic2 = pic2;
            slide.Tags = new HashSet<string>(pic1.Tags.Union(pic2.Tags));
            slide.Used = false;

            return slide;
        }

        public static List<InputOutput.Slide> GetVSlidesList(List<Picture> picturesList)
        {
            picturesList = GetVPicturesList(picturesList);
            List<InputOutput.Slide> slidesList = new List<InputOutput.Slide>();

            for(int i = 0; i < picturesList.Count(); i += 2)
            {
                slidesList.Add(JoinVPictures(picturesList.ElementAt(i), picturesList.ElementAt(i + 1)));
            }

            return slidesList;
        }

        public static int GetTagCount(HashSet<string> tags1, HashSet<string> tags2)
        {
            var union = tags1.Union(tags2);
            return union.Count();
        }
    }
}
