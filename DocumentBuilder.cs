using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Linq;

public class DocumentBuilder
{

    private PdfPCell getCell(bool leder, string txt, bool even = false, bool center = false)
    {
        iTextSharp.text.Font f = FontFactory.GetFont("Arial", 11, leder ? Font.BOLD : Font.NORMAL, BaseColor.Black);
        PdfPCell cell = new PdfPCell(new Phrase(txt, f));
        cell.Padding = 5;
        if (even)
            cell.BackgroundColor = new BaseColor(240, 240, 240);

        if (center)
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

        return cell;
    }

    public void Build(Hold hold, string outputPath)
    {

        Document doc = new Document(new Rectangle(288f, 144f), 10, 10, 10, 10);
        doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

        PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));

        doc.Open();
        AddHeader(hold.Name, doc, false);

        float[] columnWidths = { 1, 5, 3, 3, 5, 1 };
        PdfPTable table = new PdfPTable(columnWidths);

        table.WidthPercentage = 100;

        table.AddCell(getCell(false,"#", false, true));
        table.AddCell(getCell(false,"Navn"));
        table.AddCell(getCell(false,"Fødselsdato"));
        table.AddCell(getCell(false,"Tlf"));
        table.AddCell(getCell(false,"Email"));
        table.AddCell(getCell(false, "X", false, true));

        int cnt = 0;
        foreach (var plr in hold.Medlemmer.Medlemmer.Medlem.Where(m => m.Slettet == false))
        {
            bool leder = hold?.Medlemmer?.Relationer?.Gruppe?.Leder?.Medlem.FirstOrDefault(p => p == plr.Id)!=null;
            table.AddCell(getCell(leder,++cnt + "", cnt % 2 == 0, true));
            table.AddCell(getCell(leder, plr.Navn + (leder ? " (leder)" : ""), cnt % 2 == 0));
            table.AddCell(getCell(leder, plr.Birth, cnt % 2 == 0));
            table.AddCell(getCell(leder, plr.Mobil, cnt % 2 == 0));
            table.AddCell(getCell(leder, plr.Email, cnt % 2 == 0));
            table.AddCell(getCell(leder, "", cnt % 2 == 0, true));
        }

        doc.Add(table);
        doc.Close();
    }



    private void AddHeader(string teamName, Document doc, bool simple = false)
    {
        iTextSharp.text.Font header = FontFactory.GetFont("Arial", 22, iTextSharp.text.Font.BOLD, BaseColor.Black);
        iTextSharp.text.Font subHeader = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD, BaseColor.Black);
        Paragraph p = new Paragraph();
        p.Alignment = Element.ALIGN_CENTER;
        Chunk hdrChunk = new Chunk("Børnefritidsforeningen i Sydhavnen\n\n", header);
        Chunk subChunk = new Chunk("Afkrydsningsliste for " + teamName + "\n\n", subHeader);


        iTextSharp.text.Image img = null;
        string imgPath = Path.Combine(Directory.GetCurrentDirectory(), "images/" + "play1.png");
        if (File.Exists(imgPath))
        {
            img = iTextSharp.text.Image.GetInstance(imgPath);
            img.ScaleToFit(50, 50f);
            img.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_LEFT;
            img.IndentationLeft = 1f;
            img.SpacingAfter = 1f;
            img.BorderWidthTop = 1f;
            img.BorderColorTop = iTextSharp.text.BaseColor.White;
            doc.Add(img);
        }
        else
        {
            Console.WriteLine("Kan ikke finde billedet banner.png");
        }



        p.Add(hdrChunk);
        p.Add(subChunk);



        iTextSharp.text.Image img1 = null;
        string img1Path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + "play2.png");
        if (File.Exists(img1Path))
        {
            img1 = iTextSharp.text.Image.GetInstance(img1Path);
            img1.ScaleToFit(50, 50f);
            img1.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
            img1.IndentationLeft = 1f;
            img1.SpacingAfter = 1f;
            img1.BorderWidthTop = 1f;
            img1.BorderColorTop = iTextSharp.text.BaseColor.White;
            doc.Add(img1);
        }
        else
        {
            Console.WriteLine("Kan ikke finde billedet banner.png");
        }



        DottedLineSeparator dottedline = new DottedLineSeparator();
        dottedline.Offset = 0;
        dottedline.Gap = 2f;
        p.Add(dottedline);
        p.Add(new Chunk("\n\n\n"));


        doc.Add(p);
    }

}