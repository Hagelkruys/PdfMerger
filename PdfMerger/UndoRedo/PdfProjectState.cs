using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.UndoRedo
{
    public class PdfProjectState
    {
        public List<string> PdfFiles { get; set; } = new();
        public List<int> PageOrder { get; set; } = new();
        public string Title { get; set; } = "";
        public string Author { get; set; } = ""; 

        public PdfProjectState Clone()
        {
            return new PdfProjectState
            {
                PdfFiles = [.. PdfFiles],
                PageOrder = [.. PageOrder],
                Title = Title,
                Author = Author
            };
        }
    }
}
