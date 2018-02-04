using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Entidades;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
	{

        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        public Automovel Automovel { get; set; }

        public string TextoFreioAbs {

            get {
                    return $"Freio ABS - R$ {FREIO_ABS}";
                }

        }

        public string TextoArCondicionado
        {

            get
            {
                return $"Ar Condicionado - R$ {AR_CONDICIONADO}";
            }

        }

        public string TextoMP3
        {

            get
            {
                return $"MP3 Player - R$ {MP3_PLAYER}";
            }

        }

        bool temFreioAbs;
        public bool TemFreioAbs {


            get { return temFreioAbs; }
            set {


                temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }


        }

        bool temArCondicionado;
        public bool TemArCondicionado
        {


            get { return temArCondicionado; }
            set
            {


                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }


        }

        bool temMp3Player;
        public bool TemMp3Player
        {


            get { return temMp3Player; }
            set
            {


                temMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));

            }


        }



        public string ValorTotal {

            get

            {

                return $"Valor Total: R$ {Automovel.Preco + (TemFreioAbs ? FREIO_ABS : 0) + (TemMp3Player ? MP3_PLAYER : 0) + (TemArCondicionado ? AR_CONDICIONADO :0)}";

            }


        }


        public DetalheView (Automovel automovel)
		{
			InitializeComponent ();
            Automovel = automovel;
            BindingContext = this;

		}

        private void btnProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Automovel));
        }
    }
}