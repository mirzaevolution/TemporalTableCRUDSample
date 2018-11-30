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
    public partial class FormDetail : Form
    {
        private ProjectRequestsBLL _projectRequestBLL = new ProjectRequestsBLL();
        public ProjectRequests ProjectRequest { get; set; }
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

                    foreach (ProjectRequests project in _projectRequestBLL.GetHistories(SelectedData.ID))
                    {
                        var item = ListViewProjectRequset.Items.Add(project.ProjectName);
                        item.Tag = project;
                        item.SubItems.Add(project.Description);
                        item.SubItems.Add(project.ClientName);
                        item.SubItems.Add(project.StartDate.ToLongDateString());
                        item.SubItems.Add(project.ExpectedEndDate.ToLongDateString());
                        item.SubItems.Add(project.StartTime.Value.ToString());
                        item.SubItems.Add(project.EndTime.Value.ToString());
                        item.SubItems.Add(project.ModifiedBy);

                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void InvokeDetailData()
        {
            try
            {
                RichTextBoxDetail.Invoke(new Action(() =>
                {

                    var result = _projectRequestBLL.GetHistories(SelectedData.ID, false);
                    if (result.Count == 1)
                    {
                        RichTextBoxDetail.Text = "The data has not been modified since it was created.";
                    }
                    else
                    {
                        Dictionary<string, string> modifiedData = new Dictionary<string, string>();
                        if (result[0].ProjectName != result[1].ProjectName)
                            modifiedData.Add("Project Name", $"From `{result[1].ProjectName}` to `{result[0].ProjectName}`");
                        if (result[0].Description != result[1].Description)
                            modifiedData.Add("Description", $"From `{result[1].Description}` to `{result[0].Description}`");
                        if (result[0].ClientName != result[1].ClientName)
                            modifiedData.Add("Client Name", $"From `{result[1].ClientName}` to `{result[0].ClientName}`");
                        if (result[0].StartDate != result[1].StartDate)
                            modifiedData.Add("Start Date", $"From `{result[1].StartDate}` to `{result[0].StartDate}`");
                        if (result[0].ExpectedEndDate != result[1].ExpectedEndDate)
                            modifiedData.Add("Expected End Date", $"From `{result[1].ExpectedEndDate}` to `{result[0].ExpectedEndDate}`");
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"User `{result[0].ModifiedBy}` has modified the data, below is the affected columns: ");
                        foreach(var item in modifiedData)
                        {
                            sb.AppendLine($"\t[{item.Key}], {item.Value}");
                        }
                        RichTextBoxDetail.Text = sb.ToString();
                    }
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public FormDetail()
        {
            InitializeComponent();
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            LoadData();
            InvokeDetailData();
        }
    }
}
