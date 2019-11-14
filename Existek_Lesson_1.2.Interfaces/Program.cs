using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

#if false
            var repos = new AnimalRepository();

            Cat cat = new Cat("Cat")
            {
                Name = "Hlops"
            };
            var fox = new Fox("Fix")
            {
                Name = "Bing"
            };

            //fox.Voice();
            repos.AddAnimal(cat);
            repos.AddAnimal(fox);
            var dog = new Dog("Хаскі")
            {
                Name = "Люсі",
                Age = 1
            };

            repos.AddAnimal(dog);
            Console.WriteLine(dog.Name);
            repos.VoiceAll(); 
#endif
            var helper = new ServiceHelper();

            var googleDrive = new GoogleDriveService();
            var oneDriveService = new OneDriveService();

            helper.AddService(googleDrive);
            helper.AddService(oneDriveService);
            helper.Upload("Lesson1.cs");
            helper.Download("Lesson2.cs");

            Console.ReadLine();
        }
    }
}
