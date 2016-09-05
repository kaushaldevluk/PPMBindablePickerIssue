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
	public class buildingdeficiencyrepairClass
    {
		#region "properties"
			public Int32  Buildingdeficiencyrepairid {get;set;}
public Int32  Buildingid {get;set;}
public string  Description {get;set;}
public Int32  Quantity {get;set;}
public Int32  Units {get;set;}
public string  Priority {get;set;}
public string  Note {get;set;}
public Int32  Workareano {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public buildingdeficiencyrepairClass(){
		 
			Buildingdeficiencyrepairid = 0;
			Buildingid = 0;
			Description = "update";
			Quantity = 0;
			Units = 0;
			Priority = "update";
			Note = "update";
			Workareano = 0;
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class buildingdeficiencyrepairCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public buildingdeficiencyrepairCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public buildingdeficiencyrepairCtl(Int32 id)
{
obj_con = new ConnectionCls();
buildingdeficiencyrepairClass  obj_bui= new buildingdeficiencyrepairClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_bui.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[0]["Buildingdeficiencyrepairid"]);
obj_bui.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_bui.Description = Convert.ToString(dt.Rows[0]["Description"]);
obj_bui.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
obj_bui.Units = Convert.ToInt32(dt.Rows[0]["Units"]);
obj_bui.Priority = Convert.ToString(dt.Rows[0]["Priority"]);
obj_bui.Note = Convert.ToString(dt.Rows[0]["Note"]);
obj_bui.Workareano = Convert.ToInt32(dt.Rows[0]["Workareano"]);
obj_bui.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_bui.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(buildingdeficiencyrepairClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingdeficiencyrepair_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingdeficiencyrepairid = Convert.ToInt32(obj_con.getValue("@Buildingdeficiencyrepairid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingdeficiencyrepair_insert");
}
}

//update data into database 
public Int32 update(buildingdeficiencyrepairClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_buildingdeficiencyrepair_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingdeficiencyrepairid = Convert.ToInt32(obj_con.getValue("@Buildingdeficiencyrepairid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingdeficiencyrepair_update");
}
}

//delete data from database 
public void delete(Int32 Buildingdeficiencyrepairid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Buildingdeficiencyrepairid", Buildingdeficiencyrepairid );
obj_con.ExecuteNoneQuery("sp_buildingdeficiencyrepair_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_buildingdeficiencyrepair_delete");
}
}

//select all data from database 
public List<buildingdeficiencyrepairClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingdeficiencyrepair_selectall");
}
}

//select data from database as Paging
public List<buildingdeficiencyrepairClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_buildingdeficiencyrepair_selectPaging");
	 }
}

	 public List<buildingdeficiencyrepairClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingdeficiencyrepair_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_buildingdeficiencyrepair_selectIndexPaging");
		 }
	 }
	 public List<buildingdeficiencyrepairClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<buildingdeficiencyrepairClass> selectlist(Int32 Buildingdeficiencyrepairid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingdeficiencyrepairid", Buildingdeficiencyrepairid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingdeficiencyrepair_select");
}
}

//select data from database as Objject
public buildingdeficiencyrepairClass selectById(Int32 Buildingdeficiencyrepairid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingdeficiencyrepairid", Buildingdeficiencyrepairid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_buildingdeficiencyrepair_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Buildingdeficiencyrepairid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingdeficiencyrepairid", Buildingdeficiencyrepairid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_buildingdeficiencyrepair_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_buildingdeficiencyrepair_select");
}
}

