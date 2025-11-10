using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.DocumentInfo
{
    internal static class DocumentRegistry
    {
        public static Dictionary<string, DocumentData> Documents { get; private set; } = new();

        public static void AddOrUpdate(DocumentData doc)
        {
            Documents[doc.FilePath] = doc;
        }

        public static bool TryGet(string path, out DocumentData doc)
            => Documents.TryGetValue(path, out doc);

        public static void Clear()
        {
            Documents.Clear();
        }
    }
}
