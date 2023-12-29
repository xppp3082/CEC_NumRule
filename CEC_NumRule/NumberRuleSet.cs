#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.DB.Structure;
using System.Windows.Forms;
using System.Threading;
#endregion

namespace CEC_NumRule
{
    [Transaction(TransactionMode.Manual)]
    public class NumberRuleSet : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Autodesk.Revit.DB.View activeView = doc.ActiveView;
            method m = new method();

            ////抓到管類型進行設定
            //List<customSystem> pipeSystemLst = new List<customSystem>();
            ////FilteredElementCollector pipeSystemCollector
            //List<Element> pipeSystemCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipingSystem).WhereElementIsElementType().OrderBy(x=>x.Name).ToList();
            //MessageBox.Show(pipeSystemCollector.Count().ToString());
            //foreach(Element e in pipeSystemCollector)
            //{
            //    customSystem tempSystem = new customSystem()
            //    {
            //        systemType = e,
            //        systemName = e.Name,
            //        targetSystemName=""//改成先從entity抓
            //    };
            //    pipeSystemLst.Add(tempSystem);
            //}
            ////抓到風管類型進行設定
            //List<customSystem> ductSystemLst = new List<customSystem>();
            //List<Element> ductSystemCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DuctSystem).WhereElementIsElementType().OrderBy(x => x.Name).ToList();
            //foreach(Element e in ductSystemCollector)
            //{
            //    customSystem tempSystem = new customSystem()
            //    {
            //        systemType = e,
            //        systemName = e.Name,
            //        targetSystemName = ""//改成先從entity抓
            //    };
            //    ductSystemLst.Add(tempSystem);
            //}
            ////抓到電管類型進行設定
            //List<customSystem> conduitTypeLst = new List<customSystem>();
            //List<Element> conduitSystemCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsElementType().OrderBy(x => x.Name).ToList();
            //foreach (Element e in conduitSystemCollector)
            //{
            //    customSystem tempSystem = new customSystem()
            //    {
            //        systemType = e,
            //        systemName = e.Name,
            //        targetSystemName = ""//改成先從entity抓
            //    };
            //    conduitTypeLst.Add(tempSystem);
            //}
            ////抓到電纜架類型進行設定
            //List<customSystem> cableTrayLst = new List<customSystem>();
            //List<Element> cableTrayCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsElementType().OrderBy(x => x.Name).ToList();
            //foreach (Element e in conduitSystemCollector)
            //{
            //    customSystem tempSystem = new customSystem()
            //    {
            //        systemType = e,
            //        systemName = e.Name,
            //        targetSystemName = ""//改成先從entity抓
            //    };
            //    cableTrayLst.Add(tempSystem);
            //}
            
            

            RuleSetting ruleUI = new RuleSetting(doc);
            ruleUI.pipeGrid.ItemsSource = m.GetCustomSystems(doc,BuiltInCategory.OST_PipingSystem);
            ruleUI.ductGrid.ItemsSource = m.GetCustomSystems(doc, BuiltInCategory.OST_DuctSystem);
            ruleUI.conduitGrid.ItemsSource = m.GetCustomSystems(doc, BuiltInCategory.OST_Conduit);
            ruleUI.trayGrid.ItemsSource = m.GetCustomSystems(doc, BuiltInCategory.OST_CableTray);
            //ruleUI.ductGrid.ItemsSource = ductSystemLst;
            //ruleUI.conduitGrid.ItemsSource = conduitTypeLst;
            //ruleUI.trayGrid.ItemsSource = cableTrayLst;
            ruleUI.ShowDialog();



            return Result.Succeeded;
        }
    }
}
