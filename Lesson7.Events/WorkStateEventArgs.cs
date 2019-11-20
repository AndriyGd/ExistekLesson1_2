using System;

namespace Lesson7.Events
{
    public class WorkStateEventArgs : EventArgs
    {
        public int State { get; }
        public WorkStateEventArgs(int state)
        {
            State = state;
        }
    }
}
