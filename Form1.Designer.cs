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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBoxBattery = new GroupBox();
            domainUpDownCurrent = new DomainUpDown();
            labelCurrent = new Label();
            domainUpDownCapacity = new DomainUpDown();
            labelCapacity = new Label();
            comboBatteryType = new ComboBox();
            labelBatteryType = new Label();
            panelAnimation = new Panel();
            groupBoxBattery.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxBattery
            // 
            groupBoxBattery.Controls.Add(domainUpDownCurrent);
            groupBoxBattery.Controls.Add(labelCurrent);
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
            // labelCurrent
            // 
            resources.ApplyResources(labelCurrent, "labelCurrent");
            labelCurrent.Name = "labelCurrent";
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
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxBattery);
            Controls.Add(panelAnimation);
            Name = "Form1";
            groupBoxBattery.ResumeLayout(false);
            groupBoxBattery.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxBattery;
        private DomainUpDown domainUpDownCurrent;
        private Label labelCurrent;
        private DomainUpDown domainUpDownCapacity;
        private Label labelCapacity;
        private ComboBox comboBatteryType;
        private Label labelBatteryType;
        private Panel panelAnimation;
    }
}
