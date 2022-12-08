using System.Drawing;
using System.Linq;

namespace DataSerialization
{
    public class ColorParser
    {
        private const int START_INDEX = 7;

        public static Color Parse(string colorString)
        {
            int indexOfLast = colorString.LastIndexOf(']') - 1;
            int length = indexOfLast - START_INDEX + 1;
            string result = colorString.Substring(START_INDEX, length);

            if (result.StartsWith("A="))
            {
                string[] argb = result.Split(", ").Select(x => x[2..]).ToArray();
                int alpha = int.Parse(argb[0]);
                int red = int.Parse(argb[1]);
                int green = int.Parse(argb[2]);
                int blue = int.Parse(argb[3]);

                return Color.FromArgb(alpha, red, green, blue);
            }
            else
            {
                return Color.FromName(result);
            }
        }
    }
}
