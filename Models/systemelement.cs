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
	public class systemelementClass
    {
		#region "properties"
			public Int32  Systemelementid {get;set;}
public Int32  Buildingsystemid {get;set;}
public string  Systemelementname {get;set;}


	 public systemelementClass(){
		 
			Systemelementid = 0;
			Buildingsystemid = 0;
			Systemelementname = "update";
	 }
		#endregion
    }

	public class systemelementCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public systemelementCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public systemelementCtl(Int32 id)
{
obj_con = new ConnectionCls();
systemelementClass  obj_sys= new systemelementClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_sys.Systemelementid = Convert.ToInt32(dt.Rows[0]["Systemelementid"]);
obj_sys.Buildingsystemid = Convert.ToInt32(dt.Rows[0]["Buildingsystemid"]);
obj_sys.Systemelementname = Convert.ToString(dt.Rows[0]["Systemelementname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(systemelementClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_systemelement_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Systemelementid = Convert.ToInt32(obj_con.getValue("@Systemelementid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemelement_insert");
}
}

//update data into database 
public Int32 update(systemelementClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_systemelement_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Systemelementid = Convert.ToInt32(obj_con.getValue("@Systemelementid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemelement_update");
}
}

//delete data from database 
public void delete(Int32 Systemelementid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Systemelementid", Systemelementid );
obj_con.ExecuteNoneQuery("sp_systemelement_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_systemelement_delete");
}
}

//select all data from database 
public List<systemelementClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemelement_selectall");
}
}

//select data from database as Paging
public List<systemelementClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_systemelement_selectPaging");
	 }
}

	 public List<systemelementClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_systemelement_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_systemelement_selectIndexPaging");
		 }
	 }
	 public List<systemelementClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<systemelementClass> selectlist(Int32 Systemelementid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementid", Systemelementid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemelement_select");
}
}

//select data from database as Objject
public systemelementClass selectById(Int32 Systemelementid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementid", Systemelementid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_systemelement_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Systemelementid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Systemelementid", Systemelementid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_systemelement_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_systemelement_select");
}
}

//create parameter 
public void createParameter(systemelementClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingsystemid)) ? 0 : obj.Buildingsystemid);
obj_con.addParameter("@Systemelementname", string.IsNullOrEmpty(Convert.ToString(obj.Systemelementname)) ? "" : obj.Systemelementname);
obj_con.addParameter("@Systemelementid", obj.Systemelementid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public systemelementClass updateObject(systemelementClass  obj)
{
try
{

	 systemelementClass oldObj = selectById(obj.Systemelementid);
 if (obj.Buildingsystemid == null || obj.Buildingsystemid.ToString().Trim() == "0")
	 obj.Buildingsystemid = oldObj.Buildingsystemid; 

 if (obj.Systemelementname == null || obj.Systemelementname.ToString().Trim() == "update")
	 obj.Systemelementname = oldObj.Systemelementname; 

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
 public List<systemelementClass> ConvertToList(DataTable dt)
{
 List<systemelementClass> systemelementlist = new List<systemelementClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
systemelementClass obj_systemelement = new systemelementClass();

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_systemelement.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_systemelement.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_systemelement.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_systemelement.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementname"]) != "")
			obj_systemelement.Systemelementname = Convert.ToString(dt.Rows[i]["Systemelementname"]);
	 else
			 obj_systemelement.Systemelementname = Convert.ToString("");


systemelementlist.Add(obj_systemelement);
}
return systemelementlist;
}

//Convert DataTable To object method
 public systemelementClass ConvertToOjbect(DataTable dt)
{
 systemelementClass obj_systemelement = new systemelementClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_systemelement.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_systemelement.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_systemelement.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_systemelement.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementname"]) != "")
			obj_systemelement.Systemelementname = Convert.ToString(dt.Rows[i]["Systemelementname"]);
	 else
			 obj_systemelement.Systemelementname = Convert.ToString("");
}
return obj_systemelement;
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
