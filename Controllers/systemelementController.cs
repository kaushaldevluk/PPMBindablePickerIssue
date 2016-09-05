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
	public class systemelementController : Controller
    	{
        	//private systemelementCtl db = new systemelementCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(systemelementCtl db = new systemelementCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(systemelementClass Obj_systemelement, string command)
		{
			
			 using(systemelementCtl db = new systemelementCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_systemelement);
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
			
			 return View( Obj_systemelement);
		}
	 }

		

		 public ActionResult Edit(Int32 Systemelementid)
		{
			
			 using(systemelementCtl db = new systemelementCtl()){
				 systemelementClass obj_systemelement = db.selectById(Systemelementid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_systemelement);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(systemelementClass Obj_systemelement)
		{
			 using(systemelementCtl db = new systemelementCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_systemelement);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_systemelement);
		}
		}

		

		 public ActionResult Details(Int32 Systemelementid)
		{
			
			 using(systemelementCtl db = new systemelementCtl()){ systemelementClass obj_systemelement = db.selectById(Systemelementid);
				 return View(obj_systemelement);
		}
		}

		

		 public ActionResult Delete(Int32 Systemelementid) {
			 using(systemelementCtl db = new systemelementCtl()){
			 db.delete(Systemelementid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemelementCtl db = new systemelementCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemelementCtl db = new systemelementCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemelementCtl db = new systemelementCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemelementCtl db = new systemelementCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemelementCtl db = new systemelementCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemelementCtl db = new systemelementCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Systemelementid) {
			 using(systemelementCtl db = new systemelementCtl()){
			 db.delete(Systemelementid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(systemelementCtl db = new systemelementCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(systemelementCtl db = new systemelementCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(systemelementCtl db = new systemelementCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(systemelementCtl db = new systemelementCtl()){
			 var SystemelementidArray = model.GetValues("item.Systemelementid");
			 var BuildingsystemidArray = model.GetValues("item.Buildingsystemid");
			 var SystemelementnameArray = model.GetValues("item.Systemelementname");
			 for (Int32 i = 0; i < SystemelementidArray.Length; i++ ) {
				 systemelementClass obj_update = db.selectById(Convert.ToInt32(SystemelementidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementidArray)))
					 obj_update.Systemelementid = Convert.ToInt32(SystemelementidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemidArray)))
					 obj_update.Buildingsystemid = Convert.ToInt32(BuildingsystemidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementnameArray)))
					 obj_update.Systemelementname = Convert.ToString(SystemelementnameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(systemelementCtl db = new systemelementCtl()){
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
