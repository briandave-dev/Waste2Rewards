using Waste2Rewards.Models;

namespace Waste2Rewards.Services;

public interface IWastePickupService
{
    Task Create(WastePickup request);
    Task<List<WastePickup>> GetHistory(string userId);
    Task Cancel(string id);
    Task<WastePickup> GetById(string id);
}

public class WastePickupService : IWastePickupService
{
    private static List<WastePickup> _pickups = new();

    public Task Create(WastePickup request)
    {
        request.Id = Guid.NewGuid().ToString();
        request.Status = "requested";
        request.CreatedAt = DateTime.Now;
        _pickups.Add(request);
        return Task.CompletedTask;
    }

    public Task<List<WastePickup>> GetHistory(string userId)
    {
        var history = _pickups
            .Where(p => p.UserId == userId)
            .OrderByDescending(p => p.CreatedAt)
            .ToList();
        return Task.FromResult(history);
    }

    public Task Cancel(string id)
    {
        var pickup = _pickups.FirstOrDefault(p => p.Id == id);
        if (pickup != null && pickup.Status == "requested")
        {
            pickup.Status = "cancelled";
        }
        return Task.CompletedTask;
    }

    public Task<WastePickup> GetById(string id)
    {
        var pickup = _pickups.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(pickup);
    }
}