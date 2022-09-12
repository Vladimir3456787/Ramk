using System;

namespace ConsoleMasiv
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 4;
            const int M = 5;
            const int MAX_RANGE = 100;   // Верхняя граница диапазона
            const int MIN_RANGE = 0;    // Нижняя граница диапазона

            double[,] matrix = new double[N, M];
            double max = (double)MIN_RANGE;
            double rezerve = 0.0;
            int l = 0, c = 0;           // Индексы строки и столбца макс. элемента 

            Random r = new Random();

            Console.WriteLine("Матрица\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    matrix[i, j] = r.NextDouble() * r.Next(MIN_RANGE, MAX_RANGE);
                    Console.Write("{0:0.##}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }

            max = matrix[0, 0];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (j + 1 < M && matrix[i, j + 1] > max)
                    {
                        max = matrix[i, j + 1];
                        l = i;
                        c = j + 1;
                    }

            Console.WriteLine("\nМарица после изменений\n");

            for (int i = l; i > 0; i--)
                for (int j = 0; j < M; j++)
                {
                    rezerve = matrix[i - 1, j];
                    matrix[i - 1, j] = matrix[i, j];
                    matrix[i, j] = rezerve;
                }

            for (int i = 0; i < N; i++)
                for (int j = c; j > 0; j--)
                {
                    rezerve = matrix[i, j - 1];
                    matrix[i, j - 1] = matrix[i, j];
                    matrix[i, j] = rezerve;
                }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write("{0:0.##}\t", matrix[i, j]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}