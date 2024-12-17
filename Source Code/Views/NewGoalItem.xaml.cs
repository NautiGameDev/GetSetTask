using System.Media;
using System.Windows;
using System.Windows.Controls;


namespace Projecraft.Views
{
    


    public partial class NewGoalItem : UserControl
    {
        NewProfileView newProfileView {  get; set; }
        ProfileView profileView { get; set; }

        bool hasBeenClicked = false;

        public NewGoalItem(NewProfileView newProfileView)
        {
            InitializeComponent();
            this.newProfileView = newProfileView;
        }

        public NewGoalItem(ProfileView profileView)
        {
            InitializeComponent();
            this.profileView = profileView;

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoalItem.Text.Trim() != "")
            {
                try
                {
                    if (newProfileView != null)
                    {
                        newProfileView.AddGoal(GoalItem.Text);
                    }
                    else if (profileView != null)
                    {
                        profileView.AddGoal(GoalItem.Text);
                    }
                }
                catch (Exception ex)
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Enter information for your goal.");
            }
            
        }

        private void GoalItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                GoalItem.Text = "";
                GoalItem.FontWeight = FontWeights.Medium;
                hasBeenClicked = true;
            }
        }
    }
}
