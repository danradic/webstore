﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebStore.Website.Models;
using WebStore.Website.ViewModels;

namespace WebStore.Website.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPieRepository _pieRepository;

    public HomeController(ILogger<HomeController> logger,
        IPieRepository pieRepository)
    {
        _logger = logger;
        _pieRepository = pieRepository;
    }

    public IActionResult Index()
    {
        var piesOfTheWeek = _pieRepository.PiesOfTheWeek;

        if (piesOfTheWeek == null || !piesOfTheWeek.Any()) return NotFound();

        return View(new HomeViewModel(piesOfTheWeek));
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
