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
	public class institutiontypeController : Controller
    	{
        	//private institutiontypeCtl db = new institutiontypeCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(institutiontypeClass Obj_institutiontype, string command)
		{
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_institutiontype);
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
			
			 return View( Obj_institutiontype);
		}
	 }

		

		 public ActionResult Edit(Int32 Institutiontypeid)
		{
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){
				 institutiontypeClass obj_institutiontype = db.selectById(Institutiontypeid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_institutiontype);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(institutiontypeClass Obj_institutiontype)
		{
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_institutiontype);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_institutiontype);
		}
		}

		

		 public ActionResult Details(Int32 Institutiontypeid)
		{
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){ institutiontypeClass obj_institutiontype = db.selectById(Institutiontypeid);
				 return View(obj_institutiontype);
		}
		}

		

		 public ActionResult Delete(Int32 Institutiontypeid) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 db.delete(Institutiontypeid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutiontypeCtl db = new institutiontypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutiontypeCtl db = new institutiontypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Institutiontypeid) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 db.delete(Institutiontypeid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutiontypeCtl db = new institutiontypeCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutiontypeCtl db = new institutiontypeCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
			 var InstitutiontypeidArray = model.GetValues("item.Institutiontypeid");
			 var InstitutiontypenameArray = model.GetValues("item.Institutiontypename");
			 for (Int32 i = 0; i < InstitutiontypeidArray.Length; i++ ) {
				 institutiontypeClass obj_update = db.selectById(Convert.ToInt32(InstitutiontypeidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutiontypeidArray)))
					 obj_update.Institutiontypeid = Convert.ToInt32(InstitutiontypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutiontypenameArray)))
					 obj_update.Institutiontypename = Convert.ToString(InstitutiontypenameArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(institutiontypeCtl db = new institutiontypeCtl()){
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
