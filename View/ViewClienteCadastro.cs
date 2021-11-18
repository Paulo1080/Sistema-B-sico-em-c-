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
    public partial class ViewClienteCadastro : Form
    {
        public ViewClienteCadastro()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            //Código executado quando alguèm clicar no botão Cadastrar
            /*Neste momento, estamos na View (Janela), a responsabilidade dela é apenas capturar as interações
             * e informar o CONTROLADOR que o usuário deseja realizar o cadastro. */

            ClienteController.Cadastrar
                (
                    textBoxNome.Text,
                    textBoxEndereco.Text,
                    textBoxBairro.Text,
                    textBoxCidade.Text,
                    textBoxEstado.Text,
                    maskedTextBoxCep.Text,
                    maskedTextBoxTelefone.Text,
                    maskedTextBoxCPF.Text,
                    textBoxRG.Text
                );
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            //Código executado quando alguèm clicar no botão de Cancelar o Cadastrar

            //Informar o controlador que o usuário cancelou o desejo de cadastro.
            ClienteController.FecharCadastro();

        }
    }
}
