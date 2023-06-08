using AutoTestFramework.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TestingProject.Utilities.Models;

namespace TestingProject.Utilities
{
    public static class TestDataManager
    {
        private static readonly string s_userDataPath = Path.Combine(Directory.GetCurrentDirectory()) + @"\Utilities\Files\Users.json";
        private static readonly string s_testDataPath = Path.Combine(Directory.GetCurrentDirectory()) + @"\Utilities\Files\TestData.json";

        public static List<UsersTableModel> GetUsersDataFromJson()
        {
            try
            {
                return JsonConvert.DeserializeObject<List<UsersTableModel>>(File.ReadAllText(s_userDataPath));
            }
            catch (System.Exception e)
            {
                Log.Error(e, "Users data deserialize");
                throw;
            }
            
        }

        public static TestDataModel GetTestDataFromJson()
        {
            try
            {
                return JsonConvert.DeserializeObject<TestDataModel>(File.ReadAllText(s_testDataPath));
            }
            catch (System.Exception e)
            {
                Log.Error(e, "Test data deserialize");
                throw;
            }
            
        }
    }
}
