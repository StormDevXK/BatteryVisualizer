using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BatteryVisualizer.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BatteryVisualizer.Models
{
    public class Electrode
    {
        public ElectrodeType Type;
        public string Name => Type.GetDescription();
        public int Width = 65;
        public int Height = 205;
        public int X;
        public int Y;
        public Color FillColor { get; set; }
        public List<Carrier> Carriers = new List<Carrier>();

        public Electrode(ElectrodeType type, int x, int y, Color color)
        {
            Type = type;
            X = x;
            Y = y;
            FillColor = color;

            GenerateCarriers(5);
        }

        public void Render(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(FillColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }

            // Подпись под электродом
            using (Font font = new Font("Inter", 10))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                SizeF textSize = g.MeasureString(Name, font);
                float textX = X + (Width - textSize.Width) / 2;
                float textY = Y + Height + 10;
                g.DrawString(Name, font, textBrush, textX, textY);
            }

            // Отрисовка частиц
            foreach (var carrier in Carriers)
            {
                carrier.Render(g);
            }
        }

        public void GenerateCarriers(int count)
        {
            Random rand = new Random();
            Carriers.Clear();
            for (int i = 0; i < count; i++)
            {
                CarrierType carrierType = (rand.Next(2) == 0) ? CarrierType.Electron : CarrierType.Ion;
                float radius = (carrierType == CarrierType.Electron) ? 5f : 7f;
                Color color = (carrierType == CarrierType.Electron) ? Color.Blue : Color.Red;

                // Частицы генерируем внутри области электрода
                float posX = X + (float)rand.NextDouble() * Width;
                float posY = Y + (float)rand.NextDouble() * Height;

                if (Type == ElectrodeType.Cathode)
                {
                    Carriers.Add(new Carrier(CarrierType.Ion, new PointF(posX, posY)));
                }
                else
                {
                    Carriers.Add(new Carrier(CarrierType.Electron, new PointF(posX, posY)));
                }

            }
        }
    }
}   