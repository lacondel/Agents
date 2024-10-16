using Agents.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Agents.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageInformation.xaml
    /// </summary>
    public partial class PageInformation : Page
    {
        public PageInformation()
        {
            InitializeComponent();
            List<Agent> agents = AppConnect.model0db.Agent.ToList();

            if (agents.Count > 0 )
            {
                tbCounter.Text = "Найдено " + agents.Count + " агентов";
            }
            ListAgents.ItemsSource = agents;
            
            
        }
        Agent[] AgentSearch()
        {
            var agent = AppConnect.model0db.Agent.ToList();

            if (TextSearch != null)
            {
                agent = agent.Where(x => x.Title.ToLowerInvariant().Contains(TextSearch.Text.ToLowerInvariant()) ||
                    Regex.Replace(x.Phone, @"[+\-\s()]", "").Contains(Regex.Replace(TextSearch.Text, @"[+\-\s()]", ""))).ToList();
            }

            if (FilterBy != null && FilterBy.SelectedIndex > 0)
            {
                switch (FilterBy.SelectedIndex)
                {
                    case 1:
                        agent = agent.Where(x => x.AgentTypeID == 1).ToList();
                        break;
                    case 2:
                        agent = agent.Where(x => x.AgentTypeID == 2).ToList();
                        break;
                    case 3:
                        agent = agent.Where(x => x.AgentTypeID == 3).ToList();
                        break;
                    case 4:
                        agent = agent.Where(x => x.AgentTypeID == 4).ToList();
                        break;
                    case 5:
                        agent = agent.Where(x => x.AgentTypeID == 5).ToList();
                        break;
                    case 6:
                        agent = agent.Where(x => x.AgentTypeID == 6).ToList();
                        break;
                }
            }

            if (SortBy != null && SortBy.SelectedIndex > 0)
            {
                switch (SortBy.SelectedIndex)
                {
                    case 1:
                        agent = agent.OrderBy(x => x.Title).ToList();
                        break; 
                    case 2:
                        agent = agent.OrderByDescending(x => x.Title).ToList();
                        break;
                    case 3:
                        agent = agent.OrderBy(x => x.Priority).ToList();
                        break;
                    case 4:
                        agent = agent.OrderByDescending(x => x.Priority).ToList();
                        break;
                }
            }

            return agent.ToArray();
        }
        private void UpdateAgentList()
        {
            if (ListAgents != null)
            {
                var updatedAgents = AgentSearch();
                if (updatedAgents != null)
                {
                    ListAgents.ItemsSource = updatedAgents;
                }
                else
                {
                    MessageBox.Show("Список агентов пуст!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        private void TextSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateAgentList();
        }
        private void SortBy_Changed(object sender, EventArgs e)
        {
            UpdateAgentList();
        }
        private void FilterBy_Changed(Object sender, EventArgs e)
        {
            UpdateAgentList();
        }
    }
}
