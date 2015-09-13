using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.IO;


namespace GigalothMapEditor
{
    public partial class AddTileset : Form
    {

        public string defaultFilepath = Application.StartupPath + "\\Content\\";
        public string _filePath = "";
        public int _TileWidth;
        public int _TileHeight;
        public bool _setTerrain = false;
        public bool _setAnimated = false;

        public AddTileset()
        {
            InitializeComponent();
            numericUpDownTileWidth.Value = 96;
            _TileWidth = (int)numericUpDownTileWidth.Value;
            numericUpDownTileHeight.Value = 96;
            _TileHeight = (int)numericUpDownTileHeight.Value;

        }




        private void buttonLoadTileSheet_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = defaultFilepath;
            openFileDialog1.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filePath = openFileDialog1.FileName;
                    myStream.Close();
                    string[] stringSeparators = new string[] { @"\Content\" };
                    string[] result = filePath.Split(stringSeparators,
                    StringSplitOptions.RemoveEmptyEntries);
                    _filePath = result[1].Replace(".png", null);
                    labelFileName.Text = _filePath.ToString(); 
                }
            }

        }

        private void numericUpDownTileWidth_ValueChanged(object sender, EventArgs e)
        {
            _TileWidth = (int)numericUpDownTileWidth.Value;
        }

        private void numericUpDownTileHeight_ValueChanged(object sender, EventArgs e)
        {
            _TileHeight = (int)numericUpDownTileHeight.Value;
        }

        private void checkBoxIsTerrain_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsTerrain.CheckState == CheckState.Checked) _setTerrain = true;
            if (checkBoxIsTerrain.CheckState == CheckState.Unchecked) _setTerrain = false;
        }

        private void checkBoxIsAnimated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsAnimated.CheckState == CheckState.Checked) _setAnimated = true;
            if (checkBoxIsAnimated.CheckState == CheckState.Unchecked) _setAnimated = false;
        }


    }
}
