namespace Fishing
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxCapture = new System.Windows.Forms.PictureBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.textBoxPos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDirection = new System.Windows.Forms.GroupBox();
            this.radioButtonDown = new System.Windows.Forms.RadioButton();
            this.radioButtonUp = new System.Windows.Forms.RadioButton();
            this.buttonSell = new System.Windows.Forms.Button();
            this.buttonStopSell = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSellTimes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).BeginInit();
            this.groupBoxDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(685, 732);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(8);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(325, 80);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(30, 30);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(8);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(462, 949);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(685, 858);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(8);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(325, 80);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "中止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxTimes
            // 
            this.textBoxTimes.Location = new System.Drawing.Point(775, 142);
            this.textBoxTimes.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxTimes.Name = "textBoxTimes";
            this.textBoxTimes.Size = new System.Drawing.Size(229, 42);
            this.textBoxTimes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "次数";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Location = new System.Drawing.Point(685, 255);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(325, 410);
            this.flowLayoutPanel.TabIndex = 10;
            // 
            // pictureBoxCapture
            // 
            this.pictureBoxCapture.Location = new System.Drawing.Point(1121, 379);
            this.pictureBoxCapture.Name = "pictureBoxCapture";
            this.pictureBoxCapture.Size = new System.Drawing.Size(600, 600);
            this.pictureBoxCapture.TabIndex = 11;
            this.pictureBoxCapture.TabStop = false;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(1230, 90);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(155, 42);
            this.textBoxLeft.TabIndex = 12;
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(1230, 162);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(155, 42);
            this.textBoxTop.TabIndex = 13;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(1230, 237);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(155, 42);
            this.textBoxLength.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1116, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 30);
            this.label2.TabIndex = 15;
            this.label2.Text = "横坐标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1116, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 30);
            this.label3.TabIndex = 16;
            this.label3.Text = "纵坐标";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1131, 249);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 30);
            this.label4.TabIndex = 17;
            this.label4.Text = "边长";
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(1468, 141);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(162, 78);
            this.buttonCapture.TabIndex = 18;
            this.buttonCapture.Text = "截图";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // textBoxPos
            // 
            this.textBoxPos.Location = new System.Drawing.Point(1830, 74);
            this.textBoxPos.Name = "textBoxPos";
            this.textBoxPos.Size = new System.Drawing.Size(207, 42);
            this.textBoxPos.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1735, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 30);
            this.label5.TabIndex = 20;
            this.label5.Text = "位置";
            // 
            // groupBoxDirection
            // 
            this.groupBoxDirection.Controls.Add(this.radioButtonDown);
            this.groupBoxDirection.Controls.Add(this.radioButtonUp);
            this.groupBoxDirection.Location = new System.Drawing.Point(1830, 152);
            this.groupBoxDirection.Name = "groupBoxDirection";
            this.groupBoxDirection.Size = new System.Drawing.Size(194, 133);
            this.groupBoxDirection.TabIndex = 21;
            this.groupBoxDirection.TabStop = false;
            // 
            // radioButtonDown
            // 
            this.radioButtonDown.AutoSize = true;
            this.radioButtonDown.Location = new System.Drawing.Point(16, 71);
            this.radioButtonDown.Name = "radioButtonDown";
            this.radioButtonDown.Size = new System.Drawing.Size(110, 34);
            this.radioButtonDown.TabIndex = 23;
            this.radioButtonDown.TabStop = true;
            this.radioButtonDown.Text = "向下";
            this.radioButtonDown.UseVisualStyleBackColor = true;
            // 
            // radioButtonUp
            // 
            this.radioButtonUp.AutoSize = true;
            this.radioButtonUp.Location = new System.Drawing.Point(16, 31);
            this.radioButtonUp.Name = "radioButtonUp";
            this.radioButtonUp.Size = new System.Drawing.Size(110, 34);
            this.radioButtonUp.TabIndex = 22;
            this.radioButtonUp.TabStop = true;
            this.radioButtonUp.Text = "向上";
            this.radioButtonUp.UseVisualStyleBackColor = true;
            // 
            // buttonSell
            // 
            this.buttonSell.Location = new System.Drawing.Point(1814, 434);
            this.buttonSell.Margin = new System.Windows.Forms.Padding(8);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(238, 80);
            this.buttonSell.TabIndex = 22;
            this.buttonSell.Text = "卖鱼";
            this.buttonSell.UseVisualStyleBackColor = true;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // buttonStopSell
            // 
            this.buttonStopSell.Location = new System.Drawing.Point(1814, 585);
            this.buttonStopSell.Margin = new System.Windows.Forms.Padding(8);
            this.buttonStopSell.Name = "buttonStopSell";
            this.buttonStopSell.Size = new System.Drawing.Size(238, 80);
            this.buttonStopSell.TabIndex = 23;
            this.buttonStopSell.Text = "中止";
            this.buttonStopSell.UseVisualStyleBackColor = true;
            this.buttonStopSell.Click += new System.EventHandler(this.buttonStopSell_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1735, 291);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 30);
            this.label6.TabIndex = 25;
            this.label6.Text = "次数";
            // 
            // textBoxSellTimes
            // 
            this.textBoxSellTimes.Location = new System.Drawing.Point(1830, 291);
            this.textBoxSellTimes.Name = "textBoxSellTimes";
            this.textBoxSellTimes.Size = new System.Drawing.Size(207, 42);
            this.textBoxSellTimes.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2143, 1052);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxSellTimes);
            this.Controls.Add(this.buttonStopSell);
            this.Controls.Add(this.buttonSell);
            this.Controls.Add(this.groupBoxDirection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPos);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.textBoxTop);
            this.Controls.Add(this.textBoxLeft);
            this.Controls.Add(this.pictureBoxCapture);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimes);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonStart);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "Form1";
            this.Text = "Fishing";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapture)).EndInit();
            this.groupBoxDirection.ResumeLayout(false);
            this.groupBoxDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.PictureBox pictureBoxCapture;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.TextBox textBoxPos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxDirection;
        private System.Windows.Forms.RadioButton radioButtonDown;
        private System.Windows.Forms.RadioButton radioButtonUp;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Button buttonStopSell;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSellTimes;
    }
}

