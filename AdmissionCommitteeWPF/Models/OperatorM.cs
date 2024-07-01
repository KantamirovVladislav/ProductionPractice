using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using System.Text;
using System.Windows.Media.Imaging;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.Models;

public class OperatorM
{
    private List<Applicantsdocumentimage> _currentTableSorted;
    private List<Applicantsdocumentimage> _currentTable;

    private List<Keysfordocument> _keys;

    public List<Keysfordocument> Keys
    {
        get => _keys;
        set => _keys = value;
    }

    public List<Applicantsdocumentimage> CurrentTable
    {
        get => _currentTableSorted;
        set => _currentTableSorted = value;
    }
    
    public OperatorM()
    {
        _currentTable = new List<Applicantsdocumentimage>();
    }
    
    public async Task InitializeTableAsync()
    {
         _currentTable = await ExecuteCommandDataBase.GetApplicantsDocumentImages();
         _currentTableSorted = _currentTable;
    }

    public async Task InitKeys()
    {
        _keys = await ExecuteCommandDataBase.GetKeysForDocuments();
    }

    public async Task<string> GetDocumentData(int? applicantId, string documentType)
    {
        Dictionary<string, string> result = await ExecuteCommandDataBase.GetDocumentData(applicantId, documentType);
        StringBuilder builder = new StringBuilder();
        foreach (var value in result)
        {
            builder.Append($"{value.Key}: {value.Value} \n");
        }
        return builder.ToString();
    }

    public async Task InsertNewData(int? applicantId, string documentType, int keyId, string data)
    {
        try
        {
            await ExecuteCommandDataBase.AddImageData(applicantId, documentType, keyId, data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public BitmapImage DecodeImageBase64Async(string base64)
    {
        byte[] imageBytes = Convert.FromBase64String(base64);
        
        BitmapImage bitmapImage = new BitmapImage();
        using (MemoryStream memoryStream = new MemoryStream(imageBytes))
        {
            memoryStream.Position = 0;
            bitmapImage.BeginInit();
            bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.UriSource = null;
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();
        }
        bitmapImage.Freeze();

        return bitmapImage;
    }
    
    public void SortTable(string value)
    {
        if (value.All(char.IsDigit))
        {
            Console.WriteLine("Цифры");
            CurrentTable = _currentTable.Where(x => x.Snils.Contains(value)).ToList();
            return;
        }

        if (value.All(char.IsLetter))
        {
            Console.WriteLine("Буквы");
            CurrentTable = _currentTable.Where(x => x.FirstName.Contains(value)).ToList();
            return;
        }

        if (value.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
        {
            Console.WriteLine("Букавы и цифары");
            string[] values = value.Split(" ");
            CurrentTable = _currentTable.Where(x => x.FirstName.Contains(values[0]) && x.Snils.Contains(values[1]) ).ToList();
            return;
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            CurrentTable = _currentTable;
        }
    }
}