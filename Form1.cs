using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace NaverSeleniumHelper
{
    public partial class Form1 : Form
    {
        protected ChromeDriverService _driverService = null;
        protected ChromeOptions _options = null;
        protected ChromeDriver _driver = null;
        private string userEmail = String.Empty;
        public Form1()
        {
            InitializeComponent();
            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;

            _options = new ChromeOptions();
            _options.AddArgument("disable-gpu");
            pageNumberInput.Text = "1";
            dir.Text = @"C:\";
        }
        private void SaveTxtFile(string email)
        {
            try
            {
                email = email + "@naver.com";
                if (userEmail == "")
                {
                    userEmail = email;
                }
                else
                {
                    userEmail = userEmail + "," + email;
                }
                // 파일 경로
                string path = dir.Text;
                // 경로를 지정하지 않은경우
                if (path == "")
                {
                    MessageBox.Show("경로를 입력해주세요.");
                    // 종료
                    return;
                }

                StreamWriter log;
                FileStream fileStream = null;
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo;

                string txtFileDir = path + "list.txt";
                logFileInfo = new FileInfo(txtFileDir);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(txtFileDir, FileMode.Append);
                }
                log = new StreamWriter(fileStream);
                log.WriteLine(email);
                log.Close();
            }
            catch(Exception ex)
            {   
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // https://cafe.naver.com/fulpot
            string url = urlInput.Text;
            // "menuLink16"
            string id = idInput.Text;
            string inputtedPageNumber = pageNumberInput.Text;
            if (url == "" || id == "")
            {
                MessageBox.Show("카페 URL이랑 가입인사 HTML ID 속성값을 입력해라");
                return;
            }
            try
            {
                _driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("로그인페이지 버튼부터 눌러서 진행하세요^^,,");
                return;
            }

            // 사용자 메세지가 존재하지 않을경우 
            if (userMessage.Text == "")
            {
                MessageBox.Show("서웃추 메세지를 입력해야 보내죠 ㅡ ㅡ");
                return;
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var element = _driver.FindElementByXPath("//*[@id='" + id + "']");
            element.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            _driver.SwitchTo().Frame("cafe_main");
            Thread.Sleep(2000);
            var page = Int32.Parse(inputtedPageNumber);
            while (true)
            {
                var el = _driver.FindElements(By.CssSelector("div.article-board:not(#upperArticleList) .pers_nick_area a"));
                var nav = _driver.FindElement(By.CssSelector("div.prev-next > a.on"));
                // 게시판 링크 
                var boardLink = nav.GetAttribute("href");
                string firstWindow = _driver.CurrentWindowHandle;
                var uri = new Uri(boardLink);
                var searchPage = HttpUtility.ParseQueryString(uri.Query).Get("search.page");
                var normalStrArr = boardLink.Split(new string[] { "&search.page" }, StringSplitOptions.None);
                string pageUrl = normalStrArr[0] + "&search.page=" + page;

                foreach (var key in _driver.WindowHandles)
                {
                    if (firstWindow != key)
                    {
                        // 처음으로 돌아감 
                        _driver.SwitchTo().Window(key);
                        _driver.Close();
                    }
                }
                // 처음으로 돌아감 
                _driver.SwitchTo().Window(firstWindow);
                _driver.Navigate().GoToUrl(pageUrl);
                _driver.SwitchTo().Frame("cafe_main");
                el = _driver.FindElements(By.CssSelector("div.article-board:not(#upperArticleList) .pers_nick_area a"));
                nav = _driver.FindElement(By.CssSelector("div.prev-next > a.on"));
                if (el.Count == 0)
                {
                    MessageBox.Show("URL 이 잘못되어서 추적을 못했거나, 게시판이 최대 페이지까지 갔으므로 크롤링을 종료합니다.");
                    return;
                }
                // 작성자 명 목록 
                foreach (var item in el)
                {
                    try
                    {
                        // 작성자 명 클릭  
                        item.Click();
                        // 딜레이 
                        Thread.Sleep(1000);
                        // 블로그 보기 태그 링크 
                        var clickToElement = _driver.FindElements(By.CssSelector(".perid-layer a"));

                        // 블로그 보기 태그 클릭 
                        if (clickToElement.Count == 0)
                            continue;

                        clickToElement[0].Click();
                        Thread.Sleep(1000);
                        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                        Thread.Sleep(1000);
                        _driver.SwitchTo().Frame("mainFrame");
                        Thread.Sleep(1000);
                        SaveTxtFile(new Uri(_driver.Url).LocalPath.Replace("/", ""));
                        // 이웃추가하기 버튼 
                        var btn = _driver.FindElements(By.CssSelector("#blog-profile .btn_area > a"));
                        btn[0].Click();
                        Thread.Sleep(1000);

                        _driver.SwitchTo().Window(_driver.WindowHandles.Last());
                        Thread.Sleep(5000);

                        btn = _driver.FindElements(By.CssSelector("label[for='each_buddy_add']"));
                        try
                        {
                            btn[0].Click();
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            foreach (var key in _driver.WindowHandles)
                            {
                                if (firstWindow != key)
                                {
                                    // 처음으로 돌아감 
                                    _driver.SwitchTo().Window(key);
                                    _driver.Close();
                                }
                            }
                            // 처음으로 돌아감 
                            _driver.SwitchTo().Window(firstWindow);
                            _driver.SwitchTo().Frame("cafe_main");
                            continue;
                        }

                        btn = _driver.FindElements(By.CssSelector("._buddyAddNext"));
                        btn[0].Click();
                        Thread.Sleep(1000);
                        bool isErr = false;
                        try
                        {
                            var txtbox = _driver.FindElement(By.Id("message"));
                            txtbox.SendKeys(userMessage.Text);
                            Thread.Sleep(1000);

                            btn = _driver.FindElements(By.CssSelector("._addBothBuddy"));
                            btn[0].Click();
                            Thread.Sleep(1000);
                        }
                        catch (Exception ex) { isErr = true; }
                        finally
                        {
                            if (_driver.WindowHandles.Count > 1)
                            {
                                _driver.SwitchTo().Window(_driver.WindowHandles[1]);
                            }
                            _driver.Close();
                        }

                        foreach (var key in _driver.WindowHandles)
                        {
                            if (firstWindow != key)
                            {
                                // 처음으로 돌아감 
                                _driver.SwitchTo().Window(key);
                                _driver.Close();
                            }
                        }
                        // 처음으로 돌아감 
                        _driver.SwitchTo().Window(firstWindow);
                        _driver.SwitchTo().Frame("cafe_main");
                    }
                    catch (Exception ex)
                    {
                        foreach (var key in _driver.WindowHandles)
                        {
                            if (firstWindow != key)
                            {
                                // 처음으로 돌아감 
                                _driver.SwitchTo().Window(key);
                                _driver.Close();
                            }
                        }
                        // 처음으로 돌아감 
                        _driver.SwitchTo().Window(firstWindow);
                        _driver.SwitchTo().Frame("cafe_main");
                    }
                }
                page += 1;
                pageNumberInput.Text = page.ToString();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://nid.naver.com/nidlogin.login");
        }

        private void UserMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            _driver = new ChromeDriver(_driverService, _options);
            _driver.Navigate().GoToUrl("https://zhukov.github.io/webogram/#/login");

            IWebElement naverAccID = _driver.FindElement(By.CssSelector("[name=phone_number]"));
            Clipboard.SetText(userIdInput.Text);
            naverAccID.SendKeys(OpenQA.Selenium.Keys.LeftControl + "V");
            naverAccID.SendKeys(OpenQA.Selenium.Keys.Enter);

            //_driver = new ChromeDriver(_driverService, _options);
            //_driver.Navigate().GoToUrl("https://nid.naver.com/nidlogin.login");

            //// 네이버 아이디 입력
            //IWebElement naverAccID = _driver.FindElement(By.CssSelector("[name=id]"));
            //Clipboard.SetText(userIdInput.Text);
            //naverAccID.SendKeys(OpenQA.Selenium.Keys.LeftControl + "V");

            //// 네이버 암호 입력
            //IWebElement naverAccPass = _driver.FindElement(By.CssSelector("[name=pw]"));
            //Clipboard.SetText(userPwInput.Text);
            //naverAccPass.SendKeys(OpenQA.Selenium.Keys.LeftControl + "V");

            //// 로그인
            //naverAccPass.SendKeys(OpenQA.Selenium.Keys.Enter);
        }
    }
}
