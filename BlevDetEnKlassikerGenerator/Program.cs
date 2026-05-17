using System.Text;
using BlevDetEnKlassikerGenerator;

// Input, output and podcast name.
const string bgColor = "#36113e";
const string headerColor = "#ddd";
const string textColor = "#eee";
const string linkColor = "#99f";
const string linkHoverColor = "#ff9";
const string sourceFile = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\blevdetenklassiker_source.txt";
const string localOutput = @"C:\Users\hbom\OneDrive\BlevDetEnKlassiker\Output"; // Note: No ending slash.
const string title = "Blev det en klassiker?";
const string authorEmail = "anders@winsoft.se";
const string authorEmailWithName = $"{authorEmail} (Anders Hesselbom)";
const string mp3Filename = "blevdetenklassiker";
const string podcastCategory = "Music";
const string youTubeChannel = "";
const string titleImage = "blevdetenklassiker.jpg";
const string podcastImage = "blevdetenklassiker_podcast.jpg";
const string tagline = "Vi lyssnar på gamla låtar som låg på topplistorna och funderar på vilka verk som fortfarande är populära idag. Finns där poddar finns, men inte på Spotify, för någon ordning vill vi ha.";
const string episodeTagline = "I avsnitt <!--COUNT--> lyssnar Henrik och Anders på låtarna från <!--EPISODE_TITLE-->.";
const string baseUrlForVisitors = "https://blevdetenklassiker.80tal.se/"; // The URL used for marketing to listeners.
const string rss = "https://80tal.se/blevdetenklassiker/rss.xml"; // The URL to the RSS when uploaded.
const string baseUrl = "https://www.80tal.se/blevdetenklassiker/"; // The URL that is covered by the SSL certificate.
const string donate = @"Bjud på en kopp kaffe (20:-) som tack för bra innehåll!<br /><br /><img src=""https://ahesselbom.se/img/swish.png"" style=""width: 30%; height: auto; min-width: 100px; max-width: 300px; box-shadow: 0 0 25px 8px rgba(255, 255, 255, 0.5);""><br /><br />";
const string twitterLinks = @"<b>Henrik Andersson på X (Twitter):</b> <a href=""https://twitter.com/commoflage_"" target=""_blank"">@commoflage_</a><br />
<b>Anders Hesselbom på X (Twitter):</b> <a href=""https://twitter.com/ahesselbom"" target=""_blank"">@ahesselbom</a><br /><br />
Henrik Anderssons radioprogram, tisdagar kl. 20:00: <a href=""https://boz.radio/video"" target=""_blank"">https://boz.radio/video</a>, <a href=""https://boz.radio/chat"" target=""_blank"">https://boz.radio/chat</a><br /><br>
Anders e-postadress: <a href=""mailto:anders@winsoft.se"">anders@winsoft.se</a>";
StringList showHosts = ["Henrik Andersson", "Anders Hesselbom"];

var source = File.ReadAllLines(sourceFile);

var episodes = (
    source
        .Where(s => !string.IsNullOrWhiteSpace(s) && !s.Trim().StartsWith("#"))
        .Select(Episode.Parse)
    ).ToList();

// The HTML template for the landing site.
var websiteHead = $@"<!DOCTYPE html>
<html lang=""sv"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<link rel=""apple-touch-icon"" sizes=""180x180"" href=""/apple-touch-icon.png""><link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/favicon-32x32.png"">
<link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/favicon-16x16.png""><link rel=""manifest"" href=""/site.webmanifest"">
<link rel=""mask-icon"" href=""/safari-pinned-tab.svg"" color=""#5bbad5""> <meta name=""msapplication-TileColor"" content=""#da532c"">
<meta name=""theme-color"" content=""#ffffff""> <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<meta charset=""utf-8"" />
<!-- Generated at {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} -->
<title>{title} - podcast med {showHosts.SpeakList()}</title>
<style>
html, body {{ border: 0; margin: 0; padding: 0; background-color: {bgColor}; color: {textColor}; font-family: arial, sans-serif; }}
div {{ text-align: center; margin: 0 auto 0 auto; padding: 10px 0 5px 0; width: 50%; min-width: 512px; max-width: 1000px; }}
h1 {{ margin: 0; padding: 5px 0 5px 0; text-align: center; font-size: 50px; font-weight: normal; color: {headerColor}; display: none; }}
.logo {{ display: block; padding: 0; margin: 0 auto 0 auto; width: [LOGO-SIZE]; height: auto; max-width: 500px; text-align: center; }}
p {{ margin: 0; padding: 5px 0 5px 0; }} a {{ color: {linkColor}; text-decoration: none; }} a:hover {{ color: {linkHoverColor}; }}
.tagline {{ padding: 5px 0 15px 0; font-style: italic; }} .headblock {{ padding: 5px 0 15px 0; font-weight: bold; }}
.footblock {{ padding: 15px 0 5px 0; }}
table {{ border: none; margin: 0; padding: 0; width: 100%; }}
td {{ vertical-align: top; text-align: center; margin: 2px; padding: 2px; font-weight: Thin; font-size: 20px; }}
</style>
</head>
<body>
<div>
<h1>{title}</h1><img src=""logo.png"" alt=""{title}"" class=""logo"" />
<p class=""tagline"">Podcast med {showHosts.SpeakList()}</p><p><img src=""{titleImage}"" alt=""{title}"" style=""width: 100%; height: auto;""/></p>
<p class=""headblock"">{tagline}</p>";

