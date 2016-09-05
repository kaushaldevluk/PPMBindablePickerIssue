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
	public class usersController : Controller
    	{
        	//private usersCtl db = new usersCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(usersCtl db = new usersCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(usersClass Obj_users, string command)
		{
			
			 using(usersCtl db = new usersCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_users);
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
			
			 return View( Obj_users);
		}
	 }

		

		 public ActionResult Edit(Int32 Userid)
		{
			
			 using(usersCtl db = new usersCtl()){
				 usersClass obj_users = db.selectById(Userid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_users);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(usersClass Obj_users)
		{
			 using(usersCtl db = new usersCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_users);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_users);
		}
		}

		

		 public ActionResult Details(Int32 Userid)
		{
			
			 using(usersCtl db = new usersCtl()){ usersClass obj_users = db.selectById(Userid);
				 return View(obj_users);
		}
		}

		

		 public ActionResult Delete(Int32 Userid) {
			 using(usersCtl db = new usersCtl()){
			 db.delete(Userid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(usersCtl db = new usersCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(usersCtl db = new usersCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(usersCtl db = new usersCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(usersCtl db = new usersCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(usersCtl db = new usersCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(usersCtl db = new usersCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Userid) {
			 using(usersCtl db = new usersCtl()){
			 db.delete(Userid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(usersCtl db = new usersCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(usersCtl db = new usersCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(usersCtl db = new usersCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(usersCtl db = new usersCtl()){
			 var UseridArray = model.GetValues("item.Userid");
			 var EmailArray = model.GetValues("item.Email");
			 var PasswordArray = model.GetValues("item.Password");
			 var DevicetypeArray = model.GetValues("item.Devicetype");
			 var DeviceidArray = model.GetValues("item.Deviceid");
			 var IsactiveArray = model.GetValues("item.Isactive");
			 for (Int32 i = 0; i < UseridArray.Length; i++ ) {
				 usersClass obj_update = db.selectById(Convert.ToInt32(UseridArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(UseridArray)))
					 obj_update.Userid = Convert.ToInt32(UseridArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(EmailArray)))
					 obj_update.Email = Convert.ToString(EmailArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(PasswordArray)))
					 obj_update.Password = Convert.ToString(PasswordArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DevicetypeArray)))
					 obj_update.Devicetype = Convert.ToString(DevicetypeArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DeviceidArray)))
					 obj_update.Deviceid = Convert.ToString(DeviceidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(IsactiveArray)))
					 obj_update.Isactive = Convert.ToBoolean(IsactiveArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(usersCtl db = new usersCtl()){
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
