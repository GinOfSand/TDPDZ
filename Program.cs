using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TDPDZ
{
    internal class Program
    {
        public static int[][] ProizMatrix(int[][] m1, int[][] m2, ref int[][] res, int skolar)
        {
            for (int i = 0; i < m1.Length; i++)
            {
                for (int j = 0; j < m1.Length; j++)
                {
                    m2[i][j] *= skolar;
                }
            }
            res = new int[m1.Length][];
            for(int i  = 0; i < m1.Length; i++)
            {
                res[i] = new int[m1[i].Length];
            }
            if (m1.Length != m2.Length)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < m1.Length; i++)
                {
                    for (int j = 0; j < m1.Length; j++)
                    {
                        res[i][j] = m1[i][j]*m2[j][i];
                    }
                }
                return res;
            }
        }

        public static void PartProiz(int[][] m1,int[][] m2, int start, int end, ref int[][] res ,int skolar)
        {
            for (int i = start; i < end; i++)
            {
                for (int j = 0; j < m1.Length; j++)
                {
                    m2[i][j] *= skolar;
                }
            }
            try
            {
                for (int i = start; i < end; i++)
                {
                    for (int j = 0; j < m1.Length; j++)
                    {
                        res[i][j] = m1[i][j] * m2[j][i];
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public static int[][] MultiThread(int[][]m1, int[][]m2, int threadNum, int skolar)
        {
            int[][] res = new int[m1.Length][];
            for (int i = 0; i < m1.Length; i++)
            {
                res[i] = new int[m1[i].Length];
            }
            int rowPerThread = m1.Length/threadNum;
            Thread[] threads = new Thread[threadNum];
            for(int i = 0; i < threadNum; i++)
            {
                int start = i * rowPerThread;
                int end = start + rowPerThread;
                if( i == threadNum -1)
                {
                    end = m1.Length;
                }
                threads[i] = new Thread(() => PartProiz(m1,m2, start, end, ref res, skolar));
                threads[i].Start();
                
               
            }
            foreach (Thread t in threads)
            {
                t.Join();
            }
            return res;
        }
        static void Main(string[] args)
        {
            int mnoj = -1;
            int N = 10000;
            var m1 = MatrixHelper.GenerateMatrix(N, N, 1, 10);
            var m2 = MatrixHelper.GenerateMatrix(N, N, 1, 10);
            int[][] res = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ProizMatrix(m1, m2, ref res, mnoj);
            Console.WriteLine("(Одно поточный)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");
            //MatrixHelper.DisplayMatrix(res);
           
            sw.Stop();
            sw.Restart();
            var res2 = MultiThread(m1 , m2, 2, mnoj);
            Console.WriteLine("(Многопоточьный 2 потока)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");
            //MatrixHelper.DisplayMatrix(res2);

            sw.Stop();
            sw.Restart();
            var res3 = MultiThread(m1, m2, 4, mnoj);
            Console.WriteLine("(Многопоточьный 4 потока)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");

            sw.Stop();
            sw.Restart();
            var res4 = MultiThread(m1, m2, 8, mnoj);
            Console.WriteLine("(Многопоточьный 8 потока)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");

            sw.Stop();
            sw.Restart();
            var res5 = MultiThread(m1, m2, 16, mnoj);
            Console.WriteLine("(Многопоточьный 16 потока)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");

            sw.Stop();
            sw.Restart();
            var res6 = MultiThread(m1, m2, 32, mnoj);
            Console.WriteLine("(Многопоточьный 32 потока)Затраченое время в милисекундах : " + sw.ElapsedMilliseconds + "\n");
        }
    }
}
