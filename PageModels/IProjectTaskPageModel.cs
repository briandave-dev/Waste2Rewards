using CommunityToolkit.Mvvm.Input;
using Waste2Rewards.Models;

namespace Waste2Rewards.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}