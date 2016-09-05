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
	public class proposalchecklistexteriorwallsClass
    {
		#region "properties"
			public Int32  Proposalcheckexteriorwallsid {get;set;}
public Int32  Buildingid {get;set;}
public string  Sidewalkbridge {get;set;}
public string  Scaffold {get;set;}
public string  Hoist {get;set;}
public Int32  Noofdrops {get;set;}
public Int32  Nooflintels {get;set;}
public string  Qtycaulking {get;set;}
public string  Dutchmanrepairs {get;set;}
public Int32  Nosillsreplacescapped {get;set;}
public string  Metalpanelreplaced {get;set;}
public string  Stonereplacement {get;set;}
public string  Brickreplacement {get;set;}
public string  Chute {get;set;}
public Int32  Noofwythes {get;set;}
public string  Dumpsters {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public proposalchecklistexteriorwallsClass(){
		 
			Proposalcheckexteriorwallsid = 0;
			Buildingid = 0;
			Sidewalkbridge = "update";
			Scaffold = "update";
			Hoist = "update";
			Noofdrops = 0;
			Nooflintels = 0;
			Qtycaulking = "update";
			Dutchmanrepairs = "update";
			Nosillsreplacescapped = 0;
			Metalpanelreplaced = "update";
			Stonereplacement = "update";
			Brickreplacement = "update";
			Chute = "update";
			Noofwythes = 0;
			Dumpsters = "update";
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class proposalchecklistexteriorwallsCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public proposalchecklistexteriorwallsCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public proposalchecklistexteriorwallsCtl(Int32 id)
{
obj_con = new ConnectionCls();
proposalchecklistexteriorwallsClass  obj_pro= new proposalchecklistexteriorwallsClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_pro.Proposalcheckexteriorwallsid = Convert.ToInt32(dt.Rows[0]["Proposalcheckexteriorwallsid"]);
obj_pro.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_pro.Sidewalkbridge = Convert.ToString(dt.Rows[0]["Sidewalkbridge"]);
obj_pro.Scaffold = Convert.ToString(dt.Rows[0]["Scaffold"]);
obj_pro.Hoist = Convert.ToString(dt.Rows[0]["Hoist"]);
obj_pro.Noofdrops = Convert.ToInt32(dt.Rows[0]["Noofdrops"]);
obj_pro.Nooflintels = Convert.ToInt32(dt.Rows[0]["Nooflintels"]);
obj_pro.Qtycaulking = Convert.ToString(dt.Rows[0]["Qtycaulking"]);
obj_pro.Dutchmanrepairs = Convert.ToString(dt.Rows[0]["Dutchmanrepairs"]);
obj_pro.Nosillsreplacescapped = Convert.ToInt32(dt.Rows[0]["Nosillsreplacescapped"]);
obj_pro.Metalpanelreplaced = Convert.ToString(dt.Rows[0]["Metalpanelreplaced"]);
obj_pro.Stonereplacement = Convert.ToString(dt.Rows[0]["Stonereplacement"]);
obj_pro.Brickreplacement = Convert.ToString(dt.Rows[0]["Brickreplacement"]);
obj_pro.Chute = Convert.ToString(dt.Rows[0]["Chute"]);
obj_pro.Noofwythes = Convert.ToInt32(dt.Rows[0]["Noofwythes"]);
obj_pro.Dumpsters = Convert.ToString(dt.Rows[0]["Dumpsters"]);
obj_pro.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_pro.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(proposalchecklistexteriorwallsClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistexteriorwalls_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalcheckexteriorwallsid = Convert.ToInt32(obj_con.getValue("@Proposalcheckexteriorwallsid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistexteriorwalls_insert");
}
}

//update data into database 
public Int32 update(proposalchecklistexteriorwallsClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_proposalchecklistexteriorwalls_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Proposalcheckexteriorwallsid = Convert.ToInt32(obj_con.getValue("@Proposalcheckexteriorwallsid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistexteriorwalls_update");
}
}

//delete data from database 
public void delete(Int32 Proposalcheckexteriorwallsid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Proposalcheckexteriorwallsid", Proposalcheckexteriorwallsid );
obj_con.ExecuteNoneQuery("sp_proposalchecklistexteriorwalls_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_proposalchecklistexteriorwalls_delete");
}
}

//select all data from database 
public List<proposalchecklistexteriorwallsClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistexteriorwalls_selectall");
}
}

//select data from database as Paging
public List<proposalchecklistexteriorwallsClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_proposalchecklistexteriorwalls_selectPaging");
	 }
}

	 public List<proposalchecklistexteriorwallsClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistexteriorwalls_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_proposalchecklistexteriorwalls_selectIndexPaging");
		 }
	 }
	 public List<proposalchecklistexteriorwallsClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<proposalchecklistexteriorwallsClass> selectlist(Int32 Proposalcheckexteriorwallsid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckexteriorwallsid", Proposalcheckexteriorwallsid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistexteriorwalls_select");
}
}

