using BatteryVisualizer.Models;
using BatteryVisualizer.Utils;

namespace BatteryVisualizer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            comboBatteryType.DataSource = BatteryType.All.ToList();
            comboBatteryType.SelectedIndex = 0;
        }

        public void buttonStartAnimation_Click(object sender, EventArgs e)
        {
            AnimationForm animationForm = new AnimationForm(this, comboBatteryType.SelectedItem as BatteryType, decimal.ToInt32(numericUpDownCapacity.Value));
            animationForm.Show();
            this.Hide();
        }
    }
}
