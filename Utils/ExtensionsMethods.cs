using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatteryVisualizer.Utils
{
    public static class ExtensionsMethods
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute?.Description ?? value.ToString();
        }

        public static void DoubleBuffered(this Control control, bool enable)
        {
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, enable, null);
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static float SpeedMath(TrackBar trackBarResistance)
        {
            float resistance = trackBarResistance.Value;
            float logBase = 10f;
            float logValue = MathF.Log(resistance + 1, logBase);

            float maxSpeed = 5.0f;
            float minSpeed = 0.5f;

            float speedFactor = 1f - (logValue / MathF.Log(trackBarResistance.Maximum + 1, logBase));
            float carrierSpeed = ExtensionsMethods.Lerp(minSpeed, maxSpeed, speedFactor);
            return carrierSpeed;
        }
    }
}
