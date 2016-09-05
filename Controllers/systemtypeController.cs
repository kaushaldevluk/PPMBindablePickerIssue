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
	public class systemtypeController : Controller
    	{
        	//private systemtypeCtl db = new systemtypeCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(systemtypeCtl db = new systemtypeCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(systemtypeClass Obj_systemtype, string command)
		{
			
			 using(systemtypeCtl db = new systemtypeCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_systemtype);
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
			
			 return View( Obj_systemtype);
		}
	 }

		

		 public ActionResult Edit(Int32 Systemelementtypeid)
		{
			
			 using(systemtypeCtl db = new systemtypeCtl()){
				 systemtypeClass obj_systemtype = db.selectById(Systemelementtypeid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_systemtype);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(systemtypeClass Obj_systemtype)
		{
			 using(systemtypeCtl db = new systemtypeCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_systemtype);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_systemtype);
		}
		}

		

		 public ActionResult Details(Int32 Systemelementtypeid)
		{
			
			 using(systemtypeCtl db = new systemtypeCtl()){ systemtypeClass obj_systemtype = db.selectById(Systemelementtypeid);
				 return View(obj_systemtype);
		}
		}

		

		 public ActionResult Delete(Int32 Systemelementtypeid) {
			 using(systemtypeCtl db = new systemtypeCtl()){
			 db.delete(Systemelementtypeid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemtypeCtl db = new systemtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemtypeCtl db = new systemtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemtypeCtl db = new systemtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemtypeCtl db = new systemtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemtypeCtl db = new systemtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemtypeCtl db = new systemtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Systemelementtypeid) {
			 using(systemtypeCtl db = new systemtypeCtl()){
			 db.delete(Systemelementtypeid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemtypeCtl db = new systemtypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemtypeCtl db = new systemtypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemtypeCtl db = new systemtypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(systemtypeCtl db = new systemtypeCtl()){
			 var SystemelementtypeidArray = model.GetValues("item.Systemelementtypeid");
			 var SystemelementidArray = model.GetValues("item.Systemelementid");
			 var SystemelementtypenameArray = model.GetValues("item.Systemelementtypename");
			 for (Int32 i = 0; i < SystemelementtypeidArray.Length; i++ ) {
				 systemtypeClass obj_update = db.selectById(Convert.ToInt32(SystemelementtypeidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementtypeidArray)))
					 obj_update.Systemelementtypeid = Convert.ToInt32(SystemelementtypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementidArray)))
					 obj_update.Systemelementid = Convert.ToInt32(SystemelementidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementtypenameArray)))
					 obj_update.Systemelementtypename = Convert.ToString(SystemelementtypenameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(systemtypeCtl db = new systemtypeCtl()){
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
