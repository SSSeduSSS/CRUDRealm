
using System.Collections.Generic;
using System.Linq;
using Realms;
using RealmXamarin.Models;

namespace RealmXamarin.Repositories
{
    public class RepositoryMascotas
    {
        private Realm conexionRealm; //Conexion para REALM
        Transaction transaction; //Para ejecutar sentenciás de acción

        public RepositoryMascotas()
        {
            //creamos la conexión
            this.conexionRealm = Realm.GetInstance();
        }


        public List<Mascota> GetMascotas()
        {
            //Recuperar toda la lsita de mascotas
            List<Mascota> lista = this.conexionRealm.All<Mascota>().ToList();
            return lista;
        }

        //Insertar nueva mascota
        public void InsertarMascota(Mascota m)
        {
            transaction = conexionRealm.BeginWrite();
            var entry = conexionRealm.Add(m);
            transaction.Commit();            
        }


        public Mascota BuscarMascota(int id)
        {
            //Recuperas todas las mascotas
            List<Mascota> lista = this.GetMascotas();

            //De toda la lista recupero la que tiene el ID buscado
            Mascota m = lista.FirstOrDefault(z=>z.IdMascota==id);
            return m;
        }

        public void  ModificarMascota (Mascota mEdit)
        {
            //Buscas la mascota que vas a editar
            Mascota m = this.BuscarMascota(mEdit.IdMascota);

            //Ejecutamos un using desde la conexion por eficiencia
            using (var trans = this.conexionRealm.BeginWrite())
            {
                //Cambiamos los datos

                m.Nombre = mEdit.Nombre;
                m.Raza = mEdit.Raza;
                //m.Fecha=mEdit.Fecha;
                m.Anotaciones = mEdit.Anotaciones;


                trans.Commit();//Confirmamos los cambios
            }
        }

        public void EliminarRegistro (int id)
        {
            //Buscas la mascota que vas a editar
            Mascota m = this.BuscarMascota(id);

            //Si existe la mascota
            if(m!=null)
            {
                //Ejecutamos un using desde la conexion por eficiencia
                using (var trans = this.conexionRealm.BeginWrite())
                {
                    //Borramos pasando el id al método REMO de la conexión
                    this.conexionRealm.Remove(m);

                    trans.Commit(); //Confirmamos
                }
            }
        }
    }
}
