#region Using

using Android.App;
using Android.OS;
using Users.Common.DataSources;
using Users.Droid.CustomAdapters;
using Users.Common.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

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

            ListAdapter = new UsersListAdapter(this, await GetUsers());
        }

        #endregion

        #region Methods (Private)

        private async Task<IEnumerable<User>> GetUsers()
        {
            var usersViewModel = new UsersViewModel();

            await usersViewModel.RetrieveUsers();

            return usersViewModel.Users;
        }

        #endregion
    }
}

