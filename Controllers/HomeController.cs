using Book_Lending.Context;
using Book_Lending.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Book_Lending.DTO.Book;
using ATEC_BOOK_LENDING.GenericClass;
namespace Book_Lending.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookContext _bookContext;

        Pagination _pagination = new Pagination();
        
        public HomeController(ILogger<HomeController> logger, BookContext bookContext)
        {
            _logger = logger;
            _bookContext = bookContext;
        }

        public async Task<IActionResult> Index(int page=1 ,int pageSize=4)
        {
            var getBookDTOquery = _bookContext.Users.Select(usrDTO => new UserDTO
            {
               UserId = usrDTO.UserId,
               Name = usrDTO.Name,
               MiddleName = usrDTO.MiddleName,
               Surname = usrDTO.Surname,
               CreatedDate = usrDTO.CreatedDate,
            }).OrderBy(orderUsrDTO => orderUsrDTO.Name);

            var (Ipage, totalPages, IpageSize, totalRecords) = 
                _pagination.CalculateTotalRecordsAndPages(getBookDTOquery, page, pageSize);

            ViewBag.CurrentPage = Ipage; 
            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = IpageSize;

            var bookPaginatedList = await getBookDTOquery.
                 Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
               

            return View(bookPaginatedList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
