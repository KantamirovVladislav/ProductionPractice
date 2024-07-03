using System.Data;
using System.Windows;
using System.Windows.Input;
using AdmissionCommitteeWPF.Models;
using DataBaseClassLibrary.Entities;

namespace AdmissionCommitteeWPF.ViewModel;

public class CommissionVM: ViewModelBase
{
    private CommissionM _сommissionM;
    
    private Applicantsandeducation _selectedRow;

    private Statusesforeducation _selectedStatus;

    private string _applicantDocuments;

    private string _fio;

    private string _specialization;

    private double _more;

    private double _less;

    private bool _lessMoreChecked;

    public bool LessMoreChecked
    {
        get => _lessMoreChecked;
        set
        {
            _lessMoreChecked = value; 
            SortTable();
        }
    }

    public string FIOSorted
    {
        get => _fio;
        set
        {
            _fio = value;
            SortTable();
        }
    }

    public string SpecializationSorted
    {
        get => _specialization;
        set
        {
            _specialization = value;
            SortTable();
        } 
    }
    
    public double AverageMoreSorted
    {
        get => _more;
        set
        {
            _more = value; 
            SortTable();
        }
    }

    public double AverageLessSorted
    {
        get => _less;
        set
        {
            _less = value;
            SortTable();
        } 
    }

    public string ApplicantDocuments
    {
        get => _applicantDocuments;
        set => _applicantDocuments = value;
    }
    
    public Statusesforeducation SelectedStatus
    {
        get => _selectedStatus;
        set => _selectedStatus = value;
    }

    public List<Statusesforeducation> StatusesList
    {
        get => _сommissionM.Statuses;
    }

    public List<Applicantsandeducation> TableDisplay
    {
        get => _сommissionM.CurrentTable;
        set => _сommissionM.CurrentTable = value;
    }
    
    public Applicantsandeducation SelectedRow
    {
        set
        {
            _selectedRow = value;
            Task.Run(GetApplicantDocuments);
        }

        get
        {
            return _selectedRow;
        }
    }

    public ICommand UpdateStatusCommand { get; set; }

    public ICommand RefreshCommand { get; set; }

    private async Task Refresh()
    {
        try
        {
            await _сommissionM.InitializeTableAsync();
            OnPropertyChanged("TableDisplay");
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);;
        }
    }

    private async Task UpdateStatus()
    {
        try
        {
            await _сommissionM.UpdateStatusAsync(SelectedRow.Snils, SelectedRow.SpecializationId, SelectedRow.Finansingname, SelectedStatus.StatusId);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.ToString());
        }
    }

    private async Task GetApplicantDocuments()
    {
        _applicantDocuments = "";
        OnPropertyChanged("ApplicantDocuments");
        _applicantDocuments = await _сommissionM.GetApplicantDocuments(SelectedRow.Snils);
        OnPropertyChanged("ApplicantDocuments");
    }

    private void SortTable()
    {
        _сommissionM.SortTable(FIOSorted, SpecializationSorted, AverageMoreSorted,AverageLessSorted, LessMoreChecked);
        OnPropertyChanged("TableDisplay");
    }

    public CommissionVM()
    {
        _сommissionM = new CommissionM();
        UpdateStatusCommand = new RelayCommandAsync(UpdateStatus);
        RefreshCommand = new RelayCommandAsync(Refresh);
        Task.Run(async () =>
            {
                await _сommissionM.InitializeTableAsync();
                await _сommissionM.InitializeStatuses();
                
                OnPropertyChanged("TableDisplay");
                OnPropertyChanged("StatusesList");
            }
        );
    }
}