// HTML template for the episode.
var episodeSiteHead = $@"<!DOCTYPE html>
<html lang=""sv"" xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<link rel=""apple-touch-icon"" sizes=""180x180"" href=""../apple-touch-icon.png""><link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""../favicon-32x32.png"">
<link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""../favicon-16x16.png""><link rel=""manifest"" href=""../site.webmanifest""> <link rel=""mask-icon"" href=""../safari-pinned-tab.svg"" color=""#5bbad5"">
<meta name=""msapplication-TileColor"" content=""#da532c"">
<meta name=""theme-color"" content=""#ffffff"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<meta charset=""utf-8"" />
<!-- Generated at {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} -->
<title><!--EPISODE_TITLE--> - {title} - podcast med {showHosts.SpeakList()}</title>
<style>
html, body {{ border: 0; margin: 0; padding: 0; background-color: {bgColor}; color: {textColor}; font-family: arial, sans-serif; }}
div {{ text-align: center; margin: 0 auto 0 auto; padding: 10px 0 5px 0; width: 50%; min-width: 512px; max-width: 1000px; }}
h1 {{ margin: 0; padding: 5px 0 5px 0; text-align: center; font-size: 50px; font-weight: normal; color: {headerColor}; display: none; }}
.logo {{ display: block; padding: 0; margin: 0 auto 0 auto; width: 70%; height: auto; max-width: 500px; text-align: center; }}
p {{ margin: 0; padding: 5px 0 5px 0; }} a {{ color: {linkColor}; text-decoration: none; }} a:hover {{ color: {linkHoverColor}; }}
.tagline {{ padding: 5px 0 15px 0; font-style: italic; }} .headblock {{ padding: 5px 0 15px 0; font-weight: bold; }}
.footblock {{ padding: 15px 0 5px 0; }}
table {{ border: none; margin: 0; padding: 0; width: 100%; }} td {{ vertical-align: top; text-align: center; margin: 2px; padding: 2px; font-weight: Thin; font-size: 20px; }}
</style>
</head>
<body>
<div>
<h1>{title}</h1><img src=""../logo.png"" alt=""{title}"" class=""logo"" />
<p class=""tagline"">Podcast med {showHosts.SpeakList()}</p><p><img src=""./cover.jpg"" style=""width: 100%; height: auto; max-width: 250px; max-height: 250px;""/></p>
<p class=""headblock"">{episodeTagline}</p>";


const string websiteLinks = @"<div style=""border-top: 1px solid #777777; margin-top: 30px; margin-bottom: 30px; padding-top: 30px;"">
    <a href=""https://ahesselbom.se/"" target=""_blank"" style=""padding-right: 30px;"">https://ahesselbom.se/</a><a href=""https://heltperfekt.com/"" target=""_blank"" style=""padding-left: 30px;"">https://heltperfekt.com/</a>
    <br/><br/><span style=""font-size: smaller;"">&quot;Blev det en klassiker?&quot; är <a href=""https://github.com/Anders-H/BlevDetEnKlassiker-Generator"" target=""_blank"">open source</a>.</span>
</div>";

const string youTubeLink = $@"<b>YouTube:</b> <a href=""{youTubeChannel}"" target=""_blank"">{title}</a><br /><br />";

