using AplicacaoFeira.Repository.Contract;
using AplicacaoFeira.Models;
using MySql.Data.MySqlClient;
namespace AplicacaoFeira.Repository
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly string _conexaoMySQL;
        IConfiguration _config;
        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
            _config = conf;
        }

        public Cliente Login(string Email, string Senha)
        {
            using(var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbCliente where Email = @Email and Senha = @Senha ", conexao);

                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = Senha;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    cliente.Nome = Convert.ToString(dr["Nome"]);
                    cliente.Email = Convert.ToString(dr["Email"]);
                    cliente.Senha = Convert.ToString(dr["Senha"]);
                }
                return cliente;
            }
        }

        public void Cadastro(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("insert into tbCliente(Nome, Email, Senha, ConfirmacaoSenha) values (@Nome, @Email, @Senha, @ConfirmacaoSenha);", conexao);
                cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                cmd.Parameters.Add("@ConfirmacaoSenha", MySqlDbType.VarChar).Value = cliente.ConfirmacaoSenha;
                cmd.ExecuteNonQuery();
                conexao.Close();
               
            }
        }
    }
}
