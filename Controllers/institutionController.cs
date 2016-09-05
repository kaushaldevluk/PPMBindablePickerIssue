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
	public class institutionController : Controller
    	{
        	//private institutionCtl db = new institutionCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(institutionCtl db = new institutionCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(institutionClass Obj_institution, string command)
		{
			
			 using(institutionCtl db = new institutionCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_institution);
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
			
			 return View( Obj_institution);
		}
	 }

		

		 public ActionResult Edit(Int32 Institutionid)
		{
			
			 using(institutionCtl db = new institutionCtl()){
				 institutionClass obj_institution = db.selectById(Institutionid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_institution);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(institutionClass Obj_institution)
		{
			 using(institutionCtl db = new institutionCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_institution);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_institution);
		}
		}

		

		 public ActionResult Details(Int32 Institutionid)
		{
			
			 using(institutionCtl db = new institutionCtl()){ institutionClass obj_institution = db.selectById(Institutionid);
				 return View(obj_institution);
		}
		}

		

		 public ActionResult Delete(Int32 Institutionid) {
			 using(institutionCtl db = new institutionCtl()){
			 db.delete(Institutionid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutionCtl db = new institutionCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutionCtl db = new institutionCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutionCtl db = new institutionCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutionCtl db = new institutionCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutionCtl db = new institutionCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutionCtl db = new institutionCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Institutionid) {
			 using(institutionCtl db = new institutionCtl()){
			 db.delete(Institutionid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(institutionCtl db = new institutionCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(institutionCtl db = new institutionCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(institutionCtl db = new institutionCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(institutionCtl db = new institutionCtl()){
			 var InstitutionidArray = model.GetValues("item.Institutionid");
			 var InstitutioncodeArray = model.GetValues("item.Institutioncode");
			 var InstitutiontypeidArray = model.GetValues("item.Institutiontypeid");
			 var ShortnameArray = model.GetValues("item.Shortname");
			 var LegalnameArray = model.GetValues("item.Legalname");
			 var Addressline1Array = model.GetValues("item.Addressline1");
			 var Addressline2Array = model.GetValues("item.Addressline2");
			 var LocationcityArray = model.GetValues("item.Locationcity");
			 var StateidArray = model.GetValues("item.Stateid");
			 var LocationzipArray = model.GetValues("item.Locationzip");
			 for (Int32 i = 0; i < InstitutionidArray.Length; i++ ) {
				 institutionClass obj_update = db.selectById(Convert.ToInt32(InstitutionidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutionidArray)))
					 obj_update.Institutionid = Convert.ToInt32(InstitutionidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutioncodeArray)))
					 obj_update.Institutioncode = Convert.ToString(InstitutioncodeArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutiontypeidArray)))
					 obj_update.Institutiontypeid = Convert.ToInt32(InstitutiontypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ShortnameArray)))
					 obj_update.Shortname = Convert.ToString(ShortnameArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LegalnameArray)))
					 obj_update.Legalname = Convert.ToString(LegalnameArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(Addressline1Array)))
					 obj_update.Addressline1 = Convert.ToString(Addressline1Array[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(Addressline2Array)))
					 obj_update.Addressline2 = Convert.ToString(Addressline2Array[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationcityArray)))
					 obj_update.Locationcity = Convert.ToString(LocationcityArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(StateidArray)))
					 obj_update.Stateid = Convert.ToInt32(StateidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationzipArray)))
					 obj_update.Locationzip = Convert.ToString(LocationzipArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(institutionCtl db = new institutionCtl()){
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
