using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;


namespace CustomColorizerTest {
    public partial class MainForm : RibbonForm {
        public MainForm() {
            InitializeComponent();
            InitSkinGallery();

        }
        void InitSkinGallery() {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

    }
}