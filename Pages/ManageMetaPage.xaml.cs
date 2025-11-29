namespace Waste2Rewards.Pages
{
    public partial class ManageMetaPage : ContentPage
    {
        public ManageMetaPage(ManageMetaPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}