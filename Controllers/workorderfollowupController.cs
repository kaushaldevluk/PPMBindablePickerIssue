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
	public class workorderfollowupController : Controller
    	{
        	//private workorderfollowupCtl db = new workorderfollowupCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(workorderfollowupClass Obj_workorderfollowup, string command)
		{
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_workorderfollowup);
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
			
			 return View( Obj_workorderfollowup);
		}
	 }

		

		 public ActionResult Edit(Int32 Workorderfollowupid)
		{
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
				 workorderfollowupClass obj_workorderfollowup = db.selectById(Workorderfollowupid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_workorderfollowup);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(workorderfollowupClass Obj_workorderfollowup)
		{
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_workorderfollowup);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_workorderfollowup);
		}
		}

		

		 public ActionResult Details(Int32 Workorderfollowupid)
		{
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){ workorderfollowupClass obj_workorderfollowup = db.selectById(Workorderfollowupid);
				 return View(obj_workorderfollowup);
		}
		}

		

		 public ActionResult Delete(Int32 Workorderfollowupid) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 db.delete(Workorderfollowupid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Workorderfollowupid) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 db.delete(Workorderfollowupid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
			 var WorkorderfollowupidArray = model.GetValues("item.Workorderfollowupid");
			 var WorkorderidArray = model.GetValues("item.Workorderid");
			 var DatecompletedArray = model.GetValues("item.Datecompleted");
			 var LabourArray = model.GetValues("item.Labour");
			 var PartssuppiesArray = model.GetValues("item.Partssuppies");
			 var NoteArray = model.GetValues("item.Note");
			 var NoteaudioArray = model.GetValues("item.Noteaudio");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < WorkorderfollowupidArray.Length; i++ ) {
				 workorderfollowupClass obj_update = db.selectById(Convert.ToInt32(WorkorderfollowupidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkorderfollowupidArray)))
					 obj_update.Workorderfollowupid = Convert.ToInt32(WorkorderfollowupidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(WorkorderidArray)))
					 obj_update.Workorderid = Convert.ToInt32(WorkorderidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DatecompletedArray)))
					 obj_update.Datecompleted = Convert.ToDateTime(DatecompletedArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(LabourArray)))
					 obj_update.Labour = Convert.ToInt32(LabourArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PartssuppiesArray)))
					 obj_update.Partssuppies = Convert.ToString(PartssuppiesArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoteArray)))
					 obj_update.Note = Convert.ToString(NoteArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoteaudioArray)))
					 obj_update.Noteaudio = Convert.To(NoteaudioArray[i]);
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
			 using(workorderfollowupCtl db = new workorderfollowupCtl()){
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
