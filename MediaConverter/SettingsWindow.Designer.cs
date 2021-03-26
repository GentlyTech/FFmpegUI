
namespace MediaConverter
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.DefaultStartLocationTextbox = new System.Windows.Forms.TextBox();
            this.DefaultStartLocationButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DefaultOutputLocationTextbox = new System.Windows.Forms.TextBox();
            this.DefaultOutputLocationButton = new System.Windows.Forms.Button();
            this.FileFiltersCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 469);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(630, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(630, 370);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Settings";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.DefaultStartLocationTextbox);
            this.flowLayoutPanel2.Controls.Add(this.DefaultStartLocationButton);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.DefaultOutputLocationTextbox);
            this.flowLayoutPanel2.Controls.Add(this.DefaultOutputLocationButton);
            this.flowLayoutPanel2.Controls.Add(this.FileFiltersCheckbox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(335, 150);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Default Start Location";
            // 
            // DefaultStartLocationTextbox
            // 
            this.DefaultStartLocationTextbox.Location = new System.Drawing.Point(3, 23);
            this.DefaultStartLocationTextbox.Name = "DefaultStartLocationTextbox";
            this.DefaultStartLocationTextbox.Size = new System.Drawing.Size(221, 27);
            this.DefaultStartLocationTextbox.TabIndex = 0;
            this.DefaultStartLocationTextbox.TextChanged += new System.EventHandler(this.DefaultStartLocationTextbox_TextChanged);
            // 
            // DefaultStartLocationButton
            // 
            this.DefaultStartLocationButton.Location = new System.Drawing.Point(230, 23);
            this.DefaultStartLocationButton.Name = "DefaultStartLocationButton";
            this.DefaultStartLocationButton.Size = new System.Drawing.Size(94, 29);
            this.DefaultStartLocationButton.TabIndex = 1;
            this.DefaultStartLocationButton.Text = "Change";
            this.DefaultStartLocationButton.UseVisualStyleBackColor = true;
            this.DefaultStartLocationButton.Click += new System.EventHandler(this.DefaultStartLocationButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Default Output Location";
            // 
            // DefaultOutputLocationTextbox
            // 
            this.DefaultOutputLocationTextbox.Location = new System.Drawing.Point(3, 78);
            this.DefaultOutputLocationTextbox.Name = "DefaultOutputLocationTextbox";
            this.DefaultOutputLocationTextbox.Size = new System.Drawing.Size(221, 27);
            this.DefaultOutputLocationTextbox.TabIndex = 3;
            this.DefaultOutputLocationTextbox.TextChanged += new System.EventHandler(this.DefaultOutputLocationTextbox_TextChanged);
            // 
            // DefaultOutputLocationButton
            // 
            this.DefaultOutputLocationButton.Location = new System.Drawing.Point(230, 78);
            this.DefaultOutputLocationButton.Name = "DefaultOutputLocationButton";
            this.DefaultOutputLocationButton.Size = new System.Drawing.Size(94, 29);
            this.DefaultOutputLocationButton.TabIndex = 2;
            this.DefaultOutputLocationButton.Text = "Change";
            this.DefaultOutputLocationButton.UseVisualStyleBackColor = true;
            this.DefaultOutputLocationButton.Click += new System.EventHandler(this.DefaultOutputLocationButton_Click);
            // 
            // FileFiltersCheckbox
            // 
            this.FileFiltersCheckbox.AutoSize = true;
            this.FileFiltersCheckbox.Location = new System.Drawing.Point(3, 113);
            this.FileFiltersCheckbox.Name = "FileFiltersCheckbox";
            this.FileFiltersCheckbox.Size = new System.Drawing.Size(125, 24);
            this.FileFiltersCheckbox.TabIndex = 6;
            this.FileFiltersCheckbox.Text = "Use File Filters";
            this.FileFiltersCheckbox.UseVisualStyleBackColor = true;
            this.FileFiltersCheckbox.CheckedChanged += new System.EventHandler(this.FileFiltersCheckbox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResetButton);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 430);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 34);
            this.panel1.TabIndex = 2;
            // 
            // ResetButton
            // 
            this.ResetButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResetButton.ForeColor = System.Drawing.Color.Red;
            this.ResetButton.Location = new System.Drawing.Point(0, 0);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(94, 34);
            this.ResetButton.TabIndex = 5;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(442, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(94, 34);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SaveButton.Location = new System.Drawing.Point(536, 0);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(94, 34);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 469);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox DefaultStartLocationTextbox;
        private System.Windows.Forms.Button DefaultStartLocationButton;
        private System.Windows.Forms.TextBox DefaultOutputLocationTextbox;
        private System.Windows.Forms.Button DefaultOutputLocationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox FileFiltersCheckbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ResetButton;
    }
}