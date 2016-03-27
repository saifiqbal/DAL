using CoreBusiness;
using CoreBusiness;
using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL;

namespace DAL.SuperAdmin
{
    public class SuperAdminAccess
    {


        public SqlDataReader GetCitiesForMerchantState(SqlConnection connection, int StateID)
        {
            return SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, "getCities", new SqlParameter("@StateID", StateID));
        }

        public SqlDataReader GetStatesForMerchantCountry(SqlConnection connection, int CountryId)
        {
            return SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, "getStates", new SqlParameter("@CountryID", CountryId));
        }
        public string GetMenuForCurrentUser(string area, long UserID)
        {
            SqlConnection connection = mySQLConnection.Open();
            string xmlMenu = string.Empty;

            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "usp_GetMenu", area, UserID))
                {
                    while (dr.Read())
                    {
                        xmlMenu = dr[0].ToString();
                    }
                }
                mySQLConnection.Close(connection);
            }
            catch (Exception ex)
            {
                mySQLConnection.Close(connection);
                throw ex;
            }

            return xmlMenu;

        }
        public DataSet GetCompanies()
        {
            DataSet ds = new DataSet();
            SqlConnection connection = mySQLConnection.Open();

            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "GetCompanies"))
                {
                    DataTable dt = new DataTable("Table0");
                    ds.Tables.Add(dt);
                    ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
                }
             //   return ds;


            }
            catch
            {
                mySQLConnection.Close(connection);
             //   return new Result("Error", "GetCompanies", ResultType.Failure);
            }
            finally
            {
                mySQLConnection.Close(connection);
            }
            return ds;
        }

        //public Result GetCompanies()
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = mySQLConnection.Open();

        //    try
        //    {
        //        using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "GetCompanies"))
        //        {
        //            DataTable dt = new DataTable("Table0");
        //            ds.Tables.Add(dt);
        //            ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
        //        }
        //        CoreBusiness.mySQLConnection.Close(connection);
        //        return new Result("Success", "", ResultType.Success, ds);
             

        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "GetCompanies", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }
        //}

        ////CompanyID, CompanyName, Description, ContactPerson, CellPhone, WorkPhone, Theme, Status
        public int UpdateCompanyInfo(long CompanyID, string CompanyName, string Description, string ContactPerson, string CellPhone, string WorkPhone, string LogoImage, string Theme, int Status, string username, string password, string FName, string LName, long UserID,
            string EmailTo, string EmailFrom, string NotificationEmailTo, int IsNacha, int IsEpx, string AddressLine1, string AddressLine2, string ZipCode, int StateID, int CityID)
        {
            SqlConnection connection = mySQLConnection.Open();
            int isUpdated = 0;
            try
            {
                isUpdated = SqlHelper.ExecuteNonQuery(connection, "UpdateCompanyInfo", CompanyID, CompanyName, Description, ContactPerson, CellPhone, WorkPhone, LogoImage, Theme, Status, username, password, FName, LName, UserID, EmailTo, EmailFrom, IsNacha, IsEpx, NotificationEmailTo, AddressLine1, AddressLine2, ZipCode, StateID, CityID);
            }
            catch (Exception ex)
            {
                mySQLConnection.Close(connection);
            
            }
            finally
            {
                mySQLConnection.Close(connection);
            }
            return isUpdated;

        }

        public int SaveCompanyInfo(string CompanyName, string Description, string ContactPerson, string CellPhone, string WorkPhone, string LogoImage, string Theme, bool Status, string username, string password, string FName, string LName,
             string EmailTo, string EmailFrom, string NotificationEmailTo, int IsNacha, int IsEpx, string Addressline1, string AddressLine2, string zipcode, int StateID, int CityID)
        {
            int isUpdated = 0;
            SqlConnection connection = mySQLConnection.Open();
            try
            {
                 isUpdated = SqlHelper.ExecuteNonQuery(connection, "SaveCompanyInfo", CompanyName, Description,
                    ContactPerson, CellPhone, WorkPhone, LogoImage, Theme, Status, username, password, FName, LName,
                    EmailTo, EmailFrom, NotificationEmailTo, IsNacha, IsEpx, Addressline1, AddressLine2, zipcode,
                    StateID, CityID);
            }
            catch
            {
                mySQLConnection.Close(connection);
              //  return new Result("Error", "", ResultType.Failure);
            }
            finally
            {
                mySQLConnection.Close(connection);
            }
            return isUpdated;

        }


        //public Result GetProductsByTypeID(int ProductTypeID, long CompanyID = 0, int ShowDefaultProducts = 0, string SearchProductBy = "")
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = mySQLConnection.Open();
        //    try
        //    {
        //        using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "GetProductsByTypeID", ProductTypeID, CompanyID, ShowDefaultProducts, SearchProductBy))
        //        {
        //            DataTable dt = new DataTable("Products");
        //            ds.Tables.Add(dt);
        //            ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
        //        }
        //        mySQLConnection.Close(connection);
        //        return new Result("Success", "", ResultType.Success, ds.Tables[0]);
        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "GetProductsByTypeID", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }
        //}

        //public Result GetProductTypes()
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = mySQLConnection.Open();
        //    try
        //    {
        //        using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "GetProductTypes",UserInfo.CompanyID))
        //        {
        //            DataTable dt = new DataTable("ProductTypes");
        //            ds.Tables.Add(dt);
        //            ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
        //        }
        //        mySQLConnection.Close(connection);
        //        return new Result("Success", "", ResultType.Success, ds.Tables[0]);
        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "GetProductInfo", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }
        //}


        //public Result GetCompanyProductsInfo()
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = mySQLConnection.Open();
        //    try
        //    {
        //        using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, "GetCompanyProductsInfo"))
        //        {
        //            DataTable dt = new DataTable("GetCompanyProductsInfo");
        //            ds.Tables.Add(dt);
        //            ds.Load(dr, LoadOption.PreserveChanges, ds.Tables[0]);
        //        }
        //        mySQLConnection.Close(connection);
        //        return new Result("Success", "", ResultType.Success, ds.Tables[0]);
        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "GetWikiPayCountries", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }
        //}


        //public Result DeleteCompanyProducts(long CompanyID, long ProductTypeID, int ProductID)
        //{
        //    SqlConnection connection = mySQLConnection.Open();
        //    try
        //    {
        //        int a = (int)SqlHelper.ExecuteNonQuery(connection, "DeleteFromCompanyProducts", CompanyID, ProductTypeID, ProductID);
        //        if (a > 0)
        //        {
        //            return new Result("SaveCompanyProducts", "This Company product is deleted successfully", ResultType.Success);
        //        }
        //        else
        //        {
        //            return new Result("Failed", "", ResultType.Failure);
        //        }
        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "SaveCompanyProducts", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }

        //}


        //public Result SaveCompanyProducts(long CompanyID, long ProductID, string ProductTypeID)
        //{
        //    SqlConnection connection = mySQLConnection.Open();
        //    try
        //    {
        //        int a = (int)SqlHelper.ExecuteNonQuery(connection, "SaveCompanyProducts", CompanyID, ProductID, ProductTypeID);
        //        if (a > 0)
        //        {
        //            return new Result("SaveCompanyProducts", "This Company products is saved successfully", ResultType.Success);
        //        }
        //        else
        //        {
        //            return new Result("Failed", "", ResultType.Failure);
        //        }
        //    }
        //    catch
        //    {
        //        mySQLConnection.Close(connection);
        //        return new Result("Error", "SaveCompanyProducts", ResultType.Failure);
        //    }
        //    finally
        //    {
        //        mySQLConnection.Close(connection);
        //    }

        //}

    
    }
}
