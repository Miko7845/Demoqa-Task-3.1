using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using AutoTestFramework.Utilities;
using AutoTestFramework.Utilities.Interactions;
using OpenQA.Selenium;

namespace TestingProject.POM
{
    public class FramesPage : BaseForm
    {
        private By _upperIframe = By.XPath("//iframe[@id='frame1']");
        private By _lowerIframe = By.XPath("//iframe[@id='frame2']");
        private Label _upperiframeText = new Label(By.Id("sampleHeading"), "Upper Frame Text");
        private Label _loweriframeText = new Label(By.Id("sampleHeading"), "Lower Frame Text");

        public FramesPage() : base(By.Id("framesWrapper"), "Frames") { }

        public string GetUpperFrameText()
        {
            IframeUtil.Open(DriverProvider.Driver().FindElement(_upperIframe));
            var text = _upperiframeText.GetText();
            IframeUtil.Close();
            return text;
        }

        public string GetLowerFrameText()
        {
            IframeUtil.Open(DriverProvider.Driver().FindElement(_lowerIframe));
            var text = _loweriframeText.GetText();
            IframeUtil.Close();
            return text;
        }
    }
}
