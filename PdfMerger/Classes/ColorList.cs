using System.Drawing.Drawing2D;

namespace PdfMerger.Classes
{
    public static class ColorList
    {
        private static readonly List<Color> m_Colors = new()
        {
            // Mixed order for visual distinction (blue → green → red → purple → yellow → gray → pastel → etc.)
            Color.FromArgb(0xFF, 0x64, 0xB5, 0xF6), // Blue
            Color.FromArgb(0xFF, 0x81, 0xC7, 0x84), // Green
            Color.FromArgb(0xFF, 0xE5, 0x73, 0x73), // Soft Red
            Color.FromArgb(0xFF, 0xBA, 0x68, 0xC8), // Lavender
            Color.FromArgb(0xFF, 0xFF, 0xCA, 0x28), // Yellow
            Color.FromArgb(0xFF, 0x90, 0xA4, 0xAE), // Gray
            Color.FromArgb(0xFF, 0xDC, 0xED, 0xC8), // Pastel Lime

            Color.FromArgb(0xFF, 0x42, 0xA5, 0xF5), // Medium Blue
            Color.FromArgb(0xFF, 0x4D, 0xB6, 0xAC), // Teal
            Color.FromArgb(0xFF, 0xEF, 0x53, 0x50), // Red
            Color.FromArgb(0xFF, 0xCE, 0x93, 0xD8), // Violet
            Color.FromArgb(0xFF, 0xFF, 0xB7, 0x4D), // Amber
            Color.FromArgb(0xFF, 0xB0, 0xBE, 0xC5), // Blue-Gray
            Color.FromArgb(0xFF, 0xF9, 0xF0, 0xE1), // Cream

            Color.FromArgb(0xFF, 0x29, 0x79, 0xC2), // Deep Blue
            Color.FromArgb(0xFF, 0x66, 0xBB, 0x6A), // Fresh Green
            Color.FromArgb(0xFF, 0xF4, 0x8F, 0x72), // Coral
            Color.FromArgb(0xFF, 0xAB, 0x47, 0xBC), // Plum
            Color.FromArgb(0xFF, 0xFF, 0xE0, 0x82), // Light Yellow
            Color.FromArgb(0xFF, 0x60, 0x7D, 0x8B), // Slate Gray
            Color.FromArgb(0xFF, 0xE0, 0xF7, 0xFA), // Ice Blue

            Color.FromArgb(0xFF, 0x0D, 0x47, 0xA1), // Navy
            Color.FromArgb(0xFF, 0x43, 0xA0, 0x47), // Dark Green
            Color.FromArgb(0xFF, 0xFF, 0x8A, 0x65), // Orange
            Color.FromArgb(0xFF, 0xE1, 0xBE, 0xE7), // Lilac
            Color.FromArgb(0xFF, 0xFF, 0xC1, 0x07), // Gold
            Color.FromArgb(0xFF, 0x45, 0x55, 0x63), // Charcoal
            Color.FromArgb(0xFF, 0xF3, 0xE5, 0xF5), // Soft Lavender

            Color.FromArgb(0xFF, 0x90, 0xCA, 0xF9), // Sky Blue
            Color.FromArgb(0xFF, 0xA5, 0xD6, 0xA7), // Leaf Green
            Color.FromArgb(0xFF, 0xF0, 0x91, 0xA9), // Rose Pink
            Color.FromArgb(0xFF, 0x8E, 0x24, 0xAA), // Deep Purple
            Color.FromArgb(0xFF, 0xFF, 0xE0, 0xB2), // Sand
            Color.FromArgb(0xFF, 0xCF, 0xD8, 0xDC), // Light Gray
            Color.FromArgb(0xFF, 0xFF, 0xF9, 0xC4), // Soft Cream

            Color.FromArgb(0xFF, 0xBB, 0xDE, 0xFB), // Light Sky
            Color.FromArgb(0xFF, 0x4D, 0xB6, 0xAC), // Seafoam
            Color.FromArgb(0xFF, 0xAD, 0x14, 0x57), // Magenta
            Color.FromArgb(0xFF, 0x7B, 0x1F, 0xA2), // Indigo
            Color.FromArgb(0xFF, 0xFF, 0xA7, 0x26), // Bright Orange
            Color.FromArgb(0xFF, 0x26, 0x32, 0x38), // Jet Gray
            Color.FromArgb(0xFF, 0xC8, 0xE6, 0xC9), // Pastel Green

            Color.FromArgb(0xFF, 0x29, 0x79, 0xC2),
            Color.FromArgb(0xFF, 0x80, 0xDE, 0xEA),
            Color.FromArgb(0xFF, 0xD8, 0x1B, 0x60),
            Color.FromArgb(0xFF, 0xBA, 0x68, 0xC8),
            Color.FromArgb(0xFF, 0xFF, 0xCC, 0x80),
            Color.FromArgb(0xFF, 0x9E, 0x9E, 0x9E),
            Color.FromArgb(0xFF, 0xF9, 0xEB, 0xEA),

            Color.FromArgb(0xFF, 0x81, 0xD4, 0xFA),
            Color.FromArgb(0xFF, 0x4D, 0xB6, 0xAC),
            Color.FromArgb(0xFF, 0xF4, 0x9F, 0xC1),
            Color.FromArgb(0xFF, 0x9F, 0xA8, 0xDA),
            Color.FromArgb(0xFF, 0xFF, 0xB7, 0x4D),
            Color.FromArgb(0xFF, 0x8D, 0x6E, 0x63),
            Color.FromArgb(0xFF, 0xB2, 0xDF, 0xDB),

            Color.FromArgb(0xFF, 0x29, 0x79, 0xC2),
            Color.FromArgb(0xFF, 0xA1, 0xD8, 0x89),
            Color.FromArgb(0xFF, 0xF0, 0xB4, 0xC3),
            Color.FromArgb(0xFF, 0xB3, 0xE5, 0xFC),
            Color.FromArgb(0xFF, 0xFF, 0xA7, 0x26),
            Color.FromArgb(0xFF, 0xB0, 0x91, 0x6F),
            Color.FromArgb(0xFF, 0xFF, 0xF3, 0xE0),

            // Earthy Neutrals + Extra accents
            Color.FromArgb(0xFF, 0x5D, 0x40, 0x37),
            Color.FromArgb(0xFF, 0xB2, 0xDF, 0xDB),
            Color.FromArgb(0xFF, 0xFF, 0xAB, 0x91),
            Color.FromArgb(0xFF, 0xC5, 0xE1, 0xA5),
            Color.FromArgb(0xFF, 0xA1, 0x88, 0x7E),
            Color.FromArgb(0xFF, 0xB0, 0xBE, 0xC5),
            Color.FromArgb(0xFF, 0xEB, 0xEB, 0xEB)
        };


