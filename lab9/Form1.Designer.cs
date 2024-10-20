namespace lab9
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RecordBookColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecificationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfAdmissionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.specificationComboBox = new System.Windows.Forms.ComboBox();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.recordBookTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RecordBookColumn,
            this.StudentNameColumn,
            this.DepartmentColumn,
            this.SpecificationColumn,
            this.DateOfAdmissionColumn,
            this.GroupColumn});
            this.dataGridView1.Location = new System.Drawing.Point(16, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1550, 731);
            this.dataGridView1.TabIndex = 0;
            // 
            // RecordBookColumn
            // 
            this.RecordBookColumn.HeaderText = "№ зачётной книжки";
            this.RecordBookColumn.MinimumWidth = 6;
            this.RecordBookColumn.Name = "RecordBookColumn";
            // 
            // StudentNameColumn
            // 
            this.StudentNameColumn.HeaderText = "ФИО студента";
            this.StudentNameColumn.MinimumWidth = 6;
            this.StudentNameColumn.Name = "StudentNameColumn";
            // 
            // DepartmentColumn
            // 
            this.DepartmentColumn.HeaderText = "Отдел";
            this.DepartmentColumn.MinimumWidth = 6;
            this.DepartmentColumn.Name = "DepartmentColumn";
            // 
            // SpecificationColumn
            // 
            this.SpecificationColumn.HeaderText = "Направление подготовки";
            this.SpecificationColumn.MinimumWidth = 6;
            this.SpecificationColumn.Name = "SpecificationColumn";
            // 
            // DateOfAdmissionColumn
            // 
            this.DateOfAdmissionColumn.HeaderText = "Дата зачисления";
            this.DateOfAdmissionColumn.MinimumWidth = 6;
            this.DateOfAdmissionColumn.Name = "DateOfAdmissionColumn";
            // 
            // GroupColumn
            // 
            this.GroupColumn.HeaderText = "Группа";
            this.GroupColumn.MinimumWidth = 6;
            this.GroupColumn.Name = "GroupColumn";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupTextBox);
            this.groupBox1.Controls.Add(this.specificationComboBox);
            this.groupBox1.Controls.Add(this.departmentComboBox);
            this.groupBox1.Controls.Add(this.fullNameTextBox);
            this.groupBox1.Controls.Add(this.recordBookTextBox);
            this.groupBox1.Location = new System.Drawing.Point(16, 777);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1304, 228);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editButton.Location = new System.Drawing.Point(1167, 96);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.MaximumSize = new System.Drawing.Size(151, 57);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(118, 57);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.Location = new System.Drawing.Point(1167, 162);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.MaximumSize = new System.Drawing.Size(151, 57);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(118, 57);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addButton.Location = new System.Drawing.Point(1167, 32);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.MaximumSize = new System.Drawing.Size(151, 57);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 57);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(747, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Дата зачисления";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.Location = new System.Drawing.Point(921, 74);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.MaximumSize = new System.Drawing.Size(301, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Группа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Направление";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Отдел";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ФИО";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "№ зачётки";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupTextBox.Location = new System.Drawing.Point(921, 138);
            this.groupTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.groupTextBox.MaximumSize = new System.Drawing.Size(301, 22);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(210, 29);
            this.groupTextBox.TabIndex = 4;
            // 
            // specificationComboBox
            // 
            this.specificationComboBox.FormattingEnabled = true;
            this.specificationComboBox.Location = new System.Drawing.Point(553, 138);
            this.specificationComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.specificationComboBox.Name = "specificationComboBox";
            this.specificationComboBox.Size = new System.Drawing.Size(165, 32);
            this.specificationComboBox.TabIndex = 3;
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(553, 74);
            this.departmentComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(165, 32);
            this.departmentComboBox.TabIndex = 2;
            this.departmentComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentComboBox_SelectedIndexChanged);
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fullNameTextBox.Location = new System.Drawing.Point(148, 134);
            this.fullNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fullNameTextBox.MaximumSize = new System.Drawing.Size(274, 22);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(186, 29);
            this.fullNameTextBox.TabIndex = 1;
            // 
            // recordBookTextBox
            // 
            this.recordBookTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.recordBookTextBox.Location = new System.Drawing.Point(148, 74);
            this.recordBookTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.recordBookTextBox.MaximumSize = new System.Drawing.Size(274, 22);
            this.recordBookTextBox.Name = "recordBookTextBox";
            this.recordBookTextBox.Size = new System.Drawing.Size(186, 29);
            this.recordBookTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.importButton);
            this.groupBox2.Controls.Add(this.exportButton);
            this.groupBox2.Location = new System.Drawing.Point(1342, 777);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 228);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с файлами";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(24, 134);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(178, 61);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Импорт";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(24, 45);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(178, 61);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Экспорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 1023);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1607, 1087);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.TextBox recordBookTextBox;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.ComboBox specificationComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecordBookColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecificationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfAdmissionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupColumn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
    }
}

