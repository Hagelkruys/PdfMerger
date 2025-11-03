namespace PdfMerger.Config
{
    public class AppConfig
    {
        public string LastFolder { get; set; } = "";

        public int PdfRenderMaxWidth { get; set; } = 250;
        public int PdfRenderMaxHeight { get; set; } = 350;
        public bool PdfRenderAddBorder { get; set; } = true;
        public bool PdfRenderAddWhiteBackground { get; set; } = true;
        public int PdfRenderAddBorderWidth { get; set; } = 2;

        public int? WindowX { get; set; } = null;
        public int? WindowY { get; set; } = null;
        public int WindowWidth { get; set; } = 1200;
        public int WindowHeight { get; set; } = 800;

        public bool ShowFilenameExtension { get; set; } = true;
        public bool SaveAsBundle { get; set; } = true;
        public bool LoadEveryPageWhenAddingPdf { get; set; } = false;
        public bool ClearProducerMetadata { get; set; } = true;



        public bool SidebarActionExpanded { get; set; } = true;
        public bool SidebarListOfDocsExpanded { get; set; } = true;
        public bool SidebarPreviewSizeExpanded { get; set; } = true;
        public bool SidebarProjectExpanded { get; set; } = true;

        public int BundleCompressionLevel { get; set; } = 0;
    }
}
