using Asp.Common.SessionConfig;
using Asp.DALL.Entites;
using Asp.DALL.Repositray;
using Asp.DALL.Viewmodel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace ProjectMohammadRepositry.Controllers
{
    public class AuthorssController : BaseController
    {
        private readonly IRepositoryBase<Author> _repo;
        private IMapper _mapper;
        private readonly ISessionConfigService _sessionService;

        public AuthorssController(IRepositoryBase<Author> repo,
            IMapper mapper,
           ISessionConfigService SessionService

            ):base(SessionService)
        {
            _repo = repo;
            _mapper = mapper;
            _sessionService = SessionService;

            
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LoadDataGrid()
        {
            List<Author> lists = await _repo.GetList();
            List<AuthorVM> viewmodel = _mapper.Map<List<Author>, List<AuthorVM>>(lists);
           
            return Json(viewmodel);
        }

        public async Task<IActionResult> Form(int ? id)
        {
            AuthorVM vm = new AuthorVM();
           if(id==0 || id == null)
            {

                return PartialView();
            }
            else
            {
                Author entity = await _repo.GetOne(z => z.Id == id);
                vm = _mapper.Map<Author, AuthorVM>(entity);
                return PartialView(vm);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Form(AuthorVM insert)
        {
            Author model;
            model = _mapper.Map<AuthorVM, Author>(insert);
            bool done = false;
            if (insert.Id==0 || insert.Id==null) {

                done=await _repo.Add(model);

            
            }
            else
            {
                done=await _repo.Update(model);
            }
            return Json(new { done });

        }

        public async Task<IActionResult> Delete(int?id)
        {
            return PartialView(await _repo.GetOne(z => z.Id == id));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Author del)
        {
            bool done = false;
            done=await _repo.Delete(del);
            return Json(new { done = done });

        }
    }
}
