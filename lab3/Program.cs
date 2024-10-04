namespace lab3
{
    public class Lab3
    {
        static void Main(string[] args)
        {
            // Использование инициализатора для создания объекта
            Student Oleg = new Student { Name = "Олег Приколов", Age = 13 };
            Oleg.WriteInfo();

            // Использование конструктора с двумя параметрами
            Student Masha = new("Мария Цареградцева", 20);
            Masha.WriteInfo();

            // Создание объекта с использованием статического поля
            Console.WriteLine($"Количество студентов: {Student.StudentCount}");

            // Использование статического метода
            Student.DisplayTotalStudents();

            // Создание объекта с инициализатором
            Student Ivan = new Student { Name = "Иван Иванов", Age = 18 };
            Ivan.WriteInfo();

            // Использование конструктора по умолчанию
            Student studentWithDefaultValues = new Student();
            studentWithDefaultValues.WriteInfo();
        }
    }

    public class Student
    {
        // Закрытое поле
        private string _name;

        // Публичные свойства
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Age { get; set; }

        // Статическое поле для подсчета количества студентов
        public static int StudentCount { get; private set; }

        // Статический конструктор для инициализации статического поля
        static Student()
        {
            StudentCount = 0;
        }

        // Конструктор по умолчанию
        public Student()
        {
            _name = "Неизвестный студент";
            Age = 0;
            StudentCount++;
        }

        // Конструктор с одним параметром
        public Student(string name)
        {
            _name = name;
            Age = 0;
            StudentCount++;
        }

        // Конструктор с двумя параметрами
        public Student(string name, int age)
        {
            _name = name;
            Age = age;
            StudentCount++;
        }

        // Статический метод для вывода информации о количестве студентов
        public static void DisplayTotalStudents()
        {
            Console.WriteLine($"Общее количество студентов: {StudentCount}");
        }

        // Деструктор (финализатор)
        ~Student()
        {
            Console.WriteLine($"Студент {_name} удален из памяти.");
        }

        // Метод для вывода информации о студенте
        public void WriteInfo()
        {
            Console.WriteLine($"Имя студента: {_name}\nВозраст студента: {Age}\n");
        }
    }
}

