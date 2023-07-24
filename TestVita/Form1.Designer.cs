namespace TestVita
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
            this.bindButton = new System.Windows.Forms.Button();
            this.incomeDataGridView = new System.Windows.Forms.DataGridView();
            this.orderDataGridView = new System.Windows.Forms.DataGridView();
            this.bindingAmountTextBox = new System.Windows.Forms.TextBox();
            this.paymentDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.incomeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bindButton
            // 
            this.bindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bindButton.Location = new System.Drawing.Point(762, 410);
            this.bindButton.Name = "bindButton";
            this.bindButton.Size = new System.Drawing.Size(111, 31);
            this.bindButton.TabIndex = 0;
            this.bindButton.Text = "Оплатить";
            this.bindButton.UseVisualStyleBackColor = true;
            this.bindButton.Click += new System.EventHandler(this.bindButton_Click);
            // 
            // incomeDataGridView
            // 
            this.incomeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomeDataGridView.Location = new System.Drawing.Point(3, 40);
            this.incomeDataGridView.Name = "incomeDataGridView";
            this.incomeDataGridView.Size = new System.Drawing.Size(432, 364);
            this.incomeDataGridView.TabIndex = 1;
            // 
            // orderDataGridView
            // 
            this.orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView.Location = new System.Drawing.Point(441, 40);
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.Size = new System.Drawing.Size(432, 364);
            this.orderDataGridView.TabIndex = 2;
            // 
            // bindingAmountTextBox
            // 
            this.bindingAmountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.bindingAmountTextBox.Location = new System.Drawing.Point(606, 410);
            this.bindingAmountTextBox.Multiline = true;
            this.bindingAmountTextBox.Name = "bindingAmountTextBox";
            this.bindingAmountTextBox.Size = new System.Drawing.Size(150, 31);
            this.bindingAmountTextBox.TabIndex = 3;
            // 
            // paymentDataGridView
            // 
            this.paymentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentDataGridView.Location = new System.Drawing.Point(879, 40);
            this.paymentDataGridView.Name = "paymentDataGridView";
            this.paymentDataGridView.Size = new System.Drawing.Size(432, 364);
            this.paymentDataGridView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(1071, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Платежи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(602, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Заказы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(153, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Приход";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paymentDataGridView);
            this.Controls.Add(this.bindingAmountTextBox);
            this.Controls.Add(this.orderDataGridView);
            this.Controls.Add(this.incomeDataGridView);
            this.Controls.Add(this.bindButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.incomeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bindButton;
        private System.Windows.Forms.DataGridView incomeDataGridView;
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.TextBox bindingAmountTextBox;
        private System.Windows.Forms.DataGridView paymentDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

