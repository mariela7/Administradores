﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Negocios;
using System.Management;
using System.Security.AccessControl;
using System.Diagnostics;
using System.DirectoryServices;
using System.Collections;
using System.Threading;

namespace EscaneoRedes
{
    public class CHilos
    {
        public CHilos()
        {
            ListadoIps = new List<PingRespuesta>();
            ListadoIps.Clear();
        }

        public List<PingRespuesta> ListadoIps { get; set; }
        public int NHilo { get; set; }

        public void Ejecutar()
        {
            Thread workerThread = new Thread(ConsultaInformacionEquipo);
            workerThread.Start();
            while (!workerThread.IsAlive) ;
            Thread.Sleep(1);
            workerThread.Join();
        }

        public void ConsultaInformacionEquipo()
        {
            Console.WriteLine("_____Inicio Escaneo Hilo: " + NHilo.ToString() + " - FI: " + DateTime.Now.ToLongTimeString());

            Metodos metodo = new Metodos();
            string error = string.Empty;

            foreach (var item in ListadoIps)
            {
                Console.WriteLine("# Hilo " + NHilo.ToString() + " - " + item.direccion);
            }


            foreach (var b in ListadoIps)
            {
                Console.WriteLine("**HILO: "+ NHilo.ToString() + " - IP: " + b.direccion.ToString() + " - FI: " + DateTime.Now.ToLongTimeString() + " **");
                //ESCANEO
                error = RevisandoEquipos(b.direccion.ToString(), b.TTL.ToString());

                Console.WriteLine("**HILO: " + NHilo.ToString() + " - IP: " + b.direccion.ToString() + " - FF: " + DateTime.Now.ToLongTimeString() + " **");

                if (String.IsNullOrEmpty(error.Trim()) == false)
                {
                    LogEscaneo log = new LogEscaneo();
                    log.SegmentoEscaneado = b.direccion.ToString();
                    log.Accion = error;
                    log.TTL = Convert.ToInt32(b.TTL.ToString());
                    metodo.LogsInsertar(log);
                }
            }

            Console.WriteLine("_____Fin Escaneo Hilo: " + NHilo.ToString() + " - FF: " + DateTime.Now.ToLongTimeString());

        }

        public string RevisandoEquipos(string ip, string ttl)//, StreamWriter archivo, StreamWriter log)
        {
            string TextoError = string.Empty;
            bool existeError = false;

            Console.WriteLine("*** Hilo: " + NHilo.ToString() +" - " + ip + " ***");

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
                    
                    queryCollection = searcher.Get();
                    foreach (ManagementObject item in queryCollection)
                    {
                        Maquina = item.Properties["Caption"].Value.ToString();
                        CUsuario = item.Properties["UserName"].Value.ToString(); //NombreMaquina
                    }
                }
                catch (Exception ex)
                {
                    if (Maquina == "")
                    {
                        existeError = true;
                        Console.WriteLine("ERROR: " + ip.ToString() + " Nombre Maquina. U: " + CUsuario + "M: " + Maquina);
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
                    }
                }
                catch (Exception ex)
                {
                    TextoError = TextoError + "ERROR: Sistema Operativo <<" + ex.Message.ToString() + ">> *** ";
                    Console.WriteLine("ERROR: " + ip.ToString() + " SO");
                    existeError = true;
                }

                /*PARTE 3*/
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
                    }
                }
                catch (Exception ex)
                {
                    TextoError = TextoError + "ERROR: Antivirus <<" + ex.Message.ToString() + ">> *** ";
                    Console.WriteLine("ERROR: " + ip.ToString() + " Antivirus");
                }

                int ant;

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
                        Console.WriteLine("Error Administradores Ingles: " + ip.ToString());
                    }

                    try
                    {
                        DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + ip);
                        DirectoryEntry admGroup = localMachine.Children.Find("administradores", "group");
                        object members = admGroup.Invoke("members", null);
                        
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
                        Console.WriteLine("Error Administradores Español: " + ip.ToString());
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

    }

   
}
