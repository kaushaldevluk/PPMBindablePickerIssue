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
	public class locationController : Controller
    	{
        	//private locationCtl db = new locationCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(locationCtl db = new locationCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(locationClass Obj_location, string command)
		{
			
			 using(locationCtl db = new locationCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_location);
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
			
			 return View( Obj_location);
		}
	 }

		

		 public ActionResult Edit(Int32 Locationid)
		{
			
			 using(locationCtl db = new locationCtl()){
				 locationClass obj_location = db.selectById(Locationid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_location);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(locationClass Obj_location)
		{
			 using(locationCtl db = new locationCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_location);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_location);
		}
		}

		

		 public ActionResult Details(Int32 Locationid)
		{
			
			 using(locationCtl db = new locationCtl()){ locationClass obj_location = db.selectById(Locationid);
				 return View(obj_location);
		}
		}

		

		 public ActionResult Delete(Int32 Locationid) {
			 using(locationCtl db = new locationCtl()){
			 db.delete(Locationid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationCtl db = new locationCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationCtl db = new locationCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationCtl db = new locationCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationCtl db = new locationCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationCtl db = new locationCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationCtl db = new locationCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Locationid) {
			 using(locationCtl db = new locationCtl()){
			 db.delete(Locationid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationCtl db = new locationCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationCtl db = new locationCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationCtl db = new locationCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(locationCtl db = new locationCtl()){
			 var LocationidArray = model.GetValues("item.Locationid");
			 var ClientidArray = model.GetValues("item.Clientid");
			 var InstitutionidArray = model.GetValues("item.Institutionid");
			 var BuildingArray = model.GetValues("item.Building");
			 var JobtypeidArray = model.GetValues("item.Jobtypeid");
			 var JobstatusidArray = model.GetValues("item.Jobstatusid");
			 var JobdetailArray = model.GetValues("item.Jobdetail");
			 for (Int32 i = 0; i < LocationidArray.Length; i++ ) {
				 locationClass obj_update = db.selectById(Convert.ToInt32(LocationidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationidArray)))
					 obj_update.Locationid = Convert.ToInt32(LocationidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ClientidArray)))
					 obj_update.Clientid = Convert.ToInt32(ClientidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InstitutionidArray)))
					 obj_update.Institutionid = Convert.ToInt32(InstitutionidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingArray)))
					 obj_update.Building = Convert.ToString(BuildingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(JobtypeidArray)))
					 obj_update.Jobtypeid = Convert.ToInt32(JobtypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(JobstatusidArray)))
					 obj_update.Jobstatusid = Convert.ToInt32(JobstatusidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(JobdetailArray)))
					 obj_update.Jobdetail = Convert.ToString(JobdetailArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(locationCtl db = new locationCtl()){
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
