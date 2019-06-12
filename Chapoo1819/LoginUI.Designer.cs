namespace Chapoo1819
{
    partial class LoginUI
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
            this.btnManagement = new System.Windows.Forms.Button();
            this.btn_ShowOrderUI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManagement
            // 
            this.btnManagement.Location = new System.Drawing.Point(102, 47);
            this.btnManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(158, 90);
            this.btnManagement.TabIndex = 0;
            this.btnManagement.Text = "Show Management";
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btn_ShowOrderUI
            // 
            this.btn_ShowOrderUI.Location = new System.Drawing.Point(299, 47);
            this.btn_ShowOrderUI.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ShowOrderUI.Name = "btn_ShowOrderUI";
            this.btn_ShowOrderUI.Size = new System.Drawing.Size(158, 90);
            this.btn_ShowOrderUI.TabIndex = 1;
            this.btn_ShowOrderUI.Text = "Show Order";
            this.btn_ShowOrderUI.UseVisualStyleBackColor = true;
            this.btn_ShowOrderUI.Click += new System.EventHandler(this.btn_ShowOrderUI_Click);
            // 
            // LoginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_ShowOrderUI);
            this.Controls.Add(this.btnManagement);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginUI";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btn_ShowOrderUI;
    }
}

