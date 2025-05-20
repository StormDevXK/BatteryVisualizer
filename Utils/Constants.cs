using System.ComponentModel;

namespace BatteryVisualizer.Utils
{
    public enum BatteryType
    {
        [Description("Литий-ионный")] LiIon,
        [Description("Никель-металлогидридный")] NiMH,
        [Description("Никель-кадмиевый")] NiCd,
        [Description("Свинцово-кислотный")] LeadAcid
    }

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
}
