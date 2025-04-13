namespace TCP_II
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
            this.btn_ServerStop = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txt_ClientName = new System.Windows.Forms.TextBox();
            this.txt_SendText3 = new System.Windows.Forms.TextBox();
            this.txt_SendText2 = new System.Windows.Forms.TextBox();
            this.txt_SendText1 = new System.Windows.Forms.TextBox();
            this.btn_SendAll = new System.Windows.Forms.Button();
            this.btn_SendByName = new System.Windows.Forms.Button();
            this.btn_SendByNo = new System.Windows.Forms.Button();
            this.btn_ServerStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_GetClientList = new System.Windows.Forms.Button();
            this.txt_ClientList = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.txt_ReceivedData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_ServerStop
            // 
            this.btn_ServerStop.Location = new System.Drawing.Point(240, 100);
            this.btn_ServerStop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_ServerStop.Name = "btn_ServerStop";
            this.btn_ServerStop.Size = new System.Drawing.Size(167, 34);
            this.btn_ServerStop.TabIndex = 70;
            this.btn_ServerStop.Text = "サーバー停止";
            this.btn_ServerStop.UseVisualStyleBackColor = true;
            this.btn_ServerStop.Click += new System.EventHandler(this.btn_ServerStop_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(115, 295);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown1.TabIndex = 69;
            // 
            // txt_ClientName
            // 
            this.txt_ClientName.Location = new System.Drawing.Point(115, 364);
            this.txt_ClientName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ClientName.Name = "txt_ClientName";
            this.txt_ClientName.Size = new System.Drawing.Size(81, 25);
            this.txt_ClientName.TabIndex = 68;
            this.txt_ClientName.Text = "PC1";
            // 
            // txt_SendText3
            // 
            this.txt_SendText3.Location = new System.Drawing.Point(225, 436);
            this.txt_SendText3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText3.Name = "txt_SendText3";
            this.txt_SendText3.Size = new System.Drawing.Size(272, 25);
            this.txt_SendText3.TabIndex = 67;
            this.txt_SendText3.Text = "sample_string003";
            // 
            // txt_SendText2
            // 
            this.txt_SendText2.Location = new System.Drawing.Point(225, 359);
            this.txt_SendText2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText2.Name = "txt_SendText2";
            this.txt_SendText2.Size = new System.Drawing.Size(272, 25);
            this.txt_SendText2.TabIndex = 66;
            this.txt_SendText2.Text = "sample_string002";
            // 
            // txt_SendText1
            // 
            this.txt_SendText1.Location = new System.Drawing.Point(225, 287);
            this.txt_SendText1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_SendText1.Name = "txt_SendText1";
            this.txt_SendText1.Size = new System.Drawing.Size(272, 25);
            this.txt_SendText1.TabIndex = 65;
            this.txt_SendText1.Text = "sample_string001";
            // 
            // btn_SendAll
            // 
            this.btn_SendAll.Location = new System.Drawing.Point(1, 430);
            this.btn_SendAll.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_SendAll.Name = "btn_SendAll";
            this.btn_SendAll.Size = new System.Drawing.Size(107, 34);
            this.btn_SendAll.TabIndex = 63;
            this.btn_SendAll.Text = "送信";
            this.btn_SendAll.UseVisualStyleBackColor = true;
            this.btn_SendAll.Click += new System.EventHandler(this.btn_SendAll_Click);
            // 
            // btn_SendByName
            // 
            this.btn_SendByName.Location = new System.Drawing.Point(1, 359);
            this.btn_SendByName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_SendByName.Name = "btn_SendByName";
            this.btn_SendByName.Size = new System.Drawing.Size(107, 34);
            this.btn_SendByName.TabIndex = 62;
            this.btn_SendByName.Text = "送信";
            this.btn_SendByName.UseVisualStyleBackColor = true;
            this.btn_SendByName.Click += new System.EventHandler(this.btn_SendByName_Click);
            // 
            // btn_SendByNo
            // 
            this.btn_SendByNo.Location = new System.Drawing.Point(2, 289);
            this.btn_SendByNo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_SendByNo.Name = "btn_SendByNo";
            this.btn_SendByNo.Size = new System.Drawing.Size(107, 34);
            this.btn_SendByNo.TabIndex = 64;
            this.btn_SendByNo.Text = "送信";
            this.btn_SendByNo.UseVisualStyleBackColor = true;
            this.btn_SendByNo.Click += new System.EventHandler(this.btn_SendByNo_Click);
            // 
            // btn_ServerStart
            // 
            this.btn_ServerStart.Location = new System.Drawing.Point(14, 100);
            this.btn_ServerStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_ServerStart.Name = "btn_ServerStart";
            this.btn_ServerStart.Size = new System.Drawing.Size(162, 34);
            this.btn_ServerStart.TabIndex = 61;
            this.btn_ServerStart.Text = "サーバー開始";
            this.btn_ServerStart.UseVisualStyleBackColor = true;
            this.btn_ServerStart.Click += new System.EventHandler(this.btn_ServerStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 265);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 18);
            this.label3.TabIndex = 59;
            this.label3.Text = "接続No指定で送信";
            // 
            // btn_GetClientList
            // 
            this.btn_GetClientList.Location = new System.Drawing.Point(674, 43);
            this.btn_GetClientList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_GetClientList.Name = "btn_GetClientList";
            this.btn_GetClientList.Size = new System.Drawing.Size(87, 33);
            this.btn_GetClientList.TabIndex = 72;
            this.btn_GetClientList.Text = "更新";
            this.btn_GetClientList.UseVisualStyleBackColor = true;
            this.btn_GetClientList.Click += new System.EventHandler(this.btn_GetClientList_Click);
            // 
            // txt_ClientList
            // 
            this.txt_ClientList.Location = new System.Drawing.Point(517, 100);
            this.txt_ClientList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ClientList.Multiline = true;
            this.txt_ClientList.Name = "txt_ClientList";
            this.txt_ClientList.Size = new System.Drawing.Size(326, 376);
            this.txt_ClientList.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(526, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 17);
            this.label7.TabIndex = 58;
            this.label7.Text = "接続No　Name　IP:ﾎﾟｰﾄ　状態　";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(526, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "クライアントリスト";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 408);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 18);
            this.label6.TabIndex = 56;
            this.label6.Text = "全員に送信";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 337);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Name指定で送信";
            // 
            // lbl_Info
            // 
            this.lbl_Info.Location = new System.Drawing.Point(57, 173);
            this.lbl_Info.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(317, 39);
            this.lbl_Info.TabIndex = 60;
            this.lbl_Info.Text = "Port：XXX で接続待ち";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_ReceivedData
            // 
            this.txt_ReceivedData.Location = new System.Drawing.Point(18, 502);
            this.txt_ReceivedData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txt_ReceivedData.Multiline = true;
            this.txt_ReceivedData.Name = "txt_ReceivedData";
            this.txt_ReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ReceivedData.Size = new System.Drawing.Size(825, 289);
            this.txt_ReceivedData.TabIndex = 74;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 480);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "受信Data";
            // 
            // timer_main
            // 
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 785);
            this.Controls.Add(this.txt_ReceivedData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ServerStop);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.txt_ClientName);
            this.Controls.Add(this.txt_SendText3);
            this.Controls.Add(this.txt_SendText2);
            this.Controls.Add(this.txt_SendText1);
            this.Controls.Add(this.btn_SendAll);
            this.Controls.Add(this.btn_SendByName);
            this.Controls.Add(this.btn_SendByNo);
            this.Controls.Add(this.btn_ServerStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_GetClientList);
            this.Controls.Add(this.txt_ClientList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Info);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ServerStop;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox txt_ClientName;
        private System.Windows.Forms.TextBox txt_SendText3;
        private System.Windows.Forms.TextBox txt_SendText2;
        private System.Windows.Forms.TextBox txt_SendText1;
        private System.Windows.Forms.Button btn_SendAll;
        private System.Windows.Forms.Button btn_SendByName;
        private System.Windows.Forms.Button btn_SendByNo;
        private System.Windows.Forms.Button btn_ServerStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_GetClientList;
        private System.Windows.Forms.TextBox txt_ClientList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.TextBox txt_ReceivedData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer_main;
    }
}

