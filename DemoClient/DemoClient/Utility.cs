
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

	public class Utility{

			public Utility(){
		   	}



			 	private  static  BinaryFormatter  binaryformat   ;  

			 	private  static  MemoryStream  memorystream   ;  

			 	private  static  IEnumerable  enumerable   ;  

			 	private  static  StringBuilder  builder   ;  

			public static byte[] ObjectToByteArray(Object obj){
							if (obj == null)
                return null;
            binaryformat = new BinaryFormatter();
            memorystream = new MemoryStream();
            binaryformat.Serialize(memorystream, obj);

            return memorystream.ToArray();
			}	

			public static Object ByteArrayToObject(byte[] arrBytes){
							binaryformat = new BinaryFormatter();
            memorystream = new MemoryStream();
            memorystream.Write(arrBytes, 0, arrBytes.Length);
            memorystream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binaryformat.Deserialize(memorystream);

            return obj;
			}	

			public static string ObjectToString(Object obj){
							enumerable = obj as IEnumerable;
            builder = new StringBuilder();
            if (enumerable != null)
            {
                foreach (object element in enumerable)
                {
                    builder.Append(element.ToString() + ",");
                }
            }
            return builder.ToString();
			}	

			public static Device StreamToDeviceModel(string content){
							TextReader textReader = new StringReader(content);
            XmlSerializer serializer = new XmlSerializer(typeof(Device));
            return (Device)serializer.Deserialize(textReader);
			}	

			public static string DeviceModelToStream(Device data){
							builder = new StringBuilder();
            var writer = new StringWriter(builder);

            XmlSerializer serializer = new XmlSerializer(typeof(Device));
            serializer.Serialize(writer, data);
            return builder.ToString();
			}	

			public static List<ResponseData> StreamToResponseModel(string content){
							TextReader textReader = new StringReader(content);
            XmlSerializer serializer = new XmlSerializer(typeof(ResponseData));
            return (List<ResponseData>)serializer.Deserialize(textReader);
			}	

			public static string ResponseModelToStream(List<ResponseData> data){
							builder = new StringBuilder();
            var writer = new StringWriter(builder);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ResponseData>));
            serializer.Serialize(writer, data);
            return builder.ToString();
			}	


	}

