using Users.Common.DataSources;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Users.UWP
{
    public sealed partial class MainPage : Page
    {
        private UsersViewModel usersViewModel = new UsersViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await usersViewModel.RetrieveUsers();
        }
    }
}
