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
	public class proposalchecklistpitchedroofController : Controller
    	{
        	//private proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl();
            	//{privateVariables}

		

		public ActionResult Create()
		{
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 Session["CreatePreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
				 return View();
			}

		}
	

		 [HttpPost]
		[ValidateAntiForgeryToken]
		 public ActionResult Create(proposalchecklistpitchedroofClass Obj_proposalchecklistpitchedroof, string command)
		{
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 if (ModelState.IsValid)
			{
					 db.insert(Obj_proposalchecklistpitchedroof);
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
			
			 return View( Obj_proposalchecklistpitchedroof);
		}
	 }

		

		 public ActionResult Edit(Int32 Proposalcheckpitchedroofid)
		{
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
				 proposalchecklistpitchedroofClass obj_proposalchecklistpitchedroof = db.selectById(Proposalcheckpitchedroofid);
				Session["EditPreviousURL"] = Convert.ToString(ControllerContext.HttpContext.Request.UrlReferrer);
					 return View(obj_proposalchecklistpitchedroof);
		}
		}

		

		 [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(proposalchecklistpitchedroofClass Obj_proposalchecklistpitchedroof)
		{
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 if (ModelState.IsValid){
				 db.update(Obj_proposalchecklistpitchedroof);
				 string sesionval = Convert.ToString(Session["EditPreviousURL"]);
				 if (!string.IsNullOrEmpty(sesionval)){
					 Session.Remove("EditPreviousURL");
					 return Redirect(sesionval);
				 }else 
					 return RedirectToAction("Index"); 
			 }
		 return View( Obj_proposalchecklistpitchedroof);
		}
		}

		

		 public ActionResult Details(Int32 Proposalcheckpitchedroofid)
		{
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){ proposalchecklistpitchedroofClass obj_proposalchecklistpitchedroof = db.selectById(Proposalcheckpitchedroofid);
				 return View(obj_proposalchecklistpitchedroof);
		}
		}

		

		 public ActionResult Delete(Int32 Proposalcheckpitchedroofid) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 db.delete(Proposalcheckpitchedroofid);
			 return RedirectToAction("Index");
		 }
	}
		 

		public ActionResult Index()
		{
			 
			 return View();
		}

		

		 public ActionResult Indexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 IndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult IndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		public ActionResult VIndex()
		{
			 
			 return View();
		}

		

		 public ActionResult VIndexpaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 VIndexpagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult VIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		

		 public ActionResult EditTableRowDelete(Int32 Proposalcheckpitchedroofid) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 db.delete(Proposalcheckpitchedroofid);
			 return RedirectToAction("EditTable");
		 }
			}
		 

		public ActionResult EditTable()
		{
			 
			 return View();
		}

		

		 public ActionResult EditTablePaging(Int64 PageSize, Int64 PageIndex, string Search){
			 
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return PartialView(db.selectIndexPaging(PageSize, PageIndex, Search)); 
		}
		}
		public Int32 EditTablePagingCount(Int64 PageSize, Int64 PageIndex, string Search){
			
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){return db.selectIndexPagingCount(PageSize, PageIndex, Search); 
		}
		}
		 
	 public ActionResult EditTableLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
		 return PartialView( db.selectIndexLazyLoading(StartIndex, EndIndex, Search));
	 }
		} 
		
	 [HttpPost]
	 public ActionResult SaveRecords(FormCollection model) {
		 if (ModelState.IsValid) {
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
			 var ProposalcheckpitchedroofidArray = model.GetValues("item.Proposalcheckpitchedroofid");
			 var BuildingidArray = model.GetValues("item.Buildingid");
			 var IceandwatershieldArray = model.GetValues("item.Iceandwatershield");
			 var DeckArray = model.GetValues("item.Deck");
			 var NoofdrainsArray = model.GetValues("item.Noofdrains");
			 var ProtrusionsArray = model.GetValues("item.Protrusions");
			 var VallerysArray = model.GetValues("item.Vallerys");
			 var RidgecapsArray = model.GetValues("item.Ridgecaps");
			 var AsbestosArray = model.GetValues("item.Asbestos");
			 var SubroofsArray = model.GetValues("item.Subroofs");
			 var RakingwallflashingArray = model.GetValues("item.Rakingwallflashing");
			 var RakingwallcopingArray = model.GetValues("item.Rakingwallcoping");
			 var RailingArray = model.GetValues("item.Railing");
			 var AccessArray = model.GetValues("item.Access");
			 var ChimneysArray = model.GetValues("item.Chimneys");
			 var DumpstersArray = model.GetValues("item.Dumpsters");
			 var UseridArray = model.GetValues("item.Userid");
			 var InserteddatetimeArray = model.GetValues("item.Inserteddatetime");
			 for (Int32 i = 0; i < ProposalcheckpitchedroofidArray.Length; i++ ) {
				 proposalchecklistpitchedroofClass obj_update = db.selectById(Convert.ToInt32(ProposalcheckpitchedroofidArray[i]));
				 if (!string.IsNullOrEmpty(Convert.ToString(ProposalcheckpitchedroofidArray)))
					 obj_update.Proposalcheckpitchedroofid = Convert.ToInt32(ProposalcheckpitchedroofidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(BuildingidArray)))
					 obj_update.Buildingid = Convert.ToInt32(BuildingidArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(IceandwatershieldArray)))
					 obj_update.Iceandwatershield = Convert.ToString(IceandwatershieldArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(DeckArray)))
					 obj_update.Deck = Convert.ToString(DeckArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(NoofdrainsArray)))
					 obj_update.Noofdrains = Convert.ToInt32(NoofdrainsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(ProtrusionsArray)))
					 obj_update.Protrusions = Convert.ToString(ProtrusionsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(VallerysArray)))
					 obj_update.Vallerys = Convert.ToString(VallerysArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RidgecapsArray)))
					 obj_update.Ridgecaps = Convert.ToString(RidgecapsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(AsbestosArray)))
					 obj_update.Asbestos = Convert.ToString(AsbestosArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(SubroofsArray)))
					 obj_update.Subroofs = Convert.ToString(SubroofsArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RakingwallflashingArray)))
					 obj_update.Rakingwallflashing = Convert.ToString(RakingwallflashingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RakingwallcopingArray)))
					 obj_update.Rakingwallcoping = Convert.ToString(RakingwallcopingArray[i]);
				 if (!string.IsNullOrEmpty(Convert.ToString(RailingArray)))
					 obj_update.Railing = Convert.ToString(RailingArray[i]);
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
			 using(proposalchecklistpitchedroofCtl db = new proposalchecklistpitchedroofCtl()){
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
