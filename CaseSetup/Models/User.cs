namespace CaseSetup.Models
{
    public class User
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private bool IsTeacher { get; set; }
        public User(string username, string password, bool isTeacher)
        {
            Username = username;
            Password = password;
            IsTeacher = isTeacher;
        }
    }
}
