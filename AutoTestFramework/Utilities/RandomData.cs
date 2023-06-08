namespace TestingProject.Utilities
{
    public static class RandomData
    {
        private static Random s_random = new Random();

        public static string GetRandomString(int length) 
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[s_random.Next(s.Length)]).ToArray());
        }
    }
}
