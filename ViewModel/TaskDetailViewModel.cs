using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoDo.Data;
using RoDo.Model;
using System.Collections.ObjectModel;

namespace RoDo.ViewModel;

[QueryProperty("TaskItemId", "taskItemId")]
public partial class TaskDetailViewModel : ObservableObject
{
    private int _taskItemId;

    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    private string _note;
    [ObservableProperty]
    private bool _isDone;

    public int TaskItemId
    {
        set
        {
            _taskItemId = value;
            LoadTaskItem();
        }
    }

    private async void LoadTaskItem()
    {
        using (var db = new AppDbContext())
        {
            var taskItem = await db.TaskItems.FindAsync(_taskItemId);

            if (taskItem != null)
            {
                Title = taskItem.Title;
                Note = taskItem.Note;
                IsDone = taskItem.IsDone;
            }
        }
    }

    private async Task SaveTaskItemData()
    {
        using (var db = new AppDbContext())
        {
            var taskItem = await db.TaskItems.FindAsync(_taskItemId);
            if (taskItem != null)
            {
                taskItem.Title = Title;
                taskItem.Note = Note;
                taskItem.IsDone = IsDone;
                await db.SaveChangesAsync();
            }
        }
    }

    [RelayCommand]
    private async Task GoBack()
    {
        await SaveTaskItemData();
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task RemoveTask()
    {
        using (var db = new AppDbContext())
        {
            var taskItem = await db.TaskItems.FindAsync(_taskItemId);
            if (taskItem != null)
            {
                db.TaskItems.Remove(taskItem);
                await db.SaveChangesAsync();
            }
            await GoBack();
        }
    }
}
