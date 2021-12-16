namespace faster_csharp
{
    partial class FormMain
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
            this.buttonGCvsLoop = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonStaticVSDynamicArraies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGCvsLoop
            // 
            this.buttonGCvsLoop.Location = new System.Drawing.Point(12, 12);
            this.buttonGCvsLoop.Name = "buttonGCvsLoop";
            this.buttonGCvsLoop.Size = new System.Drawing.Size(180, 36);
            this.buttonGCvsLoop.TabIndex = 0;
            this.buttonGCvsLoop.Text = "Garbage Collectioin vs Loop";
            this.buttonGCvsLoop.UseVisualStyleBackColor = true;
            this.buttonGCvsLoop.Click += new System.EventHandler(this.buttonGCvsLoop_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(198, 12);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(613, 458);
            this.textBoxOutput.TabIndex = 1;
            // 
            // buttonStaticVSDynamicArraies
            // 
            this.buttonStaticVSDynamicArraies.Location = new System.Drawing.Point(12, 54);
            this.buttonStaticVSDynamicArraies.Name = "buttonStaticVSDynamicArraies";
            this.buttonStaticVSDynamicArraies.Size = new System.Drawing.Size(180, 36);
            this.buttonStaticVSDynamicArraies.TabIndex = 2;
            this.buttonStaticVSDynamicArraies.Text = "Static vs dynamic arraies";
            this.buttonStaticVSDynamicArraies.UseVisualStyleBackColor = true;
            this.buttonStaticVSDynamicArraies.Click += new System.EventHandler(this.buttonStaticVSDynamicArraies_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 482);
            this.Controls.Add(this.buttonStaticVSDynamicArraies);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonGCvsLoop);
            this.Name = "FormMain";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGCvsLoop;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonStaticVSDynamicArraies;
    }
}

