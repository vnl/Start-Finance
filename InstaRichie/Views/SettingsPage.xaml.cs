using InstaRichie.Models;
using SQLite;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace InstaRichie.Views
{
    public sealed partial class SettingsPage : Page
    {
        SQLiteConnection conn; // adding an SQLite connection
        string path = "Findata.sqlite"; // Name of the database must be unique 

        Template10.Services.SerializationService.ISerializationService _SerializationService;

        public SettingsPage()
        {
            InitializeComponent();
            _SerializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_SerializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void ResetMan_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            conn = new SQLiteConnection(path);
            /// deleteing table
            conn.DropTable<Accounts>();
            conn.DropTable<Assets>();
            conn.DropTable<Debt>();
            conn.DropTable<Transactions>();
            conn.DropTable<WishList>();
        }

        private void BusyTextTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BusyTextTextBox.Text.ToString() == "reset")
            {
                ResetMan.IsEnabled = true;
            }
            else
            {
                ResetMan.IsEnabled = false;
            }

        }

        private void BusyTextTextBox_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (BusyTextTextBox.Text.ToString() == "reset")
            {
                ResetMan.IsEnabled = true;
            }
            else
            {
                ResetMan.IsEnabled = false;
            }
        }
    }
}
