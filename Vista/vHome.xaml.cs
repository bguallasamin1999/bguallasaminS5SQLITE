using bguallasaminS5.Modelo;

namespace bguallasaminS5.Vista;

public partial class vHome : ContentPage
{
    private Persona personaSeleccionada;
	public vHome()
	{
		InitializeComponent();
        listPersonas.SelectionChanged += ListPersonas_SelectionChanged;
    }

    private void ListPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            personaSeleccionada = (Persona)e.CurrentSelection[0];
            txtNombre.Text = personaSeleccionada.Nombre;
            statusMessage.Text = $"Seleccionado: {personaSeleccionada.Id}";
        }
    }


    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.PersonaRep.insertarPersona(txtNombre.Text);
        statusMessage.Text = App.PersonaRep.statusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> personas = App.PersonaRep.obtenerPersonas();
        listPersonas.ItemsSource = personas;

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada != null)
        {
            personaSeleccionada.Nombre = txtNombre.Text;
            App.PersonaRep.actualizarPersona(personaSeleccionada);
            statusMessage.Text = App.PersonaRep.statusMessage;
            listPersonas.ItemsSource = App.PersonaRep.obtenerPersonas();
            listPersonas.SelectedItem = null;
            txtNombre.Text = "";
        }
        else
        {
            statusMessage.Text = "Por favor seleccione una persona.";
        }
    }
    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada != null)
        {
            App.PersonaRep.eliminarPersona(personaSeleccionada.Id);
            statusMessage.Text = App.PersonaRep.statusMessage;
            listPersonas.ItemsSource = App.PersonaRep.obtenerPersonas();
            txtNombre.Text = "";
            personaSeleccionada = null;
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para eliminar.";
        }
    }

    private void btnLimpiar_Clicked(object sender, EventArgs e)
    {
        personaSeleccionada = null;
        txtNombre.Text = "";
        listPersonas.SelectedItem = null;
        statusMessage.Text = "";
    }

}