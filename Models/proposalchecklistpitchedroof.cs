using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using DB_con;


namespace ppmapp.Models
{
	public class proposalchecklistpitchedroofClass
    {
		#region "properties"
			public Int32  Proposalcheckpitchedroofid {get;set;}
public Int32  Buildingid {get;set;}
public string  Iceandwatershield {get;set;}
public string  Deck {get;set;}
public Int32  Noofdrains {get;set;}
public string  Protrusions {get;set;}
public string  Vallerys {get;set;}
public string  Ridgecaps {get;set;}
public string  Asbestos {get;set;}
public string  Subroofs {get;set;}
public string  Rakingwallflashing {get;set;}
public string  Rakingwallcoping {get;set;}
public string  Railing {get;set;}
public string  Access {get;set;}
public string  Chimneys {get;set;}
public string  Dumpsters {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public proposalchecklistpitchedroofClass(){
		 
			Proposalcheckpitchedroofid = 0;
			Buildingid = 0;
			Iceandwatershield = "update";
			Deck = "update";
			Noofdrains = 0;
			Protrusions = "update";
			Vallerys = "update";
			Ridgecaps = "update";
			Asbestos = "update";
			Subroofs = "update";
			Rakingwallflashing = "update";
			Rakingwallcoping = "update";
			Railing = "update";
			Access = "update";
			Chimneys = "update";
			Dumpsters = "update";
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class proposalchecklistpitchedroofCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public proposalchecklistpitchedroofCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public proposalchecklistpitchedroofCtl(Int32 id)
{
obj_con = new ConnectionCls();
proposalchecklistpitchedroofClass  obj_pro= new proposalchecklistpitchedroofClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_pro.Proposalcheckpitchedroofid = Convert.ToInt32(dt.Rows[0]["Proposalcheckpitchedroofid"]);
obj_pro.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_pro.Iceandwatershield = Convert.ToString(dt.Rows[0]["Iceandwatershield"]);
obj_pro.Deck = Convert.ToString(dt.Rows[0]["Deck"]);
obj_pro.Noofdrains = Convert.ToInt32(dt.Rows[0]["Noofdrains"]);
obj_pro.Protrusions = Convert.ToString(dt.Rows[0]["Protrusions"]);
obj_pro.Vallerys = Convert.ToString(dt.Rows[0]["Vallerys"]);
obj_pro.Ridgecaps = Convert.ToString(dt.Rows[0]["Ridgecaps"]);
obj_pro.Asbestos = Convert.ToString(dt.Rows[0]["Asbestos"]);
obj_pro.Subroofs = Convert.ToString(dt.Rows[0]["Subroofs"]);
obj_pro.Rakingwallflashing = Convert.ToString(dt.Rows[0]["Rakingwallflashing"]);
obj_pro.Rakingwallcoping = Convert.ToString(dt.Rows[0]["Rakingwallcoping"]);
obj_pro.Railing = Convert.ToString(dt.Rows[0]["Railing"]);
obj_pro.Access = Convert.ToString(dt.Rows[0]["Access"]);
obj_pro.Chimneys = Convert.ToString(dt.Rows[0]["Chimneys"]);
obj_pro.Dumpsters = Convert.ToString(dt.Rows[0]["Dumpsters"]);
obj_pro.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_pro.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(proposalchecklistpitchedroofClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistpitchedroof_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalcheckpitchedroofid = Convert.ToInt32(obj_con.getValue("@Proposalcheckpitchedroofid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistpitchedroof_insert");
}
}

//update data into database 
public Int32 update(proposalchecklistpitchedroofClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistpitchedroof_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalcheckpitchedroofid = Convert.ToInt32(obj_con.getValue("@Proposalcheckpitchedroofid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistpitchedroof_update");
}
}

//delete data from database 
public void delete(Int32 Proposalcheckpitchedroofid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Proposalcheckpitchedroofid", Proposalcheckpitchedroofid );
obj_con.ExecuteNoneQuery("sp_proposalchecklistpitchedroof_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistpitchedroof_delete");
}
}

//select all data from database 
public List<proposalchecklistpitchedroofClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistpitchedroof_selectall");
}
}

//select data from database as Paging
public List<proposalchecklistpitchedroofClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_proposalchecklistpitchedroof_selectPaging");
	 }
}

	 public List<proposalchecklistpitchedroofClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistpitchedroof_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistpitchedroof_selectIndexPaging");
		 }
	 }
	 public List<proposalchecklistpitchedroofClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@StartIndex", StartIndex);
			 obj_con.addParameter("@EndIndex", EndIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_AddressBook_selectLazyLoading", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
	 }catch (Exception ex){
		 throw new Exception("sp_AddressBook_selectLazyLoading");
	 }
	 }
