using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson7.Events
{
    public delegate void StartWorkEventHandler(string personName);
    public delegate void WorkingEventHandler(object sender, WorkStateEventArgs e);
    public class Person
    {
        public string Name { get; }
        public event Action EndWork;
        public event StartWorkEventHandler WorkStarted;
        public event WorkingEventHandler Working;

        public Person(string name)
        {
            WorkStarted += personName => { };
            Name = name;
        }

        public void StartWork(object n)
        {
            if (!(n is int number)) return;
            OnWorkStarted();

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"I = {i}");
                OnWorking(i);
                Thread.Sleep(500);
            }

            OnEndWork();
        }

        protected virtual void OnWorkStarted()
        {
            WorkStarted(Name);
        }

        protected virtual void OnEndWork()
        {
            EndWork?.Invoke();
        }

        protected virtual void OnWorking(int state)
        {
            Working?.Invoke(this, new WorkStateEventArgs(state));
        }
    }
}
