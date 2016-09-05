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
	public class buildingworkorderClass
    {
		#region "properties"
			public Int32  Workorderid {get;set;}
public Int32  Buildingid {get;set;}
public Int32  Buildingsystemid {get;set;}
public Int32  Component {get;set;}
public string  Description {get;set;}
public string  Priority {get;set;}
public string  Requestor {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public buildingworkorderClass(){
		 
			Workorderid = 0;
			Buildingid = 0;
			Buildingsystemid = 0;
			Component = 0;
			Description = "update";
			Priority = "update";
			Requestor = "update";
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class buildingworkorderCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public buildingworkorderCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public buildingworkorderCtl(Int32 id)
{
obj_con = new ConnectionCls();
buildingworkorderClass  obj_bui= new buildingworkorderClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_bui.Workorderid = Convert.ToInt32(dt.Rows[0]["Workorderid"]);
obj_bui.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_bui.Buildingsystemid = Convert.ToInt32(dt.Rows[0]["Buildingsystemid"]);
obj_bui.Component = Convert.ToInt32(dt.Rows[0]["Component"]);
obj_bui.Description = Convert.ToString(dt.Rows[0]["Description"]);
obj_bui.Priority = Convert.ToString(dt.Rows[0]["Priority"]);
obj_bui.Requestor = Convert.ToString(dt.Rows[0]["Requestor"]);
obj_bui.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_bui.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(buildingworkorderClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingworkorder_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Workorderid = Convert.ToInt32(obj_con.getValue("@Workorderid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingworkorder_insert");
}
}

//update data into database 
public Int32 update(buildingworkorderClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingworkorder_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Workorderid = Convert.ToInt32(obj_con.getValue("@Workorderid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingworkorder_update");
}
}

//delete data from database 
public void delete(Int32 Workorderid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Workorderid", Workorderid );
obj_con.ExecuteNoneQuery("sp_buildingworkorder_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingworkorder_delete");
}
}

//select all data from database 
public List<buildingworkorderClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingworkorder_selectall");
}
}

//select data from database as Paging
public List<buildingworkorderClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_buildingworkorder_selectPaging");
	 }
}

	 public List<buildingworkorderClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingworkorder_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingworkorder_selectIndexPaging");
		 }
	 }
	 public List<buildingworkorderClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<buildingworkorderClass> selectlist(Int32 Workorderid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderid", Workorderid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingworkorder_select");
}
}

//select data from database as Objject
public buildingworkorderClass selectById(Int32 Workorderid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderid", Workorderid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingworkorder_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Workorderid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderid", Workorderid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingworkorder_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_buildingworkorder_select");
}
}

//create parameter 
public void createParameter(buildingworkorderClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Buildingsystemid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingsystemid)) ? 0 : obj.Buildingsystemid);
obj_con.addParameter("@Component", string.IsNullOrEmpty(Convert.ToString(obj.Component)) ? 0 : obj.Component);
obj_con.addParameter("@Description", string.IsNullOrEmpty(Convert.ToString(obj.Description)) ? "" : obj.Description);
obj_con.addParameter("@Priority", string.IsNullOrEmpty(Convert.ToString(obj.Priority)) ? "" : obj.Priority);
obj_con.addParameter("@Requestor", string.IsNullOrEmpty(Convert.ToString(obj.Requestor)) ? "" : obj.Requestor);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Workorderid", obj.Workorderid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public buildingworkorderClass updateObject(buildingworkorderClass  obj)
{
try
{

	 buildingworkorderClass oldObj = selectById(obj.Workorderid);
 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Buildingsystemid == null || obj.Buildingsystemid.ToString().Trim() == "0")
	 obj.Buildingsystemid = oldObj.Buildingsystemid; 

 if (obj.Component == null || obj.Component.ToString().Trim() == "0")
	 obj.Component = oldObj.Component; 

 if (obj.Description == null || obj.Description.ToString().Trim() == "update")
	 obj.Description = oldObj.Description; 

 if (obj.Priority == null || obj.Priority.ToString().Trim() == "update")
	 obj.Priority = oldObj.Priority; 

 if (obj.Requestor == null || obj.Requestor.ToString().Trim() == "update")
	 obj.Requestor = oldObj.Requestor; 

 if (obj.Userid == null || obj.Userid.ToString().Trim() == "0")
	 obj.Userid = oldObj.Userid; 

 if (obj.Inserteddatetime == null || obj.Inserteddatetime == Convert.ToDateTime("1900-01-01"))
	 obj.Inserteddatetime = oldObj.Inserteddatetime; 

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
 public List<buildingworkorderClass> ConvertToList(DataTable dt)
{
 List<buildingworkorderClass> buildingworkorderlist = new List<buildingworkorderClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
buildingworkorderClass obj_buildingworkorder = new buildingworkorderClass();

		 if (Convert.ToString(dt.Rows[i]["Workorderid"]) != "")
			obj_buildingworkorder.Workorderid = Convert.ToInt32(dt.Rows[i]["Workorderid"]);
	 else
			 obj_buildingworkorder.Workorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_buildingworkorder.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_buildingworkorder.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_buildingworkorder.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_buildingworkorder.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Component"]) != "")
			obj_buildingworkorder.Component = Convert.ToInt32(dt.Rows[i]["Component"]);
	 else
			 obj_buildingworkorder.Component = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Description"]) != "")
			obj_buildingworkorder.Description = Convert.ToString(dt.Rows[i]["Description"]);
	 else
			 obj_buildingworkorder.Description = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Priority"]) != "")
			obj_buildingworkorder.Priority = Convert.ToString(dt.Rows[i]["Priority"]);
	 else
			 obj_buildingworkorder.Priority = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Requestor"]) != "")
			obj_buildingworkorder.Requestor = Convert.ToString(dt.Rows[i]["Requestor"]);
	 else
			 obj_buildingworkorder.Requestor = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_buildingworkorder.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_buildingworkorder.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_buildingworkorder.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_buildingworkorder.Inserteddatetime = Convert.ToDateTime("01/01/1900");


buildingworkorderlist.Add(obj_buildingworkorder);
}
return buildingworkorderlist;
}

//Convert DataTable To object method
 public buildingworkorderClass ConvertToOjbect(DataTable dt)
{
 buildingworkorderClass obj_buildingworkorder = new buildingworkorderClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Workorderid"]) != "")
			obj_buildingworkorder.Workorderid = Convert.ToInt32(dt.Rows[i]["Workorderid"]);
	 else
			 obj_buildingworkorder.Workorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_buildingworkorder.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_buildingworkorder.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_buildingworkorder.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_buildingworkorder.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Component"]) != "")
			obj_buildingworkorder.Component = Convert.ToInt32(dt.Rows[i]["Component"]);
	 else
			 obj_buildingworkorder.Component = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Description"]) != "")
			obj_buildingworkorder.Description = Convert.ToString(dt.Rows[i]["Description"]);
	 else
			 obj_buildingworkorder.Description = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Priority"]) != "")
			obj_buildingworkorder.Priority = Convert.ToString(dt.Rows[i]["Priority"]);
	 else
			 obj_buildingworkorder.Priority = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Requestor"]) != "")
			obj_buildingworkorder.Requestor = Convert.ToString(dt.Rows[i]["Requestor"]);
	 else
			 obj_buildingworkorder.Requestor = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_buildingworkorder.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_buildingworkorder.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_buildingworkorder.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_buildingworkorder.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_buildingworkorder;
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
