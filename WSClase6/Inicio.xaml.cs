using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSClase6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private const string Url = "http://192.168.100.33/ws/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<WSClase6.Datos> _post;
        public Inicio()
        {
            InitializeComponent();
        }

        private async void btnNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            try { 
            var content = await client.GetStringAsync(Url);
            List<WSClase6.Datos> posts = JsonConvert.DeserializeObject<List<WSClase6.Datos>>(content);
            _post = new ObservableCollection<WSClase6.Datos>(posts);
            MyListView.ItemsSource = _post;
            var msj = "Datos Cargados";
            DependencyService.Get<Mensaje>().alertShort(msj);
            }
            catch (Exception ex)
            {
                await DisplayAlert("ALERTA", ex.Message, "OK");
            }
        }

         void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Datos)e.SelectedItem;
            var item = Obj.codigo.ToString();
            var nombre = Obj.nombre.ToString();
            var apellido = Obj.apellido.ToString();
            var item2 = Obj.edad.ToString();

            int codigo = Convert.ToInt32(item);
            int edad = Convert.ToInt32(item2);
            try
            {
                Navigation.PushAsync(new Actualizar(codigo, nombre, apellido, edad));
            }catch ( Exception)
            {
                
            }
        }
    }
}