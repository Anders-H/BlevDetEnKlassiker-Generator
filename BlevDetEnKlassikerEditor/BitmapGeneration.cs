using System.Drawing.Imaging;

namespace BlevDetEnKlassikerEditor;

public static class BitmapGeneration
{
    private static Bitmap? _template;
    private const string TemplateFilename = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\avsnittsbild400x400.png";

    public static Bitmap CreateBitmap(int episodeNumber, string list1Name, int list1Year, string list2Name, int list2Year)
    {
        _template ??= new Bitmap(TemplateFilename);
        var bmp = new Bitmap(_template.Width, _template.Height);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.DrawImage(_template, 0, 0, 400, 400);
        using var font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);
        using var brush = new SolidBrush(Color.White);
        using var shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));

        var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        for (var i = -1; i < 4; i++)
        {
            DrawShadow(-1, i);
            DrawShadow(0, i);
            DrawShadow(1, i);
            DrawShadow(2, i);
        }

        void DrawShadow(int x, int y)
        {
            g.DrawString($"Avsnitt {episodeNumber:00}", font, shadowBrush, new RectangleF(0 + x, 120 + y, bmp.Width, 40), format);
            g.DrawString($"{list1Name} ({list1Year})", font, shadowBrush, new RectangleF(0 + x, 290 + y, bmp.Width, 40), format);
            g.DrawString("och", font, shadowBrush, new RectangleF(0 + x, 322 + y, bmp.Width, 40), format);
            g.DrawString($"{list2Name} ({list2Year})", font, shadowBrush, new RectangleF(0 + x, 350 + y, bmp.Width, 40), format);
        }

        g.DrawString($"Avsnitt {episodeNumber:00}", font, brush, new RectangleF(0, 120, bmp.Width, 40), format);
        g.DrawString($"{list1Name} ({list1Year})", font, brush, new RectangleF(0, 290, bmp.Width, 40), format);
        g.DrawString("och", font, brush, new RectangleF(0, 322, bmp.Width, 40), format);
        g.DrawString($"{list2Name} ({list2Year})", font, brush, new RectangleF(0, 350, bmp.Width, 40), format);
        return bmp;
    }

    public static void SaveForEpisode(Bitmap bitmap, int episodeNumber, bool includeMp3Image)
    {
        var fi = new DirectoryInfo(MainWindow.OutputFolderEpisodeGraphics);

        if (!fi.Exists)
            fi.Create();

        if (includeMp3Image)
            bitmap.Save(Path.Combine(MainWindow.EpisodeImageOutputFolder, $"{episodeNumber:00}.png"), ImageFormat.Png);

        var jpegCodec = ImageCodecInfo.GetImageEncoders().First(enc => enc.FormatID == ImageFormat.Jpeg.Guid);
        var jpegParams = new EncoderParameters(1);
        jpegParams.Param = [new EncoderParameter(Encoder.Quality, 100L)];
        bitmap.Save(Path.Combine(MainWindow.OutputFolderEpisodeGraphics, $@"{episodeNumber:00}.jpg"), jpegCodec, jpegParams);

        using var thumb = new Bitmap(100, 100);
        using var g = Graphics.FromImage(thumb);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.DrawImage(bitmap, 0, 0, 100, 100);
        jpegParams = new EncoderParameters(1);
        jpegParams.Param = [new EncoderParameter(Encoder.Quality, 90L)];
        thumb.Save(Path.Combine(MainWindow.OutputFolderEpisodeGraphics, $@"{episodeNumber:00}_.jpg"), jpegCodec, jpegParams);
    }
}