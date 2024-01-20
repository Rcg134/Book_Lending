using Book_Lending.Context;
using Book_Lending.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Book_Lending.DTO.Book;
using ATEC_BOOK_LENDING.GenericClass;
using AutoMapper;
using Book_Lending.Models.Book;
namespace Book_Lending.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookContext _bookContext;
        private readonly IMapper _mapper;

        Pagination _pagination = new Pagination();
        
        public HomeController(ILogger<HomeController> logger,
                              BookContext bookContext,
                              IMapper mapper)
        {
            _logger = logger;
            _bookContext = bookContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page=1,
                                               int pageSize=2)
        {
            var getBookDTOquery = _bookContext.
                Users.OrderBy(orderUser => orderUser.Name).
                Select(user => _mapper.Map<UserDTO>(user));


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

        public async Task<IActionResult> AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(User addUser)
        {
            var isExist = _bookContext.Users.Any(user => user.Name == addUser.Name);
            if (ModelState.IsValid && !isExist)
            {
                addUser.Active = true;
                addUser.CreatedDate = DateTime.Now;
                _bookContext.Users.Add(addUser);
                _bookContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addUser);
        }



        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
