using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.UndoRedo
{
    public class PdfProjectState
    {
        public List<PdfPageState> PdfPages { get; set; } = new();
        public string Title { get; set; } = "";

        public PdfProjectState Clone()
        {
            return new PdfProjectState
            {
                PdfPages = [.. PdfPages],
                Title = Title,
            };
        }
    }
}
