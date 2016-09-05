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
	public class buildingsystemController : Controller
    	{
        	//private buildingsystemCtl db = new buildingsystemCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(buildingsystemClass Obj_buildingsystem, string command)
		{
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_buildingsystem);
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
			
			 return View( Obj_buildingsystem);
		}
	 }

		

		 public ActionResult Edit(Int32 Buildingsystemid)
		{
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){
				 buildingsystemClass obj_buildingsystem = db.selectById(Buildingsystemid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_buildingsystem);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(buildingsystemClass Obj_buildingsystem)
		{
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_buildingsystem);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_buildingsystem);
		}
		}

		

		 public ActionResult Details(Int32 Buildingsystemid)
		{
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){ buildingsystemClass obj_buildingsystem = db.selectById(Buildingsystemid);
				 return View(obj_buildingsystem);
		}
		}

		

		 public ActionResult Delete(Int32 Buildingsystemid) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 db.delete(Buildingsystemid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingsystemCtl db = new buildingsystemCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingsystemCtl db = new buildingsystemCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Buildingsystemid) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 db.delete(Buildingsystemid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingsystemCtl db = new buildingsystemCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingsystemCtl db = new buildingsystemCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
			 var BuildingsystemidArray = model.GetValues("item.Buildingsystemid");
			 var BuildingsystemnameArray = model.GetValues("item.Buildingsystemname");
			 for (Int32 i = 0; i < BuildingsystemidArray.Length; i++ ) {
				 buildingsystemClass obj_update = db.selectById(Convert.ToInt32(BuildingsystemidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemidArray)))
					 obj_update.Buildingsystemid = Convert.ToInt32(BuildingsystemidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemnameArray)))
					 obj_update.Buildingsystemname = Convert.ToString(BuildingsystemnameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(buildingsystemCtl db = new buildingsystemCtl()){
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
