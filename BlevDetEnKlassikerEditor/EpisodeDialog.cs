using System.ComponentModel;

namespace BlevDetEnKlassikerEditor;

public partial class EpisodeDialog : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public EpisodeDto? Episode { get; set; }

    public EpisodeDialog()
    {
        InitializeComponent();
    }

    private void EpisodeDialog_Shown(object sender, EventArgs e)
    {
        if (Episode == null)
            throw new InvalidOperationException("Episode is null");

        txtEpisodeNumber.Text = Episode.EpisodeNumber.ToString();
        txtList1.Text = Episode.List1Name;
        txtYear1.Text = Episode.List1Year.ToString();
        txtList2.Text = Episode.List2Name;
        txtYear2.Text = Episode.List2Year.ToString();
        chkPublished.Checked = Episode.Published;
        txtPublishedDate.Text = Episode.PublishedDate.ToString("yyyy-MM-dd");
        txtLengthMinutes.Text = Episode.LengthMinutes.ToString("00");
        txtLengthSeconds.Text = Episode.LengthSeconds.ToString("00");
        UpdateBitmap();
    }

    private void txtEpisodeNumber_Validating(object sender, CancelEventArgs e)
    {
        GetEpisodeNumber(out int episodeNumber);
        Episode!.EpisodeNumber = episodeNumber;
        UpdateBitmap();
    }

    private void txtList1_Validating(object sender, CancelEventArgs e)
    {
        txtList1.Text = txtList1.Text.Trim();
        UpdateBitmap();
    }

    private void txtYear1_Validating(object sender, CancelEventArgs e)
    {
        UpdateBitmap();
    }

    private void txtList2_Validating(object sender, CancelEventArgs e)
    {
        txtList2.Text = txtList2.Text.Trim();
        UpdateBitmap();
    }

    private void txtYear2_Validating(object sender, CancelEventArgs e)
    {
        UpdateBitmap();
    }

    private void txtLengthMinutes_Validating(object sender, CancelEventArgs e)
    {
        GetLength(out var lengthMinutes, out var lengthSeconds);
        txtLengthMinutes.Text = lengthMinutes.ToString("00");
    }

    private void txtLengthSeconds_Validating(object sender, CancelEventArgs e)
    {
        GetLength(out var lengthMinutes, out var lengthSeconds);
        txtLengthMinutes.Text = lengthSeconds.ToString("00");
    }

    private void UpdateBitmap()
    {
        try
        {
            pictureBox1.Image?.Dispose();
        }
        catch
        {
            // ignored
        }

        try
        {
            pictureBox1.Image = BitmapGeneration.CreateBitmap(
                Episode!.EpisodeNumber,
                txtList1.Text,
                Episode.List1Year,
                txtList2.Text,
                Episode.List2Year);
        }
        catch
        {
            // ignored
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (!GetEpisodeNumber(out int episodeNumber))
        {
            txtEpisodeNumber.Focus();
            MessageBox.Show(this, @"Avsnittsnummer är ett obligatoriskt fält.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        txtList1.Text = txtList1.Text.Trim();
        txtList2.Text = txtList2.Text.Trim();

        if (string.IsNullOrEmpty(txtList1.Text))
        {
            txtList1.Focus();
            MessageBox.Show(this, @"Lista 1 är ett obligatoriskt fält.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(txtList2.Text))
        {
            txtList2.Focus();
            MessageBox.Show(this, @"Lista 2 är ett obligatoriskt fält.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!GetYear(txtYear1.Text, Episode!.List1Year, out var year1))
        {
            txtYear1.Focus();
            MessageBox.Show(this, @"År för lista 1 är inte giltigt.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!GetYear(txtYear2.Text, Episode!.List2Year, out var year2))
        {
            txtYear2.Focus();
            MessageBox.Show(this, @"År för lista 2 är inte giltigt.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (!GetLength(out var lengthMinutes, out var lengthSeconds))
        {
            txtLengthMinutes.Focus();
            MessageBox.Show(this, @"Längden är inte giltig.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    private bool GetEpisodeNumber(out int episodeNumber)
    {
        episodeNumber = Episode!.EpisodeNumber;
        var rawEpisodeNumber = txtEpisodeNumber.Text.Trim();

        if (!int.TryParse(rawEpisodeNumber, out episodeNumber))
            return false;

        return true;
    }

    private bool GetYear(string rawYear, int currentYear, out int year)
    {
        year = currentYear;
        
        if (!int.TryParse(rawYear, out var newYear))
            return false;

        year = newYear;

        return true;
    }

    private bool GetLength(out int lengthMinutes, out int lengthSeconds)
    {
        lengthMinutes = Episode!.LengthMinutes;
        lengthSeconds = Episode.LengthSeconds;
        var rawMinutes = txtLengthMinutes.Text.Trim();
        var rawSeconds = txtLengthSeconds.Text.Trim();

        if (!int.TryParse(rawMinutes, out lengthMinutes))
            return false;
        
        if (!int.TryParse(rawSeconds, out lengthSeconds))
            return false;
        
        if (lengthSeconds < 0 || lengthSeconds > 59)
            return false;
        
        return true;
    }
}