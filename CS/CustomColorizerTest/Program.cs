using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CustomColorizerTest.CustomColorizers;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace CustomColorizerTest {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
            UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(135, 35, 0);
            SkinImageColorizer.Default = new MainThemeColorizer();
            UserLookAndFeel.Default.StyleChanged += Program.OnStyleChanged;
            Application.Run(new MainForm());
        }

        private static void OnStyleChanged(object sender, EventArgs e) {
            switch (UserLookAndFeel.Default.SkinName) {
                case "Office 2016 Colorful":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(135, 35, 0);
                    break;
                case "Office 2013":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(216, 52, 60);
                    break;
                case "Office 2013 Light Gray":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(21, 181, 131);
                    break;
                case "Office 2010 Blue":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(247, 192, 36);
                    break;
                case "Visual Studio 2013 Blue":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(166, 164, 93);
                    break;
                case "Visual Studio 2013 Dark":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(101, 87, 104);
                    break;
                case "Visual Studio 2013 Light":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(99, 210, 103);
                    break;
                case "VS2010":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(195, 92, 12);
                    break;
                case "High Contrast":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(239, 120, 141);
                    break;
                case "Office 2007 Pink":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(166, 221, 147);
                    break;
                case "McSkin":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(130, 60, 125);
                    break;
                case "Blueprint":
                    UserLookAndFeel.Default.SkinMaskColor = Color.FromArgb(108, 203, 194);
                    break;
                default:
                    UserLookAndFeel.Default.SkinMaskColor = Color.Empty;
                    break;
            }
        }
    }
}