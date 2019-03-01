namespace MSC
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.GroupBoxContainer = new System.Windows.Forms.GroupBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonDetails = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.DateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.TextBoxClientName = new System.Windows.Forms.TextBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.TextBoxProjectName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListViewProjectRequset = new System.Windows.Forms.ListView();
            this.ColumnHeaderProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.GroupBoxContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBoxContainer
            // 
            this.GroupBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxContainer.Controls.Add(this.ButtonDelete);
            this.GroupBoxContainer.Controls.Add(this.ButtonCancel);
            this.GroupBoxContainer.Controls.Add(this.ButtonDetails);
            this.GroupBoxContainer.Controls.Add(this.ButtonUpdate);
            this.GroupBoxContainer.Controls.Add(this.ButtonAdd);
            this.GroupBoxContainer.Controls.Add(this.DateTimePickerEndDate);
            this.GroupBoxContainer.Controls.Add(this.DateTimePickerStartDate);
            this.GroupBoxContainer.Controls.Add(this.TextBoxClientName);
            this.GroupBoxContainer.Controls.Add(this.TextBoxDescription);
            this.GroupBoxContainer.Controls.Add(this.TextBoxProjectName);
            this.GroupBoxContainer.Controls.Add(this.label5);
            this.GroupBoxContainer.Controls.Add(this.label4);
            this.GroupBoxContainer.Controls.Add(this.label3);
            this.GroupBoxContainer.Controls.Add(this.label2);
            this.GroupBoxContainer.Controls.Add(this.label1);
            this.GroupBoxContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBoxContainer.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxContainer.Name = "GroupBoxContainer";
            this.GroupBoxContainer.Size = new System.Drawing.Size(1026, 270);
            this.GroupBoxContainer.TabIndex = 0;
            this.GroupBoxContainer.TabStop = false;
            this.GroupBoxContainer.Text = "Project Request";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Enabled = false;
            this.ButtonCancel.Location = new System.Drawing.Point(872, 89);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(128, 36);
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "Cancel Add";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonDetails
            // 
            this.ButtonDetails.Location = new System.Drawing.Point(872, 215);
            this.ButtonDetails.Name = "ButtonDetails";
            this.ButtonDetails.Size = new System.Drawing.Size(128, 36);
            this.ButtonDetails.TabIndex = 12;
            this.ButtonDetails.Text = "History";
            this.ButtonDetails.UseVisualStyleBackColor = true;
            this.ButtonDetails.Click += new System.EventHandler(this.ButtonDetails_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.Location = new System.Drawing.Point(872, 130);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(128, 36);
            this.ButtonUpdate.TabIndex = 11;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = true;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(872, 47);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(128, 36);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Add New";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // DateTimePickerEndDate
            // 
            this.DateTimePickerEndDate.Location = new System.Drawing.Point(479, 143);
            this.DateTimePickerEndDate.Name = "DateTimePickerEndDate";
            this.DateTimePickerEndDate.Size = new System.Drawing.Size(338, 27);
            this.DateTimePickerEndDate.TabIndex = 10;
            // 
            // DateTimePickerStartDate
            // 
            this.DateTimePickerStartDate.Location = new System.Drawing.Point(480, 79);
            this.DateTimePickerStartDate.Name = "DateTimePickerStartDate";
            this.DateTimePickerStartDate.Size = new System.Drawing.Size(337, 27);
            this.DateTimePickerStartDate.TabIndex = 9;
            // 
            // TextBoxClientName
            // 
            this.TextBoxClientName.Location = new System.Drawing.Point(31, 206);
            this.TextBoxClientName.Name = "TextBoxClientName";
            this.TextBoxClientName.Size = new System.Drawing.Size(311, 27);
            this.TextBoxClientName.TabIndex = 8;
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(32, 143);
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(310, 27);
            this.TextBoxDescription.TabIndex = 7;
            // 
            // TextBoxProjectName
            // 
            this.TextBoxProjectName.Location = new System.Drawing.Point(32, 78);
            this.TextBoxProjectName.Name = "TextBoxProjectName";
            this.TextBoxProjectName.Size = new System.Drawing.Size(310, 27);
            this.TextBoxProjectName.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "End Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(476, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Start Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Client Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Name:";
            // 
            // ListViewProjectRequset
            // 
            this.ListViewProjectRequset.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderProject,
            this.ColumnHeaderDescription,
            this.ColumnHeaderClientName,
            this.ColumnHeaderStartDate,
            this.ColumnHeaderEndDate});
            this.ListViewProjectRequset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewProjectRequset.FullRowSelect = true;
            this.ListViewProjectRequset.GridLines = true;
            this.ListViewProjectRequset.Location = new System.Drawing.Point(12, 297);
            this.ListViewProjectRequset.Name = "ListViewProjectRequset";
            this.ListViewProjectRequset.Size = new System.Drawing.Size(1127, 466);
            this.ListViewProjectRequset.TabIndex = 1;
            this.ListViewProjectRequset.UseCompatibleStateImageBehavior = false;
            this.ListViewProjectRequset.View = System.Windows.Forms.View.Details;
            this.ListViewProjectRequset.SelectedIndexChanged += new System.EventHandler(this.ListViewProjectRequset_SelectedIndexChanged);
            // 
            // ColumnHeaderProject
            // 
            this.ColumnHeaderProject.Text = "Project Name";
            this.ColumnHeaderProject.Width = 250;
            // 
            // ColumnHeaderDescription
            // 
            this.ColumnHeaderDescription.Text = "Description";
            this.ColumnHeaderDescription.Width = 250;
            // 
            // ColumnHeaderClientName
            // 
            this.ColumnHeaderClientName.Text = "Client Name";
            this.ColumnHeaderClientName.Width = 200;
            // 
            // ColumnHeaderStartDate
            // 
            this.ColumnHeaderStartDate.Text = "Start Date";
            this.ColumnHeaderStartDate.Width = 150;
            // 
            // ColumnHeaderEndDate
            // 
            this.ColumnHeaderEndDate.Text = "End Date";
            this.ColumnHeaderEndDate.Width = 150;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(872, 172);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(128, 36);
            this.ButtonDelete.TabIndex = 14;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 765);
            this.Controls.Add(this.ListViewProjectRequset);
            this.Controls.Add(this.GroupBoxContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Request";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.GroupBoxContainer.ResumeLayout(false);
            this.GroupBoxContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBoxContainer;
        private System.Windows.Forms.TextBox TextBoxClientName;
        private System.Windows.Forms.TextBox TextBoxDescription;
        private System.Windows.Forms.TextBox TextBoxProjectName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker DateTimePickerStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ButtonDetails;
        private System.Windows.Forms.Button ButtonUpdate;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.ListView ListViewProjectRequset;
        private System.Windows.Forms.ColumnHeader ColumnHeaderProject;
        private System.Windows.Forms.ColumnHeader ColumnHeaderDescription;
        private System.Windows.Forms.ColumnHeader ColumnHeaderClientName;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStartDate;
        private System.Windows.Forms.ColumnHeader ColumnHeaderEndDate;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonDelete;
    }
}

