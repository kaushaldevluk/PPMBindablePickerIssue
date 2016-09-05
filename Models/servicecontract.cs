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
	public class servicecontractClass
    {
		#region "properties"
			public Int32  Servicecontractid {get;set;}
public Int32  Projectid {get;set;}
public string  Servicecontractname {get;set;}


	 public servicecontractClass(){
		 
			Servicecontractid = 0;
			Projectid = 0;
			Servicecontractname = "update";
	 }
		#endregion
    }

	public class servicecontractCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public servicecontractCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public servicecontractCtl(Int32 id)
{
obj_con = new ConnectionCls();
servicecontractClass  obj_ser= new servicecontractClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_ser.Servicecontractid = Convert.ToInt32(dt.Rows[0]["Servicecontractid"]);
obj_ser.Projectid = Convert.ToInt32(dt.Rows[0]["Projectid"]);
obj_ser.Servicecontractname = Convert.ToString(dt.Rows[0]["Servicecontractname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(servicecontractClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_servicecontract_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Servicecontractid = Convert.ToInt32(obj_con.getValue("@Servicecontractid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_servicecontract_insert");
}
}

//update data into database 
public Int32 update(servicecontractClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_servicecontract_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Servicecontractid = Convert.ToInt32(obj_con.getValue("@Servicecontractid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_servicecontract_update");
}
}

//delete data from database 
public void delete(Int32 Servicecontractid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Servicecontractid", Servicecontractid );
obj_con.ExecuteNoneQuery("sp_servicecontract_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_servicecontract_delete");
}
}

//select all data from database 
public List<servicecontractClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_servicecontract_selectall");
}
}

//select data from database as Paging
public List<servicecontractClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_servicecontract_selectPaging");
	 }
}

	 public List<servicecontractClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_servicecontract_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_servicecontract_selectIndexPaging");
		 }
	 }
	 public List<servicecontractClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<servicecontractClass> selectlist(Int32 Servicecontractid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Servicecontractid", Servicecontractid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_servicecontract_select");
}
}

//select data from database as Objject
public servicecontractClass selectById(Int32 Servicecontractid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Servicecontractid", Servicecontractid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_servicecontract_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Servicecontractid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Servicecontractid", Servicecontractid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_servicecontract_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_servicecontract_select");
}
}

//create parameter 
public void createParameter(servicecontractClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Projectid", string.IsNullOrEmpty(Convert.ToString(obj.Projectid)) ? 0 : obj.Projectid);
obj_con.addParameter("@Servicecontractname", string.IsNullOrEmpty(Convert.ToString(obj.Servicecontractname)) ? "" : obj.Servicecontractname);
obj_con.addParameter("@Servicecontractid", obj.Servicecontractid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public servicecontractClass updateObject(servicecontractClass  obj)
{
try
{

	 servicecontractClass oldObj = selectById(obj.Servicecontractid);
 if (obj.Projectid == null || obj.Projectid.ToString().Trim() == "0")
	 obj.Projectid = oldObj.Projectid; 

 if (obj.Servicecontractname == null || obj.Servicecontractname.ToString().Trim() == "update")
	 obj.Servicecontractname = oldObj.Servicecontractname; 

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
 public List<servicecontractClass> ConvertToList(DataTable dt)
{
 List<servicecontractClass> servicecontractlist = new List<servicecontractClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
servicecontractClass obj_servicecontract = new servicecontractClass();

		 if (Convert.ToString(dt.Rows[i]["Servicecontractid"]) != "")
			obj_servicecontract.Servicecontractid = Convert.ToInt32(dt.Rows[i]["Servicecontractid"]);
	 else
			 obj_servicecontract.Servicecontractid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_servicecontract.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_servicecontract.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Servicecontractname"]) != "")
			obj_servicecontract.Servicecontractname = Convert.ToString(dt.Rows[i]["Servicecontractname"]);
	 else
			 obj_servicecontract.Servicecontractname = Convert.ToString("");


servicecontractlist.Add(obj_servicecontract);
}
return servicecontractlist;
}

//Convert DataTable To object method
 public servicecontractClass ConvertToOjbect(DataTable dt)
{
 servicecontractClass obj_servicecontract = new servicecontractClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Servicecontractid"]) != "")
			obj_servicecontract.Servicecontractid = Convert.ToInt32(dt.Rows[i]["Servicecontractid"]);
	 else
			 obj_servicecontract.Servicecontractid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_servicecontract.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_servicecontract.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Servicecontractname"]) != "")
			obj_servicecontract.Servicecontractname = Convert.ToString(dt.Rows[i]["Servicecontractname"]);
	 else
			 obj_servicecontract.Servicecontractname = Convert.ToString("");
}
return obj_servicecontract;
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
