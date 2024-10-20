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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 408);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 152);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editButton.Location = new System.Drawing.Point(858, 64);
            this.editButton.MaximumSize = new System.Drawing.Size(110, 38);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(86, 38);
            this.editButton.TabIndex = 14;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.deleteButton.Location = new System.Drawing.Point(858, 108);
            this.deleteButton.MaximumSize = new System.Drawing.Size(110, 38);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(86, 38);
            this.deleteButton.TabIndex = 13;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addButton.Location = new System.Drawing.Point(858, 21);
            this.addButton.MaximumSize = new System.Drawing.Size(110, 38);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(86, 38);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(553, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Дата зачисления";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.Location = new System.Drawing.Point(679, 49);
            this.dateTimePicker1.MaximumSize = new System.Drawing.Size(220, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(583, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Группа";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Направление";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Отдел";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "ФИО";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "№ зачётки";
            // 
            // groupTextBox
            // 
            this.groupTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupTextBox.Location = new System.Drawing.Point(679, 92);
            this.groupTextBox.MaximumSize = new System.Drawing.Size(220, 22);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.Size = new System.Drawing.Size(154, 22);
            this.groupTextBox.TabIndex = 4;
            // 
            // specificationComboBox
            // 
            this.specificationComboBox.FormattingEnabled = true;
            this.specificationComboBox.Location = new System.Drawing.Point(402, 92);
            this.specificationComboBox.Name = "specificationComboBox";
            this.specificationComboBox.Size = new System.Drawing.Size(121, 24);
            this.specificationComboBox.TabIndex = 3;
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(402, 49);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(121, 24);
            this.departmentComboBox.TabIndex = 2;
            this.departmentComboBox.SelectedIndexChanged += new System.EventHandler(this.departmentComboBox_SelectedIndexChanged);
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fullNameTextBox.Location = new System.Drawing.Point(108, 89);
            this.fullNameTextBox.MaximumSize = new System.Drawing.Size(200, 22);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(136, 22);
            this.fullNameTextBox.TabIndex = 1;
            // 
            // recordBookTextBox
            // 
            this.recordBookTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.recordBookTextBox.Location = new System.Drawing.Point(108, 49);
            this.recordBookTextBox.MaximumSize = new System.Drawing.Size(200, 22);
            this.recordBookTextBox.Name = "recordBookTextBox";
            this.recordBookTextBox.Size = new System.Drawing.Size(136, 22);
            this.recordBookTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

