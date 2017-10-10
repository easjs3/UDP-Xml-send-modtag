using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlUD
{
    class XmlUDPReceiver
    {

        private readonly int Port;


        public XmlUDPReceiver(int port)
        {
            this.Port = port;
        }

        public void start()
        {
            byte[] buffer = new byte[2048];

            using (UdpClient udpClient = new UdpClient(Port))
            {
                IPEndPoint SenderEP = new IPEndPoint(IPAddress.Any, 0);
                buffer = udpClient.Receive(ref SenderEP);

                string incstr = Encoding.ASCII.GetString(buffer);

                XmlSerializer carXmlSerializer = new XmlSerializer(typeof(car));

                using (StringReader reader = new StringReader(incstr))
                {
                    car car = (car)carXmlSerializer.Deserialize(reader);
                    Console.WriteLine(car.model);
                }


                

            }

        }


    }
}
