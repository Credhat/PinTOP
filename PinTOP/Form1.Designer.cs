namespace PinTOP;


partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnPin = new System.Windows.Forms.Button();
            this.btnUnpin = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // comboBox1
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(370, 21);
            this.comboBox1.TabIndex = 0;

            // btnPin
            this.btnPin.Location = new System.Drawing.Point(12, 39);
            this.btnPin.Name = "btnPin";
            this.btnPin.Size = new System.Drawing.Size(75, 23);
            this.btnPin.TabIndex = 1;
            this.btnPin.Text = "Pin";
            this.btnPin.UseVisualStyleBackColor = true;
            this.btnPin.Click += new System.EventHandler(this.btnPin_Click);

            // btnUnpin
            this.btnUnpin.Location = new System.Drawing.Point(93, 39);
            this.btnUnpin.Name = "btnUnpin";
            this.btnUnpin.Size = new System.Drawing.Size(75, 23);
            this.btnUnpin.TabIndex = 2;
            this.btnUnpin.Text = "Unpin";
            this.btnUnpin.UseVisualStyleBackColor = true;
            this.btnUnpin.Click += new System.EventHandler(this.btnUnpin_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(194, 39);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 74);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUnpin);
            this.Controls.Add(this.btnPin);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "PinWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnPin;
        private System.Windows.Forms.Button btnUnpin;
        private System.Windows.Forms.Button btnRefresh;
    }


    // partial class Form1
    // {
    //     /// <summary>
    //     /// Required designer variable.
    //     /// </summary>
    //     private System.ComponentModel.IContainer components = null;

    //     /// <summary>
    //     /// Clean up any resources being used.
    //     /// </summary>
    //     /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //     protected override void Dispose(bool disposing)
    //     {
    //         if (disposing && (components != null))
    //         {
    //             components.Dispose();
    //         }
    //         base.Dispose(disposing);
    //     }

    //     #region Windows Form Designer generated code

    //     /// <summary>
    //     /// Required method for Designer support - do not modify
    //     /// the contents of this method with the code editor.
    //     /// </summary>
    //     private void InitializeComponent()
    //     {
    //         this.comboBox1 = new System.Windows.Forms.ComboBox();
    //         this.pinButton = new System.Windows.Forms.Button();
    //         this.unpinButton = new System.Windows.Forms.Button();
    //         this.SuspendLayout();
    //         // 
    //         // comboBox1
    //         // 
    //         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    //         this.comboBox1.FormattingEnabled = true;
    //         this.comboBox1.Location = new System.Drawing.Point(12, 12);
    //         this.comboBox1.Name = "comboBox1";
    //         this.comboBox1.Size = new System.Drawing.Size(308, 21);
    //         this.comboBox1.TabIndex = 0;
    //         // 
    //         // pinButton
    //         // 
    //         this.pinButton.Location = new System.Drawing.Point(12, 39);
    //         this.pinButton.Name = "pinButton";
    //         this.pinButton.Size = new System.Drawing.Size(146, 23);
    //         this.pinButton.TabIndex = 1;
    //         this.pinButton.Text = "Pin Window";
    //         this.pinButton.UseVisualStyleBackColor = true;
    //         this.pinButton.Click += new System.EventHandler(this.btnPin_Click);
    //         // 
    //         // unpinButton
    //         // 
    //         this.unpinButton.Location = new System.Drawing.Point(174, 39);
    //         this.unpinButton.Name = "unpinButton";
    //         this.unpinButton.Size = new System.Drawing.Size(146, 23);
    //         this.unpinButton.TabIndex = 2;
    //         this.unpinButton.Text = "Unpin Window";
    //         this.unpinButton.UseVisualStyleBackColor = true;
    //         this.unpinButton.Click += new System.EventHandler(this.btnUnpin_Click);
    //         // 
    //         // Form1
    //         // 
    //         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //         this.ClientSize = new System.Drawing.Size(332, 76);
    //         this.Controls.Add(this.unpinButton);
    //         this.Controls.Add(this.pinButton);
    //         this.Controls.Add(this.comboBox1);
    //         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    //         this.MaximizeBox = false;
    //         this.Name = "Form1";
    //         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    //         this.Text = "PinWindow";
    //         this.Load += new System.EventHandler(this.Form1_Load);
    //         this.ResumeLayout(false);

    //     }

    //     #endregion

    //     private System.Windows.Forms.ComboBox comboBox1;
    //     private System.Windows.Forms.Button pinButton;
    //     private System.Windows.Forms.Button unpinButton;
    // }
