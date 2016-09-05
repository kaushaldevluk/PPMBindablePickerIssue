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
	public class clientController : Controller
    	{
        	//private clientCtl db = new clientCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(clientCtl db = new clientCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(clientClass Obj_client, string command)
		{
			
			 using(clientCtl db = new clientCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_client);
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
			
			 return View( Obj_client);
		}
	 }

		

		 public ActionResult Edit(Int32 Clientid)
		{
			
			 using(clientCtl db = new clientCtl()){
				 clientClass obj_client = db.selectById(Clientid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_client);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(clientClass Obj_client)
		{
			 using(clientCtl db = new clientCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_client);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_client);
		}
		}

		

		 public ActionResult Details(Int32 Clientid)
		{
			
			 using(clientCtl db = new clientCtl()){ clientClass obj_client = db.selectById(Clientid);
				 return View(obj_client);
		}
		}

		

		 public ActionResult Delete(Int32 Clientid) {
			 using(clientCtl db = new clientCtl()){
			 db.delete(Clientid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(clientCtl db = new clientCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(clientCtl db = new clientCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(clientCtl db = new clientCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(clientCtl db = new clientCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(clientCtl db = new clientCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(clientCtl db = new clientCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Clientid) {
			 using(clientCtl db = new clientCtl()){
			 db.delete(Clientid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(clientCtl db = new clientCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(clientCtl db = new clientCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(clientCtl db = new clientCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(clientCtl db = new clientCtl()){
			 var ClientidArray = model.GetValues("item.Clientid");
			 var ClientnameArray = model.GetValues("item.Clientname");
			 var ClientcodeArray = model.GetValues("item.Clientcode");
			 var ClientshortnameArray = model.GetValues("item.Clientshortname");
			 var Addressline1Array = model.GetValues("item.Addressline1");
			 var Addressline2Array = model.GetValues("item.Addressline2");
			 var LocationcityArray = model.GetValues("item.Locationcity");
			 var StateidArray = model.GetValues("item.Stateid");
			 var LocationzipArray = model.GetValues("item.Locationzip");
			 var BudgetstartmonthArray = model.GetValues("item.Budgetstartmonth");
			 for (Int32 i = 0; i < ClientidArray.Length; i++ ) {
				 clientClass obj_update = db.selectById(Convert.ToInt32(ClientidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ClientidArray)))
					 obj_update.Clientid = Convert.ToInt32(ClientidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ClientnameArray)))
					 obj_update.Clientname = Convert.ToString(ClientnameArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ClientcodeArray)))
					 obj_update.Clientcode = Convert.ToString(ClientcodeArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ClientshortnameArray)))
					 obj_update.Clientshortname = Convert.ToString(ClientshortnameArray[i]);
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
				 if (!string.IsNullOrEmpty(Convert.ToString(BudgetstartmonthArray)))
					 obj_update.Budgetstartmonth = Convert.ToInt32(BudgetstartmonthArray[i]);
				 db.update(obj_update);
			 } 
		 }
		}
		 return RedirectToAction("EditTable");
	 }
	 
	 public ActionResult EditTableRowsDelete(string records) {
			 using(clientCtl db = new clientCtl()){
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
