using LinqKit;
using shop.domain.Entities;
using shop.domain.Extensions;
using shop.domain.Parameters;
using System.Linq.Expressions;

namespace shop.infra.data.FilterDefinitions.LambdaFilter;

public static class ProductLambdaFilter
{
    public static Expression<Func<Product, bool>> Build(ProductParameters parameters) 
    {
        var predicate = PredicateBuilder.New<Product>(true);

        if (parameters.Name.IsNotNull())
        {
            predicate = predicate.And(p => p.Name.ToLower().Trim().StartsWith(parameters.Name.ToLower().Trim()));
        }

        if (parameters.IsPerishable.IsNotNull())
        {
            predicate = predicate.And(p => p.IsPerishable.Equals(parameters.IsPerishable));
        }

        if (parameters.IsActive.IsNotNull())
        {
            predicate = predicate.And(p => p.IsActive.Equals(parameters.IsActive));
        }

        if (parameters.ProductCategoryId > 0)
        {
            predicate = predicate.And(p => p.ProductCategoryId.Equals(parameters.ProductCategoryId));
        }

        return predicate;
    }
}
