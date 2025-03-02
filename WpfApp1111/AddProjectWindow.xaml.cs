using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1111.Entities;

namespace WpfApp1111
{
    public partial class AddProjectWindow : Window
    {
        private ObservableCollection<Project> Projects;
        private int nextId;

        public AddProjectWindow(ObservableCollection<Project> projects, ref int idCounter)
        {
            InitializeComponent();
            Projects = projects;
            nextId = idCounter;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProjectNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProjectDescriptionTextBox.Text) ||
                StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Заполните все пустые поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Projects.Add(new Project
            {
                Id = nextId++,
                Name = ProjectNameTextBox.Text,
                Description = ProjectDescriptionTextBox.Text,
                StartDate = StartDatePicker.SelectedDate.Value
            });

            Close();
        }
    }
}
