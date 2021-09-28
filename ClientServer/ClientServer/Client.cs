using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ClientProject
{
    public class Client
    {
        public string ipAddr;
        public int port;
        public IPEndPoint iPEndPoint;
        public Socket socket;
        public StringBuilder command;
        
        string[] arr = new string[3] { $@"C:\Program Files\Opera\launcher.exe", $@"C:\Program Files\Mozilla Firefox\firefox.exe", $@"C:\Program Files\Google\Chrome\Application\chrome.exe" };
        public Client()
        {
            this.ipAddr = "127.0.0.1";
            this.port = 8000;
            this.iPEndPoint = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public Client(Socket socket)
        {
            this.socket = socket;
        }

        public void Connect()
        {
            socket.Connect(iPEndPoint);
        }
        public void SendMsg(string sms)
        {
            byte[] data = new byte[256];
            data = Encoding.Unicode.GetBytes(sms);
            socket.Send(data);
        }
        public StringBuilder GetMsg()
        {
            int bytes = 0;
            byte[] data = new byte[256];
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                bytes = socket.Receive(data);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socket.Available > 0);

            return stringBuilder;
        }

        public void Menu(string num,string path,Socket socket)
        {
            Process myProcess=null;
            switch(num)
            {
                case "1":
                    if(path.Contains("1")||path.Contains("2")||path.Contains("3"))
                    {
                        int choice = Convert.ToInt32(path);
                        myProcess=Process.Start(arr[--choice]);
                        myProcess.Kill();
                        
                    }
                    
                    break;
                case "2":
                    if (path.Contains("1") || path.Contains("2") || path.Contains("3"))
                    {
                        int choice = Convert.ToInt32(path);
                        
                        socket.Disconnect(true);
                    }
                    break;
            }
        }
        public void ServerConnect(StringBuilder str)
        {
            if(str.ToString().Contains("Start"))
            {
                if(str.ToString().Contains("Opera"))
                {
                    Process.Start($@"C:\Program Files\Opera\launcher.exe" );

                }
                if (str.ToString().Contains("Firefox"))
                {
                   Process.Start($@"C:\Program Files\Mozilla Firefox\firefox.exe" );
                }
                if (str.ToString().Contains("Google"))
                {
                    Process.Start($@"C:\Program Files\Google\Chrome\Application\chrome.exe");
                }
            }
        }
    }
}