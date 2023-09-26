
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

	public class AsyncClient{

			public AsyncClient(){

				    responseData = new List<ResponseData>();

		   	}

				public Device device;

				
					public List<ResponseData> responseData{get; set;}
				

				public StateObject state;

			 	private  static  string  response   ;  

			 	private  static  ManualResetEvent  connectDone   ;  

			 	private  static  ManualResetEvent  sendDone   ;  

			 	private  static  ManualResetEvent  receiveDone   ;


            private const int port = 11000;   

			public void StartClient( Device dev ) {
							connectDone = new ManualResetEvent(false);
            sendDone = new ManualResetEvent(false);
            receiveDone = new ManualResetEvent(false);
            // Connect to a remote device.  
            try
            {
                device = new Device();
                device = dev;
                // Establish the remote endpoint for the socket.  
                // The name of the   
                // remote device is "host.contoso.com".  
                IPHostEntry ipHostInfo = Dns.GetHostEntry("hp");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.  
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                // Send test data to the remote device.  
                Send(client, device);
                sendDone.WaitOne();

                // Receive the response from the remote device.  
                Receive(client);
                receiveDone.WaitOne();

                

                // Release the socket.  
               // client.Shutdown(SocketShutdown.Both);
               // client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

					
		     	}

			private static void ConnectCallback(IAsyncResult ar){
					 Device device = new Device();

					 ResponseData responseData = new ResponseData();

					 StateObject state = new StateObject();
							try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.  
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.  
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
			}	

			private static void Receive(Socket client){
					 Device device = new Device();

					 ResponseData responseData = new ResponseData();

					 StateObject state = new StateObject();
							try
            {
                // Create the state object.  
                state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
			}	

			private static void ReceiveCallback(IAsyncResult ar){
					 Device device = new Device();

					 ResponseData responseData = new ResponseData();

					 StateObject state = new StateObject();
							try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.  
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Write the response to the console.  
                    Console.WriteLine("Response received : {0}", response);
                    // Signal that all bytes have been received.  
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
			}	

			private static void Send(Socket client,Device data){
					 Device device = new Device();

					 ResponseData responseData = new ResponseData();

					 StateObject state = new StateObject();
							string sendData = Utility.DeviceModelToStream(data);
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(sendData);
           // Console.WriteLine(sendData);
            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
			}	

			private static void SendCallback(IAsyncResult ar){
					 Device device = new Device();

					 ResponseData responseData = new ResponseData();

					 StateObject state = new StateObject();
							try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
            // Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            Console.WriteLine("Data sent to Server");
                // Signal that all bytes have been sent.  
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
			}	


	}

