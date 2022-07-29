using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AULA_DB
{
    class clsAluno
    {
        private int mMatricula;

        public int Matricula
        {
            get { return mMatricula; }
            set { mMatricula = value; }
        }
        private String mNome;

        public String Nome
        {
            get { return mNome; }
            set { mNome = value; }
        }
        private String mTelefone;

        public String Telefone
        {
            get { return mTelefone; }
            set { mTelefone = value; }
        }
        private DateTime mDataNasc;

        public DateTime DataNasc
        {
            get { return mDataNasc; }
            set { mDataNasc = value; }
        }
        private double mMensalidade;

        public double Mensalidade
        {
            get { return mMensalidade; }
            set { mMensalidade = value; }
        }
        public bool Salvar()
        {
            SqlConnection c;
            try
            {
                c = clsBancodeDados.getConexao();
                if (!(c.State == System.Data.ConnectionState.Open))
                {
                    MessageBox.Show("Erro de Conexão!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de Conexão!\n\n" + e.Message);
                return false;
            }

            SqlCommand com;
            com = c.CreateCommand();
            com.Transaction = clsBancodeDados.getTransaction();

            if (this.Matricula > 0)
                com.CommandText = "UPDATE Aluno SET nome = @Nome, telefone = @Telefone, " +
                    "mensalidade = @Mensalidade, datanasc=@DataNasc WHERE matricula = @Matricula;";
            else
                com.CommandText = "INSERT INTO Aluno (nome, telefone, mensalidade,datanasc) " +
                " VALUES (@Nome, @Telefone, @Mensalidade,@DataNasc);";

            com.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar));
            com.Parameters[0].Value = this.Nome;
            com.Parameters.Add(new SqlParameter("@Telefone", SqlDbType.VarChar));
            com.Parameters[1].Value = this.Telefone;
            com.Parameters.Add(new SqlParameter("@Mensalidade", SqlDbType.Decimal));
            com.Parameters[2].Value = this.Mensalidade;
            com.Parameters.Add(new SqlParameter("@DataNasc", SqlDbType.Date));
            com.Parameters[3].Value = this.DataNasc;

            if (this.Matricula > 0)
            {
                com.Parameters.Add(new SqlParameter("@Matricula", SqlDbType.Int));
                com.Parameters[4].Value = this.Matricula;
            }

            try
            {
                com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao Salvar!\n\n" + e.Message);
            }

            if (this.Matricula <= 0)
            {
                com = c.CreateCommand();
                com.Transaction = clsBancodeDados.getTransaction();
                try
                {
                    com.CommandText = "SELECT * FROM Aluno WHERE nome = @Nome ORDER BY matricula DESC;";
                    com.Parameters.Add(new SqlParameter("@Nome", SqlDbType.VarChar));
                    com.Parameters[0].Value = this.Nome;
                    System.Data.SqlClient.SqlDataReader dbr;// = new System.Data.SqlClient.SqlDataReader();
                    dbr = com.ExecuteReader();

                    if (!dbr.Read())
                        MessageBox.Show("Erro ao Recuperar ID do registro!");
                    this.Matricula = dbr.GetInt32(dbr.GetOrdinal("matricula"));
                    //this.Nome = dbr.GetString(dbr.GetOrdinal("bannome"));
                    dbr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Erro ao Salvar!\n\n" + e.Message);
                }
            }

            return true;
        }
        

        public bool Pesquisar(int Matricula)
        {
            SqlConnection c;
            try
            {
                c = clsBancodeDados.getConexao();
                if (!(c.State == System.Data.ConnectionState.Open))
                {
                    MessageBox.Show("Erro de Conexão!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de Conexão!\n\n" + e.Message);
                return false;
            }

            SqlCommand com;
            com = c.CreateCommand();
            com.Transaction = clsBancodeDados.getTransaction();

            if (Matricula <= 0) return false;
            com.CommandText = "SELECT * FROM Aluno WHERE matricula = @Matricula;";
            com.Parameters.Add(new SqlParameter("@Matricula", SqlDbType.Int));
            com.Parameters[0].Value = Matricula;
            System.Data.SqlClient.SqlDataReader dbr;// = new System.Data.SqlClient.SqlDataReader();
            dbr = com.ExecuteReader();

            if (!dbr.Read())
            {
                dbr.Close();
                return false;
            }
            this.Matricula = dbr.GetInt32(dbr.GetOrdinal("matricula"));
            this.Nome = dbr.GetString(dbr.GetOrdinal("nome"));
            this.Telefone = dbr.GetString(dbr.GetOrdinal("telefone"));
            this.DataNasc = dbr.GetDateTime(dbr.GetOrdinal("datanasc"));
            this.Mensalidade = Convert.ToDouble(dbr.GetDecimal(dbr.GetOrdinal("mensalidade")));
            dbr.Close();
            return true;
        }
        public static void CarregaGrid(System.Windows.Forms.DataGridView dataGridView1)
        {
            SqlConnection c;
            try
            {
                c = clsBancodeDados.getConexao();
                if (!(c.State == System.Data.ConnectionState.Open))
                {
                    MessageBox.Show("Erro de Conexão!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de Conexão!\n\n" + e.Message);
                return;
            }

            SqlCommand com = new SqlCommand();
            com = c.CreateCommand();
            com.Transaction = clsBancodeDados.getTransaction();

            com.CommandText = "SELECT * FROM Aluno ORDER BY nome;";
            System.Data.SqlClient.SqlDataReader dbr;// = new System.Data.SqlClient.SqlDataReader();
            dbr = com.ExecuteReader();

            dataGridView1.Rows.Clear();
            //dataGridView1.ClearSelection();
            //	clsBanco objBanco;
            while (dbr.Read())
            {
                //		objBanco = new clsBanco();
                //		objBanco.Existe(dbr.GetInt32(dbr.GetOrdinal("banid")));

                String[] MyArray = new String[2];
                MyArray[0] = "" + dbr.GetInt32(dbr.GetOrdinal("matricula"));
                MyArray[1] = dbr.GetString(dbr.GetOrdinal("nome"));

                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].SetValues(MyArray);
            }
            dbr.Close();
            return;
        }

    }
}
