using PdfMerger.Classes;
using PdfMerger.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace PdfMerger.SettingsPanels
{
    public partial class ImageSettings : SettingsUserControl
    {
        public ImageSettings()
        {
            InitializeComponent();

            checkBoxRotatePageToImage.Checked = ConfigManager.Config.RotatePageToImage;


            comboBoxImagePlacementMethod.Items.Add(
                new ComboBoxItem(
                    Properties.Strings.ImagePlacementModeOriginal, 
                    (int)eImagePlacementMode.Original));

            comboBoxImagePlacementMethod.Items.Add(
                new ComboBoxItem(
                    Properties.Strings.ImagePlacementModeFit,
                    (int)eImagePlacementMode.Fit));

            comboBoxImagePlacementMethod.Items.Add(
                new ComboBoxItem(
                    Properties.Strings.ImagePlacementModeFill,
                    (int)eImagePlacementMode.Fill));

            comboBoxImagePlacementMethod.SelectedIndex = ConfigManager.Config.ImagePlacementMode;


            checkBoxRotatePageToImage.Text = Properties.Strings.RotatePageToImage;
            labelImagePlacementMethod.Text = Properties.Strings.ImagePlacementMode;
        }



        public override void Save()
        {
            ConfigManager.Config.RotatePageToImage = checkBoxRotatePageToImage.Checked;
            ConfigManager.Config.ImagePlacementMode = 
                (comboBoxImagePlacementMethod.SelectedItem as ComboBoxItem)?.IntValue 
                ?? (int) eImagePlacementMode.Fit;
        }
    }
}
