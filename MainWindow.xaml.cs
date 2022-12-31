//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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

		private void OpenFileMenu(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog
			{
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true,
				AddExtension = true,
				Title = "Locate your Geometry Dash.exe file",
				Filter = "Geometry Dash Executable|GeometryDash.exe"
			};

			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				GDPath = dialog.FileName;
				FPath.Text = GDPath;
			} 
			else
			{
				System.Windows.MessageBox.Show("Please select your Geometry Dash executable", "Error", MessageBoxButton.OK);
			}
		}

		private void HexModify()
		{
			Server = Serverlink.Text;
		}

		private void InitProgram()
		{
			Openbtn.Click += OpenFileMenu;
		}

		public MainWindow()
		{
			InitializeComponent();
			InitProgram();
		}
	}
}
