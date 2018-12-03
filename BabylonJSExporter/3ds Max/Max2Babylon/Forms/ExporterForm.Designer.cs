namespace Max2Babylon
{
    partial class ExporterForm
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
            this.butExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.treeView = new System.Windows.Forms.TreeView();
            this.butCancel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkManifest = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkWriteTextures = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.kuesaLabel = new System.Windows.Forms.Label();
            this.kuesaWireFrameCB = new System.Windows.Forms.CheckBox();
            this.kuesaLayersCB = new System.Windows.Forms.CheckBox();
            this.chkExportMaterials = new System.Windows.Forms.CheckBox();
            this.chkKHRMaterialsUnlit = new System.Windows.Forms.CheckBox();
            this.chkKHRTextureTransform = new System.Windows.Forms.CheckBox();
            this.chkKHRLightsPunctual = new System.Windows.Forms.CheckBox();
            this.chkOverwriteTextures = new System.Windows.Forms.CheckBox();
            this.chkDracoCompression = new System.Windows.Forms.CheckBox();
            this.chkMergeAOwithMR = new System.Windows.Forms.CheckBox();
            this.txtQuality = new System.Windows.Forms.TextBox();
            this.labelQuality = new System.Windows.Forms.Label();
            this.chkExportTangents = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtScaleFactor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboOutputFormat = new System.Windows.Forms.ComboBox();
            this.chkOnlySelected = new System.Windows.Forms.CheckBox();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.butExportAndRun = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.toolTipDracoCompression = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butExport
            // 
            this.butExport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butExport.Enabled = false;
            this.butExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExport.Location = new System.Drawing.Point(422, 569);
            this.butExport.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(394, 52);
            this.butExport.TabIndex = 100;
            this.butExport.Text = "Export";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            this.butExport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "File name:";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(36, 65);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(750, 31);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            this.txtFilename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBrowse.Location = new System.Drawing.Point(802, 62);
            this.butBrowse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(86, 44);
            this.butBrowse.TabIndex = 3;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            this.butBrowse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "babylon";
            this.saveFileDialog.Filter = "Babylon files|*.babylon";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(24, 1012);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1276, 44);
            this.progressBar.TabIndex = 104;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(24, 633);
            this.treeView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(1616, 364);
            this.treeView.TabIndex = 103;
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Enabled = false;
            this.butCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCancel.Location = new System.Drawing.Point(1312, 1012);
            this.butCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(160, 44);
            this.butCancel.TabIndex = 105;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            this.butCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Max2Babylon.Properties.Resources.Logo_Exporter_v4;
            this.pictureBox2.Location = new System.Drawing.Point(936, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(708, 398);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // chkManifest
            // 
            this.chkManifest.AutoSize = true;
            this.chkManifest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManifest.Location = new System.Drawing.Point(640, 313);
            this.chkManifest.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkManifest.Name = "chkManifest";
            this.chkManifest.Size = new System.Drawing.Size(221, 29);
            this.chkManifest.TabIndex = 14;
            this.chkManifest.Text = "Generate .manifest";
            this.chkManifest.UseVisualStyleBackColor = true;
            this.chkManifest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Options:";
            // 
            // chkWriteTextures
            // 
            this.chkWriteTextures.AutoSize = true;
            this.chkWriteTextures.Checked = true;
            this.chkWriteTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWriteTextures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkWriteTextures.Location = new System.Drawing.Point(36, 225);
            this.chkWriteTextures.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkWriteTextures.Name = "chkWriteTextures";
            this.chkWriteTextures.Size = new System.Drawing.Size(179, 29);
            this.chkWriteTextures.TabIndex = 11;
            this.chkWriteTextures.Text = "Write Textures";
            this.chkWriteTextures.UseVisualStyleBackColor = true;
            this.chkWriteTextures.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.kuesaLabel);
            this.groupBox1.Controls.Add(this.kuesaWireFrameCB);
            this.groupBox1.Controls.Add(this.kuesaLayersCB);
            this.groupBox1.Controls.Add(this.chkExportMaterials);
            this.groupBox1.Controls.Add(this.chkKHRMaterialsUnlit);
            this.groupBox1.Controls.Add(this.chkKHRTextureTransform);
            this.groupBox1.Controls.Add(this.chkKHRLightsPunctual);
            this.groupBox1.Controls.Add(this.chkOverwriteTextures);
            this.groupBox1.Controls.Add(this.chkDracoCompression);
            this.groupBox1.Controls.Add(this.chkMergeAOwithMR);
            this.groupBox1.Controls.Add(this.txtQuality);
            this.groupBox1.Controls.Add(this.labelQuality);
            this.groupBox1.Controls.Add(this.chkExportTangents);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtScaleFactor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboOutputFormat);
            this.groupBox1.Controls.Add(this.chkOnlySelected);
            this.groupBox1.Controls.Add(this.chkAutoSave);
            this.groupBox1.Controls.Add(this.chkHidden);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkWriteTextures);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.chkManifest);
            this.groupBox1.Controls.Add(this.butBrowse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(900, 546);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // kuesaLabel
            // 
            this.kuesaLabel.AutoSize = true;
            this.kuesaLabel.Location = new System.Drawing.Point(30, 471);
            this.kuesaLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.kuesaLabel.Name = "kuesaLabel";
            this.kuesaLabel.Size = new System.Drawing.Size(142, 25);
            this.kuesaLabel.TabIndex = 26;
            this.kuesaLabel.Text = "KDAB Kuesa:";
            this.kuesaLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // kuesaWireFrameCB
            // 
            this.kuesaWireFrameCB.AutoSize = true;
            this.kuesaWireFrameCB.Enabled = false;
            this.kuesaWireFrameCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kuesaWireFrameCB.Location = new System.Drawing.Point(332, 502);
            this.kuesaWireFrameCB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kuesaWireFrameCB.Name = "kuesaWireFrameCB";
            this.kuesaWireFrameCB.Size = new System.Drawing.Size(236, 29);
            this.kuesaWireFrameCB.TabIndex = 25;
            this.kuesaWireFrameCB.Text = "Wireframe Geometry";
            this.kuesaWireFrameCB.UseVisualStyleBackColor = true;
            this.kuesaWireFrameCB.CheckedChanged += new System.EventHandler(this.kuesaWireFrame_CheckedChanged);
            // 
            // kuesaLayersCB
            // 
            this.kuesaLayersCB.AutoSize = true;
            this.kuesaLayersCB.Enabled = false;
            this.kuesaLayersCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kuesaLayersCB.Location = new System.Drawing.Point(36, 502);
            this.kuesaLayersCB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.kuesaLayersCB.Name = "kuesaLayersCB";
            this.kuesaLayersCB.Size = new System.Drawing.Size(246, 29);
            this.kuesaLayersCB.TabIndex = 24;
            this.kuesaLayersCB.Text = "KDAB_Kuesa_Layers";
            this.kuesaLayersCB.UseVisualStyleBackColor = true;
            this.kuesaLayersCB.CheckedChanged += new System.EventHandler(this.kuesaLayers_CheckedChanged_3);
            // 
            // chkExportMaterials
            // 
            this.chkExportMaterials.AutoSize = true;
            this.chkExportMaterials.Checked = true;
            this.chkExportMaterials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportMaterials.Location = new System.Drawing.Point(36, 360);
            this.chkExportMaterials.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkExportMaterials.Name = "chkExportMaterials";
            this.chkExportMaterials.Size = new System.Drawing.Size(195, 29);
            this.chkExportMaterials.TabIndex = 23;
            this.chkExportMaterials.Text = "Export Materials";
            this.chkExportMaterials.UseVisualStyleBackColor = true;
            this.chkExportMaterials.CheckedChanged += new System.EventHandler(this.chkExportMaterials_CheckedChanged);
            // 
            // chkKHRMaterialsUnlit
            // 
            this.chkKHRMaterialsUnlit.AutoSize = true;
            this.chkKHRMaterialsUnlit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKHRMaterialsUnlit.Location = new System.Drawing.Point(634, 404);
            this.chkKHRMaterialsUnlit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkKHRMaterialsUnlit.Name = "chkKHRMaterialsUnlit";
            this.chkKHRMaterialsUnlit.Size = new System.Drawing.Size(234, 29);
            this.chkKHRMaterialsUnlit.TabIndex = 22;
            this.chkKHRMaterialsUnlit.Text = "KHR_materials_unlit";
            this.chkKHRMaterialsUnlit.UseVisualStyleBackColor = true;
            this.chkKHRMaterialsUnlit.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // chkKHRTextureTransform
            // 
            this.chkKHRTextureTransform.AutoSize = true;
            this.chkKHRTextureTransform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKHRTextureTransform.Location = new System.Drawing.Point(332, 404);
            this.chkKHRTextureTransform.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkKHRTextureTransform.Name = "chkKHRTextureTransform";
            this.chkKHRTextureTransform.Size = new System.Drawing.Size(263, 29);
            this.chkKHRTextureTransform.TabIndex = 21;
            this.chkKHRTextureTransform.Text = "KHR_texture_transform";
            this.chkKHRTextureTransform.UseVisualStyleBackColor = true;
            this.chkKHRTextureTransform.CheckedChanged += new System.EventHandler(this.chkKHRTextureTransform_CheckedChanged);
            // 
            // chkKHRLightsPunctual
            // 
            this.chkKHRLightsPunctual.AutoSize = true;
            this.chkKHRLightsPunctual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKHRLightsPunctual.Location = new System.Drawing.Point(36, 404);
            this.chkKHRLightsPunctual.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkKHRLightsPunctual.Name = "chkKHRLightsPunctual";
            this.chkKHRLightsPunctual.Size = new System.Drawing.Size(240, 29);
            this.chkKHRLightsPunctual.TabIndex = 20;
            this.chkKHRLightsPunctual.Text = "KHR_lights_punctual";
            this.chkKHRLightsPunctual.UseVisualStyleBackColor = true;
            this.chkKHRLightsPunctual.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // chkOverwriteTextures
            // 
            this.chkOverwriteTextures.AutoSize = true;
            this.chkOverwriteTextures.Checked = true;
            this.chkOverwriteTextures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwriteTextures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOverwriteTextures.Location = new System.Drawing.Point(36, 271);
            this.chkOverwriteTextures.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkOverwriteTextures.Name = "chkOverwriteTextures";
            this.chkOverwriteTextures.Size = new System.Drawing.Size(220, 29);
            this.chkOverwriteTextures.TabIndex = 19;
            this.chkOverwriteTextures.Text = "Overwrite Textures";
            this.chkOverwriteTextures.UseVisualStyleBackColor = true;
            this.chkOverwriteTextures.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkDracoCompression
            // 
            this.chkDracoCompression.AutoSize = true;
            this.chkDracoCompression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDracoCompression.Location = new System.Drawing.Point(332, 313);
            this.chkDracoCompression.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkDracoCompression.Name = "chkDracoCompression";
            this.chkDracoCompression.Size = new System.Drawing.Size(268, 29);
            this.chkDracoCompression.TabIndex = 18;
            this.chkDracoCompression.Text = "Use Draco compression";
            this.chkDracoCompression.UseVisualStyleBackColor = true;
            this.chkDracoCompression.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // chkMergeAOwithMR
            // 
            this.chkMergeAOwithMR.AutoSize = true;
            this.chkMergeAOwithMR.Checked = true;
            this.chkMergeAOwithMR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMergeAOwithMR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMergeAOwithMR.Location = new System.Drawing.Point(36, 313);
            this.chkMergeAOwithMR.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkMergeAOwithMR.Name = "chkMergeAOwithMR";
            this.chkMergeAOwithMR.Size = new System.Drawing.Size(183, 29);
            this.chkMergeAOwithMR.TabIndex = 17;
            this.chkMergeAOwithMR.Text = "Merge AO map";
            this.chkMergeAOwithMR.UseVisualStyleBackColor = true;
            this.chkMergeAOwithMR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // txtQuality
            // 
            this.txtQuality.Location = new System.Drawing.Point(802, 173);
            this.txtQuality.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtQuality.Name = "txtQuality";
            this.txtQuality.Size = new System.Drawing.Size(82, 31);
            this.txtQuality.TabIndex = 9;
            this.txtQuality.Text = "100";
            this.txtQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuality.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // labelQuality
            // 
            this.labelQuality.AutoSize = true;
            this.labelQuality.Location = new System.Drawing.Point(634, 179);
            this.labelQuality.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(160, 25);
            this.labelQuality.TabIndex = 8;
            this.labelQuality.Text = "Texture quality:";
            // 
            // chkExportTangents
            // 
            this.chkExportTangents.AutoSize = true;
            this.chkExportTangents.Checked = true;
            this.chkExportTangents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportTangents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportTangents.Location = new System.Drawing.Point(640, 269);
            this.chkExportTangents.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkExportTangents.Name = "chkExportTangents";
            this.chkExportTangents.Size = new System.Drawing.Size(190, 29);
            this.chkExportTangents.TabIndex = 16;
            this.chkExportTangents.Text = "Export tangents";
            this.chkExportTangents.UseVisualStyleBackColor = true;
            this.chkExportTangents.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(658, 133);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Scale factor:";
            // 
            // txtScaleFactor
            // 
            this.txtScaleFactor.Location = new System.Drawing.Point(804, 127);
            this.txtScaleFactor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtScaleFactor.Name = "txtScaleFactor";
            this.txtScaleFactor.Size = new System.Drawing.Size(80, 31);
            this.txtScaleFactor.TabIndex = 7;
            this.txtScaleFactor.Text = "1";
            this.txtScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScaleFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output format:";
            // 
            // comboOutputFormat
            // 
            this.comboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOutputFormat.Items.AddRange(new object[] {
            "gltf",
            "glb"});
            this.comboOutputFormat.Location = new System.Drawing.Point(172, 127);
            this.comboOutputFormat.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboOutputFormat.Name = "comboOutputFormat";
            this.comboOutputFormat.Size = new System.Drawing.Size(238, 33);
            this.comboOutputFormat.TabIndex = 5;
            this.comboOutputFormat.SelectedIndexChanged += new System.EventHandler(this.comboOutputFormat_SelectedIndexChanged);
            this.comboOutputFormat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // chkOnlySelected
            // 
            this.chkOnlySelected.AutoSize = true;
            this.chkOnlySelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOnlySelected.Location = new System.Drawing.Point(640, 225);
            this.chkOnlySelected.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkOnlySelected.Name = "chkOnlySelected";
            this.chkOnlySelected.Size = new System.Drawing.Size(234, 29);
            this.chkOnlySelected.TabIndex = 13;
            this.chkOnlySelected.Text = "Export only selected";
            this.chkOnlySelected.UseVisualStyleBackColor = true;
            this.chkOnlySelected.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAutoSave.Location = new System.Drawing.Point(332, 269);
            this.chkAutoSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(257, 29);
            this.chkAutoSave.TabIndex = 15;
            this.chkAutoSave.Text = "Auto save 3ds Max file";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            this.chkAutoSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // chkHidden
            // 
            this.chkHidden.AutoSize = true;
            this.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHidden.Location = new System.Drawing.Point(332, 225);
            this.chkHidden.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(247, 29);
            this.chkHidden.TabIndex = 12;
            this.chkHidden.Text = "Export hidden objects";
            this.chkHidden.UseVisualStyleBackColor = true;
            this.chkHidden.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // butExportAndRun
            // 
            this.butExportAndRun.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.butExportAndRun.Enabled = false;
            this.butExportAndRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExportAndRun.Location = new System.Drawing.Point(830, 569);
            this.butExportAndRun.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butExportAndRun.Name = "butExportAndRun";
            this.butExportAndRun.Size = new System.Drawing.Size(394, 52);
            this.butExportAndRun.TabIndex = 102;
            this.butExportAndRun.Text = "Export && Run";
            this.butExportAndRun.UseVisualStyleBackColor = true;
            this.butExportAndRun.Click += new System.EventHandler(this.butExportAndRun_Click);
            this.butExportAndRun.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butClose.Location = new System.Drawing.Point(1484, 1012);
            this.butClose.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(160, 44);
            this.butClose.TabIndex = 106;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            this.butClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            // 
            // toolTipDracoCompression
            // 
            this.toolTipDracoCompression.ShowAlways = true;
            // 
            // ExporterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 1079);
            this.Controls.Add(this.butExportAndRun);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.butExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1670, 692);
            this.Name = "ExporterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kueas - Export scene to glTF format (based on Babylon.js)";
            this.Activated += new System.EventHandler(this.ExporterForm_Activated);
            this.Deactivate += new System.EventHandler(this.ExporterForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExporterForm_FormClosed);
            this.Load += new System.EventHandler(this.ExporterForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExporterForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkManifest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkWriteTextures;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.Button butExportAndRun;
        private System.Windows.Forms.CheckBox chkOnlySelected;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.ComboBox comboOutputFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScaleFactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkExportTangents;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.TextBox txtQuality;
        private System.Windows.Forms.CheckBox chkMergeAOwithMR;
        private System.Windows.Forms.CheckBox chkDracoCompression;
        private System.Windows.Forms.ToolTip toolTipDracoCompression;
        private System.Windows.Forms.CheckBox chkOverwriteTextures;
        private System.Windows.Forms.CheckBox chkKHRLightsPunctual;
        private System.Windows.Forms.CheckBox chkKHRTextureTransform;
        private System.Windows.Forms.CheckBox chkKHRMaterialsUnlit;
        private System.Windows.Forms.CheckBox chkExportMaterials;
        private System.Windows.Forms.CheckBox kuesaLayersCB;
        private System.Windows.Forms.CheckBox kuesaWireFrameCB;
        private System.Windows.Forms.Label kuesaLabel;
    }
}