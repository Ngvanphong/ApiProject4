using System;
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
  public  class AllignRightButton
    {
        public void AlignRight(UIControlledApplication application)
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
            Image img = ApiProject4.Properties.Resources.icons8_multicast_16;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("Arrange horizontally", "Arrange \r horizontally",
               Assembly.GetExecutingAssembly().Location, "ApiProject4.AlignElement.ArrangeHorizontallyBinding")
            {
                ToolTip = "Arrange for element",
                LongDescription = "Arrage for element",
                Image = imgSrc,
                LargeImage = imgSrc,
            };
            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
