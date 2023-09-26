
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

	public class XMLReader{

			public XMLReader(){
				    device = new List<Device>();
		   	}

				
					private List<Device> device{get; set;}
				

			 	public  string  Name   {get; set;}  


			 	public  string  Path   {get; set;}  

			public List<Device> ReadFile( string path ) {
									device = new List<Device>();
        //  Console.WriteLine("Getting Devices Information");
        //  Console.WriteLine("================================");
                Path = path;
            if (File.Exists(Path) == false)
            {
                FileStream Fs = File.Create(Path);
                Fs.Dispose();
            }
            try
            {
                XDocument XDOC = XDocument.Load(Path);


                var Devices = XDOC.Root.Descendants("Device").Select(node => new Device
                {
                    DeviceID = Convert.ToByte(node.Element("DeviceID").Value),
                    IPAddress = node.Element("IPAddress").Value,
                    Port = int.Parse(node.Element("Port").Value),
                    destination = node.Element("Destinations").Descendants("Destination").Select(childnode => new Destination
                    {
                        Location = childnode.Element("Location").Value,
                        Inputs = childnode.Descendants("Inputs").Select(inputsnode => new Inputs
                        {
                            StartingAddress = ushort.Parse(inputsnode.Element("StartingAddress").Value),
                            NumofInput = ushort.Parse(inputsnode.Element("NumofInput").Value)
                        }).ToList()
                    }).ToList()
                }).ToList();

                device = Devices;

            }
            catch (XmlException e)
            {
                string ex = e.ToString();
            }
            return device;

					
		     	}


	}

