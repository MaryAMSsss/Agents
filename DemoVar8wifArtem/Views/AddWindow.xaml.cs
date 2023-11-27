using DemoVar8wifArtem.DataB;
using DemoVar8wifArtem.Models;
using Microsoft.Win32;
using System;
using System.IO;
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
using Path = System.IO.Path;

namespace DemoVar8wifArtem.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        string fullPath = string.Empty;
        ContentWindow contentwindow;
        public AddWindow(ContentWindow contentWindow)
        {
            InitializeComponent();
            contentwindow=contentWindow;
            AgentsTypeCb.ItemsSource=AgentTypeDB.GetAgentType();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string agentName = AgentNameTbx.Text;
            AgentType agentType1 = AgentsTypeCb.SelectedItem as AgentType;
            if(agentType1 == null )
            {
                MessageBox.Show("Вы не выбрали тип агента");
                return;
            }
            int agentType = agentType1.Id;
            string agentEmail = AgentEmailTbx.Text;
            string agentPhone = AgentPhoneTbx.Text;
            string agentAddress = AgentAddressTbx.Text;
            int agentPriority = Convert.ToInt32(AgentPriorityTbx.Text);
            string agentDirectorName= AgentDirectorTbx.Text;
            string agentINN = AgentINNTbx.Text;
            string agentKPP = AgentKPPTbx.Text;
            if (fullPath == string.Empty)
            {
                MessageBox.Show("нет картинки");
                return;
            }
            Agent agent = new Agent(agentName, agentType, agentEmail,
                agentPhone, fullPath, agentAddress, agentPriority, agentDirectorName,
                agentINN, agentKPP);
            AgentsDB.AddAgent(agent);
            contentwindow.UpdateData();
            contentwindow.UpdatePages();
            this.Close();
        }
        private void addImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();            
            if (openFileDialog.ShowDialog() == true)
            {
                fullPath = openFileDialog.FileName;
                pictureAgent.Source = new BitmapImage(new System.Uri(fullPath));
                //достаем имя файла без расширений
                fullPath = @"\agents\" + Path.GetFileName(openFileDialog.FileName);
            }
        }
    }
}
