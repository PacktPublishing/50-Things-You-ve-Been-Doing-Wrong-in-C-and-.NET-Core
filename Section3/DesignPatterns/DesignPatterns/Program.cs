﻿using System;


namespace DesignPatterns
{
    interface IProcess
    {
        void DoWork();
    }

    class Process : IProcess
    {
        public void DoWork()
        {
            Console.WriteLine("Do Work");
        }
    }

    class Client
    {
        public void StartProcess()
        {
            this.CreateProcess().DoWork();
        }

        protected virtual IProcess CreateProcess()
        {
            return new Process();
        }
    }

    class LoggingProcess : IProcess
    {
        readonly IProcess process;
        public LoggingProcess(IProcess process) => this.process = process;


        public void DoWork()
        {
            Console.WriteLine("before dowork");
            this.process.DoWork();
            Console.WriteLine("after dowork");
        }
    }
    class LoggingClient : Client
    {

        protected override IProcess CreateProcess()
        {
            return new LoggingProcess(new Process());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var client = new LoggingClient();
            client.StartProcess();
        }
    }
}