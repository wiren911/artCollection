using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtCollection.Startup))]
namespace ArtCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
