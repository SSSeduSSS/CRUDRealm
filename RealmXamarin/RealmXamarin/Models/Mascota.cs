using System;
using Realms;

namespace RealmXamarin.Models
{
    public class Mascota :RealmObject
    {
        [PrimaryKey]
        public int IdMascota { get; set; }
        public String Nombre { get; set; }
        public String Raza { get; set; }
        //public DateTime Fecha { get; set; }
        public String Anotaciones { get; set; }
    }
}
