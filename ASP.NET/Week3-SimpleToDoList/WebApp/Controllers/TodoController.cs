using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers;

public class TodoController(IToDoServices toDoServices) : Controller
{
    private readonly IToDoServices _toDoServices = toDoServices;

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "To Do List";
        ToDoViewModel viewModel = new ToDoViewModel();
        viewModel.toDoModels = await _toDoServices.GetAll();
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ToDoViewModel model)
    {
        ViewData["Title"] = "To Do List";
        if (!ModelState.IsValid)
        {
            model.toDoModels = await _toDoServices.GetAll();
            return View(model);
        }

        await _toDoServices.Create(model.toDoRegistrationForm);

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        ViewData["Title"] = "To Do List";
        if (id == 0)
        {
            return BadRequest();
        }

        await _toDoServices.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id)
    {
        ViewData["Title"] = "To Do List";
        Debug.WriteLine("Update called");
        if (id == 0)
        {
            return BadRequest();
        }

        await _toDoServices.Update(id);
        return RedirectToAction(nameof(Index));
    }
}
