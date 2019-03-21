using StructureMap;

namespace Personal
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            Scan(_ =>
            {
                _.Assembly("Personal.Domain");
                _.LookForRegistries();
            });
        }
    }
}