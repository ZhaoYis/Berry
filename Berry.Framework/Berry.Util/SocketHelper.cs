using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Berry.Util
{
    public class SocketHelper
    {
        #region 推送器 加密

        public delegate void PushSocketsHandler(Sockets sockets);
        /// <summary>
        /// 推送器
        /// </summary>
        public static PushSocketsHandler PushSockets;

        /// <summary>
        /// 数据DES加密
        /// </summary>
        public class Encrypt
        {
            private byte[] iba_mIV = new byte[8];  //向量
            private byte[] iba_mKey = new byte[8]; //密钥
            private DESCryptoServiceProvider io_DES = new DESCryptoServiceProvider();

            public Encrypt()
            {
                this.iba_mKey[0] = 0x95;
                this.iba_mKey[1] = 0xc4;
                this.iba_mKey[2] = 0xf6;
                this.iba_mKey[3] = 0x49;
                this.iba_mKey[4] = 0xac;
                this.iba_mKey[5] = 0x61;
                this.iba_mKey[6] = 0xa3;
                this.iba_mKey[7] = 0xe2;
                this.iba_mIV[0] = 0xf9;
                this.iba_mIV[1] = 0x6a;
                this.iba_mIV[2] = 0x65;
                this.iba_mIV[3] = 0xb8;
                this.iba_mIV[4] = 0x4a;
                this.iba_mIV[5] = 0x23;
                this.iba_mIV[6] = 0xfe;
                this.iba_mIV[7] = 0xc6;
                this.io_DES.Key = this.iba_mKey;
                this.io_DES.IV = this.iba_mIV;
            }

            /// <summary>
            /// 初始化加密向量与密钥 长度为8
            /// </summary>
            /// <param name="iba_mIV">向量</param>
            /// <param name="iba_mKey">密钥</param>
            public Encrypt(byte[] iba_mIV, byte[] iba_mKey)
            {
                this.io_DES.IV = iba_mIV;
                this.io_DES.Key = iba_mKey;
            }

            /// <summary>
            /// 解密
            /// </summary>
            /// <param name="as_Data"></param>
            /// <returns></returns>
            public string DoDecrypt(string as_Data)
            {
                ICryptoTransform lo_ICT = this.io_DES.CreateDecryptor(this.io_DES.Key, this.io_DES.IV);
                try
                {
                    byte[] lba_bufIn = this.FromHexString(as_Data);//Encoding.UTF8.GetString(Convert.FromBase64String(
                    byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);
                    return Encoding.UTF8.GetString(lba_bufOut);
                }
                catch
                {
                    return as_Data;
                }
            }

            /// <summary>
            /// 加密
            /// </summary>
            /// <param name="as_Data"></param>
            /// <returns></returns>
            public string DoEncrypt(string as_Data)
            {
                ICryptoTransform lo_ICT = this.io_DES.CreateEncryptor(this.io_DES.Key, this.io_DES.IV);
                try
                {
                    byte[] lba_bufIn = Encoding.UTF8.GetBytes(as_Data);
                    byte[] lba_bufOut = lo_ICT.TransformFinalBlock(lba_bufIn, 0, lba_bufIn.Length);
                    return GetHexString(lba_bufOut);//Convert.ToBase64String(Encoding.UTF8.GetBytes();
                }
                catch
                {
                    return "";
                }
            }

            /// <summary>
            /// 转换2进制
            /// </summary>
            /// <param name="as_value"></param>
            /// <returns></returns>
            private byte[] FromHexString(string as_value)
            {
                byte[] lba_buf = new byte[Convert.ToInt32((int)(as_value.Length / 2))];
                for (int li_i = 0; li_i < lba_buf.Length; li_i++)
                {
                    lba_buf[li_i] = Convert.ToByte(as_value.Substring(li_i * 2, 2), 0x10);
                }
                return lba_buf;
            }

            /// <summary>
            /// 字节转字符串
            /// </summary>
            /// <param name="aba_buf"></param>
            /// <returns></returns>
            private string GetHexString(byte[] aba_buf)
            {
                StringBuilder lsb_value = new StringBuilder();
                foreach (byte lb_byte in aba_buf)
                {
                    lsb_value.Append(Convert.ToString(lb_byte, 0x10).PadLeft(2, '0'));
                }
                return lsb_value.ToString();
            }
        }

        #endregion 推送器 加密

        /// <summary>
        /// Tcp同步服务端,SocketObject继承抽象类
        /// 服务端采用TcpListener封装.
        /// 使用Semaphore 来控制并发,每次处理5个.最大处理5000
        /// </summary>
        public class TcpServer : SocketObject
        {
            private bool _isStop = false;
            private readonly object _obj = new object();

            /// <summary>
            /// 信号量
            /// </summary>
            private readonly Semaphore _semap = new Semaphore(5, 5000);

            /// <summary>
            /// 客户端队列集合
            /// </summary>
            public readonly List<Sockets> ClientList = new List<Sockets>();

            /// <summary>
            /// 服务端
            /// </summary>
            private TcpListener _listener;

            /// <summary>
            /// 当前IP地址
            /// </summary>
            private IPAddress _ipaddress;

            /// <summary>
            /// 欢迎消息
            /// </summary>
            private string boundary = "欢迎消息";

            /// <summary>
            /// 当前监听端口
            /// </summary>
            private int _port;

            /// <summary>
            /// 当前IP,端口对象
            /// </summary>
            private IPEndPoint _ip;

            /// <summary>
            /// 初始化服务端对象
            /// </summary>
            /// <param name="ipaddress">IP地址</param>
            /// <param name="port">监听端口</param>
            public override void InitSocket(IPAddress ipaddress, int port)
            {
                _ipaddress = ipaddress;
                _port = port;
                _listener = new TcpListener(_ipaddress, _port);
            }

            /// <summary>
            /// 初始化服务端对象 监听Any即所有网卡
            /// </summary>
            /// <param name="port">监听端口</param>
            public override void InitSocket(int port)
            {
                _ipaddress = IPAddress.Any;
                _port = port;
                _listener = new TcpListener(_ipaddress, _port);
            }

            /// <summary>
            /// 初始化服务端对象
            /// </summary>
            /// <param name="ipaddress">IP地址</param>
            /// <param name="port">监听端口</param>
            public override void InitSocket(string ipaddress, int port)
            {
                _ipaddress = IPAddress.Parse(ipaddress);
                _port = port;
                _ip = new IPEndPoint(_ipaddress, _port);
                _listener = new TcpListener(_ipaddress, _port);
            }

            /// <summary>
            /// 启动监听,并处理连接
            /// </summary>
            public override void Start()
            {
                try
                {
                    _listener.Start();
                    Thread accTh = new Thread(new ThreadStart(delegate
                    {
                        while (true)
                        {
                            if (_isStop != false)
                            {
                                break;
                            }
                            GetAcceptTcpClient();
                            Thread.Sleep(1);
                        }
                    }));
                    accTh.Start();
                }
                catch (SocketException skex)
                {
                    Sockets sks = new Sockets
                    {
                        Ex = skex
                    };
                    PushSockets.Invoke(sks);//推送至UI
                }
            }

            /// <summary>
            /// 等待处理新的连接
            /// </summary>
            private void GetAcceptTcpClient()
            {
                try
                {
                    _semap.WaitOne();
                    TcpClient tclient = _listener.AcceptTcpClient();
                    //维护客户端队列
                    Socket socket = tclient.Client;
                    NetworkStream stream = new NetworkStream(socket, true); //承载这个Socket
                    Sockets sks = new Sockets(tclient.Client.RemoteEndPoint as IPEndPoint, tclient, stream);
                    sks.NewClientFlag = true;
                    //加入客户端集合.
                    AddClientList(sks);
                    //推送新客户端
                    PushSockets.Invoke(sks);
                    //客户端异步接收
                    sks.NetworkStream.BeginRead(sks.RecBuffer, 0, sks.RecBuffer.Length, new AsyncCallback(EndReader), sks);
                    //主动向客户端发送一条连接成功信息
                    if (stream.CanWrite)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(boundary);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    _semap.Release();
                }
                catch (Exception exs)
                {
                    _semap.Release();
                    Sockets sk = new Sockets
                    {
                        ClientDispose = true,
                        Ex = new Exception(exs.ToString() + "新连接监听出现异常")
                    };
                    //客户端退出
                    if (PushSockets != null)
                    {
                        PushSockets.Invoke(sk);//推送至UI
                    }
                }
            }

            /// <summary>
            /// 异步接收发送的信息.
            /// </summary>
            /// <param name="ir"></param>
            private void EndReader(IAsyncResult ir)
            {
                Sockets sks = ir.AsyncState as Sockets;
                if (sks != null && _listener != null)
                {
                    try
                    {
                        if (sks.NewClientFlag || sks.Offset != 0)
                        {
                            sks.NewClientFlag = false;
                            sks.Offset = sks.NetworkStream.EndRead(ir);
                            PushSockets.Invoke(sks);//推送至UI
                            sks.NetworkStream.BeginRead(sks.RecBuffer, 0, sks.RecBuffer.Length, new AsyncCallback(EndReader), sks);
                        }
                    }
                    catch (Exception skex)
                    {
                        lock (_obj)
                        {
                            //移除异常类
                            ClientList.Remove(sks);
                            Sockets sk = sks;
                            sk.ClientDispose = true;//客户端退出
                            sk.Ex = skex;
                            PushSockets.Invoke(sks);//推送至UI
                        }
                    }
                }
            }

            /// <summary>
            /// 加入队列.
            /// </summary>
            /// <param name="sk"></param>
            private void AddClientList(Sockets sk)
            {
                Sockets sockets = ClientList.Find(o => Equals(o.Ip, sk.Ip));
                //如果不存在则添加,否则更新
                if (sockets == null)
                {
                    ClientList.Add(sk);
                }
                else
                {
                    ClientList.Remove(sockets);
                    ClientList.Add(sk);
                }
            }

            public override void Stop()
            {
                if (_listener != null)
                {
                    SendToAll("ServerOff");
                    _listener.Stop();
                    _listener = null;
                    _isStop = true;
                    PushSockets = null;
                }
            }

            /// <summary>
            /// 向所有在线的客户端发送信息.
            /// </summary>
            /// <param name="sendData">发送的文本</param>
            public void SendToAll(string sendData)
            {
                foreach (Sockets socket in ClientList)
                {
                    SendToClient(socket.Ip, sendData);
                }
            }

            /// <summary>
            /// 向所有在线的客户端发送信息.
            /// </summary>
            /// <param name="sendDataBuffer">发送的文本</param>
            public void SendToAll(byte[] sendDataBuffer)
            {
                for (int i = 0; i < ClientList.Count; i++)
                {
                    SendToClient(ClientList[i].Ip, sendDataBuffer);
                }
            }

            /// <summary>
            /// 向某一位客户端发送信息
            /// </summary>
            /// <param name="ip">客户端IP+端口地址</param>
            /// <param name="sendDataBuffer">发送的数据包</param>
            public void SendToClient(IPEndPoint ip, byte[] sendDataBuffer)
            {
                try
                {
                    Sockets sks = ClientList.Find(o => Equals(o.Ip, ip));
                    if (sks != null)
                    {
                        if (sks.Client.Connected)
                        {
                            //获取当前流进行写入.
                            NetworkStream nStream = sks.NetworkStream;
                            if (nStream.CanWrite)
                            {
                                byte[] buffer = sendDataBuffer;
                                nStream.Write(buffer, 0, buffer.Length);
                            }
                            else
                            {
                                //避免流被关闭,重新从对象中获取流
                                nStream = sks.Client.GetStream();
                                if (nStream.CanWrite)
                                {
                                    byte[] buffer = sendDataBuffer;
                                    nStream.Write(buffer, 0, buffer.Length);
                                }
                                else
                                {
                                    //如果还是无法写入,那么认为客户端中断连接.
                                    ClientList.Remove(sks);
                                }
                            }
                        }
                        else
                        {
                            //没有连接时,标识退出
                            sks.ClientDispose = true;//如果出现异常,标识客户端下线
                            sks.Ex = new Exception("客户端无连接");
                            PushSockets.Invoke(sks);//推送至UI
                        }
                    }
                }
                catch (Exception skex)
                {
                    Sockets sks = new Sockets
                    {
                        ClientDispose = true,
                        Ex = skex
                    };
                    //如果出现异常,标识客户端退出
                    PushSockets.Invoke(sks);//推送至UI
                }
            }

            /// <summary>
            /// 向某一位客户端发送信息
            /// </summary>
            /// <param name="ip">客户端IP+端口地址</param>
            /// <param name="sendData">发送的数据包</param>
            public void SendToClient(IPEndPoint ip, string sendData)
            {
                try
                {
                    Sockets sks = ClientList.Find(o => Equals(o.Ip, ip));
                    if (sks != null)
                    {
                        if (sks.Client.Connected)
                        {
                            //获取当前流进行写入.
                            NetworkStream nStream = sks.NetworkStream;
                            if (nStream.CanWrite)
                            {
                                byte[] buffer = Encoding.UTF8.GetBytes(sendData);
                                nStream.Write(buffer, 0, buffer.Length);
                            }
                            else
                            {
                                //避免流被关闭,重新从对象中获取流
                                nStream = sks.Client.GetStream();
                                if (nStream.CanWrite)
                                {
                                    byte[] buffer = Encoding.UTF8.GetBytes(sendData);
                                    nStream.Write(buffer, 0, buffer.Length);
                                }
                                else
                                {
                                    //如果还是无法写入,那么认为客户端中断连接.
                                    ClientList.Remove(sks);
                                }
                            }
                        }
                        else
                        {
                            //没有连接时,标识退出
                            //Sockets ks = new Sockets();
                            sks.ClientDispose = true;//如果出现异常,标识客户端下线
                            sks.Ex = new Exception("客户端无连接");
                            PushSockets.Invoke(sks);//推送至UI
                        }
                    }
                }
                catch (Exception skex)
                {
                    Sockets sks = new Sockets
                    {
                        ClientDispose = true,
                        Ex = skex
                    };
                    //如果出现异常,标识客户端退出
                    if (PushSockets != null)
                    {
                        PushSockets.Invoke(sks);//推送至UI
                    }
                }
            }
        }

        public class TcpClients : SocketObject
        {
            /// <summary>
            /// 是否关闭.(窗体关闭时关闭代码)
            /// </summary>
            private bool _isClose = false;

            /// <summary>
            /// 当前管理对象
            /// </summary>
            private Sockets _sk;

            /// <summary>
            /// 客户端
            /// </summary>
            public TcpClient TcpClient;

            /// <summary>
            /// 当前连接服务端地址
            /// </summary>
            private IPAddress _ipaddress;

            /// <summary>
            /// 当前连接服务端端口号
            /// </summary>
            private int _port;

            /// <summary>
            /// 服务端IP+端口
            /// </summary>
            private IPEndPoint _ip;

            /// <summary>
            /// 发送与接收使用的流
            /// </summary>
            private NetworkStream _networkStream;

            /// <summary>
            /// 初始化Socket
            /// </summary>
            /// <param name="ipaddress"></param>
            /// <param name="port"></param>
            public override void InitSocket(string ipaddress, int port)
            {
                _ipaddress = IPAddress.Parse(ipaddress);
                _port = port;
                _ip = new IPEndPoint(_ipaddress, _port);
                TcpClient = new TcpClient();
            }

            public override void InitSocket(int port)
            {
                _port = port;
            }

            /// <summary>
            /// 初始化Socket
            /// </summary>
            /// <param name="ipaddress"></param>
            /// <param name="port"></param>
            public override void InitSocket(IPAddress ipaddress, int port)
            {
                _ipaddress = ipaddress;
                _port = port;
                _ip = new IPEndPoint(_ipaddress, _port);
                TcpClient = new TcpClient();
            }

            /// <summary>
            /// 重连上端.
            /// </summary>
            private void RestartInit()
            {
                InitSocket(_ipaddress, _port);
                Connect();
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="sendData"></param>
            public void SendData(string sendData)
            {
                try
                {
                    //如果连接则发送
                    if (TcpClient != null)
                    {
                        if (TcpClient.Connected)
                        {
                            if (_networkStream == null)
                            {
                                _networkStream = TcpClient.GetStream();
                            }
                            byte[] buffer = Encoding.UTF8.GetBytes(sendData);
                            _networkStream.Write(buffer, 0, buffer.Length);
                        }
                        else
                        {
                            Sockets sks = new Sockets
                            {
                                ErrorCode = Sockets.ErrorCodes.TrySendData,
                                Ex = new Exception("客户端发送时无连接,开始进行重连上端.."),
                                ClientDispose = true
                            };
                            PushSockets.Invoke(sks);//推送至UI
                            RestartInit();
                        }
                    }
                    else
                    {
                        Sockets sks = new Sockets
                        {
                            ErrorCode = Sockets.ErrorCodes.TrySendData,
                            Ex = new Exception("客户端对象为null,开始重连上端.."),
                            ClientDispose = true
                        };
                        PushSockets.Invoke(sks);//推送至UI
                        RestartInit();
                    }
                }
                catch (Exception skex)
                {
                    Sockets sks = new Sockets
                    {
                        ErrorCode = Sockets.ErrorCodes.TrySendData,
                        Ex = new Exception("客户端出现异常,开始重连上端..异常信息:" + skex.Message),
                        ClientDispose = true
                    };
                    PushSockets.Invoke(sks);//推送至UI
                    RestartInit();
                }
            }

            /// <summary>
            /// 发送消息
            /// </summary>
            /// <param name="sendData"></param>
            public void SendData(byte[] sendData)
            {
                try
                {
                    //如果连接则发送
                    if (TcpClient != null)
                    {
                        if (TcpClient.Connected)
                        {
                            if (_networkStream == null)
                            {
                                _networkStream = TcpClient.GetStream();
                            }
                            byte[] buffer = sendData;
                            _networkStream.Write(buffer, 0, buffer.Length);
                        }
                        else
                        {
                            Sockets sks = new Sockets
                            {
                                ErrorCode = Sockets.ErrorCodes.TrySendData,
                                Ex = new Exception("客户端发送时无连接,开始进行重连上端.."),
                                ClientDispose = true
                            };
                            PushSockets.Invoke(sks);//推送至UI
                            RestartInit();
                        }
                    }
                    else
                    {
                        Sockets sks = new Sockets
                        {
                            ErrorCode = Sockets.ErrorCodes.TrySendData,
                            Ex = new Exception("客户端无连接.."),
                            ClientDispose = true
                        };
                        PushSockets.Invoke(sks);//推送至UI
                    }
                }
                catch (Exception skex)
                {
                    Sockets sks = new Sockets
                    {
                        ErrorCode = Sockets.ErrorCodes.TrySendData,
                        Ex = new Exception("客户端出现异常,开始重连上端..异常信息:" + skex.Message),
                        ClientDispose = true
                    };
                    PushSockets.Invoke(sks);//推送至UI
                    RestartInit();
                }
            }

            private void Connect()
            {
                try
                {
                    TcpClient.Connect(_ip);
                    _networkStream = new NetworkStream(TcpClient.Client, true);
                    _sk = new Sockets(_ip, TcpClient, _networkStream);
                    _sk.NetworkStream.BeginRead(_sk.RecBuffer, 0, _sk.RecBuffer.Length, new AsyncCallback(EndReader), _sk);
                    //推送连接成功.
                    Sockets sks = new Sockets
                    {
                        ErrorCode = Sockets.ErrorCodes.ConnectSuccess,
                        Ex = new Exception("客户端连接成功."),
                        ClientDispose = false
                    };
                    PushSockets.Invoke(sks);
                }
                catch (Exception skex)
                {
                    Sockets sks = new Sockets
                    {
                        ErrorCode = Sockets.ErrorCodes.ConnectError,
                        Ex = new Exception("客户端连接失败..异常信息:" + skex.Message),
                        ClientDispose = true
                    };
                    PushSockets.Invoke(sks);
                }
            }

            private void EndReader(IAsyncResult ir)
            {
                Sockets s = ir.AsyncState as Sockets;
                try
                {
                    if (s != null)
                    {
                        if (_isClose && TcpClient == null)
                        {
                            _sk.NetworkStream.Close();
                            _sk.NetworkStream.Dispose();
                            return;
                        }
                        s.Offset = s.NetworkStream.EndRead(ir);
                        PushSockets.Invoke(s);//推送至UI
                        _sk.NetworkStream.BeginRead(_sk.RecBuffer, 0, _sk.RecBuffer.Length, new AsyncCallback(EndReader), _sk);
                    }
                }
                catch (Exception skex)
                {
                    Sockets sks = s;
                    if (sks != null)
                    {
                        sks.Ex = skex;
                        sks.ClientDispose = true;
                        PushSockets.Invoke(sks); //推送至UI
                    }
                }
            }

            /// <summary>
            /// 重写Start方法,连接服务端
            /// </summary>
            public override void Start()
            {
                Connect();
            }

            public override void Stop()
            {
                Sockets sks = new Sockets();
                if (TcpClient != null)
                {
                    TcpClient.Client.Shutdown(SocketShutdown.Both);
                    Thread.Sleep(10);
                    TcpClient.Close();
                    _isClose = true;
                    TcpClient = null;
                }
                else
                {
                    sks.Ex = new Exception("客户端没有初始化.!");
                }
                sks.Ex = new Exception("客户端与上端断开连接..");
                PushSockets.Invoke(sks);//推送至UI
            }
        }

        /// <summary>
        /// Socket基类(抽象类)
        /// 抽象3个方法,初始化Socket(含一个构造),停止,启动方法.
        /// 此抽象类为TcpServer与TcpClient的基类,前者实现后者抽象方法.
        /// 对象基类
        /// </summary>
        public abstract class SocketObject
        {
            public abstract void InitSocket(IPAddress ipaddress, int port);

            public abstract void InitSocket(string ipaddress, int port);

            public abstract void InitSocket(int port);

            public abstract void Start();

            public abstract void Stop();
        }

        /// <summary>
        /// 自定义Socket对象
        /// </summary>
        public class Sockets
        {
            /// <summary>
            /// 接收缓冲区
            /// </summary>
            public readonly byte[] RecBuffer = new byte[1024];

            /// <summary>
            /// 发送缓冲区
            /// </summary>
            public readonly byte[] SendBuffer = new byte[1024];

            /// <summary>
            /// 异步接收后包的大小
            /// </summary>
            public int Offset { get; set; }

            /// <summary>
            /// 空构造
            /// </summary>
            public Sockets() { }

            /// <summary>
            /// 创建Sockets对象
            /// </summary>
            /// <param name="ip">Ip地址</param>
            /// <param name="client">TcpClient</param>
            /// <param name="ns">承载客户端Socket的网络流</param>
            public Sockets(IPEndPoint ip, TcpClient client, NetworkStream ns)
            {
                Ip = ip;
                Client = client;
                NetworkStream = ns;
            }

            /// <summary>
            /// 当前IP地址,端口号
            /// </summary>
            public IPEndPoint Ip { get; private set; }

            /// <summary>
            /// 客户端主通信程序
            /// </summary>
            public TcpClient Client { get; private set; }

            /// <summary>
            /// 承载客户端Socket的网络流
            /// </summary>
            public NetworkStream NetworkStream { get; private set; }

            /// <summary>
            /// 发生异常时不为null.
            /// </summary>
            public Exception Ex { get; set; }

            /// <summary>
            /// 异常枚举
            /// </summary>
            public ErrorCodes ErrorCode { get; set; }

            /// <summary>
            /// 新客户端标识.如果推送器发现此标识为true,那么认为是客户端上线
            /// 仅服务端有效
            /// </summary>
            public bool NewClientFlag { get; set; }

            /// <summary>
            /// 客户端退出标识.如果服务端发现此标识为true,那么认为客户端下线
            /// 客户端接收此标识时,认为客户端异常.
            /// </summary>
            public bool ClientDispose { get; set; }

            /// <summary>
            /// 具体错误类型
            /// </summary>
            public enum ErrorCodes
            {
                /// <summary>
                /// 对象为null
                /// </summary>
                ObjectNull,

                /// <summary>
                /// 连接时发生错误
                /// </summary>
                ConnectError,

                /// <summary>
                /// 连接成功.
                /// </summary>
                ConnectSuccess,

                /// <summary>
                /// 尝试发送失败异常
                /// </summary>
                TrySendData
            }
        }
    }
}