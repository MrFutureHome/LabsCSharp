namespace lab5
{
    public class Lab5
    {
        static void Main(string[] args)
        {
            Student Oleg = new("Олег Приколов", 13, new Subject("Математика"));
            Oleg.WriteInfo();

            ITStudent Alex = new("Алексей Иванов", 21, "Программирование", new Subject("Информатика"));
            Alex.WriteInfo();

            // Клонирование студента
            Student clonedOleg = (Student)Oleg.Clone();
            Console.WriteLine($"Клонированный студент: {clonedOleg}");

            // Сравнение студентов
            int comparison = Oleg.CompareTo(Alex);
            Console.WriteLine(comparison > 0 ? "Олег старше" : comparison < 0 ? "Алексей старше" : "Олег и Алексей одного возраста");

            // Явная реализация интерфейса ISpecialist
            ((ISpecialist)Alex).Specialize();
        }
    }

    // Интерфейс IPerson
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        void PrintInfo();
    }

    // Интерфейс ISpecialist, производный от IPerson
    public interface ISpecialist : IPerson
    {
        string Specialization { get; }
        void Specialize();
    }

    // Класс Subject для любимого предмета
    public class Subject
    {
        public string SubjectName { get; set; }

        public Subject(string subjectName)
        {
            SubjectName = subjectName;
        }
    }

    // Класс Student реализует интерфейсы IPerson, ICloneable и IComparable
    public class Student : IPerson, ICloneable, IComparable<Student>
    {
        private string _name;
        public string Name => _name;
        public int Age { get; private set; }
        public Subject FavoriteSubject { get; private set; }

        public Student(string name, int age, Subject favoriteSubject)
        {
            this._name = name;
            this.Age = age;
            this.FavoriteSubject = favoriteSubject;
        }

        public void BecomeOlder()
        {
            Age++;
        }

        public string returnStudentName => _name;

        public void WriteInfo()
        {
            Console.WriteLine($"Имя студента: {_name}\nВозраст студента: {Age}\nЛюбимый предмет: {FavoriteSubject.SubjectName}\n");
        }

        // Переопределение метода ToString()
        public override string ToString()
        {
            return $"Имя: {Name}, Возраст: {Age}, Любимый предмет: {FavoriteSubject.SubjectName}";
        }

        // Реализация интерфейса ICloneable
        public object Clone()
        {
            return new Student(this._name, this.Age, new Subject(this.FavoriteSubject.SubjectName));
        }

        // Реализация интерфейса IComparable
        public int CompareTo(Student other)
        {
            return this.Age.CompareTo(other.Age);
        }

        // Реализация метода PrintInfo из интерфейса IPerson
        public void PrintInfo()
        {
            Console.WriteLine($"Студент: {Name}, возраст: {Age}");
        }
    }

    // Класс ITStudent реализует интерфейсы IPerson и ISpecialist
    public class ITStudent : Student, ISpecialist
    {
        public string Specialization { get; private set; }

        public ITStudent(string name, int age, string specialization, Subject favoriteSubject)
            : base(name, age, favoriteSubject)
        {
            Specialization = specialization;
        }

        // Явная реализация метода Specialize из интерфейса ISpecialist
        void ISpecialist.Specialize()
        {
            Console.WriteLine($"{Name} специализируется на {Specialization}.");
        }

        // Скрытие метода PrintInfo
        public new void PrintInfo()
        {
            Console.WriteLine($"IT-студент: {Name}, возраст: {Age}, специализация: {Specialization}, любимый предмет: {FavoriteSubject.SubjectName}");
        }
    }
}
