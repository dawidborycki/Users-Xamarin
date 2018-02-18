#region Using

using Users.Common.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

#endregion

namespace Users.UWP
{
    public sealed partial class MainPage : Page
    {
        #region Fields

        private UsersViewModel usersViewModel = new UsersViewModel();

        #endregion

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Event handlers

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await usersViewModel.RetrieveUsers();
        }

        #endregion
    }
}