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
	public class usersClass
    {
		#region "properties"
			public Int32  Userid {get;set;}
public string  Email {get;set;}
public string  Password {get;set;}
public string  Devicetype {get;set;}
public string  Deviceid {get;set;}
public bool  Isactive {get;set;}


	 public usersClass(){
		 
			Userid = 0;
			Email = "update";
			Password = "update";
			Devicetype = "update";
			Deviceid = "update";
			Isactive = false;
	 }
		#endregion
    }

	public class usersCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public usersCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public usersCtl(Int32 id)
{
obj_con = new ConnectionCls();
usersClass  obj_use= new usersClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_use.Userid = Convert.ToInt32(dt.Rows[0]["Userid"]);
obj_use.Email = Convert.ToString(dt.Rows[0]["Email"]);
obj_use.Password = Convert.ToString(dt.Rows[0]["Password"]);
obj_use.Devicetype = Convert.ToString(dt.Rows[0]["Devicetype"]);
obj_use.Deviceid = Convert.ToString(dt.Rows[0]["Deviceid"]);
obj_use.Isactive = Convert.ToBoolean(dt.Rows[0]["Isactive"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(usersClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_users_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Userid = Convert.ToInt32(obj_con.getValue("@Userid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_users_insert");
}
}

//update data into database 
public Int32 update(usersClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_users_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Userid = Convert.ToInt32(obj_con.getValue("@Userid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_users_update");
}
}

//delete data from database 
public void delete(Int32 Userid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Userid", Userid );
obj_con.ExecuteNoneQuery("sp_users_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_users_delete");
}
}

//select all data from database 
public List<usersClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_users_selectall");
}
}

//select data from database as Paging
public List<usersClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_users_selectPaging");
	 }
}

	 public List<usersClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_users_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_users_selectIndexPaging");
		 }
	 }
	 public List<usersClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<usersClass> selectlist(Int32 Userid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Userid", Userid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_users_select");
}
}

//select data from database as Objject
public usersClass selectById(Int32 Userid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Userid", Userid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_users_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Userid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Userid", Userid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_users_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_users_select");
}
}

//create parameter 
public void createParameter(usersClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Email", string.IsNullOrEmpty(Convert.ToString(obj.Email)) ? "" : obj.Email);
obj_con.addParameter("@Password", string.IsNullOrEmpty(Convert.ToString(obj.Password)) ? "" : obj.Password);
obj_con.addParameter("@Devicetype", string.IsNullOrEmpty(Convert.ToString(obj.Devicetype)) ? "" : obj.Devicetype);
obj_con.addParameter("@Deviceid", string.IsNullOrEmpty(Convert.ToString(obj.Deviceid)) ? "" : obj.Deviceid);
obj_con.addParameter("@Isactive", string.IsNullOrEmpty(Convert.ToString(obj.Isactive)) ? false : obj.Isactive);
obj_con.addParameter("@Userid", obj.Userid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public usersClass updateObject(usersClass  obj)
{
try
{

	 usersClass oldObj = selectById(obj.Userid);
 if (obj.Email == null || obj.Email.ToString().Trim() == "update")
	 obj.Email = oldObj.Email; 

 if (obj.Password == null || obj.Password.ToString().Trim() == "update")
	 obj.Password = oldObj.Password; 

 if (obj.Devicetype == null || obj.Devicetype.ToString().Trim() == "update")
	 obj.Devicetype = oldObj.Devicetype; 

 if (obj.Deviceid == null || obj.Deviceid.ToString().Trim() == "update")
	 obj.Deviceid = oldObj.Deviceid; 

 if (obj.Isactive == null || obj.Isactive.ToString().Trim() == "0")
	 obj.Isactive = oldObj.Isactive; 

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
 public List<usersClass> ConvertToList(DataTable dt)
{
 List<usersClass> userslist = new List<usersClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
usersClass obj_users = new usersClass();

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_users.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_users.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Email"]) != "")
			obj_users.Email = Convert.ToString(dt.Rows[i]["Email"]);
	 else
			 obj_users.Email = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Password"]) != "")
			obj_users.Password = Convert.ToString(dt.Rows[i]["Password"]);
	 else
			 obj_users.Password = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Devicetype"]) != "")
			obj_users.Devicetype = Convert.ToString(dt.Rows[i]["Devicetype"]);
	 else
			 obj_users.Devicetype = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deviceid"]) != "")
			obj_users.Deviceid = Convert.ToString(dt.Rows[i]["Deviceid"]);
	 else
			 obj_users.Deviceid = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Isactive"]) != "")
			obj_users.Isactive = Convert.ToBoolean(dt.Rows[i]["Isactive"]);
	 else
			 obj_users.Isactive = Convert.ToBoolean(0);


userslist.Add(obj_users);
}
return userslist;
}

//Convert DataTable To object method
 public usersClass ConvertToOjbect(DataTable dt)
{
 usersClass obj_users = new usersClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Userid"]) != "")
			obj_users.Userid = Convert.ToInt32(dt.Rows[i]["Userid"]);
	 else
			 obj_users.Userid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Email"]) != "")
			obj_users.Email = Convert.ToString(dt.Rows[i]["Email"]);
	 else
			 obj_users.Email = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Password"]) != "")
			obj_users.Password = Convert.ToString(dt.Rows[i]["Password"]);
	 else
			 obj_users.Password = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Devicetype"]) != "")
			obj_users.Devicetype = Convert.ToString(dt.Rows[i]["Devicetype"]);
	 else
			 obj_users.Devicetype = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Deviceid"]) != "")
			obj_users.Deviceid = Convert.ToString(dt.Rows[i]["Deviceid"]);
	 else
			 obj_users.Deviceid = Convert.ToString("");

		 if (Convert.ToString(dt.Rows[i]["Isactive"]) != "")
			obj_users.Isactive = Convert.ToBoolean(dt.Rows[i]["Isactive"]);
	 else
			 obj_users.Isactive = Convert.ToBoolean(0);
}
return obj_users;
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