var websiteFootWithPagination = $@"<p class=""footblock""><!--PAGINATION--><br/><br/><b>RSS:</b> <a href=""{rss}"" target=""_blank"">{rss}</a><br /><br />
{(string.IsNullOrWhiteSpace(youTubeChannel) ? "" : youTubeLink)}
{donate}{twitterLinks}</p></div>{websiteLinks}</body></html>";

var websiteFootWithoutPagination = $@"<p class=""footblock""><b><a href=""{baseUrlForVisitors}"">Tillbaka till startsidan</a></b><br /><br /><b>RSS:</b> <a href=""{rss}"" target=""_blank"">{rss}</a><br /><br />
{(string.IsNullOrWhiteSpace(youTubeChannel) ? "" : youTubeLink)}
{donate}{twitterLinks}</p></div>{websiteLinks}</body></html>";

// The pagination system will have 10 episodes per page.
var pagesCount = (int)Math.Ceiling(episodes.Count / 10.0);
var count = episodes.Count;
var index = 0;

var options = new FileStreamOptions
{
    Access = FileAccess.Write,
    Mode = FileMode.Create
};

for (var pageIndex = 0; pageIndex < pagesCount; pageIndex++)
{
    var filename = baseUrlForVisitors;

    if (pageIndex > 0)
        filename = $"page{pageIndex:00}.html";

    using var sw = new StreamWriter(Path.Combine(localOutput, filename.StartsWith("http") ? "index.html" : filename), Encoding.UTF8, options);
    sw.Write(websiteHead.Replace("[LOGO-SIZE]", index == 0 ? "100%" : "90%"));

    // Each episode on a normal list page (10 episodes);
    
    sw.WriteLine("<table>");

    for (var i = 0; i < 10; i++)
    {
        if (index >= episodes.Count)
            break;

        var episode = episodes[index];
        Console.WriteLine($"{count:000}: {episode}");

        if (episode.Title == "Trailer")
        {
            sw.Write("<tr>");
            sw.Write($@"<td style=""white-space: nowrap;"">0</td>");
            sw.Write($@"<td style=""white-space: nowrap; font-size: smaller; padding-top: 8px;"">{episode.PublishedDate:yyyy-MM-dd}</td>");
            var imageThumbFilename = Path.Combine(localOutput, "ep\\00_.jpg");
            var imageFilename = Path.Combine(localOutput, "ep\\00.jpg");

            if (File.Exists(imageThumbFilename))
                sw.Write($@"<td><a href=""ep/00.html""><img src=""ep/00_.jpg"" style=""width: 24px; height: 24px;"" alt=""Trailer"" /></a></td>");
            else if (File.Exists(imageFilename))
                sw.Write($@"<td><a href=""ep/00.html""><img src=""ep/00.jpg"" style=""width: 24px; height: 24px;"" alt=""Trailer"" /></a></td>");
            else
                sw.Write("<td></td>");

            sw.Write($@"<td><a href=""ep/00.html"">Trailer</a></td>");
            sw.Write($@"<td style=""white-space: nowrap; font-size: smaller; padding-top: 8px;"">{episode.Length}</td>");
            sw.Write($@"<td><a href=""{baseUrlForVisitors}mp3/{mp3Filename}00.mp3""><img src=""mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td>");

            if (episode.YouTube.Length > 4)
                sw.Write($@"<td><a href=""https://www.youtube.com/watch?v={episode.YouTube}"" target=""_blank""><img src=""youtube.png"" style=""width: 24px; height: 24px;"" alt=""Spela på YouTube..."" /></a></td>");
            else
                sw.Write("<td></td>");

            sw.Write("</tr>");

            if (count <= 0)
                break;

            index++;
        }
        else
        {
            sw.Write("<tr>");
            sw.Write($@"<td style=""white-space: nowrap;"">{count}</td>");
            sw.Write($@"<td style=""white-space: nowrap; font-size: smaller; padding-top: 8px;"">{episode.PublishedDate:yyyy-MM-dd}</td>");
            var imageThumbFilename = Path.Combine(localOutput, $"ep\\{count:00}_.jpg");
            var imageFilename = Path.Combine(localOutput, $"ep\\{count:00}.jpg");

            if (File.Exists(imageThumbFilename))
                sw.Write($@"<td><a href=""ep/{count:00}.html""><img src=""ep/{count:00}_.jpg"" style=""width: 24px; height: 24px;"" alt=""{episode.Title}"" /></a></td>");
            else if (File.Exists(imageFilename))
                sw.Write($@"<td><a href=""ep/{count:00}.html""><img src=""ep/{count:00}.jpg"" style=""width: 24px; height: 24px;"" alt=""{episode.Title}"" /></a></td>");
            else
                sw.Write("<td></td>");

            sw.Write($@"<td><a href=""ep/{count:00}.html"">{episode.Title}</a></td>");
            sw.Write($@"<td style=""white-space: nowrap; font-size: smaller; padding-top: 8px;"">{episode.Length}</td>");
            sw.Write($@"<td><a href=""{baseUrlForVisitors}mp3/{mp3Filename}{count:00}.mp3""><img src=""mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td>");

            if (episode.YouTube.Length > 4)
                sw.Write($@"<td><a href=""https://www.youtube.com/watch?v={episode.YouTube}"" target=""_blank""><img src=""youtube.png"" style=""width: 24px; height: 24px;"" alt=""Spela på YouTube..."" /></a></td>");
            else
                sw.Write("<td></td>");

            sw.Write("</tr>");
            count--;
            index++;

            if (count <= 0)
                break;
        }
    }

    sw.WriteLine("</table>");
    sw.Write(websiteFootWithPagination.Replace("<!--PAGINATION-->", GetPagination(pageIndex, pagesCount)));
    sw.Flush();
    sw.Close();
    Thread.Sleep(100);
}

