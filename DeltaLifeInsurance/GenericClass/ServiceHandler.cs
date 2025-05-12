

using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace DeltaLifeInsurance.GenericClass
{
    public class ServiceHandler
    {
        private readonly string _SQLString= "Server=.; DataBase=DeltaDB; Trusted_Connection=True; TrustServerCertificate=True;";
       

            public string ReturnString(string strSql)
            {
            SqlConnection con = new SqlConnection(_SQLString);
            string strReturn = "";
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strSql, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            strReturn = dr[0].ToString();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    strReturn = ex.Message.ToString();
                }
                finally
                {
                    con.Close();
                }
                return strReturn;
            }

            public DataSet ExecuteQuery(string strSQL)
            {
            SqlConnection con = new SqlConnection(_SQLString);
            con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlDataAdapter oda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds, "Table1");
                    return ds;

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            public string ExecuteQueryString(string strSQL)
            {
            SqlConnection con = new SqlConnection(_SQLString);
            con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlDataAdapter oda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    oda.Fill(ds, "Table1");
                    return "Success";

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }




        }
    
}