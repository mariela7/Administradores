using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AccesoDatos;
using Negocios;
using System.IO;
using System.Management;
using System.Security.AccessControl;
using System.Diagnostics;
using System.DirectoryServices;
using System.Collections;
using System.Configuration;
using System.Threading;

namespace EscaneoEquipos
{
    class Program
    {
        public static List<PingRespuesta> listaGlobalIps = new List<PingRespuesta>();

        static void Main(string[] args)
        {
            string ArchivoOrigen = Directory.GetCurrentDirectory().ToString() + @"\ListadoIPs.txt";

            Console.WriteLine("ARCHIVO ORIGEN: " + ArchivoOrigen.ToString());

            Metodos metodo = new Metodos();
            CSegmento ping = new CSegmento();
            LogEscaneo log = new LogEscaneo();

            string equiposEscaneados = string.Empty;

            List<PingRespuesta> ListaIpsAcumulada = new List<PingRespuesta>();

            if (System.IO.File.Exists(ArchivoOrigen))
            {
                List<string> ListaTotal = new List<string>();
                string line;

                List<PingRespuesta> ListaIpsSegmento = new List<PingRespuesta>();

                List<string> equipos = new List<string>();

                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(ArchivoOrigen);
                while ((line = file.ReadLine()) != null)
                {
                    equiposEscaneados = equiposEscaneados + line.ToString() + "; ";
                    equipos.Add(line);
                }

                file.Close();

                //REVISAR!!!!
                ListaIpsSegmento = ping.GetListIP(equipos);

                foreach (var row in ListaIpsSegmento)
                {
                    if (row != null)
                    {
                        PingRespuesta ip = new PingRespuesta();
                        ip.direccion = row.direccion;
                        ip.Estado = row.Estado;
                        ip.TTL = row.TTL;

                        if (Convert.ToInt32(ip.TTL) > 0)
                        {
                            ListaIpsAcumulada.Add(ip);
                        }
                    }
                }

                List<PingRespuesta> ListaIpsEscanear = new List<PingRespuesta>();
                List<PingRespuesta> ListaIpsErrores = new List<PingRespuesta>();

                foreach (var dato in ListaIpsAcumulada)
                {
                    if ((Convert.ToInt32(dato.TTL) >= 115) && (Convert.ToInt32(dato.TTL) <= 135))
                    //if ((Convert.ToInt32(dato.TTL) >= 50) && (Convert.ToInt32(dato.TTL) <= 70))
                    {
                        //ESCANEAR
                        PingRespuesta ip = new PingRespuesta();
                        ip.direccion = dato.direccion;
                        ip.Estado = dato.Estado;
                        ip.TTL = dato.TTL;

                        ListaIpsEscanear.Add(ip);
                    }
                    else
                    {
                        //ERROR
                        PingRespuesta ip = new PingRespuesta();
                        ip.direccion = dato.direccion;
                        ip.Estado = dato.Estado;
                        ip.TTL = dato.TTL;

                        ListaIpsErrores.Add(ip);
                    }
                }

                int TotalIpsEscanear = ListaIpsEscanear.Count;

                log.Accion = equiposEscaneados + " - IpsActivas: " + TotalIpsEscanear.ToString() + " - IpsErroneas: " + ListaIpsErrores.Count.ToString();
                log.SegmentoEscaneado = "Equipos-I";
                metodo.LogsInsertar(log);

                foreach (var item in ListaIpsErrores)
                {
                    log.SegmentoEscaneado = item.direccion.ToString();
                    log.Accion = "TTL no valido. - " + "Estado: " + item.Estado.ToString();
                    log.TTL = Convert.ToInt32(item.TTL);
                    metodo.LogsInsertar(log);
                }

                Console.WriteLine("Total IPs: " + TotalIpsEscanear.ToString());
                Parametros parametro = metodo.ObtenerParametroPorCodigo("HIL");
                int TotalHilos = parametro.Valor;                

                if (TotalIpsEscanear > 0)
                {
                    //HAY SEGMENTOS PARA ESCANEAR
                    if (TotalIpsEscanear > Convert.ToInt32(TotalHilos))
                    {
                        //ESCANEO POR HILOS
                        int IpsPorLista = TotalIpsEscanear / TotalHilos;

                        int c = 0;
                        int t = 0;

                        int cH = 1;

                        while (t != TotalIpsEscanear)
                        {
                            Program.listaGlobalIps.Clear();

                            for (int i = 0; i < IpsPorLista; i++)
                            {
                                PingRespuesta ip = new PingRespuesta();
                                ip.direccion = ListaIpsEscanear[i + (c * IpsPorLista)].direccion;
                                ip.Estado = ListaIpsEscanear[i + (c * IpsPorLista)].Estado;
                                ip.TTL = ListaIpsEscanear[i + (c * IpsPorLista)].TTL;

                                Program.listaGlobalIps.Add(ip);
                                t++;
                                if (t == TotalIpsEscanear)
                                {
                                    break;
                                }
                            }

                            c++;
                            Console.WriteLine("Vueltas: " + cH);
                            //Console.WriteLine("TotalIpsEscanear: " +TotalIpsEscanear);
                            //foreach (var item in listaGlobalIps)
                            //{
                            //    Console.WriteLine(item.direccion);
                            //}


                            if (Program.listaGlobalIps.Count > 0)
                            {

                                CHilos NuevoHilo = new CHilos();

                                foreach (var item in listaGlobalIps)
                                {
                                    NuevoHilo.ListadoIps.Add(item);
                                }
                                Program.listaGlobalIps.Clear();
                                NuevoHilo.NHilo = cH;

                                Console.WriteLine("##### Inicio Hilo " + cH.ToString() + " IPS: " + NuevoHilo.ListadoIps.Count());



                                //NuevoHilo.Ejecutar();


                                //ConsultaEquipos workerObject = new ConsultaEquipos();
                                Thread workerThread = new Thread(NuevoHilo.Ejecutar);
                                workerThread.Start();


                                Console.WriteLine("##### Hilo " + cH.ToString() + ". Ejecutando...");
                                //while (!workerThread.IsAlive) ;
                                //Thread.Sleep(1);

                                //workerObject.RequestStop();

                                //workerThread.Join();
                                //Console.WriteLine("##### Hilo " + cH.ToString() + ". Termina el Join");


                            }

                            cH++;
                        }

                        log.Accion = "Hilos enviados...";
                        //log.SegmentoEscaneado = "GF - " + grupo.ToString();
                        log.TTL = null;
                        metodo.LogsInsertar(log);
                    }
                    else
                    {
                        string error = string.Empty;
                        //ESCANEO DIRECTO
                        foreach (var item in ListaIpsEscanear)
                        {
                            error = RevisandoEquipos(item.direccion, item.TTL);

                            if (String.IsNullOrEmpty(error.Trim()) == false)
                            {
                                log.SegmentoEscaneado = item.direccion.ToString();
                                log.Accion = error;
                                log.TTL = Convert.ToInt32(item.TTL.ToString());
                                metodo.LogsInsertar(log);
                            }
                        }

                        log.Accion = "Fin escaneo (Por individual)";
                        //log.SegmentoEscaneado = "GF - " + grupo.ToString();
                        log.TTL = null;
                        metodo.LogsInsertar(log);
                    }
                }
                else
                {
                    //NO HAY SEGMENTOS PARA ESCANEAR
                    return;
                }
            }
        }

