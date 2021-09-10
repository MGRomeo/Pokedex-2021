using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Elemento(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
        public Elemento(){}

        public override string ToString()  // sobre escribiendo este metodo se muestra como se debe los datos en el cobTipo y Descripcion
        {
            return Descripcion;
        }

    }
}
