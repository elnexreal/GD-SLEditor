using System.IO;
//using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Forms;
using GD_SLEditor.Handling;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace GD_SLEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		string GDPath;
		string Server;

		// Open button function
		private void OpenFileMenu(object sender, RoutedEventArgs e)
		{
			// Select file dialog config
			OpenFileDialog dialog = new OpenFileDialog
			{
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true,
				AddExtension = true,
				Title = "Locate your Geometry Dash.exe file",
				Filter = "Geometry Dash Executable|GeometryDash.exe"
			};

			// Check if user cancelled file selection
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				GDPath = dialog.FileName;
				FPath.Text = GDPath;
			} 
			else
			{
				System.Windows.MessageBox.Show("Please select your Geometry Dash executable", "Operation cancelled", MessageBoxButton.OK);
			}
		}

		private void ApplyButton(object sender, RoutedEventArgs e)
		{
			Server = Serverlink.Text;
			if (Server.Length == 33)
			{
				try
				{
					HexHandler.HexModify(GDPath, FileMode.Open, Server);
				}
				catch (IOException err)
				{
					System.Windows.MessageBox.Show(err.Message);
				}
			}
			else
			{
				System.Windows.MessageBox.Show("Your server URL must have exactly 33 characters", "Warning", MessageBoxButton.OK);
			}
		}

		private void InitProgram()
		{
			// Link the button click to functions
			Openbtn.Click += OpenFileMenu;
			Applybtn.Click += ApplyButton;

			Devname.Text += $" - {DateTime.Now.Year}";
		}

		public MainWindow()
		{
			InitializeComponent();
			InitProgram();
		}
	}
}
