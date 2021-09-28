using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

namespace ClientProject
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            string path;
            string num;
            StringBuilder str;
            try
            {
                client.Connect();
                
                

                while (true)
                {
                    path = client.GetMsg().ToString();
                    num = client.GetMsg().ToString();
                    
                    client.Menu(path, num,client.socket);

                    //Console.WriteLine(client.GetMsg().ToString());

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}