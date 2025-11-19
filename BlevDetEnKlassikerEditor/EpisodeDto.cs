using System.Text;

namespace BlevDetEnKlassikerEditor;

public class EpisodeDto
{
    public int EpisodeNumber { get; set; }
    public bool Published { get; set; }
    public string List1Name { get; set; }
    public int List1Year { get; set; }
    public string List2Name { get; set; }
    public int List2Year { get; set; }
    public DateOnly PublishedDate { get; set; }
    public int LengthMinutes { get; set; }
    public int LengthSeconds { get; set; }

    public EpisodeDto(int episodeNumber, bool published, string list1Name, int list1Year, string list2Name, int list2Year, DateOnly publishedDate, int lengthMinutes, int lengthSeconds)
    {
        EpisodeNumber = episodeNumber;
        Published = published;
        List1Name = list1Name;
        List1Year = list1Year;
        List2Name = list2Name;
        List2Year = list2Year;
        PublishedDate = publishedDate;
        LengthMinutes = lengthMinutes;
        LengthSeconds = lengthSeconds;
    }

    public static EpisodeDto? Parse(string line)
    {
        try
        {
            var parts = line.Split(",");

            if (parts.Length != 5)
                return null;

            var rawName = parts[0].Trim();
            var rawDate = parts[1].Trim();
            var rawLength = parts[2].Trim();
            var rawEpisodeNumber = parts[4].Trim();

            if (!int.TryParse(rawEpisodeNumber, out var episodeNumber))
                return null;

            var published = true;

            if (rawName.StartsWith('#'))
            {
                published = false;
                rawName = rawName[1..].Trim();
            }

            var nameParts = rawName.Split(" och ");
            var namePart1 = nameParts[0].Trim();
            var namePart2 = nameParts[1].Trim();
            var year1 = GetYear(ref namePart1);
            var year2 = GetYear(ref namePart2);
            var lengthParts = rawLength.Split(':');
            var lengthMinutes = int.Parse(lengthParts[0]);
            var lengthSeconds = int.Parse(lengthParts[1]);
            var date = ParseDate(rawDate);

            return new EpisodeDto(episodeNumber, published, namePart1, year1, namePart2, year2, date, lengthMinutes, lengthSeconds);
        }
        catch (Exception ex)
        {
            MessageBox.Show(line, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    private static int GetYear(ref string listName)
    {
        var yearPart = listName.Substring(listName.Length - 4);
        listName = listName.Substring(0, listName.Length - 4).Trim();
        return int.Parse(yearPart);
    }

    private static DateOnly ParseDate(string raw)
    {
        var parts = raw.Split('-');
        return new DateOnly(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public string List1AsString() =>
        $"{List1Name} {List1Year:0000}";

    public string List2AsString() =>
        $"{List2Name} {List2Year:0000}";

    public bool EpisodeImagesExist
    {
        get
        {
            try
            {
                var filename = Path.Combine(MainWindow.OutputFolderEpisodeGraphics, $"{EpisodeNumber:00}.jpg");
                return File.Exists(filename);
            }
            catch
            {
                return false;
            }
        }
    }

    public string ToFileRow()
    {
        var episodeName = new StringBuilder();
        episodeName.Append($"{List1Name} {List1Year:0000} och {List2Name} {List2Year:0000}");

        while (episodeName.Length < 40)
            episodeName.Append(' ');

        return $"{(Published ? "" : "#")}{episodeName}, {PublishedDate:yyyy-MM-dd}, {LengthMinutes:00}:{LengthSeconds:00}, , {EpisodeNumber}";
    }
}