{
    using var sw = new StreamWriter(Path.Combine(localOutput, "all.html"), Encoding.UTF8, options);
    sw.Write(websiteHead.Replace("[LOGO-SIZE]", "80%"));
    count = episodes.Count;

    // Each episode on the "all" page.
    foreach (var episode in episodes)
    {
        if (episode.Title == "Trailer")
        {
            sw.Write($@"<p style=""font-weight: Thin; font-size: 18px;""><a href=""{baseUrlForVisitors}ep/00.html"">0. Trailer</a> ({episode.Length})</p>");
        }
        else
        {
            sw.Write($@"<p style=""font-weight: Thin; font-size: 18px;""><a href=""{baseUrlForVisitors}ep/{count:00}.html"">{count}. {episode.Title}</a> ({episode.Length})</p>");
            count--;
        }
    }

    sw.Write(websiteFootWithPagination.Replace("<!--PAGINATION-->", GetPagination(-1, pagesCount)));
    sw.Flush();
    sw.Close();
    Thread.Sleep(100);
}

{
    count = episodes.Count;

    // Each episode page
    foreach (var episode in episodes)
    {
        if (episode.Title == "Trailer")
        {
            using var sw = new StreamWriter(Path.Combine(localOutput, "ep\\00.html"), Encoding.UTF8, options);
            var imageFilename = Path.Combine(localOutput, "ep\\00.jpg");
            imageFilename = File.Exists(imageFilename) ? "./00.jpg" : $"../{titleImage}";

            sw.Write(episodeSiteHead.Replace("<!--EPISODE_TITLE-->", "ingen topplista, men det kommer att förändras").Replace("<!--COUNT-->", "0").Replace("./cover.jpg", imageFilename));
            sw.Write(@"<table style=""width: 100%"">");
            sw.Write(@"<tr><td colspan=""2"" style=""text-align: center;"">");
            sw.Write($@"<audio controls style=""width: 100%;""><source src=""../mp3/{mp3Filename}00.mp3"" type=""audio/mpeg""></audio>");
            sw.Write("</td></tr>");

            sw.Write(string.IsNullOrWhiteSpace(episode.YouTube)
                ? $@"<tr><td colspan=""2"" style=""text-align: center;""><a href=""{baseUrlForVisitors}mp3/blevdetenklassiker00.mp3"" target=""_blank""><img src=""../mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td>"
                : $@"<tr><td style=""text-align: center;""><a href=""{baseUrlForVisitors}mp3/blevdetenklassiker00.mp3"" target=""_blank""><img src=""../mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td><td style=""text-align: center;""><a href=""https://www.youtube.com/watch?v={episode.YouTube}"" target=""_blank""><img src=""../youtube.png"" style=""width: 24px; height: 24px;"" alt=""Spela på YouTube..."" /></a></td></tr>");

            sw.Write("</table>");
            sw.Write(websiteFootWithoutPagination);
            sw.Flush();
            sw.Close();
            Thread.Sleep(100);
        }
        else
        {
            using var sw = new StreamWriter(Path.Combine(localOutput, $"ep\\{count:00}.html"), Encoding.UTF8, options);
            var imageFilename = Path.Combine(localOutput, $"ep\\{count:00}.jpg");
            imageFilename = File.Exists(imageFilename) ? $"./{count:00}.jpg" : "../inteensingel.jpg";

            sw.Write(episodeSiteHead.Replace("<!--EPISODE_TITLE-->", episode.Title).Replace("<!--COUNT-->", count.ToString()).Replace("./cover.jpg", imageFilename));
            sw.Write(@"<table style=""width: 100%"">");
            sw.Write(@"<tr><td colspan=""2"" style=""text-align: center;"">");
            sw.Write($@"<audio controls style=""width: 100%;""><source src=""../mp3/{mp3Filename}{count:00}.mp3"" type=""audio/mpeg""></audio>");
            sw.Write("</td></tr>");

            sw.Write(string.IsNullOrWhiteSpace(episode.YouTube)
                ? $@"<tr><td colspan=""2"" style=""text-align: center;""><a href=""{baseUrlForVisitors}mp3/{mp3Filename}{count:00}.mp3"" target=""_blank""><img src=""../mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td>"
                : $@"<tr><td style=""text-align: center;""><a href=""{baseUrlForVisitors}mp3/{mp3Filename}{count:00}.mp3"" target=""_blank""><img src=""../mp3.png"" style=""width: 24px; height: 24px;"" alt=""Lyssna direkt..."" /></a></td><td style=""text-align: center;""><a href=""https://www.youtube.com/watch?v={episode.YouTube}"" target=""_blank""><img src=""../youtube.png"" style=""width: 24px; height: 24px;"" alt=""Spela på YouTube..."" /></a></td></tr>");

            sw.Write("</table>");
            sw.Write(websiteFootWithoutPagination);
            sw.Flush();
            sw.Close();
            Thread.Sleep(100);
            count--;
        }
    }
}

