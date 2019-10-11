using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject4.ColorElement
{
  public class ColorSystem
    {
        public static Color Blue { get{return Color.Blue;} }
        public static Color BlueViolet { get { return Color.BlueViolet; } }
        public static Color Brown { get { return Color.Brown; } }
        public static Color BurlyWood { get { return Color.BurlyWood; } }   
        public static Color Aquamarine { get { return Color.Aquamarine; } }
        public static Color Chartreuse { get { return Color.Chartreuse; } }
        public static Color CornflowerBlue { get { return Color.CornflowerBlue; } }
        public static Color DarkOrange { get { return Color.DarkOrange; } }
        public static Color DeepPink { get { return Color.DeepPink; } }
        public static Color DodgerBlue { get { return Color.DodgerBlue; } }
        public static Color Gold { get { return Color.Gold; } }
        public static Color DarkBlue { get { return Color.DarkBlue; } }
        public static Color LightPink { get { return Color.LightPink; } }
        public static Color Red { get { return Color.Red; } }
        public static Color Aqua { get { return Color.Aqua; } }
        public static Color Chocolate { get { return Color.Chocolate; } }
        public static Color Lavender { get { return Color.Lavender; } }
        public static Color DeepSkyBlue { get { return Color.DeepSkyBlue; } }
        public static Color Purple { get { return Color.Purple; } }
        public static Color RosyBrown { get { return Color.RosyBrown; } }
        public  List<Color> ColorUser { set; get; }
        public ColorSystem()
        {
            ColorUser = new List<Color>
            {
                Blue,
                BlueViolet, 
                Brown,
                BurlyWood,
                Aqua,
                Chartreuse,
                CornflowerBlue,
                DarkOrange,
                DeepPink, 
                DodgerBlue,
                Gold,
                DarkBlue,
                LightPink,
                Red,
                Chocolate,
                Lavender,
                DeepSkyBlue,
                Purple,
                RosyBrown,
                Aquamarine,
            };
        }
        

    }
}
