namespace lab3
{
    public class Lab3
    {
        static void Main(string[] args)
        {
            Student Oleg = new("Олег Приколов", 13);
            Oleg.WriteInfo();

            Student Masha = new("Мария Цареградцева");
            Masha.WriteInfo();

            Oleg.BecomeOlder();
            Console.WriteLine($"У студента {Oleg.returnStudentName} сегодня День Рождения! Ему исполняется {Oleg.Age}! \n");
            Oleg.WriteInfo();
        }

        class Student
        {
            private string _name { get; set; }

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

        }
    }
}
