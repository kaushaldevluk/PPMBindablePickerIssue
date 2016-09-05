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
	public class jobtypeController : Controller
    	{
        	//private jobtypeCtl db = new jobtypeCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(jobtypeCtl db = new jobtypeCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(jobtypeClass Obj_jobtype, string command)
		{
			
			 using(jobtypeCtl db = new jobtypeCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_jobtype);
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
			
			 return View( Obj_jobtype);
		}
	 }

		

		 public ActionResult Edit(Int32 Jobtypeid)
		{
			
			 using(jobtypeCtl db = new jobtypeCtl()){
				 jobtypeClass obj_jobtype = db.selectById(Jobtypeid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_jobtype);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(jobtypeClass Obj_jobtype)
		{
			 using(jobtypeCtl db = new jobtypeCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_jobtype);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_jobtype);
		}
		}

		

		 public ActionResult Details(Int32 Jobtypeid)
		{
			
			 using(jobtypeCtl db = new jobtypeCtl()){ jobtypeClass obj_jobtype = db.selectById(Jobtypeid);
				 return View(obj_jobtype);
		}
		}

		

		 public ActionResult Delete(Int32 Jobtypeid) {
			 using(jobtypeCtl db = new jobtypeCtl()){
			 db.delete(Jobtypeid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobtypeCtl db = new jobtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobtypeCtl db = new jobtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobtypeCtl db = new jobtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobtypeCtl db = new jobtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobtypeCtl db = new jobtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobtypeCtl db = new jobtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Jobtypeid) {
			 using(jobtypeCtl db = new jobtypeCtl()){
			 db.delete(Jobtypeid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(jobtypeCtl db = new jobtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(jobtypeCtl db = new jobtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(jobtypeCtl db = new jobtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(jobtypeCtl db = new jobtypeCtl()){
			 var JobtypeidArray = model.GetValues("item.Jobtypeid");
			 var JobtypeArray = model.GetValues("item.Jobtype");
			 for (Int32 i = 0; i < JobtypeidArray.Length; i++ ) {
				 jobtypeClass obj_update = db.selectById(Convert.ToInt32(JobtypeidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(JobtypeidArray)))
					 obj_update.Jobtypeid = Convert.ToInt32(JobtypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(JobtypeArray)))
					 obj_update.Jobtype = Convert.ToString(JobtypeArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(jobtypeCtl db = new jobtypeCtl()){
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
