
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

	public class TimeParameters{

			public TimeParameters(){
		   	}



			 	public  int  PeriodTimeSpan   {get; set;}  

			 	public  int  StartTimeSpan   {get; set;}  

			 	public  int  StopAfter   {get; set;}  


			 	public  bool  AutoEvent   {get; set;}  



	}

