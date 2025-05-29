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
        public float Speed = 2f;
        public int CurrentWireIndex = 0;
        public int Diameter = 10;
        public DateTime? ActivationTime = null;
        public PointF? Target { get; private set; } = null;
        public bool IsMoving => Target.HasValue;
        public Carrier(CarrierType type, PointF position)
        {
            Type = type;
            Position = position;
        }

        public void SetTarget(PointF newTarget)
        {
            Target = newTarget;
        }

        public void Stop()
        {
            Target = null;
        }

        public void MoveTowardsTarget()
        {
            if (ActivationTime != null && DateTime.Now < ActivationTime.Value) return;
            if (!Target.HasValue) return;

            float dx = Target.Value.X - Position.X;
            float dy = Target.Value.Y - Position.Y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);

            if (distance <= Speed)
            {
                Position = Target.Value;
                Stop();
            }
            else
            {
                float stepX = Speed * dx / distance;
                float stepY = Speed * dy / distance;
                Position = new PointF(Position.X + stepX, Position.Y + stepY);
            }
        }

        public void Render(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, Position.X - Diameter / 2, Position.Y - Diameter / 2, Diameter, Diameter);
            }
            string symbolToDraw = (Type == CarrierType.Ion) ? "+" : "-";
            Color symbolColor = Color.White;

            float fontSize = Math.Max(1f, Diameter * 0.8f);

            using (Font symbolFont = new Font("Arial", fontSize, FontStyle.Bold))
            using (SolidBrush symbolBrush = new SolidBrush(symbolColor))
            using (StringFormat stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                g.DrawString(symbolToDraw, symbolFont, symbolBrush, Position.X, Position.Y, stringFormat);
            }
        }

    }
}
