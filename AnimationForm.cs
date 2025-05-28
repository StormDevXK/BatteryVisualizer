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
        private BatteryType _selectedBatteryType;
        private int _selectedCapacity;
        public AnimationForm(SettingsForm parentForm, BatteryType selectedBatteryType, int selectedCapacity)
        //public AnimationForm(SettingsForm parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            _selectedBatteryType = selectedBatteryType;
            _selectedCapacity = selectedCapacity;
            panelAnimation.Paint += PanelAnimation_Paint;
            panelAnimation.DoubleBuffered(true);
            StartBatteryAnimation();


            // Таймер анимации
            _animationTimer = new System.Windows.Forms.Timer();
            _animationTimer.Interval = 16; // 60 FPS
            _animationTimer.Tick += AnimationTimer_Tick;
            _animationTimer.Start();
            _selectedCapacity = selectedCapacity;
        }

        private void StartBatteryAnimation()
        {
            _battery = new Battery(_selectedBatteryType.Voltage, trackBarResistance.Value);
            _battery.Capacity = _selectedCapacity;
            _battery.Cathode.GenerateCarriers(_battery.Capacity / 100);
            _battery.Anode.GenerateCarriers(_battery.Capacity / 100);
            _battery.Resistance = (double)trackBarResistance.Value / 10;


            foreach (var carrier in _battery.Cathode.Carriers)
            {
                float offsetX = _battery.Anode.X - _battery.Cathode.X;
                PointF anodePosition = new PointF(carrier.Position.X + offsetX, carrier.Position.Y);
                carrier.SetTarget(anodePosition);
            }
            foreach (var carrier in _battery.Anode.Carriers)
            {
                if (_battery.IsCharging)
                {
                    carrier.SetTarget(_battery.WirePath[0]);
                }
                else
                {
                    int lastIndex = _battery.WirePath.Count - 1;
                    carrier.SetTarget(_battery.WirePath[lastIndex]);
                }
            }

        }

        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _battery.Render(g);
        }

        private void MoveCarriersAlongWire()
        {
            var wirePath = _battery.WirePath.ToList();
            Random rand = new Random();
            Electrode targetElectrode = _battery.Anode;
            if (!_battery.IsCharging)
            {
                wirePath.Reverse();
                targetElectrode = _battery.Cathode;
            }

            foreach (var carrier in _battery.Anode.Carriers.ToList())
            {
                if (!carrier.IsMoving)
                {
                    if (carrier.CurrentWireIndex < wirePath.Count)
                    {
                        carrier.SetTarget(wirePath[carrier.CurrentWireIndex]);
                    }
                    //else
                    else if (carrier.CurrentWireIndex == wirePath.Count)
                    {
                        // Электрон прошёл весь путь по проводу
                        float relativeX = (float)rand.NextDouble() * targetElectrode.Width;
                        float relativeY = (float)rand.NextDouble() * targetElectrode.Height;

                        PointF finalPosition = new PointF(targetElectrode.X + relativeX, targetElectrode.Y + relativeY);
                        carrier.SetTarget(finalPosition);
                        continue;
                    }
                }

                carrier.MoveTowardsTarget();

                if (!carrier.IsMoving)
                {
                    carrier.CurrentWireIndex++;
                }
            }
        }

        private void ChangeDirection()
        {
            int wireLength = _battery.WirePath.Count;

            foreach (var carrier in _battery.Anode.Carriers)
            {
                // Если электрон уже прошёл весь путь (например, в фазе перехода в электрод), просто пересоздаем его путь
                if (carrier.CurrentWireIndex > wireLength)
                {
                    carrier.CurrentWireIndex = 0;
                    continue;
                }

                // Инвертируем индекс: движение в обратную сторону
                carrier.CurrentWireIndex = wireLength - carrier.CurrentWireIndex;
                carrier.Stop(); // Принудительно останавливаем, чтобы начать движение к новому target'у
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            MoveCarriersAlongWire();
            foreach (var carrier in _battery.Cathode.Carriers)
                carrier.MoveTowardsTarget();

            foreach (var carrier in _battery.Anode.Carriers)
                carrier.MoveTowardsTarget();

            labelChargeLevel.Text = $"Уровень заряда: {_battery.CurrentCharge}%";
            labelCurrentValue.Text = $"Сила тока: {_battery.Current} А";
            labelResistanceValue.Text = $"Сопротивление: {_battery.Resistance} Ом";
            labelVoltageValue.Text = $"Напряжение: {_battery.Voltage} В";

            panelAnimation.Invalidate(); // Перерисовка панели
        }

        private void buttonReturnToMenu_Click(object sender, EventArgs e)
        {
            _animationTimer.Stop();
            _parentForm.Show();
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            StartBatteryAnimation();
        }

        private void trackBarResistance_Scroll(object sender, EventArgs e)
        {
            _battery.Resistance = (double)trackBarResistance.Value / 10;
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (!_battery.IsCharging)
            {
                foreach (var carrier in _battery.Cathode.Carriers)
                {
                    float offsetX = carrier.Position.X - _battery.Cathode.X + (float)rand.NextDouble() * _battery.Cathode.Width;
                    carrier.SetTarget(new PointF(carrier.Position.X + _battery.Cathode.Width - offsetX, carrier.Position.Y));
                }
                ChangeDirection();
                _battery.IsCharging = true;
            }
        }

        private void buttonDischarge_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            if (_battery.IsCharging)
            {
                foreach (var carrier in _battery.Cathode.Carriers)
                {
                    float offsetX = carrier.Position.X - _battery.Anode.X + (float)rand.NextDouble() * _battery.Anode.Width;
                    carrier.SetTarget(new PointF(carrier.Position.X + _battery.Anode.Width - offsetX, carrier.Position.Y));
                }
                ChangeDirection();
                _battery.IsCharging = false;
            }
        }
    }
}
