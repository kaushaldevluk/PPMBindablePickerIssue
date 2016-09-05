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
	public class workorderfollowupClass
    {
		#region "properties"
			public Int32  Workorderfollowupid {get;set;}
public Int32  Workorderid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Datecompleted {get;set;}
public Int32  Labour {get;set;}
public string  Partssuppies {get;set;}
public string  Note {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public workorderfollowupClass(){
		 
			Workorderfollowupid = 0;
			Workorderid = 0;
			Datecompleted = Convert.ToDateTime("1900-01-01");
			Labour = 0;
			Partssuppies = "update";
			Note = "update";
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class workorderfollowupCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public workorderfollowupCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public workorderfollowupCtl(Int32 id)
{
obj_con = new ConnectionCls();
workorderfollowupClass  obj_wor= new workorderfollowupClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_wor.Workorderfollowupid = Convert.ToInt32(dt.Rows[0]["Workorderfollowupid"]);
obj_wor.Workorderid = Convert.ToInt32(dt.Rows[0]["Workorderid"]);
obj_wor.Datecompleted = Convert.ToDateTime(dt.Rows[0]["Datecompleted"]);
obj_wor.Labour = Convert.ToInt32(dt.Rows[0]["Labour"]);
obj_wor.Partssuppies = Convert.ToString(dt.Rows[0]["Partssuppies"]);
obj_wor.Note = Convert.ToString(dt.Rows[0]["Note"]);
obj_wor.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_wor.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(workorderfollowupClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_workorderfollowup_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Workorderfollowupid = Convert.ToInt32(obj_con.getValue("@Workorderfollowupid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_workorderfollowup_insert");
}
}

//update data into database 
public Int32 update(workorderfollowupClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_workorderfollowup_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Workorderfollowupid = Convert.ToInt32(obj_con.getValue("@Workorderfollowupid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_workorderfollowup_update");
}
}

//delete data from database 
public void delete(Int32 Workorderfollowupid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Workorderfollowupid", Workorderfollowupid );
obj_con.ExecuteNoneQuery("sp_workorderfollowup_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_workorderfollowup_delete");
}
}

//select all data from database 
public List<workorderfollowupClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_workorderfollowup_selectall");
}
}

//select data from database as Paging
public List<workorderfollowupClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_workorderfollowup_selectPaging");
	 }
}

	 public List<workorderfollowupClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_workorderfollowup_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_workorderfollowup_selectIndexPaging");
		 }
	 }
	 public List<workorderfollowupClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<workorderfollowupClass> selectlist(Int32 Workorderfollowupid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderfollowupid", Workorderfollowupid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_workorderfollowup_select");
}
}

//select data from database as Objject
public workorderfollowupClass selectById(Int32 Workorderfollowupid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderfollowupid", Workorderfollowupid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_workorderfollowup_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Workorderfollowupid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Workorderfollowupid", Workorderfollowupid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_workorderfollowup_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_workorderfollowup_select");
}
}

