using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class BrowserWindowsPage : BaseForm
    {
        private Button _newTabButton = new Button(By.XPath("//button[@id='tabButton']"), "New Tab Button");
        public BrowserWindowsPage() : base(By.Id("browserWindows"), "Browser Windows Page") { }
        public void NewTabButtonClick() => _newTabButton.Click();
    }
}
