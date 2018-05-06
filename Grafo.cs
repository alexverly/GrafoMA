using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoMA
{
    public class Grafo
    {
        private int qtdVertices;
        private int qtdArestas = 0;
        private Dictionary<int, List<int>> Vertice = new Dictionary<int, List<int>>();

        public int QtdVertices { get => qtdVertices; set => qtdVertices = value; }
        public int QtdArestas { get => qtdArestas; set => qtdArestas = value; }

        // Cria grafo passando por parâmetro a quantidade de vértices que ele deve ter
        public Grafo(int qtdVertices)
        {
            this.QtdVertices = qtdVertices;
            for (int i = 1; i < (qtdVertices + 1); i++) Vertice.Add(i, new List<int>());
        }

        // Informa a ordem do grafo;
        public int Ordem()
        {
            return QtdVertices;
        }

        // Imprime o grafo (Vértice e arestas)
        public void ImprimeGrafo()
        {
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                Console.Write("\nVértice: " + i.Key + "\tArestas: ");
                foreach (int j in (i.Value as List<int>)) Console.Write(j + "\t");
            }
        }

        // Retorna se inseriu ou não a aresta no grafo;
        public bool InserirAresta(int v1, int v2)
        {
            bool inseriu = false;
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (Vertice.ContainsKey(v1) && Vertice.ContainsKey(v2)) inseriu = true;
                else inseriu = false;
            }
            return inseriu;
        }

        // Procedimento auxiliar - Insere uma aresta no grafo. O procedimento recebe os vértices(v1, v2).
        public void InsereAresta(int V1, int V2)
        {
            string pesquisa = "\nUm dos vértices informados não exite. ";

            if (V1 == V2)
            {
                Console.Write("\nEsse programa não permite loops, por se tratar de grafos simples. ");
                return;
            }

            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (InserirAresta(V1, V2))
                {
                    pesquisa = "";

                    if (V1.Equals(i.Key))
                    {
                        if (i.Value.Contains(V2)) { }
                        else
                        {
                            i.Value.Add(V2);
                            qtdArestas++;
                        }
                    }

                    if (V2.Equals(i.Key))
                    {
                        if (i.Value.Contains(V1)) { }
                        else i.Value.Add(V1);

                    }
                    pesquisa = "\nAresta inserida com sucesso. ";
                }
            }
            Console.Write(pesquisa);
        }

        // Procedimento auxiliar - Verifica se existe uma determinada aresta.
        // A função retorna true se a aresta (v1, v2) está presente no grafo, senão retorna false.
        public bool ExisteAresta(int V1, int V2)
        {
            bool pesquisa = false;

            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (Vertice.ContainsKey(V1))
                {
                    foreach (int j in (i.Value as List<int>))
                    {
                        if (j.Equals(V2)) pesquisa = true;
                    }
                }
            }
            if (V1 == V2) pesquisa = false;
            return pesquisa;
        }

        // A função retorna se a aresta foi removida ou não.
        public bool RemoverAresta(int v1, int v2)
        {
            bool pesquisa = false;

            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (Vertice.ContainsKey(v1))
                {
                    foreach (int j in (i.Value as List<int>))
                    {
                        if (j.Equals(v2)) pesquisa = true;
                    }
                }
            }
            return pesquisa;
        }

        // Procedimento auxiliar - Retira uma aresta do grafo. O procedimento retira a aresta(v1, v2) do grafo.
        public void retiraAresta(int V1, int V2)
        {
            bool pesquisa = false;

            if (ExisteAresta(V1, V2))
            {

                if (RemoverAresta(V1, V2))
                {
                    foreach (KeyValuePair<int, List<int>> i in Vertice)
                    {
                        if (V1.Equals(i.Key))
                        {
                            foreach (int j in (i.Value as List<int>)) if (j.Equals(V2)) pesquisa = true;
                        }

                        if (pesquisa)
                        {
                            (i.Value as List<int>).Remove(V2);
                            qtdArestas--;
                        }
                    }

                    foreach (KeyValuePair<int, List<int>> i in Vertice)
                    {
                        if (V2.Equals(i.Key))
                        {
                            foreach (int j in (i.Value as List<int>))
                            {
                                if (j.Equals(V1)) pesquisa = true;
                            }
                        }

                        if (pesquisa) (i.Value as List<int>).Remove(V1);
                    }

                }
                Console.Write("\nAresta removida com sucesso. ");
            }
            else
            {
                Console.Write("\nA aresta não existe. ");
            }
        }

        // Grau: Grau de um vértice v, representado por grau(v), em um grafo não direcionado é o número de arestas que incidem em v;
        // Retorna o grau do vértice passado por parâmetro
        public int Grau(int vertice)
        {
            int grau = 0;

            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (i.Key.Equals(vertice))
                {
                    foreach (int j in (i.Value as List<int>)) grau = i.Value.Count();
                }
            }
            return grau;
        }

        // Um grafo completo é um grafo simples em que todo vértice é adjacente a todos os outros vértices;
        // Informa se um grafo é completo ou não;
        public bool Completo()
        {
            bool isComplete = false;
            int totalArestas = (QtdVertices * (QtdVertices - 1) / 2);
            if (qtdArestas == totalArestas) isComplete = true;
            else isComplete = false;
            return isComplete;
        }

        // Um grafo no qual todos os vértices possuem o mesmo grau é chamado de grafo regular;
        // Informa se o grafo é regular ou não;
        public bool Regular()
        {
            bool isRegular = false;
            int[] aux = new int[Vertice.Count];
            int cont = 0;

            foreach (KeyValuePair<int, List<int>> i in Vertice) aux[cont++] = Grau(i.Key);

            for (int i = 0; i < aux.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if (aux[i] == aux[i - 1]) isRegular = true;
                    else
                    {
                        isRegular = false;
                        break;
                    }
                }
            }
            return isRegular;
        }

        // Imprime a Matriz de Adjacência;
        public void ShowMA()
        {
            int[,] MA = new int[qtdVertices + 1, qtdVertices + 1];

            Console.WriteLine();
            // Imprime a primeira linha, com todos os vértices
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (i.Key.Equals(1)) Console.Write("\t" + i.Key + "\t");
                else Console.Write(i.Key + "\t");
            }

            // Preenche toda a Matriz com 0;
            for (int i = 0; i < MA.GetLength(0); i++)
            {
                for (int j = 0; j < MA.GetLength(1); j++) MA[i, j] = 0;
            }

            // Preenche a Matriz onde os vértices possuem arestas
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                foreach (int j in (i.Value as List<int>))
                {
                    if (ExisteAresta(i.Key, j)) MA[i.Key, j] = 1;
                }
            }

            // Imprime a Matriz de Adjacência
            for (int i = 1; i < MA.GetLength(0); i++)
            {
                Console.WriteLine("\t");
                for (int j = 1; j < MA.GetLength(1); j++)
                {
                    if (j == 0) { }
                    else if (j == 1) Console.Write(i + "\t");
                    Console.Write(MA[i, j] + "\t");
                }
            }
        }

        // Imprime a Lista de Adjacência;
        public void ShowLA()
        {
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                Console.Write("\n" + i.Key + ": \t");
                foreach (int j in (i.Value as List<int>)) Console.Write(j + "\t");
            }
        }

        // Sequência de graus de um grafo consiste em escrever em ordem crescente os graus dos seus vértices;
        // Informa a Sequência de Graus do grafo;
        public void SequenciaGraus()
        {
            int[] aux = new int[Vertice.Count];
            int cont = 0;
            foreach (KeyValuePair<int, List<int>> i in Vertice) aux[cont++] = Grau(i.Key);
            ArrayList auxiliar = new ArrayList();
            for (int i = 0; i < aux.Length; i++) auxiliar.Add(aux[i]);
            auxiliar.Sort();
            Console.Write("\nA sequência de graus é: ");
            foreach (int i in auxiliar) Console.Write(i + "\t");
        }

        // Em grafos não direcionados, dois vértices são ditos adjacentesse eles são pontos finais de uma mesma aresta;
        // Informa os vértices adjacentes ao vértice passado por parâmentro;
        public void VerticesAdjacentes(int vertice)
        {
            string pesquisa = "Não encontrado.";
            foreach (KeyValuePair<int, List<int>> i in Vertice)
            {
                if (vertice.Equals(i.Key))
                {
                    pesquisa = "";
                    Console.Write("\nVértice: " + i.Key + "\t");
                    Console.WriteLine("\nAdjacências: ");
                    foreach (int j in (i.Value as List<int>)) Console.Write("\n" + j + "\t");
                }
            }
            Console.WriteLine(pesquisa);
        }

        // Um vértice com nenhuma aresta incidente é chamado de vértice isolado;
        // De acordocom o grau, os vértices se classificam em:
        // Vértice par  –  grau par;
        // Vértice ímpar  –  grau ímpar;
        // Vértice isolado  –  grau zero.

        // Verifica se o vértice passado por parâmetro é isolado ou não;
        public bool Isolado(int vertice)
        {
            bool isIsolated = false;
            if (Grau(vertice) == 0) isIsolated = true;
            else isIsolated = false;
            return isIsolated;
        }

        // Verifica se o vértice passado por parâmetro é classificado como grau ímpar ou não;
        public bool Impar(int vertice)
        {
            bool isOdd = false;
            if (Grau(vertice) % 2 == 0) isOdd = false;
            else isOdd = true;
            return isOdd;
        }

        // Verifica se o vértice passado por parâmetro é classificado como grau par ou não;
        public bool Par(int vertice)
        {
            bool isEven = false;
            if (Grau(vertice) % 2 == 0) isEven = true;
            else isEven = false;
            return isEven;
        }

        // Em grafos não direcionados, dois vértices são ditos adjacentesse eles são pontos finais de uma mesma aresta;
        // Verifica se os vértices passados por parâmentro são adjacentes ou não;
        public bool Adjacentes(int v1, int v2)
        {
            bool isAdjacent = false;
            if (ExisteAresta(v1, v2)) isAdjacent = true;
            else isAdjacent = false;
            return isAdjacent;
        }
    }
}