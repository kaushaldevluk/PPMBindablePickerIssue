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
	public class buildingworkorderController : Controller
    	{
        	//private buildingworkorderCtl db = new buildingworkorderCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(buildingworkorderClass Obj_buildingworkorder, string command)
		{
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_buildingworkorder);
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
			
			 return View( Obj_buildingworkorder);
		}
	 }

		

		 public ActionResult Edit(Int32 Workorderid)
		{
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
				 buildingworkorderClass obj_buildingworkorder = db.selectById(Workorderid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_buildingworkorder);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(buildingworkorderClass Obj_buildingworkorder)
		{
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_buildingworkorder);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_buildingworkorder);
		}
		}

		

		 public ActionResult Details(Int32 Workorderid)
		{
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){ buildingworkorderClass obj_buildingworkorder = db.selectById(Workorderid);
				 return View(obj_buildingworkorder);
		}
		}

		

		 public ActionResult Delete(Int32 Workorderid) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 db.delete(Workorderid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Workorderid) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 db.delete(Workorderid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
			 var WorkorderidArray = model.GetValues("item.Workorderid");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var BuildingsystemidArray = model.GetValues("item.Buildingsystemid");
			 var ComponentArray = model.GetValues("item.Component");
			 var DescriptionArray = model.GetValues("item.Description");
			 var PriorityArray = model.GetValues("item.Priority");
			 var RequestorArray = model.GetValues("item.Requestor");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < WorkorderidArray.Length; i++ ) {
				 buildingworkorderClass obj_update = db.selectById(Convert.ToInt32(WorkorderidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkorderidArray)))
					 obj_update.Workorderid = Convert.ToInt32(WorkorderidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemidArray)))
					 obj_update.Buildingsystemid = Convert.ToInt32(BuildingsystemidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ComponentArray)))
					 obj_update.Component = Convert.ToInt32(ComponentArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DescriptionArray)))
					 obj_update.Description = Convert.ToString(DescriptionArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PriorityArray)))
					 obj_update.Priority = Convert.ToString(PriorityArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RequestorArray)))
					 obj_update.Requestor = Convert.ToString(RequestorArray[i]);
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
			 using(buildingworkorderCtl db = new buildingworkorderCtl()){
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
