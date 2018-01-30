using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestDrive.Entidades;

namespace TestDrive
{
	public partial class MainPage : ContentPage
	{

        public List<Automovel> Lista { get; set; }

        public MainPage()
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

      
    }
}
