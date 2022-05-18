using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSClase6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Actualizar : ContentPage
    {
        public Actualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtcodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }


        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                await httpClient.DeleteAsync("http://192.168.100.33/ws/post.php?codigo=" + txtcodigo.Text);

                var msj = "Datos Eliminados";
                DependencyService.Get<Mensaje>().alertShort(msj);
                await Navigation.PushAsync(new Inicio());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }
        }

        private async void btnActulizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtcodigo.Text);
                cliente.UploadValues("http://192.168.100.33/ws/post.php?codigo="+txtcodigo.Text+"&nombre="+txtNombre.Text+"&apellido="+txtApellido.Text+"&edad="+txtEdad.Text, "PUT", parametros);

                var msj = "Datos Actualizados";
                DependencyService.Get<Mensaje>().alertShort(msj);
                await Navigation.PushAsync(new Inicio());
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }
        }
    }
}