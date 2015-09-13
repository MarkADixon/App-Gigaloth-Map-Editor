namespace GigalothMapEditor
{
    partial class NewMap
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownGridTileWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGridTileHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTilesWide = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTilesHigh = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.labelWorldTotalWidth = new System.Windows.Forms.Label();
            this.labelWorldTotalHeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonChooseTexturePack = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTilesWide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTilesHigh)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Moire", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(83, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "NEW MAP OPTIONS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "WORLD GRID: TILE WIDTH: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "WORLD GRID: TILE HEIGHT: ";
            // 
            // numericUpDownGridTileWidth
            // 
            this.numericUpDownGridTileWidth.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGridTileWidth.Location = new System.Drawing.Point(234, 41);
            this.numericUpDownGridTileWidth.Maximum = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.numericUpDownGridTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGridTileWidth.Name = "numericUpDownGridTileWidth";
            this.numericUpDownGridTileWidth.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownGridTileWidth.TabIndex = 15;
            this.numericUpDownGridTileWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownGridTileWidth.ValueChanged += new System.EventHandler(this.numericUpDownGridTileWidth_ValueChanged);
            // 
            // numericUpDownGridTileHeight
            // 
            this.numericUpDownGridTileHeight.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGridTileHeight.Location = new System.Drawing.Point(234, 70);
            this.numericUpDownGridTileHeight.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownGridTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGridTileHeight.Name = "numericUpDownGridTileHeight";
            this.numericUpDownGridTileHeight.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownGridTileHeight.TabIndex = 16;
            this.numericUpDownGridTileHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericUpDownGridTileHeight.ValueChanged += new System.EventHandler(this.numericUpDownGridTileHeight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "WORLD GRID: TILES WIDE: ";
            // 
            // numericUpDownTilesWide
            // 
            this.numericUpDownTilesWide.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTilesWide.Location = new System.Drawing.Point(234, 99);
            this.numericUpDownTilesWide.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTilesWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTilesWide.Name = "numericUpDownTilesWide";
            this.numericUpDownTilesWide.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownTilesWide.TabIndex = 18;
            this.numericUpDownTilesWide.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTilesWide.ValueChanged += new System.EventHandler(this.numericUpDownTilesWide_ValueChanged);
            // 
            // numericUpDownTilesHigh
            // 
            this.numericUpDownTilesHigh.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTilesHigh.Location = new System.Drawing.Point(234, 128);
            this.numericUpDownTilesHigh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownTilesHigh.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTilesHigh.Name = "numericUpDownTilesHigh";
            this.numericUpDownTilesHigh.Size = new System.Drawing.Size(51, 23);
            this.numericUpDownTilesHigh.TabIndex = 19;
            this.numericUpDownTilesHigh.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTilesHigh.ValueChanged += new System.EventHandler(this.numericUpDownTilesHigh_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "WORLD GRID: TILES HIGH: ";
            // 
            // labelWorldTotalWidth
            // 
            this.labelWorldTotalWidth.AutoSize = true;
            this.labelWorldTotalWidth.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorldTotalWidth.Location = new System.Drawing.Point(12, 163);
            this.labelWorldTotalWidth.Name = "labelWorldTotalWidth";
            this.labelWorldTotalWidth.Size = new System.Drawing.Size(168, 15);
            this.labelWorldTotalWidth.TabIndex = 21;
            this.labelWorldTotalWidth.Text = "WORLD TOTAL WIDTH: ";
            // 
            // labelWorldTotalHeight
            // 
            this.labelWorldTotalHeight.AutoSize = true;
            this.labelWorldTotalHeight.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorldTotalHeight.Location = new System.Drawing.Point(9, 190);
            this.labelWorldTotalHeight.Name = "labelWorldTotalHeight";
            this.labelWorldTotalHeight.Size = new System.Drawing.Size(174, 15);
            this.labelWorldTotalHeight.TabIndex = 22;
            this.labelWorldTotalHeight.Text = "WORLD TOTAL HEIGHT: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(265, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "(1280 minimum)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(265, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 14);
            this.label7.TabIndex = 24;
            this.label7.Text = "(720 minimum)";
            // 
            // buttonChooseTexturePack
            // 
            this.buttonChooseTexturePack.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChooseTexturePack.Location = new System.Drawing.Point(77, 217);
            this.buttonChooseTexturePack.Name = "buttonChooseTexturePack";
            this.buttonChooseTexturePack.Size = new System.Drawing.Size(208, 23);
            this.buttonChooseTexturePack.TabIndex = 25;
            this.buttonChooseTexturePack.Text = "CHOOSE TEXTURE PACK ";
            this.buttonChooseTexturePack.UseVisualStyleBackColor = true;
            this.buttonChooseTexturePack.Click += new System.EventHandler(this.buttonChooseTexturePack_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(65, 243);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(230, 15);
            this.labelFileName.TabIndex = 26;
            this.labelFileName.Text = "Please Choose A Texture Pack ...";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(77, 286);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 27;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(210, 286);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // NewMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 330);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonChooseTexturePack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelWorldTotalHeight);
            this.Controls.Add(this.labelWorldTotalWidth);
            this.Controls.Add(this.numericUpDownGridTileWidth);
            this.Controls.Add(this.numericUpDownGridTileHeight);
            this.Controls.Add(this.numericUpDownTilesWide);
            this.Controls.Add(this.numericUpDownTilesHigh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "NewMap";
            this.Text = "NewMap";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGridTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTilesWide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTilesHigh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownGridTileWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownGridTileHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTilesWide;
        private System.Windows.Forms.NumericUpDown numericUpDownTilesHigh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelWorldTotalWidth;
        private System.Windows.Forms.Label labelWorldTotalHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonChooseTexturePack;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}