using System;
using System.Collections.Generic;
using System.Linq;

namespace ONELabInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            NQueen nQueen = new NQueen();
            nQueen.Solve(8);
            Console.ReadKey();
        }
    }

    class NQueen
    {
        private int length = 0;
        List<int> rowPlacements; // rowPlacements[x] = y, means placing queen on row: x, column: y.
        List<List<string>> ans;

        public void Solve(int n)
        {
            length = n;
            rowPlacements = Enumerable.Repeat(-1, length).ToList();
            ans = new List<List<string>>();

            DFS(0);
            PrintAnswer();
        }

        private void DFS(int row)
        {
            if (row == length)
            {
                PushToAnswer();
            }
            else
            {
                for (int col = 0; col < length; col++)
                {
                    rowPlacements[row] = col;
                    if (IsValid(row))
                    {
                        DFS(row + 1);
                    }
                }
            }
        }

        private bool IsValid(int row)
        {
            for (int r = 0; r < row; r++)
            {
                if (rowPlacements[r] == rowPlacements[row] || // Two queens are placed on the same column.
                    Math.Abs(r - row) == Math.Abs(rowPlacements[r] - rowPlacements[row])) // Two queens are placed on the same line that slope is 1 or -1.
                {
                    return false;
                }
            }
            return true;
        }

        private void PushToAnswer()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < length; i++)
            {
                List<string> rowList = Enumerable.Repeat(".", length).ToList();
                rowList[rowPlacements[i]] = "Q";
                list.Add(string.Join("", rowList));
            }
            ans.Add(list);
        }

        private void PrintAnswer()
        {
            for (int i = 0; i < ans.Count(); i++)
            {
                Console.WriteLine(string.Format("{1}// Solution {0}", i + 1, Environment.NewLine));
                Console.WriteLine(string.Join(Environment.NewLine, ans[i]));
            }
        }
    }
}