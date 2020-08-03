using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace Smart_FTY
{
    class Database
    {
        public String strError;
        private String strConnection, strConnectionSql;


         string strConnectionORA = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 211.54.128.21 "
                                 + ")(PORT = 1521 ))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = HUBICVJ "
                                 + ")));Password= hubicvj; User ID= hubicvj";
        public String settingDBORA()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlDBSQL;
            String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBORA.xml";
            try
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlDBSQL = xmldoc.GetElementsByTagName("DBORA");
                    String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
                    String USR = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
                    String PWD = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();

                    strConnection = "Provider=MSDAORA;Data Source=" + DATA_SOURCE + ";" +
                                    "Persist Security Info=True;" +
                                    "User ID=" + USR + ";" +
                                    "Password=" + PWD;
                    
                    return "";
                }
            }
            catch (Exception e)
            {
                return "Error : " + e.Message;
            }
        }



        public String settingORACLE()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlDBSQL;
            String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBORA.xml";
            try
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlDBSQL = xmldoc.GetElementsByTagName("DBORA");
                    String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
                    String USR = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
                    String PWD = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();

                    strConnectionORA = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 211.54.128.21 "
                                 + ")(PORT = 1521 ))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = HUBICVJ "
                                 + ")));Password=" + PWD + ";User ID=" + USR;
                    
                    return "";
                }

            }
            catch (Exception e)
            {
                return null;

            }
        }

        public  ArrayList getDataORA2(String str)
        {
            try
            {
                using (System.Data.OracleClient.OracleConnection con_ora = new System.Data.OracleClient.OracleConnection(strConnectionORA))
                {

                    con_ora.Open();
                    using (System.Data.OracleClient.OracleCommand command = new System.Data.OracleClient.OracleCommand(str, con_ora))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            ArrayList list = new ArrayList();
                            while (reader.Read())
                            {
                                object[] values = new object[reader.FieldCount];
                                reader.GetValues(values);
                                list.Add(values);

                            }
                            return list;
                        }
                    }
                }
            }
            catch (Exception e)
            {
               // strError = e.Message.ToString();
               // MessageBox.Show(strError);
                return null;

            }
        }

        public String settingDBSQL()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlDBSQL;
            String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBSQL.xml";
            try
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlDBSQL = xmldoc.GetElementsByTagName("DBSQL");
                    String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
                    String DB_NAME = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
                    String USR = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();
                    String PWD = xmlDBSQL[0].ChildNodes.Item(3).InnerText.Trim();
                    strConnectionSql = "Data Source=" + DATA_SOURCE + ";" +
                                  "Initial Catalog=" + DB_NAME + ";" +
                                  "Persist Security Info=True;" +
                                  "User ID=" + USR + ";" +
                                  "Password=" + PWD;

                    return "";
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public ArrayList getDataORA(String str)
        {
            try
            {
                using (OleDbConnection con_ora = new OleDbConnection(strConnection))
                {
                    con_ora.Open();
                    using (OleDbCommand command = new OleDbCommand(str, con_ora))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            ArrayList list = new ArrayList();
                            while (reader.Read())
                            {
                                object[] values = new object[reader.FieldCount];
                                reader.GetValues(values);
                                list.Add(values);

                            }
                            return list;
                        }
                    }
                }
            }
            catch (Exception e)
            {
               // strError = e.Message.ToString();
                return null;
            }
        }

        public DataTable getDataORASource(String str)
        {
            try
            {
                using (OleDbConnection con_ora = new OleDbConnection(strConnection))
                {
                    con_ora.Open();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(str, con_ora))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
              //  strError = e.Message.ToString();
                return null;
            }
        }

        public ArrayList getDataSQL(String str)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConnectionSql))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(str, con))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ArrayList list = new ArrayList();
                            while (reader.Read())
                            {
                                object[] values = new object[reader.FieldCount];
                                reader.GetValues(values);
                                list.Add(values);
                            }
                            return list;
                        }
                    }
                }
            }
            catch (Exception e)
            {
               // strError = e.Message.ToString();
                return null;
            }
        }

        public String saveDataORA(String str)
        {
            try
            {
                using (OleDbConnection con_ora = new OleDbConnection(strConnection))
                {
                    using (OleDbCommand command = new OleDbCommand(str, con_ora))
                    {
                        con_ora.Open();
                        command.ExecuteNonQuery();
                        return "";
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
