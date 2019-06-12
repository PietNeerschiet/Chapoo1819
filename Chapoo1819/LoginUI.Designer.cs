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
<<<<<<< HEAD
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
=======
            this.btnManagement = new System.Windows.Forms.Button();
            this.btn_ShowOrderUI = new System.Windows.Forms.Button();
>>>>>>> dadc583cba119b0cd0c27740dac0dd6996f08845
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
<<<<<<< HEAD
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(86, 234);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(408, 67);
            this.textBoxUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 69);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(86, 395);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(408, 67);
            this.textBoxPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wachtwoord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 44);
            this.label3.TabIndex = 5;
            this.label3.Text = "Werknemersnummer";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(133, 563);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(295, 75);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Aanmelden";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(81, 481);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(388, 25);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Inloggegevens onjuist, probeer het opnieuw";
            this.lblError.Visible = false;
=======
            this.btnManagement.Location = new System.Drawing.Point(102, 47);
            this.btnManagement.Margin = new System.Windows.Forms.Padding(2);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(158, 90);
            this.btnManagement.TabIndex = 0;
            this.btnManagement.Text = "Show Management";
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
>>>>>>> dadc583cba119b0cd0c27740dac0dd6996f08845
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
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(582, 753);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxUsername);
=======
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_ShowOrderUI);
            this.Controls.Add(this.btnManagement);
            this.Margin = new System.Windows.Forms.Padding(2);
>>>>>>> dadc583cba119b0cd0c27740dac0dd6996f08845
            this.Name = "LoginUI";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
<<<<<<< HEAD
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblError;
=======

        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btn_ShowOrderUI;
>>>>>>> dadc583cba119b0cd0c27740dac0dd6996f08845
    }
}

