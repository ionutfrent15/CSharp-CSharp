namespace ConcursInot
{
    partial class MainWindow
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.numeLabel = new System.Windows.Forms.Label();
            this.prenumeLabel = new System.Windows.Forms.Label();
            this.varstaLabel = new System.Windows.Forms.Label();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.prenumeTextBox = new System.Windows.Forms.TextBox();
            this.varstaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inscriereButton = new System.Windows.Forms.Button();
            this.cauta = new System.Windows.Forms.Button();
            this.cautaDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varstaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cautaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(663, 12);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(125, 23);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "LOGOUT";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(333, 511);
            this.dataGridView.TabIndex = 1;
            // 
            // numeLabel
            // 
            this.numeLabel.AutoSize = true;
            this.numeLabel.Location = new System.Drawing.Point(487, 64);
            this.numeLabel.Name = "numeLabel";
            this.numeLabel.Size = new System.Drawing.Size(48, 17);
            this.numeLabel.TabIndex = 2;
            this.numeLabel.Text = "NUME";
            // 
            // prenumeLabel
            // 
            this.prenumeLabel.AutoSize = true;
            this.prenumeLabel.Location = new System.Drawing.Point(459, 105);
            this.prenumeLabel.Name = "prenumeLabel";
            this.prenumeLabel.Size = new System.Drawing.Size(76, 17);
            this.prenumeLabel.TabIndex = 3;
            this.prenumeLabel.Text = "PRENUME";
            // 
            // varstaLabel
            // 
            this.varstaLabel.AutoSize = true;
            this.varstaLabel.Location = new System.Drawing.Point(472, 154);
            this.varstaLabel.Name = "varstaLabel";
            this.varstaLabel.Size = new System.Drawing.Size(63, 17);
            this.varstaLabel.TabIndex = 4;
            this.varstaLabel.Text = "VARSTA";
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(577, 61);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(186, 22);
            this.numeTextBox.TabIndex = 5;
            // 
            // prenumeTextBox
            // 
            this.prenumeTextBox.Location = new System.Drawing.Point(577, 105);
            this.prenumeTextBox.Name = "prenumeTextBox";
            this.prenumeTextBox.Size = new System.Drawing.Size(186, 22);
            this.prenumeTextBox.TabIndex = 6;
            // 
            // varstaNumericUpDown
            // 
            this.varstaNumericUpDown.Location = new System.Drawing.Point(577, 152);
            this.varstaNumericUpDown.Name = "varstaNumericUpDown";
            this.varstaNumericUpDown.Size = new System.Drawing.Size(186, 22);
            this.varstaNumericUpDown.TabIndex = 7;
            // 
            // inscriereButton
            // 
            this.inscriereButton.Location = new System.Drawing.Point(577, 197);
            this.inscriereButton.Name = "inscriereButton";
            this.inscriereButton.Size = new System.Drawing.Size(186, 23);
            this.inscriereButton.TabIndex = 8;
            this.inscriereButton.Text = "INSCRIERE";
            this.inscriereButton.UseVisualStyleBackColor = true;
            this.inscriereButton.Click += new System.EventHandler(this.inscriereButton_Click);
            // 
            // cauta
            // 
            this.cauta.Location = new System.Drawing.Point(401, 274);
            this.cauta.Name = "cauta";
            this.cauta.Size = new System.Drawing.Size(75, 23);
            this.cauta.TabIndex = 10;
            this.cauta.Text = "CAUTA";
            this.cauta.UseVisualStyleBackColor = true;
            this.cauta.Click += new System.EventHandler(this.cauta_Click);
            // 
            // cautaDataGridView
            // 
            this.cautaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cautaDataGridView.Location = new System.Drawing.Point(386, 331);
            this.cautaDataGridView.Name = "cautaDataGridView";
            this.cautaDataGridView.RowTemplate.Height = 24;
            this.cautaDataGridView.Size = new System.Drawing.Size(649, 192);
            this.cautaDataGridView.TabIndex = 11;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 535);
            this.Controls.Add(this.cautaDataGridView);
            this.Controls.Add(this.cauta);
            this.Controls.Add(this.inscriereButton);
            this.Controls.Add(this.varstaNumericUpDown);
            this.Controls.Add(this.prenumeTextBox);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.varstaLabel);
            this.Controls.Add(this.prenumeLabel);
            this.Controls.Add(this.numeLabel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.logoutButton);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varstaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cautaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label numeLabel;
        private System.Windows.Forms.Label prenumeLabel;
        private System.Windows.Forms.Label varstaLabel;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.TextBox prenumeTextBox;
        private System.Windows.Forms.NumericUpDown varstaNumericUpDown;
        private System.Windows.Forms.Button inscriereButton;
        private System.Windows.Forms.Button cauta;
        private System.Windows.Forms.DataGridView cautaDataGridView;
    }
}