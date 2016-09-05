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
	public class proposalchecklistexteriorwallsController : Controller
    	{
        	//private proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(proposalchecklistexteriorwallsClass Obj_proposalchecklistexteriorwalls, string command)
		{
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_proposalchecklistexteriorwalls);
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
			
			 return View( Obj_proposalchecklistexteriorwalls);
		}
	 }

		

		 public ActionResult Edit(Int32 Proposalcheckexteriorwallsid)
		{
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
				 proposalchecklistexteriorwallsClass obj_proposalchecklistexteriorwalls = db.selectById(Proposalcheckexteriorwallsid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_proposalchecklistexteriorwalls);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(proposalchecklistexteriorwallsClass Obj_proposalchecklistexteriorwalls)
		{
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_proposalchecklistexteriorwalls);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_proposalchecklistexteriorwalls);
		}
		}

		

		 public ActionResult Details(Int32 Proposalcheckexteriorwallsid)
		{
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){ proposalchecklistexteriorwallsClass obj_proposalchecklistexteriorwalls = db.selectById(Proposalcheckexteriorwallsid);
				 return View(obj_proposalchecklistexteriorwalls);
		}
		}

		

		 public ActionResult Delete(Int32 Proposalcheckexteriorwallsid) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 db.delete(Proposalcheckexteriorwallsid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Proposalcheckexteriorwallsid) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 db.delete(Proposalcheckexteriorwallsid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
			 var ProposalcheckexteriorwallsidArray = model.GetValues("item.Proposalcheckexteriorwallsid");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var SidewalkbridgeArray = model.GetValues("item.Sidewalkbridge");
			 var ScaffoldArray = model.GetValues("item.Scaffold");
			 var HoistArray = model.GetValues("item.Hoist");
			 var NoofdropsArray = model.GetValues("item.Noofdrops");
			 var NooflintelsArray = model.GetValues("item.Nooflintels");
			 var QtycaulkingArray = model.GetValues("item.Qtycaulking");
			 var DutchmanrepairsArray = model.GetValues("item.Dutchmanrepairs");
			 var NosillsreplacescappedArray = model.GetValues("item.Nosillsreplacescapped");
			 var MetalpanelreplacedArray = model.GetValues("item.Metalpanelreplaced");
			 var StonereplacementArray = model.GetValues("item.Stonereplacement");
			 var BrickreplacementArray = model.GetValues("item.Brickreplacement");
			 var ChuteArray = model.GetValues("item.Chute");
			 var NoofwythesArray = model.GetValues("item.Noofwythes");
			 var DumpstersArray = model.GetValues("item.Dumpsters");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < ProposalcheckexteriorwallsidArray.Length; i++ ) {
				 proposalchecklistexteriorwallsClass obj_update = db.selectById(Convert.ToInt32(ProposalcheckexteriorwallsidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ProposalcheckexteriorwallsidArray)))
					 obj_update.Proposalcheckexteriorwallsid = Convert.ToInt32(ProposalcheckexteriorwallsidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SidewalkbridgeArray)))
					 obj_update.Sidewalkbridge = Convert.ToString(SidewalkbridgeArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ScaffoldArray)))
					 obj_update.Scaffold = Convert.ToString(ScaffoldArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(HoistArray)))
					 obj_update.Hoist = Convert.ToString(HoistArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoofdropsArray)))
					 obj_update.Noofdrops = Convert.ToInt32(NoofdropsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NooflintelsArray)))
					 obj_update.Nooflintels = Convert.ToInt32(NooflintelsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(QtycaulkingArray)))
					 obj_update.Qtycaulking = Convert.ToString(QtycaulkingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DutchmanrepairsArray)))
					 obj_update.Dutchmanrepairs = Convert.ToString(DutchmanrepairsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NosillsreplacescappedArray)))
					 obj_update.Nosillsreplacescapped = Convert.ToInt32(NosillsreplacescappedArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(MetalpanelreplacedArray)))
					 obj_update.Metalpanelreplaced = Convert.ToString(MetalpanelreplacedArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(StonereplacementArray)))
					 obj_update.Stonereplacement = Convert.ToString(StonereplacementArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BrickreplacementArray)))
					 obj_update.Brickreplacement = Convert.ToString(BrickreplacementArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ChuteArray)))
					 obj_update.Chute = Convert.ToString(ChuteArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoofwythesArray)))
					 obj_update.Noofwythes = Convert.ToInt32(NoofwythesArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DumpstersArray)))
					 obj_update.Dumpsters = Convert.ToString(DumpstersArray[i]);
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
			 using(proposalchecklistexteriorwallsCtl db = new proposalchecklistexteriorwallsCtl()){
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
