﻿namespace LEDSegmentDisplay_Remote
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.AutoStop = new System.Windows.Forms.Button();
            this.AutoStart = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PortBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IPBox);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(309, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "远程地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口";
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(117, 64);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(176, 35);
            this.PortBox.TabIndex = 2;
            this.PortBox.Text = "2000";
            this.PortBox.TextChanged += new System.EventHandler(this.PortBox_TextChanged);
            this.PortBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(117, 19);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(176, 35);
            this.IPBox.TabIndex = 900;
            this.IPBox.Text = "192.168.0.121";
            this.IPBox.TextChanged += new System.EventHandler(this.IPBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CommandBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 116);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(309, 195);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自定信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(281, 28);
            this.label5.TabIndex = 6;
            this.label5.Text = "后四为小数点是否亮起(0或1)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "前四数字为显示数字";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "格式1-2-3-4-0-1-0-1";
            // 
            // CommandBox
            // 
            this.CommandBox.Location = new System.Drawing.Point(7, 113);
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(295, 35);
            this.CommandBox.TabIndex = 0;
            this.CommandBox.Text = "1-2-3-4-0-1-0-1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.AutoStop);
            this.groupBox3.Controls.Add(this.AutoStart);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(320, 130);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自动操作";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(80, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(176, 32);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "自动填充数字0";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AutoStop
            // 
            this.AutoStop.Enabled = false;
            this.AutoStop.ForeColor = System.Drawing.Color.Red;
            this.AutoStop.Location = new System.Drawing.Point(6, 134);
            this.AutoStop.Name = "AutoStop";
            this.AutoStop.Size = new System.Drawing.Size(105, 41);
            this.AutoStop.TabIndex = 8;
            this.AutoStop.Text = "终止";
            this.AutoStop.UseVisualStyleBackColor = true;
            this.AutoStop.Click += new System.EventHandler(this.AutoStop_Click);
            // 
            // AutoStart
            // 
            this.AutoStart.Location = new System.Drawing.Point(221, 134);
            this.AutoStart.Name = "AutoStart";
            this.AutoStart.Size = new System.Drawing.Size(105, 41);
            this.AutoStart.TabIndex = 7;
            this.AutoStart.Text = "开始";
            this.AutoStart.UseVisualStyleBackColor = true;
            this.AutoStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "1";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CPU占用%",
            "剩余内存MB",
            "已用内存MB",
            "GPU内存MB",
            "系统时间",
            "下行网速MB/s"});
            this.comboBox1.Location = new System.Drawing.Point(6, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(320, 36);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 323);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4位共阴数码管";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CommandBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button AutoStop;
        private System.Windows.Forms.Button AutoStart;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