//select data from database as list
public List<proposalchecklistpitchedroofClass> selectlist(Int32 Proposalcheckpitchedroofid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckpitchedroofid", Proposalcheckpitchedroofid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistpitchedroof_select");
}
}

//select data from database as Objject
public proposalchecklistpitchedroofClass selectById(Int32 Proposalcheckpitchedroofid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckpitchedroofid", Proposalcheckpitchedroofid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistpitchedroof_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Proposalcheckpitchedroofid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckpitchedroofid", Proposalcheckpitchedroofid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistpitchedroof_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistpitchedroof_select");
}
}

//create parameter 
public void createParameter(proposalchecklistpitchedroofClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Iceandwatershield", string.IsNullOrEmpty(Convert.ToString(obj.Iceandwatershield)) ? "" : obj.Iceandwatershield);
obj_con.addParameter("@Deck", string.IsNullOrEmpty(Convert.ToString(obj.Deck)) ? "" : obj.Deck);
obj_con.addParameter("@Noofdrains", string.IsNullOrEmpty(Convert.ToString(obj.Noofdrains)) ? 0 : obj.Noofdrains);
obj_con.addParameter("@Protrusions", string.IsNullOrEmpty(Convert.ToString(obj.Protrusions)) ? "" : obj.Protrusions);
obj_con.addParameter("@Vallerys", string.IsNullOrEmpty(Convert.ToString(obj.Vallerys)) ? "" : obj.Vallerys);
obj_con.addParameter("@Ridgecaps", string.IsNullOrEmpty(Convert.ToString(obj.Ridgecaps)) ? "" : obj.Ridgecaps);
obj_con.addParameter("@Asbestos", string.IsNullOrEmpty(Convert.ToString(obj.Asbestos)) ? "" : obj.Asbestos);
obj_con.addParameter("@Subroofs", string.IsNullOrEmpty(Convert.ToString(obj.Subroofs)) ? "" : obj.Subroofs);
obj_con.addParameter("@Rakingwallflashing", string.IsNullOrEmpty(Convert.ToString(obj.Rakingwallflashing)) ? "" : obj.Rakingwallflashing);
obj_con.addParameter("@Rakingwallcoping", string.IsNullOrEmpty(Convert.ToString(obj.Rakingwallcoping)) ? "" : obj.Rakingwallcoping);
obj_con.addParameter("@Railing", string.IsNullOrEmpty(Convert.ToString(obj.Railing)) ? "" : obj.Railing);
obj_con.addParameter("@Access", string.IsNullOrEmpty(Convert.ToString(obj.Access)) ? "" : obj.Access);
obj_con.addParameter("@Chimneys", string.IsNullOrEmpty(Convert.ToString(obj.Chimneys)) ? "" : obj.Chimneys);
obj_con.addParameter("@Dumpsters", string.IsNullOrEmpty(Convert.ToString(obj.Dumpsters)) ? "" : obj.Dumpsters);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Proposalcheckpitchedroofid", obj.Proposalcheckpitchedroofid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public proposalchecklistpitchedroofClass updateObject(proposalchecklistpitchedroofClass  obj)
{
try
{

	 proposalchecklistpitchedroofClass oldObj = selectById(obj.Proposalcheckpitchedroofid);
 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Iceandwatershield == null || obj.Iceandwatershield.ToString().Trim() == "update")
	 obj.Iceandwatershield = oldObj.Iceandwatershield; 

 if (obj.Deck == null || obj.Deck.ToString().Trim() == "update")
	 obj.Deck = oldObj.Deck; 

 if (obj.Noofdrains == null || obj.Noofdrains.ToString().Trim() == "0")
	 obj.Noofdrains = oldObj.Noofdrains; 

 if (obj.Protrusions == null || obj.Protrusions.ToString().Trim() == "update")
	 obj.Protrusions = oldObj.Protrusions; 

 if (obj.Vallerys == null || obj.Vallerys.ToString().Trim() == "update")
	 obj.Vallerys = oldObj.Vallerys; 

 if (obj.Ridgecaps == null || obj.Ridgecaps.ToString().Trim() == "update")
	 obj.Ridgecaps = oldObj.Ridgecaps; 

 if (obj.Asbestos == null || obj.Asbestos.ToString().Trim() == "update")
	 obj.Asbestos = oldObj.Asbestos; 

 if (obj.Subroofs == null || obj.Subroofs.ToString().Trim() == "update")
	 obj.Subroofs = oldObj.Subroofs; 

 if (obj.Rakingwallflashing == null || obj.Rakingwallflashing.ToString().Trim() == "update")
	 obj.Rakingwallflashing = oldObj.Rakingwallflashing; 

 if (obj.Rakingwallcoping == null || obj.Rakingwallcoping.ToString().Trim() == "update")
	 obj.Rakingwallcoping = oldObj.Rakingwallcoping; 

 if (obj.Railing == null || obj.Railing.ToString().Trim() == "update")
	 obj.Railing = oldObj.Railing; 

 if (obj.Access == null || obj.Access.ToString().Trim() == "update")
	 obj.Access = oldObj.Access; 

 if (obj.Chimneys == null || obj.Chimneys.ToString().Trim() == "update")
	 obj.Chimneys = oldObj.Chimneys; 

 if (obj.Dumpsters == null || obj.Dumpsters.ToString().Trim() == "update")
	 obj.Dumpsters = oldObj.Dumpsters; 

 if (obj.Userid == null || obj.Userid.ToString().Trim() == "0")
	 obj.Userid = oldObj.Userid; 

 if (obj.Inserteddatetime == null || obj.Inserteddatetime == Convert.ToDateTime("1900-01-01"))
	 obj.Inserteddatetime = oldObj.Inserteddatetime; 

	 return obj;}
catch (Exception ex)
{
throw new Exception(ex.Message);
}
}

