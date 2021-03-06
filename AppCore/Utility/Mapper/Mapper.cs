using Mapster;

namespace AppCore.Utility.Mapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
           return source.Adapt<TDestination>();
        }
    }
}
