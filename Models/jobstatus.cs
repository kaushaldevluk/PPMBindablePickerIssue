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
	public class jobstatusClass
    {
		#region "properties"
			public Int32  Jobstatusid {get;set;}
public string  Statusname {get;set;}


	 public jobstatusClass(){
		 
			Jobstatusid = 0;
			Statusname = "update";
	 }
		#endregion
    }

	public class jobstatusCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public jobstatusCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public jobstatusCtl(Int32 id)
{
obj_con = new ConnectionCls();
jobstatusClass  obj_job= new jobstatusClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_job.Jobstatusid = Convert.ToInt32(dt.Rows[0]["Jobstatusid"]);
obj_job.Statusname = Convert.ToString(dt.Rows[0]["Statusname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(jobstatusClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_jobstatus_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Jobstatusid = Convert.ToInt32(obj_con.getValue("@Jobstatusid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobstatus_insert");
}
}

//update data into database 
public Int32 update(jobstatusClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_jobstatus_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Jobstatusid = Convert.ToInt32(obj_con.getValue("@Jobstatusid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobstatus_update");
}
}

//delete data from database 
public void delete(Int32 Jobstatusid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Jobstatusid", Jobstatusid );
obj_con.ExecuteNoneQuery("sp_jobstatus_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobstatus_delete");
}
}

//select all data from database 
public List<jobstatusClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobstatus_selectall");
}
}

//select data from database as Paging
public List<jobstatusClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_jobstatus_selectPaging");
	 }
}

	 public List<jobstatusClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_jobstatus_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_jobstatus_selectIndexPaging");
		 }
	 }
	 public List<jobstatusClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<jobstatusClass> selectlist(Int32 Jobstatusid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobstatusid", Jobstatusid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobstatus_select");
}
}

//select data from database as Objject
public jobstatusClass selectById(Int32 Jobstatusid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobstatusid", Jobstatusid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobstatus_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Jobstatusid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobstatusid", Jobstatusid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobstatus_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_jobstatus_select");
}
}

//create parameter 
public void createParameter(jobstatusClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Statusname", string.IsNullOrEmpty(Convert.ToString(obj.Statusname)) ? "" : obj.Statusname);
obj_con.addParameter("@Jobstatusid", obj.Jobstatusid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public jobstatusClass updateObject(jobstatusClass  obj)
{
try
{

	 jobstatusClass oldObj = selectById(obj.Jobstatusid);
 if (obj.Statusname == null || obj.Statusname.ToString().Trim() == "update")
	 obj.Statusname = oldObj.Statusname; 

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
 public List<jobstatusClass> ConvertToList(DataTable dt)
{
 List<jobstatusClass> jobstatuslist = new List<jobstatusClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
jobstatusClass obj_jobstatus = new jobstatusClass();

		 if (Convert.ToString(dt.Rows[i]["Jobstatusid"]) != "")
			obj_jobstatus.Jobstatusid = Convert.ToInt32(dt.Rows[i]["Jobstatusid"]);
	 else
			 obj_jobstatus.Jobstatusid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Statusname"]) != "")
			obj_jobstatus.Statusname = Convert.ToString(dt.Rows[i]["Statusname"]);
	 else
			 obj_jobstatus.Statusname = Convert.ToString("");


jobstatuslist.Add(obj_jobstatus);
}
return jobstatuslist;
}

//Convert DataTable To object method
 public jobstatusClass ConvertToOjbect(DataTable dt)
{
 jobstatusClass obj_jobstatus = new jobstatusClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Jobstatusid"]) != "")
			obj_jobstatus.Jobstatusid = Convert.ToInt32(dt.Rows[i]["Jobstatusid"]);
	 else
			 obj_jobstatus.Jobstatusid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Statusname"]) != "")
			obj_jobstatus.Statusname = Convert.ToString(dt.Rows[i]["Statusname"]);
	 else
			 obj_jobstatus.Statusname = Convert.ToString("");
}
return obj_jobstatus;
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
