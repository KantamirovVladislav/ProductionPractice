using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AdmissionCommitteeWPF.Models;
using AdmissionCommitteeWPF.Windows;
using DataBaseClassLibrary.Entities;

namespace AdmissionCommitteeWPF.ViewModel;

public class OperatorVM: ViewModelBase
{
    private OperatorM _operatorM;
    
    private Applicantsdocumentimage _selectedRow;

    private Keysfordocument _selectedKey;

    private string _data;

    private string _resultData;

    public string DisplayResultData
    {
        get => _resultData;
        set => _resultData = value;
    }

    public string SortedValue
    {
        set
        {
            _operatorM.SortTable(value);
            OnPropertyChanged("TableDisplay");
        }
    }

    public string Data
    {
        get => _data;
        set => _data = value;
    }

    public Keysfordocument SelectedKey
    {
        get => _selectedKey;
        set => _selectedKey = value;
    }

    public List<Keysfordocument> DisplayKey
    {
        get
        {
            return _operatorM.Keys;
        }
    }

    public List<Applicantsdocumentimage> TableDisplay
    {
        get => _operatorM.CurrentTable;
        set => _operatorM.CurrentTable = value;
    }
    
    public Applicantsdocumentimage SelectedRow
    {
        set
        {
            _selectedRow = value;
            Task.Run(GetDocumentDataAsync);
        }

        get
        {
            return _selectedRow;
        }
    }
    
    public ICommand SelectedImageCommand { get; set; }

    public ICommand SaveCommand { get; set; }

    private async Task GetDocumentDataAsync()
    {
        _resultData = "";
        OnPropertyChanged("DisplayResultData");
        _resultData = await _operatorM.GetDocumentData(SelectedRow.ApplicantId, SelectedRow.Typename);
        OnPropertyChanged("DisplayResultData");
    }

    private async Task SaveData()
    {
        try
        {
            if (_selectedRow.ApplicantId == null)
                return;
            if (string.IsNullOrWhiteSpace(_selectedRow.Typename))
                return;
            if (_selectedKey.KeyId == null)
                return;
            if (string.IsNullOrWhiteSpace(_data))
                return;
            await _operatorM.InsertNewData(_selectedRow.ApplicantId, _selectedRow.Typename, _selectedKey.KeyId, _data);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
        
    }

    private void SelectedImage(object obj)
    {
        BitmapImage image = _operatorM.DecodeImageBase64Async((obj as Applicantsdocumentimage).Photo);
        ImageSource curImage = new BitmapImage();
        curImage  = image;
        ImageViewModel imageViewModel = new ImageViewModel();
        imageViewModel.Image = curImage;

        ImageView imageView = new ImageView();
        imageView.DataContext = imageViewModel;
        imageView.Show();
    }

    public OperatorVM()
    {
        _operatorM = new OperatorM();
        SelectedImageCommand = new RelayCommand(SelectedImage);
        SaveCommand = new RelayCommandAsync(async () => await SaveData());
        Task.Run(async () =>
            {
                await _operatorM.InitializeTableAsync();
                await _operatorM.InitKeys();
                
                OnPropertyChanged("TableDisplay");
                OnPropertyChanged("DisplayKey");
                OnPropertyChanged("DisplayResultData");
            }
        );
    }
}