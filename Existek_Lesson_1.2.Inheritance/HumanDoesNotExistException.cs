using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Existek_Lesson_1._2.Inheritance
{
    public class HumanDoesNotExistException : ApplicationException
    {
        private readonly string _message;

        public HumanDoesNotExistException()
        {
            
        }

        public HumanDoesNotExistException(int humanId)
        {
            _message = $"Human by id '{humanId}' does not exist!\nPlease create the Human.";
        }

        public override string Message => !string.IsNullOrWhiteSpace(_message)
            ? _message
            : base.Message;
    }
}
