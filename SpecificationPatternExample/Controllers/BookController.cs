using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecificationPatternExample.Data;
using SpecificationPatternExample.Model;
using SpecificationPatternExample.Repository;
using SpecificationPatternExample.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationPatternExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITestInterface _test;
        private readonly IGenericRepository<Book> _genericRepository;
        public BookController(ApplicationDbContext context,ITestInterface test,
            IGenericRepository<Book> genericRepository)
        {
            _context = context;
            _test = test;
            _genericRepository = genericRepository;
        }
        [HttpPost("List")]
        public async Task<IActionResult>AddInfoList()
        {

            List<Publisher> publishers = new List<Publisher> {
            new Publisher { Name = "Sameh", Age = 30,
            Books=new List<Book> {
                new Book{Title="Software Enginering",NumberOfPage=700,Price=1000},
                new Book {Title="DotNet Framework",NumberOfPage=300,Price=500 } },
            Address=new Address { Country = "USA", State = "NY", ZipCode = 50700 }

            },
              new Publisher { Name = "Rana", Age = 30,
            Books=new List<Book> {
                new Book{Title="Laravel",NumberOfPage=500,Price=750 } },

            Address=new Address { Country = "Malaysia", State = "KL", ZipCode = 50900 }
            },
                new Publisher { Name = "Yousef", Age = 25,
            Books=new List<Book> {
                new Book{Title="Software Developer",NumberOfPage=900,Price=100},
          },
            Address=new Address { Country = "Syria", State = "Ezraa", ZipCode = 50700 }
            }
            };
               
          
           
            await _context.Publishers.AddRangeAsync(publishers);
           await _context.SaveChangesAsync();
            return Ok(201);
            
        }
        [HttpPost("Single")]
        public async Task<IActionResult> AddInfoSingle()
        {
            Publisher publisher = new Publisher
            {
                Name = "Sameh",
                Age = 30,
                Books = new List<Book> {
                new Book{Title="Software Principle",NumberOfPage=700,Price=1000},
                new Book {Title="EF Framework",NumberOfPage=300,Price=500 } },
                Address = new Address { Country = "Malaysia", State = "KL", ZipCode = 50100 }

            };
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return Ok(201);
        }
        [HttpGet("CheckInterface")]
        public ActionResult<string> CheckInterface()
        {
            var response = _test.Name;
            return Ok(response);
        }
        [HttpGet("Normal")]
        public async Task<ActionResult<BookResponeDto>> Normal()
        {
            var response = await _context.Books.Include(p => p.Publisher).ThenInclude(a => a.Address).ToListAsync();
            List<BookResponeDto> bookResponeDto = new  List<BookResponeDto>();
            bookResponeDto = response.Select(i => new BookResponeDto
            {
                BookId = i.BookId,  
                NumberOfPage = i.NumberOfPage,
                Title= i.Title,
                Price=i.Price,
                Name=i.Publisher.Name,
                Age=i.Publisher.Age,
                AddressId = i.Publisher.AddressId,
                Country = i.Publisher.Address.Country,
                State =i.Publisher.Address.Country,
                ZipCode=i.Publisher.Address.ZipCode
            }).ToList();
            
            return Ok(bookResponeDto);
        }
        [HttpGet("Spec")]
        public async Task<ActionResult<BookResponeDto>> Spec()
        {
            BookSpecification spec = new BookSpecification(10);
            var response=await _genericRepository.OurListAsyncWithSpec(spec); ;
            List<BookResponeDto> bookResponeDto = new List<BookResponeDto>();
            bookResponeDto = response.Select(i => new BookResponeDto
            {
                BookId = i.BookId,
                NumberOfPage = i.NumberOfPage,
                Title = i.Title,
                Price = i.Price,
                Name = i.Publisher.Name,
                Age = i.Publisher.Age,
                AddressId = i.Publisher.AddressId,
                Country = i.Publisher.Address.Country,
                State = i.Publisher.Address.Country,
                ZipCode = i.Publisher.Address.ZipCode
            }).ToList();

            return Ok(bookResponeDto);
        }
    }
}
