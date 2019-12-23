using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson20.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

#if false
            var cappuccino1 = new Food(new List<string> { "Coffee", "Milk", "Sugar" }, "Cappuccino");
            var cappuccino2 = new Food(new List<string> { "Coffee", "Milk" }, "Cappuccino");

            var soup1 = new Food(new List<string> { "Meat", "Water", "Potato" }, "Soup with meat");
            var soup2 = new Food(new List<string> { "Water", "Potato" }, "Soup with potato");

            var meat = new Food(new List<string> { "Meat" }, "Meat");

            var girlFriend = new GirlFriend(null);
            var me = new Me(girlFriend);
            var bestFriend = new BestFriend(me);

            bestFriend.HandleFood(cappuccino1);
            bestFriend.HandleFood(cappuccino2);
            bestFriend.HandleFood(soup1);
            bestFriend.HandleFood(soup2);
            bestFriend.HandleFood(meat); 
#endif
            var boxFight = new BoxFight();

            var risky = new RiskyPlayer();
            var conservative = new ConservativePlayer();

            boxFight.AttachObserver(risky);
            boxFight.AttachObserver(conservative);

            boxFight.NextRound();
            boxFight.NextRound();
            boxFight.NextRound();
            boxFight.NextRound();
            boxFight.NextRound();

            Console.ReadLine();
        }
    }

    interface ISubject
    {
        int BoxerAScore { get; }
        int BoxerBScore { get; }

        void AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);
        void Notify();
    }

    interface IObserver
    {
        void Update(ISubject subject);
    }

    class BoxFight : ISubject
    {
        private readonly List<IObserver> _observers;
        private readonly Random _random;

        public int RoundNumber { get; private set; }

        public int BoxerAScore { get; private set; }
        public int BoxerBScore { get; private set; }

        public BoxFight()
        {
            _observers = new List<IObserver>();
            _random = new Random();
        }

        public void AttachObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void DetachObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NextRound()
        {
            RoundNumber++;

            BoxerAScore += _random.Next(0, 5);
            BoxerBScore += _random.Next(0, 5);

            Notify();
        }

        public void Notify()
        {
            _observers.ForEach(o => o.Update(this));
        }
    }

    class RiskyPlayer : IObserver
    {
        public string BoxerToPutMoneyOn { get; set; }

        public void Update(ISubject subject)
        {
            if (subject.BoxerAScore > subject.BoxerBScore)
            {
                BoxerToPutMoneyOn = "I put on boxer B, if he win I get more!";
            }
            else
            {
                BoxerToPutMoneyOn = "I put on boxer A, if he win I get more!";
            }

            Console.WriteLine($"RISKYPLAER: {BoxerToPutMoneyOn}");
        }
    }

    class ConservativePlayer : IObserver
    {
        public string BoxerToPutMoneyOn { get; set; }

        public void Update(ISubject subject)
        {
            if (subject.BoxerAScore < subject.BoxerBScore)
            {
                BoxerToPutMoneyOn = "I put on boxer B, if he win I get more!";
            }
            else
            {
                BoxerToPutMoneyOn = "I put on boxer A, if he win I get more!";
            }

            Console.WriteLine($"CONSERVATIVEPAYER:  {BoxerToPutMoneyOn}");
        }
    }

    class Food
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }

        public Food(List<string> ingredients, string name)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }

    class WierdCafeVisitor
    {
        private readonly WierdCafeVisitor _nextCafeVisitor;
        public WierdCafeVisitor(WierdCafeVisitor nextCafeVisitor)
        {
            _nextCafeVisitor = nextCafeVisitor;
        }

        public virtual void HandleFood(Food food)
        {
            _nextCafeVisitor?.HandleFood(food);
        }
    }

    class GirlFriend : WierdCafeVisitor
    {
        public GirlFriend(WierdCafeVisitor nextCafeVisitor) : base(nextCafeVisitor)
        {            
        }

        public override void HandleFood(Food food)
        {
            if (food.Name == "Cappuccino")
            {
                Console.WriteLine("GirlFriend: My lovely cappuccino!");
                return;
            }
            base.HandleFood(food);
        }
    }

    class BestFriend: WierdCafeVisitor
    {
        private List<Food> _foodsContainCoffee;

        public BestFriend(WierdCafeVisitor nextCafeVisitor) : base(nextCafeVisitor)
        {
            _foodsContainCoffee = new List<Food>();
        }

        public override void HandleFood(Food food)
        {
            if (food.Ingredients.Contains("Meat"))
            {
                Console.WriteLine($"BestFriend: I just eat {food.Name}. It was testy.");
                return;
            }
            if (food.Ingredients.Contains("Coffee") && _foodsContainCoffee.Count == 0)
            {
                _foodsContainCoffee.Add(food);
                Console.WriteLine($"BestFriend: I have to take something with coffee. {food.Name} looks fine.");
                return;
            }
            base.HandleFood(food);
        }
    }

    class Me : WierdCafeVisitor
    {
        public Me(WierdCafeVisitor nextCafeVisitor) : base(nextCafeVisitor)
        {
        }

        public override void HandleFood(Food food)
        {
            if (food.Name.Contains("Soup"))
            {
                Console.WriteLine("Me: I like soup. I went well.");
                return;
            }
            base.HandleFood(food);
        }
    }
}
