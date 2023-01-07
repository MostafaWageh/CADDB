using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace CADDB
{
    public class CommonUtil
    {
        public static string GetPolylineCoordinates(Polyline p1)
        {
            var vcount =p1.NumberOfVertices;
            Point2d coord;
            string coords = "";
            int i;
            for(i = 0; i < vcount -1 ; i++)
            {
                coord = p1.GetPoint2dAt(i);
                coords += coord[0].ToString() + "," + coord[1].ToString();
                if ((i < vcount - 1))
                    coords   += ",";

            }
            return coords;

        }

    }
}
