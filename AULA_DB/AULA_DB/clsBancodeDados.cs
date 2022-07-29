using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AULA_DB
{
    class clsBancodeDados
    {
        private static SqlConnection c;
        private static SqlTransaction Transaction;
        private static String Caminho;

        private clsBancodeDados() { }

        public static SqlConnection getConexao()
        {
            Caminho = "C:\\USERS\\ADMINISTRADOR\\DOCUMENTS\\AULA.MDF";
            if (String.IsNullOrEmpty(Caminho)) return c;
            if (c == null || c.State == System.Data.ConnectionState.Closed)
            {
                c = new SqlConnection();
                c.ConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=" + Caminho + ";Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True";
                //                c.ConnectionString = "Data Source=" + Caminho;
                c.Open();
            }
            return c;
        }
        public static SqlTransaction getTransaction()
        {
            if (c != null || c.State == System.Data.ConnectionState.Closed) getConexao();
            return Transaction;
        }
        public static void beginTransaction()
        {
            if (c != null || c.State == System.Data.ConnectionState.Closed) getConexao();
            Transaction = c.BeginTransaction();
        }
        public static void commitTransaction()
        {
            Transaction.Commit();
        }
        public static void rollbackTransaction()
        {
            Transaction.Rollback();
        }
        public static void SetCaminho(String mCaminho)
        {
            Caminho = mCaminho;
        }
    }
}