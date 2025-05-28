namespace BatteryVisualizer
{
    partial class AnimationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxStatus = new GroupBox();
            labelCurrentValue = new Label();
            labelVoltageValue = new Label();
            labelResistanceValue = new Label();
            labelChargeLevel = new Label();
            groupBoxPanel = new GroupBox();
            buttonReset = new Button();
            buttonDischarge = new Button();
            buttonCharge = new Button();
            panelAnimation = new Panel();
            buttonReturnToMenu = new Button();
            groupBoxBatterySettings = new GroupBox();
            trackBarResistance = new TrackBar();
            labelResistanceTitle = new Label();
            groupBoxStatus.SuspendLayout();
            groupBoxPanel.SuspendLayout();
            groupBoxBatterySettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarResistance).BeginInit();
            SuspendLayout();
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Controls.Add(labelCurrentValue);
            groupBoxStatus.Controls.Add(labelVoltageValue);
            groupBoxStatus.Controls.Add(labelResistanceValue);
            groupBoxStatus.Controls.Add(labelChargeLevel);
            groupBoxStatus.Location = new Point(12, 50);
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.Size = new Size(202, 125);
            groupBoxStatus.TabIndex = 8;
            groupBoxStatus.TabStop = false;
            groupBoxStatus.Text = " Статус";
            // 
            // labelCurrentValue
            // 
            labelCurrentValue.AutoSize = true;
            labelCurrentValue.ImeMode = ImeMode.NoControl;
            labelCurrentValue.Location = new Point(6, 83);
            labelCurrentValue.MaximumSize = new Size(190, 0);
            labelCurrentValue.Name = "labelCurrentValue";
            labelCurrentValue.Size = new Size(106, 20);
            labelCurrentValue.TabIndex = 3;
            labelCurrentValue.Text = "Сила тока: n А";
            // 
            // labelVoltageValue
            // 
            labelVoltageValue.AutoSize = true;
            labelVoltageValue.ImeMode = ImeMode.NoControl;
            labelVoltageValue.Location = new Point(6, 63);
            labelVoltageValue.MaximumSize = new Size(190, 0);
            labelVoltageValue.Name = "labelVoltageValue";
            labelVoltageValue.Size = new Size(127, 20);
            labelVoltageValue.TabIndex = 2;
            labelVoltageValue.Text = "Напряжение: n В";
            // 
            // labelResistanceValue
            // 
            labelResistanceValue.AutoSize = true;
            labelResistanceValue.ImeMode = ImeMode.NoControl;
            labelResistanceValue.Location = new Point(6, 43);
            labelResistanceValue.MaximumSize = new Size(190, 0);
            labelResistanceValue.Name = "labelResistanceValue";
            labelResistanceValue.Size = new Size(160, 20);
            labelResistanceValue.TabIndex = 1;
            labelResistanceValue.Text = "Сопротивление: n Ом";
            // 
            // labelChargeLevel
            // 
            labelChargeLevel.AutoSize = true;
            labelChargeLevel.ImeMode = ImeMode.NoControl;
            labelChargeLevel.Location = new Point(6, 23);
            labelChargeLevel.MaximumSize = new Size(190, 0);
            labelChargeLevel.Name = "labelChargeLevel";
            labelChargeLevel.Size = new Size(148, 20);
            labelChargeLevel.TabIndex = 0;
            labelChargeLevel.Text = "Уровень заряда: n%";
            // 
            // groupBoxPanel
            // 
            groupBoxPanel.Controls.Add(buttonReset);
            groupBoxPanel.Controls.Add(buttonDischarge);
            groupBoxPanel.Controls.Add(buttonCharge);
            groupBoxPanel.Location = new Point(12, 283);
            groupBoxPanel.Name = "groupBoxPanel";
            groupBoxPanel.Size = new Size(202, 111);
            groupBoxPanel.TabIndex = 7;
            groupBoxPanel.TabStop = false;
            groupBoxPanel.Text = "Управление анимацией";
            // 
            // buttonReset
            // 
            buttonReset.ImeMode = ImeMode.NoControl;
            buttonReset.Location = new Point(6, 71);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(190, 30);
            buttonReset.TabIndex = 4;
            buttonReset.Text = "Сброс";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonDischarge
            // 
            buttonDischarge.ImeMode = ImeMode.NoControl;
            buttonDischarge.Location = new Point(104, 35);
            buttonDischarge.Name = "buttonDischarge";
            buttonDischarge.Size = new Size(92, 30);
            buttonDischarge.TabIndex = 3;
            buttonDischarge.Text = "Разрядить";
            buttonDischarge.UseVisualStyleBackColor = true;
            buttonDischarge.Click += buttonDischarge_Click;
            // 
            // buttonCharge
            // 
            buttonCharge.ImeMode = ImeMode.NoControl;
            buttonCharge.Location = new Point(6, 35);
            buttonCharge.Name = "buttonCharge";
            buttonCharge.Size = new Size(92, 30);
            buttonCharge.TabIndex = 2;
            buttonCharge.Text = "Зарядить";
            buttonCharge.UseVisualStyleBackColor = true;
            buttonCharge.Click += buttonCharge_Click;
            // 
            // panelAnimation
            // 
            panelAnimation.Location = new Point(221, 12);
            panelAnimation.Name = "panelAnimation";
            panelAnimation.Size = new Size(505, 505);
            panelAnimation.TabIndex = 6;
            // 
            // buttonReturnToMenu
            // 
            buttonReturnToMenu.Location = new Point(12, 12);
            buttonReturnToMenu.Name = "buttonReturnToMenu";
            buttonReturnToMenu.Size = new Size(202, 32);
            buttonReturnToMenu.TabIndex = 0;
            buttonReturnToMenu.Text = "Назад";
            buttonReturnToMenu.UseVisualStyleBackColor = true;
            buttonReturnToMenu.Click += buttonReturnToMenu_Click;
            // 
            // groupBoxBatterySettings
            // 
            groupBoxBatterySettings.Controls.Add(trackBarResistance);
            groupBoxBatterySettings.Controls.Add(labelResistanceTitle);
            groupBoxBatterySettings.Location = new Point(12, 181);
            groupBoxBatterySettings.Name = "groupBoxBatterySettings";
            groupBoxBatterySettings.Size = new Size(202, 96);
            groupBoxBatterySettings.TabIndex = 8;
            groupBoxBatterySettings.TabStop = false;
            groupBoxBatterySettings.Text = "Параметры батареи";
            // 
            // trackBarResistance
            // 
            trackBarResistance.AutoSize = false;
            trackBarResistance.LargeChange = 10;
            trackBarResistance.Location = new Point(6, 46);
            trackBarResistance.Maximum = 1000;
            trackBarResistance.Minimum = 1;
            trackBarResistance.Name = "trackBarResistance";
            trackBarResistance.Size = new Size(190, 40);
            trackBarResistance.TabIndex = 1;
            trackBarResistance.TickFrequency = 10;
            trackBarResistance.Value = 50;
            trackBarResistance.Scroll += trackBarResistance_Scroll;
            // 
            // labelResistanceTitle
            // 
            labelResistanceTitle.AutoSize = true;
            labelResistanceTitle.Location = new Point(6, 23);
            labelResistanceTitle.Name = "labelResistanceTitle";
            labelResistanceTitle.Size = new Size(155, 20);
            labelResistanceTitle.TabIndex = 0;
            labelResistanceTitle.Text = "Сопротивление (Ом)";
            // 
            // AnimationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 527);
            Controls.Add(groupBoxBatterySettings);
            Controls.Add(buttonReturnToMenu);
            Controls.Add(groupBoxStatus);
            Controls.Add(groupBoxPanel);
            Controls.Add(panelAnimation);
            Name = "AnimationForm";
            Text = "Эмулятор аккумулятора";
            FormClosing += AnimationForm_FormClosing;
            groupBoxStatus.ResumeLayout(false);
            groupBoxStatus.PerformLayout();
            groupBoxPanel.ResumeLayout(false);
            groupBoxBatterySettings.ResumeLayout(false);
            groupBoxBatterySettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarResistance).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxStatus;
        private Label labelChargeLevel;
        private GroupBox groupBoxPanel;
        private Button buttonDischarge;
        private Button buttonCharge;
        private Panel panelAnimation;
        private Button buttonReset;
        private Button buttonReturnToMenu;
        private GroupBox groupBoxBatterySettings;
        private Label labelResistanceTitle;
        private TrackBar trackBarResistance;
        private Label labelCurrentValue;
        private Label labelVoltageValue;
        private Label labelResistanceValue;
    }
}