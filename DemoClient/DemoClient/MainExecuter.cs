
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

	public class MainExecuter{

			public MainExecuter(){
		   	}

				public Driver driver;


			public static void Main(string[] args){
					 Driver driver = new Driver();
							string pathxml = "C:\\Users\\Muhammar Nouman\\workspaceNEON\\org.eclipse.acceleo.module.Transformation\\Target\\Devices2.xml";
Driver drive = new Driver();
            TimeParameters time = new TimeParameters();
time.PeriodTimeSpan = 5;
            time.StopAfter = 25;
            time.AutoEvent = false;
            drive.StartClient(pathxml, time);
			}	


	}