//Convert IDataReader To DataTable method
 public DataTable ConvertDatareadertoDataTable(IDataReader dr)
{
DataTable dt = new DataTable();
dt.Load(dr);
return dt;
}

//Convert DataTable To List method
 public List<proposalchecklistpitchedroofClass> ConvertToList(DataTable dt)
{
 List<proposalchecklistpitchedroofClass> proposalchecklistpitchedrooflist = new List<proposalchecklistpitchedroofClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
proposalchecklistpitchedroofClass obj_proposalchecklistpitchedroof = new proposalchecklistpitchedroofClass();

		 if (Convert.ToString(dt.Rows[i]["Proposalcheckpitchedroofid"]) != "")
			obj_proposalchecklistpitchedroof.Proposalcheckpitchedroofid = Convert.ToInt32(dt.Rows[i]["Proposalcheckpitchedroofid"]);
	 else
			 obj_proposalchecklistpitchedroof.Proposalcheckpitchedroofid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistpitchedroof.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistpitchedroof.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Iceandwatershield"]) != "")
			obj_proposalchecklistpitchedroof.Iceandwatershield = Convert.ToString(dt.Rows[i]["Iceandwatershield"]);
	 else
			 obj_proposalchecklistpitchedroof.Iceandwatershield = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deck"]) != "")
			obj_proposalchecklistpitchedroof.Deck = Convert.ToString(dt.Rows[i]["Deck"]);
	 else
			 obj_proposalchecklistpitchedroof.Deck = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrains"]) != "")
			obj_proposalchecklistpitchedroof.Noofdrains = Convert.ToInt32(dt.Rows[i]["Noofdrains"]);
	 else
			 obj_proposalchecklistpitchedroof.Noofdrains = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Protrusions"]) != "")
			obj_proposalchecklistpitchedroof.Protrusions = Convert.ToString(dt.Rows[i]["Protrusions"]);
	 else
			 obj_proposalchecklistpitchedroof.Protrusions = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Vallerys"]) != "")
			obj_proposalchecklistpitchedroof.Vallerys = Convert.ToString(dt.Rows[i]["Vallerys"]);
	 else
			 obj_proposalchecklistpitchedroof.Vallerys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Ridgecaps"]) != "")
			obj_proposalchecklistpitchedroof.Ridgecaps = Convert.ToString(dt.Rows[i]["Ridgecaps"]);
	 else
			 obj_proposalchecklistpitchedroof.Ridgecaps = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Asbestos"]) != "")
			obj_proposalchecklistpitchedroof.Asbestos = Convert.ToString(dt.Rows[i]["Asbestos"]);
	 else
			 obj_proposalchecklistpitchedroof.Asbestos = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Subroofs"]) != "")
			obj_proposalchecklistpitchedroof.Subroofs = Convert.ToString(dt.Rows[i]["Subroofs"]);
	 else
			 obj_proposalchecklistpitchedroof.Subroofs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Rakingwallflashing"]) != "")
			obj_proposalchecklistpitchedroof.Rakingwallflashing = Convert.ToString(dt.Rows[i]["Rakingwallflashing"]);
	 else
			 obj_proposalchecklistpitchedroof.Rakingwallflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Rakingwallcoping"]) != "")
			obj_proposalchecklistpitchedroof.Rakingwallcoping = Convert.ToString(dt.Rows[i]["Rakingwallcoping"]);
	 else
			 obj_proposalchecklistpitchedroof.Rakingwallcoping = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Railing"]) != "")
			obj_proposalchecklistpitchedroof.Railing = Convert.ToString(dt.Rows[i]["Railing"]);
	 else
			 obj_proposalchecklistpitchedroof.Railing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Access"]) != "")
			obj_proposalchecklistpitchedroof.Access = Convert.ToString(dt.Rows[i]["Access"]);
	 else
			 obj_proposalchecklistpitchedroof.Access = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chimneys"]) != "")
			obj_proposalchecklistpitchedroof.Chimneys = Convert.ToString(dt.Rows[i]["Chimneys"]);
	 else
			 obj_proposalchecklistpitchedroof.Chimneys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistpitchedroof.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistpitchedroof.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistpitchedroof.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistpitchedroof.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistpitchedroof.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistpitchedroof.Inserteddatetime = Convert.ToDateTime("01/01/1900");


proposalchecklistpitchedrooflist.Add(obj_proposalchecklistpitchedroof);
}
return proposalchecklistpitchedrooflist;
}

