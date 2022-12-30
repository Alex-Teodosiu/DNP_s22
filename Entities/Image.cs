using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

public class Image
{
    [Key, MaxLength(25)]
    public string Title { get; set; }
    [JsonPropertyName("Description")]
    public string Description { get; set; }
    [JsonPropertyName("Url")]
    public string Url { get; set; }
    [JsonPropertyName("Topic")]
    public string Topic { get; set; }
}