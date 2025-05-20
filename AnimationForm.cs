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
        private Battery _battery;
        private System.Windows.Forms.Timer _animationTimer;
        public AnimationForm(SettingsForm parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            panelAnimation.Paint += PanelAnimation_Paint;
            panelAnimation.DoubleBuffered(true); // Включаем двойную буферизацию
            _battery = new Battery();
            _battery.Cathode.GenerateCarriers(5);
            _battery.Anode.GenerateCarriers(5);


            foreach (var carrier in _battery.Cathode.Carriers)
            {
                // Устанавливаем цели перемещения частиц
                PointF anodeCenter = new PointF(
                    carrier.Position.X + (_battery.Anode.X - _battery.Cathode.X),
                    carrier.Position.Y
                );
                carrier.SetTarget(anodeCenter);
            }

            // Таймер анимации
            _animationTimer = new System.Windows.Forms.Timer();
            _animationTimer.Interval = 16; // 60 FPS
            _animationTimer.Tick += AnimationTimer_Tick;
            _animationTimer.Start();
        }

        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _battery.Render(g);
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            foreach (var carrier in _battery.Cathode.Carriers)
                carrier.MoveTowardsTarget();

            foreach (var carrier in _battery.Anode.Carriers)
                carrier.MoveTowardsTarget();

            panelAnimation.Invalidate(); // Перерисовка панели
        }

        private void buttonReturnToMenu_Click(object sender, EventArgs e)
        {
            _animationTimer.Stop();
            _parentForm.Show();
            this.Close();
        }
    }
}
