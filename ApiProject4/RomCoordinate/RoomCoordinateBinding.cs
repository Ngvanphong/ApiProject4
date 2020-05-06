using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using ApiProject4.Helper;

namespace ApiProject4.RomCoordinate
{
    [Transaction(TransactionMode.Manual)]
    public class RoomCoordinateBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication app = commandData.Application;
            Document doc = app.ActiveUIDocument.Document;
            
            var listRooms= new FilteredElementCollector(doc).WhereElementIsNotElementType().OfClass(typeof(SpatialElement))
                .Where(e => e.GetType() == typeof(Room)).Cast<Room>();
            List<RoomData> listDataRooms = new List<RoomData>();
            foreach(var room in listRooms)
            {
                listDataRooms.Add(ListRoomData(room,doc));
            }
            CreateDataParameter(doc, app, listDataRooms);
            return Result.Succeeded;
        }

        private BoundingBoxXYZ GetBoundingBox(IList<IList<BoundarySegment>> boundary,Room room,Document doc)
        {
            BoundingBoxXYZ bb = new BoundingBoxXYZ();
            double infinity = double.MaxValue;
            
            Parameter paraUpperLimitLevel = room.get_Parameter(BuiltInParameter.ROOM_UPPER_LEVEL);
            Parameter paraUpperOffset = room.get_Parameter(BuiltInParameter.ROOM_UPPER_OFFSET);
            Parameter baseOffset = room.get_Parameter(BuiltInParameter.ROOM_LOWER_OFFSET);

            Level levelUp = doc.GetElement(paraUpperLimitLevel.AsElementId()) as Level;
            double offsetUp = paraUpperOffset.AsDouble();
            double baseValue = baseOffset.AsDouble();

            bb.Min = new XYZ(infinity, infinity, infinity);
            bb.Max = -bb.Min;
            foreach (IList<BoundarySegment> loop in boundary)
            {
                foreach (BoundarySegment seg in loop)
                {
                    Curve c = seg.GetCurve();
                    IList<XYZ> pts = c.Tessellate();
                    foreach (XYZ p in pts)
                    {
                        bb.ExpandToContain(p);
                    }
                }
            }
            try
            {
                double Zmin = bb.Min.Z + baseValue;
                double Zmax = levelUp.Elevation + offsetUp;
                bb.Max = new XYZ(bb.Max.X, bb.Max.Y, Zmax);
                bb.Min = new XYZ(bb.Min.X, bb.Min.Y, Zmin);
            }
            catch { }
            
            return bb;
        }

        private RoomData ListRoomData(Room room,Document doc)
        {
            SpatialElementBoundaryOptions opt = new SpatialElementBoundaryOptions();

            string nr = room.Number;
            string name = room.Name;
            double area = room.Area;

            Location loc = room.Location;
            LocationPoint lp = loc as LocationPoint;
            XYZ p = (null == lp) ? XYZ.Zero : lp.Point;

            BoundingBoxXYZ bb = room.get_BoundingBox(null);

            IList<IList<BoundarySegment>> boundary = room.GetBoundarySegments(opt);

            int nLoops = boundary.Count;

            int nFirstLoopSegments = 0 < nLoops ? boundary[0].Count : 0;

            BoundingBoxXYZ boundary_bounding_box = GetBoundingBox(boundary,room,doc);
            RoomData data = new RoomData();
            data.RoomEleent = room;
            data.BoudingData = boundary_bounding_box;
            return data;

        }

        private void CreateDataParameter(Document doc,UIApplication app,List<RoomData> data)
        {
            ProjectLocation pl = doc.ActiveProjectLocation;
            ParameterRevit paraRevit = new ParameterRevit(app);
            Parameter parameterX = data.First().RoomEleent.LookupParameter("Xmax");
            if (parameterX == null)
            {
                paraRevit.CreateParameterRevit("Room", "Xmax", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            Parameter parameterY = data.First().RoomEleent.LookupParameter("Ymax");
            if (parameterY == null)
            {
                paraRevit.CreateParameterRevit("Room", "Ymax", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            Parameter parameterZ = data.First().RoomEleent.LookupParameter("Zmax");
            if (parameterZ == null)
            {
                paraRevit.CreateParameterRevit("Room", "Zmax", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            Parameter parameterXm = data.First().RoomEleent.LookupParameter("Xmin");
            if (parameterXm == null)
            {
                paraRevit.CreateParameterRevit("Room", "Xmin", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            Parameter parameterYm = data.First().RoomEleent.LookupParameter("Ymin");
            if (parameterYm == null)
            {
                paraRevit.CreateParameterRevit("Room", "Ymin", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            Parameter parameterZm = data.First().RoomEleent.LookupParameter("Zmin");
            if (parameterZm == null)
            {
                paraRevit.CreateParameterRevit("Room", "Zmin", BuiltInCategory.OST_Rooms, BuiltInParameterGroup.PG_IDENTITY_DATA);
            }
            foreach(var item in data)
            {
                try
                {
                    ProjectPosition pointProMax = pl.GetProjectPosition(item.BoudingData.Max);
                    ProjectPosition pointProMin = pl.GetProjectPosition(item.BoudingData.Min);
                    XYZ pointMax = new XYZ(pointProMax.EastWest, pointProMax.NorthSouth, pointProMax.Elevation);
                    XYZ pointMin = new XYZ(pointProMin.EastWest, pointProMin.NorthSouth, pointProMin.Elevation);
                    Parameter paraX = item.RoomEleent.LookupParameter("Xmax");
                    paraRevit.SetValueParameter(paraX, (Math.Round(pointMax.X * 0.3048 * 1000, 2)).ToString());
                    Parameter paraY = item.RoomEleent.LookupParameter("Ymax");
                    paraRevit.SetValueParameter(paraY, (Math.Round(pointMax.Y * 0.3048 * 1000, 2)).ToString());
                    Parameter paraZ = item.RoomEleent.LookupParameter("Zmax");
                    paraRevit.SetValueParameter(paraZ, (Math.Round(pointMax.Z * 0.3048 * 1000, 2)).ToString());
                    Parameter paraXm = item.RoomEleent.LookupParameter("Xmin");
                    paraRevit.SetValueParameter(paraXm, (Math.Round(pointMin.X * 0.3048 * 1000, 2)).ToString());
                    Parameter paraYm = item.RoomEleent.LookupParameter("Ymin");
                    paraRevit.SetValueParameter(paraYm, (Math.Round(pointMin.Y * 0.3048 * 1000, 2)).ToString());
                    Parameter paraZm = item.RoomEleent.LookupParameter("Zmin");
                    paraRevit.SetValueParameter(paraZm, (Math.Round(pointMin.Z * 0.3048 * 1000, 2)).ToString());
                }
                catch { continue; }
               
            }
        }
    }

    public class RoomData
    {
        public Room RoomEleent { set; get; }

        public BoundingBoxXYZ BoudingData { set; get; }
    }


}
