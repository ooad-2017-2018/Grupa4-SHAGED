using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SEATuristickaAgencijaOOAD.Models
{
    public class BooksSearch
    {
        
       private static BooksService _booksService;
        public BooksSearch()
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCWsmbRBqcj1ycgw2Ki96PT0yx4OBMKBro",
                ApplicationName = this.GetType().ToString()
            });
        }
        public static Tuple<int?, List<Knjiga>> Search(string query)
        {
            var listquery = _booksService.Volumes.List(query);
            listquery.MaxResults = 10;
            var res = listquery.Execute();
            var books = res.Items.Select(b => new Knjiga(b.VolumeInfo.Title, b.VolumeInfo.Categories.ToString())).ToList();
            return new Tuple<int?, List<Knjiga>>(res.TotalItems, books);
        }
        /*
         * BooksSearch a = new BooksSearch();
         *var x = BooksSearch.Search("tourism");
         * x.Item2*/
    }
}