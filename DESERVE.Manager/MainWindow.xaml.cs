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
using Microsoft.Win32;
using DESERVE.Manager.Properties;

namespace DESERVE.Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			LB_ServerInstances.ItemsSource = Manager.ServerInstances;
			LB_ServerInstances.SelectedIndex = 0;
			G_MainGrid.DataContext = LB_ServerInstances.SelectedItem;
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
			((ServerInstance)LB_ServerInstances.SelectedItem).Start();
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
			((ServerInstance)LB_ServerInstances.SelectedItem).Stop();
		}

		private void MainMenu_Options_DeservePath_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.CheckFileExists = true;
			openFileDialog.InitialDirectory = Settings.Default.DESERVEPath;
			openFileDialog.ShowDialog();

			string fileName = openFileDialog.FileName;

			if (fileName.Contains(@"\DESERVE.exe"))
			{
				Settings.Default.DESERVEPath = fileName.Replace(@"\DESERVE.exe", "");
				Settings.Default.Save();				
			}		
		}

		private void MainMenu_File_Quit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void BTN_Configuration_SaveChanges_Click(object sender, RoutedEventArgs e)
		{
			var args = ((ServerInstance)LB_ServerInstances.SelectedItem).Arguments;
			var path = ((ServerInstance)LB_ServerInstances.SelectedItem).InstanceDirectory;
			FileManager.Instance.SaveArguments(path, args);
		}

		private void LB_ServerInstances_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			G_MainGrid.DataContext = LB_ServerInstances.SelectedItem;
		}
	}
}
