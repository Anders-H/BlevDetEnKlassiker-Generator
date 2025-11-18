using System.Diagnostics;

namespace BlevDetEnKlassikerEditor;

public partial class MainWindow : Form
{
#if DEBUG
    public const string EpisodesFileName = @"C:\Users\hbom\Desktop\blevdetenklassiker_source_lab.txt";
    public const string OutputFolder = @"C:\Users\hbom\Desktop\KlassikerOutputTest";
    public const string OutputFolderEpisodeGraphics = @"C:\Users\hbom\Desktop\KlassikerOutputTest\ep";
    public const string EpisodeImageOutputFolder = @"C:\Users\hbom\Desktop\KlassikerOutputTest";
#else
    public const string EpisodesFileName = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\blevdetenklassiker_source.txt";
    public const string OutputFolder = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\Output";
    public const string OutputFolderEpisodeGraphics = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\Output\ep";
    public const string EpisodeImageOutputFolder = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker";
#endif
    public const string GeneratorExeFile = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\Generator\InteEnSingelGenerator\bin\Release\net10.0\BlevDetEnKlassikerGenerator.exe";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        listView1.Columns.Add("Lista 1", 200);
        listView1.Columns.Add("Lista 2", 200);
        listView1.Columns.Add("Publicerad", 100);
        listView1.Columns.Add("Datum", 100, HorizontalAlignment.Center);
        listView1.Columns.Add("Längd", 100, HorizontalAlignment.Center);
        listView1.Columns.Add("Nummer", 100, HorizontalAlignment.Center);
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        Refresh();
        var episodes = new EpisodeDtoList();
        episodes.Load();
        listView1.BeginUpdate();

        foreach (var episode in episodes)
        {
            var item = new ListViewItem(episode.List1AsString()) { Tag = episode };
            item.SubItems.Add(episode.List2AsString());
            item.SubItems.Add(episode.Published ? "Ja" : "Nej");
            item.SubItems.Add(episode.Published ? episode.PublishedDate.ToString("yyyy-MM-dd") : "");
            item.SubItems.Add(episode.LengthMinutes != 0 && episode.LengthSeconds != 0 ? $"{episode.LengthMinutes:00}:{episode.LengthSeconds:00}" : "");
            item.SubItems.Add(episode.EpisodeNumber.ToString());
            item.Tag = episode;
            listView1.Items.Add(item);
        }

        listView1.EndUpdate();
        Cursor = Cursors.Default;
    }

    private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            Save();
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, $@"Kunde inte spara ändringar: {exception.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        Close();
    }

    private void Save()
    {

    }

    private void genereraSidaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        const string generatorPath = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\Generator\InteEnSingelGenerator\bin\Release\net10.0\BlevDetEnKlassikerGenerator.exe";
        Process.Start(generatorPath);
    }

    private void skapaNyttAvsnittToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var episodeNumber = 1;

        var publishedDate = DateTime.Today;

        while (publishedDate.DayOfWeek != DayOfWeek.Tuesday)
            publishedDate = publishedDate.AddDays(1);

        if (listView1.Items.Count > 0)
        {
            if (listView1.Items[0].Tag is EpisodeDto lastItem)
            {
                episodeNumber = lastItem.EpisodeNumber + 1;
                publishedDate = publishedDate.AddDays(7);
            }
        }

        var episode = new EpisodeDto(episodeNumber, false, "Lista1", 1980, "Lista2", 1980, DateOnly.FromDateTime(publishedDate), 0, 0);

        var item = new ListViewItem(episode.List1AsString()) { Tag = episode };
        item.SubItems.Add(episode.List2AsString());
        item.SubItems.Add(episode.Published ? "Ja" : "Nej");
        item.SubItems.Add(episode.Published ? episode.PublishedDate.ToString("yyyy-MM-dd") : "");
        item.SubItems.Add(episode.LengthMinutes != 0 && episode.LengthSeconds != 0 ? $"{episode.LengthMinutes:00}:{episode.LengthSeconds:00}" : "");
        item.SubItems.Add(episode.EpisodeNumber.ToString());
        item.Tag = episode;

        if (listView1.Items.Count > 0)
            listView1.Items.Insert(0, item);
        else
            listView1.Items.Add(item);
    }

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var item = listView1.GetItemAt(e.X, e.Y);

        if (item == null)
            return;

        item.Selected = true;
        var episode = item.Tag as EpisodeDto;

        if (episode == null)
            return;

        using var editor = new EpisodeDialog();
        editor.Episode = episode;

        if (editor.ShowDialog(this) != DialogResult.OK)
            return;

        item.SubItems[0].Text = episode.List1AsString();
        item.SubItems[1].Text = episode.List2AsString();
        item.SubItems[2].Text = episode.Published ? "Ja" : "Nej";
        item.SubItems[3].Text = episode.Published ? episode.PublishedDate.ToString("yyyy-MM-dd") : "";
        item.SubItems[4].Text = episode.LengthMinutes != 0 && episode.LengthSeconds != 0 ? $"{episode.LengthMinutes:00}:{episode.LengthSeconds:00}" : "";
        item.SubItems[5].Text = episode.EpisodeNumber.ToString();
    }

    private void skapaBildFörMarkeratAvsnittskrivÖverToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count == 0)
            return;

        if (listView1.SelectedItems[0].Tag is not EpisodeDto episode)
            return;

        try
        {
            var bitmap = BitmapGeneration.CreateBitmap(episode.EpisodeNumber, episode.List1Name, episode.List1Year, episode.List2Name, episode.List2Year);
            BitmapGeneration.SaveForEpisode(bitmap, episode.EpisodeNumber);
            MessageBox.Show(this, $@"Skapade bilder för avsnitt {episode.EpisodeNumber}.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, $@"Misslyckades: {exception.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}