using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using DataBaseClassLibrary.Context;
using DataBaseClassLibrary.Entities.Comission;
using DataBaseClassLibrary.Entities.PersonalData;
using DataBaseClassLibrary.Entities.Schedules;
using Microsoft.EntityFrameworkCore;
using Group = DataBaseClassLibrary.Entities.Schedules.Group;

namespace DataBaseClassLibrary.Methods;

public class ExecuteCommandDataBase
{
    private static readonly OpenConnectionDataBase _db = OpenConnectionDataBase.getInstance();

    #region Comission
    
    public static async Task<List<Applicant>> GetApplicants()
    {
        return await _db.Applicants.ToListAsync();
    }

    public static async Task<List<DocumentData>> GetDocumentData()
    {
        return await _db.DocumentsData.ToListAsync();
    }
    
    public static async Task<List<DocumentKey>> GetDocumentKeys()
    {
        return await _db.DocumentKeys.ToListAsync();
    }
    
    public static async Task<List<DocumentsImage>> GetDocumentsImages()
    {
        return await _db.DocumentsImages.ToListAsync();
    }
    
    public static async Task<List<DocumentType>> GetDocumentTypes()
    {
        return await _db.DocumentTypes.ToListAsync();
    }
    
    public static async Task<List<FormsEducationSpecialization>> GetFormsEducationSpecializations()
    {
        return await _db.FormsEducationSpecializations.ToListAsync();
    }
    
    public static async Task<List<FormsEducationSpecializationApplicant>> GetFormsEducationSpecializationApplicants()
    {
        return await _db.FormsEducationSpecializationApplicants.ToListAsync();
    }
    
    public static async Task<List<FormsSpecialization>> GetFormsSpecializations()
    {
        return await _db.FormsSpecializations.ToListAsync();
    }
    
    public static async Task<List<KeysForDocument>> GetKeysForDocuments()
    {
        return await _db.KeysForDocuments.ToListAsync();
    }
    
    public static async Task<List<Specialization>> GetSpecializations()
    {
        return await _db.Specializations.ToListAsync();
    }
    
    public static async Task<List<TypeFinancing>> GetTypeFinancings()
    {
        return await _db.TypeFinancings.ToListAsync();
    }
    #endregion

    #region PersonalData
    
    public static async Task<List<PersonalAccountData>> GetPersonalAccountsData()
    {
        return await _db.PersonalAccountsData.ToListAsync();
    }
    #endregion

    #region Schedule

    public static async Task<List<Group>> GetGroups()
    {
        return await _db.Groups.ToListAsync();
    }
    
    public static async Task<List<Room>> GetRooms()
    {
        return await _db.Rooms.ToListAsync();
    }
    
    public static async Task<List<Schedule>> GetSchedules()
    {
        return await _db.Schedules.ToListAsync();
    }
    
    public static async Task<List<Specialty>> GetSpecialties()
    {
        return await _db.Specialties.ToListAsync();
    }
    
    public static async Task<List<Subject>> GetSubjects()
    {
        return await _db.Subjects.ToListAsync();
    }
    
    public static async Task<List<Teacher>> GetTeachers()
    {
        return await _db.Teachers.ToListAsync();
    }
    
    public static async Task<List<Timeslot>> GetTimeslots()
    {
        return await _db.Timeslots.ToListAsync();
    }

    #endregion
    
    #region BaseCommands
    
    public static async Task AddRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            await _db.AddAsync(entity);
        }
        await _db.SaveChangesAsync();
    }
    
    public static async Task UpdateRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            _db.Update(entity);
        }
        await _db.SaveChangesAsync();
    }

    public static async Task SaveAddWithState(ObservableCollection<object> entities)
    {
        foreach (var item in entities)
        {
            if (_db.Entry(item).State == EntityState.Detached)
            {
                _db.Entry(item).State = EntityState.Added;
            }
        }
        await _db.SaveChangesAsync();
    }


    public static async Task DeleteRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            _db.Remove(entity);
        }
        await _db.SaveChangesAsync();
    }

    public static async Task SaveDeleteWithState(ObservableCollection<object> entities)
    {
        foreach (var item in entities)
        {
            var entry = _db.Entry(item);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Deleted;
            }
        }
        await _db.SaveChangesAsync();
    }

    public static async Task AddEntityAsync(object entity)
    {
        await _db.AddAsync(entity);
        await _db.SaveChangesAsync();
    }
    
    public static async Task UpdateEntityAsync(object entity)
    {
        _db.Update(entity);
        await _db.SaveChangesAsync();
    }
    
    public static async Task DeleteEntityAsync(object entity)
    {
        _db.Remove(entity);
        await _db.SaveChangesAsync();
    }
    
    public static void RejectAllChanges()
    {
        foreach (var entity in _db.ChangeTracker.Entries().ToList())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.State = EntityState.Detached;
                    break;
                case EntityState.Modified:
                    entity.State = EntityState.Unchanged;
                    break;
                case EntityState.Deleted:
                    entity.State = EntityState.Unchanged;
                    break;
            }
        }
    }

    public static void RejectChanges()
    {
        var entity = _db.ChangeTracker.Entries().ToList();
        switch (entity.Last().State)
        {
            case EntityState.Added:
                entity.Last().State = EntityState.Detached;
                break;
            case EntityState.Modified:
                entity.Last().State = EntityState.Unchanged;
                break;
            case EntityState.Deleted:
                entity.Last().State = EntityState.Unchanged;
                break;
        }
    }

    #endregion
}