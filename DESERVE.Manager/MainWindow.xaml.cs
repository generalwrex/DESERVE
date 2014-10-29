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

namespace DESERVE.Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<ServerInstance> m_servers;
		public MainWindow()
		{
			m_servers = new List<ServerInstance>();

			m_servers.Add(new ServerInstance("Test1", true));
			m_servers.Add(new ServerInstance("Test2", false));

			InitializeComponent();

			LB_ServerInstances.ItemsSource = m_servers;
			LB_ServerInstances.SelectedIndex = 0;
		}
	}
}
