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
	public class materialClass
    {
		#region "properties"
			public Int32  Materialid {get;set;}
public string  Materialname {get;set;}


	 public materialClass(){
		 
			Materialid = 0;
			Materialname = "update";
	 }
		#endregion
    }

	public class materialCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public materialCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public materialCtl(Int32 id)
{
obj_con = new ConnectionCls();
materialClass  obj_mat= new materialClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_mat.Materialid = Convert.ToInt32(dt.Rows[0]["Materialid"]);
obj_mat.Materialname = Convert.ToString(dt.Rows[0]["Materialname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(materialClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_material_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Materialid = Convert.ToInt32(obj_con.getValue("@Materialid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_material_insert");
}
}

//update data into database 
public Int32 update(materialClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_material_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Materialid = Convert.ToInt32(obj_con.getValue("@Materialid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_material_update");
}
}

//delete data from database 
public void delete(Int32 Materialid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Materialid", Materialid );
obj_con.ExecuteNoneQuery("sp_material_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_material_delete");
}
}

//select all data from database 
public List<materialClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_material_selectall");
}
}

//select data from database as Paging
public List<materialClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_material_selectPaging");
	 }
}

	 public List<materialClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_material_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_material_selectIndexPaging");
		 }
	 }
	 public List<materialClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<materialClass> selectlist(Int32 Materialid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Materialid", Materialid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_material_select");
}
}

//select data from database as Objject
public materialClass selectById(Int32 Materialid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Materialid", Materialid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_material_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Materialid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Materialid", Materialid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_material_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_material_select");
}
}

//create parameter 
public void createParameter(materialClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Materialname", string.IsNullOrEmpty(Convert.ToString(obj.Materialname)) ? "" : obj.Materialname);
obj_con.addParameter("@Materialid", obj.Materialid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public materialClass updateObject(materialClass  obj)
{
try
{

	 materialClass oldObj = selectById(obj.Materialid);
 if (obj.Materialname == null || obj.Materialname.ToString().Trim() == "update")
	 obj.Materialname = oldObj.Materialname; 

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
 public List<materialClass> ConvertToList(DataTable dt)
{
 List<materialClass> materiallist = new List<materialClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
materialClass obj_material = new materialClass();

		 if (Convert.ToString(dt.Rows[i]["Materialid"]) != "")
			obj_material.Materialid = Convert.ToInt32(dt.Rows[i]["Materialid"]);
	 else
			 obj_material.Materialid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Materialname"]) != "")
			obj_material.Materialname = Convert.ToString(dt.Rows[i]["Materialname"]);
	 else
			 obj_material.Materialname = Convert.ToString("");


materiallist.Add(obj_material);
}
return materiallist;
}

//Convert DataTable To object method
 public materialClass ConvertToOjbect(DataTable dt)
{
 materialClass obj_material = new materialClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Materialid"]) != "")
			obj_material.Materialid = Convert.ToInt32(dt.Rows[i]["Materialid"]);
	 else
			 obj_material.Materialid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Materialname"]) != "")
			obj_material.Materialname = Convert.ToString(dt.Rows[i]["Materialname"]);
	 else
			 obj_material.Materialname = Convert.ToString("");
}
return obj_material;
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
