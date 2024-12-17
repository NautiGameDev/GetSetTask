using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projecraft.Views
{
    /// <summary>
    /// Interaction logic for GoalItem.xaml
    /// </summary>
    public partial class GoalItem : UserControl
    {
        
        NewProfileView newProfileView;
        ProfileView profileView;
        ProfileController profileController;

        public GoalItem(NewProfileView newProfileView, string goal)
        {
            InitializeComponent();
            
            this.newProfileView = newProfileView;
            GoalText.Text = goal;
        }

        public GoalItem(ProfileController profileController, ProfileView profileView, string goal)
        {
            InitializeComponent();
            this.profileController = profileController;
            this.profileView = profileView;
            GoalText.Text = goal;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (newProfileView != null)
            {
                newProfileView.RemoveGoal(GoalText.Text);
            }
            else if (profileView != null)
            {
                profileView.RemoveGoal(GoalText.Text);
            }
        }
    }
}
