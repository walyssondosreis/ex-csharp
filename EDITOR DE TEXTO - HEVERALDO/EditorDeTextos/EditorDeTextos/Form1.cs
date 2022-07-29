using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorDeTextos
{
    public partial class Form1 : Form
    {
        private String NomeDoArquivo = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                NomeDoArquivo = saveFileDialog1.FileName;
                richTextBox1.SaveFile(NomeDoArquivo);
                toolStripStatusLabel1.Text = NomeDoArquivo;
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                NomeDoArquivo = openFileDialog1.FileName;
                richTextBox1.LoadFile(NomeDoArquivo);
                toolStripStatusLabel1.Text = NomeDoArquivo;
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(NomeDoArquivo.Equals(""))
            {
                salvarComoToolStripMenuItem_Click(sender, e);
                toolStripStatusLabel1.Text = NomeDoArquivo;
            }
            else
            {
                richTextBox1.SaveFile(NomeDoArquivo);
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripStatusLabel1.Text = "Novo Arquivo";
            NomeDoArquivo = "";
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 About = new AboutBox1();
            About.ShowDialog();
        }
    }
}
