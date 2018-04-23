using System.Collections.Generic;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils.Colors;
using System.Linq;

namespace CustomColorizerTest.CustomColorizers {
    public class MainThemeColorizer :SkinImageColorizer {
        private readonly Dictionary<string, Color> MainThemeColorsBySkinName;
        private readonly Dictionary<Color, Color> HueMaskColorsByThemeColor;

        public MainThemeColorizer() {
            this.MainThemeColorsBySkinName = new Dictionary<string, Color>();
            this.HueMaskColorsByThemeColor = new Dictionary<Color, Color>();
            this.AddDefaultMainThemeColors();
        }

        private Color MainThemeColor {
            get {
                return this.MainThemeColorsBySkinName.ContainsKey(UserLookAndFeel.Default.SkinName) ?
                    this.MainThemeColorsBySkinName[UserLookAndFeel.Default.SkinName] : Color.Empty;
            }
        }

        protected override Color ConvertColorByHueCore(Color color, Color maskColor) {
            if (this.IsMainThemeColor(color)) return maskColor;
            return base.ConvertColorByHueCore(color, this.GetHueMaskColor(maskColor));
        }

        private bool IsMainThemeColor(Color color) {
            return this.MainThemeColor == color;
        }

        private static Color PrepareHueMaskColor(Color themeColor) {
            HueSatBright hsb = HueSatBright.FromColor(themeColor);
            hsb.Brightness = 1.0;
            hsb.Saturation = 1.0;
            return hsb.AsRGB;
        }

        private Color GetHueMaskColor(Color themeColor) {
            Color result = Color.Empty;
            if (this.HueMaskColorsByThemeColor.TryGetValue(themeColor, out result)) return result;
            result = MainThemeColorizer.PrepareHueMaskColor(themeColor);
            this.HueMaskColorsByThemeColor.Add(themeColor, result);
            return result;
        }

        private void AddDefaultMainThemeColors() {
            this.SetSkinMainThemeColor("Office 2016 Colorful", Color.FromArgb(1, 115, 199));
            this.SetSkinMainThemeColor("Office 2013", Color.FromArgb(0, 114, 198));
            this.SetSkinMainThemeColor("Office 2013 Light Gray", Color.FromArgb(25, 71, 138));
            this.SetSkinMainThemeColor("Office 2010 Blue", Color.FromArgb(207, 221, 238));
            this.SetSkinMainThemeColor("Visual Studio 2013 Blue", Color.FromArgb(41, 57, 85));
            this.SetSkinMainThemeColor("Visual Studio 2013 Dark", Color.FromArgb(0, 122, 204));
            this.SetSkinMainThemeColor("Visual Studio 2013 Light", Color.FromArgb(0, 122, 204));
            this.SetSkinMainThemeColor("VS2010", Color.FromArgb(43, 59, 88));
            this.SetSkinMainThemeColor("High Contrast", Color.FromArgb(128, 0, 128));
            this.SetSkinMainThemeColor("Office 2007 Green", Color.FromArgb(222, 239, 229));
            this.SetSkinMainThemeColor("Office 2007 Pink", Color.FromArgb(219, 187, 196));
            this.SetSkinMainThemeColor("McSkin", Color.FromArgb(209, 215, 226));
            this.SetSkinMainThemeColor("Blueprint", Color.FromArgb(86, 119, 174));
        }

        private void SetSkinMainThemeColor(string skinName, Color mainThemeColor) {
            this.MainThemeColorsBySkinName[skinName] = mainThemeColor;
        }
    }
}
