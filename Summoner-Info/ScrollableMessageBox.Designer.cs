namespace Summoner_Info
{
    partial class ScrollableMessageBox
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
            this.ScrollableMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ScrollableMessage
            // 
            this.ScrollableMessage.Location = new System.Drawing.Point(22, 12);
            this.ScrollableMessage.Multiline = true;
            this.ScrollableMessage.Name = "ScrollableMessage";
            this.ScrollableMessage.ReadOnly = true;
            this.ScrollableMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ScrollableMessage.Size = new System.Drawing.Size(335, 268);
            this.ScrollableMessage.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScrollableMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 321);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ScrollableMessage);
            this.Name = "ScrollableMessageBox";
            this.Text = "ScrollableMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScrollableMessage;
        private System.Windows.Forms.Button button1;
    }
}