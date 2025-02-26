﻿using API.Helpers;
using System.Text.Json;

namespace API.Extensions
{
    public  static class HttpExtension
    {

        public static void AddPaginationHeader<T>(this HttpResponse response, PagedList<T> data)
        {
           var paginationheader = new PaginationHeader(data.CurrentPage , data.PageSize, data.TotalCount, data.TotalPages);
           var jsonOptions = new JsonSerializerOptions
           {
               PropertyNamingPolicy = JsonNamingPolicy.CamelCase
           };

            response.Headers.Append("Pagination", JsonSerializer.Serialize(paginationheader, jsonOptions));
            response.Headers.Append("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
