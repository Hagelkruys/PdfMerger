using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.DocumentInfo
{
    internal struct DocumentData
    {
        public DocumentData()
        {
        }

        public string FilePath { get; set; } = string.Empty;
        public string FileName => System.IO.Path.GetFileName(FilePath);
        public int PageCount { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Creator { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime LastModified { get; set; }
        public DateTime CreationTime { get; set; }

        public override string ToString() => $"{FileName} ({PageCount} pages)";
    }
}