//create parameter 
public void createParameter(buildingdeficiencyrepairClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Description", string.IsNullOrEmpty(Convert.ToString(obj.Description)) ? "" : obj.Description);
obj_con.addParameter("@Quantity", string.IsNullOrEmpty(Convert.ToString(obj.Quantity)) ? 0 : obj.Quantity);
obj_con.addParameter("@Units", string.IsNullOrEmpty(Convert.ToString(obj.Units)) ? 0 : obj.Units);
obj_con.addParameter("@Priority", string.IsNullOrEmpty(Convert.ToString(obj.Priority)) ? "" : obj.Priority);
obj_con.addParameter("@Note", string.IsNullOrEmpty(Convert.ToString(obj.Note)) ? "" : obj.Note);
obj_con.addParameter("@Workareano", string.IsNullOrEmpty(Convert.ToString(obj.Workareano)) ? 0 : obj.Workareano);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Buildingdeficiencyrepairid", obj.Buildingdeficiencyrepairid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public buildingdeficiencyrepairClass updateObject(buildingdeficiencyrepairClass  obj)
{
try
{

	 buildingdeficiencyrepairClass oldObj = selectById(obj.Buildingdeficiencyrepairid);
 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Description == null || obj.Description.ToString().Trim() == "update")
	 obj.Description = oldObj.Description; 

 if (obj.Quantity == null || obj.Quantity.ToString().Trim() == "0")
	 obj.Quantity = oldObj.Quantity; 

 if (obj.Units == null || obj.Units.ToString().Trim() == "0")
	 obj.Units = oldObj.Units; 

 if (obj.Priority == null || obj.Priority.ToString().Trim() == "update")
	 obj.Priority = oldObj.Priority; 

 if (obj.Note == null || obj.Note.ToString().Trim() == "update")
	 obj.Note = oldObj.Note; 

 if (obj.Workareano == null || obj.Workareano.ToString().Trim() == "0")
	 obj.Workareano = oldObj.Workareano; 

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
 public List<buildingdeficiencyrepairClass> ConvertToList(DataTable dt)
{
 List<buildingdeficiencyrepairClass> buildingdeficiencyrepairlist = new List<buildingdeficiencyrepairClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
buildingdeficiencyrepairClass obj_buildingdeficiencyrepair = new buildingdeficiencyrepairClass();

		 if (Convert.ToString(dt.Rows[i]["Buildingdeficiencyrepairid"]) != "")
			obj_buildingdeficiencyrepair.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[i]["Buildingdeficiencyrepairid"]);
	 else
			 obj_buildingdeficiencyrepair.Buildingdeficiencyrepairid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_buildingdeficiencyrepair.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_buildingdeficiencyrepair.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Description"]) != "")
			obj_buildingdeficiencyrepair.Description = Convert.ToString(dt.Rows[i]["Description"]);
	 else
			 obj_buildingdeficiencyrepair.Description = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Quantity"]) != "")
			obj_buildingdeficiencyrepair.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
	 else
			 obj_buildingdeficiencyrepair.Quantity = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Units"]) != "")
			obj_buildingdeficiencyrepair.Units = Convert.ToInt32(dt.Rows[i]["Units"]);
	 else
			 obj_buildingdeficiencyrepair.Units = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Priority"]) != "")
			obj_buildingdeficiencyrepair.Priority = Convert.ToString(dt.Rows[i]["Priority"]);
	 else
			 obj_buildingdeficiencyrepair.Priority = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Note"]) != "")
			obj_buildingdeficiencyrepair.Note = Convert.ToString(dt.Rows[i]["Note"]);
	 else
			 obj_buildingdeficiencyrepair.Note = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Workareano"]) != "")
			obj_buildingdeficiencyrepair.Workareano = Convert.ToInt32(dt.Rows[i]["Workareano"]);
	 else
			 obj_buildingdeficiencyrepair.Workareano = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_buildingdeficiencyrepair.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_buildingdeficiencyrepair.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_buildingdeficiencyrepair.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_buildingdeficiencyrepair.Inserteddatetime = Convert.ToDateTime("01/01/1900");


buildingdeficiencyrepairlist.Add(obj_buildingdeficiencyrepair);
}
return buildingdeficiencyrepairlist;
}

//Convert DataTable To object method
 public buildingdeficiencyrepairClass ConvertToOjbect(DataTable dt)
{
 buildingdeficiencyrepairClass obj_buildingdeficiencyrepair = new buildingdeficiencyrepairClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Buildingdeficiencyrepairid"]) != "")
			obj_buildingdeficiencyrepair.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[i]["Buildingdeficiencyrepairid"]);
	 else
			 obj_buildingdeficiencyrepair.Buildingdeficiencyrepairid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_buildingdeficiencyrepair.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_buildingdeficiencyrepair.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Description"]) != "")
			obj_buildingdeficiencyrepair.Description = Convert.ToString(dt.Rows[i]["Description"]);
	 else
			 obj_buildingdeficiencyrepair.Description = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Quantity"]) != "")
			obj_buildingdeficiencyrepair.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
	 else
			 obj_buildingdeficiencyrepair.Quantity = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Units"]) != "")
			obj_buildingdeficiencyrepair.Units = Convert.ToInt32(dt.Rows[i]["Units"]);
	 else
			 obj_buildingdeficiencyrepair.Units = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Priority"]) != "")
			obj_buildingdeficiencyrepair.Priority = Convert.ToString(dt.Rows[i]["Priority"]);
	 else
			 obj_buildingdeficiencyrepair.Priority = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Note"]) != "")
			obj_buildingdeficiencyrepair.Note = Convert.ToString(dt.Rows[i]["Note"]);
	 else
			 obj_buildingdeficiencyrepair.Note = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Workareano"]) != "")
			obj_buildingdeficiencyrepair.Workareano = Convert.ToInt32(dt.Rows[i]["Workareano"]);
	 else
			 obj_buildingdeficiencyrepair.Workareano = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_buildingdeficiencyrepair.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_buildingdeficiencyrepair.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_buildingdeficiencyrepair.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_buildingdeficiencyrepair.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_buildingdeficiencyrepair;
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
