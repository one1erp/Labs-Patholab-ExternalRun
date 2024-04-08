
using ADODB;
using ExternalRun;
using FAXCOMLib;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Oracle.ManagedDataAccess.Client;
using Patholab_Common;
using Patholab_DAL_V1;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using VB6Bridge;
using Exception = System.Exception;
//using Application = Microsoft.Office.Interop.Word.Application;
using oApplication = Microsoft.Office.Interop.Outlook.Application;

//for Console.WriteLineging

namespace ExternalRun
{
    class Program
    {

        private static OracleConnection _connection;


        private static DataLayer dal;

        private static OracleCommand _cmd;


        static bool debug;


        static bool netOrgan = false;
        [STAThread]

        static void Main(string[] args)
        {
            try
            {

                if (netOrgan)
                {
                    LoadNetOrgan();
                    return;
                }
                var Con = new Connection();


                Con.ConnectionString = "Provider=OraOLEDB.Oracle;Data Source=NAUTprd;User ID=lims_sys;Password=lims_sys";
                Con.Open();

                Form1 a = new Form1(Con);
                a.ShowDialog();
                return;

            }
            catch (Exception exx)
            {


            }
            if (debug)
            { Console.WriteLine("In debug mode"); }

            dal = new DataLayer();
            string connectionStrings = ConfigurationManager.ConnectionStrings["connectionStringef"].ConnectionString;





            //  var connectionStrings = "Data Source=PATHOLAB;User ID=lims_sys;Password=lims_sys";
            // this patrt works from app.config
            Console.WriteLine("Connecting to DB");
            dal.MockConnect(connectionStrings);
            Console.WriteLine("Connected to DB DAL");

            try
            {
                var connectionStringOracle = ConfigurationManager.ConnectionStrings["connectionStringOracle"].ConnectionString;


                _connection = new OracleConnection(connectionStringOracle);
       
                _connection.Open();
            }
            catch (Exception  pp)
            {
                Console.WriteLine("!!!! CRITICAL ERROR !!!! Can't connect to DB with oracle. Exiting program!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Connected to DB Oracle");

            LoadRequestRemark();
            //   LoadOrgan();



            //Console.ReadKey();
        }

        private static void LoadNetOrgan()
        {
            try
            {

          
            var connectionStringOracle = ConfigurationManager.ConnectionStrings["connectionStringOracle"].ConnectionString;


            _connection = new OracleConnection(connectionStringOracle);

            _connection.Open();


            Form2 f = new Form2();
            f.InitializeCon(_connection);
            f.ShowDialog();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        private static void LoadOrgan()
        {
            try
            {
                var connectionStringADODB = ConfigurationManager.ConnectionStrings["connectionStringADODB"].ConnectionString;
                object ret;

                const int i = 1;
                //Open connection for request remaraks(vb6)
                var adodbCon = new Connection();
                Console.WriteLine(connectionStringADODB);
                adodbCon.ConnectionString = connectionStringADODB;

                adodbCon.Open();



                Form1 a = new Form1(adodbCon);
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);

                // MessageBox.Show("Error  on load  RequestRemarks");
            }
        }
        private static void LoadRequestRemark()
        {
            try
            {
                object ret;

                const int i = 1;
                //Open connection for request remaraks(vb6)
                var Con = new Connection();

                var connectionStringADODB = ConfigurationManager.ConnectionStrings["connectionStringADODB"].ConnectionString;

                Con.ConnectionString = connectionStringADODB;// "Provider=MSDAORA;Data Source=naut;User ID=lims_sys;Password=lims_sys";
                Con.Open();

                var
                          requestRemarkBridge = new RequestRemarksBridge();
                requestRemarkBridge.InitilaizeCtrl(Con, "1");

                Form1 a = new Form1(Con);
                a.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);

                // MessageBox.Show("Error  on load  RequestRemarks");
            }
        }
        private static string ExecuteOrGetString(string queryOrString, SDG sdg, string sdgStatus)
        {
            string result;
            result = "";

            if (queryOrString == null)
            {
                //default to don`t send/ 1 copy
                result = "";
            }
            //if ther is no select, return the string
            string query = Regex.Replace(queryOrString ?? "", "#SDG_ID#", sdg.SDG_ID.ToString(), RegexOptions.IgnoreCase);
            query = Regex.Replace(query, "#SDG_STATUS#", "'" + sdgStatus.ToUpper() + "'", RegexOptions.IgnoreCase);



            if (query.IndexOf("select", StringComparison.OrdinalIgnoreCase) < 0)
            {
                result = query;
            }
            else
            {

                OracleDataReader reader = RunQuery(query);
                // Run query in queryString, 
                if (reader == null || !reader.HasRows)
                {
                    //if no resulst
                    //return;
                    result = "";
                }
                else
                {
                    result = reader.GetValue(0).ToString();

                }
                if (reader != null) reader.Dispose();
            }

            return result;
        }

        private static OracleDataReader RunQuery(string queryString)
        {
            _cmd = new OracleCommand(queryString, _connection);
            OracleDataReader reader;
            try
            {
                reader = _cmd.ExecuteReader();
                reader.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("reader is null " + queryString);
                reader = null;
                //continue loop 
            }

            return reader;
        }


    }
}