        static string RevisandoEquipos(string ip, string ttl)//, StreamWriter archivo, StreamWriter log)
        {
            string TextoError = string.Empty;
            bool existeError = false;

            Console.WriteLine("***" + ip + "***");

            Metodos metodo = new Metodos();

            string Maquina = "", SistOper = "", CUsuario = "", Antivirus = "";
            try
            {
                ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2");
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection queryCollection;

                try
                {
                    scope = new ManagementScope("\\\\" + ip + "\\root\\cimv2");
                    query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                    searcher = new ManagementObjectSearcher(scope, query);

                    Console.WriteLine("Inicio");

                    queryCollection = searcher.Get();
                    foreach (ManagementObject item in queryCollection)
                    {
                        Maquina = item.Properties["Caption"].Value.ToString();
                        CUsuario = item.Properties["UserName"].Value.ToString(); //NombreMaquina
                        Console.WriteLine("Nombre Maquina");
                    }
                }
                catch (Exception ex)
                {
                    if (Maquina == "")
                    {
                        existeError = true;
                        Console.WriteLine("ERROR: Nombre Maquina. U: " + CUsuario + "M: " + Maquina);
                        TextoError = TextoError + "ERROR: Nombre Maquina. U: " + CUsuario + "M: " + Maquina + " <<" + ex.Message.ToString() + ">> *** ";
                    }
                }

                try
                {
                    /*PARTE 2*/
                    query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                    searcher = new ManagementObjectSearcher(scope, query);
                    queryCollection = searcher.Get();

                    foreach (ManagementObject item in queryCollection)
                    {
                        SistOper = item.Properties["Caption"].Value.ToString();
                        Console.WriteLine("SO");
                    }
                }
                catch (Exception ex)
                {
                    TextoError = TextoError + "ERROR: Sistema Operativo <<" + ex.Message.ToString() + ">> *** ";
                    Console.WriteLine("ERROR: SO");
                    existeError = true;
                }

                /*PARTE 3*/
                int ant = 2;

                try
                {
                    if (SistOper.ToUpper().Contains("SERVER"))
                    {
                        //WINDOWS SERVER
                        query = new ObjectQuery("SELECT * FROM Win32_Service WHERE Name = 'Symantec AntiVirus'");
                    }
                    else
                    {
                        //PC
                        query = new ObjectQuery("SELECT * FROM Win32_Service WHERE Name = 'SepMasterService'");
                    }

                    searcher = new ManagementObjectSearcher(scope, query);
                    queryCollection = searcher.Get();

                    foreach (ManagementObject item in queryCollection)
                    {
                        Antivirus = item.Properties["Started"].Value.ToString();
                        Console.WriteLine("Antivirus");
                    }

                    if (String.IsNullOrEmpty(Antivirus.Trim()))
                    {
                        ant = -1;
                    }
                    else if ((Antivirus == "True") || (Antivirus == "Verdadero"))
                    {
                        ant = 1;
                    }
                    else
                    {
                        ant = 0;
                    }
                }
                catch (Exception ex)
                {
                    TextoError = TextoError + "ERROR: Antivirus <<" + ex.Message.ToString() + ">> *** ";
                    Console.WriteLine("ERROR: Antivirus");
                    ant = 2;
                }

                int idMaquina = 0;

                if (existeError == false)
                {
                    Equipos clEquipo = new Equipos();
                    clEquipo.Equipo = Maquina;
                    clEquipo.Ip = ip;
                    clEquipo.SistemaOperativo = SistOper;
                    clEquipo.UltimoUsuarioLogeado = CUsuario;
                    clEquipo.Antivirus = ant;
                    idMaquina = metodo.EquiposEscaneados_Insertar(clEquipo);
                }


                if (idMaquina > 0)
                {
                    bool errorI = true;
                    bool errorE = true;

                    string errorItxt = string.Empty;
                    string errorEtxt = string.Empty;

                    try
                    {
                        DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + ip);
                        DirectoryEntry admGroup = localMachine.Children.Find("administrators", "group");
                        object members = admGroup.Invoke("members", null);

                        Console.WriteLine("Administradores Ingles");

                        Administradores clAdmin = new Administradores();

                        foreach (object groupMember in (IEnumerable)members)
                        {
                            DirectoryEntry member = new DirectoryEntry(groupMember);

                            clAdmin.IdMaquina = idMaquina;
                            clAdmin.Administrador = member.Path;
                            metodo.AdministradoresEscaneadosInsertar(clAdmin);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ERROR ESCANEO ADMINISTRADORES
                        errorI = false;
                        errorItxt = ex.Message.ToString();
                        Console.WriteLine("Error Administradores Ingles");
                    }

                    try
                    {
                        DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + ip);
                        DirectoryEntry admGroup = localMachine.Children.Find("administradores", "group");
                        object members = admGroup.Invoke("members", null);

                        Console.WriteLine("Administradores Español");

                        Administradores clAdmin = new Administradores();

                        foreach (object groupMember in (IEnumerable)members)
                        {
                            DirectoryEntry member = new DirectoryEntry(groupMember);

                            clAdmin.IdMaquina = idMaquina;
                            clAdmin.Administrador = member.Path;
                            metodo.AdministradoresEscaneadosInsertar(clAdmin);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ERROR ESCANEO ADMINISTRADORES                        
                        errorE = false;
                        errorEtxt = ex.Message.ToString();
                        Console.WriteLine("Error Administradores Español");
                    }

                    if ((errorE == false) && (errorI == false))
                    {
                        Console.WriteLine("ERROR CON LA MAQUINA(IDIOMA): " + ip);
                        metodo.EquiposEscaneados_AdminUpdate("ERROR", idMaquina);

                        TextoError = TextoError + "ERROR ADMINS: ESP(" + errorEtxt + ") / ING(" + errorItxt + ") *** ";
                    }
                }
            }
            catch (Exception ex)
            {
                //ERROR ESCANEO EQUIPO
                //log.WriteLine("Ocurrió un error durante el escaneo del equipo: " + computerName.ToString());
                Console.WriteLine("ERROR CON LA MAQUINA: " + ip + " -- " + ex.Message.ToString());

                TextoError = TextoError + " <<" + ex.Message.ToString() + ">> *** ";
            }

            return TextoError;
        }

        public class ConsultaEquipos
        {
            private volatile bool _shouldStop;

            public void RequestStop()
            {
                _shouldStop = true;
            }

            public void ConsultaInformacionEquipo()
            {
                Metodos metodo = new Metodos();
                string error = string.Empty;
                foreach (var b in Program.listaGlobalIps)
                {
                    error = RevisandoEquipos(b.direccion.ToString(), b.TTL.ToString());

                    if (String.IsNullOrEmpty(error.Trim()) == false)
                    {
                        LogEscaneo log = new LogEscaneo();
                        log.SegmentoEscaneado = b.direccion.ToString();
                        log.Accion = error;
                        log.TTL = Convert.ToInt32(b.TTL.ToString());
                        metodo.LogsInsertar(log);
                    }
                }
            }
        }
    }
}
