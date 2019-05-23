using System;
using System.Data.SqlClient;
//using CategoriaModelo = Modelo.Categoria;//renomeamos a classe somente para o uso, pois nesse caso vamos usar a Classe categira de modelo e nao da persistencia

//devido a conflitos e erro a linha acima foi refeita
using Modelo;


namespace Persistencia
{
    public class CategoriaDAL
    {
        //chamando a conexao
        private SqlConnection conn;
        //criando um construtor, passando como parametro nossa conexao
        public CategoriaDAL(SqlConnection conn)
        {
            this.conn = conn;
        }

        //criando um metodo para buscar a categoria pelo id para usar na listagem de contas
        public Categoria GetCategoria(int id)
        {
            Categoria categoria = new Categoria();
            var command = new SqlCommand("select id, nome from categorias where id = @id", this.conn);
            //passando por atributo a variavel que vem do metodo 
            command.Parameters.AddWithValue("@id", id);
            //abrir conexao
            this.conn.Open();
            //fazer a leitura com sql datareader

            using (SqlDataReader rd = command.ExecuteReader())
            {
                //vai ler o registro
                rd.Read();
                categoria.Id = Convert.ToInt32(rd["id"].ToString());
                categoria.Nome = rd["nome"].ToString();
            }
            this.conn.Close();
            return categoria;
        }
    }
}
