using System;
using System.Collections.Generic;
using System.Text;

namespace nQueen
{
    class QueenSolution
    {
        //宣告n皇后
        int n;

        //宣告總計，計算共幾組解
        int count = 0;


        public QueenSolution(int nQueen)
        {//由Main帶入n值
            n = nQueen;
        }


        public void FindSolution(bool[,] location, int x)
        {
            //x代表目前的行  最一開始是從0，由遞迴時每次+1
            //y代表目前的列
            //以座標的方式遞迴呼叫
            if (x == n)
            {//
                count++;
                SolutionPrint(location);
                return;
            }

            for (int y = 0; y < n; y++)
            {
                if (CheckPlace(location, x, y))
                {//檢查目前的座標位置是否可以放皇后
                    location[x, y] = true;
                    FindSolution(location, x + 1);//遞迴
                    location[x, y] = false;
                }
            }
        }





        public bool CheckPlace(bool[,] location, int x, int y)
        {//檢查是否可以放皇后
         //x,y代表要檢查的座標號碼
         //如果可以會回傳true
         //不行就找下一個
            for (int i = 0; i <= x; i++)
            {
                if (location[i, y] || (i <= y && location[x - i, y - i]) || (y + i < n && location[x - i, y + i]))
                {
                    //location[i, y]  →  檢查這一橫列是否已經有皇后了
                    //(i <= y && location[x - i, y - i])   → 判斷左上方是否有皇后
                    //(y + i < n && location[x - i, y + i])  → 判斷左下方是否有皇后
                    //因為後面是空的 所以不用判斷右上與右下
                    return false;
                }
            }
            return true;
        }





        public void SolutionPrint(bool[,] location)
        {//以座標方式print出解

            Console.WriteLine("solution: {0}", count);

            for (int i = 0; i < n; i++)
            {//外層控制行數
                for (int j = 0; j < n; j++)
                {//內層控制列數
                    if (location[i, j])
                    {//如果該座標是true 表示是皇后，印出Q
                        Console.Write("Q");
                    }
                    else
                    {//其餘印點
                        Console.Write(".");
                    }
                }
                Console.WriteLine();//換行
            }

            Console.WriteLine();//這裡的換行是用來分隔下一個解
        }


        public void PrintSum()
        {
            Console.WriteLine(n + "皇后共有" + count + "解-----By  Boyen");
        }
    }
}
