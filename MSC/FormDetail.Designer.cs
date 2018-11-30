namespace MSC
{
    partial class FormDetail
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
            this.RichTextBoxDetail = new System.Windows.Forms.RichTextBox();
            this.ListViewProjectRequset = new System.Windows.Forms.ListView();
            this.ColumnHeaderProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderEndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderModifiedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RichTextBoxDetail
            // 
            this.RichTextBoxDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBoxDetail.Location = new System.Drawing.Point(15, 14);
            this.RichTextBoxDetail.Name = "RichTextBoxDetail";
            this.RichTextBoxDetail.Size = new System.Drawing.Size(703, 210);
            this.RichTextBoxDetail.TabIndex = 0;
            this.RichTextBoxDetail.Text = "";
            // 
            // ListViewProjectRequset
            // 
            this.ListViewProjectRequset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewProjectRequset.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderProject,
            this.ColumnHeaderDescription,
            this.ColumnHeaderClientName,
            this.ColumnHeaderStartDate,
            this.ColumnHeaderEndDate,
            this.ColumnHeaderStartTime,
            this.ColumnHeaderEndTime,
            this.ColumnHeaderModifiedBy});
            this.ListViewProjectRequset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListViewProjectRequset.FullRowSelect = true;
            this.ListViewProjectRequset.GridLines = true;
            this.ListViewProjectRequset.Location = new System.Drawing.Point(15, 281);
            this.ListViewProjectRequset.Name = "ListViewProjectRequset";
            this.ListViewProjectRequset.Size = new System.Drawing.Size(703, 376);
            this.ListViewProjectRequset.TabIndex = 2;
            this.ListViewProjectRequset.UseCompatibleStateImageBehavior = false;
            this.ListViewProjectRequset.View = System.Windows.Forms.View.Details;
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
            // ColumnHeaderStartTime
            // 
            this.ColumnHeaderStartTime.Text = "Start Time";
            this.ColumnHeaderStartTime.Width = 150;
            // 
            // ColumnHeaderEndTime
            // 
            this.ColumnHeaderEndTime.Text = "End Time";
            this.ColumnHeaderEndTime.Width = 150;
            // 
            // ColumnHeaderModifiedBy
            // 
            this.ColumnHeaderModifiedBy.Text = "Modified By";
            this.ColumnHeaderModifiedBy.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Full History:";
            // 
            // FormDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 686);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListViewProjectRequset);
            this.Controls.Add(this.RichTextBoxDetail);
            this.Name = "FormDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Detail";
            this.Load += new System.EventHandler(this.FormDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBoxDetail;
        private System.Windows.Forms.ListView ListViewProjectRequset;
        private System.Windows.Forms.ColumnHeader ColumnHeaderProject;
        private System.Windows.Forms.ColumnHeader ColumnHeaderDescription;
        private System.Windows.Forms.ColumnHeader ColumnHeaderClientName;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStartDate;
        private System.Windows.Forms.ColumnHeader ColumnHeaderEndDate;
        private System.Windows.Forms.ColumnHeader ColumnHeaderStartTime;
        private System.Windows.Forms.ColumnHeader ColumnHeaderEndTime;
        private System.Windows.Forms.ColumnHeader ColumnHeaderModifiedBy;
        private System.Windows.Forms.Label label1;
    }
}