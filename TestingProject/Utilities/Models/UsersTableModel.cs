using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestingProject.Utilities.Models
{
    public class UsersTableModel
    {
        [JsonProperty("FirstName")]
        public string FirstName;

        [JsonProperty("LastName")]
        public string LastName;

        [JsonProperty("Age")]
        public int Age;

        [JsonProperty("Email")]
        public string Email;

        [JsonProperty("Salary")]
        public int Salary;

        [JsonProperty("Department")]
        public string Department;

        [JsonIgnore]
        public string? EditId;

        [JsonIgnore]
        public string? DeleteId;
    }
}
