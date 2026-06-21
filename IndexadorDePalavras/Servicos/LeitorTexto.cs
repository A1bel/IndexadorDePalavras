using IndexadorDePalavras.Arvore;
using IndexadorDePalavras.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.Servicos
{
    internal class LeitorTexto
    {
        public void IndexarArquivo(string caminho, IndicePalavras indice)
        {
            if (!File.Exists(caminho))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }

            int linhas = 0;
            int palavras = 0;

            using StreamReader sr = new StreamReader(caminho);
            string linha;

            while ((linha = sr.ReadLine()) != null)
            {
                linhas++;
                palavras = ProcessarLinha(linha, linhas, indice, palavras);
            }

            Console.WriteLine("\nIndexação concluída.");
            Console.WriteLine($"Linhas lidas............: {linhas}");
            Console.WriteLine($"Palavras processadas....: {palavras}");
            Console.WriteLine($"Palavras distintas......: {indice.ContarPalavrasDistintas()}");
        }

        private int ProcessarLinha(
            string linha,
            int numeroLinha,
            IndicePalavras indice,
            int palavrasProcessadas)
        {
            string palavraAtual = "";
            int colunaInicio = 0;

            for (int i = 0; i < linha.Length; i++)
            {
                char c = linha[i];

                bool valido = char.IsLetterOrDigit(c);

                // quebra palavra
                if (valido)
                {
                    if (palavraAtual == "")
                        colunaInicio = i + 1;

                    palavraAtual += c;
                }
                else
                {
                    FinalizarPalavra();
                }
            }

            // última palavra da linha
            FinalizarPalavra();

            void FinalizarPalavra()
            {
                if (palavraAtual.Length == 0)
                    return;

                string palavra = palavraAtual.ToLowerInvariant();

                indice.RegistrarOcorrencia(
                    palavra,
                    new Ocorrencia(numeroLinha, colunaInicio));

                palavrasProcessadas++;
                palavraAtual = "";
            }
            return palavrasProcessadas;
        }
    }
}
