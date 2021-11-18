using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProjetoMercado.Controller;

namespace ProjetoMercado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dentro da View Principal, querem cadastrar um cliente
            ClienteController.IniciarCadastro();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteController.Listar(dataGridView1);
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FornecedorController.IniciarCadastro();
        }
    }
}
