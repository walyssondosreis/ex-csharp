using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AULA_DB
{
    public partial class Form1 : Form
    {
        private clsAluno Aluno;
        public Form1()
        {
            InitializeComponent();
            Aluno = new clsAluno();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsAluno.CarregaGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            Aluno.Matricula = Convert.ToInt32(textBoxMatricula.Text);
            Aluno.Nome = textBoxNome.Text;
            Aluno.Telefone = textBoxTelefone.Text;
            Aluno.DataNasc = Convert.ToDateTime(textBoxDataNasc.Text);
            Aluno.Mensalidade = Convert.ToDouble(textBoxMensalidade.Text);
            if (Aluno.Salvar())
            {
                MessageBox.Show("Salvo com Sucesso!");
                clsAluno.CarregaGrid(dataGridView1);
                textBoxMatricula.Text = "" + Aluno.Matricula;
            }
            else
                MessageBox.Show("Erro ao Salvar!");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonNovo_Click(object sender, EventArgs e)
        {
            textBoxMatricula.Text = "0";
            textBoxNome.Text = "";
            textBoxTelefone.Text = "";
            textBoxDataNasc.Text = "";
            textBoxMensalidade.Text = "";
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            int Matricula;
            Matricula = Convert.ToInt32(textBoxPesquisar.Text);
            if(Aluno.Pesquisar(Matricula))
            {
                textBoxMatricula.Text = ""+Aluno.Matricula;
                textBoxNome.Text = Aluno.Nome;
                textBoxTelefone.Text = Aluno.Telefone;
                textBoxDataNasc.Text = Convert.ToString(Aluno.DataNasc);
                textBoxMensalidade.Text = ""+Aluno.Mensalidade;
            }
            else
            {
                MessageBox.Show("Aluno Não Encontrado");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int Matricula;
            Matricula = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);

            if (Aluno.Pesquisar(Matricula))
            {
                textBoxMatricula.Text = "" + Aluno.Matricula;
                textBoxNome.Text = Aluno.Nome;
                textBoxTelefone.Text = Aluno.Telefone;
                textBoxDataNasc.Text = Convert.ToString(Aluno.DataNasc);
                textBoxMensalidade.Text = "" + Aluno.Mensalidade;
            }
            else
            {
                MessageBox.Show("Aluno Não Encontrado");
            }

        }
    }
}
