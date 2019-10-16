using NUnit.Framework;
using OpenQA.Selenium;

namespace XA.Selenium
{
    public class Tests
    {
        readonly FrontMethods f = new FrontMethods();

        [SetUp]
        public void StartBrowser()
        {
            f.Initialize();
        }

        [Test,
            Description("Wait for Ajax spinner to disappear and Click button")]
        public void AjaxLoader()
        {
            f.TargetUrl("WDU");

            f.Wait("id", "loader", "style", "display: none;");

            var aa = f.GebId("button1");
            f.DoClick(aa);

            f.GoToActive();
            var ab = f.GebXpath("//*[@id=\"myModalClick\"]/div/div/div[3]/button");
            f.DoClick(ab);
        }

        [Test,
            Description("")]
        public void LoginPassword()
        {
            f.TargetUrl("LoginPortal");

            var aa = f.GebId("text");
            f.DoInput(aa, "Login");
            var ab = f.GebId("password");
            f.DoInput(ab, "Password");
            var ac = f.GebId("login-button");
            f.DoClick(ac);

            f.AlertAccept();
        }

        [Test,
            Description("")]
        public void ClickButton()
        {
            f.TargetUrl("ClickButton");

            var aa = f.GebXpath("//*[@id=\"button1\"]");
            f.DoClick(aa);
            f.GoToActive();
            var ab = f.GebXpath("//*[@id=\"myModalClick\"]/div/div/div[3]/button");
            f.DoClick(ab);

            f.GoToActive();
            var ba = f.GebId("button2");
            f.DoClick(ba);
            f.GoToActive();
            var bb = f.GebXpath("//*[@id=\"myModalJSClick\"]/div/div/div[3]/button");
            f.DoClick(bb);

            f.GoToActive();
            var ca = f.GebId("button3");
            f.DoClick(ca);
            f.GoToActive();
            var cb = f.GebXpath("//*[@id=\"myModalMoveClick\"]/div/div/div[3]/button");
            f.DoClick(cb);
        }

        [Test,
            Description("")]
        public void ToDoList()
        {
            f.TargetUrl("ToDoList");

            var aa = f.GebXpath("//*[@id=\"container\"]/input");
            f.DoInput(aa ,"New item list");
            f.DoInput(aa, "New item list 2");
            aa.SendKeys(Keys.Enter);

            var ba = f.GebXpath("//*[@id=\"container\"]/ul/li[1]");
            f.DoClick(ba);
            f.Compare(ba, "class", "completed");
            f.DoHover(ba);
            var bb = f.GebXpath("//*[@id=\"container\"]/ul/li[1]/span/i");
            f.DoClick(bb);

            var ca = f.GebXpath("//*[@id=\"container\"]/ul/li[2]");
            f.DoClick(ca);
            f.Compare(ca, "class", "completed");
            f.DoHover(ca);
            var cb = f.GebXpath("//*[@id=\"container\"]/ul/li[2]/span/i");
            f.DoClick(cb);

            var da = f.GebXpath("//*[@id=\"container\"]/ul/li[3]");
            f.DoClick(da);
            f.Compare(da, "class", "completed");
            f.DoHover(da);
            var db = f.GebXpath("//*[@id=\"container\"]/ul/li[3]/span/i");
            f.DoClick(db);
        }

        [Test,
            Description("")]
        public void PageObjectModel()
        {
            f.TargetUrl("PageObjectModel");
            f.PageTitle("WebDriver | Page Object Model");


        }

        [TearDown]
        public void CloseBrowser()
        {
            f.ShutDown();
        }
    }
}
