using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;


namespace ProjetoMercado.Model
{
    class ClienteModel
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
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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
        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        private string rg;
        public string Rg
        {
            get { return rg; }
            set { rg = value; }
        }

        /* A palavra chave "static" permite o acesso ao atributo ou método sem precisar de um OBJETO, e sim apenas
         * o nome da CLASSE*/
        public static bool Salvar(ClienteModel novoCliente)
        {
            /*Neste ponto é responsabilidade do MODEL armazenar com persistência os dados do cliente.
             * Seja em arquivos locais ou em um SGBD*/

            Utius.DB banco = new Utius.DB();

            string query = "INSERT INTO cliente(nome, endereco, bairro, cidade, uf, cep," +
                            "telefone, cpf, rg) VALUES (@nome, @endereco, @bairro, @cidade ," +
                            "@uf, @cep, @telefone, @cpf, @rg);";

            // Montando a query previnindo contra SQL Injection
            List<MySqlParameter > conteudo = new List<MySqlParameter>();
            conteudo.Add(new MySqlParameter("@nome", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@endereco", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@bairro", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cidade", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@uf", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cep", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@telefone", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@cpf", MySqlDbType.String));
            conteudo.Add(new MySqlParameter("@rg", MySqlDbType.String));

            conteudo[0].Value = novoCliente.nome;
            conteudo[1].Value = novoCliente.endereco;
            conteudo[2].Value = novoCliente.bairro;
            conteudo[3].Value = novoCliente.cidade;
            conteudo[4].Value = novoCliente.estado;
            conteudo[5].Value = novoCliente.cep;
            conteudo[6].Value = novoCliente.telefone;
            conteudo[7].Value = novoCliente.cpf;
            conteudo[8].Value = novoCliente.rg;

            /*O retorno em BOOL destes métodos, é para informar o CONTROLADOR (que fez a requisição) se o "Salvar"
             * deu certo ou não*/
            return banco.Inserir(query, conteudo);
    
        }
        public static bool Editar(ClienteModel qualCliente)
        {
            return false;
        }
        public static bool Remover(ClienteModel qualCliente)
        {
            return false;
        }

        public static System.Data.DataTable Buscar()
        {
            Utius.DB banco = new Utius.DB();
            string query = "SELECT + FORM cliente;";
            return banco.Buscar(query, null);
        }
    }
}
