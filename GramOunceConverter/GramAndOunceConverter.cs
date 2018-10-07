using System;

namespace GramOunceConverter
{
    public class GramAndOunceConverter
    {
        public static double ToOunce(int gram)
        {
            return gram / 28.35;
        }

        public static double ToGram(int ounce)
        {
            return ounce * 28.35;
        }

    }
}
