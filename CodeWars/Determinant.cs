using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    internal class Determinant
    {
        public int Det { get; set; }
        public int[][] Matrix { get; set; }
        public static int GetDeterminantNxN(int[][] ints, int det = 0)
        {
            if (ints.Length == 1)
            {
                return ints[0][0];
            }
            if (ints.Length == 2)
            {
                return ints[0][0] * ints[1][1] - ints[0][1] * ints[1][0];
            }
            int sign;
            for (int i = 0; i < ints.GetLength(0); i++)
            {
                int[][] minor = GetMinorMatrix(i, ints);
                sign = i % 2 == 0 ? 1 : -1;
                det += sign * ints[0][i] * GetDeterminantNxN(minor);
            }
            return det;


            int[][] GetMinorMatrix(int i, int[][] ints)
            {
                List<int> nums = new List<int>();
                int[][] minor = new int[ints.Length - 1][];
                for (int j = 1; j < ints.Length; j++)
                {
                    for (int k = 0; k < ints.Length; k++)
                    {
                        if (k == i)
                        {
                            continue;
                        }
                        nums.Add(ints[j][k]);
                    }
                    minor[j - 1] = nums.ToArray();
                    nums.Clear();
                }
                return minor;
            }
        }

        public static int[][] GenMatrix(int rows, int multiple = 1024)
        {
            multiple = multiple == 0 ? 1 : multiple;
            Random random = new Random();
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[rows];
                for (int j = 0; j < rows; j++)
                {
                    matrix[i][j] = random.Next(int.MinValue / multiple, int.MaxValue / multiple);
                }
            }
            return matrix;
        }

        public override string ToString()
        {
            int max = 0;
            foreach (var item in Matrix)
            {
                foreach (var num in item)
                {
                    if (num.ToString().Length > max)
                    {
                        max = num.ToString().Length;
                    }
                }

            }
            string empty = "";
            for (int i = 0; i < max; i++)
            {
                empty += " ";
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Матрица:");
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix.Length; j++)
                {
                    string str = empty + Matrix[i][j].ToString();
                    str = str.Substring(str.Length - max);
                    stringBuilder.Append(str + " ");
                }
                stringBuilder.AppendLine();
            }
            stringBuilder.AppendLine($"Опредилитель: {Det}");
            return stringBuilder.ToString();
        }
    }
}
