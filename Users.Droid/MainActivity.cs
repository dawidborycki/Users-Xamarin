#region Using

using Android.App;
using Android.OS;
using Users.Droid.CustomAdapters;
using System.Threading.Tasks;
using Users.Common.ViewModels;

#endregion

namespace Users.Droid
{
    [Activity(Label = "Users.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : ListActivity
    {
        #region Methods (Protected)

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ListAdapter = await CreateUsersListAdapter();
        }

        #endregion

        #region Methods (Private)

        private async Task<UsersListAdapter> CreateUsersListAdapter()
        {
            var usersViewModel = new UsersViewModel();

            await usersViewModel.RetrieveUsers();

            return new UsersListAdapter(this, usersViewModel.Users);
        }

        #endregion
    }
}

