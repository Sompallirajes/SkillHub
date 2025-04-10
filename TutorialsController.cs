using Microsoft.AspNetCore.Mvc;
using DotNetSkillSchool.Models;
using System.Collections.Generic;
using System.Linq;

namespace DotNetSkillSchool.Controllers
{
    public class TutorialsController : Controller
    {
        private static List<Tutorial> tutorials = new()
        {
            new Tutorial
            {
                Id = 1,
                Title = "Introduction to HTML and CSS",
                Category = "Frontend",
                Theory = @"🔹 What is HTML?
HTML (HyperText Markup Language) is the standard markup language for creating web pages.

🔹 What is CSS?
CSS (Cascading Style Sheets) is used to style HTML elements and control layout.",
                Code = @"<!DOCTYPE html>
<html>
<head>
  <title>My First Page</title>
  <style>
    h1 { color: blue; }
  </style>
</head>
<body>
  <h1>Hello World</h1>
</body>
</html>"
            },
            new Tutorial
            {
                Id = 2,
                Title = "C# Basics",
                Category = "Backend",
                Theory = @"C# (pronounced 'C-sharp') is a modern, object-oriented programming language developed by Microsoft.

🔹 C# is widely used for:
- Web apps (ASP.NET Core)
- Desktop apps (WPF, WinForms)
- Mobile apps (Xamarin/.NET MAUI)
- Game development (Unity)",
                Code = @"using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(""Hello C#"");
    }
}"
            },
            new Tutorial
            {
                Id = 3,
                Title = "ASP.NET Core MVC Basics",
                Category = "Backend",
                Theory = @"ASP.NET Core is a cross-platform framework for building web applications and APIs.

🔹 Core Concepts:
- Controllers: Handle logic
- Views: Display UI
- Models: Carry data
- Routing: Match URLs to actions",
                Code = @"public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}"
            },
            new Tutorial
            {
                Id = 4,
                Title = "Angular with TypeScript",
                Category = "Frontend",
                Theory = @"Angular is a front-end framework developed by Google.

🔹 Benefits:
- Component-based
- Uses TypeScript
- Great for Single Page Applications (SPAs)",
                Code = @"import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<h1>Hello Angular</h1>`
})
export class AppComponent { }"
            }
        };

        public IActionResult Index()
        {
            return View(tutorials);
        }

        public IActionResult Details(int id)
        {
            var tutorial = tutorials.FirstOrDefault(t => t.Id == id);
            if (tutorial == null)
                return NotFound();

            return View(tutorial);
        }
    }
}
