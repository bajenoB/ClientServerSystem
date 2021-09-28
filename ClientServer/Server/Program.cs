using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ClientProject;
using System.Diagnostics;

namespace ServerProject
{
    class ServerProgram
    {

        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartServer();

            try

            {
                Task.Factory.StartNew(() => server.Connects());
                

                while (true)
                {

                    
                    server.Menu();

                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}