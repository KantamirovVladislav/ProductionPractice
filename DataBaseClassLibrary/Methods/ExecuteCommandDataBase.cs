using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks.Dataflow;
using DataBaseClassLibrary.Context;
using DataBaseClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Group = DataBaseClassLibrary.Entities.Group;

namespace DataBaseClassLibrary.Methods;

public class ExecuteCommandDataBase
{
    private static readonly OpenConnectionDataBase _db = OpenConnectionDataBase.getInstance();

    #region Comission
    
    public static async Task<List<Applicant>> GetApplicants()
    {
        return await _db.Applicants.ToListAsync();
    }

    public static async Task<List<Documentdatum>> GetDocumentData()
    {
        return await _db.Documentdata.ToListAsync();
    }

    public static async Task<List<DocumentKey>> GetKeys()
    {
        return await _db.DocumentKeys.ToListAsync();
    }

    public static async Task<List<Keysfordocument>> GetKeysForDocuments()
    {
        return await _db.Keysfordocuments.ToListAsync();
    }

    public static async Task<List<Statusesapplicant>> GetApplicantsStatuses()
    {
        return await _db.Statusesapplicants.ToListAsync();
    }

    public static async Task<List<Statusesforapplicant>> GetStatusesForApplicant()
    {
        return await _db.Statusesforapplicants.ToListAsync();
    }

    public static async Task<List<Statusesforeducation>> GetStatusesForEducation()
    {
        return await _db.Statusesforeducations.ToListAsync();
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
    
    public static async Task<List<Specialization>> GetSpecializations()
    {
        return await _db.Specializations.ToListAsync();
    }
    
    public static async Task<List<TypeFinancing>> GetTypeFinancings()
    {
        return await _db.TypeFinancings.ToListAsync();
    }
    
    public static async Task<List<Educationbase>> GetEducationBases()
    {
        return await _db.Educationbases.ToListAsync();
    }
    
    public static async Task<List<Applicantsdocumentimage>> GetApplicantsDocumentImages()
    {
        return await _db.Applicantsdocumentimages.ToListAsync();
    }
    
    public static async Task<List<Applicantsandeducation>> GetApplicantsAndEducations()
    {
        return await _db.Applicantsandeducations.ToListAsync();
    }

    public static async Task<List<Applicantsanddocumentsdatum>> GetApplicantsAndDocumentsData()
    {
        return await _db.Applicantsanddocumentsdata.ToListAsync();
    }

    #endregion

    #region PersonalData
    
    public static async Task<List<PersonalAccountDatum>> GetPersonalAccountsData()
    {
        return await _db.PersonalAccountData.ToListAsync();
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
    
    // Add range of entities to the database. Also save changes in the database
    public static async Task AddRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            await _db.AddAsync(entity);
        }
        await _db.SaveChangesAsync();
    }
    
