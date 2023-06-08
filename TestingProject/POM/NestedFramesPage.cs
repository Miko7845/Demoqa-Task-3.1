using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using AutoTestFramework.Utilities;
using AutoTestFramework.Utilities.Interactions;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class NestedFramesPage : BaseForm
    {
        private Label _parentIframeText = new Label(By.XPath("//body"), "Parent Frame");
        private Label _childIframeText = new Label(By.XPath("//body"), "Child Frame");
        private By _parenIframe = By.XPath("//iframe[@id='frame1']");
        private By _childIframe = By.XPath("//iframe[contains(@srcdoc, 'Child Iframe')]");

        public NestedFramesPage() : base(By.Id("framesWrapper"), "Nested Frames") { }

        public string GetParentIframeText()
        {
            IframeUtil.Open(DriverProvider.Driver().FindElement(_parenIframe));
            var str = _parentIframeText.GetText();
            IframeUtil.Close();
            return str;
        }

        public string GetChildIframeText()
        {
            IframeUtil.Open(DriverProvider.Driver().FindElement(_parenIframe));
            IframeUtil.Open(DriverProvider.Driver().FindElement(_childIframe));
            var str = _childIframeText.GetText();
            IframeUtil.Close();
            return str;
        }
    }
}
