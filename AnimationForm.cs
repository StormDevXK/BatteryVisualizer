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
using BatteryVisualizer.Models;
using BatteryVisualizer.Utils;
using System.Drawing.Printing;

namespace BatteryVisualizer
{
    public partial class AnimationForm : Form
    {
        private SettingsForm _parentForm;
        //private readonly BatteryRenderer _renderer = new BatteryRenderer();
        public AnimationForm(SettingsForm parentForm)
        {
            InitializeComponent();
            panelAnimation.Paint += PanelAnimation_Paint;
            _parentForm = parentForm;
        }

        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Battery battery = new Battery();
            battery.Render(g);
        }

        private void buttonReturnToMenu_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }
    }
}
