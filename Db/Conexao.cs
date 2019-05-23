using System;

namespace Db
{
    public class Conexao
    {
        //dados necessarios para acessar o banco de dados
        private static readonly string server = "DESKTOP-EASAT3O\\SQLEXPRESS";
        private static readonly string database = "SoN_Financeiro";
        private static readonly string username = "sa";
        private static readonly string password = "bwy6932guz";

        //metodo responsavel por devolver a string de conexao
        public static string GetStringConnection() => $"Server={server};Database={database};User Id={username};Password={password}";
    }
}
