using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test12
{
    public partial class Form1 : Form
    {

        IWebDriver driver;
        ChromeDriverService service;
        ChromeOptions options;
        ArrayList searchArray = new ArrayList();
        
        
        
        public Form1()
        {
            InitializeComponent();
            
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            options = new ChromeOptions();
            options.AddArgument("diable-gpu");

            // "headless" 를 입려하면, 윈도우창이 보이지 않음


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (driver = new ChromeDriver(service, options))
            {
                driver.Navigate().GoToUrl("https://www.g2b.go.kr/index.jsp");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                listBox1.Items.Clear();
                //searchArray.Clear();

                // 검색어 입력 명령
                //By에 마우스대고 Using OpenQA.Selenium 활성화! XPath도!

                var element = driver.FindElement(By.XPath("//*[@id='bidNm']"));
                element.SendKeys("태양광");

                // 검색 시작일 입력

                element = driver.FindElement(By.XPath("//*[@id='fromBidDt']"));
                element.Clear();
                element.SendKeys("2022/01/27");

                // 검색 종료일 입력

                element = driver.FindElement(By.XPath("//*[@id='toBidDt']"));
                element.Clear();
                element.SendKeys("2022/01/27");

                // 검색 시작

                element = driver.FindElement(By.XPath("//*[@id='searchForm']/div/fieldset[1]/ul/li[4]/dl/dd[3]/a/strong"));
                element.Click();



                //아래에서 부터 다시 시작 값 불러오는게 막혀있음

                try
                {
                    listBox1.Items.Add("박준규1");
                    listBox1.Items.Add("박준규2");
                 

                    listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id='resultForm']/div[1]")).Text);
                                                                    //*[@id="resultForm"]/div[1]/ol/li[1]


                    listBox1.Items.Add(driver.FindElement(By.Id("container")).FindElement(By.ClassName("t1")).Text);                    

                    //listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id='resultForm']/div[2]/table/tbody/tr[1]/td[4]/div/a")).Text);


                    //listBox1.Items.Add(driver.FindElement(By.XPath("//*[@id='sp_nws_all1']/div[1]/div/div[2]/div/a")).Text);
                    //listBox1.Items.Add(driver.FindElement(By.ClassName("news_info")).GetAttribute("href"));
                    //listBox1.Items.Add(driver.FindElement(By.Id("resultForm")).FindElement(By.ClassName("tl")).GetAttribute("href");

                }
                catch
                {
                    listBox1.Items.Add("검색 결과 없음");
                }

                driver.Close();



                //int index = 0;

                //List<IWebElement> elements = driver.FindElement(By.Id("container")).FindElements(By.ClassName("t1")).ToList();

                //foreach (IWebElement x in elements)
                //{
                //    listBox1.Items.Add(x.Text);
                //    //searchArray.Add(x.FindElement(By.ClassName("t1")).FindElement(By.TagName("a")).GetAttribute("href"));
                //    index++;

                //}

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
