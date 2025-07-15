namespace SeasonInfoApp
{
    partial class SeasonInfoForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            this.labelUnsplash = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelMonth = new System.Windows.Forms.Label();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCountry.Font = new System.Drawing.Font("Noto Sans JP", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(11, 81);
            this.comboBoxCountry.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(289, 38);
            this.comboBoxCountry.TabIndex = 0;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMonth.Font = new System.Drawing.Font("Noto Sans JP", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(11, 199);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(289, 38);
            this.comboBoxMonth.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.Coral;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.Location = new System.Drawing.Point(11, 317);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(289, 47);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "実行";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOutput.Font = new System.Drawing.Font("Noto Sans JP", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxOutput.Location = new System.Drawing.Point(338, 11);
            this.textBoxOutput.Margin = new System.Windows.Forms.Padding(10);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(586, 280);
            this.textBoxOutput.TabIndex = 2;
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.AutoScroll = true;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(338, 305);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(586, 246);
            this.flowLayoutPanelImages.TabIndex = 3;
            // 
            // labelUnsplash
            // 
            this.labelUnsplash.AutoSize = true;
            this.labelUnsplash.BackColor = System.Drawing.SystemColors.Control;
            this.labelUnsplash.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelUnsplash.Font = new System.Drawing.Font("Noto Sans JP", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelUnsplash.Location = new System.Drawing.Point(40, 483);
            this.labelUnsplash.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUnsplash.Name = "labelUnsplash";
            this.labelUnsplash.Size = new System.Drawing.Size(234, 48);
            this.labelUnsplash.TabIndex = 4;
            this.labelUnsplash.Text = "Photos provided by Unsplash \r\n(https://unsplash.com)";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelCountry.Location = new System.Drawing.Point(80, 35);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(151, 27);
            this.labelCountry.TabIndex = 5;
            this.labelCountry.Text = "🌎 国を選択";
            // 
            // labelMonth
            // 
            this.labelMonth.AutoSize = true;
            this.labelMonth.Font = new System.Drawing.Font("HGP創英角ｺﾞｼｯｸUB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMonth.Location = new System.Drawing.Point(80, 158);
            this.labelMonth.Name = "labelMonth";
            this.labelMonth.Size = new System.Drawing.Size(151, 27);
            this.labelMonth.TabIndex = 5;
            this.labelMonth.Text = "📅 月を選択";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackgroundImage = global::_SeasonInfoApp.Properties.Resources.background_gradient;
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(947, 563);
            this.pictureBoxBackground.TabIndex = 6;
            this.pictureBoxBackground.TabStop = false;
            // 
            // SeasonInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_SeasonInfoApp.Properties.Resources.background_gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(947, 563);
            this.Controls.Add(this.labelMonth);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelUnsplash);
            this.Controls.Add(this.flowLayoutPanelImages);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.pictureBoxBackground);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SeasonInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeasonInfoForm";
            this.Load += new System.EventHandler(this.SeasonInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Label labelUnsplash;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelMonth;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
    }
}

