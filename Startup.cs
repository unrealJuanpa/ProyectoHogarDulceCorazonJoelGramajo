using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoHogarDulceCorazonJoelGramajo.Startup))]
namespace ProyectoHogarDulceCorazonJoelGramajo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