        private static readonly Dictionary<string, int> PDFToColorIdx = new(StringComparer.OrdinalIgnoreCase);
        private static int m_ColorIndex = 0;


        public static int GetColorIndexForPdf(string pdfPath)
        {
            if (PDFToColorIdx.TryGetValue(pdfPath, out var colorIdx))
                return colorIdx;

            colorIdx = m_ColorIndex % m_Colors.Count;
            PDFToColorIdx[pdfPath] = colorIdx;
            m_ColorIndex++;
            return colorIdx;
        }

        public static Bitmap GetDotForPdf(string pdfPath)
        {
            var idx = GetColorIndexForPdf(pdfPath);
            return GenerateDot(16, m_Colors[idx]);
        }

        private static Bitmap GenerateDot(int diameter, Color color)
        {
            var bmp = new Bitmap(diameter, diameter);
            using var g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.Transparent);


            // Fill circle
            using (var brush = new SolidBrush(color))
            {
                g.FillEllipse(brush, 2, 2, diameter - 4, diameter - 4);
            }

            return bmp;
        }

        public static void Clear() => PDFToColorIdx.Clear();


        public static Color AdjustBrightness(Color color, float factor)
        {
            int r = Math.Min(255, (int)(color.R * factor));
            int g = Math.Min(255, (int)(color.G * factor));
            int b = Math.Min(255, (int)(color.B * factor));
            return Color.FromArgb(color.A, r, g, b);
        }

        public static ImageList GetImageList()
        {
            var list = new ImageList()
            {
                ImageSize = new Size(20, 20),
                ColorDepth = ColorDepth.Depth32Bit
            };

            foreach (var c in m_Colors)
            {
                var bmp = GenerateDot(20, c);
                list.Images.Add(bmp);
            }

            return list;
        }
    }
}
