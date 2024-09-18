using Models.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_LuongThien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICandidateService _service;
        private IJobPostingService _jobPostingService;

        List<CandidateProfile> _profiles { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _jobPostingService = new JobPostingService();
            _service = new CandidateService();
        }

        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgCandidate_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadJobPostingList();
            LoadCandidateProfileList();
        }


        public void LoadJobPostingList()
        {
            try
            {
                var jobPostingList = _jobPostingService.GetJobs();
                dgData.ItemsSource = jobPostingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load JobPosting error");
            }
        }

        public void LoadCandidateProfileList()
        {
            try
            {
                var CandidateList = _service.GetProfiles();
                cboCandidateProfile.ItemsSource = CandidateList;
                cboCandidateProfile.DisplayMemberPath = "FullName";
                cboCandidateProfile.SelectedValuePath = "CandidateId";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Load candidate error");
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row =
                (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            string id = ((TextBlock)RowColumn.Content).Text;
            JobPosting jobPosting = _jobPostingService.GetJob(id);
            txtJobPostingId.Text = jobPosting.PostingId.ToString();
            txtJobPostingTitle.Text = jobPosting.JobPostingTitle.ToString();
            txtDescription.Text = jobPosting.Description.ToString();
            txtPostDate.Text = jobPosting.PostedDate.ToString();
            cboCandidateProfile.SelectedValue = jobPosting.CandidateProfiles;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
