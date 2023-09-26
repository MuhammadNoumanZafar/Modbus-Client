
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

	public class Driver{

			public Driver(){
				    device = new List<Device>();



		   	}

    private XMLReader xml;
    public List<Device> device{get; set;}
				

				public TimeParameters timeparameters;

				public AsyncClient client;

				public IPValidator validate;

			 	private  string  path   ;  


			public void StartClient( string Path,TimeParameters time ) {
							path = Path;
            timeparameters = new TimeParameters();
            xml = new XMLReader();
            device = new List<Device>();
            validate = new IPValidator();
             client = new AsyncClient();
            timeparameters = time;
              device = xml.ReadFile(path);
        //var StartTimeSpan = TimeSpan.Zero;
        //var PeriodTimeSpan = TimeSpan.FromSeconds(timeparameters.PeriodTimeSpan);
        //var StopAfter = TimeSpan.FromSeconds(timeparameters.StopAfter);
        //var autoevent = new AutoResetEvent(timeparameters.AutoEvent);
        //var timer = new System.Threading.Timer((e) =>
        //{

            foreach (Device device in device)
                 {
                     bool valid = validate.ValidateIP(device.IPAddress);
                     if (valid == true)
                        {
                          client.StartClient(device);
                        }
                        else
                        {
                            Console.WriteLine("invalid IP found" + device.IPAddress);
                        }
                 }
        //}, autoevent, StartTimeSpan, PeriodTimeSpan);
        //autoevent.WaitOne(StopAfter);
        //timer.Dispose();
        Console.WriteLine("Operation Completed. Press any key to exit.");

            Console.Read();

					
		     	}


	}

