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
	public class proposalchecklistflatroofClass
    {
		#region "properties"
			public Int32  Proposalchecklistid {get;set;}
public Int32  Buildingid {get;set;}
public string  Insualtion {get;set;}
public string  Deck {get;set;}
public Int32  Noofdrains {get;set;}
public string  Protrusions {get;set;}
public string  Baseflashing {get;set;}
public string  Counterflashing {get;set;}
public string  Asbestos {get;set;}
public string  Subroofs {get;set;}
public string  Interiorparapet {get;set;}
public string  Coping {get;set;}
public string  Railings {get;set;}
public string  Access {get;set;}
public string  Chimneys {get;set;}
public string  Dumpsters {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public proposalchecklistflatroofClass(){
		 
			Proposalchecklistid = 0;
			Buildingid = 0;
			Insualtion = "update";
			Deck = "update";
			Noofdrains = 0;
			Protrusions = "update";
			Baseflashing = "update";
			Counterflashing = "update";
			Asbestos = "update";
			Subroofs = "update";
			Interiorparapet = "update";
			Coping = "update";
			Railings = "update";
			Access = "update";
			Chimneys = "update";
			Dumpsters = "update";
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class proposalchecklistflatroofCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public proposalchecklistflatroofCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public proposalchecklistflatroofCtl(Int32 id)
{
obj_con = new ConnectionCls();
proposalchecklistflatroofClass  obj_pro= new proposalchecklistflatroofClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_pro.Proposalchecklistid = Convert.ToInt32(dt.Rows[0]["Proposalchecklistid"]);
obj_pro.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_pro.Insualtion = Convert.ToString(dt.Rows[0]["Insualtion"]);
obj_pro.Deck = Convert.ToString(dt.Rows[0]["Deck"]);
obj_pro.Noofdrains = Convert.ToInt32(dt.Rows[0]["Noofdrains"]);
obj_pro.Protrusions = Convert.ToString(dt.Rows[0]["Protrusions"]);
obj_pro.Baseflashing = Convert.ToString(dt.Rows[0]["Baseflashing"]);
obj_pro.Counterflashing = Convert.ToString(dt.Rows[0]["Counterflashing"]);
obj_pro.Asbestos = Convert.ToString(dt.Rows[0]["Asbestos"]);
obj_pro.Subroofs = Convert.ToString(dt.Rows[0]["Subroofs"]);
obj_pro.Interiorparapet = Convert.ToString(dt.Rows[0]["Interiorparapet"]);
obj_pro.Coping = Convert.ToString(dt.Rows[0]["Coping"]);
obj_pro.Railings = Convert.ToString(dt.Rows[0]["Railings"]);
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
public Int32 insert(proposalchecklistflatroofClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistflatroof_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalchecklistid = Convert.ToInt32(obj_con.getValue("@Proposalchecklistid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistflatroof_insert");
}
}

//update data into database 
public Int32 update(proposalchecklistflatroofClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistflatroof_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalchecklistid = Convert.ToInt32(obj_con.getValue("@Proposalchecklistid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistflatroof_update");
}
}

//delete data from database 
public void delete(Int32 Proposalchecklistid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Proposalchecklistid", Proposalchecklistid );
obj_con.ExecuteNoneQuery("sp_proposalchecklistflatroof_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistflatroof_delete");
}
}

//select all data from database 
public List<proposalchecklistflatroofClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistflatroof_selectall");
}
}

//select data from database as Paging
public List<proposalchecklistflatroofClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_proposalchecklistflatroof_selectPaging");
	 }
}

	 public List<proposalchecklistflatroofClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistflatroof_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistflatroof_selectIndexPaging");
		 }
	 }
	 public List<proposalchecklistflatroofClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<proposalchecklistflatroofClass> selectlist(Int32 Proposalchecklistid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalchecklistid", Proposalchecklistid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistflatroof_select");
}
}

