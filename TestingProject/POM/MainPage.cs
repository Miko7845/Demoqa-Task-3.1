using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class MainPage : BaseForm
    {
        private Button _elementsButton = new Button(By.XPath("//div[@class='category-cards']/div[1]"), "Elements");
        private Button _alertsButton = new Button(By.XPath("//div[@class='category-cards']/div[3]"), "Alerts");

        public MainPage() : base(By.ClassName("category-cards"), "Main Page") { }

        public void ElementsButtonClick() => _elementsButton.Click();
        public void AlertsButtonClick() => _alertsButton.Click();
    }
}
