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
	public class clientClass
    {
		#region "properties"
			public Int32  Clientid {get;set;}
public string  Clientname {get;set;}
public string  Clientcode {get;set;}
public string  Clientshortname {get;set;}
public string  Addressline1 {get;set;}
public string  Addressline2 {get;set;}
public string  Locationcity {get;set;}
public Int32  Stateid {get;set;}
public string  Locationzip {get;set;}
public Int32  Budgetstartmonth {get;set;}


	 public clientClass(){
		 
			Clientid = 0;
			Clientname = "update";
			Clientcode = "update";
			Clientshortname = "update";
			Addressline1 = "update";
			Addressline2 = "update";
			Locationcity = "update";
			Stateid = 0;
			Locationzip = "update";
			Budgetstartmonth = 0;
	 }
		#endregion
    }

	public class clientCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public clientCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public clientCtl(Int32 id)
{
obj_con = new ConnectionCls();
clientClass  obj_cli= new clientClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_cli.Clientid = Convert.ToInt32(dt.Rows[0]["Clientid"]);
obj_cli.Clientname = Convert.ToString(dt.Rows[0]["Clientname"]);
obj_cli.Clientcode = Convert.ToString(dt.Rows[0]["Clientcode"]);
obj_cli.Clientshortname = Convert.ToString(dt.Rows[0]["Clientshortname"]);
obj_cli.Addressline1 = Convert.ToString(dt.Rows[0]["Addressline1"]);
obj_cli.Addressline2 = Convert.ToString(dt.Rows[0]["Addressline2"]);
obj_cli.Locationcity = Convert.ToString(dt.Rows[0]["Locationcity"]);
obj_cli.Stateid = Convert.ToInt32(dt.Rows[0]["Stateid"]);
obj_cli.Locationzip = Convert.ToString(dt.Rows[0]["Locationzip"]);
obj_cli.Budgetstartmonth = Convert.ToInt32(dt.Rows[0]["Budgetstartmonth"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(clientClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_client_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Clientid = Convert.ToInt32(obj_con.getValue("@Clientid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_client_insert");
}
}

//update data into database 
public Int32 update(clientClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_client_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Clientid = Convert.ToInt32(obj_con.getValue("@Clientid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_client_update");
}
}

//delete data from database 
public void delete(Int32 Clientid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Clientid", Clientid );
obj_con.ExecuteNoneQuery("sp_client_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_client_delete");
}
}

//select all data from database 
public List<clientClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_client_selectall");
}
}

//select data from database as Paging
public List<clientClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_client_selectPaging");
	 }
}

	 public List<clientClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_client_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_client_selectIndexPaging");
		 }
	 }
	 public List<clientClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<clientClass> selectlist(Int32 Clientid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Clientid", Clientid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_client_select");
}
}

//select data from database as Objject
public clientClass selectById(Int32 Clientid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Clientid", Clientid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_client_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Clientid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Clientid", Clientid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_client_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_client_select");
}
}

