namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;

        public DataService(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDb()
        {
            this.contexto.Database.EnsureCreated();
        }
    }
}


