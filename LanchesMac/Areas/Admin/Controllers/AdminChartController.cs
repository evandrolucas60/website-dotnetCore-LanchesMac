﻿using LanchesMac.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminChartController : Controller
    {
        private readonly ChartSalesService _chartSalesService;

        public AdminChartController(ChartSalesService chartSalesService)
        {
            _chartSalesService = chartSalesService ?? throw new ArgumentNullException(nameof(chartSalesService));
        }

        public JsonResult SnacksSales (int days)
        {
            var snacksTotalSales = _chartSalesService.GetSnacksSales(days);
            return Json(snacksTotalSales);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MonthlySales()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WeeklySales()
        {
            return View();
        }
    }
}
