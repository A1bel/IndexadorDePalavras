# Indexador de Palavras

## Aluno

Arthur Aibel

## Descrição do Projeto

Aplicação de console desenvolvida em C# para indexação de palavras em arquivos texto.

O sistema lê um arquivo `.txt`, identifica todas as palavras presentes, armazena cada palavra distinta em uma árvore Red-Black e registra suas ocorrências (linha e coluna) em uma lista encadeada associada ao nó da árvore.

Após a indexação, o usuário pode consultar palavras e visualizar todas as suas ocorrências no arquivo.

---

## Como Compilar e Executar

### Pré-requisitos

* .NET 8 SDK instalado

### Executando o projeto

Abra um terminal na pasta do projeto e execute:

```bash
dotnet run
```

O programa exibirá um menu com as opções de indexação e busca.

---

## Estrutura das Classes

### Ocorrencia

Representa uma ocorrência de uma palavra no arquivo.

Atributos:

* Linha
* Coluna

### NoListaOcorrencias

Nó da lista encadeada de ocorrências.

Atributos:

* Dado (Ocorrencia)
* Proximo

### ListaOcorrencias

Lista encadeada responsável por armazenar todas as ocorrências de uma palavra.

Principais métodos:

* InserirNoFim()
* Contar()
* ObterTodas()

### NoIndice

Nó da árvore Red-Black.

Atributos:

* Palavra
* Ocorrencias
* Esquerda
* Direita
* Pai
* Vermelho

### IndicePalavras

Implementação da árvore Red-Black responsável pelo índice de palavras.

Principais métodos:

* RegistrarOcorrencia()
* Buscar()
* ContarPalavrasDistintas()

### LeitorTexto

Responsável por abrir o arquivo, realizar a tokenização das palavras e alimentar o índice.

### MenuConsole

Responsável pela interação com o usuário através do console.

---

## Arquivo de Exemplo

O projeto contém dois arquivos de exemplo localizados em:

```text
textos/amostra.txt
```
```text
textos/artigo.txt
```

Caso o arquivo não seja encontrado durante a execução, também é possível informar um caminho absoluto.

---

## Instruções de Teste

1. Executar o programa utilizando:

```bash
dotnet run
```

2. Selecionar a opção de indexação.

3. Informar o caminho do arquivo:

```text
textos/amostra.txt
```

ou

```text
..\..\..\textos\amostra.txt
```

4. Verificar o resumo da indexação exibido pelo sistema.

5. Utilizar a opção de busca para consultar palavras existentes e inexistentes.

Exemplos:

```text
cidade
biblioteca
estudante
```

6. Confirmar que o sistema exibe corretamente a quantidade e as posições das ocorrências encontradas.
