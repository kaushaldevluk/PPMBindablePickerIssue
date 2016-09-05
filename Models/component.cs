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
	public class componentClass
    {
		#region "properties"
			public Int32  Componentid {get;set;}
public string  Componentname {get;set;}


	 public componentClass(){
		 
			Componentid = 0;
			Componentname = "update";
	 }
		#endregion
    }

	public class componentCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public componentCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public componentCtl(Int32 id)
{
obj_con = new ConnectionCls();
componentClass  obj_com= new componentClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_com.Componentid = Convert.ToInt32(dt.Rows[0]["Componentid"]);
obj_com.Componentname = Convert.ToString(dt.Rows[0]["Componentname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(componentClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_component_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Componentid = Convert.ToInt32(obj_con.getValue("@Componentid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_component_insert");
}
}

//update data into database 
public Int32 update(componentClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_component_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Componentid = Convert.ToInt32(obj_con.getValue("@Componentid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_component_update");
}
}

//delete data from database 
public void delete(Int32 Componentid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Componentid", Componentid );
obj_con.ExecuteNoneQuery("sp_component_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_component_delete");
}
}

//select all data from database 
public List<componentClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_component_selectall");
}
}

//select data from database as Paging
public List<componentClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_component_selectPaging");
	 }
}

	 public List<componentClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_component_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_component_selectIndexPaging");
		 }
	 }
	 public List<componentClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<componentClass> selectlist(Int32 Componentid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Componentid", Componentid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_component_select");
}
}

//select data from database as Objject
public componentClass selectById(Int32 Componentid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Componentid", Componentid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_component_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Componentid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Componentid", Componentid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_component_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_component_select");
}
}

//create parameter 
public void createParameter(componentClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Componentname", string.IsNullOrEmpty(Convert.ToString(obj.Componentname)) ? "" : obj.Componentname);
obj_con.addParameter("@Componentid", obj.Componentid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public componentClass updateObject(componentClass  obj)
{
try
{

	 componentClass oldObj = selectById(obj.Componentid);
 if (obj.Componentname == null || obj.Componentname.ToString().Trim() == "update")
	 obj.Componentname = oldObj.Componentname; 

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
 public List<componentClass> ConvertToList(DataTable dt)
{
 List<componentClass> componentlist = new List<componentClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
componentClass obj_component = new componentClass();

		 if (Convert.ToString(dt.Rows[i]["Componentid"]) != "")
			obj_component.Componentid = Convert.ToInt32(dt.Rows[i]["Componentid"]);
	 else
			 obj_component.Componentid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Componentname"]) != "")
			obj_component.Componentname = Convert.ToString(dt.Rows[i]["Componentname"]);
	 else
			 obj_component.Componentname = Convert.ToString("");


componentlist.Add(obj_component);
}
return componentlist;
}

//Convert DataTable To object method
 public componentClass ConvertToOjbect(DataTable dt)
{
 componentClass obj_component = new componentClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Componentid"]) != "")
			obj_component.Componentid = Convert.ToInt32(dt.Rows[i]["Componentid"]);
	 else
			 obj_component.Componentid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Componentname"]) != "")
			obj_component.Componentname = Convert.ToString(dt.Rows[i]["Componentname"]);
	 else
			 obj_component.Componentname = Convert.ToString("");
}
return obj_component;
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
