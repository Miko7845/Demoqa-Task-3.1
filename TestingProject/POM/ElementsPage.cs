using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class ElementsPage : BaseForm
    {
        public ElementsPage() : base(By.ClassName("accordion"), "Elements Page") { }
    }
}
