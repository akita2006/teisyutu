using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location; // ここで System.Device.dll が必要
using TCP_C;

namespace TCP_ClientTest8
{
    public partial class Form1 : Form
    {
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
       
        //クライアントクラス変数
        private TCP_Client tclient;


        public Form1()
        {
            InitializeComponent();

            this.watcher.PositionChanged += Watcher_PositionChanged;
            this.watcher.Stop();
            bool started = this.watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
            if (!started)
                MessageBox.Show("失敗しました");

            //クライアントクラスのインスタンス作成
            tclient = new TCP_Client();

            //受信時にコールバックさせる関数設定
            tclient.DataReceiveCB += TcpDataReceived;         //DATAコマンド受信時
            tclient.Cmd1RecieveCB += TcpCmd1Received;         //CMD1コマンド受信時
            tclient.FreeStrReceiveCB += TcpFreeStrReceived;   //未定義コマンド受信時
            tclient.LonLatReceiveCB += TcpLonlatReceived;
        }

        //位置情報の取得メソッド
        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            double latitude = watcher.Position.Location.Latitude;
            // e.Position.Location.Latitudeを調べてもよい

            double longitude = watcher.Position.Location.Longitude;

            // 一度取得してしまえばPCの場合変更しないので何度もこのハンドラが呼び出されないように止める
            this.watcher.Stop();

            Invoke((Action)(() => {
                txt_SendText4.Text = $"LONLAT {latitude}+{longitude}";

            }));
        }



        //接続ボタン
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            string svrip = txt_ServerIP.Text;
            tclient.Connect(svrip, 60001);
        }

        //切断ボタン
        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            tclient.Disconnect();
        }

        //送信ボタン1
        private void btn_Send1_Click(object sender, EventArgs e)
        {           
            tclient.Send(txt_SendText1.Text);
        }

        //送信ボタン2
        private void btn_Send2_Click(object sender, EventArgs e)
        {           
            tclient.DataSend("DATA "+comboBox1.Text);
        }

        //送信ボタン3
        private void btn_Send3_Click(object sender, EventArgs e)
        {
            tclient.Send(txt_SendText3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            tclient.Send(txt_SendText4.Text);
        }

        //DATAコマンド受信時の処理
        private void TcpDataReceived(string str)
        {
            txt_ReceivedData.Text += str + "\r\n";
        }

        //CMD1コマンド受信時の処理
        private void TcpCmd1Received(string str)
        {
            txt_ReceivedData.Text += str + "\r\n";
        }

        //LONLAT
        private void TcpLonlatReceived(string str)
        {
            DialogResult result = MessageBox.Show("位置情報を受信しました。表示しますか？", txt_SendText1.Text+"からの挑戦状"
                                                    , MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (result==DialogResult.Yes)
            {
                string[] lonlat= str.Split('+');
                int zoom = 19; // 大きな値にすると拡大される
                string url = $"https://www.bing.com/maps/embed?lvl={zoom}&w=600&h=600&cp={lonlat[0]}~{lonlat[1]}";
                System.Diagnostics.Process.Start(url);
                txt_ReceivedData.Text += txt_SendText1.Text+ "決闘！" + "\r\n";
            }
            else
            {                
                return;
            }
           
        }

        //未定義コマンド受信時の処理
        private void TcpFreeStrReceived(string str)
        {
            string rdata = str + "\r\n";
            txt_ReceivedData.Text += rdata;
        }


        //メインループ (タイマーで周期的に呼び出される)
        private void tmr_Main_Tick(object sender, EventArgs e)
        {
            //接続状態表示
            ConnectedStatus = tclient.IsConnected;

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

        //サーバー接続状態
        private bool ConnectedStatus
        {
            set
            {
                if (value)
                    lbl_ConnectedStatus.BackColor = Color.Lime;
                else
                    lbl_ConnectedStatus.BackColor = Color.DarkGray;
            }
            get
            {
                return tclient.IsConnected;
            }

        }

       
    }
}