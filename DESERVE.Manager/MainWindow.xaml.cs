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
using System.Reflection;
using DESERVE.Common;

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

			this.Title = "DESERVE Manager v" + Manager.VersionString;

			if (Settings.Default.DESERVEPath == "")
				StatusBar.Content = "Set path to DESERVE.exe under 'Options'";
			else
				StatusBar.Content = "Welcome to DESERVE Manager v" + Manager.VersionString;
		}

		#region General
		private void LB_ServerInstances_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			G_MainGrid.DataContext = LB_ServerInstances.SelectedItem;
			StatusBar.Content = "Ready...";
		}
		#endregion

		#region Server Info
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
			StatusBar.Content = "Started '" + ((ServerInstance)LB_ServerInstances.SelectedItem).Name + "'";
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
			StatusBar.Content = "Stopped '" + ((ServerInstance)LB_ServerInstances.SelectedItem).Name + "'";
		}

		/// <summary>
		/// <Button x:Name="BTN_SaveServer" Content="Save" IsEnabled="{Binding IsRunning}" HorizontalAlignment="Left" Margin="200,0,0,0" VerticalAlignment="Top" Width="75" Click="Save_Click"/>
		///  Saves the Currently Selected Server
		/// Note: Click="Save_Click" in the above line.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Save_Click(object sender, RoutedEventArgs e)
		{
			((ServerInstance)LB_ServerInstances.SelectedItem).Save();
			StatusBar.Content = "Saved '" + ((ServerInstance)LB_ServerInstances.SelectedItem).Name + "'";
		}
		#endregion

		#region MainMenu
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
				StatusBar.Content = "DESERVE Path now set to: " + Settings.Default.DESERVEPath;
			}
			else
				MessageBox.Show("Deserve.exe not found in the selected location", "File not found", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
		}

		private void MainMenu_File_Quit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Configuration
		private void BTN_Configuration_SaveChanges_Click(object sender, RoutedEventArgs e)
		{
			var args = ((ServerInstance)LB_ServerInstances.SelectedItem).Arguments;
			var config = ((ServerInstance)LB_ServerInstances.SelectedItem).DedicatedConfiguration;
			var path = ((ServerInstance)LB_ServerInstances.SelectedItem).InstanceDirectory;

			FileManager.Instance.SaveArguments(path, args);

			if(DedicatedConfig.SaveDedicatedConfig(path, config) == null)
				StatusBar.Content = "Dedicated Config Failed to save!" ;

			StatusBar.Content = "Saved Configuration changes of: " + ((ServerInstance)LB_ServerInstances.SelectedItem).Name;
		}
		#endregion

		#region Chat
		private void BTN_Chat_SendMessage_Click(object sender, RoutedEventArgs e)
		{
			((ServerInstance)LB_ServerInstances.SelectedItem).SendChatMessage(TXT_Chat_MessageToSend.Text);
			TXT_Chat_MessageToSend.Clear();
		}

		private void TXT_Chat_MessageToSend_KeyDown(object sender, KeyEventArgs e)
		{
			if (!(e.Key == Key.Enter) || !(e.Key == Key.Return))
				return;

			((ServerInstance)LB_ServerInstances.SelectedItem).SendChatMessage(TXT_Chat_MessageToSend.Text);
			TXT_Chat_MessageToSend.Clear();
		}

		private void LB_ChatMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (LB_ChatMessages.SelectedItem == null)
				return;

			Clipboard.SetText(LB_ChatMessages.SelectedItem.ToString());
		}
		#endregion






	}
}
