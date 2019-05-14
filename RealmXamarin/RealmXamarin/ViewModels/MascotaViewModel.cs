using RealmXamarin.Base;
using RealmXamarin.Models;
using RealmXamarin.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RealmXamarin.ViewModels
{
    public class MascotaViewModel : ViewModelBase
    {
        private RepositoryMascotas repo;

        public MascotaViewModel()
        {
            this.repo = new RepositoryMascotas();
            List<Mascota> lista = this.repo.GetMascotas();
            this.Mascotas = new ObservableCollection<Mascota>(lista);
        }

        private ObservableCollection<Mascota> _Mascotas;
        public ObservableCollection <Mascota> Mascotas
        {
            get
            {
                return this._Mascotas;
            }
            set
            {
                this._Mascotas = value;
                OnPropertyChanged("Mascotas");
            }
        }
    }
}
