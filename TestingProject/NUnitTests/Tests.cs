using AutoTestFramework.Utilities.Interactions;
using AutoTestFramework.Utilities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestingProject.NUnitTests;
using TestingProject.POM;
using TestingProject.Utilities;
using TestingProject.Utilities.Models;
using TestingProject.POM.Forms;

namespace TestingProject.Tests
{
    public class Tests : BaseTest
    {
        private TestDataModel _testData;
        public Tests()
        {
            _testData = TestDataManager.GetTestDataFromJson();
        }

        [Test]
        public void Handles()
        {
            Log.Info("Test scenario 'Handles'");

            Log.Info("STEP 1 - Main page is opened.");
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsFormOpened(), "Main page is not opened");

            Log.Info("STEP 2 - Main page is opened.");
            mainPage.AlertsButtonClick();
            var sideForm = new SideForm();
            sideForm.BrowserWindowsButton();
            var browserWindowsPage = new BrowserWindowsPage();
            Assert.IsTrue(browserWindowsPage.IsFormOpened(), "Page with Browser Windows form is not open");

            Log.Info("STEP 3 - New tab with sample page is open");
            browserWindowsPage.NewTabButtonClick();
            var samplePage = new SamplePage();
            WindowsUtil.SwitchTab(WindowsUtil.GetCurrentWindow());
            Assert.IsTrue(samplePage.IsFormOpened(), "New tab with sample page is not open");

            Log.Info("STEP 4 - Page with Browser Windows form is open");
            WindowsUtil.CloseCurrentTab();
            Assert.IsTrue(browserWindowsPage.IsFormOpened(), "Page with Browser Windows form is not open");

            Log.Info("STEP 5 - Page with Links form is open");
            sideForm.ShowElementsButton();
            sideForm.LinksButton();
            var linksPage = new LinksPage();
            Assert.IsTrue(linksPage.IsFormOpened(), "Page with Links form is not open");

            Log.Info("STEP 6 - New tab with main page is open");
            linksPage.HomePageClick();
            WindowsUtil.SwitchTab(WindowsUtil.GetCurrentWindow());
            Assert.IsTrue(mainPage.IsFormOpened(), "Main page is not opened");

            Log.Info("STE7 - Page with Links form is open");
            WindowsUtil.SwitchTab(WindowsUtil.GetCurrentWindow());
            Assert.IsTrue(linksPage.IsFormOpened(), "Page with Links form is not open");

            Log.Info("Test scenario 'Handles' - Success!");
        }

        [Test]
        [TestCaseSource(typeof(TestDataManager), nameof(TestDataManager.GetUsersDataFromJson))]
        public void Tables(UsersTableModel testUsers)
        {
            Log.Info("Test scenario 'Tables'");

            Log.Info("STEP 1 - Main page is opened.");
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsFormOpened(), "Main page is not opened");

            Log.Info("STEP 2 - Page with Web Tables form is open");
            mainPage.ElementsButtonClick();
            var sideForm = new SideForm();
            sideForm.WebTablesButton();
            var webTablePage = new WebTablesPage();
            Assert.IsTrue(webTablePage.IsFormOpened(), "Page with Web Tables form is not open");

            Log.Info("STEP 3 - Registration Form has appeared on page");
            webTablePage.AddButtonClick();
            var regForm = new RegistrationForm();
            Assert.IsTrue(regForm.IsFormOpened(), "Registration Form has not appeared on page.");

            Log.Info("STEP 4 - Registration form has closed. Data of User ¹ has appeared in a table.");
            regForm.EnterUserData(testUsers);
            Assert.IsTrue(webTablePage.IsUserExist(testUsers), "Data of User has not appeared in a table");

            Log.Info("STEP 5 - Number of records in table has changed. Data of User ¹ has been deleted from table");
            var tableSize = webTablePage.GetRowsCount();
            webTablePage.DeleteUser(testUsers);
            Assert.AreNotEqual(tableSize, webTablePage.GetRowsCount(), "Number of records in table has not changed");
            Assert.IsFalse(webTablePage.IsUserExist(testUsers), "Data of User has not been deleted from table");

