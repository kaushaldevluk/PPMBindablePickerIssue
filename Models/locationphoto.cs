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
	public class locationphotoClass
    {
		#region "properties"
			public Int32  Locationphotoid {get;set;}
public Int32  Locationid {get;set;}
public string  Photodescription {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Photouploadeddate {get;set;}
public Int32  Buildingid {get;set;}
public Int32  Buildingdeficiencyrepairid {get;set;}
public Int32  Buildingworkorderid {get;set;}
public Int32  Workorderfollowupid {get;set;}
public Int32  Userid {get;set;}
 [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
			 public DateTime  Inserteddatetime {get;set;}


	 public locationphotoClass(){
		 
			Locationphotoid = 0;
			Locationid = 0;
			Photodescription = "update";
			Photouploadeddate = Convert.ToDateTime("1900-01-01");
			Buildingid = 0;
			Buildingdeficiencyrepairid = 0;
			Buildingworkorderid = 0;
			Workorderfollowupid = 0;
			Userid = 0;
			Inserteddatetime = Convert.ToDateTime("1900-01-01");
	 }
		#endregion
    }

	public class locationphotoCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public locationphotoCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public locationphotoCtl(Int32 id)
{
obj_con = new ConnectionCls();
locationphotoClass  obj_loc= new locationphotoClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_loc.Locationphotoid = Convert.ToInt32(dt.Rows[0]["Locationphotoid"]);
obj_loc.Locationid = Convert.ToInt32(dt.Rows[0]["Locationid"]);
obj_loc.Photodescription = Convert.ToString(dt.Rows[0]["Photodescription"]);
obj_loc.Photouploadeddate = Convert.ToDateTime(dt.Rows[0]["Photouploadeddate"]);
obj_loc.Buildingid = Convert.ToInt32(dt.Rows[0]["Buildingid"]);
obj_loc.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[0]["Buildingdeficiencyrepairid"]);
obj_loc.Buildingworkorderid = Convert.ToInt32(dt.Rows[0]["Buildingworkorderid"]);
obj_loc.Workorderfollowupid = Convert.ToInt32(dt.Rows[0]["Workorderfollowupid"]);
obj_loc.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_loc.Inserteddatetime = Convert.ToDateTime(dt.Rows[0]["Inserteddatetime"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(locationphotoClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_locationphoto_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Locationphotoid = Convert.ToInt32(obj_con.getValue("@Locationphotoid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_locationphoto_insert");
}
}

//update data into database 
public Int32 update(locationphotoClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_locationphoto_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Locationphotoid = Convert.ToInt32(obj_con.getValue("@Locationphotoid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_locationphoto_update");
}
}

//delete data from database 
public void delete(Int32 Locationphotoid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Locationphotoid", Locationphotoid );
obj_con.ExecuteNoneQuery("sp_locationphoto_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_locationphoto_delete");
}
}

//select all data from database 
public List<locationphotoClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_locationphoto_selectall");
}
}

//select data from database as Paging
public List<locationphotoClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_locationphoto_selectPaging");
	 }
}

	 public List<locationphotoClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_locationphoto_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_locationphoto_selectIndexPaging");
		 }
	 }
	 public List<locationphotoClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<locationphotoClass> selectlist(Int32 Locationphotoid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationphotoid", Locationphotoid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_locationphoto_select");
}
}

//select data from database as Objject
public locationphotoClass selectById(Int32 Locationphotoid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationphotoid", Locationphotoid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_locationphoto_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Locationphotoid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Locationphotoid", Locationphotoid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_locationphoto_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_locationphoto_select");
}
}

