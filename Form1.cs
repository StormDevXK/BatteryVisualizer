using BatteryVisualizer.Models;

namespace BatteryVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelAnimation.Paint += PanelAnimation_Paint;
        }
        private void PanelAnimation_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // ���������� �������
            int x0 = 50, y0 = 50;
            int width = 200, height = 100;
            int electrodeThickness = 10;

            // ���� �������
            var bodyRect = new Rectangle(x0, y0, width, height);
            using (var pen = new Pen(Color.Black, 2))
                g.DrawRectangle(pen, bodyRect);

            // ���� (����� ��������)
            var anode = new Rectangle(x0 + electrodeThickness, y0 + 10,
                                      electrodeThickness, height - 20);
            using (var brush = new SolidBrush(Color.Gray))
                g.FillRectangle(brush, anode);

            // ����� (������ ��������)
            var cathode = new Rectangle(x0 + width - 2 * electrodeThickness, y0 + 10,
                                        electrodeThickness, height - 20);
            using (var brush = new SolidBrush(Color.Gray))
                g.FillRectangle(brush, cathode);

            // ���������
            int sepX = x0 + electrodeThickness * 2 + 10;
            g.DrawLine(Pens.LightGray, sepX, y0 + 10, sepX, y0 + height - 10);

            // ��������� ������ (������: 60%)
            float chargePercent = 0.6f;
            int chargeWidth = (int)((width - electrodeThickness * 4) * chargePercent);
            var chargeRect = new Rectangle(x0 + electrodeThickness * 2 + 12,
                                           y0 + 12, chargeWidth, height - 24);
            using (var brush = new SolidBrush(Color.LightGreen))
                g.FillRectangle(brush, chargeRect);

            // �������
            using (var font = new Font("Segoe UI", 9))
            using (var brush = new SolidBrush(Color.Black))
            {
                g.DrawString("����", font, brush, x0 + electrodeThickness + 2, y0 - 18);
                g.DrawString("�����", font, brush, x0 + width - 2 * electrodeThickness - 2, y0 - 18);
                g.DrawString($"�����: {(int)(chargePercent * 100)}%", font, brush, x0, y0 + height + 5);
            }
        }
    }
}
