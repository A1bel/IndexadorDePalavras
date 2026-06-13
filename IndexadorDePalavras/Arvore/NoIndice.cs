using IndexadorDePalavras.ListaEncadeada;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndexadorDePalavras.Arvore
{
    internal class NoIndice
    {
        public string Palavra { get; set; }
        public ListaOcorrencias Lista { get; set; }

        public NoIndice Esquerda { get; set; }
        public NoIndice Direita { get; set; }
        public NoIndice Pai { get; set; }

        public bool Vermelho { get; set; }
    }
}
