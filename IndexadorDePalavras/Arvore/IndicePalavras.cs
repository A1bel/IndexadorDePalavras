using IndexadorDePalavras.ListaEncadeada;
using IndexadorDePalavras.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace IndexadorDePalavras.Arvore
{
    internal class IndicePalavras
    {
        private NoIndice? _raiz;
        private int _quantidadeDistintas;

        public int ContarPalavrasDistintas()
        {
            return _quantidadeDistintas;
        }

        public NoIndice? Buscar(string palavra)
        {
            NoIndice atual = _raiz;
            while (atual != null)
            {
                int comparacao = string.Compare(
                palavra,
                atual.Palavra,
                StringComparison.OrdinalIgnoreCase);

                if (comparacao == 0)
                    return atual;

                if (comparacao < 0)
                    atual = atual.Esquerda;
                else
                    atual = atual.Direita;
            }

            return null;
        }

        public void RegistrarOcorrencia(string palavra, Ocorrencia ocorrencia)
        {
            NoIndice no = Buscar(palavra);

            if (no != null)
            {
                no.Ocorrencias.InserirNoFim(ocorrencia);
                return;
            }
            InserirNovaPalavra(palavra, ocorrencia);
        }

        private NoIndice CriarNo(string palavra, Ocorrencia ocorrencia)
        {
            NoIndice novo = new();

            novo.Palavra = palavra;
            novo.Vermelho = true;

            novo.Ocorrencias = new ListaOcorrencias();
            novo.Ocorrencias.InserirNoFim(ocorrencia);

            return novo;
        }

        private void InserirNovaPalavra(string palavra, Ocorrencia ocorrencia)
        {
            NoIndice novo = CriarNo(palavra, ocorrencia);

            NoIndice? pai = null;
            NoIndice? atual = _raiz;

            while (atual != null)
            {
                pai = atual;
                if (string.Compare(
                    palavra,
                    atual.Palavra,
                    StringComparison.OrdinalIgnoreCase) < 0)
                {
                    atual = atual.Esquerda;
                }
                else
                {
                    atual = atual.Direita;
                }
            }

            novo.Pai = pai;
            if (pai == null)
            {
                _raiz = novo;
                novo.Vermelho = false;
                _quantidadeDistintas++;
                return;
            }

            if (string.Compare(
                    palavra,
                    pai.Palavra,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                pai.Esquerda = novo;
            }
            else
            {
                pai.Direita = novo;
            }

            CorrigirInsercao(novo);
            _quantidadeDistintas++;
        }

        private void CorrigirInsercao(NoIndice no)
        {
            while (no != _raiz && no.Pai != null && no.Pai.Vermelho)
            {
                NoIndice pai = no.Pai;
                NoIndice vo = pai.Pai;

                if (vo == null)
                    break;

                NoIndice tio = (pai == vo.Direita)
                ? vo.Esquerda
                : vo.Direita;

                //Caso 1 tio vermelho
                if(tio != null && tio.Vermelho)
                {
                    pai.Vermelho = false;
                    tio.Vermelho = false;
                    vo.Vermelho = true;

                    no = vo;
                }
                else
                {
                    //Caso 2A Triângulo Esquerda-Direita
                    if (pai == vo.Esquerda && no == pai.Direita)
                    {
                        RotacaoEsquerda(pai);
                        no = pai;
                        pai = no.Pai;
                    }
                    //Caso 2B Triângulo Direita-Esquerda
                    else if(pai == vo.Direita && no == pai.Esquerda)
                    {
                        RotacaoDireita(pai);
                        no = pai;
                        pai = no.Pai;
                    }

                    //Caso final Linha
                    pai = no.Pai;
                    vo = pai.Pai;

                    if(pai != null && vo  != null)
                    {
                        if(no == pai.Esquerda)
                        {
                            RotacaoDireita(vo);
                        }
                        else
                        {
                            RotacaoEsquerda(vo);
                        }
                        pai.Vermelho = false;
                        vo.Vermelho = true;
                    }
                   
                }

            }

            if(_raiz != null)
                _raiz.Vermelho = false;
        }

        private void RotacaoEsquerda(NoIndice x)
        {
            NoIndice y = x.Direita;
            NoIndice B = y.Esquerda;

            y.Pai = x.Pai;

            if (x.Pai == null)
                _raiz = y;
            else if (x == x.Pai.Esquerda)
                x.Pai.Esquerda = y;
            else
                x.Pai.Direita = y;

            y.Esquerda = x;
            x.Pai = y;

            x.Direita = B;

            if (B != null)
                B.Pai = x;
        }

        private void RotacaoDireita(NoIndice y)
        {
            NoIndice x = y.Esquerda;
            NoIndice B = x.Direita;

            x.Pai = y.Pai;

            if (y.Pai == null)
                _raiz = x;
            else if (y == y.Pai.Esquerda)
                y.Pai.Esquerda = x;
            else
                y.Pai.Direita = x;

            x.Direita = y;
            y.Pai = x;

            y.Esquerda = B;

            if (B != null)
                B.Pai = y;
        }

        public void ExibirArvore()
        {
            ExibirArvore(_raiz, "", true);
        }

        private void ExibirArvore(NoIndice? no, string indentacao, bool ultimo)
        {
            if (no == null)
                return;

            Console.WriteLine(
                indentacao +
                (ultimo ? "└── " : "├── ") +
                no.Palavra +
                (no.Vermelho ? "(V)" : "(P)"));

            indentacao += ultimo ? "    " : "│   ";

            ExibirArvore(no.Esquerda, indentacao, false);
            ExibirArvore(no.Direita, indentacao, true);
        }
    }
}
