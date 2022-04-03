
namespace malApiForm
{
    partial class CreateCSVForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCSVForm));
            this.searchUserTextBox = new System.Windows.Forms.TextBox();
            this.titleFormLabel = new System.Windows.Forms.Label();
            this.chooseListComboBox = new System.Windows.Forms.ComboBox();
            this.chooseListComboBoxLabel = new System.Windows.Forms.Label();
            this.csvButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.closeAllButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchUserTextBox
            // 
            this.searchUserTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchUserTextBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchUserTextBox.Location = new System.Drawing.Point(93, 269);
            this.searchUserTextBox.Name = "searchUserTextBox";
            this.searchUserTextBox.PlaceholderText = "Search for MAL Username";
            this.searchUserTextBox.Size = new System.Drawing.Size(154, 22);
            this.searchUserTextBox.TabIndex = 7;
            // 
            // titleFormLabel
            // 
            this.titleFormLabel.AutoSize = true;
            this.titleFormLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleFormLabel.ForeColor = System.Drawing.Color.White;
            this.titleFormLabel.Location = new System.Drawing.Point(62, 152);
            this.titleFormLabel.Name = "titleFormLabel";
            this.titleFormLabel.Size = new System.Drawing.Size(216, 25);
            this.titleFormLabel.TabIndex = 8;
            this.titleFormLabel.Text = "MyAnimeList Downloader";
            this.titleFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chooseListComboBox
            // 
            this.chooseListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseListComboBox.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseListComboBox.FormattingEnabled = true;
            this.chooseListComboBox.Items.AddRange(new object[] {
            "Manga",
            "Anime"});
            this.chooseListComboBox.Location = new System.Drawing.Point(100, 227);
            this.chooseListComboBox.Name = "chooseListComboBox";
            this.chooseListComboBox.Size = new System.Drawing.Size(140, 21);
            this.chooseListComboBox.TabIndex = 9;
            // 
            // chooseListComboBoxLabel
            // 
            this.chooseListComboBoxLabel.AutoSize = true;
            this.chooseListComboBoxLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chooseListComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.chooseListComboBoxLabel.Location = new System.Drawing.Point(95, 205);
            this.chooseListComboBoxLabel.Name = "chooseListComboBoxLabel";
            this.chooseListComboBoxLabel.Size = new System.Drawing.Size(83, 19);
            this.chooseListComboBoxLabel.TabIndex = 10;
            this.chooseListComboBoxLabel.Text = "Choose List:";
            // 
            // csvButton
            // 
            this.csvButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("csvButton.BackgroundImage")));
            this.csvButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.csvButton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.csvButton.FlatAppearance.BorderSize = 0;
            this.csvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csvButton.ForeColor = System.Drawing.Color.White;
            this.csvButton.Location = new System.Drawing.Point(147, 316);
            this.csvButton.Name = "csvButton";
            this.csvButton.Size = new System.Drawing.Size(46, 43);
            this.csvButton.TabIndex = 11;
            this.csvButton.UseVisualStyleBackColor = true;
            this.csvButton.Click += new System.EventHandler(this.csvButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.errorLabel.Location = new System.Drawing.Point(10, 371);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(62, 19);
            this.errorLabel.TabIndex = 12;
            this.errorLabel.Text = "ERRORE!";
            this.errorLabel.Visible = false;
            // 
            // closeAllButton
            // 
            this.closeAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeAllButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeAllButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeAllButton.FlatAppearance.BorderSize = 0;
            this.closeAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeAllButton.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.closeAllButton.Location = new System.Drawing.Point(292, -3);
            this.closeAllButton.Name = "closeAllButton";
            this.closeAllButton.Size = new System.Drawing.Size(50, 50);
            this.closeAllButton.TabIndex = 13;
            this.closeAllButton.Text = "❌";
            this.closeAllButton.UseVisualStyleBackColor = false;
            this.closeAllButton.Click += new System.EventHandler(this.closeAllButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(60, 50);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // CreateCSVForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(340, 400);
            this.Controls.Add(this.titleFormLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeAllButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.csvButton);
            this.Controls.Add(this.chooseListComboBoxLabel);
            this.Controls.Add(this.chooseListComboBox);
            this.Controls.Add(this.searchUserTextBox);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateCSVForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchUserTextBox;
        private System.Windows.Forms.Label titleFormLabel;
        private System.Windows.Forms.ComboBox chooseListComboBox;
        private System.Windows.Forms.Label chooseListComboBoxLabel;
        private System.Windows.Forms.Button csvButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button closeAllButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

