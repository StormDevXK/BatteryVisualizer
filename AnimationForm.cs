using BatteryVisualizer.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryVisualizer
{
    public partial class AnimationForm : Form
    {
        private SettingsForm _parentForm;
        private readonly BatteryRenderer _renderer = new BatteryRenderer();
        public AnimationForm(SettingsForm parentForm)
        {
            InitializeComponent();
            panelAnimation.Paint += PanelAnimation_Paint;
            _parentForm = parentForm;
        }

        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            _renderer.PanelAnimation_Paint(sender, e);
        }

        private void buttonReturnToMenu_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }
    }
}
