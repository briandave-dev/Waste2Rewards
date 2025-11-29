namespace Waste2Rewards.Models;

public class WastePickup
{
    public string Id { get; set; }
    public string UserId { get; set; } = "USER001";
    public string PickupType { get; set; } // "normal" or "with_cleaning"
    public string Area { get; set; }
    public string Address { get; set; }
    public string Frequency { get; set; } // "once", "weekly", "fortnightly"
    public DateTime Date { get; set; }
    public string WasteType { get; set; } // "Electrical Waste", "Carbon Emission", "Home Waste"
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public string Status { get; set; } // "requested", "cancelled", "done"
    public DateTime CreatedAt { get; set; }
}