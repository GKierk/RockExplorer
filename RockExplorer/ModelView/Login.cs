/*
 *Authors: Mohamad Kassem
 *Date: 10-05-2023
 */
namespace RockExplorer.ModelView
{
    public class Login
    {
        private bool IsLoggedIn;
        private Dictionary<string, string> userDatabase;

        public Login()
        {
            
            userDatabase = new Dictionary<string, string>
        {
            { "admin", "password123" },
            { "Gülsüm", "G123" },
            { "Gab", "Ga123" },
            { "Nur", "Nur123" },
            { "Momo", "Mo123" }
        };
        }

        public void PerformLogin(string username, string password)
        {
            
            bool isAuthenticated = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                IsLoggedIn = true;
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid username or password. Login failed.");
            }
        }

        public void Logout()
        {
            IsLoggedIn = false;
            Console.WriteLine("Logged out successfully.");
        }

        private bool AuthenticateUser(string username, string password)
        {
        
            if (userDatabase.ContainsKey(username))
            {
                string storedPassword = userDatabase[username];
                if (password == storedPassword)
                {
                    return true;
                }
            }

            return false;
        }
    }
}







