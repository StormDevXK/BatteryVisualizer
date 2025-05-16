using BatteryVisualizer.Models;

namespace BatteryVisualizer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public void buttonStartAnimation_Click(object sender, EventArgs e)
        {
            AnimationForm animationForm = new AnimationForm(this);
            animationForm.Show();
            this.Hide();
        }
    }
}
