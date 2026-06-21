using IndexadorDePalavras.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.ListaEncadeada
{
    internal class ListaOcorrencias
    {
        private NoListaOcorrencias _raiz;
        private int _quantidade;

        public void InserirNoFim(Ocorrencia ocorrencia)
        {
            NoListaOcorrencias novo = new NoListaOcorrencias(ocorrencia);

            if (_raiz == null)
            {
                _raiz = novo;
            }
            else
            {
                NoListaOcorrencias atual = _raiz;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }

                atual.Proximo = novo;
            }
            _quantidade++;
        }

        public int Contar()
        {
            return _quantidade;
        }

        public void ObterTodas()
        {
            NoListaOcorrencias atual = _raiz;

            while (atual != null)
            {
                Console.WriteLine($"Linha {atual.Dado.Linha}, Coluna {atual.Dado.Coluna}");
                atual = atual.Proximo;
            }
        }
    }

}
