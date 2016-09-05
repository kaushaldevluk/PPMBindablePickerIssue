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
	public class projectController : Controller
    	{
        	//private projectCtl db = new projectCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(projectCtl db = new projectCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(projectClass Obj_project, string command)
		{
			
			 using(projectCtl db = new projectCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_project);
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
			
			 return View( Obj_project);
		}
	 }

		

		 public ActionResult Edit(Int32 Projectid)
		{
			
			 using(projectCtl db = new projectCtl()){
				 projectClass obj_project = db.selectById(Projectid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_project);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(projectClass Obj_project)
		{
			 using(projectCtl db = new projectCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_project);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_project);
		}
		}

		

		 public ActionResult Details(Int32 Projectid)
		{
			
			 using(projectCtl db = new projectCtl()){ projectClass obj_project = db.selectById(Projectid);
				 return View(obj_project);
		}
		}

		

		 public ActionResult Delete(Int32 Projectid) {
			 using(projectCtl db = new projectCtl()){
			 db.delete(Projectid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(projectCtl db = new projectCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(projectCtl db = new projectCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(projectCtl db = new projectCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(projectCtl db = new projectCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(projectCtl db = new projectCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(projectCtl db = new projectCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Projectid) {
			 using(projectCtl db = new projectCtl()){
			 db.delete(Projectid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(projectCtl db = new projectCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(projectCtl db = new projectCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(projectCtl db = new projectCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(projectCtl db = new projectCtl()){
			 var ProjectidArray = model.GetValues("item.Projectid");
			 var BuildingsystemidArray = model.GetValues("item.Buildingsystemid");
			 var ProjectnameArray = model.GetValues("item.Projectname");
			 for (Int32 i = 0; i < ProjectidArray.Length; i++ ) {
				 projectClass obj_update = db.selectById(Convert.ToInt32(ProjectidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ProjectidArray)))
					 obj_update.Projectid = Convert.ToInt32(ProjectidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemidArray)))
					 obj_update.Buildingsystemid = Convert.ToInt32(BuildingsystemidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ProjectnameArray)))
					 obj_update.Projectname = Convert.ToString(ProjectnameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(projectCtl db = new projectCtl()){
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
