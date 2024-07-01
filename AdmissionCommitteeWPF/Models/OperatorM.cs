using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.Models;

public class OperatorM
{
    private ObservableCollection<Applicantsdocumentimage> _currentTable;

    private List<Keysfordocument> _keys;

    public List<Keysfordocument> Keys
    {
        get => _keys;
        set => _keys = value;
    }

    public ObservableCollection<Applicantsdocumentimage> CurrentTable
    {
        get => _currentTable;
        set => _currentTable = value;
    }
    
    public OperatorM()
    {
        _currentTable = new ObservableCollection<Applicantsdocumentimage>();
    }
    
    public async Task InitializeTableAsync()
    {
         _currentTable = new ObservableCollection<Applicantsdocumentimage>(await ExecuteCommandDataBase.GetApplicantsDocumentImages());
    }

    public async Task InitKeys()
    {
        _keys = await ExecuteCommandDataBase.GetKeysForDocuments();
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
}