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
	public class buildingsystemClass
    {
		#region "properties"
			public Int32  Buildingsystemid {get;set;}
public string  Buildingsystemname {get;set;}


	 public buildingsystemClass(){
		 
			Buildingsystemid = 0;
			Buildingsystemname = "update";
	 }
		#endregion
    }

	public class buildingsystemCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public buildingsystemCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public buildingsystemCtl(Int32 id)
{
obj_con = new ConnectionCls();
buildingsystemClass  obj_bui= new buildingsystemClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_bui.Buildingsystemid = Convert.ToInt32(dt.Rows[0]["Buildingsystemid"]);
obj_bui.Buildingsystemname = Convert.ToString(dt.Rows[0]["Buildingsystemname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(buildingsystemClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingsystem_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingsystemid = Convert.ToInt32(obj_con.getValue("@Buildingsystemid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingsystem_insert");
}
}

//update data into database 
public Int32 update(buildingsystemClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingsystem_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingsystemid = Convert.ToInt32(obj_con.getValue("@Buildingsystemid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingsystem_update");
}
}

//delete data from database 
public void delete(Int32 Buildingsystemid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Buildingsystemid", Buildingsystemid );
obj_con.ExecuteNoneQuery("sp_buildingsystem_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingsystem_delete");
}
}

//select all data from database 
public List<buildingsystemClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingsystem_selectall");
}
}

//select data from database as Paging
public List<buildingsystemClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_buildingsystem_selectPaging");
	 }
}

	 public List<buildingsystemClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingsystem_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingsystem_selectIndexPaging");
		 }
	 }
	 public List<buildingsystemClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<buildingsystemClass> selectlist(Int32 Buildingsystemid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemid", Buildingsystemid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingsystem_select");
}
}

//select data from database as Objject
public buildingsystemClass selectById(Int32 Buildingsystemid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemid", Buildingsystemid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingsystem_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Buildingsystemid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemid", Buildingsystemid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingsystem_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_buildingsystem_select");
}
}

//create parameter 
public void createParameter(buildingsystemClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemname", string.IsNullOrEmpty(Convert.ToString(obj.Buildingsystemname)) ? "" : obj.Buildingsystemname);
obj_con.addParameter("@Buildingsystemid", obj.Buildingsystemid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public buildingsystemClass updateObject(buildingsystemClass  obj)
{
try
{

	 buildingsystemClass oldObj = selectById(obj.Buildingsystemid);
 if (obj.Buildingsystemname == null || obj.Buildingsystemname.ToString().Trim() == "update")
	 obj.Buildingsystemname = oldObj.Buildingsystemname; 

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
 public List<buildingsystemClass> ConvertToList(DataTable dt)
{
 List<buildingsystemClass> buildingsystemlist = new List<buildingsystemClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
buildingsystemClass obj_buildingsystem = new buildingsystemClass();

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_buildingsystem.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_buildingsystem.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemname"]) != "")
			obj_buildingsystem.Buildingsystemname = Convert.ToString(dt.Rows[i]["Buildingsystemname"]);
	 else
			 obj_buildingsystem.Buildingsystemname = Convert.ToString("");


buildingsystemlist.Add(obj_buildingsystem);
}
return buildingsystemlist;
}

//Convert DataTable To object method
 public buildingsystemClass ConvertToOjbect(DataTable dt)
{
 buildingsystemClass obj_buildingsystem = new buildingsystemClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_buildingsystem.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_buildingsystem.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemname"]) != "")
			obj_buildingsystem.Buildingsystemname = Convert.ToString(dt.Rows[i]["Buildingsystemname"]);
	 else
			 obj_buildingsystem.Buildingsystemname = Convert.ToString("");
}
return obj_buildingsystem;
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
