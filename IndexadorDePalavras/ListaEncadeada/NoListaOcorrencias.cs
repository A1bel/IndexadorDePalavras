using IndexadorDePalavras.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.ListaEncadeada
{
    internal class NoListaOcorrencias
    {
        public Ocorrencia Dado { get; set; }
        public NoListaOcorrencias Proximo { get; set; }

        public NoListaOcorrencias(Ocorrencia ocorrencia)
        {
            Dado = ocorrencia;
        }
    }
}
