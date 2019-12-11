using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsForms16.AsyncAwait
{
    using System.Diagnostics;

    public partial class Form1 : Form
    {
        private readonly List<Employee> _employees;
        public Form1()
        {
            InitializeComponent();

            _employees = new List<Employee>();
            LoadData();
        }

        private void LoadData()
        {
            for (int i = 0; i < 200; i++)
            {
                _employees.Add(new Employee{Name = $"Emp_{i}"});
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"button1_Click Id: {Thread.CurrentThread.ManagedThreadId}\n");
            var p = new Param();
            for (int i = 0; i < 100; i++)
            {
                //await Increment();
                //progressBar1.Value++;

                //var value = await Increment(progressBar1.Value);
                //progressBar1.Value = value;

                Inc(p);
                progressBar1.Value = p.Value;
            }

            MessageBox.Show("End work");
        }

        private async Task Increment() //повертає void
        {
            //await Task.Run(() => Thread.Sleep(200));
            //return ++sourceValue;

            await Del();
            Text = DateTime.Now.ToString();
            await Task.Run(() =>
            {
                Thread.Sleep(100);
                //Text = DateTime.Now.ToString();
            });
        }

        private async Task Del()
        {
            await Task.Run(() => Delay());
        }

        private async Task<int> Increment(int sourceValue)
        {
            await Del();
            return ++sourceValue;
        }

        private async void Inc(Param param)
        {
            await Del();
            param.Value++;
        }

        private void Delay()
        {
            Debug.WriteLine($"Delay Id: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(200);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Marquee;
            var res = Parallel.ForEach(_employees, (employee, state, arg3) =>
            {
                employee.Work((int)arg3);
            });

            if (res.IsCompleted)
            {
                Debug.WriteLine($"Total sum = {_employees.Sum(em => em.Sum)}");
                progressBar1.Style = ProgressBarStyle.Blocks;
            }
        }
    }

    class Param
    {
        public int Value { get; set; }
    }

    class Employee
    {
        public string Name { get; set; }
        public long Sum { get; set; }

        public void Work(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Sum += i;
            }

           // Debug.WriteLine(Sum);
        }
    }
}
