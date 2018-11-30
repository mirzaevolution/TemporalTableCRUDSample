using MSC.BussinessLogics;
using MSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSC
{
    public partial class FormMain : Form
    {
        private ProjectRequestsBLL _projectRequestBLL = new ProjectRequestsBLL();
        public ProjectRequests SelectedData { get; set; }
        private void LoadData()
        {
            ListViewProjectRequset.Items.Clear();
            Task.Run(() =>
            {
                InvokeData();
            });
        }
        private void InvokeData()
        {
            try
            {
                ListViewProjectRequset.Invoke(new Action(() =>
                {

                    foreach (ProjectRequests project in _projectRequestBLL.GetAll())
                    {
                        var item = ListViewProjectRequset.Items.Add(project.ProjectName);
                        item.Tag = project;
                        item.SubItems.Add(project.Description);
                        item.SubItems.Add(project.ClientName);
                        item.SubItems.Add(project.StartDate.ToLongDateString());
                        item.SubItems.Add(project.ExpectedEndDate.ToLongDateString());
                    }
                }));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task InsertData(ProjectRequests req)
        {
            try
            {
                if (_projectRequestBLL.Insert(req))
                {
                    MessageBox.Show("Data has been inserted successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    await Task.Run(() => LoadData());
                }
                else
                {
                    MessageBox.Show("Failed to insert data","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private Task UpdateData(ProjectRequests req)
        {
            try
            {
                if (_projectRequestBLL.Update(req))
                {
                    SelectedData = req;
                    
                    MessageBox.Show("Data has been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Failed to insert data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
        public FormMain()
        {
            InitializeComponent();
         
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            ProjectRequests newData = new ProjectRequests();
            if(!string.IsNullOrEmpty(TextBoxProjectName.Text) || 
               !string.IsNullOrEmpty(TextBoxDescription.Text) ||
               !string.IsNullOrEmpty(TextBoxClientName.Text) ||
               !string.IsNullOrEmpty(DateTimePickerStartDate.Text) ||
               !string.IsNullOrEmpty(DateTimePickerEndDate.Text)
              )
            {
                newData.ID = Guid.NewGuid();
                newData.ProjectName = TextBoxProjectName.Text;
                newData.Description = TextBoxDescription.Text;
                newData.ClientName = TextBoxClientName.Text;
                newData.StartDate = DateTime.Parse(DateTimePickerStartDate.Text);
                newData.ExpectedEndDate = DateTime.Parse(DateTimePickerEndDate.Text);
                newData.CreatedBy = CoreGlobal.LoggedUser;
                newData.CreatedDate = DateTime.Now;
                newData.ModifiedBy = CoreGlobal.LoggedUser;
                newData.ModifiedDate = DateTime.Now;
                await InsertData(newData);
            }
            else
            {
                MessageBox.Show("Please complete all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedData != null)
            {
                GroupBoxContainer.Enabled = false;
                ListViewProjectRequset.Enabled = false;
                SelectedData.ProjectName = TextBoxProjectName.Text;
                SelectedData.Description = TextBoxDescription.Text;
                SelectedData.ClientName = TextBoxClientName.Text;
                SelectedData.StartDate = DateTime.Parse(DateTimePickerStartDate.Text);
                SelectedData.ExpectedEndDate = DateTime.Parse(DateTimePickerEndDate.Text);
                SelectedData.ModifiedBy = CoreGlobal.LoggedUser;
                SelectedData.ModifiedDate = DateTime.Now;
                UpdateData(SelectedData);
                if (ListViewProjectRequset.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = ListViewProjectRequset.SelectedItems[0];
                    if (selectedItem != null)
                    {
                        selectedItem.Tag = SelectedData;
                        selectedItem.Text = SelectedData.ProjectName;
                        selectedItem.SubItems[1].Text = SelectedData.Description;
                        selectedItem.SubItems[2].Text = SelectedData.ClientName;
                        selectedItem.SubItems[3].Text = SelectedData.StartDate.ToLongDateString();
                        selectedItem.SubItems[4].Text = SelectedData.ExpectedEndDate.ToLongDateString();

                    }

                }
                GroupBoxContainer.Enabled = true;
                ListViewProjectRequset.Enabled = true;

            }
            else
            {
                MessageBox.Show("Please select any row to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ListViewProjectRequset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewProjectRequset.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = ListViewProjectRequset.SelectedItems[0];
                if (selectedItem != null)
                {
                    SelectedData = selectedItem.Tag as ProjectRequests;
                    TextBoxProjectName.Text = SelectedData.ProjectName;
                    TextBoxDescription.Text = SelectedData.Description;
                    TextBoxClientName.Text = SelectedData.ClientName;
                    DateTimePickerStartDate.Text = SelectedData.StartDate.ToLongDateString();
                    DateTimePickerEndDate.Text = SelectedData.ExpectedEndDate.ToLongDateString();
                }
            }
        }

        private void ButtonDetails_Click(object sender, EventArgs e)
        {
            if (SelectedData != null)
            {

                new FormDetail()
                {
                    SelectedData = SelectedData
                }.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select any row to see its history", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
