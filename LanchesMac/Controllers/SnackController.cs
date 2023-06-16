using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;

        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                snacks = _snackRepository.Snacks.OrderBy(l => l.SnackId);
                currentCategory = "Todos os lanches";
            }
            else
            {
                //if (string.Equals("Normal", category, StringComparison.OrdinalIgnoreCase)) 
                //{
                //    snacks = _snackRepository.Snacks
                //        .Where(l => l.Category.CategoryName.Equals("Normal"))
                //        .OrderBy(l => l.SnackName);
                //}
                //else
                //{
                //    snacks = _snackRepository.Snacks
                //        .Where(l => l.Category.CategoryName.Equals("Natural"))
                //        .OrderBy(l => l.SnackName);
                //}

                snacks = _snackRepository.Snacks
                    .Where(s => s.Category.CategoryName.Equals(category))
                    .OrderBy(c => c.SnackName );
                currentCategory = category;
            }

            var snackListViewModel = new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory,

            };

            return View(snackListViewModel);

        }

        public IActionResult Details(int snackId) 
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(s => s.SnackId == snackId);

            return View(snack);
        }

        public ViewResult Search(string searchString) 
        {
            IEnumerable<Snack> snacks;
            string currentCategory = string.Empty;
            
            if (string.IsNullOrEmpty(searchString))
            {
                snacks = _snackRepository.Snacks.OrderBy(p => p.SnackId);
                currentCategory = "Todos os lanches";
            }
            else
            {
                snacks = _snackRepository.Snacks
                    .Where(p => p.SnackName.ToLower()
                    .Contains(searchString.ToLower()));

                if (snacks.Any() )
                {
                    currentCategory = "Lanches";
                }
                else
                {
                    currentCategory = "Nenhum lanche foi encontrado";
                }
            }

            return View("~/Views/Snack/List.cshtml", new SnackListViewModel
            {
                Snacks = snacks,
                CurrentCategory = currentCategory
            });
        }
    }
}
