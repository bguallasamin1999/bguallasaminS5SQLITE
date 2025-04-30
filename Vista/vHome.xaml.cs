using bguallasaminS5.Modelo;

namespace bguallasaminS5.Vista;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.PersonaRep.insertarPersona(txtNombre.Text);
        statusMessage.Text = App.PersonaRep.statusMessage;
    }

    private void btnLiustar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> personas = App.PersonaRep.obtenerPersonas();
        listPersonas.ItemsSource = personas;

    }
}