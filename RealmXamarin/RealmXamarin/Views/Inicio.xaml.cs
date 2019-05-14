using RealmXamarin.Models;
using RealmXamarin.Repositories;
using RealmXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Inicio : ContentPage
	{
        RepositoryMascotas repo;
		public Inicio ()
		{
			InitializeComponent ();
            this.repo = new RepositoryMascotas();

            this.botonActualizar.Clicked += BotonActualizar_ClickedAsync;
            this.botonBuscar.Clicked += BotonBuscar_ClickedAsync;
            this.botonEliminar.Clicked += BotonEliminar_ClickedAsync;
            this.botonMostrar.Clicked += BotonMostrar_ClickedAsync;
            this.botonNuevaMascota.Clicked += BotonNuevaMascota_ClickedAsync;
		}

        private async void BotonNuevaMascota_ClickedAsync(object sender, EventArgs e)
        {
            NuevaMascota view = new NuevaMascota();
            await Navigation.PushModalAsync(view);
        }

        private async void BotonMostrar_ClickedAsync(object sender, EventArgs e)
        {
            MascotasView view = new MascotasView();
            await Navigation.PushModalAsync(view);
        }

        private async void BotonEliminar_ClickedAsync(object sender, EventArgs e)
        {
            EliminarMascota deleteview = new EliminarMascota();
            MascotaModel viewmodel = new MascotaModel();
            int id = int.Parse(this.txtid.Text);
            Mascota m = this.repo.BuscarMascota(id);
            viewmodel.Mascota = m;
            deleteview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(deleteview);

        }
 
        private async void BotonBuscar_ClickedAsync(object sender, EventArgs e)
        {
            DetallesMascota detailsview = new DetallesMascota();
            MascotaModel viewmodel = new MascotaModel();
            int id = int.Parse(this.txtid.Text);
            Mascota m = this.repo.BuscarMascota(id);
            viewmodel.Mascota = m;
            detailsview.BindingContext = viewmodel;
            await Navigation.PushModalAsync(detailsview);

        }

        private async void BotonActualizar_ClickedAsync(object sender, EventArgs e)
        {
            ModificarMascota view = new ModificarMascota();
            MascotaModel viewModel = new MascotaModel();
            int id = int.Parse(this.txtid.Text);
            Mascota m = this.repo.BuscarMascota(id);
            viewModel.Mascota = m;
            view.BindingContext = viewModel;
            await Navigation.PushModalAsync(view);
        }
    }
}