//create parameter 
public void createParameter(locationphotoClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Locationid", string.IsNullOrEmpty(Convert.ToString(obj.Locationid)) ? 0 : obj.Locationid);
obj_con.addParameter("@Photodescription", string.IsNullOrEmpty(Convert.ToString(obj.Photodescription)) ? "" : obj.Photodescription);
obj_con.addParameter("@Photouploadeddate", string.IsNullOrEmpty(Convert.ToString(obj.Photouploadeddate)) ? Convert.ToDateTime("1900-01-01") : obj.Photouploadeddate);
obj_con.addParameter("@Buildingid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingid)) ? 0 : obj.Buildingid);
obj_con.addParameter("@Buildingdeficiencyrepairid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingdeficiencyrepairid)) ? 0 : obj.Buildingdeficiencyrepairid);
obj_con.addParameter("@Buildingworkorderid", string.IsNullOrEmpty(Convert.ToString(obj.Buildingworkorderid)) ? 0 : obj.Buildingworkorderid);
obj_con.addParameter("@Workorderfollowupid", string.IsNullOrEmpty(Convert.ToString(obj.Workorderfollowupid)) ? 0 : obj.Workorderfollowupid);
obj_con.addParameter("@Userid", string.IsNullOrEmpty(Convert.ToString(obj.Userid)) ? 0 : obj.Userid);
obj_con.addParameter("@Inserteddatetime", string.IsNullOrEmpty(Convert.ToString(obj.Inserteddatetime)) ? Convert.ToDateTime("1900-01-01") : obj.Inserteddatetime);
obj_con.addParameter("@Locationphotoid", obj.Locationphotoid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public locationphotoClass updateObject(locationphotoClass  obj)
{
try
{

	 locationphotoClass oldObj = selectById(obj.Locationphotoid);
 if (obj.Locationid == null || obj.Locationid.ToString().Trim() == "0")
	 obj.Locationid = oldObj.Locationid; 

 if (obj.Photodescription == null || obj.Photodescription.ToString().Trim() == "update")
	 obj.Photodescription = oldObj.Photodescription; 

 if (obj.Photouploadeddate == null || obj.Photouploadeddate == Convert.ToDateTime("1900-01-01"))
	 obj.Photouploadeddate = oldObj.Photouploadeddate; 

 if (obj.Buildingid == null || obj.Buildingid.ToString().Trim() == "0")
	 obj.Buildingid = oldObj.Buildingid; 

 if (obj.Buildingdeficiencyrepairid == null || obj.Buildingdeficiencyrepairid.ToString().Trim() == "0")
	 obj.Buildingdeficiencyrepairid = oldObj.Buildingdeficiencyrepairid; 

 if (obj.Buildingworkorderid == null || obj.Buildingworkorderid.ToString().Trim() == "0")
	 obj.Buildingworkorderid = oldObj.Buildingworkorderid; 

 if (obj.Workorderfollowupid == null || obj.Workorderfollowupid.ToString().Trim() == "0")
	 obj.Workorderfollowupid = oldObj.Workorderfollowupid; 

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
 public List<locationphotoClass> ConvertToList(DataTable dt)
{
 List<locationphotoClass> locationphotolist = new List<locationphotoClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
locationphotoClass obj_locationphoto = new locationphotoClass();

		 if (Convert.ToString(dt.Rows[i]["Locationphotoid"]) != "")
			obj_locationphoto.Locationphotoid = Convert.ToInt32(dt.Rows[i]["Locationphotoid"]);
	 else
			 obj_locationphoto.Locationphotoid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_locationphoto.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_locationphoto.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Photodescription"]) != "")
			obj_locationphoto.Photodescription = Convert.ToString(dt.Rows[i]["Photodescription"]);
	 else
			 obj_locationphoto.Photodescription = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Photouploadeddate"]) != "")
			obj_locationphoto.Photouploadeddate = Convert.ToDateTime(dt.Rows[i]["Photouploadeddate"]);
	 else
			 obj_locationphoto.Photouploadeddate = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_locationphoto.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_locationphoto.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingdeficiencyrepairid"]) != "")
			obj_locationphoto.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[i]["Buildingdeficiencyrepairid"]);
	 else
			 obj_locationphoto.Buildingdeficiencyrepairid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingworkorderid"]) != "")
			obj_locationphoto.Buildingworkorderid = Convert.ToInt32(dt.Rows[i]["Buildingworkorderid"]);
	 else
			 obj_locationphoto.Buildingworkorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorderfollowupid"]) != "")
			obj_locationphoto.Workorderfollowupid = Convert.ToInt32(dt.Rows[i]["Workorderfollowupid"]);
	 else
			 obj_locationphoto.Workorderfollowupid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_locationphoto.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_locationphoto.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_locationphoto.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_locationphoto.Inserteddatetime = Convert.ToDateTime("01/01/1900");


locationphotolist.Add(obj_locationphoto);
}
return locationphotolist;
}

//Convert DataTable To object method
 public locationphotoClass ConvertToOjbect(DataTable dt)
{
 locationphotoClass obj_locationphoto = new locationphotoClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Locationphotoid"]) != "")
			obj_locationphoto.Locationphotoid = Convert.ToInt32(dt.Rows[i]["Locationphotoid"]);
	 else
			 obj_locationphoto.Locationphotoid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationid"]) != "")
			obj_locationphoto.Locationid = Convert.ToInt32(dt.Rows[i]["Locationid"]);
	 else
			 obj_locationphoto.Locationid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Photodescription"]) != "")
			obj_locationphoto.Photodescription = Convert.ToString(dt.Rows[i]["Photodescription"]);
	 else
			 obj_locationphoto.Photodescription = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Photouploadeddate"]) != "")
			obj_locationphoto.Photouploadeddate = Convert.ToDateTime(dt.Rows[i]["Photouploadeddate"]);
	 else
			 obj_locationphoto.Photouploadeddate = Convert.ToDateTime("01/01/1900");

		 if (Convert.ToString(dt.Rows[i]["Buildingid"]) != "")
			obj_locationphoto.Buildingid = Convert.ToInt32(dt.Rows[i]["Buildingid"]);
	 else
			 obj_locationphoto.Buildingid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingdeficiencyrepairid"]) != "")
			obj_locationphoto.Buildingdeficiencyrepairid = Convert.ToInt32(dt.Rows[i]["Buildingdeficiencyrepairid"]);
	 else
			 obj_locationphoto.Buildingdeficiencyrepairid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Buildingworkorderid"]) != "")
			obj_locationphoto.Buildingworkorderid = Convert.ToInt32(dt.Rows[i]["Buildingworkorderid"]);
	 else
			 obj_locationphoto.Buildingworkorderid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Workorderfollowupid"]) != "")
			obj_locationphoto.Workorderfollowupid = Convert.ToInt32(dt.Rows[i]["Workorderfollowupid"]);
	 else
			 obj_locationphoto.Workorderfollowupid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_locationphoto.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_locationphoto.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Inserteddatetime"]) != "")
			obj_locationphoto.Inserteddatetime = Convert.ToDateTime(dt.Rows[i]["Inserteddatetime"]);
	 else
			 obj_locationphoto.Inserteddatetime = Convert.ToDateTime("01/01/1900");
}
return obj_locationphoto;
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