//select data from database as Objject
public proposalchecklistexteriorwallsClass selectById(Int32 Proposalcheckexteriorwallsid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckexteriorwallsid", Proposalcheckexteriorwallsid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistexteriorwalls_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Proposalcheckexteriorwallsid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Proposalcheckexteriorwallsid", Proposalcheckexteriorwallsid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_proposalchecklistexteriorwalls_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_proposalchecklistexteriorwalls_select");
}
}

//create parameter 
public void createParameter(proposalchecklistexteriorwallsClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Sidewalkbridge", string.IsNullOrEmpty(Convert.ToString(obj.Sidewalkbridge)) ? "" : obj.Sidewalkbridge);
obj_con.addParameter("@Scaffold", string.IsNullOrEmpty(Convert.ToString(obj.Scaffold)) ? "" : obj.Scaffold);
obj_con.addParameter("@Hoist", string.IsNullOrEmpty(Convert.ToString(obj.Hoist)) ? "" : obj.Hoist);
obj_con.addParameter("@Noofdrops", string.IsNullOrEmpty(Convert.ToString(obj.Noofdrops)) ? 0 : obj.Noofdrops);
obj_con.addParameter("@Nooflintels", string.IsNullOrEmpty(Convert.ToString(obj.Nooflintels)) ? 0 : obj.Nooflintels);
obj_con.addParameter("@Qtycaulking", string.IsNullOrEmpty(Convert.ToString(obj.Qtycaulking)) ? "" : obj.Qtycaulking);
obj_con.addParameter("@Dutchmanrepairs", string.IsNullOrEmpty(Convert.ToString(obj.Dutchmanrepairs)) ? "" : obj.Dutchmanrepairs);
obj_con.addParameter("@Nosillsreplacescapped", string.IsNullOrEmpty(Convert.ToString(obj.Nosillsreplacescapped)) ? 0 : obj.Nosillsreplacescapped);
obj_con.addParameter("@Metalpanelreplaced", string.IsNullOrEmpty(Convert.ToString(obj.Metalpanelreplaced)) ? "" : obj.Metalpanelreplaced);
obj_con.addParameter("@Stonereplacement", string.IsNullOrEmpty(Convert.ToString(obj.Stonereplacement)) ? "" : obj.Stonereplacement);
obj_con.addParameter("@Brickreplacement", string.IsNullOrEmpty(Convert.ToString(obj.Brickreplacement)) ? "" : obj.Brickreplacement);
obj_con.addParameter("@Chute", string.IsNullOrEmpty(Convert.ToString(obj.Chute)) ? "" : obj.Chute);
obj_con.addParameter("@Noofwythes", string.IsNullOrEmpty(Convert.ToString(obj.Noofwythes)) ? 0 : obj.Noofwythes);
obj_con.addParameter("@Dumpsters", string.IsNullOrEmpty(Convert.ToString(obj.Dumpsters)) ? "" : obj.Dumpsters);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Proposalcheckexteriorwallsid", obj.Proposalcheckexteriorwallsid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public proposalchecklistexteriorwallsClass updateObject(proposalchecklistexteriorwallsClass  obj)
{
try
{

	 proposalchecklistexteriorwallsClass oldObj = selectById(obj.Proposalcheckexteriorwallsid);
 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Sidewalkbridge == null || obj.Sidewalkbridge.ToString().Trim() == "update")
	 obj.Sidewalkbridge = oldObj.Sidewalkbridge; 

 if (obj.Scaffold == null || obj.Scaffold.ToString().Trim() == "update")
	 obj.Scaffold = oldObj.Scaffold; 

 if (obj.Hoist == null || obj.Hoist.ToString().Trim() == "update")
	 obj.Hoist = oldObj.Hoist; 

 if (obj.Noofdrops == null || obj.Noofdrops.ToString().Trim() == "0")
	 obj.Noofdrops = oldObj.Noofdrops; 

 if (obj.Nooflintels == null || obj.Nooflintels.ToString().Trim() == "0")
	 obj.Nooflintels = oldObj.Nooflintels; 

 if (obj.Qtycaulking == null || obj.Qtycaulking.ToString().Trim() == "update")
	 obj.Qtycaulking = oldObj.Qtycaulking; 

 if (obj.Dutchmanrepairs == null || obj.Dutchmanrepairs.ToString().Trim() == "update")
	 obj.Dutchmanrepairs = oldObj.Dutchmanrepairs; 

 if (obj.Nosillsreplacescapped == null || obj.Nosillsreplacescapped.ToString().Trim() == "0")
	 obj.Nosillsreplacescapped = oldObj.Nosillsreplacescapped; 

 if (obj.Metalpanelreplaced == null || obj.Metalpanelreplaced.ToString().Trim() == "update")
	 obj.Metalpanelreplaced = oldObj.Metalpanelreplaced; 

 if (obj.Stonereplacement == null || obj.Stonereplacement.ToString().Trim() == "update")
	 obj.Stonereplacement = oldObj.Stonereplacement; 

 if (obj.Brickreplacement == null || obj.Brickreplacement.ToString().Trim() == "update")
	 obj.Brickreplacement = oldObj.Brickreplacement; 

 if (obj.Chute == null || obj.Chute.ToString().Trim() == "update")
	 obj.Chute = oldObj.Chute; 

 if (obj.Noofwythes == null || obj.Noofwythes.ToString().Trim() == "0")
	 obj.Noofwythes = oldObj.Noofwythes; 

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
 public List<proposalchecklistexteriorwallsClass> ConvertToList(DataTable dt)
{
 List<proposalchecklistexteriorwallsClass> proposalchecklistexteriorwallslist = new List<proposalchecklistexteriorwallsClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
proposalchecklistexteriorwallsClass obj_proposalchecklistexteriorwalls = new proposalchecklistexteriorwallsClass();

		 if (Convert.ToString(dt.Rows[i]["Proposalcheckexteriorwallsid"]) != "")
			obj_proposalchecklistexteriorwalls.Proposalcheckexteriorwallsid = Convert.ToInt32(dt.Rows[i]["Proposalcheckexteriorwallsid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Proposalcheckexteriorwallsid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistexteriorwalls.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Sidewalkbridge"]) != "")
			obj_proposalchecklistexteriorwalls.Sidewalkbridge = Convert.ToString(dt.Rows[i]["Sidewalkbridge"]);
	 else
			 obj_proposalchecklistexteriorwalls.Sidewalkbridge = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Scaffold"]) != "")
			obj_proposalchecklistexteriorwalls.Scaffold = Convert.ToString(dt.Rows[i]["Scaffold"]);
	 else
			 obj_proposalchecklistexteriorwalls.Scaffold = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Hoist"]) != "")
			obj_proposalchecklistexteriorwalls.Hoist = Convert.ToString(dt.Rows[i]["Hoist"]);
	 else
			 obj_proposalchecklistexteriorwalls.Hoist = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrops"]) != "")
			obj_proposalchecklistexteriorwalls.Noofdrops = Convert.ToInt32(dt.Rows[i]["Noofdrops"]);
	 else
			 obj_proposalchecklistexteriorwalls.Noofdrops = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Nooflintels"]) != "")
			obj_proposalchecklistexteriorwalls.Nooflintels = Convert.ToInt32(dt.Rows[i]["Nooflintels"]);
	 else
			 obj_proposalchecklistexteriorwalls.Nooflintels = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Qtycaulking"]) != "")
			obj_proposalchecklistexteriorwalls.Qtycaulking = Convert.ToString(dt.Rows[i]["Qtycaulking"]);
	 else
			 obj_proposalchecklistexteriorwalls.Qtycaulking = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dutchmanrepairs"]) != "")
			obj_proposalchecklistexteriorwalls.Dutchmanrepairs = Convert.ToString(dt.Rows[i]["Dutchmanrepairs"]);
	 else
			 obj_proposalchecklistexteriorwalls.Dutchmanrepairs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Nosillsreplacescapped"]) != "")
			obj_proposalchecklistexteriorwalls.Nosillsreplacescapped = Convert.ToInt32(dt.Rows[i]["Nosillsreplacescapped"]);
	 else
			 obj_proposalchecklistexteriorwalls.Nosillsreplacescapped = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Metalpanelreplaced"]) != "")
			obj_proposalchecklistexteriorwalls.Metalpanelreplaced = Convert.ToString(dt.Rows[i]["Metalpanelreplaced"]);
	 else
			 obj_proposalchecklistexteriorwalls.Metalpanelreplaced = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stonereplacement"]) != "")
			obj_proposalchecklistexteriorwalls.Stonereplacement = Convert.ToString(dt.Rows[i]["Stonereplacement"]);
	 else
			 obj_proposalchecklistexteriorwalls.Stonereplacement = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Brickreplacement"]) != "")
			obj_proposalchecklistexteriorwalls.Brickreplacement = Convert.ToString(dt.Rows[i]["Brickreplacement"]);
	 else
			 obj_proposalchecklistexteriorwalls.Brickreplacement = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chute"]) != "")
			obj_proposalchecklistexteriorwalls.Chute = Convert.ToString(dt.Rows[i]["Chute"]);
	 else
			 obj_proposalchecklistexteriorwalls.Chute = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofwythes"]) != "")
			obj_proposalchecklistexteriorwalls.Noofwythes = Convert.ToInt32(dt.Rows[i]["Noofwythes"]);
	 else
			 obj_proposalchecklistexteriorwalls.Noofwythes = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistexteriorwalls.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistexteriorwalls.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistexteriorwalls.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistexteriorwalls.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistexteriorwalls.Inserteddatetime = Convert.ToDateTime("01/01/1900");


proposalchecklistexteriorwallslist.Add(obj_proposalchecklistexteriorwalls);
}
return proposalchecklistexteriorwallslist;
}

