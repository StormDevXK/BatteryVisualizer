using System.ComponentModel;

namespace BatteryVisualizer.Utils
{
    //public enum BatteryType
    //{
    //    [Description("Литий-ионный")] LiIon,
    //    [Description("Никель-металлогидридный")] NiMH,
    //    [Description("Никель-кадмиевый")] NiCd,
    //    [Description("Свинцово-кислотный")] LeadAcid
    //}

    public enum ElectrodeType
    {
        [Description("Анод")] Anode,
        [Description("Катод")] Cathode
    }

    public enum CarrierType
    {
        [Description("Электрон")] Electron,
        [Description("Ион")] Ion
    }

    public class BatteryType
    {
        public string Name { get; }
        public string Text { get; }
        public double Voltage { get; }

        private BatteryType(string name, string text, double voltage)
        {
            Name = name;
            Text = text;
            Voltage = voltage;
        }

        public static readonly BatteryType LiIon = new BatteryType("LiIon", "Литий-ионный", 3.7);
        public static readonly BatteryType NiMH = new BatteryType("NiMH", "Никель-металлогидридный", 1.2);
        public static readonly BatteryType NiCd = new BatteryType("NiCd", "Никель-кадмиевый", 1.2);
        public static readonly BatteryType LeadAcid = new BatteryType("LeadAcid", "Свинцово-кислотный", 2.0);

        public static IEnumerable<BatteryType> All => new[] { LiIon, NiMH, NiCd, LeadAcid };

        public override string ToString() => Text;
    }
}
