using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using ClientProject;
using System.IO;

namespace ServerProject
{
    class Server
    {

        private string ipAddr;
        private int port;
        private IPEndPoint ipPoint;
        public Socket socket;
        public Socket socketclient;
        public List<Client> clients;
        int id=0;
       

        public Server()
        {
            this.ipAddr = "127.0.0.1";
            this.port = 8000;
            this.ipPoint = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.clients = new List<Client>();
            

        }
        public void StartServer()
        {
            try
            {

                this.socket.Bind(ipPoint);
                this.socket.Listen(10);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public void ConnectOne()
        {
            bool check = true;
            while (check)
            {
                this.socketclient = this.socket.Accept();
                clients.Add(new Client(socketclient));
                if (clients.Count > 0)
                {
                    check = false;
                }
            }

        }
        public void Connects()
        {
            while (true)
            {
                this.socketclient = this.socket.Accept();
                clients.Add(new Client(socketclient));

            }

        }
        public StringBuilder GetMsg()
        {

            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            byte[] data = new byte[256];
            foreach (var item in clients)
            {
                do
                {

                    bytes = item.socket.Receive(data);

                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (item.socket.Available > 0);
            }

            return builder;
        }
        public void SendMsg(string message)
        {
            byte[] data = new byte[256];
            foreach (var item in clients)
            {
                if (File.Exists(message) && Path.GetFileName(message).Contains(".txt") || Path.GetFileName(message).Contains(".rtf"))
                {
                    item.socket.Send(Encoding.Unicode.GetBytes(File.ReadAllText(message)));
                }
                else
                {
                    item.socket.Send(Encoding.Unicode.GetBytes(message));
                }
            }

        }

        public void Menu()
        {
            int number=0;
            int choice = 0;
            Console.WriteLine("1 - connect \n 2 - disconnect");
            number=int.Parse(Console.ReadLine());
            switch(number)
            {
                case 1://connect
                    foreach(var item in clients)
                    {

                        SendMsg("1");
                        Console.WriteLine("1 - Opera \n 2-Firefox \n 3-Chrome");
                        choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                SendMsg("1");
                                break;
                            case 2:
                                SendMsg("2");
                                break;
                            case 3:
                                SendMsg("3");
                                break;
                        }


                    }
                    break;
                case 2://disc
                    foreach (var item in clients)
                    {
                        
                        SendMsg("2");
                        Console.WriteLine("1 - Opera \n 2-Firefox \n 3-Chrome");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                SendMsg("1");
                                break;
                            case 2:
                                SendMsg("2");
                                break;
                            case 3:
                                SendMsg("3");
                                break;
                        }
                    }
                    break;
            }
        }

    }
}