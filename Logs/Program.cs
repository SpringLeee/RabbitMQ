using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1,1000,i=> {

                FileStream fs = new FileStream(@"E://log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                //开始写入
                sw.Write("Hello World!!!!");
                //清空缓冲区
                sw.Flush();
                //关闭流
                sw.Close();
                fs.Close();


            });

           

            Console.WriteLine(" --  Success --");
            Console.ReadKey();

        }
        
    }
}
