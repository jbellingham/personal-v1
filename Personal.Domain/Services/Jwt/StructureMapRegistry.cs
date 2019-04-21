using StructureMap;

namespace Personal.Domain.Services.Jwt
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            this.For<IJwtBuilder>().Use<JwtBuilder>();
        }
    }
}