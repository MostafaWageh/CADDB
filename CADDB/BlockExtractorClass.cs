using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using System.IO;
using Autodesk.AutoCAD.Internal;

namespace CADDB
{
    public class BlockExtractorClass
    {
        internal void ProcessBlockExtraction(string dwgfile, string blockname, string filename)
        {
           Document doc = Application.DocumentManager.Open(dwgfile);
                   doc.LockDocument();
            Database db = doc.Database;
            Editor edt = doc.Editor;
            edt.WriteMessage("Selecting all the " + blockname + "In the drawing");
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt =trans.GetObject(db.BlockTableId,OpenMode.ForRead) as BlockTable;
                if(!bt.Has(blockname))
                {
                    edt.WriteMessage("No" + blockname + "block found in the drawing");
                    return;
                }
                TypedValue[] tv = new TypedValue[2];
                tv.SetValue(new TypedValue((int)DxfCode.Start, "INSERT"), 0) ;
                tv.SetValue(new TypedValue((int)DxfCode.BlockName, blockname),1);

                //---------Create Filter With this values
                SelectionFilter filter = new SelectionFilter(tv);
                PromptSelectionResult psr = edt.SelectAll(filter);

                //check if ther is object selected
                if(psr.Status == PromptStatus.OK)
                {
                    SelectionSet ss = psr.Value;
                    string aattrVal = "";
                    string header = "";

                    //-----------------------Consrtuct the header by loaping through the list of attribute of ablock
                    StreamWriter writer = new StreamWriter(filename);
                    SelectedObject selobj = ss[0];
                    BlockReference bref = trans.GetObject(selobj.ObjectId,OpenMode.ForWrite)as BlockReference;
                    if( bref.AttributeCollection.Count > 0)
                    {
                        header = "InsertPtx,InsertPty ";
                        foreach(ObjectId attReferenceId in bref.AttributeCollection)
                        {
                            DBObject obj = trans.GetObject(attReferenceId, OpenMode.ForRead);
                            AttributeReference attref = obj as AttributeReference;
                            if(attref != null )
                            {
                                header += attref.Tag + ",";
                            }
                        }
                        //------Wtrite Info
                        writer.WriteLine(header,header.Substring(0,header.Length-1));
                    }
                    foreach(SelectedObject sobj in ss)
                    {
                        BlockReference br =trans.GetObject(sobj.ObjectId,OpenMode.ForWrite) as BlockReference;
                        if(br.AttributeCollection.Count>0)
                        {
                            aattrVal += br.Position.X.ToString() + "," + br.Position.ToString();
                            foreach(ObjectId attReferenceId in br.AttributeCollection)
                               
                            {
                                DBObject obj = trans.GetObject(attReferenceId, OpenMode.ForRead);
                                AttributeReference attrref = obj as AttributeReference;
                                if(attrref != null )
                                {
                                    aattrVal += attrref.TextString + ",";
                                }
                            }
                            writer.WriteLine(aattrVal.Substring(0, aattrVal.Length - 1));
                            aattrVal = "";  
                        }
                    }
                    //Display the Selected
                    edt.WriteMessage("Number of" + blockname + "Found is " + ss.Count.ToString());
                    writer.Close();
                }
                else
                {
                    edt.WriteMessage("There is no Blouk found.");
                }
               
            }
            doc.CloseAndDiscard();
        }
    }
}
