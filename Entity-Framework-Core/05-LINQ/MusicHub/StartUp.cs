namespace MusicHub;

using System;
using System.Globalization;
using System.Text;
using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        //Problem 02  int producerId = 9;
        //Problem 02  Console.WriteLine(ExportAlbumsInfo(context, producerId));

        int songDuration = 4;
        Console.WriteLine(ExportSongsAboveDuration(context, songDuration));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        StringBuilder sb = new StringBuilder();

        var albums = context.Albums
            .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
            .ToArray()
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer!.Name,
                AlbumSongs = a.Songs.Select(s => new
                {
                    s.Name,
                    Price = s.Price.ToString("f2"),
                    WriterName = s.Writer.Name
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.WriterName),
                TotalAlbumPrice = a.Price.ToString("f2")
            })
            .OrderByDescending(a => decimal.Parse(a.TotalAlbumPrice));

        foreach (var album in albums)
        {
            sb
                .AppendLine($"-AlbumName: {album.Name}")
                .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                .AppendLine($"-ProducerName: {album.ProducerName}")
                .AppendLine("-Songs:");

            int songNumber = 1;
            foreach (var song in album.AlbumSongs)
            {
                sb
                    .AppendLine($"---#{songNumber}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Price: {song.Price}")
                    .AppendLine($"---Writer: {song.WriterName}");

                songNumber++;
            }

            sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int songDuration)
    {
        StringBuilder sb = new StringBuilder();

        var songs = context.Songs
            .ToArray()
            .Where(s => s.Duration.TotalSeconds > songDuration)
            .Select(s => new
            {
                s.Name,
                PerformerFullName = s.SongPerformers
                    .Select(sp => new
                    {
                        FullName = $"{sp.Performer.FirstName} {sp.Performer.LastName}"
                    })
                    .OrderBy(sp=>sp.FullName),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album!.Producer!.Name,
                Duration = s.Duration.ToString("c")
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.WriterName);

        int songNumber = 1;
        foreach (var song in songs)
        {
            sb
                .AppendLine($"-Song #{songNumber}")
                .AppendLine($"---SongName: {song.Name}")
                .AppendLine($"---Writer: {song.WriterName}");

            foreach (var name in song.PerformerFullName)
            {
                sb.AppendLine($"---Performer: {name.FullName}");
            }

            sb
                .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                .AppendLine($"---Duration: {song.Duration}");

            songNumber++;
        }

        return sb.ToString().TrimEnd();
    }
}
