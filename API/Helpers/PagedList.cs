using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public  class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> items , int count , int pagenumber , int pagesize)
        {
            CurrentPage  = pagenumber;

            TotalPages = (int)Math.Ceiling(count / (double)pagesize);

            pagesize = pagesize;

            TotalCount = count;

            AddRange(items);

        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }


        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int poagenumber , int pagesize)
        {
            var count  = await source.CountAsync();
            var items = await source.Skip((poagenumber - 1) * pagesize).Take(pagesize).ToListAsync();


            return new PagedList<T>(items, count, poagenumber, pagesize);
        }

    }
}
