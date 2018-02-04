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
	public partial class AgendamentoView : ContentPage
	{

        public Automovel Automovel { get; set; }
        public string Nome { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        private DateTime dataAgendamento;
        public DateTime DataAgendamento { get { return DateTime.Today; } set { dataAgendamento = value;}}

        private TimeSpan horaAgendamento;
        public TimeSpan HoraAgendameto { get { return horaAgendamento; } set { horaAgendamento = value; } }

        public AgendamentoView (Automovel automovel)
		{
			InitializeComponent ();
            BindingContext = this;

            this.Automovel = automovel;

		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", $"Nome: {Nome}\nPhone: {Phone}\nEmail: {Email}\nData Agendamento: {DataAgendamento.ToString("dd/MM/yyyy")} {HoraAgendameto.ToString()}","OK");
        }
    }
}