namespace Lesson19.Patterns.SingletonModels
{
    public class ManagerSingleton
    {
        public static ManagerSingleton Instance { get; set; }

        public Manager Manager { get; }

        private ManagerSingleton()
        {
            //TODO read credentials from config file
            Manager = new Repository().Login("Viktor", "121212");
        }

        static ManagerSingleton()
        {
            Instance = new ManagerSingleton();
        }
    }
}
    