// The RSS generator.
var rssTagline = $"Podcasten {title} - om musiken från topplistorna vi kanske glömt bort. {showHosts.SpeakList()} lyssnar på låtarna som låg på listorna förr.";
var authors = showHosts.CommaList();
const string imageUrl = $"{baseUrl}{podcastImage}";

var rssHead = $@"<rss xmlns:content=""http://purl.org/rss/1.0/modules/content/"" xmlns:wfw=""http://wellformedweb.org/CommentAPI/"" xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:atom=""http://www.w3.org/2005/Atom"" xmlns:sy=""http://purl.org/rss/1.0/modules/syndication/"" xmlns:slash=""http://purl.org/rss/1.0/modules/slash/"" xmlns:itunes=""http://www.itunes.com/dtds/podcast-1.0.dtd"" xmlns:rawvoice=""http://www.rawvoice.com/rawvoiceRssModule/""  version=""2.0"">
<channel>
<title>{title}</title>
<category>{podcastCategory}</category>
<atom:link href=""{rss}"" rel=""self"" type=""application/rss+xml""/>
<link>{baseUrl}</link>
<description>{rssTagline}</description>
<lastBuildDate>{DateTime.Now.AddHours(-2):r}</lastBuildDate>
<language>sv-SE</language>
<sy:updatePeriod>weekly</sy:updatePeriod>
<sy:updateFrequency>1</sy:updateFrequency>
<generator>Custom</generator>
<itunes:summary>{tagline}</itunes:summary>
<itunes:author>{authors}</itunes:author>
<itunes:explicit>False</itunes:explicit>
<itunes:image href=""{imageUrl}""/>
<itunes:owner>
    <itunes:name>{authors}</itunes:name>
    <itunes:email>{authorEmailWithName}</itunes:email>
</itunes:owner>
<managingEditor>{authorEmailWithName}</managingEditor>
<copyright>{authors}</copyright>
<itunes:subtitle>{title}</itunes:subtitle>
<image>
    <title>{title}</title>
    <url>{imageUrl}</url>
    <link>{baseUrl}</link>