            Log.Info("Test scenario 'Tables' - Success!");
        }

        [Test]
        public void Iframe()
        {
            // STEP 1 - Main page is opened.
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsFormOpened(), "Main page is not opened");

            // STEP 2 - Page with Nested Frames form is open. There are messages "Parent frame" & "Child Iframe" present on page
            mainPage.AlertsButtonClick();
            var sideForm = new SideForm();
            sideForm.NestedFramesButton();
            var nestedFramePage = new NestedFramesPage();
            Assert.IsTrue(nestedFramePage.IsFormOpened(), "Page with Nested Frames form is not open");
            Assert.AreEqual(new string[] { _testData.NestedFrames.ParentFrameText, _testData.NestedFrames.ChildFrameText }, new string[] { nestedFramePage.GetParentIframeText(), nestedFramePage.GetChildIframeText() }, "There are not messages \"Parent frame\" & \"Child Iframe\" present on page");

            // STEP 3 - Page with Frames form is open.  Message from upper frame is equal to the message from lower frame.
            sideForm.FramesButton();
            var FramesPage = new FramesPage();
            Assert.IsTrue(FramesPage.IsFormOpened(), "Page with Frames form is not open");
            Assert.AreEqual(FramesPage.GetUpperFrameText(), FramesPage.GetLowerFrameText(), "Message from upper frame is not equal to the message from lower frame");

            Log.Info("Test scenario 'Iframe' - Success!");
        }

        [Test]
        public void Alerts()
        {
            Log.Info("Test scenario 'Alerts'");

            Log.Info("STEP 1 - Main page is opened.");
            MainPage mainPage = new MainPage();
            Assert.IsTrue(mainPage.IsFormOpened(), "Main page is not opened");

            Log.Info("STEP 2 - Alerts form has appeared on page.");
            mainPage.AlertsButtonClick();
            var sideForm = new SideForm();
            sideForm.AlertsButton();
            var alertsPage = new AlertsPage();
            Assert.IsTrue(alertsPage.IsFormOpened(), "Alerts form has not appeared on page");

            Log.Info("STEP 3 - Alert with text \"You clicked a button\" is open.");
            alertsPage.ToSeeAlertButton();
            Assert.AreEqual(_testData.Alerts.ToSeeAlert, AlertUtil.GetText(), "The current alert does not match the expected one");

            Log.Info("STEP 4 - Alert has closed");
            AlertUtil.Close();
            Assert.IsFalse(AlertUtil.IsPresent(), "Alert has not closed");

            Log.Info("STEP 5 - Alert with text \"Do you confirm action?\" is open.");
            alertsPage.ConfirmBoxButton();
            Assert.AreEqual(_testData.Alerts.ConfirmBox, AlertUtil.GetText(), "The current alert does not match the expected one");

            Log.Info("STEP 6 - Alert has closed. Text \"You selected Ok\" has appeared on page.");
            AlertUtil.Close();
            Assert.IsFalse(AlertUtil.IsPresent(), "Alert has not closed");
            Assert.AreEqual(_testData.Alerts.ConfirmText, alertsPage.GetConfirmText(), "Text \"You selected Ok\" has not appeared on page");

            Log.Info("STEP 7 - Alert with text \"Please enter your name\" is open.");
            alertsPage.PromptBoxButton();
            Assert.AreEqual(_testData.Alerts.PromptBoxText, AlertUtil.GetText(), "Alert with text \"Please enter your name\" is not open");

            Log.Info("STEP 8 - Alert has closed. Appeared text equals to the one you've entered before.");
            string randomText = RandomData.GetRandomString(5);
            AlertUtil.Prompt(randomText);
            AlertUtil.Close();
            Assert.IsFalse(AlertUtil.IsPresent(), "Alert has not closed");
            Assert.AreEqual(randomText, alertsPage.GetPromptText(), "Appeared text is not equals to the one you've entered before");

            Log.Info("Test scenario 'Alerts' - Success!");
        }
    }
}