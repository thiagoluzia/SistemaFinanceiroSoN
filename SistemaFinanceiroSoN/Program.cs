using Modelo;
using Persistencia;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static System.Console;

namespace SistemaFinanceiroSoN
{
    class Program
    {
        //Propriedades que iremos utilizar 
        private List<Conta> contas;
        private List<Categoria> categorias;

        private ContaDAL  conta;
        private CategoriaDAL categoria;

        //Criando um construtor, para a classe program, onde irei instanciar tanto a classe quanto a categoria
        public Program()
        {
            //string de conexao, instanciando a conta e a categoria
            string strConn = Db.Conexao.GetStringConnection();
            this.conta = new ContaDAL(new SqlConnection(strConn));
            this.categoria = new CategoriaDAL(new SqlConnection(strConn));
        }
        static void Main(string[] args)
        {
            //laco de repetição para mostrar o menu - repita enquanto opcao for diferente de 6
            int opc;
            //instanciando  o program public
            Program p = new Program();
            do
            {
                Title = (" CONTROLE FINANCEIRO SON ");
                Uteis.MontaMenu();
                opc = Convert.ToInt32(ReadLine());

                //Condicional para validacao da opcao e alerta se nao - se opc nao for (menor e igual) && (maior e igual a 6)
                if ( !(opc >= 0 && opc <= 6) )
                {
                    //alerta 
                    Clear();
                    BackgroundColor = ConsoleColor.Red;
                    ForegroundColor = ConsoleColor.White;
                    Uteis.MontaHeader("INFORME UMA OPÇÃO VÁLIDA ", 'X', 30);
                    ResetColor();
                }
                else
                {
                    //Caso passe da condicional ele entra no switch case e executa caso seja satifeita
                    Clear();
                    switch (opc)
                    {
                        case 1:

                            //implementando o as funcionalidades na pagina principal
                            Title = "LISTAGEM DE CONTAS - CONTROLE FINANCEIRO SON";
                            Uteis.MontaHeader("LISTAGEM DE CONTAS");
                            //listaggem das contas
                            p.contas = p.conta.ListarTodos();
                            //
                            foreach (var c in p.contas)
                            {
                                WriteLine("Descrição: ", c.Descricao);
                            }

                            break;
                        case 2:
                            Write("Cadastrar");
                            break;
                        case 3:
                            Write("Editar");
                            break;
                        case 4:
                            Write("Excluir");
                            break;
                        case 5:
                            Write("Relátorios");
                            break;
                    }
                }
            } while (opc != 6 );
        }
    }
}
