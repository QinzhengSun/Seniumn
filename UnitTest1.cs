using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using MySqlX.XDevAPI;
using System.Net;

namespace SeleniumAssessment
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /* 1 a
             * test Consine(n)*/
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[1]/span[2]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[3]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[4]/span[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();

            IWebElement resultText = driver.FindElement(By.Id("sciOutPut"));
            double result = double.Parse(resultText.Text);
            double expect = 0.5;
            Assert.AreEqual(result, expect, 0.00001, "there is problem when adding cos60");
            
        }
        [TestMethod]
        public void TestLog()
        {
             //1 b
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[4]/span[5]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[3]/span[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[4]/span[1]")).Click();
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();

            IWebElement resultText = driver.FindElement(By.Id("sciOutPut"));
            double result = double.Parse(resultText.Text);
            double expect = 1;
            Assert.AreEqual(result, expect, 0.1, "there is problem when adding log10");

        }
        [TestMethod]
        public void TestPlus()
        {
            //1 c
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//5
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[4]")).Click();//+
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[1]/span[2]")).Click();//8
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();//=
            IWebElement resultText = driver.FindElement(By.Id("sciOutPut"));
            double result = double.Parse(resultText.Text);
            double expect = 13;
            Assert.AreEqual(result, expect, 0.000001, "there is problem when adding 5+8");

        }
        [TestMethod]
        public void TestN()
        {
            //1 d
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.calculator.net/");
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[2]/span[2]")).Click();//5
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[1]/div/div[5]/span[5]")).Click();//n!
            driver.FindElement(By.XPath("//*[@id='sciout']/tbody/tr[2]/td[2]/div/div[5]/span[4]")).Click();//=
            IWebElement resultText = driver.FindElement(By.Id("sciOutPut"));
            double result = double.Parse(resultText.Text);
            double expect = 120;
            Assert.AreEqual(result, expect, 0.000001, "there is problem when adding 5!");

        }
        [TestMethod]
        public void TestLink()
        {
            //2
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            


            TextWriter tw = new StreamWriter("C:/Users/52925/Desktop/ttt.txt");
            TextWriter tw2 = new StreamWriter("C:/Users/52925/Desktop/ttt2.txt");
            IReadOnlyCollection<IWebElement> allLink = driver.FindElements(By.TagName("a"));
            List<IWebElement> list = allLink.ToList();
            for (int i = 0; i < list.LongCount(); i++)
            {
                IReadOnlyCollection<IWebElement> allLink2 = driver.FindElements(By.TagName("a"));
                List<IWebElement> list2 = allLink2.ToList();
                String url = list2[i].GetAttribute("href");
                if (url == null || url.Equals(""))
                {
                    continue;
                }

               
                HttpWebRequest  request = null;
                HttpWebResponse response = null;
                try
                {
                    request = (HttpWebRequest)HttpWebRequest.Create(url);
                }
                catch
                {
                    tw2.WriteLine(url + ":" + "This Link has problem");
                    tw2.Flush();
                    continue;
                }
               
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    String result = ((HttpWebResponse)response).StatusDescription;                
                    tw.WriteLine(url+":"+result);
                    tw.Flush();
                }
                catch
                {
                    tw2.WriteLine(url+":"+"This link has problem");
                    continue;
                }

                response.Close();
            }
                     
        }
        
        [TestMethod]
        public void TestBuy3()

        {

            //3
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            IWebElement ie = driver.FindElement(By.XPath("//*[@id='homefeatured']/li[4]/div/div[2]/div[2]/a[1]"));
            ie.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")));

            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cart_quantity_up_4_16_0_0']/span/i")));
            int clickTime = 0;
            for (int i = 0; i < 2; i++)
            {
                driver.FindElement(By.XPath("//*[@id='cart_quantity_up_4_16_0_0']/span/i")).Click();
                clickTime++;
            }
            if (clickTime == 3) { 
            IWebElement resultTxt = driver.FindElement(By.XPath("//*[@id='total_price']"));

            String result = resultTxt.Text;
            String expect = "$154.97";
            Assert.AreEqual(expect, result);
            }
        }

        String email, password, firstName, LastName, address, city, alias, zip, phone;

        [TestMethod]
        public void TestBuy3Remove2()
        {      
            //4
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            IWebElement addToChar = driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]/div[2]/a[1]"));
            addToChar.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")));
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='cart_quantity_up_1_1_0_0']")));
            int clickTime = 0;
            for (int i = 0; i < 2; i++)
            {
                driver.FindElement(By.XPath("//*[@id='cart_quantity_up_1_1_0_0']")).Click();
                clickTime++;
            }
            Thread.Sleep(1500);

            if (clickTime == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    driver.FindElement(By.ClassName("icon-minus")).Click();
                    clickTime++;
                }
            }
            Thread.Sleep(1500);
            if (clickTime == 4)
            {
                IWebElement i = driver.FindElement(By.Id("total_product"));
                String value = i.Text;
                Assert.AreEqual("$16.51",value);
            }
           



        }
        [TestMethod]
        public void signIn()
        {
            init();
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.ClassName("login")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='SubmitCreate']")));
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("passwd")).SendKeys(password);
            driver.FindElement(By.Id("SubmitLogin")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='center_column']/ul/li/a")));
            driver.FindElement(By.XPath("//*[@id='center_column']/ul/li/a")).Click();
        }
        public void init()
        {
            email = "529259684@qq.com";
            firstName = "Qinzheng";
            LastName = "Sun";
            password = "ssss1111";
            address = "116,Pembroke st";
            city = "Hamilton";
            alias = "sadd";
            zip = "02321";
            phone = "0225643352";

        }
        public void createAccount()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            init();
            driver.FindElement(By.ClassName("login")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='SubmitCreate']")));
            driver.FindElement(By.XPath("//*[@id='email_create']")).SendKeys(email);
            driver.FindElement(By.XPath("//*[@id='SubmitCreate']")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='id_gender1']")));
            driver.FindElement(By.XPath("//*[@id='id_gender1']")).Click();
            driver.FindElement(By.XPath("//*[@id='customer_firstname']")).SendKeys(firstName);
            driver.FindElement(By.XPath("//*[@id='customer_lastname']")).SendKeys(LastName);
            driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(password);
            IWebElement dayElement = driver.FindElement(By.Id("days"));
            IWebElement mounthElement = driver.FindElement(By.Id("months"));
            IWebElement yearElement = driver.FindElement(By.Id("years"));
            IWebElement stateElement = driver.FindElement(By.Id("id_state"));
            SelectElement day = new SelectElement(dayElement);
            SelectElement mounth = new SelectElement(mounthElement);
            SelectElement year = new SelectElement(yearElement);
            day.SelectByValue("30");
            mounth.SelectByValue("10");
            year.SelectByValue("1995");
            driver.FindElement(By.Id("address1")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);
            SelectElement state = new SelectElement(stateElement);
            state.SelectByText("Alabama");
            driver.FindElement(By.Id("postcode")).SendKeys(zip);
            IWebElement countryElement = driver.FindElement(By.Id("id_country"));
            SelectElement country = new SelectElement(countryElement);
            country.SelectByText("United States");
            driver.FindElement(By.Id("phone_mobile")).SendKeys(phone);
            driver.FindElement(By.Id("alias")).SendKeys(alias);
            driver.FindElement(By.Id("submitAccount")).Click();
        }








       





    }
}
