using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM.Forms
{
    public class SideForm : BaseForm
    {
        private Button _showElementsButtons = new Button(By.XPath("//li[@id='item-0']//span[text()='Text Box']//ancestor::div[@class='element-group']"), "Elements");
        private Button _showAlertsButtons = new Button(By.XPath("//li[@id='item-0']//span[text()='Browser Windows']//ancestor::div[@class='element-group']"), "Alerts, Frame & Windows");    
        private Button _alertButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-1']"), "Alerts");
        private Button _framesButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-2']"), "Frames");
        private Button _nestedFrameButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-3']"), "Nested Frames");
        private Button _webTablesButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-3']"), "Web Tables");
        private Button _browserWindowsButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-0']"), "Browser Windows");
        private Button _linksButton = new Button(By.XPath("//div[@class='element-list collapse show']//*[@id='item-5']"), "Links");

        public SideForm() : base(By.ClassName("accordion"), "Side Form") { }

        public void ShowElementsButton() => _showElementsButtons.Click();
        public void ShowAlertsButton() => _showAlertsButtons.Click();
        public void AlertsButton() => _alertButton.Click();
        public void FramesButton() => _framesButton.Click();
        public void NestedFramesButton() => _nestedFrameButton.Click();
        public void WebTablesButton() => _webTablesButton.Click();
        public void BrowserWindowsButton() => _browserWindowsButton.Click();
        public void LinksButton() => _linksButton.Click();
    }
}
