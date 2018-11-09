using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;

namespace GeekDay
{
    public class HTTPRequester {
        private WebServer ws;
        public HTTPRequester() {
            this.ws = new WebServer(SendResponse, "http://192.168.1.81:8080/");
        }

        public void Start() {
            Console.WriteLine("SAJT");
            ws.Run();
        }
        public void Stop() {
            ws.Stop();
        }

        private string SendResponse(HttpListenerRequest request) {
            Console.WriteLine(request.HttpMethod);
            Console.WriteLine("Sajt");
            return "";
        }  
    }

    

}