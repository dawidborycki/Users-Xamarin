#region Using

using Android.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;
using Users.Common.Helpers;
using Users.Common.Models;

#endregion

namespace Users.Droid.CustomAdapters
{
    public class UsersListAdapter : BaseAdapter<string>
    {
        #region Properties

        public override string this[int position] => users.ElementAt(position).Name;
        public override int Count => users.Count();

        #endregion

        #region Fields

        private IEnumerable<User> users;
        private Activity context;

        #endregion

        #region Constructor

        public UsersListAdapter(Activity context, IEnumerable<User> users) : base()
        {
            Check.IsNull(context);
            this.context = context;

            Check.IsNull(users);
            this.users = users;            
        }

        #endregion

        #region Methods (Public)

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            var user = users.ElementAt(position);

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = user.Name;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = user.Company.Name;

            return view;
        }

        #endregion
    }
}