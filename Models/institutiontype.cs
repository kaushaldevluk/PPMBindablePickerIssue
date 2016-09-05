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
	public class institutiontypeClass
    {
		#region "properties"
			public Int32  Institutiontypeid {get;set;}
public string  Institutiontypename {get;set;}


	 public institutiontypeClass(){
		 
			Institutiontypeid = 0;
			Institutiontypename = "update";
	 }
		#endregion
    }

	public class institutiontypeCtl :  IDisposable
	{
		#region "constructors"
		
			ConnectionCls obj_con = null;
//Default Constructor
public institutiontypeCtl()
{
	 obj_con = new ConnectionCls();
}

//Select Constructor
public institutiontypeCtl(Int32 id)
{
obj_con = new ConnectionCls();
institutiontypeClass  obj_ins= new institutiontypeClass();
using (DataTable dt = selectdatatable(id))
{
if (dt.Rows.Count > 0)
{

obj_ins.Institutiontypeid = Convert.ToInt32(dt.Rows[0]["Institutiontypeid"]);
obj_ins.Institutiontypename = Convert.ToString(dt.Rows[0]["Institutiontypename"]);

}
}
}

			
		#endregion
		
		#region "methods"
		
			//insert data into database 
public Int32 insert(institutiontypeClass obj)
{
try 
{
obj_con.clearParameter();
createParameter(obj, DBTrans.Insert);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_institutiontype_insert", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Institutiontypeid = Convert.ToInt32(obj_con.getValue("@Institutiontypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institutiontype_insert");
}
}

//update data into database 
public Int32 update(institutiontypeClass obj)
{
try 
{
obj_con.clearParameter();
obj = updateObject(obj);
createParameter(obj, DBTrans.Update);
obj_con.BeginTransaction();
obj_con.ExecuteNoneQuery("sp_institutiontype_update", CommandType.StoredProcedure);
obj_con.CommitTransaction();
return obj.Institutiontypeid = Convert.ToInt32(obj_con.getValue("@Institutiontypeid"));
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institutiontype_update");
}
}

//delete data from database 
public void delete(Int32 Institutiontypeid)
{
try 
{
obj_con.clearParameter();
obj_con.BeginTransaction();
obj_con.addParameter("@Institutiontypeid", Institutiontypeid );
obj_con.ExecuteNoneQuery("sp_institutiontype_delete", CommandType.StoredProcedure);
obj_con.CommitTransaction();
}
catch (Exception ex)
{
obj_con.RollbackTransaction();
throw new Exception("sp_institutiontype_delete");
}
}

//select all data from database 
public List<institutiontypeClass> getAll()
{
try 
{
obj_con.clearParameter();
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_selectall", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institutiontype_selectall");
}
}

//select data from database as Paging
public List<institutiontypeClass> selectPaging(Int64 firstPageIndex, Int64 pageSize)
{
	 try 
	 {
		 obj_con.clearParameter();
		 obj_con.addParameter("@pageFirstIndex", firstPageIndex );
		 obj_con.addParameter("@pageLastIndex", pageSize );
		 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_selectPaging", CommandType.StoredProcedure));
		 obj_con.CommitTransaction();
		 obj_con.closeConnection();
		 return ConvertToList(dt);
	  }
	 catch (Exception ex)
	 {
		 throw new Exception("sp_institutiontype_selectPaging");
	 }
}

	 public List<institutiontypeClass> selectIndexPaging(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return ConvertToList(dt);
		 } catch (Exception ex){
			 throw new Exception("sp_institutiontype_selectIndexPaging");
		 }
	 }
	 public Int32 selectIndexPagingCount(Int64 PageSize, Int64 PageIndex, string Search){
		 try{
			 obj_con.clearParameter();
			 obj_con.addParameter("@PageSize", PageSize);
			 obj_con.addParameter("@PageIndex", PageIndex);
			 obj_con.addParameter("@Search", Search);
			 DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_selectIndexPaging", CommandType.StoredProcedure));
			 obj_con.CommitTransaction();
			 obj_con.closeConnection();
			 return Convert.ToInt32(dt.Rows[0][0]);
		 } catch (Exception ex){
			 throw new Exception("sp_institutiontype_selectIndexPaging");
		 }
	 }
	 public List<institutiontypeClass> selectIndexLazyLoading(Int64 StartIndex, Int64 EndIndex, string Search){
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
public List<institutiontypeClass> selectlist(Int32 Institutiontypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutiontypeid", Institutiontypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToList(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institutiontype_select");
}
}

