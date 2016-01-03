using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BackUpAndRestoreDb
{
    class DB
    {
        //public static String connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|Negindb.mdf\";Database=Negindb;Integrated Security=True;User Instance=True";
        public static String connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|Negindb.mdf\";Integrated Security=True;User Instance=True";
        public static String connectionStringArchive = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"|DataDirectory|Archivedb.mdf\";Integrated Security=True;Connect Timeout=30;User Instance=True";
        public static String connectionStringWithoutDb = "Data Source=.\\SQLEXPRESS;Integrated Security=True;User Instance=True";

        public DB()
        {
        }
        
        public static void execSql(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public static void execSqlWithoutDb(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionStringWithoutDb;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            cmd.Cancel();
            cmd.Dispose();
            con.Dispose();
            con.Close();
        }

        public static void execSqlInArchive(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionStringArchive;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            cmd.Cancel();
            cmd.Dispose();
            con.Dispose();
            con.Close();
        }

        public static Object execSqlReturnScalar(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            Object res = null;
            try
            {
                res=cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            cmd.Cancel();
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return res;
        }

        public static Object execSqlReturnScalarInArchive(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionStringArchive;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            Object res = null;
            try
            {
                res = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            cmd.Cancel();
            cmd.Dispose();
            con.Dispose();
            con.Close();
            return res;
        }

        public static DataTable execSqlReturnDataTable(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            con.Close();
            return dt;
        }

        public static DataSet execSqlReturnDataSet(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            da.Dispose();
            ds.Dispose();
            con.Close();
            con.Dispose();
            return ds;
        }

        public static DataTable execSqlReturnDataSetDT(String sql,string tblname)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, tblname);
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
            con.Close();
            return ds.Tables[tblname];
        }
    }
}
