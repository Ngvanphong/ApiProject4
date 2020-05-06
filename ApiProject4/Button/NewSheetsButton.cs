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
  public  class NewSheetsButton
    {
        public void NewSheet(UIControlledApplication application)
        {
            const string ribbonTag = "ArmoApiVn";
            const string ribbonPanel = "View&Sheet";
            try
            {
                application.CreateRibbonTab(ribbonTag);
            }
            catch{ }
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
            Image img = ApiProject4.Properties.Resources.icons8_create_document_32;
            ImageSource imgSrc = Helper.Extension.GetImageSource(img);
            PushButtonData btnData = new PushButtonData("CreateSheets", "CreateSheets",
                Assembly.GetExecutingAssembly().Location, "ApiProject4.NewSheets.NewSheetsBinding")
            {
                ToolTip = "Create new sheets",
                LongDescription = "Create new sheets",
                Image = imgSrc,
                LargeImage = imgSrc,
            };
            PushButton button = panel.AddItem(btnData) as PushButton;
            button.Enabled = true;
        }
    }
}
