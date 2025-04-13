using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace TCP_ServerTest8
{
    class TCP_Server
    {
        /* public */

        //DATAコマンド受信時のコールバック
        public delegate void RecieveDataCallback(string name, string data);
        public event RecieveDataCallback DataReceiveCB;

        //未定義コマンド受信時のコールバック
        public delegate void RecieveFreeStrCallback(string name, string str);
        public event RecieveFreeStrCallback FreeStrReceiveCB;

        //緯度経度受信時のコールバック
        public delegate void RecievelonlatCallback(string name, string str);
        public event RecievelonlatCallback TcplonlatReceiveCB;



        /* private */
        private IPAddress ipaddress;
        private int connected_number;
        private Encoding encoding;
        private TcpListener listener;
        private List<ClientData> clients;



        //プロパティ

        //ポートNo
        public int PortNo { set; get; }


        //接続を待受け中
        public bool IsListening
        {
            get
            {
                return listening_flg;
            }
        }


        //コンストラクタ
        public TCP_Server(int portno)
        {
            //ポートNo
            PortNo = portno;

            //接続No初期化
            connected_number = 0;
            //接続中のクライアントリスト作成
            clients = new List<ClientData>();


            //文字コード設定
            //UTF-8の場合
            encoding = Encoding.UTF8;
            //shift_jisの場合
            //encoding = Encoding.GetEncoding(932);//932	shift_jis


            //特にIPを定めない場合
            ipaddress = IPAddress.Any;

            //特にIPを定めない場合(古い書き方) 
            //ipaddress = System.Net.Dns.Resolve("0.0.0.0").AddressList[0];

            //127.0.0.1を待受ける場合
            //string ipString = "127.0.0.1";
            //ipaddress = System.Net.IPAddress.Parse(ipString);


            //待受け用のリスナーインスタンス作成
            listener = new TcpListener(ipaddress, portno);
        }


        //接続待ち開始
        public void ListenStart()
        {
            Debug.WriteLine($"ListenStartスレッド:{Thread.CurrentThread.ManagedThreadId}");

            //すでに待受け中の場合は開始しない
            if (IsListening)
            {
                return;
            }

            //リスナー開始
            listener.Start();

            //接続待ちタスク開始
            _ = Acceptwait_Async();
        }


        //接続待ち停止
        public void ListenStop()
        {
            listener.Stop();
        }


        //接続済みクライアントを全切断
        public void DisconnectAllClients()
        {
            //クライアント分まわし、Closeして切断
            foreach (ClientData cd in clients)
            {
                cd.client.Close();
            }

            //接続しているクライアントリストをクリア
            clients.Clear();
        }


        //文字列送信 (接続No指定)
        public void SendByNo(int no, string message)
        {
            ClientData client_data = new ClientData();
            bool flag = false;

            //番号からクライアントを探す
            foreach (ClientData cd in clients)
            {
                if (cd.no == no)
                {
                    client_data = cd;
                    flag = true;
                    break;
                }
            }

            //見付かったクライアントに対して送信
            if (flag)
            {
                Send(client_data, message);
            }
            else
            {
                //指定したクライアント番号が見つからなかった
                //throw new CanotFindClientException();
            }
        }


        //文字列送信 (クライアントName指定)
        public void SendByName(string clientname, string message)
        {
            //クライアント分まわす
            foreach (ClientData cd in clients)
            {
                if (cd.name == clientname)
                {
                    //名前が一致したクライアントに対して送信
                    Send(cd, message);
                }
            }
        }

        public void SendBySt(string clientdata, string data)
        {
            //クライアント分まわす
            foreach (ClientData cd in clients)
            {
                if (cd.name == clientdata)
                {
                    //名前が一致したクライアントに対して送信
                    Send(cd, data);
                }
            }
        }


        //文字列送信 (クライアント全員に)
        public void SendAll(string message)
        {
            //クライアント分まわす
            foreach (ClientData cd in clients)
            {
                Send(cd, message);
            }
        }


        //接続中のクライアントリストを取得
        public string GetClientList()
        {
            string lines = "";

            //クライアント分まわす
            foreach (ClientData cd in clients)
            {
                lines += cd.no + " " + cd.name + " " + cd.client.Client.RemoteEndPoint.ToString() + "\r\n";
            }
            return lines;
        }

        //接続済みクライアント数を取得
        public int GetClientCount()
        {
            return clients.Count;
        }









        /* private */

        private bool listening_flg;

        //非同期でクライアントからの接続を待ち受ける
        private async Task Acceptwait_Async()
        {
            while (true)
            {
                Debug.WriteLine($"Acceptwaitスレッド:{Thread.CurrentThread.ManagedThreadId}");

                TcpClient client;

                try
                {
                    listening_flg = true;
                    //接続待ち (非同期実行)
                    client = await listener.AcceptTcpClientAsync();
                }
                catch (System.ObjectDisposedException)
                {
                    listening_flg = false;
                    //listennerをstopさせた場合は終わらせる
                    return;
                }


                if (true)//Keepaliveを使う場合
                {
                    //Keepaliveを使う場合
                    client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                    byte[] tcp_keepalive = new byte[12];
                    BitConverter.GetBytes((Int32)1).CopyTo(tcp_keepalive, 0);//onoffスイッチ.
                    BitConverter.GetBytes((Int32)2000).CopyTo(tcp_keepalive, 4);//wait time.(ms)
                    BitConverter.GetBytes((Int32)500).CopyTo(tcp_keepalive, 8);//interval.(ms)                                                            
                                                                               // keep-aliveのパラメータ設定
                    client.Client.IOControl(IOControlCode.KeepAliveValues, tcp_keepalive, null);
                }

                //クライアントの追加
                ClientData client_data = new ClientData();
                client_data.client = client;
                client_data.no = connected_number++;
                client_data.name = "noname";//名前の初期値はnonameとする NAMEコマンド受信したら更新する
                client_data.data = "";
                clients.Add(client_data);

                //受信タスクを開始
                _ = Recievewait_Async(client, client_data);

            }
        }


        //非同期でクライアントから文字列受信を待ち受ける
        private async Task Recievewait_Async(TcpClient client, ClientData client_data)
        {
            var ns = client.GetStream();

            Debug.WriteLine("[受信待ち](接続No:{0})", client_data.no);

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
                        Debug.WriteLine("切断(接続No:{0})", client_data.no);
                        //リストから削除する
                        clients.Remove(client_data);
                        //Clientを閉じる
                        client.Close();

                        //一応メモリ破棄
                        ms.Close();
                        ms.Dispose();

                        //受信待ちをやめるため、関数を抜ける
                        Debug.WriteLine($"Receiveスレッド:{Thread.CurrentThread.ManagedThreadId}:抜ける");
                        return;
                    }

                    ms.Write(result_bytes, 0, result_size);

                } while (ns.DataAvailable);

                string message = encoding.GetString(ms.ToArray());

                //コマンド部やデータ部などの文字列操作(最終的にはForm1へコールバックしたりする)
                Received(client_data.no, client_data.name, message);

                //一応メモリ破棄
                ms.Close();
                ms.Dispose();

                //再帰的に受信タスクを開始
                //_ = Recievewait_Async(client, client_data);
                //再帰的はやめwhileの無限ループに変えた
            }
        }


        //クライアントに文字列送信
        private void Send(ClientData client_data, string message)
        {
            byte[] message_byte = encoding.GetBytes(message + "\r\n");

            TcpClient client = client_data.client;

            try
            {
                var ns = client.GetStream();
                do
                {
                    ns.Write(message_byte, 0, message_byte.Length);
                } while (ns.DataAvailable);

            }
            catch (System.InvalidOperationException)
            {
                //切断と同時に送信した場合この例外が発生する
            }

        }


        //受信した文字列を解析
        private void Received(int no, string name, string message)
        {
            Debug.WriteLine($"onRecievedスレッド:{Thread.CurrentThread.ManagedThreadId}");
            Debug.WriteLine("[受信]接続No." + no.ToString() + ":" + message);

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

                DoCommand(no, ref name, cmd, data);
                //(↑連続したコマンドのときnameが更新されるようにrefにした)

                
            }
        }


        //受信したコマンドの処理
        //コマンドを増やす場合はこのswitch文に追加
        private void DoCommand(int no, ref string name, string cmd, string data)
        {
            switch (cmd)
            {
                //クライアント名を登録
                case "NAME":
                    setClientName(no, data);
                    name = data;
                    break;
                //データ受信
                case "DATA":
                    setClientStatas(no, data);
                    DataReceiveCB(name,data);//Form1にコールバック

                    break;
                case "LONLAT":
                    string lonlat = "LONLAT"+" "+data;
                    SendAll(lonlat);
                    break;


                default:
                    FreeStrReceiveCB(name, cmd);//Form1にコールバック
                    break;
            }
        }


        //クライアントリスト内のクライアント名をセットする
        private void setClientName(int no, string clientname)
        {
            //番号からクライアントを探す
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].no == no)
                {
                    //クライアント名をセットしてclientsリストの中身を更新する
                    clients[i].name = clientname;
                    break;
                }
            }
        }

        private void setClientStatas(int no, string clientstatas)
        {
            //番号からクライアントを探す
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].no == no)
                {
                    //クライアント名をセットしてclientsリストの中身を更新する
                    clients[i].data = clientstatas;
                    break;
                }
            }
        }




        /* private */
        //ClientDataクラスの定義
        private class ClientData
        {
            public TcpClient client;//TcpClientクラス
            public int no;          //クライアント接続番号
            public string name;     //クライアント名
            public string data;     //対戦可能不可
        }

    }
}