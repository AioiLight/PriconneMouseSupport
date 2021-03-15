
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Middle = new PriconneMouseSupport.MouseButton();
            this.Forward = new PriconneMouseSupport.MouseButton();
            this.Back = new PriconneMouseSupport.MouseButton();
            this.Button_Save = new System.Windows.Forms.Button();
            this.CheckBox_Active = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Middle
            // 
            this.Middle.Functions = PriconneMouseSupport.Functions.Menu;
            this.Middle.LabelTitle = "中クリック:";
            resources.ApplyResources(this.Middle, "Middle");
            this.Middle.Name = "Middle";
            // 
            // Forward
            // 
            this.Forward.Functions = PriconneMouseSupport.Functions.Auto;
            this.Forward.LabelTitle = "進むボタン:";
            resources.ApplyResources(this.Forward, "Forward");
            this.Forward.Name = "Forward";
            // 
            // Back
            // 
            this.Back.Functions = PriconneMouseSupport.Functions.Back;
            this.Back.LabelTitle = "戻るボタン:";
            resources.ApplyResources(this.Back, "Back");
            this.Back.Name = "Back";
            // 
            // Button_Save
            // 
            resources.ApplyResources(this.Button_Save, "Button_Save");
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // CheckBox_Active
            // 
            resources.ApplyResources(this.CheckBox_Active, "CheckBox_Active");
            this.CheckBox_Active.Name = "CheckBox_Active";
            this.CheckBox_Active.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CheckBox_Active);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Middle);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MouseButton Middle;
        private MouseButton Forward;
        private MouseButton Back;
        private System.Windows.Forms.Label abe;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.CheckBox CheckBox_Active;
    }
}

