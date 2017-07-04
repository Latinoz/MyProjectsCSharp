using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;



namespace Popingui
{
    
    class Program
    {
        class ForPopingui                                      
        {

            public string ip;                               // Переменная для ввода ip адреса

            public void PrintEnterIp () {                   // Вывод инфо для ввода ip адреса                  
                Console.WriteLine("Enter ip address: ");
                }
        }


        static void Main(string[] args)
        {
            ForPopingui obj1 = new ForPopingui();

            obj1.PrintEnterIp();

            obj1.ip = Console.ReadLine();                    // Получение ip адреса из командной строки


            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            string address = obj1.ip;

            try
            {
                PingReply reply;
                
                while (true)                                      // Цикл вывода опроса ответа ICMP 
                {                                                 // и вывод данных

                    System.Threading.Thread.Sleep(1000);          // Задержка вывода данных в миллисекундах

                    reply = pingSender.Send(address);             // Отправка запроса ICMP
                    if (reply.Status == IPStatus.Success)         // Получение и проверка ответа
                    
                    {
                        
                        Console.WriteLine("Address: {0}", reply.Address.ToString());
                        Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                        Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                        Console.WriteLine("Ping Successful!!!");
                        Console.WriteLine();
                        
                    }

                    else
                     {
                       Console.WriteLine("IP address: " + address + " not answer!");
                       Console.WriteLine();
                       
                    }
                }

            }

            catch (PingException)
            {
                Console.WriteLine("Not correct IP address (PingException)");
                Console.ReadKey();
            }

            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                Console.ReadKey();
            }
            

        }
    }
}
