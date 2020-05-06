using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using ApiProject4.Helper;
using System.Drawing;

namespace ApiProject4.FloorPlan
{
   public class PattenColor
    {

    }
    public class ColorWin
    {
        public static Color Blue { get { return Color.Blue; } }
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
        public static Color PapayaWhip { get { return Color.PapayaWhip; } }
        public static Color Peru { get { return Color.Peru; } }
        public static Color SteelBlue { get { return Color.SteelBlue; } }
        public static Color Teal { get { return Color.Teal; } }
        public static Color Tomato { get { return Color.Tomato; } }
        public static Color YellowGreen { get { return Color.YellowGreen; } }
        public static Color MediumTurquoise { get { return Color.MediumTurquoise; } }
        public static Color LightSteelBlue { get { return Color.LightSteelBlue; } }
        public static Color Tan { get { return Color.Tan; } }
        public static Color GreenYellow { get { return Color.GreenYellow; } }
        public static Color White { get { return Color.White; } }
        public List<Color> ColorUser { set; get; }
        public ColorWin()
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
                Red,
                DodgerBlue,
                Gold,
                DarkBlue,
                LightPink,
                Chocolate,
                Lavender,
                DeepSkyBlue,
                Purple,
                RosyBrown,
                Aquamarine,
                PapayaWhip,
                Peru,
                SteelBlue ,
                Teal,
                Tomato ,
                YellowGreen,
                MediumTurquoise,
                LightSteelBlue ,
                Tan,
                GreenYellow,
                White
            };
        }


    }
}
