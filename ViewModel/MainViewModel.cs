using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using RoDo.Data;
using RoDo.Model;
using System.Collections.ObjectModel;

namespace RoDo.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TaskItem> _taskItems;

    [ObservableProperty]
    private string _inputText;
    public MainViewModel()
    {
        TaskItems = new ObservableCollection<TaskItem>();
        LoadTaskItems();
    }
    private async void LoadTaskItems()
    {
        using var db = new AppDbContext();
        var taskItems = await db.TaskItems.ToListAsync();
        TaskItems = new ObservableCollection<TaskItem>(taskItems);
    }

    [RelayCommand]
    private async Task AddTask()
    {
        if (string.IsNullOrEmpty(InputText))
            return;

        using (var db = new AppDbContext())
        {
            db.TaskItems.Add(new TaskItem { Title = InputText });
            await db.SaveChangesAsync();
        }

        InputText = string.Empty;
    }

    [RelayCommand]
    private async Task RemoveTask(TaskItem taskItem)
    {
        using (var db = new AppDbContext())
        {
            var itemToRemove = await db.TaskItems.FindAsync(taskItem.Id);

            if (itemToRemove != null)
            {
                db.TaskItems.Remove(itemToRemove);
                await db.SaveChangesAsync();
            }
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

