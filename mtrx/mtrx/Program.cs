using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtrx
{
    class Matrix
    {
        public static void Multiply(int[,] mat1, int[,] mat2, int mat1row, int mat1column, int mat2row, int mat2column)
        {
           /* if(mat1row != mat2column)
            {
                Console.WriteLine("Az első mátrix sorainak száma nem egyezik meg a második mátrix oszlopainak számával!");
                return;
            }*/

            int[,] returnMatrix = new int[mat2row, mat2column];
            int sum = 0;
            for (int i = 0; i < mat2row; i++)
            {
                for (int j = 0; j < mat1column; j++)
                {
                    for (int k = 0; k < mat1row; k++)
                    {
                        sum += mat2[i, k] * mat1[k, j];
                    }
                    returnMatrix[i, j] = sum;
                    sum = 0;
                }
            }
            Write(returnMatrix, mat1row, mat1column);

        }

        public static void Addition(int[,] mat1, int[,] mat2, int mat1row, int mat1column, int mat2row, int mat2column)
        {
            int[,] returnMatrix = new int[mat2row, mat2column];
            for(int i = 0; i < mat2row; i++)
            {
                for(int j = 0; j < mat1column; j++)
                {
                    
                    returnMatrix[i, j] = mat2[i, j] + mat1[i,j];
                    
                }
            }

            Write(returnMatrix, mat1row, mat1column);
        }

        public static void Write(int[,] mat1, int mat1row, int mat1column)
        {
            for (int i = 0; i < mat1row; i++)
            {
                for (int j = 0; j < mat1column; j++)
                {
                    Console.Write(mat1[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public static int[,] Transpose(int[,] mat1, int mat1row, int mat1column)
        {
            int[,] returnMatrix = new int[mat1row, mat1column];
            for(int i = 0; i < mat1row; i++)
            {   
                for(int j = 0; j < mat1column; j++)
                {
                    returnMatrix[i, j] = mat1[j, i];
                }
            }
            return returnMatrix;
        }

        public static void SkalarMultiply(int skalarNum, int[,] mat1, int mat1row, int mat1column)
        {
            int[,] returnMatrix = new int[mat1row, mat1column];
            for (int i = 0; i < mat1row; i++)
            {
                for (int j = 0; j < mat1column; j++)
                {
                    returnMatrix[i, j] = mat1[i, j] * skalarNum;
                }
            }
            Write(returnMatrix, mat1row, mat1column);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat1 = new int[11, 11];
            int[,] mat2 = new int[11, 11];
            Random r = new Random();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j <10; j++)
                {
                    mat1[i, j] = r.Next(0, 1000);
                    mat2[i, j] = r.Next(0, 1000);
                }
            }
            /*int sum1 = 0;
            int sum2 = 0;
            int sum0 = 0;
            for (int i = 0; i < 3; i++)
            {
                sum1 = 0;
                sum2 = 0;
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        sum0 += mat2[i, k] * mat1[k, j];
                    }
                    Console.WriteLine(sum0);
                    sum0 = 0;
                    Console.WriteLine(mat1[j,0]);
                    Console.WriteLine(mat1[j,1]);
                    sum1 += mat2[i, j] * mat1[j, 0];
                    sum2 += mat2[i, j] * mat1[j, 1];
                    Console.WriteLine(mat2[i,j]);
                    sum1 += mat2[i, j] * mat1[j, i];
                    sum2 += mat2[i, j] * mat1[j, i + 1];
                }
                Console.WriteLine($"{sum1} {sum2}");
                Console.WriteLine(mat1[i,0]);
                Console.WriteLine(mat2[0,i]);
                sum += mat2[0, i] * mat1[i, 0];
                Console.WriteLine($"Összegük: {sum}");
            }*/
            Console.WriteLine("Original Matrix(mat1, first)");
            Matrix.Write(mat1, 10, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Multiplication");
            Console.WriteLine("\n");
            Matrix.Multiply(mat1, mat2, 10, 10, 10, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Addition");
            Console.WriteLine("\n");
            Matrix.Addition(mat1, mat2, 10, 10, 10, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Write");
            Matrix.Write(mat1, 10, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Transpose");
            Console.WriteLine("\n");
            int[,] transposed = Matrix.Transpose(mat1, 10, 10);
            Matrix.Write(transposed, 10, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Skalar Multiplication");
            Matrix.SkalarMultiply(2, transposed, 10, 10);
            Console.ReadKey();
        }
    }
}
