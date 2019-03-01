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

        #region CRUD Handlers
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private Task<bool> InsertData(ProjectRequests req)
        {
            if (_projectRequestBLL.Insert(req))
            {
                return Task.FromResult<bool>(true);
            }
            else
            {
                return Task.FromResult<bool>(false);
            }
        }
        private Task<bool> UpdateData(ProjectRequests req)
        {
            if (_projectRequestBLL.Update(req))
            {
                SelectedData = req;
                return Task.FromResult<bool>(true);
            }
            else
            {
                return Task.FromResult<bool>(false);
            }
        }
        private Task<bool> DeleteData(Guid id)
        {
            if (_projectRequestBLL.Delete(id))
            {
                return Task.FromResult<bool>(true);
            }
            else
            {
                return Task.FromResult<bool>(false);
            }
        }
        #endregion



        public FormMain()
        {
            InitializeComponent();

        }


        #region Button Handlers
        private async void ButtonAdd_Click(object sender, EventArgs e)
        {
            Control[] buttonControls = new Control[]
             {
                    ButtonUpdate,
                    ButtonDelete,
                    ButtonDetails
             };

            if (ButtonAdd.Text.Equals("Add New"))
            {
                Control[] textControls = new Control[]
                {
                    TextBoxProjectName,
                    TextBoxDescription,
                    TextBoxClientName,
                    DateTimePickerStartDate,
                    DateTimePickerEndDate
                };

                foreach (Control control in textControls)
                {
                    control.Text = "";
                }
                foreach (Control control in buttonControls)
                {
                    control.Enabled = false;
                }
                ButtonCancel.Enabled = true;
                ButtonAdd.Text = "Save";
                ListViewProjectRequset.Enabled = false;
            }
            else
            {

                ProjectRequests newData = new ProjectRequests();
                if (!string.IsNullOrEmpty(TextBoxProjectName.Text) ||
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

                    bool success = await InsertData(newData);

                    if (success)
                    {

                        MessageBox.Show("Data has been inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await Task.Run(() => LoadData());
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    foreach (Control control in buttonControls)
                    {
                        control.Enabled = true;
                    }
                    ButtonCancel.Enabled = false;

                    ButtonAdd.Text = "Add New";
                    ListViewProjectRequset.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please complete all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async void ButtonUpdate_Click(object sender, EventArgs e)
        {

            if (SelectedData != null)
            {
                if (MessageBox.Show("Are you sure want to update the selected row?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    bool success = await UpdateData(SelectedData);
                    if (success)
                    {
                        if (ListViewProjectRequset.SelectedItems.Count > 0)
                        {
                            MessageBox.Show("Data has been updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    }
                    else
                    {
                        MessageBox.Show("Failed to update data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    GroupBoxContainer.Enabled = true;
                    ListViewProjectRequset.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please select any row to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Control[] buttonControls = new Control[]
             {
                        ButtonUpdate,
                        ButtonDelete,
                        ButtonDetails
             };

            foreach (Control control in buttonControls)
            {
                control.Enabled = true;
            }
            ButtonCancel.Enabled = false;

            ButtonAdd.Text = "Add New";
            ListViewProjectRequset.Enabled = true;
            if (ListViewProjectRequset.Items.Count > 0)
            {
                ListViewProjectRequset.Items[0].Selected = true;
            }
        }
        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedData != null)
            {
                if (MessageBox.Show("Are you sure want to delete the selected row?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GroupBoxContainer.Enabled = false;
                    ListViewProjectRequset.Enabled = false;

                    bool success = await DeleteData(SelectedData.ID);
                    if (success)
                    {
                        SelectedData = null;
                        ListViewProjectRequset.SelectedItems[0].Remove();
                        Control[] textControls = new Control[]
                        {
                            TextBoxProjectName,
                            TextBoxDescription,
                            TextBoxClientName,
                            DateTimePickerStartDate,
                            DateTimePickerEndDate
                        };

                        foreach (Control control in textControls)
                        {
                            control.Text = "";
                        }
                        MessageBox.Show("Data has been deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    GroupBoxContainer.Enabled = true;
                    ListViewProjectRequset.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please select any row to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        #endregion


        #region Form Handlers
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion


        #region ListView Handlers
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
        #endregion


    }
}
