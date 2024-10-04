namespace lab4
{
    public class Lab4
    {
        static void Main(string[] args)
        {
            Student Oleg = new("Олег Приколов", 13);
            Oleg.WriteInfo();

            ITStudent Alex = new("Алексей Иванов", 21, "Программирование");
            Alex.WriteInfo();

            Oleg.BecomeOlder();
            Console.WriteLine($"У студента {Oleg.returnStudentName} сегодня День Рождения! Ему исполняется {Oleg.Age}! \n");
            Oleg.WriteInfo();

            // Демонстрация переопределения ToString()
            Console.WriteLine(Oleg.ToString());

            // Демонстрация различия между переопределением и скрытием
            Alex.PrintInfo();
        }
    }

    // Абстрактный класс Person
    public abstract class Person
    {
        public abstract string Name { get; }
        public abstract void PrintInfo();
    }

    // Класс Student наследуется от абстрактного класса Person
    public class Student : Person
    {
        private string _name;
        public override string Name => _name;
        public int Age { get; private set; }

        public Student(string name)
        {
            this._name = name;
        }

        public Student(string name, int age)
        {
            this._name = name;
            this.Age = age;
        }

        public void BecomeOlder()
        {
            Age++;
        }

        public string returnStudentName
        {
            get => _name;
        }

        public void WriteInfo()
        {
            if (Age == 0)
            {
                Console.WriteLine($"Имя студента: {_name} \nВозраст студента: Неизвестен\n");
            }
            else
            {
                Console.WriteLine($"Имя студента: {_name} \nВозраст студента: {Age}\n");
            }
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return $"Student: {Name}, Age: {Age}";
        }

        // Переопределение метода PrintInfo()
        public override void PrintInfo()
        {
            Console.WriteLine($"Студент: {Name}, возраст: {Age}");
        }
    }

    // Производный класс ITStudent наследуется от Student
    public class ITStudent : Student
    {
        public string Specialization { get; private set; }

        public ITStudent(string name, int age, string specialization)
            : base(name, age)
        {
            Specialization = specialization;
        }

        // Скрытие метода PrintInfo
        public new void PrintInfo()
        {
            Console.WriteLine($"IT-студент: {Name}, возраст: {Age}, специализация: {Specialization}");
        }
    }
}
