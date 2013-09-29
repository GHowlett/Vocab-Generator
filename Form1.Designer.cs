namespace Web_Service_Tut
{
    partial class Form1
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
            this.DefineButton = new System.Windows.Forms.Button();
            this.WordBox = new System.Windows.Forms.TextBox();
            this.DefinitionBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DefineButton
            // 
            this.DefineButton.Location = new System.Drawing.Point(161, 12);
            this.DefineButton.Name = "DefineButton";
            this.DefineButton.Size = new System.Drawing.Size(791, 38);
            this.DefineButton.TabIndex = 0;
            this.DefineButton.Text = "Define";
            this.DefineButton.UseVisualStyleBackColor = true;
            this.DefineButton.Click += new System.EventHandler(this.DefineButton_Click);
            // 
            // WordBox
            // 
            this.WordBox.Location = new System.Drawing.Point(12, 22);
            this.WordBox.Name = "WordBox";
            this.WordBox.Size = new System.Drawing.Size(143, 38);
            this.WordBox.TabIndex = 2;
            // 
            // DefinitionBox
            // 
            this.DefinitionBox.Location = new System.Drawing.Point(12, 73);
            this.DefinitionBox.Name = "DefinitionBox";
            this.DefinitionBox.Size = new System.Drawing.Size(940, 267);
            this.DefinitionBox.TabIndex = 3;
            this.DefinitionBox.Text = "";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.button1.Location = new System.Drawing.Point(12, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(940, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Word Document";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 389);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DefinitionBox);
            this.Controls.Add(this.WordBox);
            this.Controls.Add(this.DefineButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DefineButton;
        private System.Windows.Forms.TextBox WordBox;
        private System.Windows.Forms.RichTextBox DefinitionBox;
        private System.Windows.Forms.Button button1;
    }
}

