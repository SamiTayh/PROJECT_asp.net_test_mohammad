using Asp.Common.SessionConfig;
using Asp.DALL.Context;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace ProjectMohammadRepositry.Controllers
{
    public class ProductController : BaseController
    {
        //private readonly ProjectContext _db;
        private readonly IRepositoryBase<Product> _repo;
        private readonly ISessionConfigService _sessionService;
        public ProductController(IRepositoryBase<Product> repo, ISessionConfigService sessionService):base(sessionService) //ProjectContext db)
        {
            //db = _db;
            _repo = repo;
            _sessionService = sessionService;
        }
        public  async Task<IActionResult> Index()
        {
            //List<Product> productList = await  _repo.GetList();
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Product> productList = await _repo.GetList();
            return Json(productList);
        }
     
        public async Task<IActionResult> Form(int? id=0)
        {
        if (id == 0 || id==null)
            {
                return PartialView();

            }
            else
            {
                return PartialView( await _repo.GetOne(z =>z.Id == id));

            }
        }
        [HttpPost]
        public async Task<IActionResult> Form(Product pro)
        {
            bool done=false;
            if (pro.Id == null || pro.Id == null)
            {
                done= await _repo.Add(pro);
            }
            else
            {
                done= await _repo.Update(pro);
            }
            return Json(new {done= done });
        }

        public async Task<IActionResult> Delete(int? id)
        {

            return PartialView(await _repo.GetOne(z => z.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product del)
        {
            bool done = false;
            await _repo.Delete(del);

            return Json(new { done = done });
        }


    }
}
