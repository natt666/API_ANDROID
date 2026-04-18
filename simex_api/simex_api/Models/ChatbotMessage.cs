using System;
using System.Collections.Generic;

namespace simex_api.Models;

public partial class ChatbotMessage
{
    public long Id { get; set; }

    public long? UsuariId { get; set; }

    public string Provider { get; set; } = null!;

    public string? Model { get; set; }

    public string Prompt { get; set; } = null!;

    public string? Reply { get; set; }

    public string Status { get; set; } = null!;

    public string? Error { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
