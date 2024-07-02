using System.Text;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.Models;

public class CommissionM
{
    private List<Applicantsandeducation> _currentTableSorted;
    private List<Applicantsandeducation> _currentTable;
    
    private List<Statusesforeducation> _statuses;

    public List<Statusesforeducation> Statuses
    {
        get => _statuses;
        set => _statuses = value;
    }

    public List<Applicantsandeducation> CurrentTable
    {
        get => _currentTableSorted;
        set => _currentTableSorted = value;
    }
    
    public async Task InitializeTableAsync()
    {
        _currentTable = await ExecuteCommandDataBase.GetApplicantsAndEducations();
        _currentTableSorted = _currentTable;
    }

    public async Task UpdateStatusAsync(string snils, string specId, string typeFin, int status)
    {
        await ExecuteCommandDataBase.UpdateStatusSpecialization(snils, specId, typeFin, status);
    }

    public async Task<string> GetApplicantDocuments(string snils)
    {
        var result = await ExecuteCommandDataBase.GetApplicantDocuments(snils);

        StringBuilder builder = new StringBuilder();

        foreach (var value in result)
        {
            builder.Append($"{value.Key}: {(value.Value == "t" ? "Обработан": "Не обработан")}\n");
        }

        return builder.ToString();
    }

    public void FIOSortTable(string data)
    {
        _currentTableSorted = _currentTable.Where(x => $"{x.FirstName} {x.Name} {x.LastName}".Contains(data)).ToList();
    }
    
    public void SpecializationSortTable(string data)
    {
        _currentTableSorted = _currentTableSorted.Where(x => x.Snils.Contains(data)).ToList();
    }

    public async Task InitializeStatuses()
    {
        _statuses = await ExecuteCommandDataBase.GetStatusesForEducation();
    }

    public CommissionM()
    {
        _currentTable = new List<Applicantsandeducation>();
    }
}