//create parameter 
public void createParameter(workorderfollowupClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Workorderid", string.IsNullOrEmpty(Convert.ToString(obj.Workorderid)) ? 0 : obj.Workorderid);
obj_con.addParameter("@Datecompleted", string.IsNullOrEmpty(Convert.ToString(obj.Datecompleted)) ? Convert.ToDateTime("1900-01-01") : obj.Datecompleted);
obj_con.addParameter("@Labour", string.IsNullOrEmpty(Convert.ToString(obj.Labour)) ? 0 : obj.Labour);
obj_con.addParameter("@Partssuppies", string.IsNullOrEmpty(Convert.ToString(obj.Partssuppies)) ? "" : obj.Partssuppies);
obj_con.addParameter("@Note", string.IsNullOrEmpty(Convert.ToString(obj.Note)) ? "" : obj.Note);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Workorderfollowupid", obj.Workorderfollowupid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public workorderfollowupClass updateObject(workorderfollowupClass  obj)
{
try
{

	 workorderfollowupClass oldObj = selectById(obj.Workorderfollowupid);
 if (obj.Workorderid == null || obj.Workorderid.ToString().Trim() == "0")
	 obj.Workorderid = oldObj.Workorderid; 

 if (obj.Datecompleted == null || obj.Datecompleted == Convert.ToDateTime("1900-01-01"))
	 obj.Datecompleted = oldObj.Datecompleted; 

 if (obj.Labour == null || obj.Labour.ToString().Trim() == "0")
	 obj.Labour = oldObj.Labour; 

 if (obj.Partssuppies == null || obj.Partssuppies.ToString().Trim() == "update")
	 obj.Partssuppies = oldObj.Partssuppies; 

 if (obj.Note == null || obj.Note.ToString().Trim() == "update")
	 obj.Note = oldObj.Note; 

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
 public List<workorderfollowupClass> ConvertToList(DataTable dt)
{
 List<workorderfollowupClass> workorderfollowuplist = new List<workorderfollowupClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
workorderfollowupClass obj_workorderfollowup = new workorderfollowupClass();

		 if (Convert.ToString(dt.Rows[i]["Workorderfollowupid"]) != "")
			obj_workorderfollowup.Workorderfollowupid = Convert.ToInt32(dt.Rows[i]["Workorderfollowupid"]);
	 else
			 obj_workorderfollowup.Workorderfollowupid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorderid"]) != "")
			obj_workorderfollowup.Workorderid = Convert.ToInt32(dt.Rows[i]["Workorderid"]);
	 else
			 obj_workorderfollowup.Workorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Datecompleted"]) != "")
			obj_workorderfollowup.Datecompleted = Convert.ToDateTime(dt.Rows[i]["Datecompleted"]);
	 else
			 obj_workorderfollowup.Datecompleted = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Labour"]) != "")
			obj_workorderfollowup.Labour = Convert.ToInt32(dt.Rows[i]["Labour"]);
	 else
			 obj_workorderfollowup.Labour = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Partssuppies"]) != "")
			obj_workorderfollowup.Partssuppies = Convert.ToString(dt.Rows[i]["Partssuppies"]);
	 else
			 obj_workorderfollowup.Partssuppies = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Note"]) != "")
			obj_workorderfollowup.Note = Convert.ToString(dt.Rows[i]["Note"]);
	 else
			 obj_workorderfollowup.Note = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_workorderfollowup.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_workorderfollowup.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_workorderfollowup.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_workorderfollowup.Inserteddatetime = Convert.ToDateTime("01/01/1900");


workorderfollowuplist.Add(obj_workorderfollowup);
}
return workorderfollowuplist;
}

//Convert DataTable To object method
 public workorderfollowupClass ConvertToOjbect(DataTable dt)
{
 workorderfollowupClass obj_workorderfollowup = new workorderfollowupClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Workorderfollowupid"]) != "")
			obj_workorderfollowup.Workorderfollowupid = Convert.ToInt32(dt.Rows[i]["Workorderfollowupid"]);
	 else
			 obj_workorderfollowup.Workorderfollowupid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorderid"]) != "")
			obj_workorderfollowup.Workorderid = Convert.ToInt32(dt.Rows[i]["Workorderid"]);
	 else
			 obj_workorderfollowup.Workorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Datecompleted"]) != "")
			obj_workorderfollowup.Datecompleted = Convert.ToDateTime(dt.Rows[i]["Datecompleted"]);
	 else
			 obj_workorderfollowup.Datecompleted = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Labour"]) != "")
			obj_workorderfollowup.Labour = Convert.ToInt32(dt.Rows[i]["Labour"]);
	 else
			 obj_workorderfollowup.Labour = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Partssuppies"]) != "")
			obj_workorderfollowup.Partssuppies = Convert.ToString(dt.Rows[i]["Partssuppies"]);
	 else
			 obj_workorderfollowup.Partssuppies = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Note"]) != "")
			obj_workorderfollowup.Note = Convert.ToString(dt.Rows[i]["Note"]);
	 else
			 obj_workorderfollowup.Note = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_workorderfollowup.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_workorderfollowup.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_workorderfollowup.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_workorderfollowup.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_workorderfollowup;
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
