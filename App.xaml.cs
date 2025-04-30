namespace bguallasaminS5
{
    public partial class App : Application
    {
        public static Repositorio.PersonaRepositorio PersonaRep { get; set; }
        public App(Repositorio.PersonaRepositorio repositorioPersona)
        {
            InitializeComponent();
            PersonaRep = repositorioPersona;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Vista.vHome());
        }
    }
}