//select data from database as Objject
public institutiontypeClass selectById(Int32 Institutiontypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutiontypeid", Institutiontypeid );
DataTable dt = ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_select", CommandType.StoredProcedure));
obj_con.CommitTransaction();
obj_con.closeConnection();
return ConvertToOjbect(dt);
}
catch (Exception ex)
{
throw new Exception("sp_institutiontype_select");
}
}

//select data from database as datatable
public DataTable selectdatatable(Int32 Institutiontypeid)
{
try 
{
obj_con.clearParameter();
obj_con.addParameter("@Institutiontypeid", Institutiontypeid );
return ConvertDatareadertoDataTable(obj_con.ExecuteReader("sp_institutiontype_select", CommandType.StoredProcedure));
}
catch (Exception ex)
{
throw new Exception("sp_institutiontype_select");
}
}

//create parameter 
public void createParameter(institutiontypeClass  obj, DB_con.DBTrans trans)
{
try
{
	 obj_con.clearParameter();
obj_con.addParameter("@Institutiontypename", string.IsNullOrEmpty(Convert.ToString(obj.Institutiontypename)) ? "" : obj.Institutiontypename);
obj_con.addParameter("@Institutiontypeid", obj.Institutiontypeid, trans);
}
catch (Exception ex)
{
throw ex;
}
}

//update edited object 
public institutiontypeClass updateObject(institutiontypeClass  obj)
{
try
{

	 institutiontypeClass oldObj = selectById(obj.Institutiontypeid);
 if (obj.Institutiontypename == null || obj.Institutiontypename.ToString().Trim() == "update")
	 obj.Institutiontypename = oldObj.Institutiontypename; 

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
 public List<institutiontypeClass> ConvertToList(DataTable dt)
{
 List<institutiontypeClass> institutiontypelist = new List<institutiontypeClass>();
for(int i = 0; i<dt.Rows.Count; i++)
{
institutiontypeClass obj_institutiontype = new institutiontypeClass();

		 if (Convert.ToString(dt.Rows[i]["Institutiontypeid"]) != "")
			obj_institutiontype.Institutiontypeid = Convert.ToInt32(dt.Rows[i]["Institutiontypeid"]);
	 else
			 obj_institutiontype.Institutiontypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutiontypename"]) != "")
			obj_institutiontype.Institutiontypename = Convert.ToString(dt.Rows[i]["Institutiontypename"]);
	 else
			 obj_institutiontype.Institutiontypename = Convert.ToString("");


institutiontypelist.Add(obj_institutiontype);
}
return institutiontypelist;
}

//Convert DataTable To object method
 public institutiontypeClass ConvertToOjbect(DataTable dt)
{
 institutiontypeClass obj_institutiontype = new institutiontypeClass();
for(int i = 0; i<dt.Rows.Count; i++)
{

		 if (Convert.ToString(dt.Rows[i]["Institutiontypeid"]) != "")
			obj_institutiontype.Institutiontypeid = Convert.ToInt32(dt.Rows[i]["Institutiontypeid"]);
	 else
			 obj_institutiontype.Institutiontypeid = Convert.ToInt32("0");

		 if (Convert.ToString(dt.Rows[i]["Institutiontypename"]) != "")
			obj_institutiontype.Institutiontypename = Convert.ToString(dt.Rows[i]["Institutiontypename"]);
	 else
			 obj_institutiontype.Institutiontypename = Convert.ToString("");
}
return obj_institutiontype;
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
