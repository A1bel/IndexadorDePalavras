using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.Models
{
    internal class Ocorrencia
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Ocorrencia(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
    }
}
