using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;


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
        
            Reference r = uidoc.Selection.PickObject(ObjectType.Element);
            Element e = doc.GetElement(r.ElementId);
            Wall wall = e as Wall;

            TaskDialog.Show("¾Ë¸²", wall.Name);

            return Result.Succeeded;
        }
    }
}
