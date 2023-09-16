using LinqKit;
using shop.domain.Extensions;
using shop.domain.Models.Entities;
using shop.domain.Models.Parameters;
using System.Linq.Expressions;

namespace shop.infra.data.FilterDefinitions.LambdaFilter;

public class ProductCategoryLambdaFilter
{
    public static Expression<Func<ProductCategory, bool>> Build(ProductCategoryParameters parameters)
    {
        var predicate = PredicateBuilder.New<ProductCategory>(true);

        if (parameters.Name.IsNotNull())
        {
            predicate = predicate.And(pc => pc.Name.ToLower().Trim().StartsWith(parameters.Name.ToLower().ToLower().Trim()));
        }

        if (parameters.IsActive.IsNotNull())
        {
            predicate = predicate.And(pc => pc.IsActive.Equals(parameters.IsActive));
        }

        return predicate;
    }
}