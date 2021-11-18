using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ProjetoMercado.Model;
using ProjetoMercado.View;

namespace ProjetoMercado.Controller
{
    class ClienteController
    {
        /*A responsabilidade de um controlador é gerenciar e fazer a lógica do programa. Ele recebe as as requisições
         * do usuário e decide o que é pra fazer, como por exemplo mandar pro Model salvar com persistência.*/

        private static ViewClienteCadastro janelaCadastroCliente;

        //Cadastro
        public static void IniciarCadastro()
        {
            //Aqui vamos apresentar a janela de cadastro pro usuário
            janelaCadastroCliente = new ViewClienteCadastro();
            janelaCadastroCliente.ShowDialog();

        }

        public static void FecharCadastro()
        {
            //Vamos remover da apresentação a janela de cadastro
            janelaCadastroCliente.Close();
        }
        public static void Cadastrar(/* Recebo as informações da View*/
                                       string nome, string endereco, string bairro,
                                       string cidade, string estado, string cep, string telefone,
                                        string cpf, string rg)
        {
            /*Pega todas as informações da janela de cadastro e informa o Model que o usuário que salvar aquelas informações.*/

            // Estruturar as informações recebidas no formato Model
            ClienteModel novoCliente = new ClienteModel();
            novoCliente.Nome = nome;
            novoCliente.Endereco = endereco;
            novoCliente.Bairro = bairro;
            novoCliente.Cidade = cidade;
            novoCliente.Estado = estado;
            novoCliente.Cep = cep;
            novoCliente.Telefone = telefone;
            novoCliente.Cpf = cpf;
            novoCliente.Rg = rg;


            //Informar o Model que eu quero salvar
            bool sucesso = ClienteModel.Salvar(novoCliente);


            //Verificar a resposta do Model (se salvou ou não)
            if(sucesso)
            {
                // Indico ao usuário que o cadastro teve sucesso e fecho a janela de cadastro
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show
                    (
                        "Cliente cadastrado com sucesso!", //Mensagem
                        "Sucesso" //Titulo
                    );
            }
            else 
            {
                System.Windows.Forms.MessageBox.Show
                   (
                       "Erro ao cadastrar o cliente. Por favor tente novamente.", //Mensagem
                       "Erro" //Titulo
                   );
            }
        }
        //ATUALIZAÇÃO
        public static void IniciarAtualizacao() { }
        public static void FecharAtualizacao() { }
        public static void Atualizar() { }

        //REMOÇÃO
        public static void IniciarRemocao() { }
        public static void FecharRemocao() { }
        public static void Remover() { }

        //LISTAR

        public static void Listar(System.Windows.Forms.DataGridView elementoVisual)
        {
            /*Está primeiro buscando no Model as informações cadastradas no Banco de Dados e, após teruma resposta, 
             * coloca esta resposta no elemento visual passado pela View*/
            elementoVisual.DataSource = ClienteModel.Buscar();
        }
        
    }
}
