using ToDoList.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ToDoList
{
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddTask));
        }
    }
}
