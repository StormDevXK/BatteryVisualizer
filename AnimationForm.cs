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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
            _battery.Cathode.GenerateCarriers(20);
            _battery.Anode.GenerateCarriers(20);


            foreach (var carrier in _battery.Cathode.Carriers)
            {
                float offsetX = _battery.Anode.X - _battery.Cathode.X;
                PointF anodePosition = new PointF(carrier.Position.X + offsetX, carrier.Position.Y);
                carrier.SetTarget(anodePosition);
            }
            int lastIndex = _battery.WirePath.Count - 1;
            foreach (var carrier in _battery.Anode.Carriers)
            {
                carrier.CurrentWireIndex = lastIndex;
                carrier.SetTarget(_battery.WirePath[lastIndex]);
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

        private void MoveCarriersAlongWire()
        {
            var wirePath = _battery.WirePath;
            Random rand = new Random();

            foreach (var carrier in _battery.Anode.Carriers.ToList())
            {
                if (!carrier.IsMoving)
                {
                    if (carrier.CurrentWireIndex >= 0)
                    {
                        carrier.SetTarget(wirePath[carrier.CurrentWireIndex]);
                    }
                    else
                    {
                        // Электрон прошёл весь путь по проводу
                        float relativeX = (float)rand.NextDouble() * _battery.Cathode.Width;
                        float relativeY = (float)rand.NextDouble() * _battery.Cathode.Height;

                        PointF finalPosition = new PointF(_battery.Cathode.X + relativeX, _battery.Cathode.Y + relativeY);
                        carrier.SetTarget(finalPosition);
                        continue;
                    }
                }

                carrier.MoveTowardsTarget();

                if (!carrier.IsMoving)
                {
                    carrier.CurrentWireIndex--;
                    if (carrier.CurrentWireIndex >= 0)
                    {
                        carrier.SetTarget(wirePath[carrier.CurrentWireIndex]);
                    }
                }
            }
        }



        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            MoveCarriersAlongWire();
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
