#region Using

using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Users.Common.Helpers;
using Users.Common.Models;

#endregion

namespace Users.iOS.CustomTableSources
{
    public class UsersTableSource : UITableViewSource
    {
        #region Fields

        private IEnumerable<User> users;

        private const string cellId = "UserCell";

        #endregion

        #region Constructor

        public UsersTableSource(IEnumerable<User> users)
        {
            Check.IsNull(users);

            this.users = users;
        }

        #endregion

        #region Methods (Public)

        public override UITableViewCell GetCell(
            UITableView tableView, NSIndexPath indexPath)
        {
            // Get item to display
            var user = users.ElementAt(indexPath.Row);

            // Try to reuse a cell before creating a new one
            var cell = tableView.DequeueReusableCell(cellId)
                ?? new UITableViewCell(UITableViewCellStyle.Value1, cellId);

            // Configure cell properties
            cell.TextLabel.Text = user.Name;
            cell.DetailTextLabel.Text = user.Company.Name;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return users.Count();
        }

        #endregion
    }
}