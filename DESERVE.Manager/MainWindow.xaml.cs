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

		/// <summary>
		/// <Button Content="Start" HorizontalAlignment="Left" Margin="10,0,0,0" VerticalAlignment="Top" Width="75" Click="Start_Click"/>
		/// 
		/// Note: Click="Start_Click" in the above line.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Start_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// <Button Content="Stop" HorizontalAlignment="Left" Margin="90,0,0,0" VerticalAlignment="Top" Width="75" Click="Stop_Click"/>
		/// 
		/// Note: Click="Stop_Click" in the above line.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Stop_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
