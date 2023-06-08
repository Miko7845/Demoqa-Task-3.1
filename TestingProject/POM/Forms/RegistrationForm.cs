using AutoTestFramework.BaseEntity.Elements;
using AutoTestFramework.BaseEntity.Pages;
using OpenQA.Selenium;
using TestingProject.Utilities.Models;

namespace TestingProject.POM.Forms
{
    public class RegistrationForm : BaseForm
    {
        private TextBox _firstNameField = new TextBox(By.XPath("//input[@id='firstName']"), "First Name TextBox");
        private TextBox _lastNameField = new TextBox(By.XPath("//input[@id='lastName']"), "Last Name TextBox");
        private TextBox _emailField = new TextBox(By.XPath("//input[@id='userEmail']"), "Email TextBox");
        private TextBox _ageField = new TextBox(By.XPath("//input[@id='age']"), "Age TextBox");
        private TextBox _salaryField = new TextBox(By.XPath("//input[@id='salary']"), "Salary TextBox");
        private TextBox _departmentField = new TextBox(By.XPath("//input[@id='department']"), "Department TextBox");
        private Button _submitButton = new Button(By.Id("submit"), "Add Button");

        public RegistrationForm() : base(By.Id("userForm"), "Registration form") { }

        public void SetFirstName(string firstName) => _firstNameField.SetText(firstName);
        public void SetLastName(string lastName) => _lastNameField.SetText(lastName);
        public void SetEmail(string email) => _emailField.SetText(email);
        public void SetAge(string age) => _ageField.SetText(age);
        public void SetSalary(string salary) => _salaryField.SetText(salary);
        public void SetDepartment(string department) => _departmentField.SetText(department);
        public void SubmitButtonClick() => _submitButton.Click();

        public void EnterUserData(UsersTableModel user)
        {
            SetFirstName(user.FirstName);
            SetLastName(user.LastName);
            SetEmail(user.Email);
            SetAge(user.Age.ToString());
            SetSalary(user.Salary.ToString());
            SetDepartment(user.Department);
            SubmitButtonClick();
        }
    }
}
