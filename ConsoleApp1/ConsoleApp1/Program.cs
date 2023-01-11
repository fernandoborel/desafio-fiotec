using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dados atualizados: ");
            var dados = new Dados();
            dados.CarregarDados();
            Console.WriteLine("Aperte 'ENTER' para sair.");
            Console.ReadLine();
        }
    }
}
