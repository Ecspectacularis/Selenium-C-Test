using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace XA.Selenium
{
    public class FrontMethods
    {
        public IWebDriver driver;
        readonly Extensions x = new Extensions();
        readonly Variables v = new Variables();

        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void TargetUrl(string pageName)
        {
            switch (pageName)
            {
                case "MyStore":
                    driver.Url = x.GetUrls().MyStore;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "Importer":
                    driver.Url = x.GetUrls().XaImporterUrl;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "WDU":
                    driver.Url = x.GetUrls().WDU;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "ClickButton":
                    driver.Url = x.GetUrls().ClickButton;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "LoginPortal":
                    driver.Url = x.GetUrls().LoginPortal;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "ToDoList":
                    driver.Url = x.GetUrls().ToDoList;
                    log.Info("Url provided " + driver.Url);
                    break;

                case "PageObjectModel":
                    driver.Url = x.GetUrls().PageObjectModel;
                    log.Info("Url provided " + driver.Url);
                    break;

                default:
                    log.Error("Title not assigned");
                    Assert.Fail();
                    break;
            }
        }

        public void ShutDown()
        {
            driver.Close();
        }

        public void PageTitle(string pageTitle)
        {
            if (driver.Title.ToString() == pageTitle)
            {
                log.Info("Title comparison = PASS");
            }
            else
            {
                log.Error("Title comparison = FAIL");
                Assert.Fail();
            }
        }
        
        public IWebElement GebId(string path)
        {
            int i = 3;

            try
            {
                while (i != 0)
                {
                    IWebElement element = driver.FindElement(By.Id(path));

                    if (element != null)
                    {
                        log.Info("Element found");
                        log.Info(element.ToString());
                        return element;
                    }
                    else
                    {
                        log.Error("Element not found yet, trying again");
                    }

                    i--;
                    Thread.Sleep(1000);
                }
                return null;
            }
            catch (Exception e)
            {
                log.Error("Element not found");
                throw e;
            }
        }

        public IWebElement GebXpath(string path)
        {
            int i = 3;

            try
            {
                while (i != 0)
                {
                    IWebElement element = driver.FindElement(By.XPath(path));

                    if (element != null)
                    {
                        log.Info("Element found");
                        log.Info(element.ToString());
                        return element;
                    }
                    else
                    {
                        log.Error("Element not found");
                    }

                    i--;
                    Thread.Sleep(1000);
                }
                return null;
            }
            catch (Exception e)
            {
                log.Error("Element not found");
                throw e;
            }
        }

        public IWebElement GebClassName(string path)
        {
            int i = 3;

            try
            {
                while (i != 0)
                {
                    IWebElement element = driver.FindElement(By.ClassName(path));

                    if (element != null)
                    {
                        log.Info("Element found");
                        log.Info(element.ToString());
                        return element;
                    }
                    else
                    {
                        log.Error("Element not found");
                    }

                    i--;
                    Thread.Sleep(1000);
                }
                return null;
            }
            catch (Exception e)
            {
                log.Error("element not found");
                throw e;
            }
        }

        public void Compare(IWebElement element, string attribute, string value)
        {
            if (element.GetAttribute(attribute).ToString() == value)
            {
                log.Info("Attribute value matched");
            }
            else
            {
                Assert.Fail();
            }
        }

        public void Wait(string type, string path, string attribute, string compare)
        {
            int i = 5;

            try
            {
                switch (type)
                {
                    case "id":
                        while (i != 0)
                        {
                            var a = driver.FindElement(By.Id(path));

                            if (a.GetAttribute(attribute).ToString() != compare)
                            {
                                Thread.Sleep(5000);
                                i--;
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case "xpath":
                        while (i != 0)
                        {
                            var b = driver.FindElement(By.XPath(path));

                            if (b.GetAttribute(attribute).ToString() != compare)
                            {
                                Thread.Sleep(5000);
                                i--;
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    case "class":
                        while (i != 0)
                        {
                            var c = driver.FindElement(By.ClassName(path));

                            if (c.GetAttribute(attribute).ToString() != compare)
                            {
                                Thread.Sleep(5000);
                                i--;
                            }
                            else
                            {
                                return;
                            }
                        }
                        break;

                    default:
                        log.Error("Incorrect case parameter");
                        Assert.Fail();
                        break;
                }
                log.Error("Still waiting for element to disappear");
                Assert.Fail();
            }
            catch
            {
                log.Error("Switch was never executed");
                Assert.Fail();
            }
        }

        public string NameScript()
        {
            string guid = Guid.NewGuid().ToString();
            log.Info("guid assigned =  " + guid);
            return guid;
        }

        public string AssignLanguage(string language)
        {
            switch ($"{language}")
            {
                case "english":
                    v.LanguagePicker = "//*[@id=\"languageId\"]/option[2]";
                    log.Info("Language " + language + " selected");
                    break;

                case "polish":
                    v.LanguagePicker = "//*[@id=\"languageId\"]/option[3]";
                    log.Info("Language " + language + " selected");
                    break;

                case "portugese":
                    v.LanguagePicker = "//*[@id=\"languageId\"]/option[4]";
                    log.Info("Language " + language + " selected");
                    break;
            }

            return v.LanguagePicker;
        }

        public void CheckString(IWebElement element ,string checkString)
        {
            if (element.Text == checkString)
            {
                log.Info("String match = PASS");
            }
            else
            {
                log.Error("String match = FAIL");
                Assert.Fail();
            }
        }

        public void DoClick(IWebElement element)
        {
            if (element != null)
            {
                element.Click();
            }
            else
            {
                Assert.Fail();
            }
        }

        public void DoHover(IWebElement element)
        {
            Actions action = new Actions(driver);

            if (element != null)
            {
                action.MoveToElement(element);
            }
            else
            {
                Assert.Fail();
            }
        }

        public void DoInput(IWebElement element, string input)
        {
            if (element != null)
            {
                element.SendKeys(input);
            }
            else
            {
                Assert.Fail();
            }
        }

        public void AlertDismiss()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Dismiss();
        }

        public void AlertAccept()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
        }

        public void GoToActive()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().ActiveElement();
        }

        public void FrameManagementFirst()
        {
            Thread.Sleep(1000);
            driver.SwitchTo().DefaultContent();
        }

        public void FrameManagementLast()
        {
            Thread.Sleep(1000);
            List<IWebElement> frames = new List<IWebElement>(driver.FindElements(By.TagName("iframe")));
            driver.SwitchTo().Frame(frames.Last());
        }

        public void Refresh()
        {
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
        }

        public void ScrollDownByPixel(int a, int b)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy({a},{b})");
        }

        public void ScrollDownToElement(IWebElement element)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
