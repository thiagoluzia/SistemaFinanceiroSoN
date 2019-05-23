using System;
using System.Collections.Generic;
using System.Text;

using static System.Console;

namespace SistemaFinanceiroSoN
{
    public static class Uteis
    {
        //monta menu - essas opçoe vao aparecer sempre que que o metodo for chamado no program
        public static void MontaMenu()
        {
            MontaHeader(" CONTROLE FINANCEIRO  - SON ");//chamando o monta header que foi feito abaixo antes era so um writeline
            WriteLine("Selecione uma opção abaixo: ");
            WriteLine("------------------------------");
            WriteLine("1 - Listar");
            WriteLine("2 - Cadastrar");
            WriteLine("3 - Editar");
            WriteLine("4 - Excluir");
            WriteLine("5 - Relatórios");
            WriteLine("6 - Sair");
            Write("Opção: ");
        }

        //monta header - cabecario (parametros do cabecario = uma string com o titulo, cod do tipo caractere para decorar, a quantidade de caractere que vamos usar para enfeitar)
        public static void MontaHeader(string titulo, char cod = '=', int len = 30)
        {
            //instanciando os parametros para o metodo da forma que vao ser utilizados quando se chamar o header
            WriteLine(new string(cod, len) + " " + titulo + new string(cod, len) + "\n" );
        }
    }
}
