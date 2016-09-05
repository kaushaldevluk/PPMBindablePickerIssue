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
	public class labourClass
    {
		#region "properties"
			public Int32  Labourid {get;set;}
public string  Labourname {get;set;}


	 public labourClass(){
		 
			Labourid = 0;
			Labourname = "update";
	 }
		#endregion
    }

	public class labourCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public labourCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public labourCtl(Int32 id)
{
obj_con = new ConnectionCls();
labourClass  obj_lab= new labourClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_lab.Labourid = Convert.ToInt32(dt.Rows[0]["Labourid"]);
obj_lab.Labourname = Convert.ToString(dt.Rows[0]["Labourname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(labourClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_labour_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Labourid = Convert.ToInt32(obj_con.getValue("@Labourid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_labour_insert");
}
}

//update data into database 
public Int32 update(labourClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_labour_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Labourid = Convert.ToInt32(obj_con.getValue("@Labourid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_labour_update");
}
}

//delete data from database 
public void delete(Int32 Labourid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Labourid", Labourid );
obj_con.ExecuteNoneQuery("sp_labour_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_labour_delete");
}
}

//select all data from database 
public List<labourClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_labour_selectall");
}
}

//select data from database as Paging
public List<labourClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_labour_selectPaging");
	 }
}

	 public List<labourClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_labour_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_labour_selectIndexPaging");
		 }
	 }
	 public List<labourClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<labourClass> selectlist(Int32 Labourid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Labourid", Labourid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_labour_select");
}
}

//select data from database as Objject
public labourClass selectById(Int32 Labourid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Labourid", Labourid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_labour_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Labourid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Labourid", Labourid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_labour_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_labour_select");
}
}

//create parameter 
public void createParameter(labourClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Labourname", string.IsNullOrEmpty(Convert.ToString(obj.Labourname)) ? "" : obj.Labourname);
obj_con.addParameter("@Labourid", obj.Labourid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public labourClass updateObject(labourClass  obj)
{
try
{

	 labourClass oldObj = selectById(obj.Labourid);
 if (obj.Labourname == null || obj.Labourname.ToString().Trim() == "update")
	 obj.Labourname = oldObj.Labourname; 

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
 public List<labourClass> ConvertToList(DataTable dt)
{
 List<labourClass> labourlist = new List<labourClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
labourClass obj_labour = new labourClass();

		 if (Convert.ToString(dt.Rows[i]["Labourid"]) != "")
			obj_labour.Labourid = Convert.ToInt32(dt.Rows[i]["Labourid"]);
	 else
			 obj_labour.Labourid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Labourname"]) != "")
			obj_labour.Labourname = Convert.ToString(dt.Rows[i]["Labourname"]);
	 else
			 obj_labour.Labourname = Convert.ToString("");


labourlist.Add(obj_labour);
}
return labourlist;
}

//Convert DataTable To object method
 public labourClass ConvertToOjbect(DataTable dt)
{
 labourClass obj_labour = new labourClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Labourid"]) != "")
			obj_labour.Labourid = Convert.ToInt32(dt.Rows[i]["Labourid"]);
	 else
			 obj_labour.Labourid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Labourname"]) != "")
			obj_labour.Labourname = Convert.ToString(dt.Rows[i]["Labourname"]);
	 else
			 obj_labour.Labourname = Convert.ToString("");
}
return obj_labour;
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
