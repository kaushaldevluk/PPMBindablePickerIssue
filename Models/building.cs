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
	public class buildingClass
    {
		#region "properties"
			public Int32  Buildingid {get;set;}
public Int32  Locationid {get;set;}
public string  Buildingcode {get;set;}
public Int32  Buildingsystemid {get;set;}
public Int32  Systemelementid {get;set;}
public Int32  Systemtypeid {get;set;}
public Int32  Rating {get;set;}
public string  Details {get;set;}
public bool  Isdeficiencyrepair {get;set;}
public Int32  Projectid {get;set;}
public Int32  Servicecontractid {get;set;}
public string  Workorder {get;set;}
public string  Compliance {get;set;}
public Int32  Height {get;set;}
public Int32  Width {get;set;}
public Int32  Materialid {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}
public string  Addressline1 {get;set;}
public string  Addressline2 {get;set;}
public string  Locationcity {get;set;}
public Int32  Stateid {get;set;}
public string  Locationzip {get;set;}


	 public buildingClass(){
		 
			Buildingid = 0;
			Locationid = 0;
			Buildingcode = "update";
			Buildingsystemid = 0;
			Systemelementid = 0;
			Systemtypeid = 0;
			Rating = 0;
			Details = "update";
			Isdeficiencyrepair = false;
			Projectid = 0;
			Servicecontractid = 0;
			Workorder = "update";
			Compliance = "update";
			Height = 0;
			Width = 0;
			Materialid = 0;
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
			Addressline1 = "update";
			Addressline2 = "update";
			Locationcity = "update";
			Stateid = 0;
			Locationzip = "update";
	 }
		#endregion
    }

	public class buildingCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public buildingCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public buildingCtl(Int32 id)
{
obj_con = new ConnectionCls();
buildingClass  obj_bui= new buildingClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_bui.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_bui.Locationid = Convert.ToInt32(dt.Rows[0]["Locationid"]);
obj_bui.Buildingcode = Convert.ToString(dt.Rows[0]["Buildingcode"]);
obj_bui.Buildingsystemid = Convert.ToInt32(dt.Rows[0]["Buildingsystemid"]);
obj_bui.Systemelementid = Convert.ToInt32(dt.Rows[0]["Systemelementid"]);
obj_bui.Systemtypeid = Convert.ToInt32(dt.Rows[0]["Systemtypeid"]);
obj_bui.Rating = Convert.ToInt32(dt.Rows[0]["Rating"]);
obj_bui.Details = Convert.ToString(dt.Rows[0]["Details"]);
obj_bui.Isdeficiencyrepair = Convert.ToBoolean(dt.Rows[0]["Isdeficiencyrepair"]);
obj_bui.Projectid = Convert.ToInt32(dt.Rows[0]["Projectid"]);
obj_bui.Servicecontractid = Convert.ToInt32(dt.Rows[0]["Servicecontractid"]);
obj_bui.Workorder = Convert.ToString(dt.Rows[0]["Workorder"]);
obj_bui.Compliance = Convert.ToString(dt.Rows[0]["Compliance"]);
obj_bui.Height = Convert.ToInt32(dt.Rows[0]["Height"]);
obj_bui.Width = Convert.ToInt32(dt.Rows[0]["Width"]);
obj_bui.Materialid = Convert.ToInt32(dt.Rows[0]["Materialid"]);
obj_bui.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_bui.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);
obj_bui.Addressline1 = Convert.ToString(dt.Rows[0]["Addressline1"]);
obj_bui.Addressline2 = Convert.ToString(dt.Rows[0]["Addressline2"]);
obj_bui.Locationcity = Convert.ToString(dt.Rows[0]["Locationcity"]);
obj_bui.Stateid = Convert.ToInt32(dt.Rows[0]["Stateid"]);
obj_bui.Locationzip = Convert.ToString(dt.Rows[0]["Locationzip"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(buildingClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_building_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingid = Convert.ToInt32(obj_con.getValue("@Buildingid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_building_insert");
}
}

//update data into database 
public Int32 update(buildingClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_building_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Buildingid = Convert.ToInt32(obj_con.getValue("@Buildingid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_building_update");
}
}

//delete data from database 
public void delete(Int32 Buildingid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Buildingid", Buildingid );
obj_con.ExecuteNoneQuery("sp_building_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_building_delete");
}
}

//select all data from database 
public List<buildingClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_building_selectall");
}
}

