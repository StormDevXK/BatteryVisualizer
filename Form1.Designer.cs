using BatteryVisualizer.Models;

namespace BatteryVisualizer
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBoxBattery = new GroupBox();
            domainUpDownCurrent = new DomainUpDown();
            labelResistance = new Label();
            domainUpDownCapacity = new DomainUpDown();
            labelCapacity = new Label();
            comboBatteryType = new ComboBox();
            labelBatteryType = new Label();
            panelAnimation = new Panel();
            groupBoxPanel = new GroupBox();
            timer1 = new System.Windows.Forms.Timer(components);
            buttonCharge = new Button();
            buttonDischarge = new Button();
            buttonReset = new Button();
            groupBoxStatus = new GroupBox();
            label1 = new Label();
            groupBoxBattery.SuspendLayout();
            groupBoxPanel.SuspendLayout();
            groupBoxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxBattery
            // 
            groupBoxBattery.Controls.Add(domainUpDownCurrent);
            groupBoxBattery.Controls.Add(labelResistance);
            groupBoxBattery.Controls.Add(domainUpDownCapacity);
            groupBoxBattery.Controls.Add(labelCapacity);
            groupBoxBattery.Controls.Add(comboBatteryType);
            groupBoxBattery.Controls.Add(labelBatteryType);
            resources.ApplyResources(groupBoxBattery, "groupBoxBattery");
            groupBoxBattery.Name = "groupBoxBattery";
            groupBoxBattery.TabStop = false;
            // 
            // domainUpDownCurrent
            // 
            resources.ApplyResources(domainUpDownCurrent, "domainUpDownCurrent");
            domainUpDownCurrent.Name = "domainUpDownCurrent";
            // 
            // labelResistance
            // 
            resources.ApplyResources(labelResistance, "labelResistance");
            labelResistance.Name = "labelResistance";
            // 
            // domainUpDownCapacity
            // 
            resources.ApplyResources(domainUpDownCapacity, "domainUpDownCapacity");
            domainUpDownCapacity.Name = "domainUpDownCapacity";
            // 
            // labelCapacity
            // 
            resources.ApplyResources(labelCapacity, "labelCapacity");
            labelCapacity.Name = "labelCapacity";
            // 
            // comboBatteryType
            // 
            comboBatteryType.DataSource = new BatteryType[]
    {
    BatteryType.LiIon,
    BatteryType.NiMH,
    BatteryType.NiCd,
    BatteryType.LeadAcid
    };
            comboBatteryType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBatteryType.FormattingEnabled = true;
            comboBatteryType.Items.AddRange(new object[] { resources.GetObject("comboBatteryType.Items"), resources.GetObject("comboBatteryType.Items1"), resources.GetObject("comboBatteryType.Items2"), resources.GetObject("comboBatteryType.Items3") });
            resources.ApplyResources(comboBatteryType, "comboBatteryType");
            comboBatteryType.Name = "comboBatteryType";
            // 
            // labelBatteryType
            // 
            resources.ApplyResources(labelBatteryType, "labelBatteryType");
            labelBatteryType.Name = "labelBatteryType";
            // 
            // panelAnimation
            // 
            resources.ApplyResources(panelAnimation, "panelAnimation");
            panelAnimation.Name = "panelAnimation";
            // 
            // groupBoxPanel
            // 
            groupBoxPanel.Controls.Add(buttonReset);
            groupBoxPanel.Controls.Add(buttonDischarge);
            groupBoxPanel.Controls.Add(buttonCharge);
            resources.ApplyResources(groupBoxPanel, "groupBoxPanel");
            groupBoxPanel.Name = "groupBoxPanel";
            groupBoxPanel.TabStop = false;
            // 
            // buttonCharge
            // 
            resources.ApplyResources(buttonCharge, "buttonCharge");
            buttonCharge.Name = "buttonCharge";
            buttonCharge.UseVisualStyleBackColor = true;
            // 
            // buttonDischarge
            // 
            resources.ApplyResources(buttonDischarge, "buttonDischarge");
            buttonDischarge.Name = "buttonDischarge";
            buttonDischarge.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            resources.ApplyResources(buttonReset, "buttonReset");
            buttonReset.Name = "buttonReset";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatus
            // 
            groupBoxStatus.Controls.Add(label1);
            resources.ApplyResources(groupBoxStatus, "groupBoxStatus");
            groupBoxStatus.Name = "groupBoxStatus";
            groupBoxStatus.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxStatus);
            Controls.Add(groupBoxPanel);
            Controls.Add(groupBoxBattery);
            Controls.Add(panelAnimation);
            Name = "Form1";
            groupBoxBattery.ResumeLayout(false);
            groupBoxBattery.PerformLayout();
            groupBoxPanel.ResumeLayout(false);
            groupBoxStatus.ResumeLayout(false);
            groupBoxStatus.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxBattery;
        private DomainUpDown domainUpDownCurrent;
        private Label labelResistance;
        private DomainUpDown domainUpDownCapacity;
        private Label labelCapacity;
        private ComboBox comboBatteryType;
        private Label labelBatteryType;
        private Panel panelAnimation;
        private GroupBox groupBoxPanel;
        private Button buttonDischarge;
        private Button buttonCharge;
        private System.Windows.Forms.Timer timer1;
        private Button buttonReset;
        private GroupBox groupBoxStatus;
        private Label label1;
    }
}