//Convert DataTable To object method
 public proposalchecklistexteriorwallsClass ConvertToOjbect(DataTable dt)
{
 proposalchecklistexteriorwallsClass obj_proposalchecklistexteriorwalls = new proposalchecklistexteriorwallsClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Proposalcheckexteriorwallsid"]) != "")
			obj_proposalchecklistexteriorwalls.Proposalcheckexteriorwallsid = Convert.ToInt32(dt.Rows[i]["Proposalcheckexteriorwallsid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Proposalcheckexteriorwallsid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_proposalchecklistexteriorwalls.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Sidewalkbridge"]) != "")
			obj_proposalchecklistexteriorwalls.Sidewalkbridge = Convert.ToString(dt.Rows[i]["Sidewalkbridge"]);
	 else
			 obj_proposalchecklistexteriorwalls.Sidewalkbridge = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Scaffold"]) != "")
			obj_proposalchecklistexteriorwalls.Scaffold = Convert.ToString(dt.Rows[i]["Scaffold"]);
	 else
			 obj_proposalchecklistexteriorwalls.Scaffold = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Hoist"]) != "")
			obj_proposalchecklistexteriorwalls.Hoist = Convert.ToString(dt.Rows[i]["Hoist"]);
	 else
			 obj_proposalchecklistexteriorwalls.Hoist = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofdrops"]) != "")
			obj_proposalchecklistexteriorwalls.Noofdrops = Convert.ToInt32(dt.Rows[i]["Noofdrops"]);
	 else
			 obj_proposalchecklistexteriorwalls.Noofdrops = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Nooflintels"]) != "")
			obj_proposalchecklistexteriorwalls.Nooflintels = Convert.ToInt32(dt.Rows[i]["Nooflintels"]);
	 else
			 obj_proposalchecklistexteriorwalls.Nooflintels = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Qtycaulking"]) != "")
			obj_proposalchecklistexteriorwalls.Qtycaulking = Convert.ToString(dt.Rows[i]["Qtycaulking"]);
	 else
			 obj_proposalchecklistexteriorwalls.Qtycaulking = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Dutchmanrepairs"]) != "")
			obj_proposalchecklistexteriorwalls.Dutchmanrepairs = Convert.ToString(dt.Rows[i]["Dutchmanrepairs"]);
	 else
			 obj_proposalchecklistexteriorwalls.Dutchmanrepairs = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Nosillsreplacescapped"]) != "")
			obj_proposalchecklistexteriorwalls.Nosillsreplacescapped = Convert.ToInt32(dt.Rows[i]["Nosillsreplacescapped"]);
	 else
			 obj_proposalchecklistexteriorwalls.Nosillsreplacescapped = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Metalpanelreplaced"]) != "")
			obj_proposalchecklistexteriorwalls.Metalpanelreplaced = Convert.ToString(dt.Rows[i]["Metalpanelreplaced"]);
	 else
			 obj_proposalchecklistexteriorwalls.Metalpanelreplaced = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stonereplacement"]) != "")
			obj_proposalchecklistexteriorwalls.Stonereplacement = Convert.ToString(dt.Rows[i]["Stonereplacement"]);
	 else
			 obj_proposalchecklistexteriorwalls.Stonereplacement = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Brickreplacement"]) != "")
			obj_proposalchecklistexteriorwalls.Brickreplacement = Convert.ToString(dt.Rows[i]["Brickreplacement"]);
	 else
			 obj_proposalchecklistexteriorwalls.Brickreplacement = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Chute"]) != "")
			obj_proposalchecklistexteriorwalls.Chute = Convert.ToString(dt.Rows[i]["Chute"]);
	 else
			 obj_proposalchecklistexteriorwalls.Chute = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Noofwythes"]) != "")
			obj_proposalchecklistexteriorwalls.Noofwythes = Convert.ToInt32(dt.Rows[i]["Noofwythes"]);
	 else
			 obj_proposalchecklistexteriorwalls.Noofwythes = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Dumpsters"]) != "")
			obj_proposalchecklistexteriorwalls.Dumpsters = Convert.ToString(dt.Rows[i]["Dumpsters"]);
	 else
			 obj_proposalchecklistexteriorwalls.Dumpsters = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_proposalchecklistexteriorwalls.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_proposalchecklistexteriorwalls.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_proposalchecklistexteriorwalls.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_proposalchecklistexteriorwalls.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_proposalchecklistexteriorwalls;
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
