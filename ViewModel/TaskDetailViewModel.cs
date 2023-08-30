using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoDo.Model;
using System.Collections.ObjectModel;

namespace RoDo.ViewModel;

[QueryProperty("TaskItem", "TaskItem")]
public partial class TaskDetailViewModel : ObservableObject
{
    private MainViewModel _mainViewModel;
    private ObservableCollection<TaskItem> _taskItems;

    [ObservableProperty]
    private TaskItem _taskItem;

    public TaskDetailViewModel(MainViewModel mainViewModel)
    {
        _mainViewModel = mainViewModel;
        _taskItems = _mainViewModel.TaskItems;
    }
    public void SaveTaskItemData()
    {
        if (TaskItem != null)
        {
            int index = _taskItems.IndexOf(_taskItems.FirstOrDefault(item => item.Id == TaskItem.Id));
            if (index >= 0)
            {
                _taskItems[index].Title = TaskItem.Title;
                _taskItems[index].Note = TaskItem.Note;
                _taskItems[index].IsDone = TaskItem.IsDone;
            }
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        SaveTaskItemData();
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task RemoveTask()
    {
        if (TaskItem != null)
        {
            _taskItems.Remove(TaskItem);
            TaskItem = null;
        }
        await GoBack();
    }
}
