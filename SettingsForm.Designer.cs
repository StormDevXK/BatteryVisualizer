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
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownCapacity
            // 
            numericUpDownCapacity.Location = new Point(129, 48);
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
            labelCapacity.Location = new Point(12, 50);
            labelCapacity.Name = "labelCapacity";
            labelCapacity.Size = new Size(111, 20);
            labelCapacity.TabIndex = 4;
            labelCapacity.Text = "Ёмкость (мАч):";
            // 
            // comboBatteryType
            // 
            comboBatteryType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBatteryType.FormattingEnabled = true;
            comboBatteryType.Items.AddRange(new object[] { BatteryType.LiIon, BatteryType.NiMH, BatteryType.NiCd, BatteryType.LeadAcid });
            comboBatteryType.Location = new Point(129, 15);
            comboBatteryType.Name = "comboBatteryType";
            comboBatteryType.Size = new Size(180, 28);
            comboBatteryType.TabIndex = 3;
            // 
            // labelBatteryType
            // 
            labelBatteryType.AutoSize = true;
            labelBatteryType.Location = new Point(12, 15);
            labelBatteryType.Name = "labelBatteryType";
            labelBatteryType.Size = new Size(99, 20);
            labelBatteryType.TabIndex = 1;
            labelBatteryType.Text = "Тип батареи:";
            // 
            // buttonStartAnimation
            // 
            buttonStartAnimation.Location = new Point(12, 96);
            buttonStartAnimation.Name = "buttonStartAnimation";
            buttonStartAnimation.Size = new Size(296, 30);
            buttonStartAnimation.TabIndex = 0;
            buttonStartAnimation.Text = "Старт";
            buttonStartAnimation.UseVisualStyleBackColor = true;
            buttonStartAnimation.Click += buttonStartAnimation_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 138);
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
    }
}
