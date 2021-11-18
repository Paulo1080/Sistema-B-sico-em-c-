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

namespace ProjetoMercado.View
{
    public partial class ViewFornecedorCadastro : Form
    {
        public ViewFornecedorCadastro()
        {
            InitializeComponent();
        }

        

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            FornecedorController.Cadastrar(textBoxNome.Text, textBoxEndereco.Text, textBoxBairro.Text, textBoxCidade.Text,
                                       maskedTextBoxUf.Text, maskedTextBoxCep.Text, maskedTextBoxTelefone.Text);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            ClienteController.FecharCadastro();
        }
    }
}
