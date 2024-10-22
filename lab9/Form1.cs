using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

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

        // Экспорт в XML
        private void ExportToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, students);
            }
        }

        // Импорт из XML
        private void ImportFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            using (StreamReader reader = new StreamReader(filePath))
            {
                students = (List<Student>)serializer.Deserialize(reader);
            }
        }

        // Экспорт в CSV
        private void ExportToCsv(string filePath)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("RecordBook,FullName,Department,Specification,DateOfAdmission,Group");

            foreach (var student in students)
            {
                csvContent.AppendLine($"{student.RecordBook},{student.FullName},{student.Department},{student.Specification},{student.DateOfAdmission.ToShortDateString()},{student.Group}");
            }

            File.WriteAllText(filePath, csvContent.ToString());
        }

        // Импорт из CSV
        private void ImportFromCsv(string filePath)
        {
            string[] csvLines = File.ReadAllLines(filePath);
            students.Clear();

            for (int i = 1; i < csvLines.Length; i++) // Пропускаем заголовок
            {
                string[] data = csvLines[i].Split(',');
                Student student = new Student
                {
                    RecordBook = data[0],
                    FullName = data[1],
                    Department = data[2],
                    Specification = data[3],
                    DateOfAdmission = DateTime.Parse(data[4]),
                    Group = data[5]
                };
                students.Add(student);
            }
        }

        // Экспорт в JSON
        private void ExportToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // Импорт из JSON
        private void ImportFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
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
        private bool ValidateRecordBook(string recordBook)
        {
            return Regex.IsMatch(recordBook, @"^\d{8}$");
        }

        private bool ValidateStudentInput(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(recordBookTextBox.Text))
            {
                errorMessage = "Номер зачетной книжки не может быть пустым.";
                return false;
            }
            if (!ValidateRecordBook(recordBookTextBox.Text))
            {
                errorMessage = "Номер зачетной книжки должен состоять из 8 цифр.";
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

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv|JSON files (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    if (filePath.EndsWith(".xml"))
                    {
                        ExportToXml(filePath);
                    }
                    else if (filePath.EndsWith(".csv"))
                    {
                        ExportToCsv(filePath);
                    }
                    else if (filePath.EndsWith(".json"))
                    {
                        ExportToJson(filePath);
                    }
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Все файлы (*.*)|*.*|XML files (*.xml)|*.xml|CSV files (*.csv)|*.csv|JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (filePath.EndsWith(".xml"))
                    {
                        ImportFromXml(filePath);
                    }
                    else if (filePath.EndsWith(".csv"))
                    {
                        ImportFromCsv(filePath);
                    }
                    else if (filePath.EndsWith(".json"))
                    {
                        ImportFromJson(filePath);
                    }
                }
            }
            UpdateDataGrid();
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

}
