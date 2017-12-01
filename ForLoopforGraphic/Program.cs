using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoopforGraphic
{
    class Program
    {
        static void Main(string[] args)
        {
            int type = 0, level = 0;
            string s_type,s_level;
            while (type <= 0 || type > 4)
            {
                Console.WriteLine("請選擇要印出之圖形：\n");
                Console.WriteLine("\t1.菱形\n\t2.等腰直角三角形(直角在右)\n\t3.聖誕樹\n\t4. 巴斯卡三角形\n ");
                s_type = Console.ReadLine();
                int.TryParse(s_type, out type);
                if (type <= 0 || type > 4)
                    Console.WriteLine("請依照說明輸入代碼\n\n");
            }
            while(level <= 0)
            {
                Console.WriteLine("請輸入要印出之邊長／層數：\n");
                s_level = Console.ReadLine();
                int.TryParse(s_level, out level);
                if (level <= 0)
                    Console.WriteLine("請輸入合法數字\n\n");
            }
            Draw(type, level);

        }

        public static void Draw(int type,int level)
        {
            Console.Clear();
            
            // 菱形
            if(type == 1)
            {
                Console.WriteLine("您將印出邊長為 {0} 之菱形\n", level);
                for (int i = (level - 1) * -1; i < level; i++)
                {
                    for (int j = (level - 1) * -1; j < level; j++)
                    {
                        if (Math.Abs(i) + Math.Abs(j) < level)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            // 直角三角形(靠右)
            else if (type == 2)
            {
                Console.WriteLine("您將印出腰長為 {0} 之等腰直角三角形(直角在右)\n", level);
                for(int i = 1;i <= level;i++)
                {
                    for(int j = level * -1;j < 0;j++)
                    {
                        if (i + j > -1)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            // 聖誕樹
            else if (type == 3)
            {
                Console.WriteLine("您將印出層數為 {0} 之聖誕樹\n", level);
                const int mid = 0;
                for(int i = 0;i < level + 4;i++)
                {
                    if (i >= level)
                    {
                        for(int j = (level + 1) * -1; j <= level + 1;j++)
                        {
                            if (Math.Abs(j - mid) < 2)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        for (int j = (level + 1) * -1; j <= level + 1; j++)
                        {
                            if (Math.Abs(j - mid) <= i)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                        for (int k = (level + 1) * -1; k <= level + 1; k++)
                        {
                            if (Math.Abs(k - mid) <= i + 2)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
            }

            // 巴斯卡三角形
            else if (type == 4)
            {
                Console.WriteLine("您將印出層數為 {0} 的巴斯卡三角形\n", level);
                long[,] pascal = new long[level,level];
                for(int i = 0;i < level;i++)
                {
                    for(int j = 0;j < level;j++)
                    {
                        if (j > i)
                            break;
                        if (i < 2)
                            pascal[i, j] = 1;
                        else
                        {
                            if (j == 0 || j == i)
                                pascal[i, j] = 1;
                            else
                                pascal[i, j] = pascal[i - 1, j - 1] + pascal[i - 1, j];
                        }
                    }
                }
                for(int i = 0;i < level;i++)
                {
                    for(int j = 0;j < level;j++)
                    {
                        if (pascal[i, j] == 0)
                            break;
                        else
                        {
                            Console.Write(pascal[i, j] + "\t");
                        }
                    }
                    Console.WriteLine();
                }
                
            }
        }

    }
}
