namespace Prog3.WinFormsClient
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
            this.ComboBoxCounterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxIterations = new System.Windows.Forms.TextBox();
            this.TextBoxDelay = new System.Windows.Forms.TextBox();
            this.ButtonAddCounter = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ListBoxCounters = new System.Windows.Forms.ListBox();
            this.PanelControls = new System.Windows.Forms.Panel();
            this.PanelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboBoxCounterType
            // 
            this.ComboBoxCounterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCounterType.FormattingEnabled = true;
            this.ComboBoxCounterType.Location = new System.Drawing.Point(9, 24);
            this.ComboBoxCounterType.Name = "ComboBoxCounterType";
            this.ComboBoxCounterType.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCounterType.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conter type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Iterations:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Delay:";
            // 
            // TextBoxIterations
            // 
            this.TextBoxIterations.Location = new System.Drawing.Point(149, 24);
            this.TextBoxIterations.Name = "TextBoxIterations";
            this.TextBoxIterations.Size = new System.Drawing.Size(100, 20);
            this.TextBoxIterations.TabIndex = 4;
            // 
            // TextBoxDelay
            // 
            this.TextBoxDelay.Location = new System.Drawing.Point(268, 24);
            this.TextBoxDelay.Name = "TextBoxDelay";
            this.TextBoxDelay.Size = new System.Drawing.Size(100, 20);
            this.TextBoxDelay.TabIndex = 5;
            // 
            // ButtonAddCounter
            // 
            this.ButtonAddCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAddCounter.Location = new System.Drawing.Point(376, 22);
            this.ButtonAddCounter.Name = "ButtonAddCounter";
            this.ButtonAddCounter.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddCounter.TabIndex = 6;
            this.ButtonAddCounter.Text = "Add counter";
            this.ButtonAddCounter.UseVisualStyleBackColor = true;
            this.ButtonAddCounter.Click += new System.EventHandler(this.ButtonAddCounter_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonStart.Location = new System.Drawing.Point(459, 22);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 23);
            this.ButtonStart.TabIndex = 7;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ListBoxCounters
            // 
            this.ListBoxCounters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxCounters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBoxCounters.FormattingEnabled = true;
            this.ListBoxCounters.Location = new System.Drawing.Point(10, 51);
            this.ListBoxCounters.Name = "ListBoxCounters";
            this.ListBoxCounters.Size = new System.Drawing.Size(523, 394);
            this.ListBoxCounters.TabIndex = 8;
            // 
            // PanelControls
            // 
            this.PanelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelControls.Controls.Add(this.label1);
            this.PanelControls.Controls.Add(this.ButtonStart);
            this.PanelControls.Controls.Add(this.ComboBoxCounterType);
            this.PanelControls.Controls.Add(this.ButtonAddCounter);
            this.PanelControls.Controls.Add(this.label2);
            this.PanelControls.Controls.Add(this.TextBoxDelay);
            this.PanelControls.Controls.Add(this.label3);
            this.PanelControls.Controls.Add(this.TextBoxIterations);
            this.PanelControls.Location = new System.Drawing.Point(0, 0);
            this.PanelControls.Name = "PanelControls";
            this.PanelControls.Size = new System.Drawing.Size(544, 48);
            this.PanelControls.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 450);
            this.Controls.Add(this.ListBoxCounters);
            this.Controls.Add(this.PanelControls);
            this.Name = "Form1";
            this.Text = "Prog#3 WinFormsClient";
            this.PanelControls.ResumeLayout(false);
            this.PanelControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxIterations;
        private System.Windows.Forms.TextBox TextBoxDelay;
        private System.Windows.Forms.Button ButtonAddCounter;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.ComboBox ComboBoxCounterType;
        private System.Windows.Forms.ListBox ListBoxCounters;
        private System.Windows.Forms.Panel PanelControls;
    }
}

