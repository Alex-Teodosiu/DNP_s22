using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Entities;

public class Album
{
    [Key, MaxLength(25)]
    public string Title { get; set; }
    [MaxLength(150)]
    public string Description { get; set; }
    [JsonPropertyName("CreatedBy")]
    public string CreatedBy { get; set; }
    public ICollection<Image> Images { get; set; }
}