</image>
<itunes:category text=""{podcastCategory}""></itunes:category>
<rawvoice:rating>TV-G</rawvoice:rating>
<rawvoice:frequency>Weekly</rawvoice:frequency>
<rawvoice:subscribe feed=""{rss}"" googleplay=""{rss}""/>";

const string rssFoot = "</channel></rss>";

using var swRss = new StreamWriter(Path.Combine(localOutput, "rss.xml"), Encoding.UTF8, options);
swRss.Write(rssHead);

count = episodes.Count;
var revCount = episodes.Count;
foreach (var episode in episodes)
{
    var url = $"{baseUrl}mp3/{mp3Filename}{count:00}.mp3";
    var localFile = $@"{localOutput}\mp3\{mp3Filename}{count:00}.mp3";
    var episodeTitle = $"Avsnitt {count:00}: {episode.Title}";

    if (episode.Title == "Trailer")
    {
        var episodeDescription = episodeTagline.Replace("<!--EPISODE_TITLE-->","Trailer").Replace("<!--COUNT-->", "0");
        swRss.Write($@"<item>
<title>Trailer</title>
<link>{baseUrl}</link>
<pubDate>{episode.PublishedDate:r}</pubDate>
<guid isPermaLink=""false"">{baseUrl}#{revCount--}</guid>
<description>{episodeDescription}</description>
<content:encoded>
<![CDATA[ <p>{episodeDescription}</p> ]]>
</content:encoded>
<enclosure url=""{url}"" length=""{GetLengthInBytes(localFile)}"" type=""audio/mpeg""/>
<itunes:subtitle>Trailer</itunes:subtitle>
<itunes:summary>Trailer</itunes:summary>
<itunes:author>{showHosts.CommaList()}</itunes:author>
<itunes:image href=""{imageUrl}""/>
<itunes:explicit>False</itunes:explicit>
<itunes:duration>00:{episode.Length}</itunes:duration>
</item>");
    }
    else
    {
        var episodeDescription = episodeTagline.Replace("<!--EPISODE_TITLE-->", episode.Title).Replace("<!--COUNT-->", count.ToString());
        swRss.Write($@"<item>
<title>{episodeTitle}</title>
<link>{baseUrl}</link>
<pubDate>{episode.PublishedDate:r}</pubDate>
<guid isPermaLink=""false"">{baseUrl}#{revCount--}</guid>
<description>{episodeDescription}</description>
<content:encoded>
<![CDATA[ <p>{episodeDescription}</p> ]]>
</content:encoded>
<enclosure url=""{url}"" length=""{GetLengthInBytes(localFile)}"" type=""audio/mpeg""/>
<itunes:subtitle>{episodeTitle}</itunes:subtitle>
<itunes:summary>{episodeTitle}</itunes:summary>
<itunes:author>{showHosts.CommaList()}</itunes:author>
<itunes:image href=""{imageUrl}""/>
<itunes:explicit>False</itunes:explicit>
<itunes:duration>00:{episode.Length}</itunes:duration>
</item>");
        count--;

    }
}

swRss.Write(rssFoot);
swRss.Flush();
swRss.Close();
return;

// Function that returns the MP3 file size in bytes.
static int GetLengthInBytes(string localFile)
{
    var fi = new FileInfo(localFile);
    return fi.Exists ? (int)fi.Length : 0;
}

// Function that returns the page selector.
static string GetPagination(int pageIndex, int pageCount)
{
    var s = new StringBuilder();

    if (pageIndex < 0)
    {
        for (var i = 0; i < pageCount; i++)
        {
            var filename = baseUrlForVisitors;

            if (i > 0)
                filename = $"page{i:00}.html";

            s.Append($@"<a href=""{filename}"">[Sida {i + 1}]</a> ");
        }

        s.Append("<b>[Alla avsnitt]</b>");
        return s.ToString();
    }

    for (var i = 0; i < pageCount; i++)
    {
        var filename = baseUrlForVisitors;

        if (i > 0)
            filename = $"page{i:00}.html";

        if (i == pageIndex)
            s.Append($"<b>[Sida {i + 1}]</b> ");
        else
            s.Append($@"<a href=""{filename}"">[Sida {i + 1}]</a> ");
    }

    s.Append(@"<a href=""all.html"">[Alla avsnitt]</a>");

    return s.ToString();
}