    // Update range of entities in the database. Also save changes in the database
    public static async Task UpdateRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            _db.Update(entity);
        }
        await _db.SaveChangesAsync();
    }

    
    // Save range of entities with state in the entityFramework. All detached entities will be added.
    private static void SaveAddWithState(ObservableCollection<object> entities)
    {
        foreach (var item in entities)
        {
            if (_db.Entry(item).State == EntityState.Detached)
            {
                _db.Entry(item).State = EntityState.Added;
            }
        }
    }
    
    // Delete range of entities in the database. Also save changes in the database
    public static async Task DeleteRangeEntityAsync(ObservableCollection<object> entities)
    {
        foreach (var entity in entities)
        {
            _db.Remove(entity);
        }
        await _db.SaveChangesAsync();
    }

    // Save range of entities with state in the entityFramework. All detached entities will be deleted
    private static void SaveDeleteWithState(ObservableCollection<object> entities)
    {
        if (entities.Count != 0)
        {
            foreach (var item in entities)
            {
                var entry = _db.Entry(item);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Deleted;
                }
            }
        }
    }

    // Add entity to the database. Also save changes in the database
    public static async Task AddEntityAsync(object entity)
    {
        await _db.AddAsync(entity);
        await _db.SaveChangesAsync();
    }
    
    // Update entity in the database. Also save changes in the database
    public static async Task UpdateEntityAsync(object entity)
    {
        _db.Update(entity);
        await _db.SaveChangesAsync();
    }
    
    // Delete entity in the database. Also save changes in the database
    public static async Task DeleteEntityAsync(object entity)
    {
        _db.Remove(entity);
        await _db.SaveChangesAsync();
    }
    
    // Save all changes in the database. Parameters are the list of added and deleted entities
    public static async Task SaveDbChanges(ObservableCollection<object> addedEntities, ObservableCollection<object> deletedEntities)
    {
        Console.WriteLine(deletedEntities.Count.ToString(), addedEntities.Count.ToString());
        if (deletedEntities.Count != 0)
            SaveDeleteWithState(deletedEntities);
        if (addedEntities.Count != 0)
            SaveAddWithState(addedEntities);
        await _db.SaveChangesAsync();
    }
    
    // Reject all changes in the database. Use this method if you want to cancel all changes in the database
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

    // Reject last changes in the database. Use this method if you want to cancel last changes in the database
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

    #region CustomCommandCommission

    public static async Task AddImageData(int? applicantId, string documentType, int keyId, string data)
    {
        try
        {
            NpgsqlParameter parameter1 = new NpgsqlParameter("applicantid", applicantId);
            NpgsqlParameter parameter2 = new NpgsqlParameter("documenttype", documentType);
            NpgsqlParameter parameter3 = new NpgsqlParameter("keyid", keyId);
            NpgsqlParameter parameter4 = new NpgsqlParameter("currentdata", data);
            await _db.Database.ExecuteSqlRawAsync("call comission.insert_new_data_document(@applicantid, @documenttype, @keyid, @currentdata)", parameter1, parameter2, parameter3, parameter4);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in insert_new_data_document {e.Message}");
        }
    }
    
    public static async Task UpdateStatusDocument(int? applicantId, string documentType)
    {
        try
        {
            NpgsqlParameter parameter1 = new NpgsqlParameter("applicantid", applicantId);
            NpgsqlParameter parameter2 = new NpgsqlParameter("documenttype", documentType);
            await _db.Database.ExecuteSqlRawAsync("call comission.update_status_document(@applicantid, @documenttype)", parameter1, parameter2);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in update_status_document {e.Message}");
        }
    }
    
    public static async Task UpdateStatusSpecialization(string snils, string specId, string typeFin, int status)
    {
        try
        {
            NpgsqlParameter parameter1 = new NpgsqlParameter("_snils", snils);
            NpgsqlParameter parameter2 = new NpgsqlParameter("specializationid", specId);
            NpgsqlParameter parameter3 = new NpgsqlParameter("type_financing", typeFin);
            NpgsqlParameter parameter4 = new NpgsqlParameter("_status", status);
            await _db.Database.ExecuteSqlRawAsync("call comission.update_status_specialization_applicants(@_snils, @specializationid, @type_financing,  @_status)", parameter1, parameter2, parameter3, parameter4);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in update_status_document {e.Message}");
        }
    }
    
    public static async Task<Dictionary<string, string>> GetDocumentData(int? applicantId, string documentType)
    {
        try
        {
            var connection = _db.Database.GetDbConnection();
            await connection.OpenAsync();
            var command = connection.CreateCommand();
            command.Parameters.Add(new NpgsqlParameter("applicantId", applicantId));
            command.Parameters.Add(new NpgsqlParameter("documentType", documentType));
            command.CommandText = "select comission.get_document_data(@applicantId, @documentType)";
            
            var resultData = await command.ExecuteScalarAsync();
            await connection.CloseAsync();
            
            return DeserializeDictionary(resultData as string);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in get_document_data {e.Message}");
        }
    }
    
    public static async Task<Dictionary<string, string>> GetApplicantDocuments(string snils)
    {
        try
        {
            var connection = _db.Database.GetDbConnection();
            await connection.OpenAsync();
            var command = connection.CreateCommand();
            command.Parameters.Add(new NpgsqlParameter("_snils", snils));

            command.CommandText = "select comission.get_documents_applicant(@_snils)";
            
            var resultData = await command.ExecuteScalarAsync();
            await connection.CloseAsync();
            
            return DeserializeDictionary(resultData as string);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Error in get_document_data {e.Message}");
        }
    }

    private static Dictionary<string, string> DeserializeDictionary(string? data)
    {
        if (data is not string)
        {
            return null;
        }

        Dictionary<string, string> result = new Dictionary<string, string>();

           
        string[] pairs = (data as string).Split(";");

            
        foreach (string pair in pairs)
        {
                
            string[] keyValue = pair.Split(":");

                
            if (keyValue.Length == 2)
            {
                string key = keyValue[0].Trim();
                string value = keyValue[1].Trim();
                    
                Console.WriteLine(key);
                Console.WriteLine(value);

                    
                if (!result.ContainsKey(key))
                {
                    result.Add(key, value);
                }
            }
        }

        return result;
    }

    #endregion
}