
using System.Linq;
using ToDoList;
using ToDoList.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoListApp3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private MainViewModel getViewModel()
        {
            return DataContext as MainViewModel;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            RESTManager restManager = new RESTManager();
            restManager.deleteTask(getViewModel().CurrentTask);
            Frame.Navigate(typeof(Login));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            getViewModel().CurrentTask.Title = TaskTitleTextBox.Text;
            getViewModel().CurrentTask.Value = TaskValueTextBox.Text;

            RESTManager restManager = new RESTManager();
            restManager.updateTask(getViewModel().CurrentTask);
            Frame.Navigate(typeof(Login));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }
    }
}
