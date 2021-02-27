using System;

namespace nQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            //宣告n皇后變數
            int n = 8;

            bool[,] location = new bool[n, n];

            //建立物件
            QueenSolution Queen = new QueenSolution(n);

            //帶入數字找解,從0開始
            Queen.FindSolution(location, 0);


            //計算出總共有幾組解
            Queen.PrintSum();


            Console.ReadLine();
        }
    }
}
