using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersApp.Data
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int PreviousFolderId { get; set; }
        public ICollection<FolderLink>? SubFolders { get; set; }       
        

        public Folder() { }        
    }
}
