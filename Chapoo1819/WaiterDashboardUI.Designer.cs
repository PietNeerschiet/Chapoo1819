namespace Chapoo1819
{
    partial class WaiterDashboardUI
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
            this.btnTakeOrder = new System.Windows.Forms.Button();
            this.lblLoggedInAs = new System.Windows.Forms.Label();
            this.btnRestaurantOverview = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTakeOrder
            // 
            this.btnTakeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeOrder.Location = new System.Drawing.Point(83, 185);
            this.btnTakeOrder.Name = "btnTakeOrder";
            this.btnTakeOrder.Size = new System.Drawing.Size(426, 73);
            this.btnTakeOrder.TabIndex = 0;
            this.btnTakeOrder.Text = "Bestelling opnemen";
            this.btnTakeOrder.UseVisualStyleBackColor = true;
            // 
            // lblLoggedInAs
            // 
            this.lblLoggedInAs.AutoSize = true;
            this.lblLoggedInAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedInAs.Location = new System.Drawing.Point(140, 80);
            this.lblLoggedInAs.Name = "lblLoggedInAs";
            this.lblLoggedInAs.Size = new System.Drawing.Size(313, 32);
            this.lblLoggedInAs.TabIndex = 1;
            this.lblLoggedInAs.Text = "Ingelogd als: Bediening";
            // 
            // btnRestaurantOverview
            // 
            this.btnRestaurantOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurantOverview.Location = new System.Drawing.Point(83, 342);
            this.btnRestaurantOverview.Name = "btnRestaurantOverview";
            this.btnRestaurantOverview.Size = new System.Drawing.Size(426, 73);
            this.btnRestaurantOverview.TabIndex = 2;
            this.btnRestaurantOverview.Text = "Restaurant overzicht";
            this.btnRestaurantOverview.UseVisualStyleBackColor = true;
            this.btnRestaurantOverview.Click += new System.EventHandler(this.btnRestaurantOverview_Click);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOff.Location = new System.Drawing.Point(83, 495);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(426, 73);
            this.btnLogOff.TabIndex = 3;
            this.btnLogOff.Text = "Afmelden";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // WaiterDashboardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 753);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.btnRestaurantOverview);
            this.Controls.Add(this.lblLoggedInAs);
            this.Controls.Add(this.btnTakeOrder);
            this.Name = "WaiterDashboardUI";
            this.Text = "Homepage Bediening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTakeOrder;
        private System.Windows.Forms.Label lblLoggedInAs;
        private System.Windows.Forms.Button btnRestaurantOverview;
        private System.Windows.Forms.Button btnLogOff;
    }
}