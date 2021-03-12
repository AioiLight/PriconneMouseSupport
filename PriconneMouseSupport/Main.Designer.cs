
namespace PriconneMouseSupport
{
    partial class Main
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
            this.Middle = new PriconneMouseSupport.MouseButton();
            this.Forward = new PriconneMouseSupport.MouseButton();
            this.Back = new PriconneMouseSupport.MouseButton();
            this.SuspendLayout();
            // 
            // Middle
            // 
            this.Middle.Functions = PriconneMouseSupport.Functions.Menu;
            this.Middle.LabelTitle = "Middle Click:";
            this.Middle.Location = new System.Drawing.Point(12, 12);
            this.Middle.Name = "Middle";
            this.Middle.Size = new System.Drawing.Size(288, 50);
            this.Middle.TabIndex = 0;
            // 
            // Forward
            // 
            this.Forward.Functions = PriconneMouseSupport.Functions.Auto;
            this.Forward.LabelTitle = "Forward button:";
            this.Forward.Location = new System.Drawing.Point(12, 68);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(288, 50);
            this.Forward.TabIndex = 1;
            // 
            // Back
            // 
            this.Back.Functions = PriconneMouseSupport.Functions.Back;
            this.Back.LabelTitle = "Back button:";
            this.Back.Location = new System.Drawing.Point(12, 124);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(288, 50);
            this.Back.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 289);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Middle);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 320);
            this.Name = "Main";
            this.Text = "PriconneMouseSupport";
            this.ResumeLayout(false);

        }

        #endregion

        private MouseButton Middle;
        private MouseButton Forward;
        private MouseButton Back;
    }
}

