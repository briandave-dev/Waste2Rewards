using Waste2Rewards.Models;
using Waste2Rewards.PageModels;

namespace Waste2Rewards.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}