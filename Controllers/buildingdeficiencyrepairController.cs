using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using ppmapp.Models;
using System.Net;
using DB_con;
using System.Web.Services;


namespace ppmapp.Controllers
{
	public class buildingdeficiencyrepairController : Controller
    	{
        	//private buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(buildingdeficiencyrepairClass Obj_buildingdeficiencyrepair, string command)
		{
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_buildingdeficiencyrepair);
					 if (command.ToLower().Trim() == "save"){
						 string sesionval = Convert.ToString(Session["CreatePreviousURL"]);
						 if (!string.IsNullOrEmpty(sesionval)){
							 Session.Remove("CreatePreviousURL");
							 return Redirect(sesionval); 
						 } else
							 return RedirectToAction("Index"); 
					 }else {
						 ModelState.Clear();
						 return View(); 
					 }
				 }
			
			 return View( Obj_buildingdeficiencyrepair);
		}
	 }

		

		 public ActionResult Edit(Int32 Buildingdeficiencyrepairid)
		{
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
				 buildingdeficiencyrepairClass obj_buildingdeficiencyrepair = db.selectById(Buildingdeficiencyrepairid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_buildingdeficiencyrepair);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(buildingdeficiencyrepairClass Obj_buildingdeficiencyrepair)
		{
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_buildingdeficiencyrepair);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_buildingdeficiencyrepair);
		}
		}

		

		 public ActionResult Details(Int32 Buildingdeficiencyrepairid)
		{
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){ buildingdeficiencyrepairClass obj_buildingdeficiencyrepair = db.selectById(Buildingdeficiencyrepairid);
				 return View(obj_buildingdeficiencyrepair);
		}
		}

		

		 public ActionResult Delete(Int32 Buildingdeficiencyrepairid) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 db.delete(Buildingdeficiencyrepairid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Buildingdeficiencyrepairid) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 db.delete(Buildingdeficiencyrepairid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
			 var BuildingdeficiencyrepairidArray = model.GetValues("item.Buildingdeficiencyrepairid");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var DescriptionArray = model.GetValues("item.Description");
			 var QuantityArray = model.GetValues("item.Quantity");
			 var UnitsArray = model.GetValues("item.Units");
			 var PriorityArray = model.GetValues("item.Priority");
			 var NoteArray = model.GetValues("item.Note");
			 var NoteaudioArray = model.GetValues("item.Noteaudio");
			 var WorkareanoArray = model.GetValues("item.Workareano");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < BuildingdeficiencyrepairidArray.Length; i++ ) {
				 buildingdeficiencyrepairClass obj_update = db.selectById(Convert.ToInt32(BuildingdeficiencyrepairidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingdeficiencyrepairidArray)))
					 obj_update.Buildingdeficiencyrepairid = Convert.ToInt32(BuildingdeficiencyrepairidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DescriptionArray)))
					 obj_update.Description = Convert.ToString(DescriptionArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(QuantityArray)))
					 obj_update.Quantity = Convert.ToInt32(QuantityArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(UnitsArray)))
					 obj_update.Units = Convert.ToInt32(UnitsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PriorityArray)))
					 obj_update.Priority = Convert.ToString(PriorityArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoteArray)))
					 obj_update.Note = Convert.ToString(NoteArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoteaudioArray)))
					 obj_update.Noteaudio = Convert.To(NoteaudioArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkareanoArray)))
					 obj_update.Workareano = Convert.ToInt32(WorkareanoArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(UseridArray)))
					 obj_update.Userid = Convert.ToInt32(UseridArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InserteddatetimeArray)))
					 obj_update.Inserteddatetime = Convert.ToDateTime(InserteddatetimeArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(buildingdeficiencyrepairCtl db = new buildingdeficiencyrepairCtl()){
		 foreach(string id in records.Trim(',').Split(',')  ){
			 if(!string.IsNullOrEmpty(id.Trim())){
				 db.delete(Convert.ToInt32(id));
			 }
		 }
		 return View();
		}
	 } 
		//{ActionResultMethod}
		

	         

	}

}
