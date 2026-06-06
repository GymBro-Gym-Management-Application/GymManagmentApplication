using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Member.Interfaces;
using GymManagmentApplication.Application.Member.Requests;
using GymManagmentApplication.Application.Member.Responses;
using GymManagmentApplication.Domain.Entities.Identity;
using GymManagmentApplication.Domain.Enums;
using GymManagmentApplication.Infrastructure.Repositories.Member;
using Microsoft.AspNetCore.Http;

namespace GymManagmentApplication.Application.Member.Services;

public class MemberService(IMemberRepository repository) : IMemberService
{
    // In-memory stores for notes, documents, tags (replace with DB repositories as needed)
    private static readonly List<(ulong MemberId, MemberNoteResponse Note)> _notes = [];
    private static readonly List<(ulong MemberId, MemberDocumentResponse Doc)> _documents = [];
    private static readonly Dictionary<ulong, List<string>> _tags = [];
    private static ulong _noteId = 1;
    private static ulong _docId = 1;

    public async Task<PagedResponse<MemberResponse>> GetAllAsync(MemberSearchRequest request)
    {
        var (items, total) = await repository.GetAllAsync(request);
        return new PagedResponse<MemberResponse>
        {
            Items = items.Select(Map),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalRecords = total
        };
    }

    public async Task<MemberResponse> CreateAsync(CreateMemberRequest request)
    {
        var user = new User
        {
            TenantId = request.TenantId,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Gender = Enum.TryParse<UserGender>(request.Gender, true, out var g) ? g : null,
            Dob = request.Dob,
            AvatarUrl = request.AvatarUrl,
            PasswordHash = string.Empty,
            Uuid = Guid.NewGuid().ToString(),
            RoleId = 0,
            Status = UserStatus.Active
        };
        var created = await repository.CreateAsync(user);
        return Map(created);
    }

    public async Task<MemberResponse?> GetByIdAsync(ulong id)
    {
        var user = await repository.GetByIdAsync(id);
        return user is null ? null : Map(user);
    }

    public async Task<MemberResponse?> UpdateAsync(ulong id, UpdateMemberRequest request)
    {
        var user = await repository.GetByIdAsync(id);
        if (user is null) return null;
        if (request.FirstName is not null) user.FirstName = request.FirstName;
        if (request.LastName is not null) user.LastName = request.LastName;
        if (request.Phone is not null) user.Phone = request.Phone;
        if (request.Dob.HasValue) user.Dob = request.Dob;
        if (request.AvatarUrl is not null) user.AvatarUrl = request.AvatarUrl;
        if (request.Gender is not null) user.Gender = Enum.TryParse<UserGender>(request.Gender, true, out var g) ? g : user.Gender;
        await repository.UpdateAsync(user);
        return Map(user);
    }

    public Task<bool> DeleteAsync(ulong id) => repository.SoftDeleteAsync(id);

    public async Task<List<MemberResponse>> BulkImportAsync(BulkImportMemberRequest request)
    {
        var results = new List<MemberResponse>();
        foreach (var r in request.Members)
            results.Add(await CreateAsync(r));
        return results;
    }

    public async Task<List<MemberTimelineResponse>> GetTimelineAsync(ulong id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user is null) return [];
        return
        [
            new() { EventType = "Created", Description = "Member profile created.", OccurredAt = user.CreatedAt }
        ];
    }

    public async Task<string> UploadPhotoAsync(ulong id, IFormFile photo)
    {
        var user = await repository.GetByIdAsync(id);
        if (user is null) return string.Empty;
        var url = $"/uploads/members/{id}/{photo.FileName}";
        user.AvatarUrl = url;
        await repository.UpdateAsync(user);
        return url;
    }

    public Task<List<MemberNoteResponse>> GetNotesAsync(ulong id) =>
        Task.FromResult(_notes.Where(n => n.MemberId == id).Select(n => n.Note).ToList());

    public Task<MemberNoteResponse> AddNoteAsync(ulong id, AddMemberNoteRequest request)
    {
        var note = new MemberNoteResponse { Id = _noteId++, Note = request.Note, TrainerId = request.TrainerId, CreatedAt = DateTime.UtcNow };
        _notes.Add((id, note));
        return Task.FromResult(note);
    }

    public Task<List<MemberDocumentResponse>> GetDocumentsAsync(ulong id) =>
        Task.FromResult(_documents.Where(d => d.MemberId == id).Select(d => d.Doc).ToList());

    public Task<MemberDocumentResponse> UploadDocumentAsync(ulong id, IFormFile file, string? documentType)
    {
        var doc = new MemberDocumentResponse
        {
            Id = _docId++,
            FileName = file.FileName,
            Url = $"/uploads/members/{id}/docs/{file.FileName}",
            DocumentType = documentType,
            UploadedAt = DateTime.UtcNow
        };
        _documents.Add((id, doc));
        return Task.FromResult(doc);
    }

    public Task<PagedResponse<MemberResponse>> SearchAsync(MemberSearchRequest request) => GetAllAsync(request);

    public Task<List<string>> GetTagsAsync(ulong id) =>
        Task.FromResult(_tags.TryGetValue(id, out var t) ? t : []);

    public Task<bool> AssignTagsAsync(ulong id, AssignTagsRequest request)
    {
        _tags[id] = request.Tags;
        return Task.FromResult(true);
    }

    private static MemberResponse Map(User u) => new()
    {
        Id = u.Id,
        TenantId = u.TenantId,
        Email = u.Email,
        FirstName = u.FirstName,
        LastName = u.LastName,
        Phone = u.Phone,
        Gender = u.Gender?.ToString(),
        Dob = u.Dob,
        AvatarUrl = u.AvatarUrl,
        Status = u.Status.ToString(),
        CreatedAt = u.CreatedAt
    };
}
