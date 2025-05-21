using BatteryVisualizer.Models;
using BatteryVisualizer.Utils;

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
            AnimationForm animationForm = new AnimationForm(this, comboBatteryType.SelectedItem as BatteryType, decimal.ToInt32(numericUpDownCapacity.Value));
            animationForm.Show();
            this.Hide();
        }
    }
}
