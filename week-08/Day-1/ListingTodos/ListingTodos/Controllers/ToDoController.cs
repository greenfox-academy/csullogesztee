﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListingTodos.Models;
using ListingTodos.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListingTodos.Controllers
{
    [Route("")]
    public class ToDoController : Controller
    {
        public TodoRepository todoRepository;

        public ToDoController(TodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }

        //[Route("todo")]
        //public IActionResult FilterToDo([FromQuery] bool isActive)
        //{
        //    //http://localhost:53454/todo/?isActive=true
        //    var ActiveToDos = todoRepository.ListOfToDos().Where(t => t.IsDone != isActive).ToList();
        //    return View("List", ActiveToDos);
        //}

        [Route("")]
        [HttpGet("list")]
        public IActionResult List()
        {
            return View(todoRepository.ListOfToDos());
        }

        //[Route("add")]
        //public IActionResult AddToDo([FromQuery] string title, [FromQuery] bool isDone)
        //{
        //    //http://localhost:53454/add/?title=swim&isDone=true
        //    ToDo newToDo = new ToDo()
        //    {
        //        Title = title,
        //        IsDone = isDone
        //    };

        //    todoRepository.AddNewTodo(newToDo);
        //    return RedirectToAction("list");
        //}

        [HttpPost("add")]
        public IActionResult Add(string title)
        {
            ToDo newToDo = new ToDo()
            {
                Title = title
            };

            todoRepository.AddNewTodo(newToDo);
            return RedirectToAction("list");
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(long id)
        {
            todoRepository.DeleteToDo(id);
            return RedirectToAction("list");
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(ToDo toDo, long id)
        {
            todoRepository.Edit(toDo, id);
            return RedirectToAction("list");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(long id)
        {
            var currentTodo = todoRepository.toDoContext.ToDos.FirstOrDefault(x => x.Id == id);
            return View(currentTodo);
        }
    }
}
