using System.Net;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class RewardPdfGenerator
{
    public byte[] GenerateRewardPdf(string username, double total)
{
    QuestPDF.Settings.License = LicenseType.Community;

    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "rewards", "images", "monster-energy-zero-500ml.jpg");

var pdfBytes = Document.Create(container =>
{
    container.Page(page =>
    {
        page.Margin(50);
        page.Size(PageSizes.A4);

        page.Header()
            .Text($"Congratulations, {username}!")
            .SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);

        page.Content()
            .PaddingVertical(20)
            .Column(col =>
            {
                col.Spacing(10);
                col.Item().Text($"You have reached a total of {total} XP!");
                col.Item().Image(imagePath);
            });

        page.Footer()
            .AlignCenter()
            .Text("PumpQuest")
            .FontSize(12)
            .FontColor(Colors.Grey.Darken1);
    });
}).GeneratePdf();


    return pdfBytes;
}

}
