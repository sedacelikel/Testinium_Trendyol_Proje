using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Trendyol_Projesi.Xpath;

namespace Trendyol_Projesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Xpath xpath = new Xpath();
            string browsername = xpath.CurrentPcDefaultBrowserName();
            ReturnModel isSuccess = new ReturnModel();

            switch (browsername)
            {
                case "None":
                    break;

                case "Firefox":
                    isSuccess = xpath.TestStartFirefox();
                    break;

                case "Chrome":
                    isSuccess = xpath.TestStartChrome();
                    break;

                case "IE":
                    isSuccess = xpath.TestStartIE();
                    break;

            }
            Console.WriteLine(" ");
            if (isSuccess.IsSuccess == true)
            {
                Console.WriteLine("Test Başarılı");
            }
            else
            {
                Console.WriteLine(isSuccess.ErrorMessage);
            }
            Console.ReadLine();
        }
    }
}


