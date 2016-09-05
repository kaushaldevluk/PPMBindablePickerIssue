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
	public class systemtypeClass
    {
		#region "properties"
			public Int32  Systemelementtypeid {get;set;}
public Int32  Systemelementid {get;set;}
public string  Systemelementtypename {get;set;}


	 public systemtypeClass(){
		 
			Systemelementtypeid = 0;
			Systemelementid = 0;
			Systemelementtypename = "update";
	 }
		#endregion
    }

	public class systemtypeCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public systemtypeCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public systemtypeCtl(Int32 id)
{
obj_con = new ConnectionCls();
systemtypeClass  obj_sys= new systemtypeClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_sys.Systemelementtypeid = Convert.ToInt32(dt.Rows[0]["Systemelementtypeid"]);
obj_sys.Systemelementid = Convert.ToInt32(dt.Rows[0]["Systemelementid"]);
obj_sys.Systemelementtypename = Convert.ToString(dt.Rows[0]["Systemelementtypename"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(systemtypeClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_systemtype_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Systemelementtypeid = Convert.ToInt32(obj_con.getValue("@Systemelementtypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemtype_insert");
}
}

//update data into database 
public Int32 update(systemtypeClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_systemtype_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Systemelementtypeid = Convert.ToInt32(obj_con.getValue("@Systemelementtypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemtype_update");
}
}

//delete data from database 
public void delete(Int32 Systemelementtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Systemelementtypeid", Systemelementtypeid );
obj_con.ExecuteNoneQuery("sp_systemtype_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemtype_delete");
}
}

//select all data from database 
public List<systemtypeClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemtype_selectall");
}
}

//select data from database as Paging
public List<systemtypeClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_systemtype_selectPaging");
	 }
}

	 public List<systemtypeClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_systemtype_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_systemtype_selectIndexPaging");
		 }
	 }
	 public List<systemtypeClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<systemtypeClass> selectlist(Int32 Systemelementtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementtypeid", Systemelementtypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemtype_select");
}
}

//select data from database as Objject
public systemtypeClass selectById(Int32 Systemelementtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementtypeid", Systemelementtypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemtype_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Systemelementtypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementtypeid", Systemelementtypeid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemtype_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_systemtype_select");
}
}

//create parameter 
public void createParameter(systemtypeClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Systemelementid", string.IsNullOrEmpty(Convert.ToString(obj.Systemelementid)) ? 0 : obj.Systemelementid);
obj_con.addParameter("@Systemelementtypename", string.IsNullOrEmpty(Convert.ToString(obj.Systemelementtypename)) ? "" : obj.Systemelementtypename);
obj_con.addParameter("@Systemelementtypeid", obj.Systemelementtypeid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public systemtypeClass updateObject(systemtypeClass  obj)
{
try
{

	 systemtypeClass oldObj = selectById(obj.Systemelementtypeid);
 if (obj.Systemelementid == null || obj.Systemelementid.ToString().Trim() == "0")
	 obj.Systemelementid = oldObj.Systemelementid; 

 if (obj.Systemelementtypename == null || obj.Systemelementtypename.ToString().Trim() == "update")
	 obj.Systemelementtypename = oldObj.Systemelementtypename; 

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
 public List<systemtypeClass> ConvertToList(DataTable dt)
{
 List<systemtypeClass> systemtypelist = new List<systemtypeClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
systemtypeClass obj_systemtype = new systemtypeClass();

		 if (Convert.ToString(dt.Rows[i]["Systemelementtypeid"]) != "")
			obj_systemtype.Systemelementtypeid = Convert.ToInt32(dt.Rows[i]["Systemelementtypeid"]);
	 else
			 obj_systemtype.Systemelementtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_systemtype.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_systemtype.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementtypename"]) != "")
			obj_systemtype.Systemelementtypename = Convert.ToString(dt.Rows[i]["Systemelementtypename"]);
	 else
			 obj_systemtype.Systemelementtypename = Convert.ToString("");


systemtypelist.Add(obj_systemtype);
}
return systemtypelist;
}

//Convert DataTable To object method
 public systemtypeClass ConvertToOjbect(DataTable dt)
{
 systemtypeClass obj_systemtype = new systemtypeClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Systemelementtypeid"]) != "")
			obj_systemtype.Systemelementtypeid = Convert.ToInt32(dt.Rows[i]["Systemelementtypeid"]);
	 else
			 obj_systemtype.Systemelementtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_systemtype.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_systemtype.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementtypename"]) != "")
			obj_systemtype.Systemelementtypename = Convert.ToString(dt.Rows[i]["Systemelementtypename"]);
	 else
			 obj_systemtype.Systemelementtypename = Convert.ToString("");
}
return obj_systemtype;
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
