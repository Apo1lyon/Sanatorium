using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanatorium
{
    public static class ThemeColor
    {

        public static Color PrimaryColor { get; set; } //Первичный цвет
        public static Color SecondaryColor { get; set; } //Вторичный цвет

        public static List<string> ColorList = new List<string>() 
        {
            "#591E4A",
            "#3A0A2E",
            "#712633",
            "#552B32",
            "#4A0C17",
            "#391F51",
            "#30213D",
            "#200A35",
            "#1F344E",
            "#202C3A",
            "#0A1D33",
            "#292453",
            "#26243E",
            "#100C36",
            "#1B4E40",
            "#1E3B33",
            "#093327"};//Список цветов

        public static Color ChangeColorBrightness(Color color, double correctionFactor) //Изменение цветопередачи
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
