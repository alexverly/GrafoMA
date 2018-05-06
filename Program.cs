using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoMA
{
    class Program
    {
        // Github: http://bit.ly/GrafoMA-Codigo
        // Video: https://bit.ly/GrafoMA-Video

        // APRESENTAÇÃO DO PROGRAMA: Este programa exibe um menu para o usuário que permite chamar vários métodos para análise de grafos.
        // AUTORES:
        // - Alex Martins Oliveira
        // - Gabriel Rocha de Oliveira

        // VERSÃO: 1.0.
        // DATA: 01/06/2018
        // CÓDIGO DE HONRA: N/A

        static void Main(string[] args)
        {
            int opcao = 0;
            bool testeOpcao = true;
            Console.WriteLine("\n************************ CRIAR GRAFO ************************");
            int qtdVertice = 0;
            bool testeQtdVertice = true;
            bool testeVertice = true;
            Console.Write("\nDigite a quantidade de vértices: ");
            testeQtdVertice = int.TryParse(Console.ReadLine(), out qtdVertice);

            while (!testeQtdVertice)
            {
                Console.WriteLine("VALOR INVÁLIDO. Digite a quantidade de vértices: ");
                testeQtdVertice = int.TryParse(Console.ReadLine(), out qtdVertice);
            }

            Grafo Grafo = new Grafo(qtdVertice);

            do
            {
                Console.Clear();
                Console.WriteLine("\n************************ MENU DE GRAFOS ************************\n");
                Console.WriteLine("[01] Imprimir a ordem do grafo");
                Console.WriteLine("[02] Inserir aresta");
                Console.WriteLine("[03] Remover aresta");
                Console.WriteLine("[04] Imprimir grau de um vértice");
                Console.WriteLine("[05] Verificar se o grafo é completo");
                Console.WriteLine("[06] Verificar se o grafo é regular");
                Console.WriteLine("[07] Imprimir Matriz de Adjacência");
                Console.WriteLine("[08] Imprimir Lista de Adjacências");
                Console.WriteLine("[09] Imprimir Sequência de Graus");
                Console.WriteLine("[10] Imprimir Vértices Adjacentes de um vértice");
                Console.WriteLine("[11] Verificar se um vértice é isolado");
                Console.WriteLine("[12] Verificar se um vértice é ímpar");
                Console.WriteLine("[13] Verificar se um vértice é par");
                Console.WriteLine("[14] Verificar se dois vértices são adjacentes");
                Console.WriteLine("[15] Imprimir grafo");
                Console.WriteLine("[00] Sair\n");

                Console.Write("\nDigite a opção desejada: ");
                testeOpcao = int.TryParse(Console.ReadLine(), out opcao);

                while (opcao < 0 || opcao > 15 || testeOpcao == false)
                {
                    Console.Write("\nOPÇÃO INVÁLIDA. Digite a opção desejada: ");
                    testeOpcao = int.TryParse(Console.ReadLine(), out opcao);
                }

                switch (opcao)
                {
                    case (1):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR ORDEM DO GRAFO ************************");
                        Console.Write("\nA ordem do grafo é: " + Grafo.Ordem().ToString());
                        Console.ReadKey(true);
                        break;

                    case (2):
                        Console.Clear();
                        Console.WriteLine("\n************************ INSERIR ARESTA ************************");
                        int V1 = 0, V2 = 0;
                        bool testeAresta = true;
                        Console.Write("\nDigite o primeiro vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V1);

                        while (!testeAresta || V1 > qtdVertice || V1 <= 0)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o primeiro vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V1);
                        }

                        testeAresta = true;
                        Console.Write("\nDigite o segundo vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V2);

                        while (!testeAresta || V2 > qtdVertice || V2 <= 0)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o segundo vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V2);
                        }

                        Grafo.InsereAresta(V1, V2);
                        Console.ReadKey(true);
                        break;

                    case (3):
                        Console.Clear();
                        Console.WriteLine("\n************************ REMOVER ARESTA ************************");
                        V1 = 0;
                        V2 = 0;
                        testeAresta = true;
                        Console.Write("\nDigite o primeiro vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V1);

                        while (!testeAresta || V1 > qtdVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o primeiro vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V1);
                        }

                        testeAresta = true;
                        Console.Write("\nDigite o segundo vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V2);

                        while (!testeAresta || V2 > qtdVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o segundo vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V2);
                        }

                        Grafo.retiraAresta(V1, V2);
                        Console.ReadKey(true);
                        break;

                    case (4):
                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR GRAU DE UM VÉRTICE ************************");
                        V1 = 0;
                        testeAresta = true;
                        Console.Write("\nDigite o vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V1);

                        while (!testeAresta || V1 > qtdVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V1);
                        }

                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR GRAU DE UM VÉRTICE ************************");
                        Console.Write("\nO grau do vértice " + V1.ToString() + " é: " + Grafo.Grau(V1));
                        Console.ReadKey(true);
                        break;

                    case (5):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE O GRAFO É COMPLETO ************************");

                        if (Grafo.Completo()) Console.Write("\nO Grafo é completo. ");
                        else Console.Write("\nO Grafo não é completo. ");

                        Console.ReadKey(true);
                        break;

                    case (6):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE O GRAFO É REGULAR ************************");

                        if (Grafo.Regular()) Console.Write("\nO Grafo é regular. ");
                        else Console.Write("\nO Grafo não é regular. ");

                        Console.ReadKey(true);
                        break;

                    case (7):
                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR MATRIZ DE ADJACÊNCIA ************************");
                        Grafo.ShowMA();
                        Console.ReadKey(true);
                        break;

                    case (8):
                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR LISTA DE ADJACÊNCIA ************************");
                        Grafo.ShowLA();
                        Console.ReadKey(true);
                        break;

                    case (9):
                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR SEQUÊNCIA DE GRAUS ************************");
                        Grafo.SequenciaGraus();
                        Console.ReadKey(true);
                        break;

                    case (10):
                        Console.Clear();
                        Console.WriteLine("\n************************ LISTA VÉRTICES ADJACENTES ************************");
                        int v = 0;
                        testeVertice = true;
                        Console.Write("\nDigite o vértice para listar as adjacências: ");
                        testeVertice = int.TryParse(Console.ReadLine(), out v);

                        while (!testeVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o vértice para listar as adjacências: ");
                            testeVertice = int.TryParse(Console.ReadLine(), out v);
                        }

                        Grafo.VerticesAdjacentes(v);
                        Console.ReadKey(true);
                        break;

                    case (11):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE UM VÉRTICE É ISOLADO ************************");
                        v = 0;
                        testeVertice = true;
                        Console.Write("\nDigite o vértice para verificar se ele é isolado: ");
                        testeVertice = int.TryParse(Console.ReadLine(), out v);

                        while (!testeVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o vértice para verificar se ele é isolado: ");
                            testeVertice = int.TryParse(Console.ReadLine(), out v);
                        }

                        if (Grafo.Isolado(v)) Console.WriteLine("\nO vértice informado é classificardo como isolado. ");
                        else Console.WriteLine("\nO vértice informado não é isolado. ");
                        Console.ReadKey(true);
                        break;

                    case (12):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE UM VÉRTICE É ÍMPAR ************************");
                        v = 0;
                        testeVertice = true;
                        Console.Write("\nDigite o vértice para verificar se ele é ímpar: ");
                        testeVertice = int.TryParse(Console.ReadLine(), out v);

                        while (!testeVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o vértice para verificar se ele é ímpar: ");
                            testeVertice = int.TryParse(Console.ReadLine(), out v);
                        }

                        if (Grafo.Impar(v)) Console.WriteLine("\nO vértice informado é classificardo como ímpar. ");
                        else Console.WriteLine("\nO vértice informado não é ímpar. ");
                        Console.ReadKey(true);
                        break;

                    case (13):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE UM VÉRTICE É PAR ************************");
                        v = 0;
                        testeVertice = true;
                        Console.Write("\nDigite o vértice para verificar se ele é par: ");
                        testeVertice = int.TryParse(Console.ReadLine(), out v);

                        while (!testeVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o vértice para verificar se ele é par: ");
                            testeVertice = int.TryParse(Console.ReadLine(), out v);
                        }

                        if (Grafo.Par(v)) Console.WriteLine("\nO vértice informado é classificardo como par. ");
                        else Console.WriteLine("\nO vértice informado não é par. ");
                        Console.ReadKey(true);
                        break;

                    case (14):
                        Console.Clear();
                        Console.WriteLine("\n************************ VERIFICAR SE DOIS VÉRTICES SÃO ADJACENTES ************************");
                        V1 = 0;
                        V2 = 0;
                        testeAresta = true;
                        Console.Write("\nDigite o primeiro vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V1);

                        while (!testeAresta || V1 > qtdVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o primeiro vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V1);
                        }

                        testeAresta = true;
                        Console.Write("\nDigite o segundo vértice: ");
                        testeAresta = int.TryParse(Console.ReadLine(), out V2);

                        while (!testeAresta || V2 > qtdVertice)
                        {
                            Console.Write("\nVALOR INVÁLIDO. Digite o segundo vértice: ");
                            testeAresta = int.TryParse(Console.ReadLine(), out V2);
                        }

                        if (Grafo.Adjacentes(V1, V2)) Console.WriteLine("\nOs vértices informados são adjacentes. ");
                        else Console.WriteLine("\nOs vértices informados não são adjacentes. ");
                        Console.ReadKey(true);
                        break;

                    case (15):
                        Console.Clear();
                        Console.WriteLine("\n************************ IMPRIMIR GRAFO ************************");
                        Grafo.ImprimeGrafo();
                        Console.ReadKey(true);
                        break;

                    case (0):
                        break;

                    default:
                        Console.Write("\nOPÇÃO INVÁLIDA!");
                        break;
                }
            } while (opcao != 0);
            Console.Write("\nPressione qualquer tecla para sair...");
            Console.ReadKey(true);
        }
    }
}
