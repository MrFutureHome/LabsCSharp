using System;

namespace lab6
{
    public class Lab6
    {
        static void Main(string[] args)
        {
            try
            {
                Student Oleg = new("Олег Приколов", -5); // Это вызовет исключение
                Oleg.WriteInfo();
            }
            catch (ArgumentException ex) when (ex.Message.Contains("недопустимый возраст"))
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

            try
            {
                Student Alex = new("Алексей Иванов", 21);
                Alex.BecomeOlder();
                Alex.WriteInfo();

                // Проверка исключения при установке неверного предмета
                Alex.SetFavoriteSubject("");
            }
            catch (ArgumentException ex) when (ex.Message.Contains("название предмета"))
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }

    public class Student
    {
        private string _name;
        private int _age;
        public string Name => _name;
        public int Age => _age;
        public Subject FavoriteSubject { get; private set; }

        public Student(string name, int age)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.");
            this._name = name;
            this._age = age;
            FavoriteSubject = new Subject("Неизвестно");
        }

        public void BecomeOlder()
        {
            _age++;
        }

        public void WriteInfo()
        {
            Console.WriteLine($"Имя студента: {_name}\nВозраст студента: {_age}\nЛюбимый предмет: {FavoriteSubject.SubjectName}\n");
        }

        public void SetFavoriteSubject(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Название предмета не может быть пустым.");
            FavoriteSubject = new Subject(subjectName);
        }
    }

    public class Subject
    {
        public string SubjectName { get; set; }

        public Subject(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                throw new ArgumentException("Название предмета не может быть пустым.");
            SubjectName = subjectName;
        }
    }
}
