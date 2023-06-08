using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class SamplePage : BaseForm
    {
        public SamplePage() : base(By.Id("sampleHeading"), "Sample Page") { }
    }
}
