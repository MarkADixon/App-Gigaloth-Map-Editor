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
    public partial class NewMap : Form
    {
        public string defaultFilepath = Application.StartupPath + "\\Content\\";
        public string _filePath = "";
        public int _WorldTileWidth;
        public int _WorldTileHeight;
        public int _WorldGridWidth;
        public int _WorldGridHeight;
        public int _WorldWidth;
        public int _WorldHeight;
        public string worldWidthLabel;

        public NewMap()
        {
            InitializeComponent();
            numericUpDownGridTileWidth.Value = 16;
            _WorldTileWidth = (int)numericUpDownGridTileWidth.Value;
            numericUpDownGridTileHeight.Value = 16;
            _WorldTileHeight = (int)numericUpDownGridTileHeight.Value;
            numericUpDownTilesWide.Value = 160;
            _WorldGridWidth = (int)numericUpDownTilesWide.Value;
            numericUpDownTilesHigh.Value = 90;
            _WorldGridHeight = (int)numericUpDownTilesHigh.Value;
            _WorldWidth = _WorldTileWidth * _WorldGridWidth;
            _WorldHeight = _WorldTileHeight * _WorldGridHeight;
            labelWorldTotalWidth.Text = "WORLD TOTAL WIDTH: " + _WorldWidth.ToString() + " pixels";
            labelWorldTotalHeight.Text = "WORLD TOTAL HEIGHT: " + _WorldHeight.ToString() + " pixels";
        }

        private void numericUpDownGridTileWidth_ValueChanged(object sender, EventArgs e)
        {
            _WorldTileWidth = (int)numericUpDownGridTileWidth.Value;
            _WorldWidth = _WorldTileWidth * _WorldGridWidth;
            if (_WorldWidth < 1281)
            {
                numericUpDownGridTileWidth.Value = (decimal)(1281 / _WorldGridWidth)+1;
            }
            labelWorldTotalWidth.Text = "WORLD TOTAL WIDTH: " + _WorldWidth.ToString() + " pixels";
        }

        private void numericUpDownGridTileHeight_ValueChanged(object sender, EventArgs e)
        {
            _WorldTileHeight = (int)numericUpDownGridTileHeight.Value;
            _WorldHeight = _WorldTileHeight * _WorldGridHeight;
            if (_WorldHeight < 721)
            {
                numericUpDownGridTileHeight.Value = (decimal)(721 / _WorldGridHeight) + 1;
            }
            labelWorldTotalHeight.Text = "WORLD TOTAL HEIGHT: " + _WorldHeight.ToString() + " pixels";
        }

        private void numericUpDownTilesWide_ValueChanged(object sender, EventArgs e)
        {
            _WorldGridWidth = (int)numericUpDownTilesWide.Value;
            _WorldWidth = _WorldTileWidth * _WorldGridWidth;
            if (_WorldWidth < 1281)
            {
                numericUpDownTilesWide.Value = (decimal)(1281 / _WorldTileWidth) + 1;
            }
            labelWorldTotalWidth.Text = "WORLD TOTAL WIDTH: " + _WorldWidth.ToString() + " pixels";
        }

        private void numericUpDownTilesHigh_ValueChanged(object sender, EventArgs e)
        {
            _WorldGridHeight = (int)numericUpDownTilesHigh.Value;
            _WorldHeight = _WorldTileHeight * _WorldGridHeight;
            if (_WorldHeight < 721)
            {
                numericUpDownTilesHigh.Value = (decimal)(721 / _WorldTileWidth) + 1;
            }
            labelWorldTotalHeight.Text = "WORLD TOTAL HEIGHT: " + _WorldHeight.ToString() + " pixels";
        }

        private void buttonChooseTexturePack_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = defaultFilepath;
            openFileDialog1.Filter = "texture pack files (*.pck)|*.pck|All files (*.*)|*.*";
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
                    _filePath = result[1].Replace(".pck", null);
                    labelFileName.Text = _filePath.ToString();
                }
            }
        }




    }
}
