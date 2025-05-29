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
        private int _electronCounter;
        private readonly Random _rand = new Random();
        private readonly int _startMoveDelay = 500;
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
            _electronCounter = _battery.Anode.Carriers.Count;

            float carrierSpeed = ExtensionsMethods.SpeedMath(trackBarResistance);
            foreach (var carrier in _battery.Cathode.Carriers)
                carrier.Speed = carrierSpeed;
            foreach (var carrier in _battery.Anode.Carriers)
                carrier.Speed = carrierSpeed;

            DateTime baseTime = DateTime.Now;
            for (int i = 0; i < _battery.Cathode.Carriers.Count; i++)
            {
                var carrier = _battery.Cathode.Carriers[i];
                float offsetX = carrier.Position.X - _battery.Anode.X + (float)_rand.NextDouble() * _battery.Anode.Width;
                carrier.SetTarget(new PointF(carrier.Position.X + _battery.Anode.Width - offsetX, carrier.Position.Y));
                carrier.ActivationTime = baseTime.AddMilliseconds(i * _startMoveDelay);
            }

            for (int i = 0; i < _battery.Anode.Carriers.Count; i++)
            {
                var carrier = _battery.Anode.Carriers[i];
                carrier.ActivationTime = baseTime.AddMilliseconds(i * _startMoveDelay);
                carrier.CurrentWireIndex = 0;
                carrier.Stop();
            }
        }

        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            _battery.Render(g);
        }

        private void MoveCarriersAlongWire(DateTime baseTime)
        {
            var wirePath = _battery.WirePath.ToList();
            Electrode targetElectrode = _battery.Anode;
            if (!_battery.IsCharging)
            {
                wirePath.Reverse();
                targetElectrode = _battery.Cathode;
            }

            for (int i = 0; i < _battery.Anode.Carriers.Count; i++)
            {
                var carrier = _battery.Anode.Carriers[i];
                if (!carrier.IsMoving)
                {
                    if (carrier.ActivationTime.HasValue && baseTime < carrier.ActivationTime.Value) continue;
                    if (carrier.CurrentWireIndex < wirePath.Count)
                    {
                        carrier.SetTarget(wirePath[carrier.CurrentWireIndex]);
                    }
                    else if (carrier.CurrentWireIndex == wirePath.Count)
                    {
                        float relativeX = (float)_rand.NextDouble() * targetElectrode.Width;
                        float relativeY = (float)_rand.NextDouble() * targetElectrode.Height;

                        PointF finalPosition = new PointF(targetElectrode.X + relativeX, targetElectrode.Y + relativeY);
                        carrier.SetTarget(finalPosition);
                        carrier.CurrentWireIndex++;
                        if (_battery.IsCharging) _electronCounter++;
                        else _electronCounter--;
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

            DateTime baseTime = DateTime.Now;

            for (int i = 0; i < _battery.Anode.Carriers.Count; i++)
            {
                var carrier = _battery.Anode.Carriers[i];
                carrier.ActivationTime = baseTime.AddMilliseconds(i * _startMoveDelay); if (carrier.CurrentWireIndex > wireLength)
                {
                    carrier.CurrentWireIndex = 0;
                    continue;
                }

                carrier.CurrentWireIndex = wireLength - carrier.CurrentWireIndex;
                carrier.Stop();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            MoveCarriersAlongWire(DateTime.Now);
            foreach (var carrier in _battery.Cathode.Carriers)
                carrier.MoveTowardsTarget();

            foreach (var carrier in _battery.Anode.Carriers)
                carrier.MoveTowardsTarget();

            _battery.CurrentCharge = (int)((float)_electronCounter / (float)_battery.Anode.Carriers.Count * 100);// доделать стабильный механизм при ручной разрядке зарядке
            //_battery.CurrentCharge = _electronCounter;
            labelBatteryStatus.Text = _battery.IsCharging ? "Зарядка" : "Разрядка"; 
            labelChargeLevel.Text = $"Уровень заряда: {_battery.CurrentCharge}%";
            labelCurrentValue.Text = $"Сила тока: {_battery.Current} А";
            labelResistanceValue.Text = $"Сопротивление: {_battery.Resistance} Ом";
            labelVoltageValue.Text = $"Напряжение: {_battery.Voltage} В";

            panelAnimation.Invalidate();
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
            float carrierSpeed = ExtensionsMethods.SpeedMath(trackBarResistance);
            foreach (var carrier in _battery.Cathode.Carriers)
                carrier.Speed = carrierSpeed;
            foreach (var carrier in _battery.Anode.Carriers)
                carrier.Speed = carrierSpeed;
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            if (!_battery.IsCharging)
            {
                DateTime baseTime = DateTime.Now;
                for (int i = 0; i < _battery.Cathode.Carriers.Count; i++)
                {
                    var carrier = _battery.Cathode.Carriers[i];
                    float offsetX = carrier.Position.X - _battery.Cathode.X + (float)_rand.NextDouble() * _battery.Cathode.Width;
                    carrier.SetTarget(new PointF(carrier.Position.X + _battery.Cathode.Width - offsetX, carrier.Position.Y));
                    carrier.ActivationTime = baseTime.AddMilliseconds(i * _startMoveDelay);
                }

                ChangeDirection();
                _battery.IsCharging = true;
            }
        }

        private void buttonDischarge_Click(object sender, EventArgs e)
        {
            if (_battery.IsCharging)
            {
                DateTime baseTime = DateTime.Now;
                for (int i = 0; i < _battery.Cathode.Carriers.Count; i++)
                {
                    var carrier = _battery.Cathode.Carriers[i];
                    float offsetX = carrier.Position.X - _battery.Anode.X + (float)_rand.NextDouble() * _battery.Anode.Width;
                    carrier.SetTarget(new PointF(carrier.Position.X + _battery.Anode.Width - offsetX, carrier.Position.Y));
                    carrier.ActivationTime = baseTime.AddMilliseconds(i * _startMoveDelay);
                }
                ChangeDirection();
                _battery.IsCharging = false;
            }
        }

        private void AnimationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_parentForm.Close();
        }
    }
}
