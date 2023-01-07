using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CADDB
{
    internal class DBLoadUtil
    {
        public string LoadLines()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "LINE"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);
                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double startPtx = 0.0, startPty = 0.0, EndPtx = 0.0, EndPty = 0.0;
                        string Layer = "", ltype = "", Color = "";
                        double len = 0.0;
                        Line line = new Line();
                        SelectionSet ss = ssPrompt.Value;
                        string sql = @"INSERT INTO dbo.Lines (StartPtx,StartPty,EndPtx,EndPty,Layer,Color,LineType,Length,Created)
                                    VALUES(@StartPtx,@StartPty,@EndPtx,@EndPty,@Layer,@Color,@LineType,@Length,@Created)";
                        conn.Open();
                        foreach (SelectedObject sObj in ss)
                        {
                            line = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as Line;
                            startPtx = line.StartPoint.X;
                            startPty = line.StartPoint.Y;
                            EndPtx = line.EndPoint.X;
                            EndPty = line.EndPoint.Y;
                            Layer = line.Layer;
                            ltype = line.Linetype;
                            Color = line.Color.ToString();
                            len = line.Length;

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@StartPtx", startPtx);
                            cmd.Parameters.AddWithValue("@StartPty", startPty);
                            cmd.Parameters.AddWithValue("@EndPtx", EndPtx);
                            cmd.Parameters.AddWithValue("@EndPty", EndPty);
                            cmd.Parameters.AddWithValue("@Layer", Layer);
                            cmd.Parameters.AddWithValue("@Color", Color);
                            cmd.Parameters.AddWithValue("@LineType", ltype);
                            cmd.Parameters.AddWithValue("@Length", len);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }


                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }
                    result = "Done Completed Succefully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }

        //------------------------------------------------------------------------
        public string LoadMtext()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "MTEXT"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);
                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double IntsPtx = 0.0, IntsPty = 0.0;
                        string layer = "", textstyle = "", Color = "";
                        double height = 0.0, widith = 0.0;
                        int Attachement;
                        MText mtx = new MText();
                        string tx = "";
                        SelectionSet ss = ssPrompt.Value;
                        string sql = @"INSERT INTO dbo.Mtext (IntsPtx,IntsPty,layer,Color,textstyle,height,widith,Text,Attachement,Created)
                                    VALUES(@IntsPtx,@IntsPty,@Layer,@Color,@Textstyle,@Height,@Widith,@Text,@Attachement,@Created)";
                        conn.Open();
                        foreach (SelectedObject sObj in ss)
                        {
                            mtx = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as MText;
                            IntsPtx = mtx.Location.X;
                            IntsPtx = mtx.Location.Y;
                            layer = mtx.Layer;
                            Color = mtx.Color.ToString();
                            textstyle = mtx.TextStyleName;
                            height = mtx.TextHeight;
                            widith = mtx.Width;
                            Attachement = Convert.ToInt32(mtx.Attachment);

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@IntsPtx", IntsPtx);
                            cmd.Parameters.AddWithValue("@IntsPty", IntsPtx);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@Color", Color);
                            cmd.Parameters.AddWithValue("@Textstyle", textstyle);
                            cmd.Parameters.AddWithValue("@Height", height);
                            cmd.Parameters.AddWithValue("@Widith", widith);
                            cmd.Parameters.AddWithValue("@Text", tx);
                            cmd.Parameters.AddWithValue("@Attachement", Attachement);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }


                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }
                    result = "Done Completed Succefully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        //----------------------------------------------------------------
        public string LoadPolylines()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "LWPOLYLINE"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);
                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        string layer = "", ltype = "";
                        string coords = "";
                        double len = 0.0;
                        Polyline pline = new Polyline();
                        bool isclosed = false;
                        SelectionSet ss = ssPrompt.Value;
                        string sql = @"INSERT INTO dbo.Pline (Layer,LineType,Length,Coordinates,Isclosed,Created)
                                    VALUES(@Layer,@LineType,@Length,@Coordinates,@Isclosed,@Created)";
                        conn.Open();
                        foreach (SelectedObject sObj in ss)
                        {
                            pline = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as Polyline;
                            layer = pline.Layer;
                            ltype = pline.Linetype;
                            len = pline.Length;
                            isclosed = pline.Closed;
                            coords = CommonUtil.GetPolylineCoordinates(pline);

                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@LineType", ltype);
                            cmd.Parameters.AddWithValue("@Length", len);
                            cmd.Parameters.AddWithValue("@Coordinates", coords);
                            cmd.Parameters.AddWithValue("@Isclosed", isclosed);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }


                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }
                    result = "Done Completed Succefully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }


        //----------------------------------------------------------------
        public string LoadBlocksNoattribute()
        {
            string result = "";
            SqlConnection conn = DBUtil.GetConnection();
            try
            {
                Document doc = Application.DocumentManager.MdiActiveDocument;
                Editor ed = doc.Editor;
                using (Transaction trans = doc.TransactionManager.StartTransaction())
                {
                    TypedValue[] tv = new TypedValue[1];
                    tv.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0);
                    SelectionFilter filter = new SelectionFilter(tv);
                    PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                    if (ssPrompt.Status == PromptStatus.OK)
                    {
                        double insPtx = 0.0, insPty = 0.0;
                        string blkname = "";
                        string layer = "";
                        double routation = 0.0;
                        BlockReference blk;
                        string insPt = "";
                        SelectionSet ss = ssPrompt.Value;
                        string sql = @"INSERT INTO dbo.BlocksNoAttribute (IntersectionPt,BlockName,Layer,Rotation,Created)
                                    VALUES(@IntersectionPt,@BlockName,@Layer,@Rotation,@Created)";
                        conn.Open();
                        foreach (SelectedObject sObj in ss)
                        {
                            blk = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as BlockReference;
                            if (blk.AttributeCollection.Count == 0 & !blk.Name.Contains("*"))
                            {
                                insPtx = blk.Position.X;
                                insPty = blk.Position.Y;
                                insPt = insPtx.ToString() + "," + insPty.ToString();
                                blkname = blk.Name;
                                layer = blk.Layer;
                                routation = blk.Rotation;

                                SqlCommand cmd = new SqlCommand(sql, conn);
                                cmd.Parameters.AddWithValue("@IntersectionPt", insPt);
                                cmd.Parameters.AddWithValue("@BlockName", blkname);
                                cmd.Parameters.AddWithValue("@Layer", layer);
                                cmd.Parameters.AddWithValue("@Rotation", routation);
                                cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }

                        }


                    }
                    else
                    {
                        ed.WriteMessage("No Object Selected");
                    }
                    result = "Done Completed Succefully";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }
        //----------------------------------------------------------------
        public string LoadBlocksWithattribute()
    {
        string result = "";
        SqlConnection conn = DBUtil.GetConnection();
        try
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            using (Transaction trans = doc.TransactionManager.StartTransaction())
            {
                TypedValue[] tv = new TypedValue[1];
                tv.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0);
                SelectionFilter filter = new SelectionFilter(tv);
                PromptSelectionResult ssPrompt = ed.SelectAll(filter);
                if (ssPrompt.Status == PromptStatus.OK)
                {
                    double insPtx = 0.0, insPty = 0.0;
                    string blkname = "" ;
                    string layer = "" ;
                    double routation = 0.0;
                    BlockReference blk;
                    string insPt = "";
                    string attributes="";
                    SelectionSet ss = ssPrompt.Value;
                    string sql = @"INSERT INTO dbo.BlocksWithAttribute(IntersectionPt,Blockname,Layer,Rotation,Attributes,Created)
                                    VALUES(@IntersectionPt,@Blockname,@Layer,@Rotation,,@Attributes,@Created)";
                    conn.Open();
                    foreach (SelectedObject sObj in ss)
                    {
                        blk = trans.GetObject(sObj.ObjectId, OpenMode.ForRead) as BlockReference;
                        if (blk.AttributeCollection.Count > 0 & !blk.Name.Contains("*"))
                        {
                            insPtx = blk.Position.X;
                            insPty = blk.Position.Y;
                            insPt = insPtx.ToString() + "," + insPty.ToString();
                            blkname = blk.Name;
                            layer = blk.Layer;
                            routation = blk.Rotation;
                                    
                            foreach(ObjectId attRefId in blk.AttributeCollection)
                                {
                                    DBObject obj = trans.GetObject(attRefId, OpenMode.ForRead);
                                    AttributeReference attRef = obj as AttributeReference; 
                                    if(attRef != null)
                                    {
                                        attributes += attRef + "=" + attRef.TextString +",";
                                    }
                                }
                                attributes = attributes.Substring(0, attributes.Length - 1);

                                SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@IntersectionPt", insPt);
                            cmd.Parameters.AddWithValue("@Blockname", blkname);
                            cmd.Parameters.AddWithValue("@Layer", layer);
                            cmd.Parameters.AddWithValue("@Rotation", routation);
                            cmd.Parameters.AddWithValue("@Attributes", attributes);
                            cmd.Parameters.AddWithValue("@Created", DateTime.Now);
                            cmd.ExecuteNonQuery();

                                attributes ="";
                        }

                    }


                }
                else
                {
                    ed.WriteMessage("No Object Selected");
                }
                result = "Done Completed Succefully";
            }
        }
        catch (Exception ex)
        {
            result = ex.Message;

        }
        finally
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        return result;
    }

}
}

