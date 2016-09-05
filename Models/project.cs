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
	public class projectClass
    {
		#region "properties"
			public Int32  Projectid {get;set;}
public Int32  Buildingsystemid {get;set;}
public string  Projectname {get;set;}


	 public projectClass(){
		 
			Projectid = 0;
			Buildingsystemid = 0;
			Projectname = "update";
	 }
		#endregion
    }

	public class projectCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public projectCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public projectCtl(Int32 id)
{
obj_con = new ConnectionCls();
projectClass  obj_pro= new projectClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_pro.Projectid = Convert.ToInt32(dt.Rows[0]["Projectid"]);
obj_pro.Buildingsystemid = Convert.ToInt32(dt.Rows[0]["Buildingsystemid"]);
obj_pro.Projectname = Convert.ToString(dt.Rows[0]["Projectname"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(projectClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_project_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Projectid = Convert.ToInt32(obj_con.getValue("@Projectid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_project_insert");
}
}

//update data into database 
public Int32 update(projectClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_project_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Projectid = Convert.ToInt32(obj_con.getValue("@Projectid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_project_update");
}
}

//delete data from database 
public void delete(Int32 Projectid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Projectid", Projectid );
obj_con.ExecuteNoneQuery("sp_project_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_project_delete");
}
}

//select all data from database 
public List<projectClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_project_selectall");
}
}

//select data from database as Paging
public List<projectClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_project_selectPaging");
	 }
}

	 public List<projectClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_project_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_project_selectIndexPaging");
		 }
	 }
	 public List<projectClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<projectClass> selectlist(Int32 Projectid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Projectid", Projectid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_project_select");
}
}

//select data from database as Objject
public projectClass selectById(Int32 Projectid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Projectid", Projectid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_project_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Projectid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Projectid", Projectid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_project_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_project_select");
}
}

//create parameter 
public void createParameter(projectClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingsystemid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingsystemid)) ? 0 : obj.Buildingsystemid);
obj_con.addParameter("@Projectname", string.IsNullOrEmpty(Convert.ToString(obj.Projectname)) ? "" : obj.Projectname);
obj_con.addParameter("@Projectid", obj.Projectid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public projectClass updateObject(projectClass  obj)
{
try
{

	 projectClass oldObj = selectById(obj.Projectid);
 if (obj.Buildingsystemid == null || obj.Buildingsystemid.ToString().Trim() == "0")
	 obj.Buildingsystemid = oldObj.Buildingsystemid; 

 if (obj.Projectname == null || obj.Projectname.ToString().Trim() == "update")
	 obj.Projectname = oldObj.Projectname; 

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
 public List<projectClass> ConvertToList(DataTable dt)
{
 List<projectClass> projectlist = new List<projectClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
projectClass obj_project = new projectClass();

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_project.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_project.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_project.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_project.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Projectname"]) != "")
			obj_project.Projectname = Convert.ToString(dt.Rows[i]["Projectname"]);
	 else
			 obj_project.Projectname = Convert.ToString("");


projectlist.Add(obj_project);
}
return projectlist;
}

//Convert DataTable To object method
 public projectClass ConvertToOjbect(DataTable dt)
{
 projectClass obj_project = new projectClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_project.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_project.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_project.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_project.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Projectname"]) != "")
			obj_project.Projectname = Convert.ToString(dt.Rows[i]["Projectname"]);
	 else
			 obj_project.Projectname = Convert.ToString("");
}
return obj_project;
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
