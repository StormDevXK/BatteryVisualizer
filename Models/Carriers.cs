using BatteryVisualizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryVisualizer.Models
{
    public class Carrier
    {
        public CarrierType Type;
        public Color Color => (Type == CarrierType.Ion) ? Color.FromArgb(220, 0, 0) : Color.FromArgb(0, 0, 220);
        public PointF Position;
        public float Speed = 2.0f;
        public int Diameter = 15;

        public Carrier(CarrierType type, PointF position)
        {
            Type = type;
            Position = position;
        }

        public void Render(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, Position.X - Diameter / 2, Position.Y - Diameter / 2, Diameter, Diameter);
            }
        }
    }
}
