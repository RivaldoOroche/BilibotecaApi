namespace Biblioteca.Cliente.Api.Routes
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class RouteProducto
        {
            //Para Leer
            public const string GetAll = Base+ "/cliente/all";
            public const string GetById = Base+ "/cliente/{id}";

            //Write
            public const string Create = Base + "/producto/create";
            public const string Update = Base + "/producto/update";
            public const string Delete = Base + "/producto/delete";



        }


    }
}
