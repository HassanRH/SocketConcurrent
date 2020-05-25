/*
 * TcpEchoServer2.cs
 *
 * Author Michael Claudius, ZIBAT Computer Science
 * Version 1.0. 2014.02.10
 * Copyright 2014 by Michael Claudius
 * Revised 2014.09.15, revised 2016.09.05, 2017.09.20
 * All rights reserved
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SocketConcurrent
{
    public class TCPEchoServer2
    {
        public static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            //TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();


            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated now");
                EchoService service = new EchoService(connectionSocket);
                //Use Task and delegates

                //Task solution with delegates
                Task.Factory.StartNew(() => service.DoIt());

                //OR
                //Task.Factory.StartNew(service.DoIt);

                //OR
                //Task.Run(( ) => service.DoIt());

                //OR
                //Thread solution
                //Thread myThread = new Thread(new ThreadStart(service.DoIt));
      
                //OR
                //Thread myThread = new Thread(service.DoIt);
                //myThread.Start();

            }

            serverSocket.Stop();
        }

    }
}