//Convert DataTable To object method
 public proposalchecklistpitchedroofClass ConvertToOjbect(DataTable dt)
{
 proposalchecklistpitchedroofClass obj_proposalchecklistpitchedroof = new proposalchecklistpitchedroofClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Proposalcheckpitchedroofid"]) != "")
			obj_proposalchecklistpitchedroof.Proposalcheckpitchedroofid = Convert.ToInt32(dt.Rows[i]["Proposalcheckpitchedroofid"]);
	 else
			 obj_proposalchecklistpitchedroof.Proposalcheckpitchedroofid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistpitchedroof.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistpitchedroof.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Iceandwatershield"]) != "")
			obj_proposalchecklistpitchedroof.Iceandwatershield = Convert.ToString(dt.Rows[i]["Iceandwatershield"]);
	 else
			 obj_proposalchecklistpitchedroof.Iceandwatershield = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deck"]) != "")
			obj_proposalchecklistpitchedroof.Deck = Convert.ToString(dt.Rows[i]["Deck"]);
	 else
			 obj_proposalchecklistpitchedroof.Deck = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrains"]) != "")
			obj_proposalchecklistpitchedroof.Noofdrains = Convert.ToInt32(dt.Rows[i]["Noofdrains"]);
	 else
			 obj_proposalchecklistpitchedroof.Noofdrains = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Protrusions"]) != "")
			obj_proposalchecklistpitchedroof.Protrusions = Convert.ToString(dt.Rows[i]["Protrusions"]);
	 else
			 obj_proposalchecklistpitchedroof.Protrusions = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Vallerys"]) != "")
			obj_proposalchecklistpitchedroof.Vallerys = Convert.ToString(dt.Rows[i]["Vallerys"]);
	 else
			 obj_proposalchecklistpitchedroof.Vallerys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Ridgecaps"]) != "")
			obj_proposalchecklistpitchedroof.Ridgecaps = Convert.ToString(dt.Rows[i]["Ridgecaps"]);
	 else
			 obj_proposalchecklistpitchedroof.Ridgecaps = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Asbestos"]) != "")
			obj_proposalchecklistpitchedroof.Asbestos = Convert.ToString(dt.Rows[i]["Asbestos"]);
	 else
			 obj_proposalchecklistpitchedroof.Asbestos = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Subroofs"]) != "")
			obj_proposalchecklistpitchedroof.Subroofs = Convert.ToString(dt.Rows[i]["Subroofs"]);
	 else
			 obj_proposalchecklistpitchedroof.Subroofs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Rakingwallflashing"]) != "")
			obj_proposalchecklistpitchedroof.Rakingwallflashing = Convert.ToString(dt.Rows[i]["Rakingwallflashing"]);
	 else
			 obj_proposalchecklistpitchedroof.Rakingwallflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Rakingwallcoping"]) != "")
			obj_proposalchecklistpitchedroof.Rakingwallcoping = Convert.ToString(dt.Rows[i]["Rakingwallcoping"]);
	 else
			 obj_proposalchecklistpitchedroof.Rakingwallcoping = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Railing"]) != "")
			obj_proposalchecklistpitchedroof.Railing = Convert.ToString(dt.Rows[i]["Railing"]);
	 else
			 obj_proposalchecklistpitchedroof.Railing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Access"]) != "")
			obj_proposalchecklistpitchedroof.Access = Convert.ToString(dt.Rows[i]["Access"]);
	 else
			 obj_proposalchecklistpitchedroof.Access = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chimneys"]) != "")
			obj_proposalchecklistpitchedroof.Chimneys = Convert.ToString(dt.Rows[i]["Chimneys"]);
	 else
			 obj_proposalchecklistpitchedroof.Chimneys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistpitchedroof.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistpitchedroof.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistpitchedroof.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistpitchedroof.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistpitchedroof.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistpitchedroof.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_proposalchecklistpitchedroof;
}

			
	 //disposble method
 	void IDisposable.Dispose()
 	{
     		System.GC.SuppressFinalize(this);
     		obj_con.closeConnection();
 	}

		#endregion
	}

}
