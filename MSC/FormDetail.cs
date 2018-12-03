using MSC.BussinessLogics;
using MSC.Extensions;
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

                    var result = _projectRequestBLL.GetHistories(SelectedData.ID, true);
                    if (result.Count == 1)
                    {
                        RichTextBoxDetail.Text = "The data has not been modified since it was created.";
                    }
                    else
                    {
                        List<string> list = ColumnChangeTracker.GetChangedColumns(result.ToArray());
                        string textResult = list.Aggregate((current, next) => current + "\n" + next);
                        RichTextBoxDetail.Text = textResult;
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