//select data from database as Objject
public proposalchecklistflatroofClass selectById(Int32 Proposalchecklistid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalchecklistid", Proposalchecklistid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistflatroof_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Proposalchecklistid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalchecklistid", Proposalchecklistid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistflatroof_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistflatroof_select");
}
}

//create parameter 
public void createParameter(proposalchecklistflatroofClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Insualtion", string.IsNullOrEmpty(Convert.ToString(obj.Insualtion)) ? "" : obj.Insualtion);
obj_con.addParameter("@Deck", string.IsNullOrEmpty(Convert.ToString(obj.Deck)) ? "" : obj.Deck);
obj_con.addParameter("@Noofdrains", string.IsNullOrEmpty(Convert.ToString(obj.Noofdrains)) ? 0 : obj.Noofdrains);
obj_con.addParameter("@Protrusions", string.IsNullOrEmpty(Convert.ToString(obj.Protrusions)) ? "" : obj.Protrusions);
obj_con.addParameter("@Baseflashing", string.IsNullOrEmpty(Convert.ToString(obj.Baseflashing)) ? "" : obj.Baseflashing);
obj_con.addParameter("@Counterflashing", string.IsNullOrEmpty(Convert.ToString(obj.Counterflashing)) ? "" : obj.Counterflashing);
obj_con.addParameter("@Asbestos", string.IsNullOrEmpty(Convert.ToString(obj.Asbestos)) ? "" : obj.Asbestos);
obj_con.addParameter("@Subroofs", string.IsNullOrEmpty(Convert.ToString(obj.Subroofs)) ? "" : obj.Subroofs);
obj_con.addParameter("@Interiorparapet", string.IsNullOrEmpty(Convert.ToString(obj.Interiorparapet)) ? "" : obj.Interiorparapet);
obj_con.addParameter("@Coping", string.IsNullOrEmpty(Convert.ToString(obj.Coping)) ? "" : obj.Coping);
obj_con.addParameter("@Railings", string.IsNullOrEmpty(Convert.ToString(obj.Railings)) ? "" : obj.Railings);
obj_con.addParameter("@Access", string.IsNullOrEmpty(Convert.ToString(obj.Access)) ? "" : obj.Access);
obj_con.addParameter("@Chimneys", string.IsNullOrEmpty(Convert.ToString(obj.Chimneys)) ? "" : obj.Chimneys);
obj_con.addParameter("@Dumpsters", string.IsNullOrEmpty(Convert.ToString(obj.Dumpsters)) ? "" : obj.Dumpsters);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Proposalchecklistid", obj.Proposalchecklistid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public proposalchecklistflatroofClass updateObject(proposalchecklistflatroofClass  obj)
{
try
{

	 proposalchecklistflatroofClass oldObj = selectById(obj.Proposalchecklistid);
 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Insualtion == null || obj.Insualtion.ToString().Trim() == "update")
	 obj.Insualtion = oldObj.Insualtion; 

 if (obj.Deck == null || obj.Deck.ToString().Trim() == "update")
	 obj.Deck = oldObj.Deck; 

 if (obj.Noofdrains == null || obj.Noofdrains.ToString().Trim() == "0")
	 obj.Noofdrains = oldObj.Noofdrains; 

 if (obj.Protrusions == null || obj.Protrusions.ToString().Trim() == "update")
	 obj.Protrusions = oldObj.Protrusions; 

 if (obj.Baseflashing == null || obj.Baseflashing.ToString().Trim() == "update")
	 obj.Baseflashing = oldObj.Baseflashing; 

 if (obj.Counterflashing == null || obj.Counterflashing.ToString().Trim() == "update")
	 obj.Counterflashing = oldObj.Counterflashing; 

 if (obj.Asbestos == null || obj.Asbestos.ToString().Trim() == "update")
	 obj.Asbestos = oldObj.Asbestos; 

 if (obj.Subroofs == null || obj.Subroofs.ToString().Trim() == "update")
	 obj.Subroofs = oldObj.Subroofs; 

 if (obj.Interiorparapet == null || obj.Interiorparapet.ToString().Trim() == "update")
	 obj.Interiorparapet = oldObj.Interiorparapet; 

 if (obj.Coping == null || obj.Coping.ToString().Trim() == "update")
	 obj.Coping = oldObj.Coping; 

 if (obj.Railings == null || obj.Railings.ToString().Trim() == "update")
	 obj.Railings = oldObj.Railings; 

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
 public List<proposalchecklistflatroofClass> ConvertToList(DataTable dt)
{
 List<proposalchecklistflatroofClass> proposalchecklistflatrooflist = new List<proposalchecklistflatroofClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
proposalchecklistflatroofClass obj_proposalchecklistflatroof = new proposalchecklistflatroofClass();

		 if (Convert.ToString(dt.Rows[i]["Proposalchecklistid"]) != "")
			obj_proposalchecklistflatroof.Proposalchecklistid = Convert.ToInt32(dt.Rows[i]["Proposalchecklistid"]);
	 else
			 obj_proposalchecklistflatroof.Proposalchecklistid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistflatroof.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistflatroof.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Insualtion"]) != "")
			obj_proposalchecklistflatroof.Insualtion = Convert.ToString(dt.Rows[i]["Insualtion"]);
	 else
			 obj_proposalchecklistflatroof.Insualtion = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deck"]) != "")
			obj_proposalchecklistflatroof.Deck = Convert.ToString(dt.Rows[i]["Deck"]);
	 else
			 obj_proposalchecklistflatroof.Deck = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrains"]) != "")
			obj_proposalchecklistflatroof.Noofdrains = Convert.ToInt32(dt.Rows[i]["Noofdrains"]);
	 else
			 obj_proposalchecklistflatroof.Noofdrains = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Protrusions"]) != "")
			obj_proposalchecklistflatroof.Protrusions = Convert.ToString(dt.Rows[i]["Protrusions"]);
	 else
			 obj_proposalchecklistflatroof.Protrusions = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Baseflashing"]) != "")
			obj_proposalchecklistflatroof.Baseflashing = Convert.ToString(dt.Rows[i]["Baseflashing"]);
	 else
			 obj_proposalchecklistflatroof.Baseflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Counterflashing"]) != "")
			obj_proposalchecklistflatroof.Counterflashing = Convert.ToString(dt.Rows[i]["Counterflashing"]);
	 else
			 obj_proposalchecklistflatroof.Counterflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Asbestos"]) != "")
			obj_proposalchecklistflatroof.Asbestos = Convert.ToString(dt.Rows[i]["Asbestos"]);
	 else
			 obj_proposalchecklistflatroof.Asbestos = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Subroofs"]) != "")
			obj_proposalchecklistflatroof.Subroofs = Convert.ToString(dt.Rows[i]["Subroofs"]);
	 else
			 obj_proposalchecklistflatroof.Subroofs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Interiorparapet"]) != "")
			obj_proposalchecklistflatroof.Interiorparapet = Convert.ToString(dt.Rows[i]["Interiorparapet"]);
	 else
			 obj_proposalchecklistflatroof.Interiorparapet = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Coping"]) != "")
			obj_proposalchecklistflatroof.Coping = Convert.ToString(dt.Rows[i]["Coping"]);
	 else
			 obj_proposalchecklistflatroof.Coping = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Railings"]) != "")
			obj_proposalchecklistflatroof.Railings = Convert.ToString(dt.Rows[i]["Railings"]);
	 else
			 obj_proposalchecklistflatroof.Railings = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Access"]) != "")
			obj_proposalchecklistflatroof.Access = Convert.ToString(dt.Rows[i]["Access"]);
	 else
			 obj_proposalchecklistflatroof.Access = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chimneys"]) != "")
			obj_proposalchecklistflatroof.Chimneys = Convert.ToString(dt.Rows[i]["Chimneys"]);
	 else
			 obj_proposalchecklistflatroof.Chimneys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistflatroof.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistflatroof.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistflatroof.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistflatroof.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistflatroof.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistflatroof.Inserteddatetime = Convert.ToDateTime("01/01/1900");


proposalchecklistflatrooflist.Add(obj_proposalchecklistflatroof);
}
return proposalchecklistflatrooflist;
}

//Convert DataTable To object method
 public proposalchecklistflatroofClass ConvertToOjbect(DataTable dt)
{
 proposalchecklistflatroofClass obj_proposalchecklistflatroof = new proposalchecklistflatroofClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Proposalchecklistid"]) != "")
			obj_proposalchecklistflatroof.Proposalchecklistid = Convert.ToInt32(dt.Rows[i]["Proposalchecklistid"]);
	 else
			 obj_proposalchecklistflatroof.Proposalchecklistid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistflatroof.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistflatroof.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Insualtion"]) != "")
			obj_proposalchecklistflatroof.Insualtion = Convert.ToString(dt.Rows[i]["Insualtion"]);
	 else
			 obj_proposalchecklistflatroof.Insualtion = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deck"]) != "")
			obj_proposalchecklistflatroof.Deck = Convert.ToString(dt.Rows[i]["Deck"]);
	 else
			 obj_proposalchecklistflatroof.Deck = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrains"]) != "")
			obj_proposalchecklistflatroof.Noofdrains = Convert.ToInt32(dt.Rows[i]["Noofdrains"]);
	 else
			 obj_proposalchecklistflatroof.Noofdrains = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Protrusions"]) != "")
			obj_proposalchecklistflatroof.Protrusions = Convert.ToString(dt.Rows[i]["Protrusions"]);
	 else
			 obj_proposalchecklistflatroof.Protrusions = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Baseflashing"]) != "")
			obj_proposalchecklistflatroof.Baseflashing = Convert.ToString(dt.Rows[i]["Baseflashing"]);
	 else
			 obj_proposalchecklistflatroof.Baseflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Counterflashing"]) != "")
			obj_proposalchecklistflatroof.Counterflashing = Convert.ToString(dt.Rows[i]["Counterflashing"]);
	 else
			 obj_proposalchecklistflatroof.Counterflashing = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Asbestos"]) != "")
			obj_proposalchecklistflatroof.Asbestos = Convert.ToString(dt.Rows[i]["Asbestos"]);
	 else
			 obj_proposalchecklistflatroof.Asbestos = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Subroofs"]) != "")
			obj_proposalchecklistflatroof.Subroofs = Convert.ToString(dt.Rows[i]["Subroofs"]);
	 else
			 obj_proposalchecklistflatroof.Subroofs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Interiorparapet"]) != "")
			obj_proposalchecklistflatroof.Interiorparapet = Convert.ToString(dt.Rows[i]["Interiorparapet"]);
	 else
			 obj_proposalchecklistflatroof.Interiorparapet = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Coping"]) != "")
			obj_proposalchecklistflatroof.Coping = Convert.ToString(dt.Rows[i]["Coping"]);
	 else
			 obj_proposalchecklistflatroof.Coping = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Railings"]) != "")
			obj_proposalchecklistflatroof.Railings = Convert.ToString(dt.Rows[i]["Railings"]);
	 else
			 obj_proposalchecklistflatroof.Railings = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Access"]) != "")
			obj_proposalchecklistflatroof.Access = Convert.ToString(dt.Rows[i]["Access"]);
	 else
			 obj_proposalchecklistflatroof.Access = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chimneys"]) != "")
			obj_proposalchecklistflatroof.Chimneys = Convert.ToString(dt.Rows[i]["Chimneys"]);
	 else
			 obj_proposalchecklistflatroof.Chimneys = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistflatroof.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistflatroof.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistflatroof.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistflatroof.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistflatroof.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistflatroof.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_proposalchecklistflatroof;
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
