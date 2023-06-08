using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class LinksPage : BaseForm
    {
        private Button _homeLinkButton = new Button(By.Id("simpleLink"), "Home Link");
        public LinksPage() : base(By.Id("linkWrapper"), "Links Page") { }

        public void HomePageClick() => _homeLinkButton.Click();
    }
}
