using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersApp.Data
{
    public class FolderLink
    {
        public FolderLink() { }
        public FolderLink(int id) 
        {
            FolderId = id;
        }
        public int Id { get; set; }
        public int FolderId { get; set; }
    }
}
