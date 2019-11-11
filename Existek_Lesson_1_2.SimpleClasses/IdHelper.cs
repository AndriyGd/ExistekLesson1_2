namespace Existek_Lesson_1_2.SimpleClasses
{
    class IdHelper
    {
        private static int _idCounter;

        public static int GetNextId()
        {
            return ++_idCounter;
        }
    }
}