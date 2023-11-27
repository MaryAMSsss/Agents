using DemoVar8wifArtem.DataB;
using DemoVar8wifArtem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DemoVar8wifArtem.Views
{
    /// <summary>
    /// Логика взаимодействия для ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : Window
    {
        List<Agent> agents = new List<Agent>();
        public int TotalRecordsOnPage = 10;
        public int CurrentPage = 0;
        ObservableCollection<Agent> agentsOnPage = new ObservableCollection<Agent>();
        public int MaxPageCount
        {
            get
            {
                if (agents.Count % 10 == 0)
                {
                    return agents.Count / TotalRecordsOnPage;
                }
                else return agents.Count / TotalRecordsOnPage + 1;
            }
        }
        public ContentWindow()
        {
            InitializeComponent();
            LoadingData();
        }
        public void UpdatePages()
        {
            agentsOnPage.Clear();
            for (int i = TotalRecordsOnPage*CurrentPage; i < TotalRecordsOnPage * CurrentPage + TotalRecordsOnPage; i++) 
            {
                if(i < agents.Count)
                {
                    agentsOnPage.Add(agents[i]);
                }
            }
            UpdateLabels();
            currentPage.Foreground = Brushes.Red;
            currentPage.FontWeight = FontWeights.Bold;
        }
        public void LoadingData()
        {
            UpdateData();
            AgentsListBox.ItemsSource = agentsOnPage;
            UpdatePages();
        }
        
        public void UpdateData()
        {
            agents = AgentsDB.GetAgents();
        }
        private void AgentsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditWindow editWindow = new EditWindow(AgentsListBox.SelectedItem as Agent, this);
            editWindow.Show();            
        }
        private void GoToPrevPage_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentPage == 0)
            {
                return;
            }
            CurrentPage -= 1;
            UpdatePages();
        }
        private void GoToNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage == MaxPageCount-1)
            {
                return;
            }
            CurrentPage += 1;
            UpdatePages();
        }
        public void UpdateLabels()
        {
            if (CurrentPage > 0)
            {
                lastPage.Content = CurrentPage - 1;
            }
            else lastPage.Content = ' ';
            if (CurrentPage == MaxPageCount - 1)
            {
                nextPage.Content = ' ';
            }
            else nextPage.Content = CurrentPage + 1;
            maxPage.Content = MaxPageCount-1;
            currentPage.Content = CurrentPage;
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow(this);
            addWindow.Show();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Agent selectedItem = AgentsListBox.SelectedItem as Agent;
            if (selectedItem == null)
            {
                MessageBox.Show("Вы не выбрали элемент списка");
                return;
            }
            agentsOnPage.Remove(selectedItem);
            AgentsDB.RemoveAgent(selectedItem);
        }
    }
}
