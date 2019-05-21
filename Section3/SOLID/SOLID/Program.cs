using System;
using System.Collections.Generic;
namespace SOLID
{
    class Order
    {
        //Violates Single Responsiblity Principle
        //Also violates Dependency Inversion
        public void SendConfirmationMessage(string message) 
        { 
            //send email
        }
    }

    class MessageSender
    {
        public MessageSender(string targetAddress) => this.TargetAddress = targetAddress;
        //Should be hidden
        public string TargetAddress;

        //Probably should be virtual or abstract
        public void SendConfirmationMessage(string message) 
        { 
           
            //send email
        }
    }
    class BetterMessageSender
    {
        public BetterMessageSender(string targetAddress) => this.targetAddress = targetAddress;
        protected readonly string targetAddress;

        //Probably should be virtual or abstract
        public virtual void SendConfirmationMessage(string message) 
        { 
            if(message.Length > 500) throw new ArgumentException("Message too long");
            //send email
        }
    }

    class SMSSender : BetterMessageSender
    {
        SMSSender(string targetNumber): base(targetNumber){}
        public override void SendConfirmationMessage(string message)
        {
            // violates liskov substitution
              if(message.Length > 200) throw new ArgumentException("Message too long");
        }
    }


    interface IMessageSender
    {
        int SendConfirmationMessage(string message);

        // are we sure if ReadReceipt is supported for all implementors?
        bool GetReadReceipt(int messageId);
    }

    interface IBetterMessageSender
    {
          int SendConfirmationMessage(string message);

    }
    interface IBetterMessageSenderWithReceipt : IBetterMessageSender
    {
          bool GetReadReceipt(int messageId);
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}