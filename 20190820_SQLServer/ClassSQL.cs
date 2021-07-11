using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20190820_SQLServer
{
    class ClassSQL
    {

        //Webconfig string
        //public static string sConnection = System.Configuration.ConfigurationManager.ConnectionStrings["PerfectCue"].ConnectionString;
        //Init connection string every time when connect to database to avoid multiple threading problem
        private static string GetConnectionString()
        {
            //Init string
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
            //Use longer string to make deciper harder when exe been de-compiled to protect database.
            stringBuilder.ConnectionString = GetStringIntegrated("127.0.0.1","LUCC");
            //stringBuilder.DataSource=
            //stringBuilder.InitialCatalog
            //stringBuilder.UserID
            //stringBuilder.Password

            //Set connection parameters
            stringBuilder.Pooling = true;//Open Pool
            stringBuilder.MinPoolSize = 5; //At least one, maintain connection, minimize response time
            stringBuilder.MaxPoolSize = 200;//Default 100
            stringBuilder.ConnectTimeout = 3; //Default 15

            return stringBuilder.ConnectionString;
        }

        //Init database connction string with integrated
        public static string GetStringIntegrated(string Source, string DBName)
        {
            //Init database connction string
            return @"Data Source =" + Source + "; " +
                "Initial Catalog=" + DBName + ";" + "Integrated Security=SSPI;";
        }

        //Init database connction string with user/pass
        public static string GetStringUserPass(string sServer, string sDBName, string sUsername, string sPassword)
        {
            //Init connection
            return "Data Source=" + sServer + ";" + "Initial Catalog=" + sDBName + ";" +
                                        "User id=" + sUsername + ";" + "Password=" + sPassword + ";";
        }


        //Note: the Connect Timeout=2 is only SQL level, won't work if there is no connection
        //To fix this, use CheckDBConnection2 instead
        public static bool CheckDBConnection(out string errMSG)
        {
            //variables
            errMSG = "";

            using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
            {
                //record time---debug info
                Stopwatch s1 = new Stopwatch();
                s1.Start();

                try
                {
                    sqlCon.Open();
                    sqlCon.Close();
                    s1.Stop(); //Stop
                    return true;
                }
                catch (Exception e)
                {
                    errMSG = "Database connection open error!";
                    Debug.WriteLine("Database Timeout:" + sqlCon.ConnectionTimeout + "\r\n" + e.Message);
                    Debug.WriteLine("Actual time:" + s1.ElapsedMilliseconds.ToString());
                    s1.Stop(); //Timer stop
                    return false;
                }
            }
        }

        //Fixed time-out issue
        public static bool CheckDBConnectionTimeout(out string errMSG, int TimeoutInMilliseconds = 3000)
        {
            //variables
            errMSG = "";
            string errTemp = "";
            bool ConnectionFlag = false; //connection flag

            //record time---debug info
            Stopwatch s1 = new Stopwatch();

            //Thread to try to connect
            Thread t1 = new Thread(() =>
            {
                using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        s1.Start(); //Start to count
                        sqlCon.Open();
                        sqlCon.Close();
                        ConnectionFlag = true; //Pass connection
                    }
                    catch (Exception e)
                    {
                        errTemp = e.Message;
                        s1.Stop();
                        ConnectionFlag = false;
                    }
                }
            });
            t1.IsBackground = true;
            t1.Start();


            //Loop check connection thread
            while (TimeoutInMilliseconds > s1.ElapsedMilliseconds)
            {
                //If thread finished stop, jump out the loop
                //else keep waiting until timeout pass setted time.
                if (t1.Join(1))
                {
                    break;
                }
            }

            //return connection status
            errMSG = errTemp;
            return ConnectionFlag;
        }



        public static bool SQLDataAdapter(string sSQL, out DataTable dtdata, out string errMSG)
        {
            //variables
            errMSG = "";
            dtdata = new DataTable();

            //Connection
            using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlCon.Open();
                    //get data
                    SqlCommand cmd = new SqlCommand(sSQL, sqlCon);
                    SqlDataAdapter theAdapter = new SqlDataAdapter(cmd);
                    theAdapter.Fill(dtdata);
                    sqlCon.Close();
                    return true;
                }
                catch (Exception e)
                {
                    errMSG = e.Message;
                    Debug.WriteLine(errMSG);
                    return false;
                }
            }
        }


        //Fix time out not working problem
        public static bool SQLDataAdapterTimeOut(string sSQL, out DataTable dtdata, out string errMSG, int TimeoutInMilliseconds = 3000)
        {
            //variables
            string tempMSG = "";
            DataTable dtTemp = new DataTable();
            bool ConnectionFlag = false; //connection flag

            //record time---debug info
            Stopwatch s1 = new Stopwatch();

            //Thread to try to connect
            Thread t1 = new Thread(() =>
            { //Setup Connection
                using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        s1.Start(); //Start to count
                        sqlCon.Open();
                        //get data
                        SqlCommand cmd = new SqlCommand(sSQL, sqlCon);
                        SqlDataAdapter theAdapter = new SqlDataAdapter(cmd);
                        theAdapter.Fill(dtTemp);
                        sqlCon.Close();
                        ConnectionFlag = true; //Pass connection
                    }
                    catch (Exception e)
                    {
                        tempMSG = e.Message;
                        Console.WriteLine(tempMSG);
                        s1.Stop();
                        ConnectionFlag = false;
                    }
                }
            });
            t1.IsBackground = true;
            t1.Start();

            //Loop check connection thread
            while (TimeoutInMilliseconds > s1.ElapsedMilliseconds)
            {
                //If thread finished stop, jump out the loop         
                if (t1.Join(1))//else keep waiting thread to finish until timeout pass setted time.
                {
                    break;
                }
            }


            //Get output values, out/ref can't be used in thread, so temp variables used.
            errMSG = tempMSG;
            dtdata = dtTemp;

            return ConnectionFlag;
        }


        public static bool SQLNoneQuery(string sSQL, out string errMSG)
        {
            //variables
            errMSG = "";

            //Setup Connection
            using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlCon.Open();
                    //cmd
                    SqlCommand cmd = new SqlCommand(sSQL, sqlCon);
                    int count = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    return true;
                }
                catch (Exception e)
                {
                    errMSG = e.Message;
                    Console.WriteLine("Database Timeout:" + sqlCon.ConnectionTimeout + "\r\n" + e.Message);
                    return false;
                }
            }
        }


        //Fix time out not working problem
        public static bool SQLNoneQueryTimeout(string sSQL, out string errMSG, int TimeoutInMilliseconds = 3000)
        {
            //variables
            string tempMSG = "";
            bool ConnectionFlag = false; //connection flag


            //record time---debug info
            Stopwatch s1 = new Stopwatch();

            //Thread to try to connect
            Thread t1 = new Thread(() =>
            {
                //Connection
                //Setup Connection
                using (SqlConnection sqlCon = new SqlConnection(GetConnectionString()))
                {
                    try
                    {
                        s1.Start(); //Start to count
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand(sSQL, sqlCon);   //cmd
                        int count = cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        ConnectionFlag = true; //Pass connection
                    }
                    catch (Exception e)
                    {
                        tempMSG = e.Message;
                        Debug.WriteLine(tempMSG);
                        s1.Stop();
                        ConnectionFlag = false;
                    }
                }
            });
            t1.IsBackground = true;
            t1.Start();

            //Loop check connection thread
            while (TimeoutInMilliseconds > s1.ElapsedMilliseconds)
            {
                //If thread finished stop, jump out the loop         
                if (t1.Join(1))//else keep waiting thread to finish until timeout pass setted time.
                {
                    break;
                }

            }

            //Get output values, out/ref can't be used in thread, so temp variables used.
            errMSG = tempMSG;
            return ConnectionFlag;
        }
    }
}