using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxCodigo.Clear();
            textBoxNome.Clear();
            textBoxEndereco.Clear();
            textBoxCep.Clear();
            textBoxCidade.Clear();
            textBoxBairro.Clear();
            textBoxEmail.Clear();
            textBoxTelefone.Clear();
            textBoxEstado.Clear();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            String Texto = "";
            Texto += "Codigo: " + textBoxCodigo.Text + "\n";
            Texto += "Nome: " + textBoxNome.Text + "\n";
            Texto += "Endereço: " + textBoxEndereco.Text + "\n";
            Texto += "CEP: " + textBoxCep.Text + "\n";
            Texto += "Cidade: " + textBoxCidade.Text + "\n";
            Texto += "Bairro: " + textBoxBairro.Text + "\n";
            Texto += "Email: " + textBoxEmail.Text + "\n";
            Texto += "Telefone: " + textBoxTelefone.Text + "\n";
            Texto += "Estado: " + textBoxEstado.Text + "\n";
            MessageBox.Show(Texto);
        }
    }
}
