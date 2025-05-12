using System.ComponentModel;

namespace BatteryVisualizer.Models
{
    public enum BatteryType
    {
        [Description("Литий-ионный (Li-Ion)")]
        LiIon,

        [Description("Никель-металлогидридный (NiMH)")]
        NiMH,

        [Description("Никель-кадмиевый (NiCd)")]
        NiCd,

        [Description("Свинцово-кислотный")]
        LeadAcid
    }
}
