using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoMercado.Model;
using ProjetoMercado.View;

namespace ProjetoMercado.Controller
{
    class FornecedorController
    {
        private static ViewFornecedorCadastro janelaCadastroFornecedor;

        public static void IniciarCadastro()
        {
            janelaCadastroFornecedor = new ViewFornecedorCadastro();
            janelaCadastroFornecedor.ShowDialog();
        }
        public static void FecharCadastro()
        {
            janelaCadastroFornecedor.Close();
        }
        public static void Cadastrar(string nome,string endereco,string bairro, string cidade, string uf, string cep, string telefone)
        {
            FornecedorModel novoFornecedor = new FornecedorModel();
            novoFornecedor.Nome = nome;
            novoFornecedor.Endereco = endereco;
            novoFornecedor.Bairro = bairro;
            novoFornecedor.Cidade = cidade;
            novoFornecedor.Uf = uf;
            novoFornecedor.Cep = cep;
            novoFornecedor.Telefone = telefone;

            bool sucesso = FornecedorModel.Salvar(novoFornecedor);

            if(sucesso)
            {
                FecharCadastro();
                System.Windows.Forms.MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Erro ao cadastrar o Fornecedor.Por favor tente novamente.", "Erro");
            }
        }

        public static void IniciarAtualizacao() { }
        public static void FecharAtualizacao() { }
        public static void Atualizar() { }


        public static void IniciarRemocao() { }
        public static void FecharRemocao() { }
        public static void Remover() { }


        public static void Listar() { }
    }
}
