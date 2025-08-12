using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace PRO131_01.Extentions
{
    public static class FilterExtention1
    {
        public static ICollection<T> TimKiem<T>(this ICollection<T> source, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return source;

            var stringProperties = typeof(T).GetProperties()
                                            .Where(prop => prop.PropertyType == typeof(string));

            // Không dùng StringComparison, dùng ToLower() để tránh lỗi Dynamic LINQ
            string filterExp = string.Join(" || ",
                stringProperties.Select(p => $"{p.Name}.ToLower().Contains(@0)")
            );

            return source.AsQueryable()
                         .Where(filterExp, search.ToLower())
                         .ToList();
        }
    }
}
