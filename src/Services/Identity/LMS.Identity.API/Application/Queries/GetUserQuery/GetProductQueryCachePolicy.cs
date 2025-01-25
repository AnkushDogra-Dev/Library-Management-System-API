// using Common.Caching;
// using ProductClient.DTOs;

// namespace ProductMicroservice.Queries
// {
//     public class GetProductQueryCachePolicy : ICachePolicy<GetProductQuery, ProductDto>
//     {
//         public TimeSpan? SlidingExpiration(GetProductQuery query, ProductDto? dto) => TimeSpan.FromMinutes(60);

//         public string GetCacheKey(GetProductQuery query)
//         {
//             return $"GetProductQuery.{query.id}";
//         }
//     }
// }