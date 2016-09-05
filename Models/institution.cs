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
	public class institutionClass
    {
		#region "properties"
			public Int32  Institutionid {get;set;}
public string  Institutioncode {get;set;}
public Int32  Institutiontypeid {get;set;}
public string  Shortname {get;set;}
public string  Legalname {get;set;}
public string  Addressline1 {get;set;}
public string  Addressline2 {get;set;}
public string  Locationcity {get;set;}
public Int32  Stateid {get;set;}
public string  Locationzip {get;set;}


	 public institutionClass(){
		 
			Institutionid = 0;
			Institutioncode = "update";
			Institutiontypeid = 0;
			Shortname = "update";
			Legalname = "update";
			Addressline1 = "update";
			Addressline2 = "update";
			Locationcity = "update";
			Stateid = 0;
			Locationzip = "update";
	 }
		#endregion
    }

	public class institutionCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public institutionCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public institutionCtl(Int32 id)
{
obj_con = new ConnectionCls();
institutionClass  obj_ins= new institutionClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_ins.Institutionid = Convert.ToInt32(dt.Rows[0]["Institutionid"]);
obj_ins.Institutioncode = Convert.ToString(dt.Rows[0]["Institutioncode"]);
obj_ins.Institutiontypeid = Convert.ToInt32(dt.Rows[0]["Institutiontypeid"]);
obj_ins.Shortname = Convert.ToString(dt.Rows[0]["Shortname"]);
obj_ins.Legalname = Convert.ToString(dt.Rows[0]["Legalname"]);
obj_ins.Addressline1 = Convert.ToString(dt.Rows[0]["Addressline1"]);
obj_ins.Addressline2 = Convert.ToString(dt.Rows[0]["Addressline2"]);
obj_ins.Locationcity = Convert.ToString(dt.Rows[0]["Locationcity"]);
obj_ins.Stateid = Convert.ToInt32(dt.Rows[0]["Stateid"]);
obj_ins.Locationzip = Convert.ToString(dt.Rows[0]["Locationzip"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(institutionClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_institution_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Institutionid = Convert.ToInt32(obj_con.getValue("@Institutionid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institution_insert");
}
}

//update data into database 
public Int32 update(institutionClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_institution_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Institutionid = Convert.ToInt32(obj_con.getValue("@Institutionid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institution_update");
}
}

//delete data from database 
public void delete(Int32 Institutionid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Institutionid", Institutionid );
obj_con.ExecuteNoneQuery("sp_institution_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institution_delete");
}
}

//select all data from database 
public List<institutionClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institution_selectall");
}
}

//select data from database as Paging
public List<institutionClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_institution_selectPaging");
	 }
}

	 public List<institutionClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_institution_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_institution_selectIndexPaging");
		 }
	 }
	 public List<institutionClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<institutionClass> selectlist(Int32 Institutionid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutionid", Institutionid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institution_select");
}
}

//select data from database as Objject
public institutionClass selectById(Int32 Institutionid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutionid", Institutionid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institution_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Institutionid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutionid", Institutionid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institution_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_institution_select");
}
}

