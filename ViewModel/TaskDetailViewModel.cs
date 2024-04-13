using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoDo.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace RoDo.ViewModel;

[QueryProperty("TaskItemId", "TaskItemId")]
public partial class TaskDetailViewModel : ObservableObject
{
    private ObservableCollection<TaskItem> _taskItems;
    private TaskItem _taskItem;

    [ObservableProperty]
    private int _taskItemId;

    public TaskDetailViewModel(MainViewModel mainViewModel) 
    {
        _taskItems = LoadTasks();
        _taskItem = GetTargetTaskItem();
        Title = _taskItem.Title;
        Note = _taskItem.Note;
        IsDone = _taskItem.IsDone;
    }

    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    private string _note;
    [ObservableProperty]
    private bool _isDone;

    private TaskItem GetTargetTaskItem()
    {
        TaskItem targetTaskItem = _taskItems.FirstOrDefault(item => item.Id == TaskItemId);
        if (targetTaskItem != null)
        {
            return targetTaskItem;
        }
        return null;
    }
    private ObservableCollection<TaskItem> LoadTasks()
    {
        string dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.json");

        if (File.Exists(dataFilePath))
        {
            string json = File.ReadAllText(dataFilePath);
            return JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(json) ?? new ObservableCollection<TaskItem>();
        }
        else
        {
            return new ObservableCollection<TaskItem>();
        }
    }
    private async Task SaveTasks()
    {
        if(TaskItemId > 0)
        {
            string dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.json");
            string json = JsonSerializer.Serialize(_taskItems, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(dataFilePath, json);
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await SaveTasks();
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task RemoveTask()
    {
        if (TaskItemId > 0)
        {
            TaskItem taskToRemove = _taskItems.FirstOrDefault(item => item.Id == TaskItemId);
            if (taskToRemove != null)
            {
                _taskItems.Remove(taskToRemove);
                await SaveTasks();
                TaskItemId = 0;
            }
        }
        await GoBack();
    }
}
