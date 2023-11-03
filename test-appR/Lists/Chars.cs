using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_appR.Lists
{
    public class Character
    {
        public string Name { get; set; }
        public string DueDate { get; set; }
        public string Project { get; set; }

        public string ImgSrc { get; set; }
    }

    public class CharsManager
    {
        public static List<Character> GetChars()
        {
            var Chars = new List<Character>
            {
                new Character { Name = "Keiichi", DueDate = "", Project = "", ImgSrc = "ms-appx:///Assets/Char/keiichi.png" }
            };

            return Chars;
        }
    }
}
