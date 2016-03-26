namespace Summoner_Info
{
    partial class UserInterface
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.retrieveName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(12, 35);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(211, 20);
            this.nameInput.TabIndex = 0;
            // 
            // retrieveName
            // 
            this.retrieveName.Location = new System.Drawing.Point(229, 33);
            this.retrieveName.Name = "retrieveName";
            this.retrieveName.Size = new System.Drawing.Size(75, 23);
            this.retrieveName.TabIndex = 1;
            this.retrieveName.Text = "Search";
            this.retrieveName.UseVisualStyleBackColor = true;
            this.retrieveName.Click += new System.EventHandler(this.retrieveInput_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Summoner Name:";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 71);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.retrieveName);
            this.Controls.Add(this.nameInput);
            this.Name = "UserInterface";
            this.Text = "Get Summoner Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Button retrieveName;
        private System.Windows.Forms.Label label1;
    }
}

