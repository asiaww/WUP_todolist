using ToDoList.ViewModel;
using ToDoListApp3.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoList
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.OwnerId = UsernameTextBox.Text;
            Frame.Navigate(typeof(Login));
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }
    }
}
