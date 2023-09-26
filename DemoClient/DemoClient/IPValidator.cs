
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Device;
using Modbus.Utility;
using System.Timers;
using System.Threading;
using System.Net.Sockets;
using System.IO.Ports;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FtdAdapter;
using Modbus.Data;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

	public class IPValidator{

			public IPValidator(){
		   	}



			 	private  IPAddress  address   ;  

			public bool ValidateIP( string ipString ) {
							bool IP = false;
            if (IPAddress.TryParse(ipString, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        IP = true;
                        break;
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        IP = true;
                        break;
                    default:
                        IP = false;
                        break;
                }
            }
            return IP;

					
		     	}


	}

