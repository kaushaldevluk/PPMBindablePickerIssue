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
	public class buildingController : Controller
    	{
        	//private buildingCtl db = new buildingCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(buildingCtl db = new buildingCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(buildingClass Obj_building, string command)
		{
			
			 using(buildingCtl db = new buildingCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_building);
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
			
			 return View( Obj_building);
		}
	 }

		

		 public ActionResult Edit(Int32 Buildingid)
		{
			
			 using(buildingCtl db = new buildingCtl()){
				 buildingClass obj_building = db.selectById(Buildingid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_building);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(buildingClass Obj_building)
		{
			 using(buildingCtl db = new buildingCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_building);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_building);
		}
		}

		

		 public ActionResult Details(Int32 Buildingid)
		{
			
			 using(buildingCtl db = new buildingCtl()){ buildingClass obj_building = db.selectById(Buildingid);
				 return View(obj_building);
		}
		}

		

		 public ActionResult Delete(Int32 Buildingid) {
			 using(buildingCtl db = new buildingCtl()){
			 db.delete(Buildingid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingCtl db = new buildingCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingCtl db = new buildingCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingCtl db = new buildingCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingCtl db = new buildingCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingCtl db = new buildingCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingCtl db = new buildingCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Buildingid) {
			 using(buildingCtl db = new buildingCtl()){
			 db.delete(Buildingid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(buildingCtl db = new buildingCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(buildingCtl db = new buildingCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(buildingCtl db = new buildingCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(buildingCtl db = new buildingCtl()){
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var LocationidArray = model.GetValues("item.Locationid");
			 var BuildingcodeArray = model.GetValues("item.Buildingcode");
			 var BuildingsystemidArray = model.GetValues("item.Buildingsystemid");
			 var SystemelementidArray = model.GetValues("item.Systemelementid");
			 var SystemtypeidArray = model.GetValues("item.Systemtypeid");
			 var RatingArray = model.GetValues("item.Rating");
			 var DetailsArray = model.GetValues("item.Details");
			 var IsdeficiencyrepairArray = model.GetValues("item.Isdeficiencyrepair");
			 var ProjectidArray = model.GetValues("item.Projectid");
			 var ServicecontractidArray = model.GetValues("item.Servicecontractid");
			 var WorkorderArray = model.GetValues("item.Workorder");
			 var ComplianceArray = model.GetValues("item.Compliance");
			 var HeightArray = model.GetValues("item.Height");
			 var WidthArray = model.GetValues("item.Width");
			 var MaterialidArray = model.GetValues("item.Materialid");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 var Addressline1Array = model.GetValues("item.Addressline1");
			 var Addressline2Array = model.GetValues("item.Addressline2");
			 var LocationcityArray = model.GetValues("item.Locationcity");
			 var StateidArray = model.GetValues("item.Stateid");
			 var LocationzipArray = model.GetValues("item.Locationzip");
			 for (Int32 i = 0; i < BuildingidArray.Length; i++ ) {
				 buildingClass obj_update = db.selectById(Convert.ToInt32(BuildingidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LocationidArray)))
					 obj_update.Locationid = Convert.ToInt32(LocationidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingcodeArray)))
					 obj_update.Buildingcode = Convert.ToString(BuildingcodeArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingsystemidArray)))
					 obj_update.Buildingsystemid = Convert.ToInt32(BuildingsystemidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemelementidArray)))
					 obj_update.Systemelementid = Convert.ToInt32(SystemelementidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SystemtypeidArray)))
					 obj_update.Systemtypeid = Convert.ToInt32(SystemtypeidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RatingArray)))
					 obj_update.Rating = Convert.ToInt32(RatingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DetailsArray)))
					 obj_update.Details = Convert.ToString(DetailsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(IsdeficiencyrepairArray)))
					 obj_update.Isdeficiencyrepair = Convert.ToBoolean(IsdeficiencyrepairArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ProjectidArray)))
					 obj_update.Projectid = Convert.ToInt32(ProjectidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ServicecontractidArray)))
					 obj_update.Servicecontractid = Convert.ToInt32(ServicecontractidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkorderArray)))
					 obj_update.Workorder = Convert.ToString(WorkorderArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ComplianceArray)))
					 obj_update.Compliance = Convert.ToString(ComplianceArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(HeightArray)))
					 obj_update.Height = Convert.ToInt32(HeightArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(WidthArray)))
					 obj_update.Width = Convert.ToInt32(WidthArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(MaterialidArray)))
					 obj_update.Materialid = Convert.ToInt32(MaterialidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(UseridArray)))
					 obj_update.Userid = Convert.ToInt32(UseridArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InserteddatetimeArray)))
					 obj_update.Inserteddatetime = Convert.ToDateTime(InserteddatetimeArray[i]);
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
			 using(buildingCtl db = new buildingCtl()){
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
