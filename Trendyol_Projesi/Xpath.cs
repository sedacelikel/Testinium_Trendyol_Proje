using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;

namespace Trendyol_Projesi
{
    public class Xpath
    {

        //Buradaki amaç 3 ana tarayıcıdan uygulamamı başlatmak.
        public string CurrentPcDefaultBrowserName()
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string browserName;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice))
            {
                if (userChoiceKey == null)
                    return "None";

                object progIdValue = userChoiceKey.GetValue("Progid");

                if (progIdValue == null)
                    return "None";

                browserName = progIdValue.ToString();

                if (browserName.Contains("Chrome"))
                    browserName = "Chrome";

                else if (browserName.Contains("IE"))
                    browserName = "InternetExplorer";

                else if (browserName.Contains("Firefox"))
                    browserName = "Firefox";

              

                else
                    browserName = "None";
            }
            return browserName;
        }

        public class ReturnModel
        {
            public bool IsSuccess { get; set; }

            public string ErrorMessage { get; set; }
        }


        public ReturnModel TestStartFirefox()
        {
            ReturnModel testOk = new ReturnModel();
            try
            {
                IWebDriver driver = new FirefoxDriver();
                string link = @"http://www.trendyol.com/";
                driver.Navigate().GoToUrl(link);

                //LOGİN KISMI

                //driver.FindElement(By.XPath("//*[@id='accountBtn']/div[1]/i");
                //driver.FindElement(By.Id("email")).SendKeys("sedacelikel96@gmail.com");
                //driver.FindElement(By.Id("password")).SendKeys("sedaseda1996");
                //driver.FindElement(By.Id("loginSubmit")).Click();

                //ARAMA SONUCUNDA  RASTGELE BİR ÜRÜNÜ SEÇME İŞLEMİ

                driver.FindElement(By.XPath("//*[@id='auto - complete - app']/div/div/input")).SendKeys("Bilgisayar");
                driver.FindElement(By.XPath("//i[@class='search - icon']")).Click();


                driver.FindElement(By.XPath("//*[@id='search - app']/div/div/div[2]/div[2]/div/div[1]/div[1]/a/div[1]/div/img")).Click();//burada arama sonucunda çıkan rastgele bir ürünü seçme işlmei yaptık.

                //Son Kısım Sepet işlemleri
                driver.FindElement(By.ClassName("add-to-basket-button")).Click();
                driver.FindElement(By.ClassName("go-to-basket-button")).Click();
                driver.FindElement(By.ClassName("ty-numeric-counter-button")).Click();//ürün adedi  arttırıldı.
                driver.FindElement(By.XPath("//*[@id='partial - basket']/div/div[2]/div[2]/div[3]/button")).Click(); // çöp kutusu ikonuna tıklandı.

                driver.FindElement(By.XPath("//*[@class='btn-item btn-remove']")).Click(); //daha sonra çıkan pencereden sil butonuna tıklama işlemi yaptırdık.

                testOk.IsSuccess = true;

            }
            catch (Exception ex)
            {
                testOk.IsSuccess = false;
                testOk.ErrorMessage = "Hata : " + ex.Message;
            }
            return testOk;
        }
        public ReturnModel TestStartChrome()
        {
            ReturnModel testOk = new ReturnModel();
            try
            {
                IWebDriver driver = new ChromeDriver();
                string link = @"http://www.trendyol.com/";
                driver.Navigate().GoToUrl(link);

                //LOGİN KISMI

                //driver.FindElement(By.XPath("//*[@id='accountBtn']/div[1]/i");
                //driver.FindElement(By.Id("email")).SendKeys("sedacelikel96@gmail.com");
                //driver.FindElement(By.Id("password")).SendKeys("sedaseda1996");
                //driver.FindElement(By.Id("loginSubmit")).Click();

                //ARAMA SONUCUNDA  RASTGELE BİR ÜRÜNÜ SEÇME İŞLEMİ

                driver.FindElement(By.XPath("//*[@id='auto - complete - app']/div/div/input")).SendKeys("Bilgisayar");
                driver.FindElement(By.XPath("//i[@class='search - icon']")).Click();


                driver.FindElement(By.XPath("//*[@id='search - app']/div/div/div[2]/div[2]/div/div[1]/div[1]/a/div[1]/div/img")).Click();

                //Son Kısım Sepet işlemleri
                driver.FindElement(By.ClassName("add-to-basket-button")).Click();
                driver.FindElement(By.ClassName("go-to-basket-button")).Click();
                driver.FindElement(By.ClassName("ty-numeric-counter-button")).Click();//ürün adedi  arttırıldı.
                driver.FindElement(By.XPath("//*[@id='partial - basket']/div/div[2]/div[2]/div[3]/button")).Click(); // çöp kutusu ikonuna tıklandı.

                driver.FindElement(By.XPath("//*[@class='btn-item btn-remove']")).Click(); //daha sonra çıkan pencereden sil butonuna tıklama işlemi yaptırdık.

                testOk.IsSuccess = true;

            }
            catch (Exception ex)
            {
                testOk.IsSuccess = false;
                testOk.ErrorMessage = "Hata : " + ex.Message;
            }
            return testOk;
        }
        public ReturnModel TestStartIE()
        {
            ReturnModel testOk = new ReturnModel();
            try
            {
                IWebDriver driver = new InternetExplorerDriver();
                string link = @"http://www.trendyol.com/";
                driver.Navigate().GoToUrl(link);

                //LOGİN KISMI
                //driver.FindElement(By.XPath("//*[@id='accountBtn']/div[1]/i");
                //driver.FindElement(By.Id("email")).SendKeys("sedacelikel96@gmail.com");
                //driver.FindElement(By.Id("password")).SendKeys("sedaseda1996");
                //driver.FindElement(By.Id("loginSubmit")).Click();

                //ARAMA SONUCUNDA  RASTGELE BİR ÜRÜNÜ SEÇME İŞLEMİ


                driver.FindElement(By.XPath("//*[@id='auto - complete - app']/div/div/input")).SendKeys("Bilgisayar");
                driver.FindElement(By.XPath("//i[@class='search - icon']")).Click();


                driver.FindElement(By.XPath("//*[@id='search - app']/div/div/div[2]/div[2]/div/div[1]/div[1]/a/div[1]/div/img")).Click();

                //Son Kısım Sepet işlemleri
                driver.FindElement(By.ClassName("add-to-basket-button")).Click();
                driver.FindElement(By.ClassName("go-to-basket-button")).Click();
                driver.FindElement(By.ClassName("ty-numeric-counter-button")).Click();//ürün adedi  arttırıldı.
                driver.FindElement(By.XPath("//*[@id='partial - basket']/div/div[2]/div[2]/div[3]/button")).Click(); // çöp kutusu ikonuna tıklandı.

                driver.FindElement(By.XPath("//*[@class='btn-item btn-remove']")).Click(); //daha sonra çıkan pencereden sil butonuna tıklama işlemi yaptırdık.

                testOk.IsSuccess = true;

            }
            catch (Exception ex)
            {
                testOk.IsSuccess = false;
                testOk.ErrorMessage = "Hata : " + ex.Message;
            }
            return testOk;
        }


    }

}