//select data from database as Paging
public List<buildingClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_building_selectPaging");
	 }
}

	 public List<buildingClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_building_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_building_selectIndexPaging");
		 }
	 }
	 public List<buildingClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<buildingClass> selectlist(Int32 Buildingid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingid", Buildingid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_building_select");
}
}

//select data from database as Objject
public buildingClass selectById(Int32 Buildingid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingid", Buildingid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_building_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Buildingid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Buildingid", Buildingid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_building_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_building_select");
}
}

//create parameter 
public void createParameter(buildingClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Locationid", string.IsNullOrEmpty(Convert.ToString(obj.Locationid)) ? 0 : obj.Locationid);
obj_con.addParameter("@Buildingcode", string.IsNullOrEmpty(Convert.ToString(obj.Buildingcode)) ? "" : obj.Buildingcode);
obj_con.addParameter("@Buildingsystemid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingsystemid)) ? 0 : obj.Buildingsystemid);
obj_con.addParameter("@Systemelementid", string.IsNullOrEmpty(Convert.ToString(obj.Systemelementid)) ? 0 : obj.Systemelementid);
obj_con.addParameter("@Systemtypeid", string.IsNullOrEmpty(Convert.ToString(obj.Systemtypeid)) ? 0 : obj.Systemtypeid);
obj_con.addParameter("@Rating", string.IsNullOrEmpty(Convert.ToString(obj.Rating)) ? 0 : obj.Rating);
obj_con.addParameter("@Details", string.IsNullOrEmpty(Convert.ToString(obj.Details)) ? "" : obj.Details);
obj_con.addParameter("@Isdeficiencyrepair", string.IsNullOrEmpty(Convert.ToString(obj.Isdeficiencyrepair)) ? false : obj.Isdeficiencyrepair);
obj_con.addParameter("@Projectid", string.IsNullOrEmpty(Convert.ToString(obj.Projectid)) ? 0 : obj.Projectid);
obj_con.addParameter("@Servicecontractid", string.IsNullOrEmpty(Convert.ToString(obj.Servicecontractid)) ? 0 : obj.Servicecontractid);
obj_con.addParameter("@Workorder", string.IsNullOrEmpty(Convert.ToString(obj.Workorder)) ? "" : obj.Workorder);
obj_con.addParameter("@Compliance", string.IsNullOrEmpty(Convert.ToString(obj.Compliance)) ? "" : obj.Compliance);
obj_con.addParameter("@Height", string.IsNullOrEmpty(Convert.ToString(obj.Height)) ? 0 : obj.Height);
obj_con.addParameter("@Width", string.IsNullOrEmpty(Convert.ToString(obj.Width)) ? 0 : obj.Width);
obj_con.addParameter("@Materialid", string.IsNullOrEmpty(Convert.ToString(obj.Materialid)) ? 0 : obj.Materialid);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Addressline1", string.IsNullOrEmpty(Convert.ToString(obj.Addressline1)) ? "" : obj.Addressline1);
obj_con.addParameter("@Addressline2", string.IsNullOrEmpty(Convert.ToString(obj.Addressline2)) ? "" : obj.Addressline2);
obj_con.addParameter("@Locationcity", string.IsNullOrEmpty(Convert.ToString(obj.Locationcity)) ? "" : obj.Locationcity);
obj_con.addParameter("@Stateid", string.IsNullOrEmpty(Convert.ToString(obj.Stateid)) ? 0 : obj.Stateid);
obj_con.addParameter("@Locationzip", string.IsNullOrEmpty(Convert.ToString(obj.Locationzip)) ? "" : obj.Locationzip);
obj_con.addParameter("@Buildingid", obj.Buildingid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public buildingClass updateObject(buildingClass  obj)
{
try
{

	 buildingClass oldObj = selectById(obj.Buildingid);
 if (obj.Locationid == null || obj.Locationid.ToString().Trim() == "0")
	 obj.Locationid = oldObj.Locationid; 

 if (obj.Buildingcode == null || obj.Buildingcode.ToString().Trim() == "update")
	 obj.Buildingcode = oldObj.Buildingcode; 

 if (obj.Buildingsystemid == null || obj.Buildingsystemid.ToString().Trim() == "0")
	 obj.Buildingsystemid = oldObj.Buildingsystemid; 

 if (obj.Systemelementid == null || obj.Systemelementid.ToString().Trim() == "0")
	 obj.Systemelementid = oldObj.Systemelementid; 

 if (obj.Systemtypeid == null || obj.Systemtypeid.ToString().Trim() == "0")
	 obj.Systemtypeid = oldObj.Systemtypeid; 

 if (obj.Rating == null || obj.Rating.ToString().Trim() == "0")
	 obj.Rating = oldObj.Rating; 

 if (obj.Details == null || obj.Details.ToString().Trim() == "update")
	 obj.Details = oldObj.Details; 

 if (obj.Isdeficiencyrepair == null || obj.Isdeficiencyrepair.ToString().Trim() == "0")
	 obj.Isdeficiencyrepair = oldObj.Isdeficiencyrepair; 

 if (obj.Projectid == null || obj.Projectid.ToString().Trim() == "0")
	 obj.Projectid = oldObj.Projectid; 

 if (obj.Servicecontractid == null || obj.Servicecontractid.ToString().Trim() == "0")
	 obj.Servicecontractid = oldObj.Servicecontractid; 

 if (obj.Workorder == null || obj.Workorder.ToString().Trim() == "update")
	 obj.Workorder = oldObj.Workorder; 

 if (obj.Compliance == null || obj.Compliance.ToString().Trim() == "update")
	 obj.Compliance = oldObj.Compliance; 

 if (obj.Height == null || obj.Height.ToString().Trim() == "0")
	 obj.Height = oldObj.Height; 

 if (obj.Width == null || obj.Width.ToString().Trim() == "0")
	 obj.Width = oldObj.Width; 

 if (obj.Materialid == null || obj.Materialid.ToString().Trim() == "0")
	 obj.Materialid = oldObj.Materialid; 

 if (obj.Userid == null || obj.Userid.ToString().Trim() == "0")
	 obj.Userid = oldObj.Userid; 

 if (obj.Inserteddatetime == null || obj.Inserteddatetime == Convert.ToDateTime("1900-01-01"))
	 obj.Inserteddatetime = oldObj.Inserteddatetime; 

 if (obj.Addressline1 == null || obj.Addressline1.ToString().Trim() == "update")
	 obj.Addressline1 = oldObj.Addressline1; 

 if (obj.Addressline2 == null || obj.Addressline2.ToString().Trim() == "update")
	 obj.Addressline2 = oldObj.Addressline2; 

 if (obj.Locationcity == null || obj.Locationcity.ToString().Trim() == "update")
	 obj.Locationcity = oldObj.Locationcity; 

 if (obj.Stateid == null || obj.Stateid.ToString().Trim() == "0")
	 obj.Stateid = oldObj.Stateid; 

 if (obj.Locationzip == null || obj.Locationzip.ToString().Trim() == "update")
	 obj.Locationzip = oldObj.Locationzip; 

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
 public List<buildingClass> ConvertToList(DataTable dt)
{
 List<buildingClass> buildinglist = new List<buildingClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
buildingClass obj_building = new buildingClass();

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_building.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_building.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_building.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_building.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingcode"]) != "")
			obj_building.Buildingcode = Convert.ToString(dt.Rows[i]["Buildingcode"]);
	 else
			 obj_building.Buildingcode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_building.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_building.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_building.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_building.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemtypeid"]) != "")
			obj_building.Systemtypeid = Convert.ToInt32(dt.Rows[i]["Systemtypeid"]);
	 else
			 obj_building.Systemtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Rating"]) != "")
			obj_building.Rating = Convert.ToInt32(dt.Rows[i]["Rating"]);
	 else
			 obj_building.Rating = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Details"]) != "")
			obj_building.Details = Convert.ToString(dt.Rows[i]["Details"]);
	 else
			 obj_building.Details = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Isdeficiencyrepair"]) != "")
			obj_building.Isdeficiencyrepair = Convert.ToBoolean(dt.Rows[i]["Isdeficiencyrepair"]);
	 else
			 obj_building.Isdeficiencyrepair = Convert.ToBoolean(0);

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_building.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_building.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Servicecontractid"]) != "")
			obj_building.Servicecontractid = Convert.ToInt32(dt.Rows[i]["Servicecontractid"]);
	 else
			 obj_building.Servicecontractid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorder"]) != "")
			obj_building.Workorder = Convert.ToString(dt.Rows[i]["Workorder"]);
	 else
			 obj_building.Workorder = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Compliance"]) != "")
			obj_building.Compliance = Convert.ToString(dt.Rows[i]["Compliance"]);
	 else
			 obj_building.Compliance = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Height"]) != "")
			obj_building.Height = Convert.ToInt32(dt.Rows[i]["Height"]);
	 else
			 obj_building.Height = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Width"]) != "")
			obj_building.Width = Convert.ToInt32(dt.Rows[i]["Width"]);
	 else
			 obj_building.Width = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Materialid"]) != "")
			obj_building.Materialid = Convert.ToInt32(dt.Rows[i]["Materialid"]);
	 else
			 obj_building.Materialid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_building.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_building.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_building.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_building.Inserteddatetime = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_building.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_building.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_building.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_building.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_building.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_building.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_building.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_building.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_building.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_building.Locationzip = Convert.ToString("");


buildinglist.Add(obj_building);
}
return buildinglist;
}

//Convert DataTable To object method
 public buildingClass ConvertToOjbect(DataTable dt)
{
 buildingClass obj_building = new buildingClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_building.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_building.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_building.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_building.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingcode"]) != "")
			obj_building.Buildingcode = Convert.ToString(dt.Rows[i]["Buildingcode"]);
	 else
			 obj_building.Buildingcode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Buildingsystemid"]) != "")
			obj_building.Buildingsystemid = Convert.ToInt32(dt.Rows[i]["Buildingsystemid"]);
	 else
			 obj_building.Buildingsystemid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemelementid"]) != "")
			obj_building.Systemelementid = Convert.ToInt32(dt.Rows[i]["Systemelementid"]);
	 else
			 obj_building.Systemelementid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Systemtypeid"]) != "")
			obj_building.Systemtypeid = Convert.ToInt32(dt.Rows[i]["Systemtypeid"]);
	 else
			 obj_building.Systemtypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Rating"]) != "")
			obj_building.Rating = Convert.ToInt32(dt.Rows[i]["Rating"]);
	 else
			 obj_building.Rating = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Details"]) != "")
			obj_building.Details = Convert.ToString(dt.Rows[i]["Details"]);
	 else
			 obj_building.Details = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Isdeficiencyrepair"]) != "")
			obj_building.Isdeficiencyrepair = Convert.ToBoolean(dt.Rows[i]["Isdeficiencyrepair"]);
	 else
			 obj_building.Isdeficiencyrepair = Convert.ToBoolean(0);

		 if (Convert.ToString(dt.Rows[i]["Projectid"]) != "")
			obj_building.Projectid = Convert.ToInt32(dt.Rows[i]["Projectid"]);
	 else
			 obj_building.Projectid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Servicecontractid"]) != "")
			obj_building.Servicecontractid = Convert.ToInt32(dt.Rows[i]["Servicecontractid"]);
	 else
			 obj_building.Servicecontractid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorder"]) != "")
			obj_building.Workorder = Convert.ToString(dt.Rows[i]["Workorder"]);
	 else
			 obj_building.Workorder = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Compliance"]) != "")
			obj_building.Compliance = Convert.ToString(dt.Rows[i]["Compliance"]);
	 else
			 obj_building.Compliance = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Height"]) != "")
			obj_building.Height = Convert.ToInt32(dt.Rows[i]["Height"]);
	 else
			 obj_building.Height = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Width"]) != "")
			obj_building.Width = Convert.ToInt32(dt.Rows[i]["Width"]);
	 else
			 obj_building.Width = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Materialid"]) != "")
			obj_building.Materialid = Convert.ToInt32(dt.Rows[i]["Materialid"]);
	 else
			 obj_building.Materialid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_building.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_building.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_building.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_building.Inserteddatetime = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_building.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_building.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_building.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_building.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_building.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_building.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_building.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_building.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_building.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_building.Locationzip = Convert.ToString("");
}
return obj_building;
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
