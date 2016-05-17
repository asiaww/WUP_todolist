using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ToDoList.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTask : Page
    {
        public AddTask()
        {
            this.InitializeComponent();
            DataContext = MainViewModel.Singleton();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            RESTManager restManager = new RESTManager();
            ToDoTask newTask = new ToDoTask { Id = 0, Title = NewTaskTitleTextBox.Text, Value = NewTaskValueTextBox.Text, OwnerId = MainViewModel.OwnerId, CreatedAt = DateTime.Now.ToString() };
            restManager.postTask(newTask);

            Frame.Navigate(typeof(Login));
        }
    }
}
