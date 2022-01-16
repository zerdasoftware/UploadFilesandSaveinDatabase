using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using UploadFilesandSaveinDatabase.Models;

namespace UploadFilesandSaveinDatabase.Controllers
{
    public class DemoController : Controller
    {
        private readonly DatabaseContext _context;

        public DemoController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);
                    var fileExtension= Path.GetExtension(fileName);
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()),fileExtension);
                    var objFiles = new Files()
                    {
                        DocumentId=0,
                        Name=newFileName,
                        FileType=fileExtension,
                        CreatedOn=DateTime.Now
                    };
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objFiles.DataFiles = target.ToArray();
                    }
                    _context.Files.Add(objFiles);
                    _context.SaveChanges();
                }
            }
            return View();
        }
    }
}
