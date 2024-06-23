using System.Collections.ObjectModel;
using DataBaseClassLibrary.Entities.Comission;
using DataBaseClassLibrary.Methods;

namespace AdmissionCommitteeWPF.Models;

public class TablesListModel
{
    private ObservableCollection<object> _currentTable;
    private ObservableCollection<object> _deletedValues;

    public ObservableCollection<object> CurrentTable
    {
        get { return _currentTable;}
        set { _currentTable = value; }
    }
    
    public ObservableCollection<object> DeletedValues
    {
        get { return _deletedValues;}
        set { _deletedValues = value; }
    }

    public TablesListModel()
    {
       
    }

    public async Task SetTable(ComissionEntitys entity)
    {
        switch (entity)
        {
            case ComissionEntitys.Applicant:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetApplicants());
                break;
            case ComissionEntitys.DocumentData:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetDocumentData());
                break;
            // case ComissionEntitys.DocumentKey:
            //     _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetDocumentKeys());
            //     break;
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
            case ComissionEntitys.KeysForDocument:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetKeysForDocuments());
                break;
            case ComissionEntitys.Specialization:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetSpecializations());
                break;
            case ComissionEntitys.TypeFinancing:
                _currentTable = new ObservableCollection<object>(await ExecuteCommandDataBase.GetTypeFinancings());
                break;
        }
    }

}