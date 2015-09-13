namespace GigalothMapEditor
{
    partial class MapEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vIEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWorldGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTextOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spriteTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forewardLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertNewLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLayerBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLayerForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.listTiles = new System.Windows.Forms.ListView();
            this.imgListTiles = new System.Windows.Forms.ImageList(this.components);
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.labelTilesetID = new System.Windows.Forms.Label();
            this.comboBoxTileSet = new System.Windows.Forms.ComboBox();
            this.labelTileSet = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.comboBoxWorld = new System.Windows.Forms.ComboBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.labelWorld = new System.Windows.Forms.Label();
            this.labelLayer = new System.Windows.Forms.Label();
            this.comboBoxLayer = new System.Windows.Forms.ComboBox();
            this.groupBoxRightClick = new System.Windows.Forms.GroupBox();
            this.radioPlace = new System.Windows.Forms.RadioButton();
            this.radioClearTile = new System.Windows.Forms.RadioButton();
            this.timerGameUpdate = new System.Windows.Forms.Timer(this.components);
            this.groupBoxPlaceMode = new System.Windows.Forms.GroupBox();
            this.radioSnapToGrid = new System.Windows.Forms.RadioButton();
            this.radioFreePlace = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonBackgroundApply = new System.Windows.Forms.Button();
            this.labelParallax = new System.Windows.Forms.Label();
            this.numericUpDownParallax = new System.Windows.Forms.NumericUpDown();
            this.labelparallaxx = new System.Windows.Forms.Label();
            this.comboBoxTexture = new System.Windows.Forms.ComboBox();
            this.labelTexture = new System.Windows.Forms.Label();
            this.labelTextureID = new System.Windows.Forms.Label();
            this.buttonSaveMap = new System.Windows.Forms.Button();
            this.checkBoxSelectSpriteMode = new System.Windows.Forms.CheckBox();
            this.comboBoxPathing = new System.Windows.Forms.ComboBox();
            this.labelPathing = new System.Windows.Forms.Label();
            this.labelPathingX = new System.Windows.Forms.Label();
            this.labelPathingY = new System.Windows.Forms.Label();
            this.numericUpDownPathingX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPathingY = new System.Windows.Forms.NumericUpDown();
            this.labelPathingSpeed = new System.Windows.Forms.Label();
            this.labelPathingStart = new System.Windows.Forms.Label();
            this.numericUpDownPathingPercent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPathingSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelSpriteType = new System.Windows.Forms.Label();
            this.groupBoxSpriteControl = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelHP = new System.Windows.Forms.Label();
            this.numericUpDownHP = new System.Windows.Forms.NumericUpDown();
            this.labelType = new System.Windows.Forms.Label();
            this.numericUpDownTimer = new System.Windows.Forms.NumericUpDown();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.checkBoxPathInertia = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.checkBoxFlipY = new System.Windows.Forms.CheckBox();
            this.checkBoxFlipX = new System.Windows.Forms.CheckBox();
            this.numericUpDownRotation = new System.Windows.Forms.NumericUpDown();
            this.labelRotation = new System.Windows.Forms.Label();
            this.labelXoffset = new System.Windows.Forms.Label();
            this.labelYoffset = new System.Windows.Forms.Label();
            this.numericUpDownXOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownYOffset = new System.Windows.Forms.NumericUpDown();
            this.labelLayerMove = new System.Windows.Forms.Label();
            this.buttonLayerMove = new System.Windows.Forms.Button();
            this.labelLayerMoveX = new System.Windows.Forms.Label();
            this.labelLayerMoveY = new System.Windows.Forms.Label();
            this.numericUpDownLayerMoveX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLayerMoveY = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxRightClick.SuspendLayout();
            this.groupBoxPlaceMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParallax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingSpeed)).BeginInit();
            this.groupBoxSpriteControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerMoveX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerMoveY)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.vIEWToolStripMenuItem,
            this.backgroundLayersToolStripMenuItem,
            this.worldToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1424, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMapToolStripMenuItem,
            this.saveMapToolStripMenuItem,
            this.loadMapToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newMapToolStripMenuItem
            // 
            this.newMapToolStripMenuItem.Name = "newMapToolStripMenuItem";
            this.newMapToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.newMapToolStripMenuItem.Text = "New Map";
            this.newMapToolStripMenuItem.Click += new System.EventHandler(this.newMapToolStripMenuItem_Click);
            // 
            // saveMapToolStripMenuItem
            // 
            this.saveMapToolStripMenuItem.Name = "saveMapToolStripMenuItem";
            this.saveMapToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.saveMapToolStripMenuItem.Text = "Save Map";
            this.saveMapToolStripMenuItem.Click += new System.EventHandler(this.saveMapToolStripMenuItem_Click);
            // 
            // loadMapToolStripMenuItem
            // 
            this.loadMapToolStripMenuItem.Name = "loadMapToolStripMenuItem";
            this.loadMapToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.loadMapToolStripMenuItem.Text = "Load Map";
            this.loadMapToolStripMenuItem.Click += new System.EventHandler(this.loadMapToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // vIEWToolStripMenuItem
            // 
            this.vIEWToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWorldGridToolStripMenuItem,
            this.showTextOverlayToolStripMenuItem,
            this.spriteTypesToolStripMenuItem,
            this.forewardLayersToolStripMenuItem});
            this.vIEWToolStripMenuItem.Name = "vIEWToolStripMenuItem";
            this.vIEWToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.vIEWToolStripMenuItem.Text = "V&iew";
            // 
            // showWorldGridToolStripMenuItem
            // 
            this.showWorldGridToolStripMenuItem.Name = "showWorldGridToolStripMenuItem";
            this.showWorldGridToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showWorldGridToolStripMenuItem.Text = "World Grid";
            this.showWorldGridToolStripMenuItem.Click += new System.EventHandler(this.showWorldGridToolStripMenuItem_Click);
            // 
            // showTextOverlayToolStripMenuItem
            // 
            this.showTextOverlayToolStripMenuItem.Name = "showTextOverlayToolStripMenuItem";
            this.showTextOverlayToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.showTextOverlayToolStripMenuItem.Text = "Text Overlay";
            this.showTextOverlayToolStripMenuItem.Click += new System.EventHandler(this.showTextOverlayToolStripMenuItem_Click);
            // 
            // spriteTypesToolStripMenuItem
            // 
            this.spriteTypesToolStripMenuItem.Name = "spriteTypesToolStripMenuItem";
            this.spriteTypesToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.spriteTypesToolStripMenuItem.Text = "Sprite Types";
            this.spriteTypesToolStripMenuItem.Click += new System.EventHandler(this.spriteTypesToolStripMenuItem_Click);
            // 
            // forewardLayersToolStripMenuItem
            // 
            this.forewardLayersToolStripMenuItem.Name = "forewardLayersToolStripMenuItem";
            this.forewardLayersToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.forewardLayersToolStripMenuItem.Text = "Show Nearer Layers";
            this.forewardLayersToolStripMenuItem.Click += new System.EventHandler(this.forewardLayersToolStripMenuItem_Click);
            // 
            // backgroundLayersToolStripMenuItem
            // 
            this.backgroundLayersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertNewLayerToolStripMenuItem,
            this.deleteLayerToolStripMenuItem,
            this.moveLayerBackToolStripMenuItem,
            this.moveLayerForwardToolStripMenuItem});
            this.backgroundLayersToolStripMenuItem.Name = "backgroundLayersToolStripMenuItem";
            this.backgroundLayersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.backgroundLayersToolStripMenuItem.Text = "Layer";
            // 
            // insertNewLayerToolStripMenuItem
            // 
            this.insertNewLayerToolStripMenuItem.Name = "insertNewLayerToolStripMenuItem";
            this.insertNewLayerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.insertNewLayerToolStripMenuItem.Text = "Add Layer";
            this.insertNewLayerToolStripMenuItem.Click += new System.EventHandler(this.insertNewLayerToolStripMenuItem_Click);
            // 
            // deleteLayerToolStripMenuItem
            // 
            this.deleteLayerToolStripMenuItem.Name = "deleteLayerToolStripMenuItem";
            this.deleteLayerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.deleteLayerToolStripMenuItem.Text = "Delete Layer";
            this.deleteLayerToolStripMenuItem.Click += new System.EventHandler(this.deleteLayerToolStripMenuItem_Click);
            // 
            // moveLayerBackToolStripMenuItem
            // 
            this.moveLayerBackToolStripMenuItem.Name = "moveLayerBackToolStripMenuItem";
            this.moveLayerBackToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.moveLayerBackToolStripMenuItem.Text = "Move Layer Back";
            this.moveLayerBackToolStripMenuItem.Click += new System.EventHandler(this.moveLayerBackToolStripMenuItem_Click);
            // 
            // moveLayerForwardToolStripMenuItem
            // 
            this.moveLayerForwardToolStripMenuItem.Name = "moveLayerForwardToolStripMenuItem";
            this.moveLayerForwardToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.moveLayerForwardToolStripMenuItem.Text = "Move Layer Forward";
            this.moveLayerForwardToolStripMenuItem.Click += new System.EventHandler(this.moveLayerForwardToolStripMenuItem_Click);
            // 
            // worldToolStripMenuItem
            // 
            this.worldToolStripMenuItem.Name = "worldToolStripMenuItem";
            this.worldToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.worldToolStripMenuItem.Text = "World ";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.Location = new System.Drawing.Point(126, 124);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // listTiles
            // 
            this.listTiles.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listTiles.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listTiles.BackColor = System.Drawing.SystemColors.ControlDark;
            this.listTiles.GridLines = true;
            this.listTiles.HideSelection = false;
            this.listTiles.LabelWrap = false;
            this.listTiles.LargeImageList = this.imgListTiles;
            this.listTiles.Location = new System.Drawing.Point(301, 0);
            this.listTiles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listTiles.MultiSelect = false;
            this.listTiles.Name = "listTiles";
            this.listTiles.ShowGroups = false;
            this.listTiles.Size = new System.Drawing.Size(1105, 118);
            this.listTiles.SmallImageList = this.imgListTiles;
            this.listTiles.TabIndex = 2;
            this.listTiles.TileSize = new System.Drawing.Size(96, 96);
            this.listTiles.UseCompatibleStateImageBehavior = false;
            this.listTiles.SelectedIndexChanged += new System.EventHandler(this.listTiles_SelectedIndexChanged);
            // 
            // imgListTiles
            // 
            this.imgListTiles.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListTiles.ImageSize = new System.Drawing.Size(96, 96);
            this.imgListTiles.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 1;
            this.vScrollBar1.Location = new System.Drawing.Point(1406, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(18, 844);
            this.vScrollBar1.TabIndex = 3;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 1;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 844);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1406, 18);
            this.hScrollBar1.TabIndex = 4;
            // 
            // labelTilesetID
            // 
            this.labelTilesetID.AutoSize = true;
            this.labelTilesetID.BackColor = System.Drawing.Color.Transparent;
            this.labelTilesetID.Location = new System.Drawing.Point(211, 75);
            this.labelTilesetID.Name = "labelTilesetID";
            this.labelTilesetID.Size = new System.Drawing.Size(25, 15);
            this.labelTilesetID.TabIndex = 11;
            this.labelTilesetID.Text = "ID:";
            // 
            // comboBoxTileSet
            // 
            this.comboBoxTileSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTileSet.FormattingEnabled = true;
            this.comboBoxTileSet.Location = new System.Drawing.Point(154, 95);
            this.comboBoxTileSet.Name = "comboBoxTileSet";
            this.comboBoxTileSet.Size = new System.Drawing.Size(140, 23);
            this.comboBoxTileSet.TabIndex = 4;
            this.comboBoxTileSet.SelectedIndexChanged += new System.EventHandler(this.comboBoxTileSet_SelectedIndexChanged);
            // 
            // labelTileSet
            // 
            this.labelTileSet.AutoSize = true;
            this.labelTileSet.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTileSet.Location = new System.Drawing.Point(127, 75);
            this.labelTileSet.Name = "labelTileSet";
            this.labelTileSet.Size = new System.Drawing.Size(70, 15);
            this.labelTileSet.TabIndex = 3;
            this.labelTileSet.Text = "TILESET:";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.Location = new System.Drawing.Point(10, 53);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(60, 15);
            this.labelLevel.TabIndex = 7;
            this.labelLevel.Text = "LEVEL :";
            // 
            // comboBoxWorld
            // 
            this.comboBoxWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorld.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWorld.FormattingEnabled = true;
            this.comboBoxWorld.IntegralHeight = false;
            this.comboBoxWorld.Location = new System.Drawing.Point(72, 27);
            this.comboBoxWorld.Name = "comboBoxWorld";
            this.comboBoxWorld.Size = new System.Drawing.Size(49, 23);
            this.comboBoxWorld.TabIndex = 6;
            this.comboBoxWorld.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorld_SelectedIndexChanged);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.IntegralHeight = false;
            this.comboBoxLevel.Location = new System.Drawing.Point(72, 53);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(49, 23);
            this.comboBoxLevel.TabIndex = 8;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // labelWorld
            // 
            this.labelWorld.AutoSize = true;
            this.labelWorld.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorld.Location = new System.Drawing.Point(4, 32);
            this.labelWorld.Name = "labelWorld";
            this.labelWorld.Size = new System.Drawing.Size(67, 15);
            this.labelWorld.TabIndex = 5;
            this.labelWorld.Text = "WORLD :";
            // 
            // labelLayer
            // 
            this.labelLayer.AutoSize = true;
            this.labelLayer.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLayer.Location = new System.Drawing.Point(127, 30);
            this.labelLayer.Name = "labelLayer";
            this.labelLayer.Size = new System.Drawing.Size(62, 15);
            this.labelLayer.TabIndex = 2;
            this.labelLayer.Text = "LAYER :";
            // 
            // comboBoxLayer
            // 
            this.comboBoxLayer.DisplayMember = "index";
            this.comboBoxLayer.FormattingEnabled = true;
            this.comboBoxLayer.Location = new System.Drawing.Point(186, 27);
            this.comboBoxLayer.Name = "comboBoxLayer";
            this.comboBoxLayer.Size = new System.Drawing.Size(108, 23);
            this.comboBoxLayer.TabIndex = 1;
            this.comboBoxLayer.Text = "Layer Name";
            this.comboBoxLayer.ValueMember = "LayerName";
            this.comboBoxLayer.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayer_SelectedIndexChanged);
            this.comboBoxLayer.TextUpdate += new System.EventHandler(this.comboBoxLayer_TextUpdate);
            // 
            // groupBoxRightClick
            // 
            this.groupBoxRightClick.Controls.Add(this.radioPlace);
            this.groupBoxRightClick.Controls.Add(this.radioClearTile);
            this.groupBoxRightClick.Location = new System.Drawing.Point(0, 190);
            this.groupBoxRightClick.Name = "groupBoxRightClick";
            this.groupBoxRightClick.Size = new System.Drawing.Size(121, 67);
            this.groupBoxRightClick.TabIndex = 6;
            this.groupBoxRightClick.TabStop = false;
            this.groupBoxRightClick.Text = "RIGHT CLICK";
            // 
            // radioPlace
            // 
            this.radioPlace.AutoSize = true;
            this.radioPlace.Checked = true;
            this.radioPlace.Location = new System.Drawing.Point(6, 19);
            this.radioPlace.Name = "radioPlace";
            this.radioPlace.Size = new System.Drawing.Size(82, 17);
            this.radioPlace.TabIndex = 6;
            this.radioPlace.TabStop = true;
            this.radioPlace.Text = "Place Mode";
            this.radioPlace.UseVisualStyleBackColor = true;
            this.radioPlace.CheckedChanged += new System.EventHandler(this.radioPlace_CheckedChanged);
            // 
            // radioClearTile
            // 
            this.radioClearTile.AutoSize = true;
            this.radioClearTile.Location = new System.Drawing.Point(6, 42);
            this.radioClearTile.Name = "radioClearTile";
            this.radioClearTile.Size = new System.Drawing.Size(79, 17);
            this.radioClearTile.TabIndex = 5;
            this.radioClearTile.Text = "Clear Mode";
            this.radioClearTile.UseVisualStyleBackColor = true;
            this.radioClearTile.CheckedChanged += new System.EventHandler(this.radioClearTile_CheckedChanged);
            // 
            // timerGameUpdate
            // 
            this.timerGameUpdate.Enabled = true;
            this.timerGameUpdate.Interval = 20;
            this.timerGameUpdate.Tick += new System.EventHandler(this.timerGameUpdate_Tick);
            // 
            // groupBoxPlaceMode
            // 
            this.groupBoxPlaceMode.Controls.Add(this.radioSnapToGrid);
            this.groupBoxPlaceMode.Controls.Add(this.radioFreePlace);
            this.groupBoxPlaceMode.Location = new System.Drawing.Point(0, 124);
            this.groupBoxPlaceMode.Name = "groupBoxPlaceMode";
            this.groupBoxPlaceMode.Size = new System.Drawing.Size(121, 67);
            this.groupBoxPlaceMode.TabIndex = 9;
            this.groupBoxPlaceMode.TabStop = false;
            this.groupBoxPlaceMode.Text = "PLACE MODE";
            // 
            // radioSnapToGrid
            // 
            this.radioSnapToGrid.AutoSize = true;
            this.radioSnapToGrid.Checked = true;
            this.radioSnapToGrid.Location = new System.Drawing.Point(6, 20);
            this.radioSnapToGrid.Name = "radioSnapToGrid";
            this.radioSnapToGrid.Size = new System.Drawing.Size(72, 17);
            this.radioSnapToGrid.TabIndex = 6;
            this.radioSnapToGrid.TabStop = true;
            this.radioSnapToGrid.Text = "Grid Snap";
            this.radioSnapToGrid.UseVisualStyleBackColor = true;
            this.radioSnapToGrid.CheckedChanged += new System.EventHandler(this.radioSnapToGrid_CheckedChanged);
            // 
            // radioFreePlace
            // 
            this.radioFreePlace.AutoSize = true;
            this.radioFreePlace.Location = new System.Drawing.Point(6, 43);
            this.radioFreePlace.Name = "radioFreePlace";
            this.radioFreePlace.Size = new System.Drawing.Size(76, 17);
            this.radioFreePlace.TabIndex = 5;
            this.radioFreePlace.Text = "Free Place";
            this.radioFreePlace.UseVisualStyleBackColor = true;
            this.radioFreePlace.CheckedChanged += new System.EventHandler(this.radioFreePlace_CheckedChanged);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = System.Drawing.Color.Silver;
            this.colorDialog.FullOpen = true;
            // 
            // buttonBackgroundApply
            // 
            this.buttonBackgroundApply.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackgroundApply.Location = new System.Drawing.Point(4, 721);
            this.buttonBackgroundApply.Name = "buttonBackgroundApply";
            this.buttonBackgroundApply.Size = new System.Drawing.Size(117, 23);
            this.buttonBackgroundApply.TabIndex = 17;
            this.buttonBackgroundApply.Text = "Auto Background";
            this.buttonBackgroundApply.UseVisualStyleBackColor = true;
            this.buttonBackgroundApply.Click += new System.EventHandler(this.buttonBackgroundApply_Click);
            // 
            // labelParallax
            // 
            this.labelParallax.AutoSize = true;
            this.labelParallax.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParallax.Location = new System.Drawing.Point(127, 55);
            this.labelParallax.Name = "labelParallax";
            this.labelParallax.Size = new System.Drawing.Size(89, 15);
            this.labelParallax.TabIndex = 41;
            this.labelParallax.Text = "PARALLAX:";
            // 
            // numericUpDownParallax
            // 
            this.numericUpDownParallax.DecimalPlaces = 2;
            this.numericUpDownParallax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownParallax.Location = new System.Drawing.Point(214, 51);
            this.numericUpDownParallax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownParallax.Name = "numericUpDownParallax";
            this.numericUpDownParallax.Size = new System.Drawing.Size(59, 23);
            this.numericUpDownParallax.TabIndex = 42;
            this.numericUpDownParallax.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.numericUpDownParallax.ValueChanged += new System.EventHandler(this.numericUpDownParallax_ValueChanged);
            // 
            // labelparallaxx
            // 
            this.labelparallaxx.AutoSize = true;
            this.labelparallaxx.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelparallaxx.Location = new System.Drawing.Point(279, 56);
            this.labelparallaxx.Name = "labelparallaxx";
            this.labelparallaxx.Size = new System.Drawing.Size(15, 15);
            this.labelparallaxx.TabIndex = 43;
            this.labelparallaxx.Text = "x";
            // 
            // comboBoxTexture
            // 
            this.comboBoxTexture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTexture.FormattingEnabled = true;
            this.comboBoxTexture.Location = new System.Drawing.Point(4, 638);
            this.comboBoxTexture.Name = "comboBoxTexture";
            this.comboBoxTexture.Size = new System.Drawing.Size(117, 23);
            this.comboBoxTexture.TabIndex = 44;
            this.comboBoxTexture.SelectedIndexChanged += new System.EventHandler(this.comboBoxTexture_SelectedIndexChanged);
            // 
            // labelTexture
            // 
            this.labelTexture.AutoSize = true;
            this.labelTexture.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTexture.Location = new System.Drawing.Point(1, 620);
            this.labelTexture.Name = "labelTexture";
            this.labelTexture.Size = new System.Drawing.Size(74, 15);
            this.labelTexture.TabIndex = 45;
            this.labelTexture.Text = "TEXTURE";
            // 
            // labelTextureID
            // 
            this.labelTextureID.AutoSize = true;
            this.labelTextureID.BackColor = System.Drawing.Color.Transparent;
            this.labelTextureID.Location = new System.Drawing.Point(83, 620);
            this.labelTextureID.Name = "labelTextureID";
            this.labelTextureID.Size = new System.Drawing.Size(25, 15);
            this.labelTextureID.TabIndex = 46;
            this.labelTextureID.Text = "ID:";
            // 
            // buttonSaveMap
            // 
            this.buttonSaveMap.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveMap.Location = new System.Drawing.Point(54, 77);
            this.buttonSaveMap.Name = "buttonSaveMap";
            this.buttonSaveMap.Size = new System.Drawing.Size(67, 21);
            this.buttonSaveMap.TabIndex = 48;
            this.buttonSaveMap.Text = "Save ";
            this.buttonSaveMap.UseVisualStyleBackColor = true;
            this.buttonSaveMap.Click += new System.EventHandler(this.buttonSaveMap_Click);
            // 
            // checkBoxSelectSpriteMode
            // 
            this.checkBoxSelectSpriteMode.AutoSize = true;
            this.checkBoxSelectSpriteMode.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSelectSpriteMode.Location = new System.Drawing.Point(4, 100);
            this.checkBoxSelectSpriteMode.Name = "checkBoxSelectSpriteMode";
            this.checkBoxSelectSpriteMode.Size = new System.Drawing.Size(128, 18);
            this.checkBoxSelectSpriteMode.TabIndex = 49;
            this.checkBoxSelectSpriteMode.Text = "Select Sprite ON";
            this.checkBoxSelectSpriteMode.UseVisualStyleBackColor = true;
            this.checkBoxSelectSpriteMode.CheckedChanged += new System.EventHandler(this.checkBoxSelectSpriteMode_CheckedChanged);
            // 
            // comboBoxPathing
            // 
            this.comboBoxPathing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPathing.FormattingEnabled = true;
            this.comboBoxPathing.Location = new System.Drawing.Point(6, 156);
            this.comboBoxPathing.Name = "comboBoxPathing";
            this.comboBoxPathing.Size = new System.Drawing.Size(105, 23);
            this.comboBoxPathing.TabIndex = 50;
            this.comboBoxPathing.SelectedIndexChanged += new System.EventHandler(this.comboBoxPathing_SelectedIndexChanged);
            // 
            // labelPathing
            // 
            this.labelPathing.AutoSize = true;
            this.labelPathing.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPathing.Location = new System.Drawing.Point(5, 139);
            this.labelPathing.Name = "labelPathing";
            this.labelPathing.Size = new System.Drawing.Size(66, 14);
            this.labelPathing.TabIndex = 51;
            this.labelPathing.Text = "PATHING:";
            // 
            // labelPathingX
            // 
            this.labelPathingX.AutoSize = true;
            this.labelPathingX.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPathingX.Location = new System.Drawing.Point(4, 207);
            this.labelPathingX.Name = "labelPathingX";
            this.labelPathingX.Size = new System.Drawing.Size(51, 14);
            this.labelPathingX.TabIndex = 52;
            this.labelPathingX.Text = "X DIST:";
            // 
            // labelPathingY
            // 
            this.labelPathingY.AutoSize = true;
            this.labelPathingY.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPathingY.Location = new System.Drawing.Point(4, 229);
            this.labelPathingY.Name = "labelPathingY";
            this.labelPathingY.Size = new System.Drawing.Size(51, 14);
            this.labelPathingY.TabIndex = 53;
            this.labelPathingY.Text = "Y DIST:";
            // 
            // numericUpDownPathingX
            // 
            this.numericUpDownPathingX.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPathingX.Location = new System.Drawing.Point(57, 205);
            this.numericUpDownPathingX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPathingX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPathingX.Name = "numericUpDownPathingX";
            this.numericUpDownPathingX.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownPathingX.TabIndex = 54;
            this.numericUpDownPathingX.ValueChanged += new System.EventHandler(this.numericUpDownPathingX_ValueChanged);
            // 
            // numericUpDownPathingY
            // 
            this.numericUpDownPathingY.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPathingY.Location = new System.Drawing.Point(57, 227);
            this.numericUpDownPathingY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPathingY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPathingY.Name = "numericUpDownPathingY";
            this.numericUpDownPathingY.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownPathingY.TabIndex = 55;
            this.numericUpDownPathingY.ValueChanged += new System.EventHandler(this.numericUpDownPathingY_ValueChanged);
            // 
            // labelPathingSpeed
            // 
            this.labelPathingSpeed.AutoSize = true;
            this.labelPathingSpeed.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPathingSpeed.Location = new System.Drawing.Point(3, 252);
            this.labelPathingSpeed.Name = "labelPathingSpeed";
            this.labelPathingSpeed.Size = new System.Drawing.Size(53, 14);
            this.labelPathingSpeed.TabIndex = 56;
            this.labelPathingSpeed.Text = "SPEED:";
            // 
            // labelPathingStart
            // 
            this.labelPathingStart.AutoSize = true;
            this.labelPathingStart.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPathingStart.Location = new System.Drawing.Point(3, 274);
            this.labelPathingStart.Name = "labelPathingStart";
            this.labelPathingStart.Size = new System.Drawing.Size(63, 14);
            this.labelPathingStart.TabIndex = 57;
            this.labelPathingStart.Text = "START %:";
            // 
            // numericUpDownPathingPercent
            // 
            this.numericUpDownPathingPercent.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPathingPercent.Location = new System.Drawing.Point(65, 272);
            this.numericUpDownPathingPercent.Name = "numericUpDownPathingPercent";
            this.numericUpDownPathingPercent.Size = new System.Drawing.Size(47, 21);
            this.numericUpDownPathingPercent.TabIndex = 58;
            this.numericUpDownPathingPercent.ValueChanged += new System.EventHandler(this.numericUpDownPathingPercent_ValueChanged);
            // 
            // numericUpDownPathingSpeed
            // 
            this.numericUpDownPathingSpeed.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPathingSpeed.Location = new System.Drawing.Point(58, 250);
            this.numericUpDownPathingSpeed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownPathingSpeed.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownPathingSpeed.Name = "numericUpDownPathingSpeed";
            this.numericUpDownPathingSpeed.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownPathingSpeed.TabIndex = 59;
            this.numericUpDownPathingSpeed.ValueChanged += new System.EventHandler(this.numericUpDownPathingSpeed_ValueChanged);
            // 
            // labelSpriteType
            // 
            this.labelSpriteType.AutoSize = true;
            this.labelSpriteType.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpriteType.Location = new System.Drawing.Point(6, 19);
            this.labelSpriteType.Name = "labelSpriteType";
            this.labelSpriteType.Size = new System.Drawing.Size(42, 14);
            this.labelSpriteType.TabIndex = 24;
            this.labelSpriteType.Text = "TYPE:";
            // 
            // groupBoxSpriteControl
            // 
            this.groupBoxSpriteControl.Controls.Add(this.buttonReset);
            this.groupBoxSpriteControl.Controls.Add(this.labelHP);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownHP);
            this.groupBoxSpriteControl.Controls.Add(this.labelType);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownTimer);
            this.groupBoxSpriteControl.Controls.Add(this.labelTimer);
            this.groupBoxSpriteControl.Controls.Add(this.buttonSet);
            this.groupBoxSpriteControl.Controls.Add(this.checkBoxPathInertia);
            this.groupBoxSpriteControl.Controls.Add(this.buttonStop);
            this.groupBoxSpriteControl.Controls.Add(this.buttonPlay);
            this.groupBoxSpriteControl.Controls.Add(this.checkBoxFlipY);
            this.groupBoxSpriteControl.Controls.Add(this.checkBoxFlipX);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownRotation);
            this.groupBoxSpriteControl.Controls.Add(this.labelRotation);
            this.groupBoxSpriteControl.Controls.Add(this.labelPathingSpeed);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownPathingSpeed);
            this.groupBoxSpriteControl.Controls.Add(this.labelSpriteType);
            this.groupBoxSpriteControl.Controls.Add(this.labelPathingStart);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownPathingPercent);
            this.groupBoxSpriteControl.Controls.Add(this.labelPathing);
            this.groupBoxSpriteControl.Controls.Add(this.comboBoxPathing);
            this.groupBoxSpriteControl.Controls.Add(this.labelPathingX);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownPathingX);
            this.groupBoxSpriteControl.Controls.Add(this.numericUpDownPathingY);
            this.groupBoxSpriteControl.Controls.Add(this.labelPathingY);
            this.groupBoxSpriteControl.Location = new System.Drawing.Point(4, 263);
            this.groupBoxSpriteControl.Name = "groupBoxSpriteControl";
            this.groupBoxSpriteControl.Size = new System.Drawing.Size(117, 344);
            this.groupBoxSpriteControl.TabIndex = 15;
            this.groupBoxSpriteControl.TabStop = false;
            this.groupBoxSpriteControl.Text = "SPRITE";
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(39, 113);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(72, 23);
            this.buttonReset.TabIndex = 72;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHP.Location = new System.Drawing.Point(14, 38);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(44, 14);
            this.labelHP.TabIndex = 71;
            this.labelHP.Text = "VAR1:";
            // 
            // numericUpDownHP
            // 
            this.numericUpDownHP.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHP.Location = new System.Drawing.Point(61, 36);
            this.numericUpDownHP.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownHP.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownHP.Name = "numericUpDownHP";
            this.numericUpDownHP.Size = new System.Drawing.Size(50, 21);
            this.numericUpDownHP.TabIndex = 70;
            this.numericUpDownHP.ValueChanged += new System.EventHandler(this.numericUpDownHP_ValueChanged);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.Location = new System.Drawing.Point(47, 19);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(44, 14);
            this.labelType.TabIndex = 57;
            this.labelType.Text = "NONE";
            // 
            // numericUpDownTimer
            // 
            this.numericUpDownTimer.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTimer.Location = new System.Drawing.Point(58, 294);
            this.numericUpDownTimer.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownTimer.Name = "numericUpDownTimer";
            this.numericUpDownTimer.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownTimer.TabIndex = 69;
            this.numericUpDownTimer.ValueChanged += new System.EventHandler(this.numericUpDownTimer_ValueChanged);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimer.Location = new System.Drawing.Point(5, 296);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(57, 14);
            this.labelTimer.TabIndex = 68;
            this.labelTimer.Text = "P. TIME:";
            // 
            // buttonSet
            // 
            this.buttonSet.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSet.Location = new System.Drawing.Point(6, 315);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(46, 23);
            this.buttonSet.TabIndex = 67;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // checkBoxPathInertia
            // 
            this.checkBoxPathInertia.AutoSize = true;
            this.checkBoxPathInertia.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPathInertia.Location = new System.Drawing.Point(14, 181);
            this.checkBoxPathInertia.Name = "checkBoxPathInertia";
            this.checkBoxPathInertia.Size = new System.Drawing.Size(98, 18);
            this.checkBoxPathInertia.TabIndex = 66;
            this.checkBoxPathInertia.Text = "SlowToStop";
            this.checkBoxPathInertia.UseVisualStyleBackColor = true;
            this.checkBoxPathInertia.CheckStateChanged += new System.EventHandler(this.checkBoxPathInertia_CheckStateChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(82, 315);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(29, 23);
            this.buttonStop.TabIndex = 65;
            this.buttonStop.Text = "[]";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(52, 315);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(29, 23);
            this.buttonPlay.TabIndex = 64;
            this.buttonPlay.Text = ">>";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // checkBoxFlipY
            // 
            this.checkBoxFlipY.AutoSize = true;
            this.checkBoxFlipY.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFlipY.Location = new System.Drawing.Point(7, 96);
            this.checkBoxFlipY.Name = "checkBoxFlipY";
            this.checkBoxFlipY.Size = new System.Drawing.Size(78, 18);
            this.checkBoxFlipY.TabIndex = 63;
            this.checkBoxFlipY.Text = "Mirror Y";
            this.checkBoxFlipY.UseVisualStyleBackColor = true;
            this.checkBoxFlipY.CheckStateChanged += new System.EventHandler(this.checkBoxFlipY_CheckStateChanged);
            // 
            // checkBoxFlipX
            // 
            this.checkBoxFlipX.AutoSize = true;
            this.checkBoxFlipX.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFlipX.Location = new System.Drawing.Point(7, 81);
            this.checkBoxFlipX.Name = "checkBoxFlipX";
            this.checkBoxFlipX.Size = new System.Drawing.Size(78, 18);
            this.checkBoxFlipX.TabIndex = 62;
            this.checkBoxFlipX.Text = "Mirror X";
            this.checkBoxFlipX.UseVisualStyleBackColor = true;
            this.checkBoxFlipX.CheckStateChanged += new System.EventHandler(this.checkBoxFlipX_CheckStateChanged);
            // 
            // numericUpDownRotation
            // 
            this.numericUpDownRotation.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRotation.Location = new System.Drawing.Point(61, 62);
            this.numericUpDownRotation.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRotation.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownRotation.Name = "numericUpDownRotation";
            this.numericUpDownRotation.Size = new System.Drawing.Size(50, 21);
            this.numericUpDownRotation.TabIndex = 61;
            this.numericUpDownRotation.ValueChanged += new System.EventHandler(this.numericUpDownRotation_ValueChanged);
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRotation.Location = new System.Drawing.Point(22, 64);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(36, 14);
            this.labelRotation.TabIndex = 60;
            this.labelRotation.Text = "ROT:";
            // 
            // labelXoffset
            // 
            this.labelXoffset.AutoSize = true;
            this.labelXoffset.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelXoffset.Location = new System.Drawing.Point(7, 669);
            this.labelXoffset.Name = "labelXoffset";
            this.labelXoffset.Size = new System.Drawing.Size(58, 14);
            this.labelXoffset.TabIndex = 53;
            this.labelXoffset.Text = "X Offset:";
            // 
            // labelYoffset
            // 
            this.labelYoffset.AutoSize = true;
            this.labelYoffset.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYoffset.Location = new System.Drawing.Point(7, 696);
            this.labelYoffset.Name = "labelYoffset";
            this.labelYoffset.Size = new System.Drawing.Size(58, 14);
            this.labelYoffset.TabIndex = 54;
            this.labelYoffset.Text = "Y Offset:";
            // 
            // numericUpDownXOffset
            // 
            this.numericUpDownXOffset.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownXOffset.Location = new System.Drawing.Point(67, 667);
            this.numericUpDownXOffset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownXOffset.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownXOffset.Name = "numericUpDownXOffset";
            this.numericUpDownXOffset.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownXOffset.TabIndex = 55;
            // 
            // numericUpDownYOffset
            // 
            this.numericUpDownYOffset.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownYOffset.Location = new System.Drawing.Point(67, 694);
            this.numericUpDownYOffset.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownYOffset.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownYOffset.Name = "numericUpDownYOffset";
            this.numericUpDownYOffset.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownYOffset.TabIndex = 56;
            // 
            // labelLayerMove
            // 
            this.labelLayerMove.AutoSize = true;
            this.labelLayerMove.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLayerMove.Location = new System.Drawing.Point(4, 747);
            this.labelLayerMove.Name = "labelLayerMove";
            this.labelLayerMove.Size = new System.Drawing.Size(98, 15);
            this.labelLayerMove.TabIndex = 58;
            this.labelLayerMove.Text = "LAYERMOVE";
            // 
            // buttonLayerMove
            // 
            this.buttonLayerMove.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLayerMove.Location = new System.Drawing.Point(29, 818);
            this.buttonLayerMove.Name = "buttonLayerMove";
            this.buttonLayerMove.Size = new System.Drawing.Size(56, 23);
            this.buttonLayerMove.TabIndex = 68;
            this.buttonLayerMove.Text = "Move";
            this.buttonLayerMove.UseVisualStyleBackColor = true;
            this.buttonLayerMove.Click += new System.EventHandler(this.buttonLayerMove_Click);
            // 
            // labelLayerMoveX
            // 
            this.labelLayerMoveX.AutoSize = true;
            this.labelLayerMoveX.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLayerMoveX.Location = new System.Drawing.Point(7, 767);
            this.labelLayerMoveX.Name = "labelLayerMoveX";
            this.labelLayerMoveX.Size = new System.Drawing.Size(55, 14);
            this.labelLayerMoveX.TabIndex = 69;
            this.labelLayerMoveX.Text = "X Move:";
            // 
            // labelLayerMoveY
            // 
            this.labelLayerMoveY.AutoSize = true;
            this.labelLayerMoveY.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLayerMoveY.Location = new System.Drawing.Point(9, 794);
            this.labelLayerMoveY.Name = "labelLayerMoveY";
            this.labelLayerMoveY.Size = new System.Drawing.Size(55, 14);
            this.labelLayerMoveY.TabIndex = 70;
            this.labelLayerMoveY.Text = "Y Move:";
            // 
            // numericUpDownLayerMoveX
            // 
            this.numericUpDownLayerMoveX.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLayerMoveX.Location = new System.Drawing.Point(67, 765);
            this.numericUpDownLayerMoveX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLayerMoveX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownLayerMoveX.Name = "numericUpDownLayerMoveX";
            this.numericUpDownLayerMoveX.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownLayerMoveX.TabIndex = 71;
            // 
            // numericUpDownLayerMoveY
            // 
            this.numericUpDownLayerMoveY.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownLayerMoveY.Location = new System.Drawing.Point(67, 792);
            this.numericUpDownLayerMoveY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownLayerMoveY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownLayerMoveY.Name = "numericUpDownLayerMoveY";
            this.numericUpDownLayerMoveY.Size = new System.Drawing.Size(54, 21);
            this.numericUpDownLayerMoveY.TabIndex = 72;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1424, 862);
            this.Controls.Add(this.numericUpDownLayerMoveY);
            this.Controls.Add(this.numericUpDownLayerMoveX);
            this.Controls.Add(this.labelLayerMoveY);
            this.Controls.Add(this.labelLayerMoveX);
            this.Controls.Add(this.buttonLayerMove);
            this.Controls.Add(this.labelLayerMove);
            this.Controls.Add(this.numericUpDownYOffset);
            this.Controls.Add(this.numericUpDownXOffset);
            this.Controls.Add(this.labelYoffset);
            this.Controls.Add(this.labelXoffset);
            this.Controls.Add(this.checkBoxSelectSpriteMode);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(this.comboBoxWorld);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelWorld);
            this.Controls.Add(this.buttonSaveMap);
            this.Controls.Add(this.comboBoxTexture);
            this.Controls.Add(this.labelTextureID);
            this.Controls.Add(this.labelTexture);
            this.Controls.Add(this.comboBoxLayer);
            this.Controls.Add(this.numericUpDownParallax);
            this.Controls.Add(this.labelparallaxx);
            this.Controls.Add(this.labelParallax);
            this.Controls.Add(this.buttonBackgroundApply);
            this.Controls.Add(this.groupBoxSpriteControl);
            this.Controls.Add(this.labelTilesetID);
            this.Controls.Add(this.comboBoxTileSet);
            this.Controls.Add(this.labelTileSet);
            this.Controls.Add(this.groupBoxPlaceMode);
            this.Controls.Add(this.groupBoxRightClick);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.labelLayer);
            this.Controls.Add(this.listTiles);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MapEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "GIGALOTH GAMES MAP EDITOR (PARALLAX WARP ENGINE)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapEditor_FormClosed);
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxRightClick.ResumeLayout(false);
            this.groupBoxRightClick.PerformLayout();
            this.groupBoxPlaceMode.ResumeLayout(false);
            this.groupBoxPlaceMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownParallax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPathingSpeed)).EndInit();
            this.groupBoxSpriteControl.ResumeLayout(false);
            this.groupBoxSpriteControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerMoveX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayerMoveY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listTiles;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem vIEWToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxLayer;
        private System.Windows.Forms.Label labelLayer;
        private System.Windows.Forms.Label labelTileSet;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.ComboBox comboBoxWorld;
        private System.Windows.Forms.Label labelWorld;
        private System.Windows.Forms.ComboBox comboBoxTileSet;
        private System.Windows.Forms.ToolStripMenuItem newMapToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListTiles;
        private System.Windows.Forms.GroupBox groupBoxRightClick;
        private System.Windows.Forms.RadioButton radioClearTile;
        public System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Timer timerGameUpdate;
        private System.Windows.Forms.ToolStripMenuItem showWorldGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTextOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundLayersToolStripMenuItem;
        private System.Windows.Forms.Label labelTilesetID;
        private System.Windows.Forms.RadioButton radioPlace;
        private System.Windows.Forms.GroupBox groupBoxPlaceMode;
        private System.Windows.Forms.RadioButton radioSnapToGrid;
        private System.Windows.Forms.RadioButton radioFreePlace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spriteTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forewardLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertNewLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLayerToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonBackgroundApply;
        private System.Windows.Forms.Label labelParallax;
        private System.Windows.Forms.NumericUpDown numericUpDownParallax;
        private System.Windows.Forms.Label labelparallaxx;
        private System.Windows.Forms.ComboBox comboBoxTexture;
        private System.Windows.Forms.Label labelTexture;
        private System.Windows.Forms.Label labelTextureID;
        private System.Windows.Forms.ToolStripMenuItem moveLayerBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveLayerForwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem worldToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveMap;
        private System.Windows.Forms.CheckBox checkBoxSelectSpriteMode;
        private System.Windows.Forms.ComboBox comboBoxPathing;
        private System.Windows.Forms.Label labelPathing;
        private System.Windows.Forms.Label labelPathingX;
        private System.Windows.Forms.Label labelPathingY;
        private System.Windows.Forms.NumericUpDown numericUpDownPathingX;
        private System.Windows.Forms.NumericUpDown numericUpDownPathingY;
        private System.Windows.Forms.Label labelPathingSpeed;
        private System.Windows.Forms.Label labelPathingStart;
        private System.Windows.Forms.NumericUpDown numericUpDownPathingPercent;
        private System.Windows.Forms.NumericUpDown numericUpDownPathingSpeed;
        private System.Windows.Forms.Label labelSpriteType;
        private System.Windows.Forms.ComboBox comboBoxSpriteType;
        private System.Windows.Forms.GroupBox groupBoxSpriteControl;
        private System.Windows.Forms.NumericUpDown numericUpDownRotation;
        private System.Windows.Forms.Label labelRotation;
        private System.Windows.Forms.CheckBox checkBoxFlipX;
        private System.Windows.Forms.CheckBox checkBoxFlipY;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.CheckBox checkBoxPathInertia;
        private System.Windows.Forms.Label labelXoffset;
        private System.Windows.Forms.Label labelYoffset;
        private System.Windows.Forms.NumericUpDown numericUpDownXOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownYOffset;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.NumericUpDown numericUpDownTimer;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.NumericUpDown numericUpDownHP;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelLayerMove;
        private System.Windows.Forms.Button buttonLayerMove;
        private System.Windows.Forms.Label labelLayerMoveX;
        private System.Windows.Forms.Label labelLayerMoveY;
        private System.Windows.Forms.NumericUpDown numericUpDownLayerMoveX;
        private System.Windows.Forms.NumericUpDown numericUpDownLayerMoveY;
    }
}