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
	public class jobtypeClass
    {
		#region "properties"
			public Int32  Jobtypeid {get;set;}
public string  Jobtype {get;set;}


	 public jobtypeClass(){
		 
			Jobtypeid = 0;
			Jobtype = "update";
	 }
		#endregion
    }

	public class jobtypeCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public jobtypeCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public jobtypeCtl(Int32 id)
{
obj_con = new ConnectionCls();
jobtypeClass  obj_job= new jobtypeClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_job.Jobtypeid = Convert.ToInt32(dt.Rows[0]["Jobtypeid"]);
obj_job.Jobtype = Convert.ToString(dt.Rows[0]["Jobtype"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(jobtypeClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_jobtype_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Jobtypeid = Convert.ToInt32(obj_con.getValue("@Jobtypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobtype_insert");
}
}

//update data into database 
public Int32 update(jobtypeClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_jobtype_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Jobtypeid = Convert.ToInt32(obj_con.getValue("@Jobtypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobtype_update");
}
}

//delete data from database 
public void delete(Int32 Jobtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Jobtypeid", Jobtypeid );
obj_con.ExecuteNoneQuery("sp_jobtype_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_jobtype_delete");
}
}

//select all data from database 
public List<jobtypeClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobtype_selectall");
}
}

//select data from database as Paging
public List<jobtypeClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_jobtype_selectPaging");
	 }
}

	 public List<jobtypeClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_jobtype_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_jobtype_selectIndexPaging");
		 }
	 }
	 public List<jobtypeClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<jobtypeClass> selectlist(Int32 Jobtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobtypeid", Jobtypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobtype_select");
}
}

//select data from database as Objject
public jobtypeClass selectById(Int32 Jobtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobtypeid", Jobtypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_jobtype_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Jobtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Jobtypeid", Jobtypeid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_jobtype_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_jobtype_select");
}
}

//create parameter 
public void createParameter(jobtypeClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Jobtype", string.IsNullOrEmpty(Convert.ToString(obj.Jobtype)) ? "" : obj.Jobtype);
obj_con.addParameter("@Jobtypeid", obj.Jobtypeid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public jobtypeClass updateObject(jobtypeClass  obj)
{
try
{

	 jobtypeClass oldObj = selectById(obj.Jobtypeid);
 if (obj.Jobtype == null || obj.Jobtype.ToString().Trim() == "update")
	 obj.Jobtype = oldObj.Jobtype; 

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
 public List<jobtypeClass> ConvertToList(DataTable dt)
{
 List<jobtypeClass> jobtypelist = new List<jobtypeClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
jobtypeClass obj_jobtype = new jobtypeClass();

		 if (Convert.ToString(dt.Rows[i]["Jobtypeid"]) != "")
			obj_jobtype.Jobtypeid = Convert.ToInt32(dt.Rows[i]["Jobtypeid"]);
	 else
			 obj_jobtype.Jobtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobtype"]) != "")
			obj_jobtype.Jobtype = Convert.ToString(dt.Rows[i]["Jobtype"]);
	 else
			 obj_jobtype.Jobtype = Convert.ToString("");


jobtypelist.Add(obj_jobtype);
}
return jobtypelist;
}

//Convert DataTable To object method
 public jobtypeClass ConvertToOjbect(DataTable dt)
{
 jobtypeClass obj_jobtype = new jobtypeClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Jobtypeid"]) != "")
			obj_jobtype.Jobtypeid = Convert.ToInt32(dt.Rows[i]["Jobtypeid"]);
	 else
			 obj_jobtype.Jobtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Jobtype"]) != "")
			obj_jobtype.Jobtype = Convert.ToString(dt.Rows[i]["Jobtype"]);
	 else
			 obj_jobtype.Jobtype = Convert.ToString("");
}
return obj_jobtype;
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
