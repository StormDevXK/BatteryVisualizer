using BatteryVisualizer.Utils;

namespace BatteryVisualizer
{
    partial class SettingsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numericUpDownCapacity = new NumericUpDown();
            labelCapacity = new Label();
            comboBatteryType = new ComboBox();
            labelBatteryType = new Label();
            buttonStartAnimation = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownCapacity
            // 
            numericUpDownCapacity.Location = new Point(150, 186);
            numericUpDownCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownCapacity.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDownCapacity.Name = "numericUpDownCapacity";
            numericUpDownCapacity.Size = new Size(180, 27);
            numericUpDownCapacity.TabIndex = 2;
            numericUpDownCapacity.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // labelCapacity
            // 
            labelCapacity.AutoSize = true;
            labelCapacity.Location = new Point(33, 188);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(111, 20);
            labelCapacity.TabIndex = 4;
            labelCapacity.Text = "Ёмкость (мАч):";
            // 
            // comboBatteryType
            // 
            comboBatteryType.DisplayMember = "Text";
            comboBatteryType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBatteryType.FormattingEnabled = true;
            comboBatteryType.Location = new Point(150, 153);
            comboBatteryType.Name = "comboBatteryType";
            comboBatteryType.Size = new Size(180, 28);
            comboBatteryType.TabIndex = 3;
            // 
            // labelBatteryType
            // 
            labelBatteryType.AutoSize = true;
            labelBatteryType.Location = new Point(33, 153);
            labelBatteryType.Name = "labelBatteryType";
            labelBatteryType.Size = new Size(99, 20);
            labelBatteryType.TabIndex = 1;
            labelBatteryType.Text = "Тип батареи:";
            // 
            // buttonStartAnimation
            // 
            buttonStartAnimation.Location = new Point(33, 234);
            buttonStartAnimation.Name = "buttonStartAnimation";
            buttonStartAnimation.Size = new Size(296, 30);
            buttonStartAnimation.TabIndex = 0;
            buttonStartAnimation.Text = "Старт";
            buttonStartAnimation.UseVisualStyleBackColor = true;
            buttonStartAnimation.Click += buttonStartAnimation_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(342, 28);
            label1.TabIndex = 5;
            label1.Text = "Симулятор Работы Аккумулятора";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(223, 80);
            label2.TabIndex = 6;
            label2.Text = "Для начала симуляции:\r\n1. Выберите тип аккумулятора.\r\n2. Укажите его ёмкость.\r\n3. Нажмите \"Старт\".";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(368, 280);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonStartAnimation);
            Controls.Add(labelBatteryType);
            Controls.Add(numericUpDownCapacity);
            Controls.Add(comboBatteryType);
            Controls.Add(labelCapacity);
            Name = "SettingsForm";
            Text = "Настройки батареи";
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numericUpDownCapacity;
        private Label labelCapacity;
        private ComboBox comboBatteryType;
        private Label labelBatteryType;
        private Button buttonStartAnimation;
        private Label label1;
        private Label label2;
    }
}
