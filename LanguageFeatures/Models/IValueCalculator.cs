using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}