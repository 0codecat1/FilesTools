using System;
using System.IO;

namespace FilesTools
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var pg = new Program();
                Console.WriteLine("作用域:程序所在当前目录及下一级子目录");
                Console.WriteLine("1.删除文件名中的部分字符");
                Console.WriteLine("2.删除文件名中的指定位置字符");
                Console.WriteLine("3.替换文件名中的部分字符");
                Console.WriteLine("9.退出");
                string text1 = Console.ReadLine().ToString();
                if (text1 == "1")
                {
                    Console.WriteLine("请选择文件类型(输入数字)");
                    Console.WriteLine("1:txt  2:xml  3:json  4:pdf  5:docx  6:xlsx  7:pptx  8:jpg  9:png  10:mp3  11:mp4  12:zip  13:rar ");
                    string num1 = Console.ReadLine().ToString();
                    Console.WriteLine("请输入要删除的字符");
                    string text1_1 = Console.ReadLine().ToString();
                    //获得当前运行程序的路径
                    string rootPath = Directory.GetCurrentDirectory();
                    DirectoryInfo root = new DirectoryInfo(rootPath);
                    //获取当前路径下的文件                   
                    FileInfo[] files = root.GetFiles(pg.FileType(num1));
                    //   FileInfo[] files = root.GetFiles("*.xml");
                    //获取当前路径下的文件夹
                    DirectoryInfo[] dics = root.GetDirectories();
                    foreach (FileInfo file in files)
                    {
                        //Console.WriteLine(file);
                        file.MoveTo(file.DirectoryName + "\\" + file.Name.Replace(text1_1, ""));
                    }
                    if (dics.Length > 0)
                    {
                        foreach (DirectoryInfo dirChild in dics)
                        {
                                DirectoryInfo Child = new DirectoryInfo(dirChild.FullName);
                                FileInfo[] Childfiles = Child.GetFiles(pg.FileType(num1));
                                foreach (FileInfo Childfile in Childfiles)
                                {
                           //         Console.WriteLine(Childfile);
                           //         Console.WriteLine(Childfile.Name);
                           //         Console.WriteLine(Childfile.DirectoryName+"\\"+ Childfile.Name);
                                 Childfile.MoveTo(Childfile.DirectoryName + "\\" + Childfile.Name.Replace(text1_1, ""));
                            }
                        }
                    }
                    Console.WriteLine("删除完成");

                    //   Console.WriteLine(rootPath);

                }
                else
                {
                  if(text1 == "2")
                   {
                        Console.WriteLine("请选择文件类型(输入数字)");
                        Console.WriteLine("1:txt  2:xml  3:json  4:pdf  5:docx  6:xlsx  7:pptx  8:jpg  9:png  10:mp3  11:mp4  12:zip  13:rar ");
                        string num2 = Console.ReadLine().ToString();
                        Console.WriteLine("请输入要删除字符的位置");
                        string text2_1 = Console.ReadLine().ToString();
                        //获得当前运行程序的路径
                        string rootPath = Directory.GetCurrentDirectory();
                        DirectoryInfo root = new DirectoryInfo(rootPath);
                        //获取当前路径下的文件                   
                        FileInfo[] files = root.GetFiles(pg.FileType(num2));
                        //获取当前路径下的文件夹
                        DirectoryInfo[] dics = root.GetDirectories();
                        foreach (FileInfo file in files)
                        {
                            file.MoveTo(file.DirectoryName + "\\" + file.Name.Remove(Convert.ToInt32(text2_1)-1, 1));
                        }
                        if (dics.Length > 0)
                        {
                            foreach (DirectoryInfo dirChild in dics)
                            {
                                DirectoryInfo Child = new DirectoryInfo(dirChild.FullName);
                                FileInfo[] Childfiles = Child.GetFiles(pg.FileType(num2));
                                foreach (FileInfo Childfile in Childfiles)
                                {
                                    Childfile.MoveTo(Childfile.DirectoryName + "\\" + Childfile.Name.Remove(Convert.ToInt32(text2_1)-1, 1));
                                }
                            }
                        }
                        Console.WriteLine("删除完成");
                   }
                  else 
                  { 
                    if(text1 == "3")
                    {
                        Console.WriteLine("请选择文件类型(输入数字)");
                        Console.WriteLine("1:txt  2:xml  3:json  4:pdf  5:docx  6:xlsx  7:pptx  8:jpg  9:png  10:mp3  11:mp4  12:zip  13:rar ");
                        string num3 = Console.ReadLine().ToString();
                        Console.WriteLine("请输入要被替换的源字符");
                        string text3_1 = Console.ReadLine().ToString();
                        Console.WriteLine("请输入要替换的目标字符");
                        string text3_2 = Console.ReadLine().ToString();
                        //获得当前运行程序的路径
                        string rootPath = Directory.GetCurrentDirectory();
                        DirectoryInfo root = new DirectoryInfo(rootPath);
                        //获取当前路径下的文件
                        FileInfo[] files = root.GetFiles(pg.FileType(num3));
                        //获取当前路径下的文件夹
                        DirectoryInfo[] dics = root.GetDirectories();
                        foreach (FileInfo file in files)
                        {
                            file.MoveTo(file.DirectoryName + "\\" + file.Name.Replace(text3_1,text3_2));
                        }
                        if (dics.Length > 0)
                        {
                            foreach (DirectoryInfo dirChild in dics)
                            {
                                DirectoryInfo Child = new DirectoryInfo(dirChild.FullName);
                                FileInfo[] Childfiles = Child.GetFiles(pg.FileType(num3));
                                foreach (FileInfo Childfile in Childfiles)
                                {
                                    Childfile.MoveTo(Childfile.DirectoryName + "\\" + Childfile.Name.Replace(text3_1,text3_2));
                                    
                                }
                            }
                        }
                        Console.WriteLine("替换完成");
                    }
                    else 
                    { break; }
                   }

                }
                
            }
            
        }

        public enum files { 
            txt = 1, xml, json, pdf, docx, xlsx, pptx, jpg, png, mp3, mp4, zip, rar 
        }


        public string FileType(string num)
        {


            string result = "*."+((files)Convert.ToInt32(num)).ToString();

            return result;
     
        }
    }
}
