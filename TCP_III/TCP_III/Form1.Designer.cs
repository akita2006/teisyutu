namespace TCP_ClientTest8
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_ReceivedData = new System.Windows.Forms.TextBox();
            this.btn_Send3 = new System.Windows.Forms.Button();
            this.btn_Send2 = new System.Windows.Forms.Button();
            this.btn_Send1 = new System.Windows.Forms.Button();
            this.txt_SendText3 = new System.Windows.Forms.TextBox();
            this.txt_SendText1 = new System.Windows.Forms.TextBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ServerIP = new System.Windows.Forms.TextBox();
            this.lbl_ConnectedStatus = new System.Windows.Forms.Label();
            this.tmr_Main = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txt_SendText4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txt_ReceivedData
            // 
            this.txt_ReceivedData.Location = new System.Drawing.Point(82, 359);
            this.txt_ReceivedData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ReceivedData.Multiline = true;
            this.txt_ReceivedData.Name = "txt_ReceivedData";
            this.txt_ReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ReceivedData.Size = new System.Drawing.Size(629, 218);
            this.txt_ReceivedData.TabIndex = 45;
            // 
            // btn_Send3
            // 
            this.btn_Send3.Location = new System.Drawing.Point(250, 216);
            this.btn_Send3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Send3.Name = "btn_Send3";
            this.btn_Send3.Size = new System.Drawing.Size(125, 34);
            this.btn_Send3.TabIndex = 42;
            this.btn_Send3.Text = "送信";
            this.btn_Send3.UseVisualStyleBackColor = true;
            this.btn_Send3.Click += new System.EventHandler(this.btn_Send3_Click);
            // 
            // btn_Send2
            // 
            this.btn_Send2.Location = new System.Drawing.Point(250, 165);
            this.btn_Send2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Send2.Name = "btn_Send2";
            this.btn_Send2.Size = new System.Drawing.Size(125, 34);
            this.btn_Send2.TabIndex = 43;
            this.btn_Send2.Text = "送信";
            this.btn_Send2.UseVisualStyleBackColor = true;
            this.btn_Send2.Click += new System.EventHandler(this.btn_Send2_Click);
            // 
            // btn_Send1
            // 
            this.btn_Send1.Location = new System.Drawing.Point(250, 119);
            this.btn_Send1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Send1.Name = "btn_Send1";
            this.btn_Send1.Size = new System.Drawing.Size(125, 34);
            this.btn_Send1.TabIndex = 44;
            this.btn_Send1.Text = "送信";
            this.btn_Send1.UseVisualStyleBackColor = true;
            this.btn_Send1.Click += new System.EventHandler(this.btn_Send1_Click);
            // 
            // txt_SendText3
            // 
            this.txt_SendText3.Location = new System.Drawing.Point(404, 220);
            this.txt_SendText3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText3.Name = "txt_SendText3";
            this.txt_SendText3.Size = new System.Drawing.Size(299, 25);
            this.txt_SendText3.TabIndex = 39;
            this.txt_SendText3.Text = "SampleStringABC";
            // 
            // txt_SendText1
            // 
            this.txt_SendText1.Location = new System.Drawing.Point(404, 124);
            this.txt_SendText1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText1.Name = "txt_SendText1";
            this.txt_SendText1.Size = new System.Drawing.Size(299, 25);
            this.txt_SendText1.TabIndex = 41;
            this.txt_SendText1.Text = "NAME PC1";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(405, 36);
            this.btn_Disconnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(125, 34);
            this.btn_Disconnect.TabIndex = 37;
            this.btn_Disconnect.Text = "切断";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(270, 36);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(125, 34);
            this.btn_Connect.TabIndex = 38;
            this.btn_Connect.Text = "接続";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 337);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 48;
            this.label4.Text = "受信データ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "適当な文字列送信";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "データ送信";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "Name登録";
            // 
            // txt_ServerIP
            // 
            this.txt_ServerIP.Location = new System.Drawing.Point(89, 39);
            this.txt_ServerIP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ServerIP.Name = "txt_ServerIP";
            this.txt_ServerIP.Size = new System.Drawing.Size(164, 25);
            this.txt_ServerIP.TabIndex = 47;
            this.txt_ServerIP.Text = "127.0.0.1";
            // 
            // lbl_ConnectedStatus
            // 
            this.lbl_ConnectedStatus.BackColor = System.Drawing.Color.DarkGray;
            this.lbl_ConnectedStatus.Location = new System.Drawing.Point(44, 37);
            this.lbl_ConnectedStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_ConnectedStatus.Name = "lbl_ConnectedStatus";
            this.lbl_ConnectedStatus.Size = new System.Drawing.Size(35, 33);
            this.lbl_ConnectedStatus.TabIndex = 46;
            // 
            // tmr_Main
            // 
            this.tmr_Main.Enabled = true;
            this.tmr_Main.Tick += new System.EventHandler(this.tmr_Main_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 274);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 34);
            this.button1.TabIndex = 53;
            this.button1.Text = "送信";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_SendText4
            // 
            this.txt_SendText4.Location = new System.Drawing.Point(404, 278);
            this.txt_SendText4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText4.Name = "txt_SendText4";
            this.txt_SendText4.Size = new System.Drawing.Size(299, 25);
            this.txt_SendText4.TabIndex = 52;
            this.txt_SendText4.Text = "SampleStringABC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 281);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 18);
            this.label5.TabIndex = 54;
            this.label5.Text = "位置情報の送信";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "決闘可",
            "決闘不"});
            this.comboBox1.Location = new System.Drawing.Point(404, 170);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 26);
            this.comboBox1.TabIndex = 55;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 593);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_SendText4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ReceivedData);
            this.Controls.Add(this.btn_Send3);
            this.Controls.Add(this.btn_Send2);
            this.Controls.Add(this.btn_Send1);
            this.Controls.Add(this.txt_SendText3);
            this.Controls.Add(this.txt_SendText1);
            this.Controls.Add(this.btn_Disconnect);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ServerIP);
            this.Controls.Add(this.lbl_ConnectedStatus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ReceivedData;
        private System.Windows.Forms.Button btn_Send3;
        private System.Windows.Forms.Button btn_Send2;
        private System.Windows.Forms.Button btn_Send1;
        private System.Windows.Forms.TextBox txt_SendText3;
        private System.Windows.Forms.TextBox txt_SendText1;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ServerIP;
        private System.Windows.Forms.Label lbl_ConnectedStatus;
        private System.Windows.Forms.Timer tmr_Main;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_SendText4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

