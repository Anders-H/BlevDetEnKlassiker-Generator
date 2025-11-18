namespace BlevDetEnKlassikerEditor;

public class EpisodeDtoList : List<EpisodeDto>
{
    public void Load()
    {
        Clear();
        var fi = new FileInfo(MainWindow.EpisodesFileName);

        if (!fi.Exists)
        {
            fi.Create().Dispose();
            Thread.Sleep(100);
        }

        var lines = File.ReadAllLines(MainWindow.EpisodesFileName);
        
        foreach (var line in lines)
        {
            var e = EpisodeDto.Parse(line);

            if (e != null)
                Add(e);
        }
    }
}