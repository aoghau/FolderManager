using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoldersApp.Data;
using FoldersApp.Utility;
using System.Xml.Linq;

namespace FoldersApp.Controllers
{
    public class FoldersController : Controller
    {
        private IConfiguration _config;
        private TrackerService _tracker;
        //private int _currentFolderId = 1;

        public FoldersController(IConfiguration config, TrackerService tracker)
        {
            _config = config;
            _tracker = tracker;
            //_currentFolderId = 1;
        }

        [HttpGet("home")]
        public IActionResult OnPageLoaded()
        {            
            using (var context = new FolderDataContext())
            {
                this.UpdateId(1);
                var wrapper = new ListWrapper<Folder>() { List = context.Folders.Where(x => x.PreviousFolderId == _tracker.currentFolderId).ToArray()};
                return new JsonResult(wrapper);
            }
        }

        [HttpGet("page")]
        public IActionResult DisplayFolder()
        {
            using (var context = new FolderDataContext())
            {
                var wrapper = new ListWrapper<Folder>() { List = context.Folders.Where(x => x.PreviousFolderId == _tracker.currentFolderId).ToArray() };
                return new JsonResult(wrapper);
            }
        }

        [HttpGet("name")]
        public IActionResult NavigateDown(string name)
        {
            using (var context = new FolderDataContext())
            {
               int folder = _tracker.currentFolderId;
               int folderLocation = context.Folders.Where(x => x.Name.Equals(name)).FirstOrDefault().Id;
               this.UpdateId(context.Folders.Where(x => x.Name.Equals(name)).FirstOrDefault().Id);
               var wrapper = new ListWrapper<Folder>() { List = context.Folders.Where(x => x.PreviousFolderId == _tracker.currentFolderId).ToArray() };                
               return new JsonResult(wrapper);
            }
        }      
        
        [HttpGet("back")]
        public IActionResult NavigateUp()
        {
            using (var context = new FolderDataContext())
            {
                this.UpdateId(context.Folders.Where(x => x.Id == _tracker.currentFolderId).FirstOrDefault().PreviousFolderId);
                var wrapper = new ListWrapper<Folder>() { List = context.Folders.Where(x => x.PreviousFolderId == _tracker.currentFolderId).ToArray() };
                return new JsonResult(wrapper);
            }
            
        }

        [HttpPost("name")]
        public IActionResult AddFolder(string name)
        {
            using (var context = new FolderDataContext())
            {
                int location = _tracker.currentFolderId;
                Folder folder = new Folder() { Name = name, PreviousFolderId = _tracker.currentFolderId, SubFolders = null };
                //context.Folders.Where(x => x.Id == _currentFolderId).FirstOrDefault().SubFolders.Add(new FolderLink(folder.Id));
                var wrapper = new ListWrapper<Folder>() { List = context.Folders.Where(x => x.PreviousFolderId == _tracker.currentFolderId).ToArray() };
                context.Folders.Add(folder);
                context.SaveChanges();
                return new JsonResult(wrapper);
            }            
        }

        public void UpdateId(int val){
            _tracker.currentFolderId = val;
        }
    }
}
