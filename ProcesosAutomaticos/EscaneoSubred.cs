using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using Negocios;

namespace ProcesosAutomaticos
{
    public class EscaneoSubred
    {
        List<Agencias> ListadoAgencias = new List<Agencias>();
        Metodos met = new Metodos();

        ListadoAgencias = met.Agencias_ObtenerEscaneoDiario();
    }
}
