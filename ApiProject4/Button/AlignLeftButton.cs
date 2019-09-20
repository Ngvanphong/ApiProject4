﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Drawing;
using System.Windows.Media;
using System.Reflection;

namespace ApiProject4.Button
{
   public class AlignLeftButton
    {
        public void AlignLeft(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Align";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch (Exception ex) { }
            RibbonPanel panel = null;
            List<RibbonPanel> panels = application.GetRibbonPanels(ribbonTag);
            foreach (RibbonPanel pl in panels)
            {
                if (pl.Name == ribbonPanel)
                {
                    panel = pl;
                    break;
                }
            }
            if (panel == null)
            {
                panel = application.CreateRibbonPanel(ribbonTag, ribbonPanel);
            }

            PushButtonData btnData = new PushButtonData("Align horizontally", "Align horizontally",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.AlignLeftBinding")
            {
                ToolTip = "Allign horizontal for element",
                LongDescription = "Allign horizontal for element",
            };
            PushButtonData btnData2 = new PushButtonData("Arrange vertically", "Arrange vertically",
               Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.ArrangeBinding")
            {
                ToolTip = "Arrange for element",
                LongDescription = "Arrage for element",

            };

            PushButtonData btnData3 = new PushButtonData("Align vertically", "Align vertically",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.AlignTopBinding")
            {
                ToolTip = "Align vertical for element",
                LongDescription = "Align vertical for element",

            };

            List<RibbonItem> projectButtons = new List<RibbonItem>();
            projectButtons.AddRange(panel.AddStackedItems(btnData,btnData3, btnData2));

           // button.Enabled = true;
        }

    }
}