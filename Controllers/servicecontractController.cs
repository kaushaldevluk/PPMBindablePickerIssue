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
	public class servicecontractController : Controller
    	{
        	//private servicecontractCtl db = new servicecontractCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(servicecontractCtl db = new servicecontractCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(servicecontractClass Obj_servicecontract, string command)
		{
			
			 using(servicecontractCtl db = new servicecontractCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_servicecontract);
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
			
			 return View( Obj_servicecontract);
		}
	 }

		

		 public ActionResult Edit(Int32 Servicecontractid)
		{
			
			 using(servicecontractCtl db = new servicecontractCtl()){
				 servicecontractClass obj_servicecontract = db.selectById(Servicecontractid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_servicecontract);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(servicecontractClass Obj_servicecontract)
		{
			 using(servicecontractCtl db = new servicecontractCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_servicecontract);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_servicecontract);
		}
		}

		

		 public ActionResult Details(Int32 Servicecontractid)
		{
			
			 using(servicecontractCtl db = new servicecontractCtl()){ servicecontractClass obj_servicecontract = db.selectById(Servicecontractid);
				 return View(obj_servicecontract);
		}
		}

		

		 public ActionResult Delete(Int32 Servicecontractid) {
			 using(servicecontractCtl db = new servicecontractCtl()){
			 db.delete(Servicecontractid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(servicecontractCtl db = new servicecontractCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(servicecontractCtl db = new servicecontractCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(servicecontractCtl db = new servicecontractCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(servicecontractCtl db = new servicecontractCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(servicecontractCtl db = new servicecontractCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(servicecontractCtl db = new servicecontractCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Servicecontractid) {
			 using(servicecontractCtl db = new servicecontractCtl()){
			 db.delete(Servicecontractid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(servicecontractCtl db = new servicecontractCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(servicecontractCtl db = new servicecontractCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(servicecontractCtl db = new servicecontractCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(servicecontractCtl db = new servicecontractCtl()){
			 var ServicecontractidArray = model.GetValues("item.Servicecontractid");
			 var ProjectidArray = model.GetValues("item.Projectid");
			 var ServicecontractnameArray = model.GetValues("item.Servicecontractname");
			 for (Int32 i = 0; i < ServicecontractidArray.Length; i++ ) {
				 servicecontractClass obj_update = db.selectById(Convert.ToInt32(ServicecontractidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ServicecontractidArray)))
					 obj_update.Servicecontractid = Convert.ToInt32(ServicecontractidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ProjectidArray)))
					 obj_update.Projectid = Convert.ToInt32(ProjectidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ServicecontractnameArray)))
					 obj_update.Servicecontractname = Convert.ToString(ServicecontractnameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(servicecontractCtl db = new servicecontractCtl()){
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
