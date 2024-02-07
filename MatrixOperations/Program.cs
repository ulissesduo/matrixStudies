using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Security.Cryptography;
using System.Data;

namespace MyApplication
{
    class Program
    {
        public static void DisplayResult(int[,] matrixR) 
        {
            for (int row = 0; row < matrixR.GetLength(0); row++) 
            {
                for (int cols = 0; cols < matrixR.GetLength(1); cols++) 
                {
                    Console.Write(matrixR[row, cols] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int[,] SubOfMatrixes(int[,] matrixA, int[,] matrixB)
        {
            //to sum matrix is it necessary get the same index of one matrix and the another and sum both of them
            //both MUST have the same order.
            int rowsMatrixA = matrixA.GetLength(0);
            int rowsMatrixB = matrixB.GetLength(0);
            int colsMatrixA = matrixA.GetLength(1);
            int colsMatrixB = matrixB.GetLength(1);
            int[,] matrixR = new int[rowsMatrixA, colsMatrixB];

            for (int rowA = 0; rowA < matrixB.GetLength(0); rowA++)
            {
                for (int colA = 0; colA < matrixB.GetLength(1); colA++)
                {
                    matrixR[rowA, colA] = matrixA[rowA, colA] - matrixB[rowA, colA];
                }
            }
            return matrixR;
        }

        public static int[,] SumOfMatrixes(int[,] matrixA, int[,] matrixB, int[,] matrixC) 
        {
            //to sum matrix is it necessary get the same index of one matrix and the another and sum both of them
            //both MUST have the same order.
            int rowsMatrixA = matrixA.GetLength(0);
            int rowsMatrixB = matrixB.GetLength(0);
            int colsMatrixA = matrixA.GetLength(1);
            int colsMatrixB = matrixB.GetLength(1);
            int[,] matrixR = new int[rowsMatrixA, colsMatrixB];

            for (int rowA = 0; rowA < matrixA.GetLength(0); rowA++) 
            {
                for (int colA = 0; colA < matrixA.GetLength(1); colA++) 
                {
                    matrixR[rowA,colA] = matrixA[rowA,colA] + matrixB[rowA,colA] - matrixC[rowA,colA];
                }
            }
            return matrixR;
        }

        public static int[,] MultiplyMatrix(int[,] matrixA, int[,] matrixB)
        {
            int rowsMatrixA = matrixA.GetLength(0);
            int colsMatrixA = matrixA.GetLength(1);
            int colsMatrixB = matrixB.GetLength(1);
            int[,] matrixR = new int[rowsMatrixA, colsMatrixB];
          
            //iterate over matrix A rows and MatrixB cols and execute the multiplication of it
            for (int rowsA = 0; rowsA < matrixA.GetLength(0); rowsA++) 
            {
                for (int colsB = 0; colsB < matrixB.GetLength(1); colsB++) 
                {
                    //execute multiplication
                    int sum = 0;
                    for (int i = 0; i < colsMatrixA; i++) 
                    {
                        sum += matrixA[rowsA, i] * matrixB[i, colsB];                        
                    }
                    matrixR[rowsA, colsB] = sum;
                }
            }
            return matrixR;
        }

        
        static void Main(string[] args)
        {
         
            //number of rowsA == colunsB or rowsB == colunsA
            int[,] matrixA = { { 3,0,0 }, { 1,1,1 }, {1,1,1 }, { 0, 0, 3} };
            int[,] matrixB = { { 3 }, { 1 }, {0 } };

            Console.WriteLine("matriz A");
            DisplayResult(matrixA);
            Console.WriteLine("Matriz B");
            DisplayResult(matrixB);
            Console.WriteLine("MatrizA x MatrizB");

            var s = MultiplyMatrix(matrixA, matrixB);
            DisplayResult(s);

            int[,] matrixAa = { { 3, 2, 1 }, { 3, 3, 4 }, { 1, 2, 7 } };
            int[,] matrixBa = { { 3, 2, 6 }, { 1, 2, 5 }, { 3, 7, 9} };
            int[,] matrixCa = { { 1, 1, 3 }, { 4, 5, 6 }, { 4, 3, 0} };
 
            Console.WriteLine();
            Console.WriteLine("Soma de matrizes\nMatrizA");
            DisplayResult(matrixAa);
            Console.WriteLine("MatrizB");
            DisplayResult(matrixBa);
            Console.WriteLine("MatrizC");
            DisplayResult(matrixCa);
            Console.WriteLine("MatrizA + MatrizB");

            var t = SumOfMatrixes(matrixAa, matrixBa, matrixCa);
            DisplayResult(t);

            Console.WriteLine("subtração MatrizA - MatrizB");
            var q = SubOfMatrixes(matrixAa, matrixBa);
            DisplayResult(q);

        }
    }
}