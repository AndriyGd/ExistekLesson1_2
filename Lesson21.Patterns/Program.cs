using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21.Patterns
{
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main(string[] args)
        {
#if adapter
            var old = new OldElectricitySystem();
            var newSystem = new NewElectricitySystem();
            var adapter = new OldElectricitySystemAdapter(old);

            var charger = new Charger();
            charger.ChargeNotebook(newSystem);
            charger.ChargeNotebook(adapter); 
#endif

#if Decorator
            var t = new Tesla();
            var m = new Mersedes();
            var ambulance = new AmbulanceCar(m);

            CarHelper(t);
            CarHelper(m);
            CarHelper(ambulance); 
#endif
            var emp = new Employee{Name = "Petro"};
            var csv = new CsvReportGenerator();
            var pdf = new PdfReportGenerator();

            var reporter = new ReportGenerator(pdf);
            reporter.GenerateReport(emp);

            Console.ReadLine();
        }

        static void CarHelper(Car car)
        {
            Console.WriteLine(car.Brand);
            car.Go();
        }

        static void Generate(ReportGenerator generator, Employee employee)
        {
            generator.GenerateReport(employee);
        }

        static void Generate(IReportGenerator generator, Employee employee)
        {
            generator.GenerateReport(employee);
        }
    }

    #region Adapter
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return $"220 V";
        }
    }

    class OldElectricitySystem
    {
        public string ThinSocket()
        {
            return "220 V";
        }
    }

    class OldElectricitySystemAdapter : INewElectricitySystem
    {
        private readonly OldElectricitySystem _oldElectricitySystem;

        public OldElectricitySystemAdapter(OldElectricitySystem oldElectricitySystem)
        {
            _oldElectricitySystem = oldElectricitySystem;
        }

        public string MatchWideSocket()
        {
            return _oldElectricitySystem.ThinSocket();
        }
    }

    class Charger
    {
        public void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }
    #endregion

    #region MyRegion
    abstract class Car
    {
        public virtual string Brand { get; set; }

        public virtual void Go()
        {
            Console.WriteLine($"I'm {Brand} and I'm on my way...");
        }
    }

    class Mersedes : Car
    {
        public Mersedes()
        {
            Brand = "Mersedes X300";
        }
    }

    class Tesla : Car
    {
        public Tesla()
        {
            Brand = "Tesla Model X";
        }
    }

    abstract class DecoratorCar : Car
    {
        protected readonly Car Car;

        protected DecoratorCar(Car car)
        {
            Car = car;
        }

        public override void Go()
        {
            Car.Go();
        }
    }

    class AmbulanceCar : DecoratorCar
    {
        public override string Brand
        {
            get => $"{Car.Brand} AMBULANCE";
            set => Car.Brand = value;
        }

        public AmbulanceCar(Car car) : base(car)
        {
        }

        public override void Go()
        {
            base.Go();

            //Additional functionality
            Console.WriteLine("beeeb-beeb-beeb...");
        }
    } 
    #endregion

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Bad practice
        public void GenerateReport()
        {
            //Generate report to CSV
        }
    }

    interface IReportGenerator
    {
        void GenerateReport(Employee employee);
    }

    class CsvReportGenerator: IReportGenerator
    {
        public void GenerateReport(Employee employee)
        {
            Console.WriteLine("CSV Report");
        }
    }

    class PdfReportGenerator: IReportGenerator
    {
        public void GenerateReport(Employee employee)
        {
            Console.WriteLine("PDF Report");
        }
    }

    class ReportGenerator
    {
        private readonly IReportGenerator _reportGenerator;
        public string ReportType { get; set; }


        //Dependency injection
        public ReportGenerator(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
            ReportType = "CSV";
        }

        public void GenerateReport(Employee employee)
        {
            _reportGenerator.GenerateReport(employee);

            //switch (ReportType)
            //{
            //    case "CSV": 
            //        break;
            //    case "PDF":
            //        break;
            //}
        }
    }
}
