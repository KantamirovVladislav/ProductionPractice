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

    public string FIOSorted
    {
        set
        {
            _сommissionM.FIOSortTable(value);
            OnPropertyChanged("TableDisplay");
        }
    }

    public string SpecializationSorted
    {
        set
        {
            _сommissionM.SpecializationSortTable(value);
            OnPropertyChanged("TableDisplay");
        }
    }
    
    public string AverageMoreSorted
    {
        get;
        set;
    }

    public string AverageLessSorted
    {
        get;
        set;
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
        _applicantDocuments = await _сommissionM.GetApplicantDocuments(SelectedRow.Snils);
        OnPropertyChanged("ApplicantDocuments");
    }

    public CommissionVM()
    {
        _сommissionM = new CommissionM();
        UpdateStatusCommand = new RelayCommandAsync(UpdateStatus);
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