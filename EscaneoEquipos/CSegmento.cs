using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Diagnostics;

namespace EscaneoEquipos
{
    public class CSegmento
    {
        /// <summary>
        /// Devuelve una lista de IP's Disponible en el rango especificado
        /// </summary>
        /// <param name="Rango">Formato: 192.168.1.</param>
        /// <returns></returns>
        /// 

        private static List<Ping> pingers = new List<Ping>();
        private static List<PingRespuesta> miLista = new List<PingRespuesta>();
        private static int instances = 0;
        private static object @lock = new object();
        private static int result = 0;
        private static int timeOut = 500;
        private static int ttl = 5;

        public List<PingRespuesta> GetListIP(List<string> Rango)
        {
            result = 0;
            //string baseIP = Rango;

            //Console.WriteLine("Pinging IP destination {0}", );

            //foreach (string item in Rango)
            //{
            //    CreatePingers(0);    
            //}
            
            PingOptions po = new PingOptions(ttl, true);
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] data = enc.GetBytes("abababababababababababababababab");

            SpinWait wait = new SpinWait();
            int cnt = 1;
            Stopwatch watch = Stopwatch.StartNew();

            foreach (string item in Rango)
            {
                Ping p = new Ping();
                p.PingCompleted += Ping_completed;
                pingers.Add(p);

            }

            for (int i = 0; i < pingers.Count-1; i++)
            {
                lock (@lock)
                {
                    instances += 1;
                }
                pingers[i].SendAsync(Rango[i], timeOut, data, po);
                cnt += 1;
            }
            
           

            while (instances > 0)
            {
                wait.SpinOnce();
            }

            watch.Stop();

            DestroyPingers();

            Console.WriteLine("Found {0} active IP-addresses.", result);

            return miLista;
        }

        public static void Ping_completed(object s, PingCompletedEventArgs e)
        {
            lock (@lock)
            {
                instances -= 1;
            }
            PingRespuesta miRespuesta = new PingRespuesta();
            try
            {
                miRespuesta.direccion = e.Reply.Address.ToString();
                miRespuesta.Estado = e.Reply.Status.ToString();


                if (e.Reply.Status == IPStatus.Success)
                {
                    miRespuesta.TTL = e.Reply.Options.Ttl.ToString();
                    result += 1;
                }
                else
                {
                    miRespuesta.TTL = "0";
                }

            }
            catch (Exception ex)
            {
                //Console.Write("ERROR DE PING: " +" - " + ex.Message.ToString() + "\n");
            }

            
            miLista.Add(miRespuesta);

            //if (e.Reply.Status == IPStatus.Success)
            //{
            //    miLista.Add(e.Reply.Address.ToString());
            //    result += 1;
            //}
            //else
            //{
            //}
        }

        private static void CreatePingers(int cnt)
        {
                Ping p = new Ping();
                p.PingCompleted += Ping_completed;
                pingers.Add(p);
        }

        private static void DestroyPingers()
        {
            foreach (Ping p in pingers)
            {
                p.PingCompleted -= Ping_completed;
                p.Dispose();
            }

            pingers.Clear();

        }
    }

    public class PingRespuesta
    {
        public string direccion { get; set; }
        public string TTL { get; set; }
        public string Estado { get; set; }
    }
}
