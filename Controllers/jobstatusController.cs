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
	public class jobstatusController : Controller
    	{
        	//private jobstatusCtl db = new jobstatusCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(jobstatusCtl db = new jobstatusCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(jobstatusClass Obj_jobstatus, string command)
		{
			
			 using(jobstatusCtl db = new jobstatusCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_jobstatus);
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
			
			 return View( Obj_jobstatus);
		}
	 }

		

		 public ActionResult Edit(Int32 Jobstatusid)
		{
			
			 using(jobstatusCtl db = new jobstatusCtl()){
				 jobstatusClass obj_jobstatus = db.selectById(Jobstatusid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_jobstatus);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(jobstatusClass Obj_jobstatus)
		{
			 using(jobstatusCtl db = new jobstatusCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_jobstatus);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_jobstatus);
		}
		}

		

		 public ActionResult Details(Int32 Jobstatusid)
		{
			
			 using(jobstatusCtl db = new jobstatusCtl()){ jobstatusClass obj_jobstatus = db.selectById(Jobstatusid);
				 return View(obj_jobstatus);
		}
		}

		

		 public ActionResult Delete(Int32 Jobstatusid) {
			 using(jobstatusCtl db = new jobstatusCtl()){
			 db.delete(Jobstatusid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobstatusCtl db = new jobstatusCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobstatusCtl db = new jobstatusCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobstatusCtl db = new jobstatusCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobstatusCtl db = new jobstatusCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobstatusCtl db = new jobstatusCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobstatusCtl db = new jobstatusCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Jobstatusid) {
			 using(jobstatusCtl db = new jobstatusCtl()){
			 db.delete(Jobstatusid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobstatusCtl db = new jobstatusCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobstatusCtl db = new jobstatusCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobstatusCtl db = new jobstatusCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(jobstatusCtl db = new jobstatusCtl()){
			 var JobstatusidArray = model.GetValues("item.Jobstatusid");
			 var StatusnameArray = model.GetValues("item.Statusname");
			 for (Int32 i = 0; i < JobstatusidArray.Length; i++ ) {
				 jobstatusClass obj_update = db.selectById(Convert.ToInt32(JobstatusidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(JobstatusidArray)))
					 obj_update.Jobstatusid = Convert.ToInt32(JobstatusidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(StatusnameArray)))
					 obj_update.Statusname = Convert.ToString(StatusnameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(jobstatusCtl db = new jobstatusCtl()){
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
