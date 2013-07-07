namespace Capture
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonFancyCarp = new System.Windows.Forms.RadioButton();
            this.radioButtonRainbowTrout = new System.Windows.Forms.RadioButton();
            this.textBoxBaitPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPlace = new System.Windows.Forms.GroupBox();
            this.groupBoxPlace.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(187, 382);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxTimes
            // 
            this.textBoxTimes.Location = new System.Drawing.Point(310, 57);
            this.textBoxTimes.Name = "textBoxTimes";
            this.textBoxTimes.Size = new System.Drawing.Size(94, 21);
            this.textBoxTimes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "次数";
            // 
            // radioButtonFancyCarp
            // 
            this.radioButtonFancyCarp.AutoSize = true;
            this.radioButtonFancyCarp.Location = new System.Drawing.Point(18, 22);
            this.radioButtonFancyCarp.Name = "radioButtonFancyCarp";
            this.radioButtonFancyCarp.Size = new System.Drawing.Size(59, 16);
            this.radioButtonFancyCarp.TabIndex = 5;
            this.radioButtonFancyCarp.TabStop = true;
            this.radioButtonFancyCarp.Text = "钓锦鲤";
            this.radioButtonFancyCarp.UseVisualStyleBackColor = true;
            // 
            // radioButtonRainbowTrout
            // 
            this.radioButtonRainbowTrout.AutoSize = true;
            this.radioButtonRainbowTrout.Location = new System.Drawing.Point(18, 44);
            this.radioButtonRainbowTrout.Name = "radioButtonRainbowTrout";
            this.radioButtonRainbowTrout.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRainbowTrout.TabIndex = 6;
            this.radioButtonRainbowTrout.TabStop = true;
            this.radioButtonRainbowTrout.Text = "钓虹鳟鱼";
            this.radioButtonRainbowTrout.UseVisualStyleBackColor = true;
            // 
            // textBoxBaitPos
            // 
            this.textBoxBaitPos.Location = new System.Drawing.Point(310, 90);
            this.textBoxBaitPos.Name = "textBoxBaitPos";
            this.textBoxBaitPos.Size = new System.Drawing.Size(94, 21);
            this.textBoxBaitPos.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "鱼饵位置";
            // 
            // groupBoxPlace
            // 
            this.groupBoxPlace.Controls.Add(this.radioButtonRainbowTrout);
            this.groupBoxPlace.Controls.Add(this.radioButtonFancyCarp);
            this.groupBoxPlace.Location = new System.Drawing.Point(293, 156);
            this.groupBoxPlace.Name = "groupBoxPlace";
            this.groupBoxPlace.Size = new System.Drawing.Size(111, 66);
            this.groupBoxPlace.TabIndex = 9;
            this.groupBoxPlace.TabStop = false;
            this.groupBoxPlace.Text = "钓鱼地点";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 421);
            this.Controls.Add(this.groupBoxPlace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxBaitPos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Fishing";
            this.groupBoxPlace.ResumeLayout(false);
            this.groupBoxPlace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonFancyCarp;
        private System.Windows.Forms.RadioButton radioButtonRainbowTrout;
        private System.Windows.Forms.TextBox textBoxBaitPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxPlace;
    }
}

