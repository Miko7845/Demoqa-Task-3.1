using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class AlertsPage : BaseForm
    {
        private Button _toSeeAlertButton = new Button(By.XPath("//div[@class='row']//button[@id='alertButton']"), "Click Button to see alert");
        private Button _confirmBoxButton = new Button(By.XPath("//div[@class='col']/button[@id='confirmButton']"), "On button click, confirm box will appear");
        private Button _promptBoxButton = new Button(By.Id("promtButton"), "On button click, prompt box will appear");
        private Label _confirmResultText = new Label(By.Id("confirmResult"), "On button click, confirm box will appear");
        private Label _promptResultText = new Label(By.Id("promptResult"), "On button click, prompt box will appear");

        public AlertsPage() : base(By.Id("javascriptAlertsWrapper"), "Alerts") { }

        public void ToSeeAlertButton() => _toSeeAlertButton.Click();
        public void ConfirmBoxButton() => _confirmBoxButton.Click();
        public void PromptBoxButton() => _promptBoxButton.Click();
        public string GetConfirmText() => _confirmResultText.GetText();
        public string GetPromptText() => _promptResultText.GetText().Substring(12);
    }
}
