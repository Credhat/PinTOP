using Newtonsoft.Json;

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
            this.btnGetData = new System.Windows.Forms.Button();
            this.testPlanIdLabel=new System.Windows.Forms.Label();
            this.testSuiteIdLabel=new System.Windows.Forms.Label();
            this.completeUriLabel=new System.Windows.Forms.Label();
            this.cookieLabel=new System.Windows.Forms.Label();
            this.testPlanIdTextBox=new System.Windows.Forms.TextBox();
            this.testSuiteIdTextBox=new System.Windows.Forms.TextBox();
            this.completeUriTextBox=new System.Windows.Forms.TextBox();
            this.cookieTextBox=new System.Windows.Forms.TextBox();
            this.dataTable1= new System.Data.DataTable();
            this.dataGridView1=new System.Windows.Forms.DataGridView();
            this.progressBar1=new System.Windows.Forms.ProgressBar();
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


   

            // 将JSON数据从TextBox中获取
            // 要求用户输入,或者完整的URl,解析URl即可.
            // 输入框等控件
            int StartY=60;
            this.testPlanIdLabel.Location = new System.Drawing.Point(10, 20+StartY);
            this.testPlanIdLabel.Text = "Test Plan ID";
            this.testPlanIdLabel.AutoSize=true;

            this.testPlanIdTextBox.Location = new System.Drawing.Point(10, 40+StartY);
            this.testPlanIdTextBox.Size = new System.Drawing.Size(80, 21);

            this.testSuiteIdLabel.Location = new System.Drawing.Point(100, 20+StartY);
            this.testSuiteIdLabel.Text = "Test Suite ID";
            this.testSuiteIdLabel.AutoSize=true;

            this.testSuiteIdTextBox.Location = new System.Drawing.Point(100, 40+StartY);
            this.testSuiteIdTextBox.Size = new System.Drawing.Size(80, 21);

            this.completeUriLabel.Location = new System.Drawing.Point(10, 80+StartY);
            this.completeUriLabel.Text = "Complete URL";
            this.completeUriLabel.AutoSize=true;

            this.completeUriTextBox.Location = new System.Drawing.Point(10, 100+StartY);
            this.completeUriTextBox.Size = new System.Drawing.Size(370, 21);

            this.cookieLabel.Location = new System.Drawing.Point(10, 140+StartY);
            this.cookieLabel.Text = "Secret Cookie";
            this.cookieLabel.AutoSize=true;

            this.cookieTextBox.Location = new System.Drawing.Point(10, 160+StartY);
            this.cookieTextBox.Size = new System.Drawing.Size(370, 40);

            //ProgressBar
            this.progressBar1.Location = new System.Drawing.Point(10, 191+StartY);
            this.progressBar1.Size = new System.Drawing.Size(280,22);
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.progressBar1.MarqueeAnimationSpeed=1;
            this.progressBar1.Visible = false;
            // this.progressBar1.Maximum=100;
            // this.progressBar1.Minimum=0;

            // bthGetData
            this.btnGetData.Location =new System.Drawing.Point(305,190+StartY);
            this.btnGetData.Name="bthGetData";
            this.btnGetData.Size=new System.Drawing.Size(75,24);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "GetTestCases";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);


            //TestCasesDataGridView
            this.dataGridView1.DataSource=dataTable1;
            this.dataGridView1.Location=new System.Drawing.Point(400,12);
            this.dataGridView1.Name="dataGridView";
            this.dataGridView1.Size=new System.Drawing.Size(800,400);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Text = "DataTable";
            // this.dataGridView1.UseVisualStyleBackColor = true;
            // this.dataGridView1.Click += new System.EventHandler(this.btnGetData_Click);


            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 74);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUnpin);
            this.Controls.Add(this.btnPin);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.testPlanIdLabel);
            this.Controls.Add(this.testSuiteIdLabel);
            this.Controls.Add(this.completeUriLabel);
            this.Controls.Add(this.cookieLabel);
            this.Controls.Add(this.testPlanIdTextBox);
            this.Controls.Add(this.testSuiteIdTextBox);
            this.Controls.Add(this.completeUriTextBox);
            this.Controls.Add(this.cookieTextBox);
            this.Controls.Add(progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "PinWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnPin;
        private System.Windows.Forms.Button btnUnpin;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label testPlanIdLabel;
        private System.Windows.Forms.Label testSuiteIdLabel;
        private System.Windows.Forms.Label completeUriLabel;
        private System.Windows.Forms.Label cookieLabel;
        private System.Windows.Forms.TextBox testPlanIdTextBox;
        private System.Windows.Forms.TextBox testSuiteIdTextBox;
        private System.Windows.Forms.TextBox completeUriTextBox;
        private System.Windows.Forms.TextBox cookieTextBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.DataTable dataTable1;
    }
