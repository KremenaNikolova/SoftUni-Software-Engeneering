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

        int producerId = 9;
        Console.WriteLine(ExportAlbumsInfo(context, producerId));
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

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        throw new NotImplementedException();
    }
}
