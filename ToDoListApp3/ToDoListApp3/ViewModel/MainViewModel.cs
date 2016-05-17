using System.Collections.ObjectModel;

namespace ToDoList.ViewModel
{
    public class MainViewModel : ViewModel
    {
        private static MainViewModel MVMinstance { get; set; }

        public static string OwnerId { get { return ownerId; } set { ownerId = value; } }
        private static string ownerId { get; set; }

        public ObservableCollection<ToDoTask> TaskList
            { get { return taskList; } set { taskList = value; OnPropertyChanged("TaskList"); } }
        private ObservableCollection<ToDoTask> taskList;

        public ToDoTask CurrentTask
            { get { return currentTask; } set { currentTask = value; OnPropertyChanged("CurrentTask"); } }
        private ToDoTask currentTask { get; set; }

        public static MainViewModel Singleton()
        {
            if (MVMinstance == null)
            {
                MVMinstance = new MainViewModel();
            }
            return MVMinstance;
        }
    }
}