//create parameter 
public void createParameter(clientClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Clientname", string.IsNullOrEmpty(Convert.ToString(obj.Clientname)) ? "" : obj.Clientname);
obj_con.addParameter("@Clientcode", string.IsNullOrEmpty(Convert.ToString(obj.Clientcode)) ? "" : obj.Clientcode);
obj_con.addParameter("@Clientshortname", string.IsNullOrEmpty(Convert.ToString(obj.Clientshortname)) ? "" : obj.Clientshortname);
obj_con.addParameter("@Addressline1", string.IsNullOrEmpty(Convert.ToString(obj.Addressline1)) ? "" : obj.Addressline1);
obj_con.addParameter("@Addressline2", string.IsNullOrEmpty(Convert.ToString(obj.Addressline2)) ? "" : obj.Addressline2);
obj_con.addParameter("@Locationcity", string.IsNullOrEmpty(Convert.ToString(obj.Locationcity)) ? "" : obj.Locationcity);
obj_con.addParameter("@Stateid", string.IsNullOrEmpty(Convert.ToString(obj.Stateid)) ? 0 : obj.Stateid);
obj_con.addParameter("@Locationzip", string.IsNullOrEmpty(Convert.ToString(obj.Locationzip)) ? "" : obj.Locationzip);
obj_con.addParameter("@Budgetstartmonth", string.IsNullOrEmpty(Convert.ToString(obj.Budgetstartmonth)) ? 0 : obj.Budgetstartmonth);
obj_con.addParameter("@Clientid", obj.Clientid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public clientClass updateObject(clientClass  obj)
{
try
{

	 clientClass oldObj = selectById(obj.Clientid);
 if (obj.Clientname == null || obj.Clientname.ToString().Trim() == "update")
	 obj.Clientname = oldObj.Clientname; 

 if (obj.Clientcode == null || obj.Clientcode.ToString().Trim() == "update")
	 obj.Clientcode = oldObj.Clientcode; 

 if (obj.Clientshortname == null || obj.Clientshortname.ToString().Trim() == "update")
	 obj.Clientshortname = oldObj.Clientshortname; 

 if (obj.Addressline1 == null || obj.Addressline1.ToString().Trim() == "update")
	 obj.Addressline1 = oldObj.Addressline1; 

 if (obj.Addressline2 == null || obj.Addressline2.ToString().Trim() == "update")
	 obj.Addressline2 = oldObj.Addressline2; 

 if (obj.Locationcity == null || obj.Locationcity.ToString().Trim() == "update")
	 obj.Locationcity = oldObj.Locationcity; 

 if (obj.Stateid == null || obj.Stateid.ToString().Trim() == "0")
	 obj.Stateid = oldObj.Stateid; 

 if (obj.Locationzip == null || obj.Locationzip.ToString().Trim() == "update")
	 obj.Locationzip = oldObj.Locationzip; 

 if (obj.Budgetstartmonth == null || obj.Budgetstartmonth.ToString().Trim() == "0")
	 obj.Budgetstartmonth = oldObj.Budgetstartmonth; 

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
 public List<clientClass> ConvertToList(DataTable dt)
{
 List<clientClass> clientlist = new List<clientClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
clientClass obj_client = new clientClass();

		 if (Convert.ToString(dt.Rows[i]["Clientid"]) != "")
			obj_client.Clientid = Convert.ToInt32(dt.Rows[i]["Clientid"]);
	 else
			 obj_client.Clientid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Clientname"]) != "")
			obj_client.Clientname = Convert.ToString(dt.Rows[i]["Clientname"]);
	 else
			 obj_client.Clientname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Clientcode"]) != "")
			obj_client.Clientcode = Convert.ToString(dt.Rows[i]["Clientcode"]);
	 else
			 obj_client.Clientcode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Clientshortname"]) != "")
			obj_client.Clientshortname = Convert.ToString(dt.Rows[i]["Clientshortname"]);
	 else
			 obj_client.Clientshortname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_client.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_client.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_client.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_client.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_client.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_client.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_client.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_client.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_client.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_client.Locationzip = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Budgetstartmonth"]) != "")
			obj_client.Budgetstartmonth = Convert.ToInt32(dt.Rows[i]["Budgetstartmonth"]);
	 else
			 obj_client.Budgetstartmonth = Convert.ToInt32("0");


clientlist.Add(obj_client);
}
return clientlist;
}

//Convert DataTable To object method
 public clientClass ConvertToOjbect(DataTable dt)
{
 clientClass obj_client = new clientClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Clientid"]) != "")
			obj_client.Clientid = Convert.ToInt32(dt.Rows[i]["Clientid"]);
	 else
			 obj_client.Clientid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Clientname"]) != "")
			obj_client.Clientname = Convert.ToString(dt.Rows[i]["Clientname"]);
	 else
			 obj_client.Clientname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Clientcode"]) != "")
			obj_client.Clientcode = Convert.ToString(dt.Rows[i]["Clientcode"]);
	 else
			 obj_client.Clientcode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Clientshortname"]) != "")
			obj_client.Clientshortname = Convert.ToString(dt.Rows[i]["Clientshortname"]);
	 else
			 obj_client.Clientshortname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_client.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_client.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_client.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_client.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_client.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_client.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_client.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_client.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_client.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_client.Locationzip = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Budgetstartmonth"]) != "")
			obj_client.Budgetstartmonth = Convert.ToInt32(dt.Rows[i]["Budgetstartmonth"]);
	 else
			 obj_client.Budgetstartmonth = Convert.ToInt32("0");
}
return obj_client;
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
