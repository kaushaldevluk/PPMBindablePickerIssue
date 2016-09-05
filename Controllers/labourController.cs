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
	public class labourController : Controller
    	{
        	//private labourCtl db = new labourCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(labourCtl db = new labourCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(labourClass Obj_labour, string command)
		{
			
			 using(labourCtl db = new labourCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_labour);
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
			
			 return View( Obj_labour);
		}
	 }

		

		 public ActionResult Edit(Int32 Labourid)
		{
			
			 using(labourCtl db = new labourCtl()){
				 labourClass obj_labour = db.selectById(Labourid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_labour);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(labourClass Obj_labour)
		{
			 using(labourCtl db = new labourCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_labour);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_labour);
		}
		}

		

		 public ActionResult Details(Int32 Labourid)
		{
			
			 using(labourCtl db = new labourCtl()){ labourClass obj_labour = db.selectById(Labourid);
				 return View(obj_labour);
		}
		}

		

		 public ActionResult Delete(Int32 Labourid) {
			 using(labourCtl db = new labourCtl()){
			 db.delete(Labourid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(labourCtl db = new labourCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(labourCtl db = new labourCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(labourCtl db = new labourCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(labourCtl db = new labourCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(labourCtl db = new labourCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(labourCtl db = new labourCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Labourid) {
			 using(labourCtl db = new labourCtl()){
			 db.delete(Labourid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(labourCtl db = new labourCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(labourCtl db = new labourCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(labourCtl db = new labourCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(labourCtl db = new labourCtl()){
			 var LabouridArray = model.GetValues("item.Labourid");
			 var LabournameArray = model.GetValues("item.Labourname");
			 for (Int32 i = 0; i < LabouridArray.Length; i++ ) {
				 labourClass obj_update = db.selectById(Convert.ToInt32(LabouridArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(LabouridArray)))
					 obj_update.Labourid = Convert.ToInt32(LabouridArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LabournameArray)))
					 obj_update.Labourname = Convert.ToString(LabournameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(labourCtl db = new labourCtl()){
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
