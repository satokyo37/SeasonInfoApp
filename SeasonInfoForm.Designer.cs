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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCountry.Font = new System.Drawing.Font("Noto Sans JP", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(60, 64);
            this.comboBoxCountry.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(289, 47);
            this.comboBoxCountry.TabIndex = 0;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMonth.Font = new System.Drawing.Font("Noto Sans JP", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(478, 64);
            this.comboBoxMonth.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(138, 47);
            this.comboBoxMonth.TabIndex = 0;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("Noto Sans JP", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonConfirm.Location = new System.Drawing.Point(745, 64);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(141, 47);
            this.buttonConfirm.TabIndex = 1;
            this.buttonConfirm.Text = "実行";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Noto Sans JP", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(14, 171);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(922, 390);
            this.textBox1.TabIndex = 2;
            // 
            // SeasonInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 563);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxCountry);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "SeasonInfoForm";
            this.Text = "SeasonInfoForm";
            this.Load += new System.EventHandler(this.SeasonInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.TextBox textBox1;
    }
}

