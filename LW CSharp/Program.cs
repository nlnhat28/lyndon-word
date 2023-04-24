// LYNDON WORS 
// C# Console

using System;
using System.Collections.Generic;
using System.Linq;

namespace LW_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] arrS = { "0", "1" };
                int n;

                Console.Write("   Nhap so nguyen n: ");
                while (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.Write("   !!! n khong phai 1 so nguyen. Nhap lai n: ");
                }

                List<string> ListLyndonWord = ShowAllLyndonWords(arrS.ToList(), n);

                foreach (string w in ListLyndonWord)
                {
                    Console.WriteLine("   " + w);
                }
                Console.WriteLine("   So luong: {0}", ListLyndonWord.Count());
                Console.WriteLine("   An Enter de tiep tuc");
                Console.ReadKey();
            }
        }

        //Hàm tạo list Lyndon Words
        static List<string> ShowAllLyndonWords(List<string> S, int N) 
        {
            List<string> listLW = new List<string>();

            if (S.Count() == 0 || N == 0) listLW = null;
            else
            {
                listLW.Add(S[0]); //Chữ cái đầu tiên là 1 Lyndon Word

                for (int n = 1; n <= N; n++) // n: 1 → Số kí tự tối đa nhập từ bàn phím
                {
                    List<string> tmplistLW = new List<string>();

                    foreach (string word in listLW)
                    {
                        List<char> NewWord = new List<char>();
                        List<char> WordInList = word.ToList();

                        // Bước 1 Thuật toán Duval 
                        // Lặp lại các ký hiệu từ 1 Lyndon Word để tạo thành một New Word có độ dài là n
                        // v[i] = w[i mod |w|]
                        for (int i = 0; i < n; i++)
                        {
                            NewWord.Add(WordInList[i % word.Length]); 
                        }
                        
                        // Bước 2 Thuật toán Duval 
                        // Xoá kí tự cuối cùng nếu nó trùng với kí tự cuối cùng trong bảng chữ cái
                        while (NewWord.Count() > 0 && (NewWord[NewWord.Count() - 1] == char.Parse(S[S.Count() - 1])))
                        {
                            NewWord.RemoveAt(NewWord.Count() - 1);                           
                        }

                        // Bước 3 Thuật toán Duval 
                        // Thay kí tự cuối cùng của New Word thành kí tự sau nó trong bảng chữ cái
                        if (NewWord.Count() > 0)
                        {
                            int lastIndex = S.IndexOf((NewWord[NewWord.Count() - 1]).ToString());

                            NewWord.RemoveAt(NewWord.Count() - 1);
                            NewWord.Add(char.Parse(S[lastIndex + 1]));

                            string W = new string(NewWord.ToArray());
                            if (!listLW.Contains(W)) tmplistLW.Add(W);
                        }  
                    }
                    listLW.AddRange(tmplistLW);
                }
            }
            return listLW;
        }
    }
}
