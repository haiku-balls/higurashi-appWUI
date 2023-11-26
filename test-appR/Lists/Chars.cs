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

        public string ImgSrc { get; set; }
    }

    public class CharsManager
    {
        public static List<Character> GetChars()
        {
            var Chars = new List<Character>
            {
                new Character { Name = "Keiichi", ImgSrc = "ms-appx:///Assets/Char/keiichi.png" },

                new Character { Name = "Rena", ImgSrc = "ms-appx:///Assets/Char/renaS.png" },

                new Character { Name = "Mion", ImgSrc = "ms-appx:///Assets/Char/mionS.png" },

                new Character { Name = "Shion", ImgSrc = "ms-appx:///Assets/Char/shionS.png" },

                new Character { Name = "Satoko", ImgSrc = "ms-appx:///Assets/Char/satokoS.png" },
                
                new Character { Name = "Rika", ImgSrc = "ms-appx:///Assets/Char/rikaS.png" },

                new Character {Name = "Hanyu", ImgSrc = "ms-appx:///Assets/Char/hanyuG.png"}
            };

            return Chars;
        }
    }
}
