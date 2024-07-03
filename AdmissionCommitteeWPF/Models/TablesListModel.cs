using System.Collections.ObjectModel;
using System.Windows;
using DataBaseClassLibrary.Entities;
using DataBaseClassLibrary.Methods;
using Npgsql;

namespace AdmissionCommitteeWPF.Models;

public class TablesListModel
{
    // Contains the current table values
    private ObservableCollection<object> _currentTable;
    
    // Contains the deleted table values
    private ObservableCollection<object> _deletedValues;

    // Getters and setters for the _currentTable
    public ObservableCollection<object> CurrentTable
    {
        get { return _currentTable;}
        set { _currentTable = value; }
    }
    
    // Getters and setters for the _deletedValues
    public ObservableCollection<object> DeletedValues
    {
        get { return _deletedValues;}
        set { _deletedValues = value; }
    }

    public TablesListModel()
    {
        _currentTable = new ObservableCollection<object>();
        _deletedValues = new ObservableCollection<object>();
    }

    // Accepts the table name and starts loading data from the database to the _currentTable
    public async Task SetTable(ComissionEntitys entity)
    {
        switch (entity)
        {
            case ComissionEntitys.Applicant:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicants());
                break;
            case ComissionEntitys.Documentdatum:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetDocumentData());
                break;
            case ComissionEntitys.DocumentsImage:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetDocumentsImages());
                break;
            case ComissionEntitys.DocumentType:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetDocumentTypes());
                break;
            case ComissionEntitys.FormsEducationSpecialization:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetFormsEducationSpecializations());
                break;
            case ComissionEntitys.FormsEducationSpecializationApplicant:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetFormsEducationSpecializationApplicants());
                break;
            case ComissionEntitys.FormsSpecialization:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetFormsSpecializations());
                break;
            case ComissionEntitys.Keysfordocument:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetKeysForDocuments());
                break;
            case ComissionEntitys.Specialization:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetSpecializations());
                break;
            case ComissionEntitys.TypeFinancing:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetTypeFinancings());
                break;
            case ComissionEntitys.Statusesapplicant:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicantsStatuses());
                break;
            case ComissionEntitys.Applicantsdocumentimage:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicantsDocumentImages());
                break;
            case ComissionEntitys.Applicantsandeducation:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicantsAndEducations());
                break;
            case ComissionEntitys.Applicantsanddocumentsdatum:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicantsAndDocumentsData());
                break;
            case ComissionEntitys.Educationbase:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetEducationBases());
                break;
            case ComissionEntitys.DocumentKey:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetKeys());
                break;
            case ComissionEntitys.Statusesforapplicant:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetStatusesForApplicant());
                break;
            case ComissionEntitys.Statusesforeducation:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetStatusesForEducation());
                break;
        }
    }


    public async Task SaveData()
    {
        try
        {
            await ExecuteCommandDataBase.SaveDbChanges(_currentTable, _deletedValues);
        }
        catch (NpgsqlException e)
        {
            throw new ArgumentException("Error while saving data to the database. Error: " + e.ToString());
        }
    }
    
    public void RejectAllChanges()
    {
        try
        {
            ExecuteCommandDataBase.RejectAllChanges();
            _deletedValues.Clear();
        }
        catch (Exception e)
        {
            throw new ArgumentException("Error while reject data to the database. Error: " + e.Message);
        }

    }
    
    //Bot working
    public void RejectChanges()
    {
        try
        {
            ExecuteCommandDataBase.RejectChanges();
        }
        catch (Exception e)
        {
            throw new ArgumentException("Error while reject data to the database. Error: " + e.Message);
        }
    }
}