using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace ProjetoMercado.Utius
{
    class DB
    {
        //Variáveis de conexão
        private string host = "localhost";
        private string username = "root";
        private string password = "";
        private string database = "fhomercado";
        private MySqlConnection conexao;

        //Construtor
        public DB()
        {
            string chamadaConexao = "SERVER=" + host + ";" +
                                    "DATABASE=" + database + ";" +
                                    "UID=" + username + ";" +
                                    "PASSWORD=" + password + ";";

            conexao = new MySqlConnection(chamadaConexao);


        }

        //Métodos de Abrir e Fechar Conexão
        private bool AbrirConexao()
        {
            /*O bloco Try and Catch "TENTA" executar o código dentro do Try e, CASO OCORRA ERRO, ele executa o 
             * código*/
            try
            {
                //É neste momento que os dados de acesso são enviados ao SGBD (seja local ou remoto)
                conexao.Open();
                return true;
            }
            catch(Exception ex)
            {
                //Erro encontrado
                System.Windows.Forms.MessageBox.Show
                    (
                        "Erro ao abrir conexão: " + ex.Message, "Erro"
                    );
                return false;
            }
            
        }
        private bool FecharConexao()
        {
            try
            {
                conexao.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show
                    (
                        "Erro ao abrir conexão: " + ex.Message, "Erro"
                    );
                return false;  
            }
        }
        
        //Métodos de Manipulção do Banco de Dados
        public bool Inserir(string query, List<MySqlParameter > parametros)
        {
            //INSERT INTO cliente (codigo, nome) VALUES (______, ________)
            try
            {
                if (AbrirConexao()) //Só entra se conseguir conectar ao banco
                {
                    // Comando combinando a instrução (query) com o acesso ao banco (conexao)
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    // Combinar os parãmetros passados com a query
                    if (parametros != null)
                        for (int i = 0; i < parametros.Count; i++)
                            cmd.Parameters.Add(parametros[i]);

                    //Mandando o comando pro banco de dados
                    int resposta = cmd.ExecuteNonQuery();
                    Console.WriteLine("Resposta insert: " + resposta);

                    FecharConexao();

                    if (resposta != 0)
                        return true;
                    return false;
                }
                return false;
            }
            catch(Exception ex)
            {
                System.Windows .Forms.MessageBox.Show("Erro MySQL: " + ex.Message, "Erro");
                return false;
            }
           
        }
        public bool Atualizar(string query, List<MySqlParameter>parametros)
        {
            return Inserir(query, parametros);
        }
        public bool Remover(string query, List<MySqlParameter> parametros)
        {
            return Inserir(query, parametros);
        }
        public  DataTable Buscar(string query, List<MySqlParameter> parametros)
        {
            try
            {
                if (AbrirConexao())
                {
                    DataTable tabelaResposta = null;

                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    if (parametros != null)
                        for (int i = 0; i < parametros.Count; i++)
                            cmd.Parameters.Add(parametros[i]);

                    //Preparando para execução de uma query do select
                    MySqlDataReader data = cmd.ExecuteReader();
                    List<string> registros = new List<string>();

                    //Convertendo um DataReader (SQL) para um DataTable (C#)
                    DataTable esquemaBanco = data.GetSchemaTable();
                    tabelaResposta = new DataTable();

                    if(data != null && esquemaBanco != null)// Tem informações para serem apresentadas
                    {
                        //Convertendo e criando as colunas (SQL -> C#)
                        foreach (DataRow linha in esquemaBanco.Rows)
                        {
                            if (!tabelaResposta.Columns.Contains(linha["ColumnName"].ToString()))
                            {
                                DataColumn col = new DataColumn()
                                {
                                    ColumnName = linha["ColumnName"].ToString(),
                                    Unique = Convert.ToBoolean(linha["IsUnique"]),
                                    AllowDBNull = Convert.ToBoolean(linha["AllowDBNull"]),
                                    ReadOnly = Convert.ToBoolean(linha["IsReadOnly"])

                                };
                                tabelaResposta.Columns.Add(col);
                            }
                        }
                    }

                    // Preenchendo a tabela com os registro com os registro encontrados no banco de dados
                    while(data.Read())
                    {
                        DataRow novoRegistro = tabelaResposta.NewRow();
                        for (int i = 0; i < tabelaResposta.Columns.Count; i++)
                            novoRegistro[i] = data.GetValue(i);
                        tabelaResposta.Rows.Add(novoRegistro);

                    }

                    data.Close();

                    FecharConexao();
                    
                    return tabelaResposta;
                }
                else
                    return null;

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro MySQL: " + ex.Message, "Erro");
                return null;
            }
        }
    }
}
