// By Omid55

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows;

namespace NeginProject
{
    class DB
    {
        private static String dbConfigPath = Environment.CurrentDirectory + "\\dbconfig.conf";

        public DB()
        {
        }

        public static String getConnectionString()
        {
            String res = "";
            try
            {
                StreamReader sr = new StreamReader(dbConfigPath);
                res = sr.ReadLine();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("فایل اطلاعات پایگاه داده ها یافت نشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("فایل اطلاعات پایگاه داده ها صحیح نمی باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

        public static String getConnectionStringArchive()
        {
            String res = "";
            try
            {
                StreamReader sr = new StreamReader("dbconfig.conf");
                sr.ReadLine();
                res = sr.ReadLine();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("فایل اطلاعات پایگاه داده ها یافت نشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("فایل اطلاعات پایگاه داده ها صحیح نمی باشد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return res;
        }

        public static void execSql(String sql, int dbIndex)
        {
            SqlConnection con = new SqlConnection();
            if (dbIndex == 0)
            {
                con.ConnectionString = getConnectionString();
            }
            else
            {
                con.ConnectionString = getConnectionStringArchive();
            }
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

        /*public static void execSqlWithoutDb(String sql)
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
        }*/

        public static void execSqlInArchive(String sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = getConnectionStringArchive();
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
            con.ConnectionString = getConnectionString();
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
            con.ConnectionString = getConnectionStringArchive();
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

        public static DataTable execSqlReturnDataTable(String sql,int dbIndex)
        {
            SqlConnection con = new SqlConnection();
            if (dbIndex == 0)
            {
                con.ConnectionString = getConnectionString();
            }
            else
            {
                con.ConnectionString = getConnectionStringArchive();
            }
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

        //public static DataSet execSqlReturnDataSet(String sql)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = getConnectionString();
        //    //con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(sql, con);
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        da.Fill(ds);
        //    }
        //    catch (Exception e)
        //    {
        //        con.Close();
        //        throw e;
        //    }
        //    da.Dispose();
        //    ds.Dispose();
        //    con.Close();
        //    con.Dispose();
        //    return ds;
        //}

        public static DataTable execSqlReturnDataSetDT(String sql, string tblname)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = getConnectionString();
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
