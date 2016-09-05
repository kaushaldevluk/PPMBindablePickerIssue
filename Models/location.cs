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
	public class locationClass
    {
		#region "properties"
			public Int32  Locationid {get;set;}
public Int32  Clientid {get;set;}
public Int32  Institutionid {get;set;}
public string  Building {get;set;}
public Int32  Jobtypeid {get;set;}
public Int32  Jobstatusid {get;set;}
public string  Jobdetail {get;set;}


	 public locationClass(){
		 
			Locationid = 0;
			Clientid = 0;
			Institutionid = 0;
			Building = "update";
			Jobtypeid = 0;
			Jobstatusid = 0;
			Jobdetail = "update";
	 }
		#endregion
    }

	public class locationCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public locationCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public locationCtl(Int32 id)
{
obj_con = new ConnectionCls();
locationClass  obj_loc= new locationClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_loc.Locationid = Convert.ToInt32(dt.Rows[0]["Locationid"]);
obj_loc.Clientid = Convert.ToInt32(dt.Rows[0]["Clientid"]);
obj_loc.Institutionid = Convert.ToInt32(dt.Rows[0]["Institutionid"]);
obj_loc.Building = Convert.ToString(dt.Rows[0]["Building"]);
obj_loc.Jobtypeid = Convert.ToInt32(dt.Rows[0]["Jobtypeid"]);
obj_loc.Jobstatusid = Convert.ToInt32(dt.Rows[0]["Jobstatusid"]);
obj_loc.Jobdetail = Convert.ToString(dt.Rows[0]["Jobdetail"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(locationClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_location_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Locationid = Convert.ToInt32(obj_con.getValue("@Locationid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_location_insert");
}
}

//update data into database 
public Int32 update(locationClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_location_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Locationid = Convert.ToInt32(obj_con.getValue("@Locationid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_location_update");
}
}

//delete data from database 
public void delete(Int32 Locationid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Locationid", Locationid );
obj_con.ExecuteNoneQuery("sp_location_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_location_delete");
}
}

//select all data from database 
public List<locationClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_location_selectall");
}
}

//select data from database as Paging
public List<locationClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_location_selectPaging");
	 }
}

	 public List<locationClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_location_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_location_selectIndexPaging");
		 }
	 }
	 public List<locationClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<locationClass> selectlist(Int32 Locationid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationid", Locationid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_location_select");
}
}

//select data from database as Objject
public locationClass selectById(Int32 Locationid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationid", Locationid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_location_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Locationid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationid", Locationid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_location_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_location_select");
}
}

//create parameter 
public void createParameter(locationClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Clientid", string.IsNullOrEmpty(Convert.ToString(obj.Clientid)) ? 0 : obj.Clientid);
obj_con.addParameter("@Institutionid", string.IsNullOrEmpty(Convert.ToString(obj.Institutionid)) ? 0 : obj.Institutionid);
obj_con.addParameter("@Building", string.IsNullOrEmpty(Convert.ToString(obj.Building)) ? "" : obj.Building);
obj_con.addParameter("@Jobtypeid", string.IsNullOrEmpty(Convert.ToString(obj.Jobtypeid)) ? 0 : obj.Jobtypeid);
obj_con.addParameter("@Jobstatusid", string.IsNullOrEmpty(Convert.ToString(obj.Jobstatusid)) ? 0 : obj.Jobstatusid);
obj_con.addParameter("@Jobdetail", string.IsNullOrEmpty(Convert.ToString(obj.Jobdetail)) ? "" : obj.Jobdetail);
obj_con.addParameter("@Locationid", obj.Locationid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public locationClass updateObject(locationClass  obj)
{
try
{

	 locationClass oldObj = selectById(obj.Locationid);
 if (obj.Clientid == null || obj.Clientid.ToString().Trim() == "0")
	 obj.Clientid = oldObj.Clientid; 

 if (obj.Institutionid == null || obj.Institutionid.ToString().Trim() == "0")
	 obj.Institutionid = oldObj.Institutionid; 

 if (obj.Building == null || obj.Building.ToString().Trim() == "update")
	 obj.Building = oldObj.Building; 

 if (obj.Jobtypeid == null || obj.Jobtypeid.ToString().Trim() == "0")
	 obj.Jobtypeid = oldObj.Jobtypeid; 

 if (obj.Jobstatusid == null || obj.Jobstatusid.ToString().Trim() == "0")
	 obj.Jobstatusid = oldObj.Jobstatusid; 

 if (obj.Jobdetail == null || obj.Jobdetail.ToString().Trim() == "update")
	 obj.Jobdetail = oldObj.Jobdetail; 

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
 public List<locationClass> ConvertToList(DataTable dt)
{
 List<locationClass> locationlist = new List<locationClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
locationClass obj_location = new locationClass();

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_location.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_location.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Clientid"]) != "")
			obj_location.Clientid = Convert.ToInt32(dt.Rows[i]["Clientid"]);
	 else
			 obj_location.Clientid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutionid"]) != "")
			obj_location.Institutionid = Convert.ToInt32(dt.Rows[i]["Institutionid"]);
	 else
			 obj_location.Institutionid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Building"]) != "")
			obj_location.Building = Convert.ToString(dt.Rows[i]["Building"]);
	 else
			 obj_location.Building = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Jobtypeid"]) != "")
			obj_location.Jobtypeid = Convert.ToInt32(dt.Rows[i]["Jobtypeid"]);
	 else
			 obj_location.Jobtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobstatusid"]) != "")
			obj_location.Jobstatusid = Convert.ToInt32(dt.Rows[i]["Jobstatusid"]);
	 else
			 obj_location.Jobstatusid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobdetail"]) != "")
			obj_location.Jobdetail = Convert.ToString(dt.Rows[i]["Jobdetail"]);
	 else
			 obj_location.Jobdetail = Convert.ToString("");


locationlist.Add(obj_location);
}
return locationlist;
}

//Convert DataTable To object method
 public locationClass ConvertToOjbect(DataTable dt)
{
 locationClass obj_location = new locationClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_location.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_location.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Clientid"]) != "")
			obj_location.Clientid = Convert.ToInt32(dt.Rows[i]["Clientid"]);
	 else
			 obj_location.Clientid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutionid"]) != "")
			obj_location.Institutionid = Convert.ToInt32(dt.Rows[i]["Institutionid"]);
	 else
			 obj_location.Institutionid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Building"]) != "")
			obj_location.Building = Convert.ToString(dt.Rows[i]["Building"]);
	 else
			 obj_location.Building = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Jobtypeid"]) != "")
			obj_location.Jobtypeid = Convert.ToInt32(dt.Rows[i]["Jobtypeid"]);
	 else
			 obj_location.Jobtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobstatusid"]) != "")
			obj_location.Jobstatusid = Convert.ToInt32(dt.Rows[i]["Jobstatusid"]);
	 else
			 obj_location.Jobstatusid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobdetail"]) != "")
			obj_location.Jobdetail = Convert.ToString(dt.Rows[i]["Jobdetail"]);
	 else
			 obj_location.Jobdetail = Convert.ToString("");
}
return obj_location;
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
