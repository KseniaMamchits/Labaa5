using System;

namespace Laba5
{
    //Испытание, Тест, Экзамен, Выпускной экзамен, Вопрос;

    interface ITest//испытание
    {
        void Move();
    }

    abstract class Exam
    {
        protected string Name;
        protected byte Mark;

        public Exam (string Name, byte Mark)
        {
            this.Name = Name;
            this.Mark = Mark;
        }

        public abstract void Move();
    }

    class FinalExam : Exam
    {
        string specialty;

        public FinalExam(string specialty, string Name, byte Mark) : base(Name, Mark)
        {
            this.specialty = specialty;
        }

        public override void Move()
        {
            Console.WriteLine("Выпускной экзамены для специальности "+specialty+": "+Name+". Проходной балл: "+Mark);
        }
    }

    public class Test : ITest
    {
        private string v;

        public Test(string v)
        {
            this.v = v;
        }

        public void Move()
        {
            Console.WriteLine("Тест по CorelDraw: ");
        }

        public override bool Equals(object obj)
        {
            if (obj == "-") // проверка
            {
                Console.WriteLine("Что-то не так");
                return false;
            }

            if (obj != "-")
            {
                Console.WriteLine("Тест сдан.");
                return true;
            }

            Console.WriteLine("Нет теста!");
            return false;
        }
        public override int GetHashCode()
        {
            return 444;
        }
    }

    sealed class Question: ITest
    {
        string answer;
        public Question(string answer)
        {
            this.answer = answer;
        }
        public void Move()
        {
            Console.WriteLine("Студент работает? "+answer);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            FinalExam spec1 = new FinalExam("ИСИТ", "Математика", 5);
            spec1.Move();
            FinalExam spec2 = new FinalExam("ПОИТ", "Физическая культура", 10);
            spec2.Move();
            Console.WriteLine("Иванов Иван");
            Question quest = new Question("Да, я работаю в ресторане быстрого питания");
            quest.Move();
            Console.WriteLine("Писали тест по CorelDraw?");
            Test test1 = new Test("+");
            test1.Move();
            test1.Equals("+");
        }
    }
}
