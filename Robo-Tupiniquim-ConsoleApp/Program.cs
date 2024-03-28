namespace Desafio_Robo_Tupiniquim_ConsoleApp
{
    internal class Program
    {
        static int posX;
        static int posY;
        static int direcao;
        static int linhas = obterValor<int>("Digite o tamanho do eixo X da matriz: ");
        static int colunas = obterValor<int>("Digite o tamanho do eixo Y da matriz: ");
        static void Main(string[] args)
        {
            Console.WriteLine("Desaifio Robô Tupiniquim | Academia de Programação 2024!\n");


            geradorDeMatriz(linhas, colunas);
            comandoRobo();
            comandoRobo();
        }


        static void comandoRobo()
        {
            string[] comandos, deployTupiniquim;

            string deploy = obterValor<string>("Digite as coordenadas do deploy do robo: \n" +
                "Utilize o padrão((Coordenada X) (Coordenada Y) (Direção))");
            deployTupiniquim = deploy.Split(" ");

            string inputDeComandos = obterValor<string>("Insira os comandos para o robô: ");
            comandos = inputDeComandos.Split(" ");

            posX = int.Parse(deployTupiniquim[0]);
            posY = int.Parse(deployTupiniquim[1]);
            direcao = int.Parse(deployTupiniquim[2]);


            foreach (var comando in comandos)
            {
                switch (comando)
                {
                    case "M": // Move o robô na direção em que está olhando

                        switch (direcao)
                        {
                            case 0: // Norte
                                posY = Math.Min(posY + 1, colunas - 1);
                                break;
                            case 1: // Leste
                                posX = Math.Max(0, posX + 1);
                                break;
                            case 2: // Sul
                                posY = Math.Max(0, posY - 1);
                                break;
                            case 3: // Oeste
                                posX = Math.Min(posX - 1, linhas - 1);
                                break;
                        }

                        break;



                    case "D": // Vira para a direita
                        direcao = (direcao + 1) % 4;
                        break;
                    case "E": // Vira para a esquerda
                        direcao = (direcao - 1 + 4) % 4;
                        break;
                }
            }


            Console.WriteLine($"Posição final do robô: ({posX}, {posY})\n");
            TupiniquimLog(direcao);
            //processarOrdem();

        }




        static void TupiniquimLog(int direcao)
        {
            switch (direcao)
            {
                case 0: Console.WriteLine("O Tupiniquim virou para o Norte!"); break;
                case 1: Console.WriteLine("O Tupiniquim virou para o Leste!"); break;
                case 2: Console.WriteLine("O Tupiniquim virou para o Sul!"); break;
                case 3: Console.WriteLine("O Tupiniquim virou para o Oeste!"); break;
            }
        }


        static void geradorDeMatriz(int linhas, int colunas)
        {
            string[,] matriz = new string[linhas, colunas];

            for (int i = 1; i < linhas; i++)
            {
                for (int j = 1; j < colunas; j++)
                {
                    int matrizXInvertida = linhas - i;

                    matriz[i, j] = $"{j}, {matrizXInvertida}  ";
                    Console.Write($"[{j},{matrizXInvertida}]  ");

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
                Console.WriteLine("Formato inválido!");
                return obterValor<tipo>(texto);
            }
        }
    }
}

//INPUT
// 5 5  
//1 2 N
//E M E M E M E M M
//3 3 L  
//M M D M M D M D D M

//Output esperado: 
//1 3 N
//5 1 L  
