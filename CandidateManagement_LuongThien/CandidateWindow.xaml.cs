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

        public void LoadJobPosting()
        {
            var JobPosting = _jobPostingService.GetJobs();
            cboPostingId.ItemsSource = JobPosting;
            cboPostingId.DisplayMemberPath = "JobPostTitle";
            cboPostingId.SelectedValuePath = "PostingId";
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

        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCandidate();
        }
    }
}
