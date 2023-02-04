using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Autodesk.Revit.DB.Structure;


namespace FirstProject
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            #region Step-4
            //Reference r = uidoc.Selection.PickObject(ObjectType.Element);
            //Element e = doc.GetElement(r.ElementId);
            //Wall wall = e as Wall;

            //TaskDialog.Show("알림", wall.Name);
            #endregion

            #region Step-5

            //IList<Reference> rf = uidoc.Selection.PickObjects(ObjectType.Element);
            //List<Wall> dfdf = new List<Wall>();
            //foreach (Reference item in rf)
            //{
            //    Element wall = doc.GetElement(item.ElementId);
            //    Wall w = wall as Wall;
            //    dfdf.Add(w);
            //}

            //List<string> strs = new List<string>();
            //for (int i = 0; i < rf.Count; i++)
            //{
            //    string name = dfdf[i].Name;
            //    strs.Add(name);
            //}

            //foreach (string item in strs)
            //{
            //    TaskDialog.Show("벽체의 이름은 : ", item + "입니다.");
            //}

            #endregion

            #region Step-6
            //public FamilyInstance NewFamilyInstance(Curve curve,FamilySymbol symbol,Level level, StructuralType structuralType)

            XYZ p1 = new XYZ(0, 0, 0);
            XYZ p2 = new XYZ(1000, 0, 0)/304.8;
            Line line = Line.CreateBound(p1, p2);

            FilteredElementCollector col = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol));
            FamilySymbol fs = null;
            foreach (FamilySymbol item in col)
            {
                if(item.Name == "G1")
                {
                    fs = item;  
                }
            }

            Level leve = doc.ActiveView.GenLevel;
            StructuralType f = StructuralType.Beam;

            Transaction trans = new Transaction(doc, "Create");
            trans.Start();
            fs.Activate();
            FamilyInstance ffs = doc.Create.NewFamilyInstance(line, fs, leve, f);
            trans.Commit();


            #endregion



            return Result.Succeeded;
        }
    }
}
