using System;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _211069
{
    public class Banco
    {
        // Criando as váriaveis publicas para conexão e consulta serão usadas em todo o projeto
        // Connection reponsável pela conexão com  o MySQL
        public static MySqlConnection Conexao;

        // Command reponsável pelas instruções SQL a serem executadas
        public static MySqlCommand Comando;

        // Adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;

        // DataTable responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;


        public static void AbrirConexao()
        {
            try
            {
                // Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                // Abre a conexao com o banco de dados
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            {
                // Fecha a conexão com o banco de dados
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                // Chama a função para abertura de conexão com o banco
                AbrirConexao();

                // Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);
                
                // Executa a Query no MySQL (Raio do Workbench)
                Comando.ExecuteNonQuery();

                // Criando tabela Cidades
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                            "(id integer auto_increment primary key, " +
                                            "nome char(40), " +
                                            "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela Marcas
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Marcas " +
                                            "(id integer auto_increment primary key, " +
                                            "marca char(20))", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela Categorias
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Categorias " +
                            "(id integer auto_increment primary key, " +
                            "categoria char(20))", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela clientes
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes " +
                               "(id integer auto_increment primary key, " +
                               "nome char(40), " +
                               "idCidade integer," +
                               "dataNasc date," +
                               "renda decimal(10,2), " +
                               "cpf char(14), " +
                               "foto varchar(100), " +
                               "venda boolean)", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela Produtos
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Produtos " +
                                "(Id integer auto_increment primary key, " +
                                "descricao char(40), " +
                                "idCategoria integer," +
                                "idMarca integer," +
                                "estoque decimal(10,3), " +
                                "valorVenda decimal(10,2), " +
                                "foto varchar(100))", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela Vendas
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaCab " +
                                            "(Id integer auto_increment primary key, " +
                                            "idCliente int, " +
                                            "date date," +
                                            "total decimal(10,2))", Conexao);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS VendaDet " +
                                            "(Id integer auto_increment primary key, " +
                                            "idVendaCab int, " +
                                            "idProduto int, " +
                                            "qtde decimal(10,3)," +
                                            "valorUnitario decimal(10,2))", Conexao);
                Comando.ExecuteNonQuery();

                // Criando tabela Caixa
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Caixa " +
                                        "(Id integer auto_increment primary key, " +
                                        "idVendaCab int, " +
                                        "dinheiro decimal(10,2), " +
                                        "pix decimal(10,2), " +
                                        "cartao decimal(10,2), " +
                                        "cheque decimal(10,2), " +
                                        "boleto decimal(10,2))", Conexao);
                Comando.ExecuteNonQuery();


                // Chama a função para fechar a conexão com o banco
                FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }



}
