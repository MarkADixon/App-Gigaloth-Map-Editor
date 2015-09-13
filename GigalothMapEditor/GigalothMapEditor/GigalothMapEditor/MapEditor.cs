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
using Microsoft.Xna.Framework.Graphics;
using ParallaxEngine;

namespace GigalothMapEditor
{
    public partial class MapEditor : Form
    {
        #region DECLARATIONS

        public Game1 game;
        public BindingList<Layer> bindingListLayers;
        public int listBoxTileWidth = 64;
        public int listBoxTileHeight = 64;
        public string defaultFilepath = Application.StartupPath + "\\Content\\";
        public List<int> TilesetComboBoxTextureIDs = new List<int>();
        private bool wasUpdateTickedOnce=false;
        public string backgroundFilePath = "";
        public const int texturePadding = 2;

        

        #endregion


        public MapEditor()
        {
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.DoubleBuffered = true;
            InitializeComponent();
        }

       
        //helper method to load tilesheet in editor window
        public void LoadTileList(String filepath, bool isAnimated)
        {
            imgListTiles.Images.Clear();
            listTiles.Items.Clear();
            Bitmap tileSheet = new Bitmap(filepath);
            int tilecount = 0;
            for (int y = 0; y < tileSheet.Height / (listBoxTileHeight + (2*texturePadding)); y++)
            {
                for (int x = 0; x < tileSheet.Width / (listBoxTileWidth + (2*texturePadding)); x++)
                {
                    if (!isAnimated || x == 0)
                    {
                        Bitmap newBitmap = tileSheet.Clone(
                            new System.Drawing.Rectangle(
                                texturePadding + (x * (listBoxTileWidth + (2 * texturePadding))),
                                texturePadding + (y * (listBoxTileHeight + (2 * texturePadding))),
                                listBoxTileWidth,
                                listBoxTileHeight),
                                System.Drawing.Imaging.PixelFormat.DontCare);
                        imgListTiles.Images.Add(newBitmap);
                        string itemName = "";
                        listTiles.Items.Add(new ListViewItem(itemName, tilecount++));
                    }
                }
            }
        }


        #region MAP EDITOR LOAD () : SETS DEFAULTS FOR DROPDOWNS/SWITCHES
        private void MapEditor_Load(object sender, EventArgs e)
        {

            
        }
        #endregion

        #region EDITOR RESIZING EVENT HANDLING
        private void MapEditor_Resize(object sender, EventArgs e)
        {
            FixScrollBarScales();

        }
        private void FixScrollBarScales()
        {
            Camera.ViewportWidth = pictureBox.Width;
            Camera.ViewportHeight = pictureBox.Height;
            
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Camera.WorldRectangle.Height - Camera.ViewportHeight;
            vScrollBar1.Value = vScrollBar1.Maximum;
            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = Camera.WorldRectangle.Width - Camera.ViewportWidth;
            
        }
        #endregion

        #region POST GAME CLASS LOAD INITIALIZATION
        //things to set up after the Game finishes its load and initialization by having waited for the update Timer to tick.
        //set up so that the inside loop happens only once
        private void timerGameUpdate_Tick(object sender, EventArgs e)
        {
            if (!wasUpdateTickedOnce)
            {

                Initialize();
                wasUpdateTickedOnce = true;
            }

            if (game.isSpriteJustSelected) SetControlsExistingSelected();

            game.Tick();

        }
        #endregion

