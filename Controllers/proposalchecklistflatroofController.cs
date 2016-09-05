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
	public class proposalchecklistflatroofController : Controller
    	{
        	//private proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(proposalchecklistflatroofClass Obj_proposalchecklistflatroof, string command)
		{
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_proposalchecklistflatroof);
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
			
			 return View( Obj_proposalchecklistflatroof);
		}
	 }

		

		 public ActionResult Edit(Int32 Proposalchecklistid)
		{
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
				 proposalchecklistflatroofClass obj_proposalchecklistflatroof = db.selectById(Proposalchecklistid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_proposalchecklistflatroof);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(proposalchecklistflatroofClass Obj_proposalchecklistflatroof)
		{
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_proposalchecklistflatroof);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_proposalchecklistflatroof);
		}
		}

		

		 public ActionResult Details(Int32 Proposalchecklistid)
		{
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){ proposalchecklistflatroofClass obj_proposalchecklistflatroof = db.selectById(Proposalchecklistid);
				 return View(obj_proposalchecklistflatroof);
		}
		}

		

		 public ActionResult Delete(Int32 Proposalchecklistid) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 db.delete(Proposalchecklistid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Proposalchecklistid) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 db.delete(Proposalchecklistid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
			 var ProposalchecklistidArray = model.GetValues("item.Proposalchecklistid");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var InsualtionArray = model.GetValues("item.Insualtion");
			 var DeckArray = model.GetValues("item.Deck");
			 var NoofdrainsArray = model.GetValues("item.Noofdrains");
			 var ProtrusionsArray = model.GetValues("item.Protrusions");
			 var BaseflashingArray = model.GetValues("item.Baseflashing");
			 var CounterflashingArray = model.GetValues("item.Counterflashing");
			 var AsbestosArray = model.GetValues("item.Asbestos");
			 var SubroofsArray = model.GetValues("item.Subroofs");
			 var InteriorparapetArray = model.GetValues("item.Interiorparapet");
			 var CopingArray = model.GetValues("item.Coping");
			 var RailingsArray = model.GetValues("item.Railings");
			 var AccessArray = model.GetValues("item.Access");
			 var ChimneysArray = model.GetValues("item.Chimneys");
			 var DumpstersArray = model.GetValues("item.Dumpsters");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < ProposalchecklistidArray.Length; i++ ) {
				 proposalchecklistflatroofClass obj_update = db.selectById(Convert.ToInt32(ProposalchecklistidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ProposalchecklistidArray)))
					 obj_update.Proposalchecklistid = Convert.ToInt32(ProposalchecklistidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InsualtionArray)))
					 obj_update.Insualtion = Convert.ToString(InsualtionArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DeckArray)))
					 obj_update.Deck = Convert.ToString(DeckArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoofdrainsArray)))
					 obj_update.Noofdrains = Convert.ToInt32(NoofdrainsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ProtrusionsArray)))
					 obj_update.Protrusions = Convert.ToString(ProtrusionsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BaseflashingArray)))
					 obj_update.Baseflashing = Convert.ToString(BaseflashingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(CounterflashingArray)))
					 obj_update.Counterflashing = Convert.ToString(CounterflashingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(AsbestosArray)))
					 obj_update.Asbestos = Convert.ToString(AsbestosArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SubroofsArray)))
					 obj_update.Subroofs = Convert.ToString(SubroofsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(InteriorparapetArray)))
					 obj_update.Interiorparapet = Convert.ToString(InteriorparapetArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(CopingArray)))
					 obj_update.Coping = Convert.ToString(CopingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RailingsArray)))
					 obj_update.Railings = Convert.ToString(RailingsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(AccessArray)))
					 obj_update.Access = Convert.ToString(AccessArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ChimneysArray)))
					 obj_update.Chimneys = Convert.ToString(ChimneysArray[i]);
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
			 using(proposalchecklistflatroofCtl db = new proposalchecklistflatroofCtl()){
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
