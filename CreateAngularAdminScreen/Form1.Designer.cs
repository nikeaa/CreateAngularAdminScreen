namespace CreateAngularAdminScreen
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.OutputDirectoryTextBox = new System.Windows.Forms.TextBox();
			this.TitleCaseNameTextBox = new System.Windows.Forms.TextBox();
			this.OutputDirectorySearchButton = new System.Windows.Forms.Button();
			this.CamelCaseNameTextBox = new System.Windows.Forms.TextBox();
			this.LowerCamelCaseNameTextBox = new System.Windows.Forms.TextBox();
			this.DashNameTextBox = new System.Windows.Forms.TextBox();
			this.GenerateCodeButton = new System.Windows.Forms.Button();
			this.OutputDirectorySearchDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Output Directory:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Title Case Name";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Camel Case Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Lower Camel Case Name";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(29, 146);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Dash Name";
			// 
			// OutputDirectoryTextBox
			// 
			this.OutputDirectoryTextBox.Location = new System.Drawing.Point(187, 36);
			this.OutputDirectoryTextBox.Name = "OutputDirectoryTextBox";
			this.OutputDirectoryTextBox.Size = new System.Drawing.Size(499, 20);
			this.OutputDirectoryTextBox.TabIndex = 5;
			// 
			// TitleCaseNameTextBox
			// 
			this.TitleCaseNameTextBox.Location = new System.Drawing.Point(187, 75);
			this.TitleCaseNameTextBox.Name = "TitleCaseNameTextBox";
			this.TitleCaseNameTextBox.Size = new System.Drawing.Size(312, 20);
			this.TitleCaseNameTextBox.TabIndex = 6;
			this.TitleCaseNameTextBox.TextChanged += new System.EventHandler(this.TitleCaseNameTextBox_TextChanged);
			// 
			// OutputDirectorySearchButton
			// 
			this.OutputDirectorySearchButton.Location = new System.Drawing.Point(692, 34);
			this.OutputDirectorySearchButton.Name = "OutputDirectorySearchButton";
			this.OutputDirectorySearchButton.Size = new System.Drawing.Size(26, 23);
			this.OutputDirectorySearchButton.TabIndex = 7;
			this.OutputDirectorySearchButton.Text = "...";
			this.OutputDirectorySearchButton.UseVisualStyleBackColor = true;
			this.OutputDirectorySearchButton.Click += new System.EventHandler(this.OutputDirectorySearchButton_Click);
			// 
			// CamelCaseNameTextBox
			// 
			this.CamelCaseNameTextBox.Location = new System.Drawing.Point(187, 97);
			this.CamelCaseNameTextBox.Name = "CamelCaseNameTextBox";
			this.CamelCaseNameTextBox.Size = new System.Drawing.Size(312, 20);
			this.CamelCaseNameTextBox.TabIndex = 8;
			// 
			// LowerCamelCaseNameTextBox
			// 
			this.LowerCamelCaseNameTextBox.Location = new System.Drawing.Point(187, 120);
			this.LowerCamelCaseNameTextBox.Name = "LowerCamelCaseNameTextBox";
			this.LowerCamelCaseNameTextBox.Size = new System.Drawing.Size(312, 20);
			this.LowerCamelCaseNameTextBox.TabIndex = 9;
			// 
			// DashNameTextBox
			// 
			this.DashNameTextBox.Location = new System.Drawing.Point(187, 143);
			this.DashNameTextBox.Name = "DashNameTextBox";
			this.DashNameTextBox.Size = new System.Drawing.Size(312, 20);
			this.DashNameTextBox.TabIndex = 10;
			// 
			// GenerateCodeButton
			// 
			this.GenerateCodeButton.Location = new System.Drawing.Point(630, 141);
			this.GenerateCodeButton.Name = "GenerateCodeButton";
			this.GenerateCodeButton.Size = new System.Drawing.Size(87, 23);
			this.GenerateCodeButton.TabIndex = 11;
			this.GenerateCodeButton.Text = "Generate Code";
			this.GenerateCodeButton.UseVisualStyleBackColor = true;
			this.GenerateCodeButton.Click += new System.EventHandler(this.GenerateCodeButton_Click);
			// 
			// OutputDirectorySearchDialog
			// 
			this.OutputDirectorySearchDialog.SelectedPath = "D:\\Dev";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 188);
			this.Controls.Add(this.GenerateCodeButton);
			this.Controls.Add(this.DashNameTextBox);
			this.Controls.Add(this.LowerCamelCaseNameTextBox);
			this.Controls.Add(this.CamelCaseNameTextBox);
			this.Controls.Add(this.OutputDirectorySearchButton);
			this.Controls.Add(this.TitleCaseNameTextBox);
			this.Controls.Add(this.OutputDirectoryTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox OutputDirectoryTextBox;
		private System.Windows.Forms.TextBox TitleCaseNameTextBox;
		private System.Windows.Forms.Button OutputDirectorySearchButton;
		private System.Windows.Forms.TextBox CamelCaseNameTextBox;
		private System.Windows.Forms.TextBox LowerCamelCaseNameTextBox;
		private System.Windows.Forms.TextBox DashNameTextBox;
		private System.Windows.Forms.Button GenerateCodeButton;
		private System.Windows.Forms.FolderBrowserDialog OutputDirectorySearchDialog;
	}
}

