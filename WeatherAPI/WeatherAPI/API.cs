using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WeatherAPI
{
	public static class API
	{
		public static void GetWeather ()
		{
			//Declare and assign the url to a string
			string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&APPID=15bbc55515f9a14b1e1b097e6f918185";

			// Create a Web Request object type 
			WebRequest req = WebRequest.Create(@url);


			//Get method
			req.Method = "GET";

			// Declare and Initialize the WebRequest for the Request
			HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

			//If statement to status code results after Http Request
			if (resp.StatusCode == HttpStatusCode.OK)
			{
				// reading the reponse 
				using (Stream respStream = resp.GetResponseStream())
				{
					//Declare the reader
					StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
					
					//Declare and Assign the reader to a string
					String jsonstr = reader.ReadToEnd();

					// Declare and Initalize the Newton Json Serializer to a string
					JObject result = JObject.Parse(jsonstr);

					//Display the parse results in Json
					Console.WriteLine("json is: ---------------------" + result);
				}
			}
			else
			{
				//Display the results in a string format
				Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
			}
			//Keep the COnsole open after the display
			Console.Read();


		}//GetWeather
	//End Class API
}//End Namespace WeatherAPI
