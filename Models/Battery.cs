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

        public void Render(Graphics g)
        {
            // Основная рамка аккумулятора
            using (Pen borderPen = new Pen(Color.Black, 3))
            using (SolidBrush batteryBrush = new SolidBrush(batteryColor))
            {
                g.FillRectangle(batteryBrush, X, Y, Width, Height);
                g.DrawRectangle(borderPen, X, Y, Width, Height);
            }

            // Левая часть (область электрода, серая)
            using (SolidBrush electrodeBrush = new SolidBrush(electrodeFillColor))
            {
                //g.FillRectangle(electrodeBrush, X + 24, Y, 65, 205);
            }

            // Правая часть (область электрода, серая)
            //g.FillRectangle(new SolidBrush(electrodeFillColor), X + 291, Y, 65, 205);

            // Сепаратор (пунктирная вертикальная линия)
            using (Pen separatorPen = new Pen(separatorColor, 4))
            {
                separatorPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(separatorPen, X + 190, Y, X + 190, Y + 205);
            }

            // Провода (горизонтальный и вертикальные)
            using (Pen redPen = new Pen(WireColor, 3))
            {
                // Левая вертикальная
                g.DrawLine(redPen, X + 54, Y - 69, X + 54, Y);
                // Правая вертикальная
                g.DrawLine(redPen, X + 324, Y - 69, X + 324, Y);
                // Горизонтальная сверху
                g.DrawLine(redPen, X + 53, Y - 69, X + 325, Y - 69);
            }

            Cathode = new Electrode(ElectrodeType.Cathode, X + 24, Y, Color.FromArgb(126, 126, 126));
            Cathode.Render(g);
            Anode = new Electrode(ElectrodeType.Anode, X + 291, Y, Color.FromArgb(200, 200, 200));
            Anode.Render(g);
        }
    }
}
