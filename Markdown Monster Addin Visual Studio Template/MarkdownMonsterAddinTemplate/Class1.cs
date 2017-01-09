using System;
using System.Windows;
using FontAwesome.WPF;
using MarkdownMonster.AddIns;

namespace $safeprojectname$
{
    public class $safeitemname$ : MarkdownMonster.AddIns.MarkdownMonsterAddin
    {
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            Id = "$safeitemname$";

            // by passing in the add in you automatically
            // hook up OnExecute/OnExecuteConfiguration/OnCanExecute
            var menuItem = new AddInMenuItem(this)
            {
                Caption = "Sample Add in",

                // if an icon is specified it shows on the toolbar
                // if not the add-in only shows in the add-ins menu
                FontawesomeIcon = FontAwesomeIcon.Bullhorn
            };

            // if you don't want to display config or main menu item clear handler
            //menuItem.ExecuteConfiguration = null;

            // Must add the menu to the collection to display menu and toolbar items            
            this.MenuItems.Add(menuItem);
        }

        public override void OnExecute(object sender)
        {
            MessageBox.Show("Hello from your sample Addin", "Markdown Addin Sample",
                            MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override void OnExecuteConfiguration(object sender)
        {
            MessageBox.Show("Configuration for our sample Addin", "Markdown Addin Sample",
                            MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public override bool OnCanExecute(object sender)
        {
            return true;
        }

    }
}
