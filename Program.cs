using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace Test3
{
    internal class Program
    {

        private static ExtentReports _extent;
        private static ExtentTest _test;

        static void Main(string[] args)
        {


            string reportPath = @"C:\ruta\del\reporte.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

           
            _test.Log(Status.Info, "Comenzando la prueba");
            _test.Log(Status.Pass, "La prueba ha sido exitosa");

            _extent.Flush();

            //Entro a la pagina

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.youtube.com/");
            driver.Manage().Window.Maximize();

            //Tomar captura de la pantalla

            driver.save_screenshot("captura1.png");

            //Busco la Informacion

            IWebElement input = driver.FindElement(By.Id("masthead-search-term"));
            input.SendKeys("Juegos de video");

            //Presionar el boton Buscar

            IWebElement btnsearch = driver.FindElement(By.Id("search-btn"));
            btnsearch.Click();

            //Abro Mi Biblioteca

            IWebElement btnlibrary = driver.FindElement(By.Id("library-btn"));
            btnlibrary.Click();

            //Cierro la pagina web

            driver.Close();

        }
    }
}
