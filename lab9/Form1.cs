using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab9
{
    public partial class Form1 : Form
    {
        private List<Student> students;
        private List<Department> departments;
        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
            UpdateDataGrid();
            InitDepartments();
        }

        public class Department
        {
            public string DepartmentName { get; set; }
            public List<Specification> Specifications { get; set; }

            public Department(string departmentName, List<Specification> specifications)
            {
                DepartmentName = departmentName;
                Specifications = specifications;
            }
        }

        public class Specification
        {
            public string SpecificationName { get; set; }

            public Specification(string specificationName)
            {
                SpecificationName = specificationName;
            }
        }

        public class Student
        {
            public string RecordBook { get; set; }
            public string FullName { get; set; }
            public string Department { get; set; }
            public string Specification { get; set; }
            public DateTime DateOfAdmission { get; set; }
            public string Group { get; set; }
        }

        private void InitDepartments()
        {
            // Создаем список отделов
            departments = new List<Department>
            {
                new Department("Институт информационных технологий", new List<Specification>
                {
                    new Specification("Программирование"),
                    new Specification("Кибербезопасность"),
                    new Specification("Искусственный интеллект")
                }),
                new Department("Институт экономики и управления", new List<Specification>
                {
                    new Specification("Экономика"),
                    new Specification("Менеджмент"),
                    new Specification("Бухгалтерский учет")
                }),
                new Department("Институт естественных наук", new List<Specification>
                {
                    new Specification("Биология"),
                    new Specification("Химия"),
                    new Specification("Экология")
                })
            };

            // Заполняем ComboBox для институтов
            departmentComboBox.Items.Clear();
            foreach (var department in departments)
            {
                departmentComboBox.Items.Add(department.DepartmentName);
            }

            // Событие на изменение института, чтобы обновить список направлений
            departmentComboBox.SelectedIndexChanged += departmentComboBox_SelectedIndexChanged;
        }

        private void UpdateDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var student in students)
            {
                dataGridView1.Rows.Add(student.RecordBook, student.FullName, student.Department, student.Specification, student.DateOfAdmission.ToShortDateString(), student.Group);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var student = new Student
            {
                RecordBook = recordBookTextBox.Text,
                FullName = fullNameTextBox.Text,
                Department = departmentComboBox.Text,
                Specification = specificationComboBox.Text,
                DateOfAdmission = dateTimePicker1.Value,
                Group = groupTextBox.Text
            };

            if (students.Exists(s => s.RecordBook == student.RecordBook))
            {
                MessageBox.Show("Студент с таким номером зачетной книжки уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            students.Add(student);
            UpdateDataGrid();
            ClearInputFields();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                students.RemoveAt(index);
                UpdateDataGrid();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                if (!ValidateStudentInput(out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var student = students[index];
                student.RecordBook = recordBookTextBox.Text;
                student.FullName = fullNameTextBox.Text;
                student.Department = departmentComboBox.Text;
                student.Specification = specificationComboBox.Text;
                student.DateOfAdmission = dateTimePicker1.Value;
                student.Group = groupTextBox.Text;

                UpdateDataGrid();
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            recordBookTextBox.Clear();
            fullNameTextBox.Clear();
            departmentComboBox.SelectedIndex = -1;
            specificationComboBox.Items.Clear();
            dateTimePicker1.Value = DateTime.Now;
            groupTextBox.Clear();
        }

        private bool ValidateStudentInput(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(recordBookTextBox.Text))
            {
                errorMessage = "Номер зачетной книжки не может быть пустым.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                errorMessage = "ФИО студента не может быть пустым.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(departmentComboBox.Text))
            {
                errorMessage = "Выберите институт.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(specificationComboBox.Text))
            {
                errorMessage = "Выберите направление.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(groupTextBox.Text))
            {
                errorMessage = "Поле группы не может быть пустым.";
                return false;
            }

            errorMessage = null;
            return true;
        }

        private void departmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            specificationComboBox.Items.Clear();

            if (departmentComboBox.SelectedIndex != -1)
            {
                var selectedDepartment = departments[departmentComboBox.SelectedIndex];
                foreach (var spec in selectedDepartment.Specifications)
                {
                    specificationComboBox.Items.Add(spec.SpecificationName);
                }
            }
        }
    }

}
