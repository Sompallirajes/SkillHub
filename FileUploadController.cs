using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetSkillSchool.Models;


namespace DotNetSkillSchool.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ApplictionContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(ApplictionContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var files = _context.Files.ToList();
            return View(files);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // ✅ Sanitize filename (remove # and spaces)
                string originalName = file.FileName;
                string safeFileName = Path.GetFileNameWithoutExtension(originalName)
                                        .Replace("#", "Sharp")
                                        .Replace(" ", "_") +
                                        Path.GetExtension(originalName);

                string filePath = Path.Combine(uploadFolder, safeFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var uploadedFile = new FileUpload
                {
                    FileName = originalName,                 // Keep original name
                    FilePath = "/uploads/" + safeFileName    // But store safe file path
                };

                _context.Files.Add(uploadedFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
