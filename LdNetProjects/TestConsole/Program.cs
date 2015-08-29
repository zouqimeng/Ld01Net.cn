using LdNet.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string test = "123tr";
                int i = int.Parse(test);//制造一个异常
            }
            catch (Exception e)
            {
                LogHelp.RecordException(e);
            }
        }
    }
}
