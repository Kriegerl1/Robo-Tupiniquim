namespace Robo_Tupiniquim_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Robo Tupiniquim | Academia de programação 2024!\n");

            geradorDeMatriz();
            int posicaoXInicial = obterValor<int>("Digite a cord X: ");
            int posicaoYInicial = obterValor<int>("Digite a cord Y: ");
            int visao = obterValor<int>("Qual a direção que o robo está olhando? ");
            controlador(posicaoYInicial,posicaoXInicial, visao);
        }

        //Inputs Passados

        // E M E M E M E M M

        // M M D M M D M D D M



        static int visao = 0; // 0- Norte,1- Leste, 2- Sul, 3- Oeste
        static int linhas;
        static int colunas;

        static void movimentar(string[] comandos, int posXInicial, int posYInicial, int visao)
        {
            int posX = posXInicial;
            int posY = posYInicial;

            foreach (var comando in comandos)
            {
                switch (comando)
                {
                    case "M": // Move o robô na direção em que está olhando
                        switch (visao)
                        {
                            case 0: // Leste
                                posX = Math.Min(posX + 1, colunas - 1);
                                break;
                            case 1: // Norte
                                posY = Math.Max(0, posY - 1);
                                break;
                            case 2: // Oeste
                                posX = Math.Max(0, posX - 1);
                                break;
                            case 3: // Sul
                                posY = Math.Min(posY + 1, linhas - 1);
                                break;
                        }
                        break;
                    case "D": // Vira para a direita
                        visao = (visao - 1 + 4) % 4;
                        break;
                    case "E": // Vira para a esquerda
                        visao = (visao + 1 + 4) % 4;
                        break;
                }

                Console.WriteLine($"Posição final do robô: ({posX}, {posY})\n");
                visaoDoRobo(visao);
            }
        }



        static void controlador(int posXInicial, int posYInicial, int visao)
        {
            string comandosInput = obterValor<string>("Insira os comandos para o robô: ");
            string[] comandos = comandosInput.Split(" ");

            movimentar(comandos,posXInicial, posYInicial, visao);
        }

        static void visaoDoRobo(int visao)
        {
            switch (visao)
            {
                case 0: Console.WriteLine("O robô está olhando para o norte!"); break;
                case 1: Console.WriteLine("O robô está olhando para o oeste!"); break;
                case 2: Console.WriteLine("O robô está olhando para o sul!"); break;
                case 3: Console.WriteLine("O robô está olhando para o leste!"); break;
            }
        }


        static void geradorDeMatriz()
        {
            linhas = obterValor<int>("Digite a quantidade de Linhas (Eixo X) da matriz: ");
            colunas = obterValor<int>("Digite a quantidade de Colunas (Eixo Y) da matriz: ");

            string[,] matriz = new string[linhas, colunas];
            Console.Clear();
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    int linhaInversa = (linhas - 1) - i;
                    matriz[i, j] = $"[{linhaInversa},{j}]";
                }
            }

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {

                    Console.Write(matriz[i, j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

        }


        static tipo obterValor<tipo>(string texto)
        {
            Console.WriteLine(texto);

            string input = Console.ReadLine();

            try
            {
                return (tipo)Convert.ChangeType(input, typeof(tipo));
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido, tente novamente!");
                return obterValor<tipo>(texto);
            }
        }

    }
}

