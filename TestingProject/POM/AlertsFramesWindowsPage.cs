using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class AlertsFramesWindowsPage : BaseForm
    {
        public AlertsFramesWindowsPage() : base(By.ClassName("accordion"), "Alerts Page") { }
    }
}
