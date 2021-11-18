using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ProjetoMercado.Model
{
    class FornecedorModel
    {
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string endereco;
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private string bairro;
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private string cidade;
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        private string uf;
        public string Uf
        {
            get { return uf; }
            set { uf = value; }
        }
        private string cep;
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }

        public static bool Salvar(FornecedorModel novoFornecedor)
        {
            Utius.DB banco = new Utius.DB();

            string query = "INSERT INTO fornecedor(nome, endereco, bairro, cidade, uf, cep," +
                            "telefone) VALUES (@nome, @endereco, @bairro, @cidade ," +
                            "@uf, @cep, @telefone);";

            
            List<MySqlParameter> conteudo = new List<MySqlParameter>();
            conteudo.Add(new MySqlParameter("@nome", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@endereco", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@bairro", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cidade", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@uf", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cep", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@telefone", MySqlDbType.String));
            

            conteudo[0].Value = novoFornecedor.nome;
            conteudo[1].Value = novoFornecedor.endereco;
            conteudo[2].Value = novoFornecedor.bairro;
            conteudo[3].Value = novoFornecedor.cidade;
            conteudo[4].Value = novoFornecedor.uf;
            conteudo[5].Value = novoFornecedor.cep;
            conteudo[6].Value = novoFornecedor.telefone;
            

            return banco.Inserir(query, conteudo);
        }
        public static bool Editar(FornecedorModel qualFornecedor)
        {
            return false;
        }
        public static bool Remover(FornecedorModel qualFornecedor)
        {
            return false;
        }
        public static System.Data.DataTable Buscar()
        {
            Utius.DB banco = new Utius.DB();
            string query = "SELECT + FORM fornecedor;";
            return banco.Buscar(query, null);
        }
    }
}
