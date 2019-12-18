namespace Lesson19.Patterns.SingletonModels
{
    using System.Security.Authentication;

    public class Repository
    {
        public Manager Login(string name, string password)
        {
            if(name != "Viktor" && password != "121212") throw new InvalidCredentialException();

            return new Manager{Name = "Viktor", Password = "121212", ManagerId = 23};
        }
    }
}
