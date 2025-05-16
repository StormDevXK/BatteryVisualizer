using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatteryVisualizer
{
    public partial class AnimationForm : Form
    {
        private SettingsForm _parentForm;
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

            // Координаты батареи
            int x0 = 50, y0 = 50;
            int width = 200, height = 100;
            int electrodeThickness = 10;

            // Тело батареи
            var bodyRect = new Rectangle(x0, y0, width, height);
            using (var pen = new Pen(Color.Black, 2))
                g.DrawRectangle(pen, bodyRect);

            // Анод (левая пластина)
            var anode = new Rectangle(x0 + electrodeThickness, y0 + 10,
                                      electrodeThickness, height - 20);
            using (var brush = new SolidBrush(Color.Gray))
                g.FillRectangle(brush, anode);

            // Катод (правая пластина)
            var cathode = new Rectangle(x0 + width - 2 * electrodeThickness, y0 + 10,
                                        electrodeThickness, height - 20);
            using (var brush = new SolidBrush(Color.Gray))
                g.FillRectangle(brush, cathode);

            // Сепаратор
            int sepX = x0 + electrodeThickness * 2 + 10;
            g.DrawLine(Pens.LightGray, sepX, y0 + 10, sepX, y0 + height - 10);

            // Индикатор заряда (пример: 60%)
            float chargePercent = 0.6f;
            int chargeWidth = (int)((width - electrodeThickness * 4) * chargePercent);
            var chargeRect = new Rectangle(x0 + electrodeThickness * 2 + 12,
                                           y0 + 12, chargeWidth, height - 24);
            using (var brush = new SolidBrush(Color.LightGreen))
                g.FillRectangle(brush, chargeRect);

            // Подписи
            using (var font = new Font("Segoe UI", 9))
            using (var brush = new SolidBrush(Color.Black))
            {
                g.DrawString("Анод", font, brush, x0 + electrodeThickness + 2, y0 - 18);
                g.DrawString("Катод", font, brush, x0 + width - 2 * electrodeThickness - 2, y0 - 18);
                g.DrawString($"Заряд: {(int)(chargePercent * 100)}%", font, brush, x0, y0 + height + 5);
            }
        }

        private void buttonReturnToMenu_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }
    }
}
