using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCitiesAPI.Data.Models;

public class City
{
    #region Properties
    /// <summary>
    /// The Unique id and primary key for this City
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }
    /// <summary>
    /// City name (in UTF8 fotmat)
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// City Latitude
    /// </summary>
    [Column(TypeName = "decimal(7, 4)")]
    public decimal Lat { get; set; }
    /// <summary>
    /// City Longitude
    /// </summary>
    [Column(TypeName ="decimal(7, 4)")]
    public decimal Lon {  get; set; }
    /// <summary>
    /// Country Id(foreign key
    /// </summary>
    public int CountryId { get; set; }
    #endregion
}
