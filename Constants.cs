using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpack
{
   static class Constants
    {
        public static String FILEPATH = "../../data/items.txt";
        public static IFormatProvider FORMAT_PROVIDER = System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat;
    }
}
