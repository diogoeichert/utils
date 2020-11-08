namespace MicroEditor
{
    partial class ReplaceForm
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
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.findButton = new System.Windows.Forms.Button();
            this.replaceWithTextBox = new System.Windows.Forms.TextBox();
            this.findWhatTextBox = new System.Windows.Forms.TextBox();
            this.findWhatLabel = new System.Windows.Forms.Label();
            this.replaceWithLabel = new System.Windows.Forms.Label();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(196, 69);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(75, 23);
            this.replaceAllButton.TabIndex = 4;
            this.replaceAllButton.Text = "Replace &All";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(196, 40);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 3;
            this.replaceButton.Text = "&Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(196, 12);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 23);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // replaceWithTextBox
            // 
            this.replaceWithTextBox.Location = new System.Drawing.Point(90, 43);
            this.replaceWithTextBox.Name = "replaceWithTextBox";
            this.replaceWithTextBox.Size = new System.Drawing.Size(100, 20);
            this.replaceWithTextBox.TabIndex = 2;
            // 
            // findWhatTextBox
            // 
            this.findWhatTextBox.Location = new System.Drawing.Point(90, 14);
            this.findWhatTextBox.Name = "findWhatTextBox";
            this.findWhatTextBox.Size = new System.Drawing.Size(100, 20);
            this.findWhatTextBox.TabIndex = 0;
            this.findWhatTextBox.TextChanged += new System.EventHandler(this.findWhatTextBox_TextChanged);
            this.findWhatTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.findWhatTextBox_KeyPress);
            // 
            // findWhatLabel
            // 
            this.findWhatLabel.AutoSize = true;
            this.findWhatLabel.Location = new System.Drawing.Point(28, 17);
            this.findWhatLabel.Name = "findWhatLabel";
            this.findWhatLabel.Size = new System.Drawing.Size(56, 13);
            this.findWhatLabel.TabIndex = 5;
            this.findWhatLabel.Text = "Find what:";
            // 
            // replaceWithLabel
            // 
            this.replaceWithLabel.AutoSize = true;
            this.replaceWithLabel.Location = new System.Drawing.Point(12, 46);
            this.replaceWithLabel.Name = "replaceWithLabel";
            this.replaceWithLabel.Size = new System.Drawing.Size(72, 13);
            this.replaceWithLabel.TabIndex = 6;
            this.replaceWithLabel.Text = "Replace with:";
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Location = new System.Drawing.Point(15, 73);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(82, 17);
            this.matchCaseCheckBox.TabIndex = 5;
            this.matchCaseCheckBox.Text = "Match case";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            this.matchCaseCheckBox.CheckedChanged += new System.EventHandler(this.matchCaseCheckBox_CheckedChanged);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 104);
            this.Controls.Add(this.matchCaseCheckBox);
            this.Controls.Add(this.replaceWithLabel);
            this.Controls.Add(this.findWhatLabel);
            this.Controls.Add(this.findWhatTextBox);
            this.Controls.Add(this.replaceWithTextBox);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.replaceAllButton);
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button replaceAllButton;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.TextBox replaceWithTextBox;
        private System.Windows.Forms.TextBox findWhatTextBox;
        private System.Windows.Forms.Label findWhatLabel;
        private System.Windows.Forms.Label replaceWithLabel;
        private System.Windows.Forms.CheckBox matchCaseCheckBox;
    }
}