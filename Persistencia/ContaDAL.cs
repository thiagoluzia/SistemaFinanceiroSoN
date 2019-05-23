using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Modelo;

namespace Persistencia
{
    public class ContaDAL
    {
        //chamando a conexao
        private SqlConnection  conn;
        //para possiveis listagens de categoria
        private CategoriaDAL categoria;


        //criando um construtor, passando como parametro nossa conexao
        public ContaDAL(SqlConnection conn)
        {
            this.conn = conn;
            //utilizando a conexao
            string strConn = Db.Conexao.GetStringConnection();
            //instanciando a categoria
            this.categoria = new CategoriaDAL(new SqlConnection(strConn));
        }

        //criando um metodo public para retornar uma lista de conta modelo(devemos importa o namespace de conta modelo, e classe modelo tem que ser publica)
        public List<Conta> ListarTodos()
        {
            //objeto do tipo list, contas
            List<Conta> contas = new List<Conta>() ;

            //efetuando uma consulta, con=conta, cat=categoria
            var command = new SqlCommand("select con.id, con.descricao, con.valor, con.tipo, con.data_vencimento, cat.nome, cat.id as categoria_id from contas con inner join categorias cat on con.categoria_id = cat.id", this.conn);
            //abrir conexao
            this.conn.Open();
            //fazer a leitura com sql datareader

            using(SqlDataReader rd = command.ExecuteReader())
            {
                //quando ele encontrar ele vai executar, read ler um dado e passa para o proximo, enqunto isso ele verdadeiro, quando nao encontar mais dados ele se torna falso e sai do laço
                while (rd.Read())
                {
                    Conta conta = new Conta()
                    {
                        //atribuindo valores a nossas classes
                        Id = Convert.ToInt32(rd["id"].ToString()),
                        Descricao = rd["descricao"].ToString(),
                        Tipo = Convert.ToChar(rd["tipo"].ToString()),
                        Valor = Convert.ToDouble(rd["valor"].ToString())
                    };

                    //atribuindo para o conta a categoria, pegando o id que vem do banco de dados
                    int id_categoria = Convert.ToInt32(rd["id"].ToString());
                    conta.Categoria = this.categoria.GetCategoria(id_categoria);
                    //adicionando a contas
                    contas.Add(conta);
                }
            }
            return contas;
        }
    }
}
