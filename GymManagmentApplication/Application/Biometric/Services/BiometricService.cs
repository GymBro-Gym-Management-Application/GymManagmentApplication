using GymManagmentApplication.Application.Biometric.Interfaces;
using GymManagmentApplication.Application.Biometric.Requests;
using GymManagmentApplication.Application.Biometric.Responses;

namespace GymManagmentApplication.Application.Biometric.Services;

public class BiometricService : IBiometricService
{
    private static readonly HashSet<ulong> _enrolledFaces = [];
    private static readonly HashSet<ulong> _enrolledFingerprints = [];
    private static readonly List<EntryLogResponse> _entryLogs = [];
    private static ulong _logId = 1;

    public Task<BiometricEnrollResponse> EnrollFaceAsync(EnrollFaceRequest request)
    {
        _enrolledFaces.Add(request.UserId);
        return Task.FromResult(new BiometricEnrollResponse
        {
            UserId = request.UserId, BiometricType = "Face",
            Success = true, EnrolledAt = DateTime.UtcNow
        });
    }

    public Task<BiometricVerifyResponse> VerifyFaceAsync(VerifyFaceRequest request)
    {
        // In production: run face recognition model against enrolled templates
        var verified = _enrolledFaces.Count > 0;
        var userId = _enrolledFaces.FirstOrDefault();
        var log = new EntryLogResponse { LogId = _logId++, UserId = userId, EntryType = "Face", AccessGranted = verified, Timestamp = DateTime.UtcNow };
        _entryLogs.Add(log);
        return Task.FromResult(new BiometricVerifyResponse { Verified = verified, UserId = verified ? userId : null, Confidence = verified ? 0.97 : 0.0, VerifiedAt = DateTime.UtcNow });
    }

    public Task<bool> DeleteBiometricAsync(ulong userId)
    {
        var face = _enrolledFaces.Remove(userId);
        var finger = _enrolledFingerprints.Remove(userId);
        return Task.FromResult(face || finger);
    }

    public Task<List<EntryLogResponse>> GetEntryLogsAsync(ulong tenantId, int pageNumber, int pageSize) =>
        Task.FromResult(_entryLogs.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList());

    public Task<BiometricEnrollResponse> EnrollFingerprintAsync(EnrollFingerprintRequest request)
    {
        _enrolledFingerprints.Add(request.UserId);
        return Task.FromResult(new BiometricEnrollResponse
        {
            UserId = request.UserId, BiometricType = "Fingerprint",
            Success = true, EnrolledAt = DateTime.UtcNow
        });
    }

    public Task<BiometricVerifyResponse> VerifyFingerprintAsync(VerifyFingerprintRequest request)
    {
        var verified = _enrolledFingerprints.Count > 0;
        var userId = _enrolledFingerprints.FirstOrDefault();
        var log = new EntryLogResponse { LogId = _logId++, UserId = userId, EntryType = "Fingerprint", AccessGranted = verified, Timestamp = DateTime.UtcNow };
        _entryLogs.Add(log);
        return Task.FromResult(new BiometricVerifyResponse { Verified = verified, UserId = verified ? userId : null, Confidence = verified ? 0.99 : 0.0, VerifiedAt = DateTime.UtcNow });
    }
}
