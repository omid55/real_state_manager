using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace NeginProject
{
    class SearchSQL
    {
        private String[] str;
        private List<String> bitStrList;
        private String procName;
        private int numberOfMember;
        private List<int> fullIndex;

        public SearchSQL(String[] s,String procedureName)
        {
            bitStrList = new List<string>();
            fullIndex=new List<int>();
            procName = procedureName;
            str = s;
            String ss="";
            for (int i = 0; i < str.Length; i++)
                ss += '1';
            bitStrList.Add(ss);
            for (int i = 0; i < str.Length; i++)
            {
                String st=str[i].TrimEnd();
                st=st.TrimStart();
                st=st.ToUpper();
                if (st.Length != 0 && st != "" && st != "''" && st != "N''" && st != "N'\r\n'" && st!="FALSE")
                {
                    fullIndex.Add(i);
                }
            }
            numberOfMember = fullIndex.Count;
        }

        public DataTable getResult()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = DB.getConnectionString();
            con.Open();
            int size=0;
            DataTable dt=null;
            while (size == 0)
            {
                if (bitStrList.Count == 0)
                {
                    if(numberOfMember<=1)
                    {
                        return null;
                    }
                    generateNext();
                }
                while (bitStrList.Count != 0)
                {
                    String sql = getNextSQLCode();
                    if (bitStrList.Count == 0)  // the last one
                    {
                        sql = sql + ",0";
                    }
                    else
                    {
                        sql = sql + ",1";
                    }
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                size = dt.DefaultView.Count;
            }
            con.Close();
            return dt;
        }

        public String getNextSQLCode()
        {
            //if (bitStrList.Count == 0) generateNext();
            String bit=bitStrList.ElementAt(0);
            bitStrList.RemoveAt(0);
            String sql = "EXEC " + procName+" ";
            for (int i = 0; i < str.Length-1; i++)
            {
                if (bit[i] == '0')
                {
                    sql = sql + "'',";
                }
                else
                {
                    sql = sql + str[i] + ",";
                }
            }
            if (bit[str.Length - 1] == '0')    // because the last one doesn't need any ','
            {
                sql = sql + "''";
            }
            else
            {
                sql = sql + str[str.Length - 1];
            }
            return sql;
        }

        private bool next_comb(int[] comb, int k, int n)
        {
	        int i = k - 1;
	        ++comb[i];
	        while ((i > 0) && (comb[i] >= n - k + 1 + i))
	        {
		        --i;
		        ++comb[i];
	        }

	        if (comb[0] > n - k) 
		        return false;

	        for (i = i + 1; i < k; ++i)
		        comb[i] = comb[i - 1] + 1;

	        return true;
        }

        private void generateNext()
        {
            int n = fullIndex.Count;
            int k = --numberOfMember;
            int[] comb = new int[k];
            for (int i = 0; i < k; ++i)
                comb[i] = i;

            String sst = "";
            int ind = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (ind< comb.Length && fullIndex[comb[ind]] == i)
                {
                    ind++;
                    sst += '1';
                }
                else
                {
                    sst += '0';
                }
            }
            bitStrList.Add(sst);

            while (next_comb(comb, k, n))
            {
                String ss="";
                int index=0;
                for(int i=0;i<str.Length;i++)
                {
                    if (index<comb.Length && fullIndex[comb[index]] == i)
                    {
                        index++;
                        ss += '1';
                    }
                    else
                    {
                        ss += '0';
                    }
                }
                bitStrList.Add(ss);
            }
        }
    }
}
