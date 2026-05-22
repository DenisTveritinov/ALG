using System;

namespace SLAE_LUP_Solver
{
    public class LUPSolver
    {
        private int n;
        private double[][] LU;
        private int[] P;

        public LUPSolver(double[][] matrix)
        {
            n = matrix.Length;
            LU = new double[n][];
            for (int i = 0; i < n; i++)
            {
                LU[i] = new double[n];
                Array.Copy(matrix[i], LU[i], n);
            }

            P = new int[n];
            for (int i = 0; i < n; i++)
            {
                P[i] = i;
            }
        }

        public bool Decompose()
        {
            for (int i = 0; i < n; i++)
            {
                double maxEl = Math.Abs(LU[i][i]);
                int pivotRow = i;

                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(LU[k][i]) > maxEl)
                    {
                        maxEl = Math.Abs(LU[k][i]);
                        pivotRow = k;
                    }
                }

                if (maxEl == 0) return false;

                if (pivotRow != i)
                {
                    int tempP = P[i];
                    P[i] = P[pivotRow];
                    P[pivotRow] = tempP;

                    double[] tempRow = LU[i];
                    LU[i] = LU[pivotRow];
                    LU[pivotRow] = tempRow;
                }

                for (int j = i + 1; j < n; j++)
                {
                    LU[j][i] /= LU[i][i];
                    for (int k = i + 1; k < n; k++)
                    {
                        LU[j][k] -= LU[j][i] * LU[i][k];
                    }
                }
            }
            return true;
        }

        public double[] Solve(double[] b)
        {
            double[] x = new double[n];

            for (int i = 0; i < n; i++)
            {
                x[i] = b[P[i]];
                for (int k = 0; k < i; k++)
                {
                    x[i] -= LU[i][k] * x[k];
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int k = i + 1; k < n; k++)
                {
                    x[i] -= LU[i][k] * x[k];
                }
                x[i] /= LU[i][i];
            }

            return x;
        }
    }

    class Program
    {
        static void Main()
        {
            double[][] A = new double[][]
            {
                new double[] { 2, 1, 1 },
                new double[] { 1, -1, 0 },
                new double[] { 3, -1, 2 }
            };

            double[] B = { 2, -2, 2 };

            LUPSolver solver = new LUPSolver(A);

            if (solver.Decompose())
            {
                double[] result = solver.Solve(B);
                Console.WriteLine("Розв'язок системи:");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine($"x{i + 1} = {Math.Round(result[i], 4)}");
                }
            }
            else
            {
                Console.WriteLine("Помилка: Матриця вироджена. Рішення не існує або їх безліч.");
            }

            Console.ReadLine();
        }
    }
}