using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TCP_C
{
    class TCP_Client
    {
        /* public */

        //接続完了時のコールバック
        //public delegate void ConnectOKCallback();
        //public event ConnectOKCallback ConnectOkCB;

        //接続失敗時のコールバック
        //public delegate void ConnectNGCallback();
        //public event ConnectNGCallback ConnectNgCB;

        //切断時のコールバック
        //public delegate void DisconnectedCallback();
        //public event DisconnectedCallback DisconnectedCB;


        //DATAコマンド受信時のコールバック
        public delegate void RecieveDATACallback(string data);
        public event RecieveDATACallback DataReceiveCB;

        //CMD1コマンド受信時のコールバック
        public delegate void RecieveCMD1Callback(string data);
        public event RecieveCMD1Callback Cmd1RecieveCB;

        //未定義コマンド受信時のコールバック
        public delegate void RecieveFreeStrCallback(string data);
        public event RecieveFreeStrCallback FreeStrReceiveCB;

        public delegate void RecieveLonlatCallback(string data);
        public event RecieveFreeStrCallback LonLatReceiveCB;



        /* private */
        private TcpClient client;
        private Encoding encoding;




        /* public */

        //コンストラクタ
        public TCP_Client()
        {
            client = new TcpClient();//インスタンスを作成

            //encoding = Encoding.GetEncoding(932);//932	shift_jis

            encoding = Encoding.UTF8;

        }


        public void Connect(string svrip, int port)
        {
            //非同期で接続開始
            _ = ConnectStartAsync(svrip, port);
        }


        //切断
        public void Disconnect()
        {
            //接続処理中は抜ける
            if (connecting_flg)
                return;

            //切断処理
            client.Close();
            //client.Dispose();
        }


        //送信
        public void Send(string message)
        {
            if (this.IsConnected == false)
                return;

            var ns = client.GetStream();
            byte[] message_byte = encoding.GetBytes(message + "\r\n");

            do
            {
                ns.Write(message_byte, 0, message_byte.Length);
            } while (ns.DataAvailable);

        }

        public void DataSend(string data)
        {
            if (this.IsConnected == false)
                return;

            var ns = client.GetStream();
            byte[] data_byte = encoding.GetBytes(data + "\r\n");

            do
            {
                ns.Write(data_byte, 0, data_byte.Length);
            } while (ns.DataAvailable);

        }




        //プロパティ

        //接続完了したかどうか
        public bool IsConnected
        {
            get
            {
                bool b = false;

                if (client != null && client.Client != null)
                    b = client.Connected;
                return b;
            }
        }



        /* private */

        private bool connecting_flg; //接続処理中フラグ

        //接続開始
        private async Task ConnectStartAsync(string ip, int port)
        {

            if (client != null && client.Client != null && client.Connected)
            {
                //すでに接続してたら 再接続させない
                return;
            }
            if (connecting_flg)
            {
                //すでに接続処理中なら接続処理させない
                return;
            }

            Debug.WriteLine($"Connectスレッド:{Thread.CurrentThread.ManagedThreadId}");


            //TcpClientのインスタンスを作成
            client = new TcpClient();

            //Keepaliveを使う場合
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            byte[] tcp_keepalive = new byte[12];
            BitConverter.GetBytes((Int32)1).CopyTo(tcp_keepalive, 0);//onoffスイッチ.
            BitConverter.GetBytes((Int32)2000).CopyTo(tcp_keepalive, 4);//wait time.(ms)
            BitConverter.GetBytes((Int32)500).CopyTo(tcp_keepalive, 8);//interval.(ms)
                                                                       // keep-aliveのパラメータ設定
            client.Client.IOControl(IOControlCode.KeepAliveValues, tcp_keepalive, null);


            //接続開始
            try
            {
                connecting_flg = true;//接続処理中フラグ ON
                //接続 (非同期実行)
                await client.ConnectAsync(ip, port);
            }
            catch (System.Net.Sockets.SocketException)
            {
                //接続失敗 (失敗すると この例外が発生する)
                connecting_flg = false;//接続処理中フラグ OFF
                client.Close();
                //ConnectNgCB();//Form1にコールバック
                return;
            }
            catch
            {
                //ごくまれにSystem.NullReferenceExceptionなど起きる
                connecting_flg = false;//接続処理中フラグ OFF
                client.Close();
                //ConnectNgCB();//Form1にコールバック
                return;
            }

            //接続成功
            connecting_flg = false;//接続処理中フラグ OFF
            //受信タスクを開始
            _ = Recievewait_Async();

        }


        //非同期でクライアントから文字列受信を待ち受ける
        private async Task Recievewait_Async()
        {
            var ns = client.GetStream();

            Debug.WriteLine("[受信待ち]");

            while (true)
            {
                var ms = new MemoryStream();
                byte[] result_bytes = new byte[16];

                Debug.WriteLine($"Receiveスレッド:{Thread.CurrentThread.ManagedThreadId}");

                do
                {
                    int result_size = 0;

                    try
                    {
                        //受信 (非同期実行)
                        result_size = await ns.ReadAsync(result_bytes, 0, result_bytes.Length);
                    }
                    catch (System.IO.IOException)
                    {
                        //LANケーブルが抜けたときKeepaliveによってこの例外が発生する
                    }

                    if (result_size == 0)
                    {
                        //受信サイズが0のとき切断とみなし クライアントの削除
                        Debug.WriteLine("[切断]");
                        //Clientを閉じる
                        client.Close();

                        //一応メモリ破棄
                        ms.Close();
                        ms.Dispose();

                        //受信待ちをやめるため、関数を抜ける
                        return;
                    }

                    ms.Write(result_bytes, 0, result_size);

                } while (ns.DataAvailable);

                string message = encoding.GetString(ms.ToArray());

                Received(message);

                //一応メモリ破棄
                ms.Close();
                ms.Dispose();

                //再帰的に受信タスクを開始
                //_ = Recievewait_Async();
                //再帰的はやめwhileの無限ループに変えた
            }
        }


        //受信した文字列処理
        //      複数のコマンドがくっついている可能性があるので改行で分解する
        //      コマンド部とデータ部に分解する (スペースで区切られた)
        private void Received(string message)
        {
            Debug.WriteLine($"onRecievedスレッド:{Thread.CurrentThread.ManagedThreadId}");
            Debug.WriteLine("[受信]" + message);

            //受信文字列を\nで分割 (<0A>)
            string[] lines = message.Split('\n');

            foreach (string line in lines)
            {
                string cmd;
                string data = "";

                //前後の空白文字を削除
                string trimline = line.Trim();
                if (trimline.Length == 0)
                {
                    continue;//文字列がなかったら次の行実行
                }
                //コマンドとデータに分ける
                string[] cmddata = trimline.Split(' ');//スペースでコマンド部とデータ部分割 

                cmd = cmddata[0];    //コマンド部

                if (cmddata.Length > 1)//データ部があるとき
                {
                    data = cmddata[1];   //データ部  (注)データ部にスペースがあったら先頭部分以外は削られる
                }

                DoCommand(cmd, data);
                //(↑連続したコマンドのときnameが更新されるようにrefにした)
            }
        }


        //受信したコマンドの処理
        //コマンドを増やす場合はこのswitch文に追加
        private void DoCommand(string cmd, string data)
        {
            switch (cmd)
            {

                //データ受信
                case "DATA":
                    DataReceiveCB(data);//Form1にコールバック
                    break;

                //コマンド1受信
                case "CMD1":
                    Cmd1RecieveCB(data);//Form1にコールバック
                    break;

                case "LONLAT":
                    LonLatReceiveCB(data);
                    break;

                //未定義コマンド
                default:
                    FreeStrReceiveCB(cmd);//Form1にコールバック
                    break;
            }
        }
    }
}