using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
namespace ApiProject4.AllginViewPort
{
  public static  class AppPenalAlignViewport
    {
        public static frmAlginViewport myFromAlignViewport;
        public static void ShowAlignViewport()
        {
            AlignViewportHandler handlerViewport = new AlignViewportHandler();
            ExternalEvent eventViewport = ExternalEvent.Create(handlerViewport);
            myFromAlignViewport = new frmAlginViewport(eventViewport, handlerViewport);
            myFromAlignViewport.Show();
        }

    }
}
