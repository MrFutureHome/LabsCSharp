namespace lab2
{
    public class Lab2
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Сейчас я продемонстрирую вам, что усвоил тему данной лабы\n");
            Console.ResetColor();

            Student Oleg = new("Олег Приколов", 13);
            Oleg.FavoriteGame = new("Sonic Adventure", 1999, "Sonic Team");
            Oleg.FavoriteSubject = new("Основы веб-программирования");
            Oleg.WriteInfo();

            Student Masha = new("Мария Цареградцева");
            Masha.WriteInfo();
            Masha.FavoriteGame = new("Sonic Generations", 2011, "Sonic Team");
            Masha.FavoriteSubject = new("Математика");

            Oleg.BecomeOlder();
            Console.WriteLine($"У студента {Oleg.returnStudentName} сегодня День Рождения! Ему исполняется {Oleg.Age}! \n");
            Oleg.WriteInfo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Теперь к вопросам второй лабы\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;

            Oleg.returnFavoriteGame();
            Oleg.returnFavoriteSubject();

            Masha.returnFavoriteGame();
            Masha.returnFavoriteSubject();

            Console.ResetColor();

            //Game SonicAdventure = new("Sonic Adventure", 1999, "Sonic Team");
            //Game SonicGenerations = new("Sonic Generations", 2011, "Sonic Team");
            //Game SonicHeroes = new("Sonic Heroes", 2004, "Sonic Team");
            //Game SonicRiders = new("Sonic Riders", 2006, "Sonic Team");


        }

        class Student
        {
            private string _name { get; set; }

            /* Если здесь прямо сейчас я напишу функцию 
            public int Age { get; }
            тем самым сделав переменную Read-only, я не смогу обратиться к ней из собственного класса

            придётся использовать "костыль" для доступа к объекту:

            private int age;
            public int Age { get { return age; } }

            поэтому можно просто написать 

            public int Age { get; private set; }

            как то так и работает модификатор private :)
            
            */

            public int Age { get; private set; }

            public Student(string _name)
            {
                this._name = _name;
            }

            public Student(string _name, int Age)
            {
                this._name = _name;
                this.Age = Age;
            }

            //Методы возвращающие любимые игру и предмет студента

            public Subject FavoriteSubject { get; set; }
            public Game FavoriteGame { get; set; }

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
                    Console.WriteLine($"Имя студента: {_name} \n" +
                    $"Возраст студента: Неизвестен \n");
                }

                else
                {
                    Console.WriteLine($"Имя студента: {_name} \n" +
                    $"Возраст студента: {Age} \n");
                }
            }

            public void returnFavoriteGame()
            {
                Console.WriteLine($"Любимая игра студента {_name} - {FavoriteGame.gameName}\n" +
                    $"Год релиза: {FavoriteGame.yearOfRelease}\n" +
                    $"Разработчик: {FavoriteGame.developerName}\n");
            }

            public void returnFavoriteSubject()
            {
                Console.WriteLine($"Любимая предмет студента {_name} - {FavoriteSubject.subjectName}\n");
            }
        }

        class Subject
        {
            public string subjectName { get; private set; }

            public Subject(string subjectName)
            {
                this.subjectName = subjectName;
            }
        }

        //создаём новый класс Game
        class Game
        {
            public string gameName { get; set; }
            public int yearOfRelease { get; private set; }
            public string? developerName { get; set; }

            //используем 2 конструктора, чтобы сделать поле developerName необязательным

            public Game(string gameName, int yearOfRelease, string developerName) 
            { 
                this.gameName = gameName;
                this.yearOfRelease = yearOfRelease;
                this.developerName = developerName;
            }

            public Game(string gameName, int yearOfRelease)
            {
                this.gameName = gameName;
                this.yearOfRelease = yearOfRelease;
            }

        }
        
    }
}
