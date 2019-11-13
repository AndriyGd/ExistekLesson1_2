using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance.Common
{
    using Existek_Lesson_1_2.ExCommon;

    public class Human
    {
        #region Class Fields

        private int _age;
        #endregion

        #region Calss Properties

        public int Id { get; }
        public string Name { get; set; }
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException();
                _age = value;
            }
        } 
        #endregion

        public Human()
        {
            Console.WriteLine("Call Human Constructor");
            Id = IdHelper.GetNextId();
        }
    }
}
