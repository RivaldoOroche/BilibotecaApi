namespace Biblioteca.Cliente.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteCliente
        {
            //Para Leer
            public const string GetAll = Base+ "/cliente/all";
            public const string GetById = Base+ "/cliente/{id}";

            //Write
            public const string Create = Base + "/cliente/create";
            public const string Update = Base + "/cliente/update";
            public const string Delete = Base + "/cliente/delete";



        }


    }
}
