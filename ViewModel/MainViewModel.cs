using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoDo.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace RoDo.ViewModel;

public partial class MainViewModel : ObservableObject
{

    private readonly string _dataFilePath;

    [ObservableProperty]
    private ObservableCollection<TaskItem> _taskItems;

    [ObservableProperty]
    private string _inputText;
    public MainViewModel()
    {
        TaskItems = new ObservableCollection<TaskItem>();
        _dataFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.json");
        LoadTasks();
    }
    private void LoadTasks()
    {
        if (File.Exists(_dataFilePath))
        {
            string json = File.ReadAllText(_dataFilePath);
            TaskItems = JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(json) ?? new ObservableCollection<TaskItem>();
        }
        else
        {
            TaskItems = new ObservableCollection<TaskItem>();
        }
    }

    private void SaveTasks()
    {
        string json = JsonSerializer.Serialize(TaskItems, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_dataFilePath, json);
    }

    [RelayCommand]
    private void AddTask()
    {
        if (!string.IsNullOrEmpty(InputText))
        {
            TaskItems.Add(new TaskItem(InputText));
            InputText = string.Empty;
            SaveTasks();
        }
    }

    [RelayCommand]
    private void RemoveTask(TaskItem taskItem)
    {
        if (TaskItems.Contains(taskItem))
        {
            TaskItems.Remove(taskItem);
            SaveTasks();
        }
    }

    [RelayCommand]
    private async Task TaskTap(TaskItem taskItem)
    {
        if (TaskItems.Contains(taskItem))
        {
            await Shell.Current.GoToAsync(nameof(TaskDetailPage), new Dictionary<string, object>
            {
                { "taskItemId", taskItem.Id }
            });
        }
    }
}

