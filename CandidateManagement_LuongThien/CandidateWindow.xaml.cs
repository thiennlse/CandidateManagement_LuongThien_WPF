using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CandidateManagement_LuongThien
{
    /// <summary>
    /// Interaction logic for CandidateWindow.xaml
    /// </summary>
    public partial class CandidateWindow : Window
    {
        private ICandidateService _candidateService;
        private IJobPostingService _jobPostingService;  
        public CandidateWindow()
        {
            InitializeComponent();
            _candidateService = new CandidateService();
            _jobPostingService = new JobPostingService();
        }

        public void LoadCandidate()
        {
            var CandidateList = _candidateService.GetProfiles();
            dgData.ItemsSource = CandidateList;
        }
        
        public void LoadData()
        {
            dgData.ItemsSource = _candidateService.GetProfiles();
        }

        public void LoadJobPosting()
        {
            var JobPosting = _jobPostingService.GetJobs();
            cboPostingId.ItemsSource = JobPosting;
            cboPostingId.DisplayMemberPath = "JobPostingTitle";
            cboPostingId.SelectedValuePath = "PostingId";
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string id = txtCandidateId.Text;
            CandidateProfile profile = new CandidateProfile(txtCandidateId.Text,txtFullname.Text,DateTime.Parse(txtBirthday.Text),txtProfileDescription.Text,txtProfileURL.Text,cboPostingId.SelectedValue.ToString());
            _candidateService.addCandidate(profile);
            MessageBox.Show("Tạo mới thành công");
            this.LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string id = txtCandidateId.Text;
            CandidateProfile profile = _candidateService.GetProfile(id);
            txtFullname.Text = profile.Fullname;
            profile.Birthday = DateTime.Parse(txtBirthday.Text);
            profile.ProfileUrl = txtProfileURL.Text;
            profile.ProfileShortDescription = txtProfileDescription.Text;
            cboPostingId.SelectedValue = profile.PostingId;
            _candidateService.updateCandidate(id, profile);
            MessageBox.Show("Cập nhật thành công ");
            this.LoadData();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string id = txtCandidateId.Text;
            CandidateProfile profile = _candidateService.GetProfile(id);
            _candidateService.removeCandidate(id);
            MessageBox.Show("Xóa candidate thành công");
            this.LoadData();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            CandidateProfile candidate = _candidateService.GetProfile(id);
            txtCandidateId.Text = candidate.CandidateId.ToString();
            txtFullname.Text = candidate.Fullname.ToString();
            txtBirthday.Text = candidate.Birthday.ToString();
            txtProfileDescription.Text = candidate.ProfileShortDescription.ToString();
            txtProfileURL.Text = candidate.ProfileUrl.ToString();
            cboPostingId.SelectedValue = candidate.PostingId;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCandidate();
            LoadJobPosting();   
        }
    }
}
