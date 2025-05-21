using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatteryVisualizer.Utils;

namespace BatteryVisualizer.Models
{
    public class Battery
    {
        public int X = 63;
        public int Y = 189;
        public int Width = 380;
        public int Height = 250;

        public Color batteryColor = Color.FromArgb(240, 240, 240);
        public Color separatorColor = Color.Black;
        public Color electrodeFillColor = Color.FromArgb(200, 200, 200);
        public Color WireColor = Color.FromArgb(220, 100, 0);

        public Electrode Cathode;
        public Electrode Anode;

        public List<Point> WirePath;

        public bool IsCharging = false;
        private int _currentCharge = 100; // Уровень заряда от 0 до 100
        public int CurrentCharge
        {
            get => _currentCharge;
            set => _currentCharge = Math.Clamp(value, 0, 100);
        }
        public double Voltage;
        public double Resistance;
        public double Current => Resistance != 0 ? (double)Decimal.Round((decimal)(Voltage / Resistance), 2)   : 0;
        public int Capacity = 1000;

        public Battery(double newVoltage, int newResistance)
        {
            Cathode = new Electrode(ElectrodeType.Cathode, X + 24, Y, Color.FromArgb(126, 126, 126));
            Anode = new Electrode(ElectrodeType.Anode, X + 291, Y, Color.FromArgb(200, 200, 200));
            WirePath = new List<Point>
            {
                new Point(X + 54, Y),
                new Point(X + 54, Y - 69),
                new Point(X + 325, Y - 69),
                new Point(X + 324, Y)
            };
            Voltage = newVoltage;
            Resistance = newResistance;
        }

        public void Render(Graphics g)
        {
            // Основная рамка аккумулятора
            using (Pen borderPen = new Pen(Color.Black, 3))
            using (SolidBrush batteryBrush = new SolidBrush(batteryColor))
            {
                g.FillRectangle(batteryBrush, X, Y, Width, Height);
                g.DrawRectangle(borderPen, X, Y, Width, Height);
            }
            
            // Сепаратор (пунктирная вертикальная линия)
            using (Pen separatorPen = new Pen(separatorColor, 4))
            {
                separatorPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(separatorPen, X + 190, Y, X + 190, Y + 205);
            }

            // Провода (горизонтальный и вертикальные)
            using (Pen wirePen = new Pen(WireColor, 3))
            {
                for (int i = 0; i < WirePath.Count - 1; i++)
                {
                    g.DrawLine(wirePen, WirePath[i], WirePath[i + 1]);
                }
            }

            Cathode.Render(g);
            Anode.Render(g);
            Cathode.RenderCarriers(g);
            Anode.RenderCarriers(g);
        }
    }
}
