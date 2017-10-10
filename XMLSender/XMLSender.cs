using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSender
{
    class XMLSender
    {
        private readonly int _port;


        public XMLSender(int port)
        {
            this._port = port;
        }


        public void start()
        {

            //opretter bil
            car car = new car();
            car.model = "hurtig";

            string xmlstr = "";

            XmlSerializer carXmlSerializer = new XmlSerializer(typeof(car));
            using (StringWriter txtStringWriter = new StringWriter())
            {
                carXmlSerializer.Serialize(txtStringWriter, car);
                xmlstr = txtStringWriter.ToString();

                using (UdpClient udpClient = new UdpClient())
                {

                    IPEndPoint OtherEP = new IPEndPoint(IPAddress.Broadcast, _port);
                    byte[] buffer = Encoding.ASCII.GetBytes(xmlstr);
                    udpClient.Send(buffer, buffer.Length, OtherEP);


                }
            }


        }

    }
}
