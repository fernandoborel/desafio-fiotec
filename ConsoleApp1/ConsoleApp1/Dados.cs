using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class Dados
    {
        public void CarregarDados()
        {
            var sql = new Sql();

            var cadastroDeDados = new List<ContentEmail>();

            string NOME, REMETENTE, DESTINATARIO, DATAEMAIL, CONTEUDO;

            string[] line = Directory.GetFiles(@"C:\Users\Fernando\Desktop\Mensagens v02");

            
            for (int i = 0; i < line.Length; i++)
            {
                string[] text = File.ReadAllLines(line[i]);

                REMETENTE = text[0];
                DATAEMAIL = text[1];
                DESTINATARIO = text[2];
                NOME = text[3];
                CONTEUDO = (text).ToString();

                var dados = new ContentEmail();
                dados.REMETENTE = REMETENTE;
                dados.DATAEMAIL = DATAEMAIL;
                dados.DESTINATARIO = DESTINATARIO;
                dados.NOME = NOME;
                dados.CONTEUDO = CONTEUDO;

                cadastroDeDados.Add(dados);
            }

            int id = 0;

            foreach (var dados in cadastroDeDados)
            {
                Console.WriteLine(" ");
                Console.WriteLine($"ID: {id}");
                Console.WriteLine(dados.REMETENTE);
                Console.WriteLine(dados.DATAEMAIL);
                Console.WriteLine(dados.DESTINATARIO);
                Console.WriteLine(dados.NOME);
                Console.WriteLine(dados.CONTEUDO);
                Console.WriteLine(" ");
                id++;
            }
        }
    }
}