//create parameter 
public void createParameter(institutionClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Institutioncode", string.IsNullOrEmpty(Convert.ToString(obj.Institutioncode)) ? "" : obj.Institutioncode);
obj_con.addParameter("@Institutiontypeid", string.IsNullOrEmpty(Convert.ToString(obj.Institutiontypeid)) ? 0 : obj.Institutiontypeid);
obj_con.addParameter("@Shortname", string.IsNullOrEmpty(Convert.ToString(obj.Shortname)) ? "" : obj.Shortname);
obj_con.addParameter("@Legalname", string.IsNullOrEmpty(Convert.ToString(obj.Legalname)) ? "" : obj.Legalname);
obj_con.addParameter("@Addressline1", string.IsNullOrEmpty(Convert.ToString(obj.Addressline1)) ? "" : obj.Addressline1);
obj_con.addParameter("@Addressline2", string.IsNullOrEmpty(Convert.ToString(obj.Addressline2)) ? "" : obj.Addressline2);
obj_con.addParameter("@Locationcity", string.IsNullOrEmpty(Convert.ToString(obj.Locationcity)) ? "" : obj.Locationcity);
obj_con.addParameter("@Stateid", string.IsNullOrEmpty(Convert.ToString(obj.Stateid)) ? 0 : obj.Stateid);
obj_con.addParameter("@Locationzip", string.IsNullOrEmpty(Convert.ToString(obj.Locationzip)) ? "" : obj.Locationzip);
obj_con.addParameter("@Institutionid", obj.Institutionid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public institutionClass updateObject(institutionClass  obj)
{
try
{

	 institutionClass oldObj = selectById(obj.Institutionid);
 if (obj.Institutioncode == null || obj.Institutioncode.ToString().Trim() == "update")
	 obj.Institutioncode = oldObj.Institutioncode; 

 if (obj.Institutiontypeid == null || obj.Institutiontypeid.ToString().Trim() == "0")
	 obj.Institutiontypeid = oldObj.Institutiontypeid; 

 if (obj.Shortname == null || obj.Shortname.ToString().Trim() == "update")
	 obj.Shortname = oldObj.Shortname; 

 if (obj.Legalname == null || obj.Legalname.ToString().Trim() == "update")
	 obj.Legalname = oldObj.Legalname; 

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
 public List<institutionClass> ConvertToList(DataTable dt)
{
 List<institutionClass> institutionlist = new List<institutionClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
institutionClass obj_institution = new institutionClass();

		 if (Convert.ToString(dt.Rows[i]["Institutionid"]) != "")
			obj_institution.Institutionid = Convert.ToInt32(dt.Rows[i]["Institutionid"]);
	 else
			 obj_institution.Institutionid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutioncode"]) != "")
			obj_institution.Institutioncode = Convert.ToString(dt.Rows[i]["Institutioncode"]);
	 else
			 obj_institution.Institutioncode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Institutiontypeid"]) != "")
			obj_institution.Institutiontypeid = Convert.ToInt32(dt.Rows[i]["Institutiontypeid"]);
	 else
			 obj_institution.Institutiontypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Shortname"]) != "")
			obj_institution.Shortname = Convert.ToString(dt.Rows[i]["Shortname"]);
	 else
			 obj_institution.Shortname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Legalname"]) != "")
			obj_institution.Legalname = Convert.ToString(dt.Rows[i]["Legalname"]);
	 else
			 obj_institution.Legalname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_institution.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_institution.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_institution.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_institution.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_institution.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_institution.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_institution.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_institution.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_institution.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_institution.Locationzip = Convert.ToString("");


institutionlist.Add(obj_institution);
}
return institutionlist;
}

//Convert DataTable To object method
 public institutionClass ConvertToOjbect(DataTable dt)
{
 institutionClass obj_institution = new institutionClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Institutionid"]) != "")
			obj_institution.Institutionid = Convert.ToInt32(dt.Rows[i]["Institutionid"]);
	 else
			 obj_institution.Institutionid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutioncode"]) != "")
			obj_institution.Institutioncode = Convert.ToString(dt.Rows[i]["Institutioncode"]);
	 else
			 obj_institution.Institutioncode = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Institutiontypeid"]) != "")
			obj_institution.Institutiontypeid = Convert.ToInt32(dt.Rows[i]["Institutiontypeid"]);
	 else
			 obj_institution.Institutiontypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Shortname"]) != "")
			obj_institution.Shortname = Convert.ToString(dt.Rows[i]["Shortname"]);
	 else
			 obj_institution.Shortname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Legalname"]) != "")
			obj_institution.Legalname = Convert.ToString(dt.Rows[i]["Legalname"]);
	 else
			 obj_institution.Legalname = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline1"]) != "")
			obj_institution.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
	 else
			 obj_institution.Addressline1 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Addressline2"]) != "")
			obj_institution.Addressline2 = Convert.ToString(dt.Rows[i]["Addressline2"]);
	 else
			 obj_institution.Addressline2 = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Locationcity"]) != "")
			obj_institution.Locationcity = Convert.ToString(dt.Rows[i]["Locationcity"]);
	 else
			 obj_institution.Locationcity = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Stateid"]) != "")
			obj_institution.Stateid = Convert.ToInt32(dt.Rows[i]["Stateid"]);
	 else
			 obj_institution.Stateid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Locationzip"]) != "")
			obj_institution.Locationzip = Convert.ToString(dt.Rows[i]["Locationzip"]);
	 else
			 obj_institution.Locationzip = Convert.ToString("");
}
return obj_institution;
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
