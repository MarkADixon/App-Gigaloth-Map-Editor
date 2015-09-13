namespace GigalothMapEditor
{
    partial class AddTileset
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTileHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoadTileSheet = new System.Windows.Forms.Button();
            this.checkBoxIsTerrain = new System.Windows.Forms.CheckBox();
            this.checkBoxIsAnimated = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TILE WIDTH : ";
            // 
            // numericUpDownTileWidth
            // 
            this.numericUpDownTileWidth.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTileWidth.Location = new System.Drawing.Point(141, 58);
            this.numericUpDownTileWidth.Maximum = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.numericUpDownTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileWidth.Name = "numericUpDownTileWidth";
            this.numericUpDownTileWidth.Size = new System.Drawing.Size(50, 23);
            this.numericUpDownTileWidth.TabIndex = 1;
            this.numericUpDownTileWidth.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numericUpDownTileWidth.ValueChanged += new System.EventHandler(this.numericUpDownTileWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "TILE HEIGHT : ";
            // 
            // numericUpDownTileHeight
            // 
            this.numericUpDownTileHeight.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTileHeight.Location = new System.Drawing.Point(141, 88);
            this.numericUpDownTileHeight.Maximum = new decimal(new int[] {
            1280,
            0,
            0,
            0});
            this.numericUpDownTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTileHeight.Name = "numericUpDownTileHeight";
            this.numericUpDownTileHeight.Size = new System.Drawing.Size(50, 23);
            this.numericUpDownTileHeight.TabIndex = 3;
            this.numericUpDownTileHeight.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numericUpDownTileHeight.ValueChanged += new System.EventHandler(this.numericUpDownTileHeight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(197, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "+ 2 pixel per side padding ";
            // 
            // buttonLoadTileSheet
            // 
            this.buttonLoadTileSheet.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadTileSheet.Location = new System.Drawing.Point(26, 172);
            this.buttonLoadTileSheet.Name = "buttonLoadTileSheet";
            this.buttonLoadTileSheet.Size = new System.Drawing.Size(153, 23);
            this.buttonLoadTileSheet.TabIndex = 7;
            this.buttonLoadTileSheet.Text = "CHOOSE FILE :";
            this.buttonLoadTileSheet.UseVisualStyleBackColor = true;
            this.buttonLoadTileSheet.Click += new System.EventHandler(this.buttonLoadTileSheet_Click);
            // 
            // checkBoxIsTerrain
            // 
            this.checkBoxIsTerrain.AutoSize = true;
            this.checkBoxIsTerrain.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsTerrain.Location = new System.Drawing.Point(26, 122);
            this.checkBoxIsTerrain.Name = "checkBoxIsTerrain";
            this.checkBoxIsTerrain.Size = new System.Drawing.Size(327, 19);
            this.checkBoxIsTerrain.TabIndex = 8;
            this.checkBoxIsTerrain.Text = "Tile sheet is terrain (Impassable to physics)";
            this.checkBoxIsTerrain.UseVisualStyleBackColor = true;
            this.checkBoxIsTerrain.CheckedChanged += new System.EventHandler(this.checkBoxIsTerrain_CheckedChanged);
            // 
            // checkBoxIsAnimated
            // 
            this.checkBoxIsAnimated.AutoSize = true;
            this.checkBoxIsAnimated.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsAnimated.Location = new System.Drawing.Point(26, 147);
            this.checkBoxIsAnimated.Name = "checkBoxIsAnimated";
            this.checkBoxIsAnimated.Size = new System.Drawing.Size(307, 19);
            this.checkBoxIsAnimated.TabIndex = 9;
            this.checkBoxIsAnimated.Text = "Tile sheet is animated (Rows are frames)";
            this.checkBoxIsAnimated.UseVisualStyleBackColor = true;
            this.checkBoxIsAnimated.CheckedChanged += new System.EventHandler(this.checkBoxIsAnimated_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Moire", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(87, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "ADD TILESET OPTIONS";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(192, 176);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(147, 15);
            this.labelFileName.TabIndex = 11;
            this.labelFileName.Text = "Please Choose File...";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(75, 216);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Moire", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(230, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Moire", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 14);
            this.label3.TabIndex = 14;
            this.label3.Text = "+ 2 pixel per side padding ";
            // 
            // AddTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxIsAnimated);
            this.Controls.Add(this.checkBoxIsTerrain);
            this.Controls.Add(this.buttonLoadTileSheet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownTileHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownTileWidth);
            this.Controls.Add(this.label1);
            this.Name = "AddTileset";
            this.Text = "AddTileset";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTileHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTileWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTileHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLoadTileSheet;
        private System.Windows.Forms.CheckBox checkBoxIsTerrain;
        private System.Windows.Forms.CheckBox checkBoxIsAnimated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
    }
}