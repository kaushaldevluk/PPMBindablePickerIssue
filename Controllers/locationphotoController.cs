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
	public class locationphotoController : Controller
    	{
        	//private locationphotoCtl db = new locationphotoCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(locationphotoCtl db = new locationphotoCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(locationphotoClass Obj_locationphoto, string command)
		{
			
			 using(locationphotoCtl db = new locationphotoCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_locationphoto);
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
			
			 return View( Obj_locationphoto);
		}
	 }

		

		 public ActionResult Edit(Int32 Locationphotoid)
		{
			
			 using(locationphotoCtl db = new locationphotoCtl()){
				 locationphotoClass obj_locationphoto = db.selectById(Locationphotoid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_locationphoto);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(locationphotoClass Obj_locationphoto)
		{
			 using(locationphotoCtl db = new locationphotoCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_locationphoto);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_locationphoto);
		}
		}

		

		 public ActionResult Details(Int32 Locationphotoid)
		{
			
			 using(locationphotoCtl db = new locationphotoCtl()){ locationphotoClass obj_locationphoto = db.selectById(Locationphotoid);
				 return View(obj_locationphoto);
		}
		}

		

		 public ActionResult Delete(Int32 Locationphotoid) {
			 using(locationphotoCtl db = new locationphotoCtl()){
			 db.delete(Locationphotoid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationphotoCtl db = new locationphotoCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationphotoCtl db = new locationphotoCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationphotoCtl db = new locationphotoCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationphotoCtl db = new locationphotoCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationphotoCtl db = new locationphotoCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationphotoCtl db = new locationphotoCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Locationphotoid) {
			 using(locationphotoCtl db = new locationphotoCtl()){
			 db.delete(Locationphotoid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(locationphotoCtl db = new locationphotoCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(locationphotoCtl db = new locationphotoCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(locationphotoCtl db = new locationphotoCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(locationphotoCtl db = new locationphotoCtl()){
			 var LocationphotoidArray = model.GetValues("item.Locationphotoid");
			 var PhotoArray = model.GetValues("item.Photo");
			 var LocationidArray = model.GetValues("item.Locationid");
			 var PhotodescriptionArray = model.GetValues("item.Photodescription");
			 var PhotouploadeddateArray = model.GetValues("item.Photouploadeddate");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var BuildingdeficiencyrepairidArray = model.GetValues("item.Buildingdeficiencyrepairid");
			 var BuildingworkorderidArray = model.GetValues("item.Buildingworkorderid");
			 var WorkorderfollowupidArray = model.GetValues("item.Workorderfollowupid");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < LocationphotoidArray.Length; i++ ) {
				 locationphotoClass obj_update = db.selectById(Convert.ToInt32(LocationphotoidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationphotoidArray)))
					 obj_update.Locationphotoid = Convert.ToInt32(LocationphotoidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PhotoArray)))
					 obj_update.Photo = Convert.To(PhotoArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationidArray)))
					 obj_update.Locationid = Convert.ToInt32(LocationidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PhotodescriptionArray)))
					 obj_update.Photodescription = Convert.ToString(PhotodescriptionArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PhotouploadeddateArray)))
					 obj_update.Photouploadeddate = Convert.ToDateTime(PhotouploadeddateArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingdeficiencyrepairidArray)))
					 obj_update.Buildingdeficiencyrepairid = Convert.ToInt32(BuildingdeficiencyrepairidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingworkorderidArray)))
					 obj_update.Buildingworkorderid = Convert.ToInt32(BuildingworkorderidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkorderfollowupidArray)))
					 obj_update.Workorderfollowupid = Convert.ToInt32(WorkorderfollowupidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(UseridArray)))
					 obj_update.Userid = Convert.ToInt32(UseridArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InserteddatetimeArray)))
					 obj_update.Inserteddatetime = Convert.ToDateTime(InserteddatetimeArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(locationphotoCtl db = new locationphotoCtl()){
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
