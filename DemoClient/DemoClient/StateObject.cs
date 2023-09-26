
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

	public class StateObject{

			public StateObject(){
		   	}



			 	public  Socket  workSocket  = null;  

			 	public  const int  BufferSize  = 4024;  

			 	public  byte  []  buffer  = new byte[BufferSize];  

			 	public  StringBuilder  sb  = new StringBuilder();  



	}

