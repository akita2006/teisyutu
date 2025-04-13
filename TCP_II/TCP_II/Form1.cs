using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP_ServerTest8;

namespace TCP_II
{
    public partial class Form1 : Form
    {

        //サーバークラス変数
        private TCP_Server tserver;


        //コンストラクタ
        public Form1()
        {
            InitializeComponent();

            //サーバー用待受けポートを指定し サーバークラスのインスタンス作成
            int port = 60001;
            tserver = new TCP_Server(port);

            //受信時にコールバックさせる関数設定
            tserver.DataReceiveCB += TcpDataReceived;        //DATAコマンド受信時
            tserver.FreeStrReceiveCB += TcpFreeStrReceived;  //未定義コマンド受信時
            tserver.TcplonlatReceiveCB -= TcplonlatReceived;  //緯度経度受信

            //接続待ち開始
            ListenStart();

            //メインループタイマー開始
            timer_main.Enabled = true;
        }


        //サーバー開始ボタン
        private void btn_ServerStart_Click(object sender, EventArgs e)
        {
            //待受け開始
            ListenStart();
        }
        //待受け開始
        private void ListenStart()
        {
            //接続待ち開始
            tserver.ListenStart();
        }


        //サーバー停止ボタン
        private void btn_ServerStop_Click(object sender, EventArgs e)
        {
            //待受け停止
            ListenStop();

            //接続済みクライアントを全切断
            tserver.DisconnectAllClients();
        }
        //待受け停止
        private void ListenStop()
        {
            //接続待ち停止
            tserver.ListenStop();
        }


        //送信ボタン (クライアント接続Noで指定)
        private void btn_SendByNo_Click(object sender, EventArgs e)
        {
            int no = (int)numericUpDown1.Value;
            tserver.SendByNo(no, txt_SendText1.Text);
        }


        //送信ボタン (クライアントNameで指定)
        private void btn_SendByName_Click(object sender, EventArgs e)
        {
            tserver.SendByName(txt_ClientName.Text, txt_SendText2.Text);
        }


        //送信ボタン (クライアント全員に送信)
        private void btn_SendAll_Click(object sender, EventArgs e)
        {
            tserver.SendAll(txt_SendText3.Text);
        }


        //更新ボタン 接続しているクライアントを取得
        private void btn_GetClientList_Click(object sender, EventArgs e)
        {
            txt_ClientList.Text = tserver.GetClientList();
        }



        //クライアントからDATAコマンド受信時の処理
        private void TcpDataReceived(string name, string situation)
        {
            string rdata = name + ":" + situation + "\r\n";
            txt_ReceivedData.Text += rdata;
            tserver.SendAll(rdata);
            

        }


        //クライアントからコマンドフォーマットにない文字列を受信時の処理
        private void TcpFreeStrReceived(string name, string str)
        {
            string rdata = name + ":" + str + "\r\n";
            tserver.SendAll(rdata);
            txt_ReceivedData.Text += rdata;

        }

        private void TcplonlatReceived(string name, string str)
        {
            string lon_lat = name + ":" + str + "\r\n";
            tserver.SendAll(lon_lat);
            txt_ReceivedData.Text += lon_lat;

        }


        //メインループ
        private void timer_main_Tick(object sender, EventArgs e)
        {
            //サーバー待受け状態表示
            ServerListeningStatus = tserver.IsListening;

            //接続クライアントを取得しテキストボックスに表示
            txt_ClientList.Text = tserver.GetClientList();

            //
            //ここに処理を記述する
            //
            //例えば、状態遷移Noの変数を用意して
            //番号によってSwitch文で処理を切り分けたりすると良いと思われ
            //
            //ただし時間のかかる処理は非同期でさせるべき
            //
        }



        //プロパティ

        //サーバー待受け状態
        private bool ServerListeningStatus
        {
            set
            {
                if (value)
                {
                    lbl_Info.Text = "サーバー Port: " + tserver.PortNo.ToString() + " で待受け中";
                    lbl_Info.BackColor = Color.Lime;
                }
                else
                {
                    lbl_Info.Text = "サーバー接続停止中";
                    lbl_Info.BackColor = Color.DarkGray;
                }
            }
            get
            {
                return tserver.IsListening;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
