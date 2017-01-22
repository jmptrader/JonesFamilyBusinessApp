using JonesFamilyBusinessApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace JonesFamilyBusinessApp.Persistence
{
    /// <summary>
    /// Manages all the database operations
    /// </summary>
    public class DBManager
    {

        // Path to MDF File. Must be set in Web.Config
        private string dbpath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("dbpath");
            }
        }

        #region Singleton
        private static DBManager _instance { get; set; }
        private DBManager() { }

        public static DBManager Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new DBManager();
                }
                return _instance;
            }
        }
        #endregion

        // Save object in mdf File
        public bool SaveObject(IModel model)
        {
            bool result = true;
            using (SqlConnection con = new SqlConnection())
            {
                try
                {
                    // get SQL Command from model
                    String sql = model.getInsertQuery();

                    //Set connection data
                    SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                    sqlcon.DataSource = @"(localdb)\MSSQLLocalDB";
                    sqlcon.AttachDBFilename = @dbpath;
                    sqlcon.InitialCatalog = "jonesdb";
                    sqlcon.IntegratedSecurity = true;
                    
                    con.ConnectionString = sqlcon.ToString();

                    // Open Connection
                    con.Open();

                    // Execute command
                    SqlCommand sqlInsert = new SqlCommand(sql, con);
                    sqlInsert.ExecuteNonQuery();
                }

                #region Exceptions
                catch (SqlException ex)
                {
                    result = false;
                    Logging.LogWriter.Instance.LogWrite(ex.Message);
                }
                catch (Exception ex)
                {
                    result = false;
                    Logging.LogWriter.Instance.LogWrite(ex.Message);
                }
                #endregion

                finally
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        // Get Objects from mdf file
        public DataTable getObjects(string type)
        {
            DataTable dt = null;
            using (SqlConnection con = new SqlConnection())
            {
                try
                {
                    // get SQL Command from model
                    String sql = createModel(type).getSelectQuery();

                    // Set Connection Data
                    SqlConnectionStringBuilder sqlcon = new SqlConnectionStringBuilder();
                    sqlcon.DataSource = @"(localdb)\MSSQLLocalDB";
                    sqlcon.AttachDBFilename = @dbpath;
                    sqlcon.InitialCatalog = "jonesdb";
                    sqlcon.IntegratedSecurity = true;
                    con.ConnectionString = sqlcon.ToString();

                    // Open Connection
                    con.Open();

                    // Execute command
                    SqlCommand cmd = new SqlCommand(sql, con);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                }

                #region Exceptions
                catch (SqlException ex)
                {
                    dt = null;
                    Logging.LogWriter.Instance.LogWrite(ex.Message);
                }
                catch (Exception ex)
                {
                    dt = null;
                    Logging.LogWriter.Instance.LogWrite(ex.Message);
                }
                #endregion
                finally
                {
                    if(con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
            return dt;
        }

        //It creates the model with type parameter
        //ToDo: implement FactoryPattern in another class 
        private IModel createModel(string type)
        {
            IModel model;
            switch (type)
            {
                case "Time":
                    model = new TimeModel();
                    break;
                default:
                    model = new TimeModel();
                    break;
            }
            return model;
        }
    }
}