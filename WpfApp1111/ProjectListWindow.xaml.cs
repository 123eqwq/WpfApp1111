using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1111.Entities;

namespace WpfApp1111
{
    public partial class ProjectListWindow : Window
    {
        private ObservableCollection<Project> Projects = new ObservableCollection<Project>();
        private int projectIdCounter = 1;

        public ProjectListWindow()
        {
            InitializeComponent();
            ProjectsListBox.ItemsSource = Projects;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            var addProjectWindow = new AddProjectWindow(Projects, ref projectIdCounter);
            addProjectWindow.ShowDialog();
        }
    }
}
