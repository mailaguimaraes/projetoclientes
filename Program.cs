using System.Data.SqlClient;

namespace projetoclientes;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try{
                    //executar
                    SqlConnectionStringBuilder builder= new SqlConnectionStringBuilder(

                        
                        "Server=localhost,1433;"+
                        "User Id=sa;Password=MiPassw0rd!1521;"+
                        "Database=projetoclientes;"+
                        "Trusted_Connection=False;"
                    );

                    using(SqlConnection conexao = new SqlConnection (builder.ConnectionString)){

                        string sql = " Select * from clientes ";

                        using(SqlCommand comando= new SqlCommand (sql, conexao) ){

                            conexao.Open();

                            using( SqlDataReader leitor = comando.ExecuteReader() ){

                                while( leitor.Read()){

                                    //System.Console.WriteLine("id: {0}", leitor["id"]);
                                     //System.Console.WriteLine("id: {0}", leitor["nome"]);
                                      //System.Console.WriteLine("id: {0}", leitor["email"]);


                                     System.Console.WriteLine("id: {0}", leitor.GetSqlInt32(0));
                                     System.Console.WriteLine("nome: {0}", leitor.GetSqlString(1));
                                     System.Console.WriteLine("email: {0}", leitor.GetSqlString(2));
                                }
                            }
                        }

                    }

        }

        catch(Exception e)
        {
                    //exception
                    System.Console.WriteLine("Erro:"+ e.ToString());

        }
    }
}