        #region INITIALIZE EDITOR 
        public void Initialize()
        {

            FixScrollBarScales();

            //set up drop down boxes
            showWorldGridToolStripMenuItem.CheckState = CheckState.Checked;
            showTextOverlayToolStripMenuItem.CheckState = CheckState.Checked;
            forewardLayersToolStripMenuItem.CheckState = CheckState.Unchecked;
            spriteTypesToolStripMenuItem.CheckState = CheckState.Checked;
            //checkBoxPlaceSpritesAsleep.CheckState = CheckState.Checked;
            checkBoxSelectSpriteMode.CheckState = CheckState.Unchecked;

            comboBoxTexture.Items.Clear();
            foreach (TextureData texture in LevelDataManager.levelTextures)
            {
                comboBoxTexture.Items.Add(texture.FileName);
            }
            comboBoxTexture.SelectedIndex = 0;


            comboBoxTileSet.Items.Clear();
            TilesetComboBoxTextureIDs.Clear();
            foreach (TextureData texture in LevelDataManager.levelTextures)
            {
                if (texture.IsTiled)
                {
                    comboBoxTileSet.Items.Add(texture.FileName);
                    TilesetComboBoxTextureIDs.Add(texture.TextureID);
                }
            }
            comboBoxTileSet.SelectedIndex = 0;
            game.placementSprite.TextureID = TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex];
            labelTilesetID.Text = ("ID: " + TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex].ToString());
            listBoxTileWidth = LevelDataManager.SpriteWidth(TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]);
            listBoxTileHeight = LevelDataManager.SpriteHeight(TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]);
            bool isAnimated = LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].IsAnimated;
            LoadTileList(defaultFilepath + LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].FilePath + ".png", isAnimated);

            bindingListLayers = new BindingList<Layer>(game.parallaxEngine.worldLayers);
            comboBoxLayer.DataSource = bindingListLayers;
            comboBoxLayer.DisplayMember = "LayerName";
            comboBoxLayer.SelectedIndex = bindingListLayers.Count - 1;

            //pictureBoxTexture.Image = Image.FromFile(Application.StartupPath + "\\Content\\defaultTextures\\Titlebackground.png");

            comboBoxLevel.Items.Clear();
            comboBoxWorld.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                comboBoxLevel.Items.Add(i.ToString());
                comboBoxWorld.Items.Add(i.ToString());
            }
            comboBoxWorld.SelectedIndex = game.world;
            comboBoxLevel.SelectedIndex = game.level;

            comboBoxPathing.Items.Clear();
            comboBoxPathing.Items.Add("NONE");
            comboBoxPathing.Items.Add("LINEAR");
            comboBoxPathing.Items.Add("RECTANGLE");
            comboBoxPathing.Items.Add("ROUND");
            comboBoxPathing.Items.Add("FISH");
            comboBoxPathing.Items.Add("BAT");
            comboBoxPathing.Items.Add("SPIDER");
            comboBoxPathing.Items.Add("BIRD");
            comboBoxPathing.Items.Add("GREMLIN");
            comboBoxPathing.SelectedIndex = 0;

            listTiles.Focus();

        }
        #endregion


        #region FILE MENU

        //NEW MAP SELECTED
        private void newMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isInputSuspended = true;
            // Display a message box asking users if they wish to create a new map
            if (MessageBox.Show("Creating a new map will cause any unsaved data on the current map will be lost.  Do you want to create a new map?", "Gigaloth Games Editor",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
               NewMap newMapForm = new NewMap();
               if (newMapForm.ShowDialog(this) == DialogResult.OK && newMapForm._filePath != "")
               {
                   game.texturePack = @"\" + newMapForm._filePath + ".pck";
                   game.NewMap(defaultFilepath+newMapForm._filePath+".pck",newMapForm._WorldTileWidth,newMapForm._WorldTileHeight, newMapForm._WorldGridWidth,newMapForm._WorldGridHeight);

                   Initialize();                   
               }
            }

            game.isInputSuspended = false;
        }

        //SAVE MAP SELECTED
        private void saveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isInputSuspended = true;
            if (MessageBox.Show("Overwrite Save Data " + game.world.ToString() + "_" + game.level.ToString() + ".lvl ?", "Gigaloth Games Editor",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                game.SaveMap(defaultFilepath);
                MessageBox.Show("File Save Complete");
            }
            game.isInputSuspended = false;
        }

        //LOAD MAP SELECTED
        private void loadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isInputSuspended = true;
            
            // Display a message box asking users if they wish to load
            if (MessageBox.Show("Loading map will cause any unsaved data on the current map will be lost.  Do you wish to continue?", "Gigaloth Games Editor",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                              == DialogResult.Yes)
            {
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = defaultFilepath;
                openFileDialog1.Filter = "Level files (*.lvl)|*.lvl|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        string filePath = openFileDialog1.FileName;
                        myStream.Close();

                        game.LoadMap(filePath);
                        Initialize();
                    }
                }
            }

            game.isInputSuspended = false;
            return;
        }

        //EXIT EDITOR 
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            game.isInputSuspended = true; 
            // Display a message box confirming exit
            if (MessageBox.Show("Exiting the editor will cause any unsaved data on the current map will be lost.  Do you want to exit the map editor?", "Gigaloth Games Editor",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                game.Exit();
                Application.Exit();
            }
            game.isInputSuspended = false;

        }


        #endregion

        #region VIEW MENU
        private void showWorldGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isWorldGridOn = !game.isWorldGridOn;
            showWorldGridToolStripMenuItem.Checked = !showWorldGridToolStripMenuItem.Checked;
        }

        private void showTextOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isTextOverlayOn = !game.isTextOverlayOn;
            showTextOverlayToolStripMenuItem.Checked = !showTextOverlayToolStripMenuItem.Checked;
        }

        private void spriteTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isSpriteTypeOverlayOn = !game.isSpriteTypeOverlayOn;
            spriteTypesToolStripMenuItem.Checked = !spriteTypesToolStripMenuItem.Checked;
        }

        private void forewardLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isShowNearerLayers = !game.isShowNearerLayers;
            forewardLayersToolStripMenuItem.Checked = !forewardLayersToolStripMenuItem.Checked;
        }

        #endregion

        #region TILE WINDOW EVENT HANDLERS
        //sets the draw tile to the selected tile in the list view window
        private void listTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            if (listTiles.SelectedIndices.Count > 0)
            {
               
                game.placementSprite.TextureID = TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex];
                game.placementSprite.SpriteRectangle = new Microsoft.Xna.Framework.Rectangle(0, 0, listBoxTileWidth, listBoxTileHeight);
                if (!LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].IsAnimated)
                    game.placementSprite.TextureIndex = listTiles.SelectedIndices[0];
                else game.placementSprite.TextureIndex = listTiles.SelectedIndices[0] * LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].SpritesInRow;
                game.placementSprite.SpriteType = LevelDataManager.levelTextures[game.placementSprite.TextureID].SpriteType;
                labelType.Text = game.placementSprite.SpriteType;
            }

        }

        private void comboBoxTileSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            game.placementSprite.TextureIndex = 0;
            game.placementSprite.TextureID=TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex];
            labelTilesetID.Text = ("ID: " + TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex].ToString());
            listBoxTileWidth = LevelDataManager.SpriteWidth(TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]);
            listBoxTileHeight = LevelDataManager.SpriteHeight(TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]);
            bool isAnimated = LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].IsAnimated;
            LoadTileList(defaultFilepath + LevelDataManager.levelTextures[TilesetComboBoxTextureIDs[comboBoxTileSet.SelectedIndex]].FilePath + ".png",isAnimated);
            game.placementSprite.SpriteRectangle = new Microsoft.Xna.Framework.Rectangle(0, 0, listBoxTileWidth, listBoxTileHeight);
            game.placementSprite.SpriteType = LevelDataManager.levelTextures[game.placementSprite.TextureID].SpriteType;
            labelType.Text = game.placementSprite.SpriteType;
        }

        private void ResetComboBoxTileSet()
        {
            game.isExistingSpriteSelected = false;
            comboBoxTileSet.Items.Clear();
            TilesetComboBoxTextureIDs.Clear();
            foreach (TextureData texture in LevelDataManager.levelTextures)
            {
                if (texture.IsTiled)
                {
                    comboBoxTileSet.Items.Add(texture.FileName);
                    TilesetComboBoxTextureIDs.Add(texture.TextureID);
                }
            }
            comboBoxTileSet.SelectedIndex = comboBoxTileSet.Items.Count - 1;
        }

        #endregion

        #region TEXTURE BAR
        private void ResetComboBoxTexture()
        {
            game.isExistingSpriteSelected = false;
            comboBoxTexture.Items.Clear();
            foreach (TextureData texture in LevelDataManager.levelTextures)
            {
                comboBoxTexture.Items.Add(texture.FileName);
            }
            comboBoxTexture.SelectedIndex = comboBoxTexture.Items.Count - 1;
        }
        
        private void comboBoxTexture_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            int texID =  LevelDataManager.IsTextureLoaded((string)comboBoxTexture.Items[comboBoxTexture.SelectedIndex]);
            game.placementSprite.TextureIndex = 0;
            game.placementSprite.TextureID = texID;
            game.placementSprite.SpriteRectangle = new Microsoft.Xna.Framework.Rectangle (0,0,LevelDataManager.SpriteWidth(texID), LevelDataManager.SpriteHeight(texID));
            game.placementSprite.SpriteType = LevelDataManager.levelTextures[texID].SpriteType;
            labelType.Text = LevelDataManager.levelTextures[texID].SpriteType;
            labelTextureID.Text = ("ID: " + texID.ToString() );
        }

        #region QUICK BACKGROUND

        private void buttonBackgroundApply_Click(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            game.isInputSuspended = true;
            // Display a message box warning 
            string deleteLayerMessage = "Sprites in Layer : " + game.parallaxEngine.worldLayers[game.editingLayer].LayerName + " : " + game.parallaxEngine.worldLayers[game.editingLayer].SpriteCount.ToString();
            if (MessageBox.Show("Create a new layer, and set parallax first! Selected texture will be lined up with bottom left corner of the worldspace and repeated horizontally. All sprites placed on this layer will be lost. Do you want to continue? " + deleteLayerMessage,
                                "Gigaloth Games Editor",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                
                Sprite newBackgroundSprite = new Sprite(LevelDataManager.IsTextureLoaded((string)comboBoxTexture.Items[comboBoxTexture.SelectedIndex]), 0, Vector2.Zero);
                CreateRepeatingBackground( game.editingLayer, newBackgroundSprite);
                game.parallaxEngine.worldLayers[game.editingLayer].LayerName = (string)comboBoxTexture.Items[comboBoxTexture.SelectedIndex];
                bindingListLayers.ResetItem(game.editingLayer);
            }
            game.isInputSuspended = false;
        }

        //adds the sprite to the layer and clones horizontally enough times so that the edge of one will never show within bounds defined by the camera's world rectangle
        //initialize the sprite with a texture before passing to function
        public void CreateRepeatingBackground(int layerIndex, Sprite startingSprite)
        {
            game.parallaxEngine.worldLayers[game.editingLayer].layerSprites.Clear();
            //setup variables, clear the list
            float layerWidth = 1280.0f + (game.parallaxEngine.worldLayers[game.editingLayer].LayerParallax.X * ((float)game.worldWidth - 1280.0f));
            int numberOfSprites = (int)(layerWidth-1 / startingSprite.Texture.Width) +1 ;
            
            Camera.Move(new Vector2(-Camera.Position.X, game.worldHeight - Camera.ViewportHeight - Camera.Position.Y));  //set camera to bottom left

            numberOfSprites += -1*(int)numericUpDownXOffset.Value / startingSprite.Texture.Width;
            
            int yalign = (720 - startingSprite.Texture.Height + (int)numericUpDownYOffset.Value);
            for(int i = 0; i < numberOfSprites; i++)
            {
                int xalign = (i * startingSprite.Texture.Width) + (int)numericUpDownXOffset.Value;
                startingSprite.Location = Camera.ScreenToWorld(new Vector2( xalign , yalign), game.parallaxEngine.worldLayers[game.editingLayer].LayerParallax);
                game.parallaxEngine.worldLayers[game.editingLayer].CopySpriteToLayer(startingSprite);
            }
        }

        #endregion

        #endregion

        #region RIGHT CLICK MODE BUTTON HANDLERS

        private void radioClearTile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioClearTile.Checked)
            {
                game.rightClickMode = Game1.RightClickMode.ClearTile;
                radioPlace.Checked = false;
            }
        }

        private void radioPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPlace.Checked)
            {
                game.rightClickMode = Game1.RightClickMode.PlaceTile;
                radioClearTile.Checked = false;
            }
        }

        #endregion

        #region PLACE MODE BUTTON HANDLERS
        private void radioSnapToGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSnapToGrid.Checked)
            {
                game.placeMode = Game1.PlaceMode.GridSnap;
                radioFreePlace.Checked = false;
            }
        }

        private void radioFreePlace_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFreePlace.Checked)
            {
                game.placeMode = Game1.PlaceMode.FreePlace;
                radioSnapToGrid.Checked = false;
            }
        }

        private void checkBoxSelectSpriteMode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectSpriteMode.CheckState == CheckState.Checked) game.isSelectSpriteMode = true;
            if (checkBoxSelectSpriteMode.CheckState == CheckState.Unchecked)
            {
                game.isSelectSpriteMode = false;
                game.isExistingSpriteSelected = false;
            }
        }

        #endregion

        #region SPRITE CONTROLS

        private void numericUpDownRotation_ValueChanged(object sender, EventArgs e)
        {

            game.placementSprite.TotalRotation = MathHelper.ToRadians((float)numericUpDownRotation.Value);

            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TotalRotation = MathHelper.ToRadians((float)numericUpDownRotation.Value);
            }
        }

        private void numericUpDownHP_ValueChanged(object sender, EventArgs e)
        {
            game.placementSprite.HitPoints = (int)numericUpDownHP.Value;

            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].HitPoints = (int)numericUpDownHP.Value;
            }
        }

        private void numericUpDownTimer_ValueChanged(object sender, EventArgs e)
        {
            game.placementSprite.TimeDelay = (float)numericUpDownTimer.Value /100f;

            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TimeDelay = (float)numericUpDownTimer.Value /100f;
            }
        }


        private void checkBoxFlipX_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxFlipX.CheckState == CheckState.Checked)
            {
                checkBoxFlipY.CheckState = CheckState.Unchecked;
                game.placementSprite.IsFlippedHorizontally = true;

            }
            if (checkBoxFlipX.CheckState == CheckState.Unchecked) game.placementSprite.IsFlippedHorizontally = false;

            if (game.isExistingSpriteSelected)
            {
                if (checkBoxFlipX.CheckState == CheckState.Checked)
                {
                    checkBoxFlipY.CheckState = CheckState.Unchecked;
                    game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsFlippedHorizontally = true;

                }
                if (checkBoxFlipX.CheckState == CheckState.Unchecked) game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsFlippedHorizontally = false;
            }
        }

        private void checkBoxFlipY_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxFlipY.CheckState == CheckState.Checked)
            {
                checkBoxFlipX.CheckState = CheckState.Unchecked;
                game.placementSprite.IsFlippedVertically = true;
            }
            if (checkBoxFlipY.CheckState == CheckState.Unchecked) game.placementSprite.IsFlippedVertically = false;

            if (game.isExistingSpriteSelected)
            {
                if (checkBoxFlipY.CheckState == CheckState.Checked)
                {
                    checkBoxFlipX.CheckState = CheckState.Unchecked;
                    game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsFlippedVertically = true;
                }
                if (checkBoxFlipY.CheckState == CheckState.Unchecked) game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsFlippedVertically = false;
            }
        }

        private void checkBoxPathInertia_CheckStateChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (checkBoxPathInertia.CheckState == CheckState.Checked)
            {
                game.placementSprite.IsPathingInertia = true;
            }
            if (checkBoxPathInertia.CheckState == CheckState.Unchecked) game.placementSprite.IsPathingInertia = false;

            if (game.isExistingSpriteSelected)
            {
                if (checkBoxPathInertia.CheckState == CheckState.Checked)
                {
                    game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsPathingInertia = true;
                }
                if (checkBoxPathInertia.CheckState == CheckState.Unchecked) game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].IsPathingInertia = false;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            game.ActivateSprites();
            return;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            return;
        }

        #endregion

        #region LAYER CONTROLS

        private void comboBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            game.isMouseOverPlacedSprite = false;
            game.editingLayer = comboBoxLayer.SelectedIndex;
            numericUpDownParallax.Value = (decimal)game.parallaxEngine.worldLayers[game.editingLayer].LayerParallax.X;
        }

        private void comboBoxLayer_TextUpdate(object sender, EventArgs e)
        {
            bindingListLayers[game.editingLayer].LayerName = comboBoxLayer.Text;
            bindingListLayers.ResetItem(game.editingLayer);
        }

        private void numericUpDownParallax_ValueChanged(object sender, EventArgs e)
        {
            if ((float)numericUpDownParallax.Value == 1.0f)
                game.parallaxEngine.worldLayers[game.editingLayer].LayerParallax = new Vector2((float)numericUpDownParallax.Value, (float)numericUpDownParallax.Value);
            else
                game.parallaxEngine.worldLayers[game.editingLayer].LayerParallax = new Vector2((float)numericUpDownParallax.Value, (float)numericUpDownParallax.Value/2f);
        }


        #region LAYER MENU


        private void insertNewLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            bindingListLayers.Insert(game.editingLayer + 1, new Layer());
            game.parallaxEngine.worldLayers[game.editingLayer + 1].LayerName = (game.editingLayer + 2).ToString();
            bindingListLayers.ResetItem(game.editingLayer);
            bindingListLayers.ResetItem(game.editingLayer+1);
            comboBoxLayer.SelectedIndex = game.editingLayer + 1;
        }

        private void deleteLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game.parallaxEngine.worldLayers.Count == 1)
            {
                MessageBox.Show("Cannot delete the only layer!  Make a new one then delete this one...");
                return;
            }
            game.isInputSuspended = true;
            game.isExistingSpriteSelected = false;
            string deleteLayerMessage = "Sprites in Layer : " + game.parallaxEngine.worldLayers[game.editingLayer].LayerName + " : " + game.parallaxEngine.worldLayers[game.editingLayer].SpriteCount.ToString();
            if (MessageBox.Show("Deleting this layer will also delete all sprites placed on this layer. Do you want to delete this layer? " + deleteLayerMessage,
                                "Gigaloth Games Editor",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question)
             == DialogResult.Yes)
            {
                bindingListLayers.RemoveAt(game.editingLayer);
                bindingListLayers.ResetItem(game.editingLayer);
            }
            game.isInputSuspended = false;
        }

      
        private void moveLayerBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            if (game.editingLayer <= 0) return;

            Layer bufferLayer = game.parallaxEngine.worldLayers[game.editingLayer].Clone();
            game.parallaxEngine.worldLayers.RemoveAt(game.editingLayer);
            game.parallaxEngine.worldLayers.Insert(game.editingLayer - 1, bufferLayer);
            bindingListLayers.ResetItem(game.editingLayer);
            bindingListLayers.ResetItem(game.editingLayer-1);
            comboBoxLayer.SelectedIndex = game.editingLayer -1;
            
            return;

        }

        private void moveLayerForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.isExistingSpriteSelected = false;
            if (game.editingLayer >= game.parallaxEngine.worldLayers.Count - 1) return;

            Layer bufferLayer = game.parallaxEngine.worldLayers[game.editingLayer].Clone();
            game.parallaxEngine.worldLayers.RemoveAt(game.editingLayer);
            game.parallaxEngine.worldLayers.Insert(game.editingLayer + 1, bufferLayer);
            bindingListLayers.ResetItem(game.editingLayer);
            bindingListLayers.ResetItem(game.editingLayer+1);
            comboBoxLayer.SelectedIndex = game.editingLayer+1;
            return;
        }
        #endregion
        #endregion

        #region WORLD-LEVEL-SAVE BAR
        private void comboBoxWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.world = comboBoxWorld.SelectedIndex;
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.level = comboBoxLevel.SelectedIndex;
        }

        private void buttonSaveMap_Click(object sender, EventArgs e)
        {
            game.isInputSuspended = true;
            if (MessageBox.Show("Overwrite Save Data " + game.world.ToString() + "_" + game.level.ToString() + ".lvl ?", "Gigaloth Games Editor",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                  == DialogResult.Yes)
            {
                game.SaveMap(defaultFilepath);
                MessageBox.Show("File Save Complete");
            }
            game.isInputSuspended = false;
        }
        #endregion

        #region PATHING CONTROLS
        private void comboBoxPathing_SelectedIndexChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].pathing = (Sprite.Pathing)comboBoxPathing.SelectedIndex;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }
            else
            {
                game.placementSprite.pathing = (Sprite.Pathing)comboBoxPathing.SelectedIndex;
                game.placementSprite.InitPathingPoint();
            }
            return;
        }

        private void numericUpDownPathingX_ValueChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusX = (int)numericUpDownPathingX.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }
            else
            {
                game.placementSprite.PathingRadiusX = (int)numericUpDownPathingX.Value;
                game.placementSprite.InitPathingPoint();
            }
            return;
        }

        private void numericUpDownPathingY_ValueChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusY = (int)numericUpDownPathingY.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }
            else
            {
                game.placementSprite.PathingRadiusY = (int)numericUpDownPathingY.Value;
                game.placementSprite.InitPathingPoint();
            }
            return;
        }

        private void numericUpDownPathingSpeed_ValueChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingSpeed = (int)numericUpDownPathingSpeed.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();

            }
            else
            {
                game.placementSprite.PathingSpeed = (int)numericUpDownPathingSpeed.Value;
                game.placementSprite.InitPathingPoint();
            }
            return;
        }

        private void numericUpDownPathingPercent_ValueChanged(object sender, EventArgs e)
        {
            game.DeactivateSprites();
            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingPercentComplete = (int)numericUpDownPathingPercent.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }
            else
            {
                game.placementSprite.PathingPercentComplete = (int)numericUpDownPathingPercent.Value;
                game.placementSprite.InitPathingPoint();
            }
            return;
        }

        #endregion


        private void MapEditor_FormClosed(object sender, FormClosedEventArgs e)
        {

                game.Exit();
                Application.Exit();

        }

        public void SetControlsExistingSelected()
        {

            game.isSpriteJustSelected = false;
            comboBoxPathing.SelectedIndex = (int)game.placementSprite.pathing;
            numericUpDownPathingX.Value = (decimal)game.placementSprite.PathingRadiusX;
            numericUpDownPathingY.Value = (decimal)game.placementSprite.PathingRadiusY;
            numericUpDownPathingSpeed.Value = (decimal)game.placementSprite.PathingSpeed;
            numericUpDownPathingPercent.Value = (decimal)game.placementSprite.PathingPercentComplete;
            numericUpDownTimer.Value = (decimal)(int)(game.placementSprite.TimeDelay * 100);
            if (game.placementSprite.IsFlippedHorizontally)
            {
                checkBoxFlipX.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxFlipX.CheckState = CheckState.Unchecked;
            }
            if (game.placementSprite.IsFlippedVertically)
            {
                checkBoxFlipY.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxFlipY.CheckState = CheckState.Unchecked;
            }
            if (game.placementSprite.IsPathingInertia)
            {
                checkBoxPathInertia.CheckState = CheckState.Checked;
            }
            else
            {
                checkBoxPathInertia.CheckState = CheckState.Unchecked;
            }


            numericUpDownRotation.Value = (decimal)MathHelper.ToDegrees(game.placementSprite.TotalRotation);
            numericUpDownHP.Value = (decimal)game.placementSprite.HitPoints;

            labelType.Text = game.placementSprite.SpriteType;
            
            return;
        }

        //apply values of all the numeric UpDowns
        private void buttonSet_Click(object sender, EventArgs e)
        {
            game.DeactivateSprites();

            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TotalRotation = MathHelper.ToRadians((float)numericUpDownRotation.Value);
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].HitPoints = (int)numericUpDownHP.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].pathing = (Sprite.Pathing)comboBoxPathing.SelectedIndex;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusX = (int)numericUpDownPathingX.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusY = (int)numericUpDownPathingY.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingSpeed = (int)numericUpDownPathingSpeed.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingPercentComplete = (int)numericUpDownPathingPercent.Value;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TimeDelay = (float)numericUpDownTimer.Value /100f;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }
            else
            {
                game.placementSprite.TotalRotation = MathHelper.ToRadians((float)numericUpDownRotation.Value);
                game.placementSprite.HitPoints = (int)numericUpDownHP.Value;
                game.placementSprite.pathing = (Sprite.Pathing)comboBoxPathing.SelectedIndex;
                game.placementSprite.PathingRadiusX = (int)numericUpDownPathingX.Value;
                game.placementSprite.PathingRadiusY = (int)numericUpDownPathingY.Value;
                game.placementSprite.PathingSpeed = (int)numericUpDownPathingSpeed.Value;
                game.placementSprite.PathingPercentComplete = (int)numericUpDownPathingPercent.Value;
                game.placementSprite.TimeDelay = (float)numericUpDownTimer.Value /100f;
                game.placementSprite.InitPathingPoint();
            }

            return;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            game.DeactivateSprites();

            if (game.isExistingSpriteSelected)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TotalRotation = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].HitPoints = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].pathing = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusX = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingRadiusY = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingSpeed = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].PathingPercentComplete = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].TimeDelay = 0;
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[game.selectedSpriteIndex].InitPathingPoint();
            }

                game.placementSprite.TotalRotation = 0;
                game.placementSprite.HitPoints = 0;
                game.placementSprite.pathing = 0;
                game.placementSprite.PathingRadiusX = 0;
                game.placementSprite.PathingRadiusY = 0;
                game.placementSprite.PathingSpeed = 0;
                game.placementSprite.PathingPercentComplete = 0;
                game.placementSprite.TimeDelay = 0;
                game.placementSprite.InitPathingPoint();

            SetControlsExistingSelected();
        }

        private void buttonLayerMove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < game.parallaxEngine.worldLayers[game.editingLayer].SpriteCount; i++)
            {
                game.parallaxEngine.worldLayers[game.editingLayer].layerSprites[i].Location += 
                       new Vector2((float)numericUpDownLayerMoveX.Value,(float)numericUpDownLayerMoveY.Value);
            }
            return;
        }











































































    }
}
