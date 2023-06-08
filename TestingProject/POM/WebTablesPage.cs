using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using TestingProject.Utilities.Models;
using System.Linq;
using AngleSharp.Text;
using AutoTestFramework.Utilities;
using System.Collections.ObjectModel;

namespace TestingProject.POM
{
    public class WebTablesPage : BaseForm
    {
        private Button _addButton = new Button(By.Id("addNewRecordButton"), "Add Button");
        private By _rows = By.XPath("//div[@class='rt-tr-group']/div[not (contains(@class, '-padRow'))]");
        private By _tableColumns = By.TagName("div");
        private By _editElement = By.XPath(".//span[@title='Edit']");
        private By _deleteElement = By.XPath(".//span[@title='Delete']");

        public WebTablesPage() : base(By.ClassName("web-tables-wrapper"), "Web Tables") { }

        private ReadOnlyCollection<IWebElement> GetRowElements() => DriverProvider.Driver().FindElements(_rows);
        public int GetRowsCount() => GetRowElements().Count;
        public void DeleteUser(UsersTableModel user) => new Button(By.Id(GetDeleteId(user)), "Delete Button").Click();
        public void EditUser(UsersTableModel user) => new Button(By.Id(GetEditId(user)), "Edit Button").Click();
        public void AddButtonClick() => _addButton.Click();

        private string GetDeleteId(UsersTableModel user)
        {
            foreach (var x in GetDataFromTable())
                if (x.FirstName == user.FirstName && x.LastName == user.LastName && x.Age == user.Age && x.Email == user.Email && x.Salary == user.Salary && x.Department == user.Department)
                    return x.DeleteId;
            return null;
        }

        private string GetEditId(UsersTableModel user)
        {
            foreach (var x in GetDataFromTable())
                if (x.FirstName == user.FirstName && x.LastName == user.LastName && x.Age == user.Age && x.Email == user.Email && x.Salary == user.Salary && x.Department == user.Department)
                    return x.EditId;
            return null;
        }

        public bool IsUserExist(UsersTableModel user)
        {
            if (GetDataFromTable().Any(x => x.FirstName == user.FirstName && x.LastName == user.LastName && x.Age == user.Age && x.Email == user.Email && x.Salary == user.Salary && x.Department == user.Department))
                return true;
            return false;
        }

        public List<UsersTableModel> GetDataFromTable()
        {
            var list = new List<UsersTableModel>();
            for (int i = 0; i < GetRowsCount(); i++) list.Add(new UsersTableModel());
            foreach (var zip in GetRowElements().Zip(list, System.Tuple.Create))
            {
                zip.Item2.FirstName = zip.Item1.FindElements(_tableColumns).ElementAt(0).Text;
                zip.Item2.LastName = zip.Item1.FindElements(_tableColumns).ElementAt(1).Text;
                zip.Item2.Age = zip.Item1.FindElements(_tableColumns).ElementAt(2).Text.ToInteger(0);
                zip.Item2.Email = zip.Item1.FindElements(_tableColumns).ElementAt(3).Text;
                zip.Item2.Salary = zip.Item1.FindElements(_tableColumns).ElementAt(4).Text.ToInteger(0);
                zip.Item2.Department = zip.Item1.FindElements(_tableColumns).ElementAt(5).Text;
                zip.Item2.EditId = zip.Item1.FindElement(_editElement).GetAttribute("id");
                zip.Item2.DeleteId = zip.Item1.FindElement(_deleteElement).GetAttribute("id");
            }
            return list;
        }
    }
}
