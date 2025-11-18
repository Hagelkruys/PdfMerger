namespace PdfMerger.Classes;

public static class ImageStackSizeIndicator
{

    public static int GetStackSize(int pagecount)
    {
        if (pagecount <= 0)
        {
            return 0;
        }

        if (pagecount < 5)
        {
            return 2;
        }

        if (pagecount < 15)
        {
            return 3;
        }

        if (pagecount < 30)
        {
            return 4;
        }

        return 5;
    }
}
