#region Using

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Users.Common.Models;
using Users.Common.RestClients;

#endregion

namespace Users.Common.ViewModels
{
    public class UsersViewModel
    {
        #region Properties

        public ObservableCollection<User> Users { get; private set; }
            = new ObservableCollection<User>();

        #endregion

        #region Fields

        private UsersClient usersClient = new UsersClient();

        #endregion

        #region Methods (Public)

        public async Task RetrieveUsers()
        {
            var users = await usersClient.GetAll();

            Users.Clear();

            foreach (User user in users)
            {
                Users.Add(user);
            }
        }

        #endregion
    }
}
