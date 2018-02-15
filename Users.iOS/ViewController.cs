#region Using

using CoreGraphics;
using System;
using System.Threading.Tasks;
using UIKit;
using Users.Common.DataSources;
using Users.iOS.CustomTableSources;

#endregion

namespace Users.iOS
{
    public partial class ViewController : UIViewController
    {
        #region Constructor

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        #endregion

        #region Methods (Public)

        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create users repository and use it to instantiate table source
            var usersTableSource = await CreateUsersTableSource();

            // ... and use it to populate the table view
            CreateUsersTableView(usersTableSource);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();            
        }

        #endregion

        #region Methods (Private)

        private async Task<UsersTableSource> CreateUsersTableSource()
        {
            var usersViewModel = new UsersViewModel();

            await usersViewModel.RetrieveUsers();

            return new UsersTableSource(usersViewModel.Users);
        }

        private void CreateUsersTableView(UsersTableSource usersTableSource)
        {
            // Create and display table view
            var table = new UITableView(GetFrameWithVerticalMargin(20))
            {
                Source = usersTableSource
            };

            Add(table);
        }

        private CGRect GetFrameWithVerticalMargin(nfloat offset)
        {
            var rect = View.Frame;

            rect.Y = offset;
            rect.Height -= offset;

            return rect;
        }

        #endregion
    }
}