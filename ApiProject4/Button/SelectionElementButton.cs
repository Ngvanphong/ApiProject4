using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using System.Drawing;
using System.Windows.Media;
using System.Reflection;

namespace ApiProject4.Button
{
   public class SelectionElementButton
    {
        public void SelectionElement(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "Element";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch { }
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
            Image img = ApiProject4.Properties.Resources.icons8_select_column_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("SelectionElement", "SelectionElement",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.SelectionElement.SelectionElementBinding")
            {
                ToolTip = "Select element faster",
                LongDescription = "Select element faster",
                Image = imgSrc,
                LargeImage = imgSrc,
            };

            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;


        }

    }
}
