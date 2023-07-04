using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPDZ
{
    internal class MatrixHelper
    {
        public static Random r = new Random();

        public static bool Equals(int[][] m1, int[][] m2)
        {
            if (m1.Length != m2.Length)
            {
                return false;
            }
            for (int i = 0; i < m1.Length; i++)
            {
                if (m1[i].Length != m2[i].Length)
                {
                    return false;
                }
                for (int j = 0; j < m1[i].Length; j++)
                {
                    if (m1[i][j] != m2[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void DisplayMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] GenerateMatrix(int m, int n, int min, int max)
        {
            try
            {
                int[][] matrix = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    matrix[i] = new int[n];
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i][j] = r.Next(min, max + 1);
                    }
                }
                return matrix;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred: {e.Message}");
                return null;
            }
        }
    }
}
