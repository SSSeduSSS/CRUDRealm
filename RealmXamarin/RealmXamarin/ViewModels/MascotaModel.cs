using RealmXamarin.Base;
using RealmXamarin.Models;
using RealmXamarin.Repositories;

using System;

using Xamarin.Forms;

namespace RealmXamarin.ViewModels
{
    public class MascotaModel :ViewModelBase
    {
        RepositoryMascotas repo;

        public MascotaModel()
        {
            this.repo = new RepositoryMascotas();
            this.Mascota = new Mascota();
        }

        //Para los BINDINGS al AXML
        private Mascota _Mascota;
        public Mascota Mascota
        {
            get
            {
               return  this._Mascota ;
            }
            set
            {
                this._Mascota = value;
                OnPropertyChanged("Mascota");
            }
        }

        //Para mostrar un mensaje al usuario
        private String _Mensaje;
        public String Mensaje
        {
            get { return this._Mensaje; }
            set
            {
                this._Mensaje = value;
                OnPropertyChanged("Mensaje");
            }
        }

        public Command NuevaMascota
        {
            get
            {
                return new Command(() => {
                    this.repo.InsertarMascota(this.Mascota);
                    this.Mensaje = "Mascota almacenada";
                });
            }
        }

        public Command ModificarMascota
        {
            get
            {
                return new Command(() => {
                    this.repo.ModificarMascota(this.Mascota);
                    this.Mensaje = "Mascota Actualizada";
                });
            }
        }

        public Command EliminarMascota
        {
            get
            {
                return new Command(() => {
                    this.repo.EliminarRegistro(this.Mascota.IdMascota);
                    this.Mensaje = "Registro Eliminado";
                });
            }
        }

    }
}
