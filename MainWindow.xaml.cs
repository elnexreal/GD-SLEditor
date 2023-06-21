using GD_SLEditor.Handling;
using System.IO;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows;
using forms = System.Windows.Forms;
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
        string executable;

        // Open button function
        private void OpenFileMenu(object sender, RoutedEventArgs e)
        {
            // Create a menu that lets you select the executable
            forms.OpenFileDialog dialog = new forms.OpenFileDialog
            {
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                AddExtension = true,
                Title = "Locate your Geometry Dash.exe file",
                Filter = "Geometry Dash Executable|*.exe"
            };

            // Check if user selected a file
            if (dialog.ShowDialog() == forms.DialogResult.OK)
            {
                executable = dialog.FileName;
                FPath.Text = executable;

                MessageBox.Show("Make sure you have a backup of your GD executable", "Warning", MessageBoxButton.OK);
            }
            // Otherwise show a messagebox
            else
            {
                MessageBox.Show("Please select your Geometry Dash executable", "Operation cancelled", MessageBoxButton.OK);
            }
        }
        private void ApplyButton(object sender, RoutedEventArgs e)
        {
            string server = Serverlink.Text;
            if (server.Length == 33)
            {
                try
                {
                    HexHandler.HexModify(executable, server);

                    MessageBox.Show("Server url changed to" + server);
                }
                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Your server URL must have exactly 33 characters", "Warning", MessageBoxButton.OK);
            }
        }

        private void InitProgram()
        {
            // Link the button click to functions
            Openbtn.Click += OpenFileMenu;
            Applybtn.Click += ApplyButton;
        }

        public MainWindow()
        {
            InitializeComponent();
            InitProgram();
        }
    }
}
