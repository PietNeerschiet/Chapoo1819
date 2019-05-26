namespace Chapoo1819
{
    partial class ManagementUI
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
            this.pnl_Home = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.btnChangeMenu = new System.Windows.Forms.Button();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.btnEmployeeManagement = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnTakeOrder = new System.Windows.Forms.Button();
            this.pnl_Stock = new System.Windows.Forms.Panel();
            this.listViewStock = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_Stock = new System.Windows.Forms.Label();
            this.pnl_Home.SuspendLayout();
            this.pnl_Stock.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Home
            // 
            this.pnl_Home.Controls.Add(this.lblHome);
            this.pnl_Home.Controls.Add(this.btnChangeMenu);
            this.pnl_Home.Controls.Add(this.btnRevenue);
            this.pnl_Home.Controls.Add(this.btnEmployeeManagement);
            this.pnl_Home.Controls.Add(this.btnStock);
            this.pnl_Home.Controls.Add(this.btnTakeOrder);
            this.pnl_Home.Location = new System.Drawing.Point(1, 5);
            this.pnl_Home.Name = "pnl_Home";
            this.pnl_Home.Size = new System.Drawing.Size(579, 747);
            this.pnl_Home.TabIndex = 0;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHome.Location = new System.Drawing.Point(232, 49);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(90, 32);
            this.lblHome.TabIndex = 5;
            this.lblHome.Text = "Home";
            // 
            // btnChangeMenu
            // 
            this.btnChangeMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeMenu.Location = new System.Drawing.Point(11, 640);
            this.btnChangeMenu.Name = "btnChangeMenu";
            this.btnChangeMenu.Size = new System.Drawing.Size(558, 94);
            this.btnChangeMenu.TabIndex = 4;
            this.btnChangeMenu.Text = "Change menu";
            this.btnChangeMenu.UseVisualStyleBackColor = true;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenue.Location = new System.Drawing.Point(11, 524);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(558, 94);
            this.btnRevenue.TabIndex = 3;
            this.btnRevenue.Text = "Revenue";
            this.btnRevenue.UseVisualStyleBackColor = true;
            // 
            // btnEmployeeManagement
            // 
            this.btnEmployeeManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeManagement.Location = new System.Drawing.Point(11, 410);
            this.btnEmployeeManagement.Name = "btnEmployeeManagement";
            this.btnEmployeeManagement.Size = new System.Drawing.Size(558, 94);
            this.btnEmployeeManagement.TabIndex = 2;
            this.btnEmployeeManagement.Text = "Employee management";
            this.btnEmployeeManagement.UseVisualStyleBackColor = true;
            // 
            // btnStock
            // 
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Location = new System.Drawing.Point(11, 298);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(558, 94);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnTakeOrder
            // 
            this.btnTakeOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakeOrder.Location = new System.Drawing.Point(11, 187);
            this.btnTakeOrder.Name = "btnTakeOrder";
            this.btnTakeOrder.Size = new System.Drawing.Size(558, 94);
            this.btnTakeOrder.TabIndex = 0;
            this.btnTakeOrder.Text = "Take order / change existing order";
            this.btnTakeOrder.UseVisualStyleBackColor = true;
            this.btnTakeOrder.Click += new System.EventHandler(this.btnTakeOrder_Click);
            // 
            // pnl_Stock
            // 
            this.pnl_Stock.Controls.Add(this.listViewStock);
            this.pnl_Stock.Controls.Add(this.lbl_Stock);
            this.pnl_Stock.Location = new System.Drawing.Point(4, 5);
            this.pnl_Stock.Name = "pnl_Stock";
            this.pnl_Stock.Size = new System.Drawing.Size(579, 747);
            this.pnl_Stock.TabIndex = 1;
            // 
            // listViewStock
            // 
            this.listViewStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewStock.Location = new System.Drawing.Point(11, 109);
            this.listViewStock.Name = "listViewStock";
            this.listViewStock.Size = new System.Drawing.Size(558, 628);
            this.listViewStock.TabIndex = 1;
            this.listViewStock.UseCompatibleStateImageBehavior = false;
            this.listViewStock.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "Item ID";
            this.columnHeader0.Width = 58;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Stock";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 58;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Price";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 66;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Category";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 81;
            // 
            // lbl_Stock
            // 
            this.lbl_Stock.AutoSize = true;
            this.lbl_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Stock.Location = new System.Drawing.Point(12, 14);
            this.lbl_Stock.Name = "lbl_Stock";
            this.lbl_Stock.Size = new System.Drawing.Size(86, 32);
            this.lbl_Stock.TabIndex = 0;
            this.lbl_Stock.Text = "Stock";
            // 
            // ManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 753);
            this.Controls.Add(this.pnl_Stock);
            this.Controls.Add(this.pnl_Home);
            this.Name = "ManagementUI";
            this.Text = "ManagementUI";
            this.Load += new System.EventHandler(this.ManagementUI_Load);
            this.pnl_Home.ResumeLayout(false);
            this.pnl_Home.PerformLayout();
            this.pnl_Stock.ResumeLayout(false);
            this.pnl_Stock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Home;
        private System.Windows.Forms.Button btnChangeMenu;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Button btnEmployeeManagement;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnTakeOrder;
        private System.Windows.Forms.Panel pnl_Stock;
        private System.Windows.Forms.Label lbl_Stock;
        private System.Windows.Forms.ListView listViewStock;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblHome;
    }
}