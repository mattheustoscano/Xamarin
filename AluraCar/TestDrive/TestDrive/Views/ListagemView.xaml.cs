using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestDrive.Entidades;


namespace TestDrive.Views
{
	public partial class ListagemView : ContentPage
	{

        public List<Automovel> Lista { get; set; }

        public ListagemView()
		{
			InitializeComponent();

            Lista = new List<Automovel>()
            {
              new Automovel("Azera V6", 50000m),
              new Automovel("HB20",70000m)
            };


            LtVeiculos.ItemsSource = Lista;

            BindingContext = this.BindingContext; 
          

        }

        private void LtVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            var veiculo = e.Item as Automovel;
            

            Navigation.PushAsync(new DetalheView());



        }
    }
}
