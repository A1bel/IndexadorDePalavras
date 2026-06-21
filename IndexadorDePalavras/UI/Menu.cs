using IndexadorDePalavras.Arvore;
using IndexadorDePalavras.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.UI
{
    internal class Menu
    {
        private IndicePalavras _indice = new IndicePalavras();
        private LeitorTexto _leitor = new LeitorTexto();

        public void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1 - Indexar arquivo");
                Console.WriteLine("2 - Buscar palavra");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Indexar();
                        break;

                    case "2":
                        Buscar();
                        break;

                    case "3":
                        Console.WriteLine("Encerrando...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausar();
                        break;
                }
            }
        }
        private void Indexar()
        {
            Console.Clear();
            Console.WriteLine("=== INDEXAÇÃO DE ARQUIVO ===");

            Console.Write("Digite o caminho do arquivo: ");
            string caminho = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(caminho))
            {
                Console.WriteLine("Caminho inválido!");
                Pausar();
                return;
            }

            _indice = new IndicePalavras();
            _leitor.IndexarArquivo(caminho, _indice);

            Pausar();
        }
        private void Buscar()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCA DE PALAVRA ===");

            Console.WriteLine("Digite a palavra: ");
            string palavra = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(palavra))
            {
                Console.WriteLine("Palavra inválida!");
                Pausar();
                return;
            }

            if (_indice.ContarPalavrasDistintas() == 0)
            {
                Console.WriteLine("Nenhum arquivo foi indexado.");
                Console.WriteLine("Realize uma indexação antes de buscar palavras.");
                Pausar();
                return;
            }

            palavra = palavra.ToLowerInvariant();
            NoIndice no = _indice.Buscar(palavra);

            if(no == null)
            {
                Console.WriteLine("Palavra não encontrada");
                Pausar();
                return;
            }

            Console.WriteLine($"\nTotal de ocorrências: {no.Ocorrencias.Contar()}");

            no.Ocorrencias.ObterTodas();

            Pausar();
        }
        private void Pausar()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
