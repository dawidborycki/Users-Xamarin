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
    public class UsersListAdapter : BaseAdapter<User>
    {
        #region Properties

        public override User this[int position] => users.ElementAt(position);
        public override int Count => users.Count();

        #endregion

        #region Fields

        private IEnumerable<User> users;
        private Activity context;

        #endregion

        #region Constructor

        public UsersListAdapter(Activity context, 
            IEnumerable<User> users) : base()
        {
            Check.IsNull(context);
            this.context = context;

            Check.IsNull(users);
            this.users = users;
        }

        #endregion

        #region Methods (Public)        

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get item to display
            var user = this[position];

            // Try to reuse view before creating the new one
            var view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(
                    Android.Resource.Layout.SimpleListItem2, null);
            }            

            // Configure cell properties
            view.FindViewById<TextView>(
                Android.Resource.Id.Text1).Text = user.Name;
            view.FindViewById<TextView>(
                Android.Resource.Id.Text2).Text = user.Company.Name;

            return view;
        }

        public override long GetItemId(int position)
        {
            return this[position].Id;
        }

        #endregion
    }
}