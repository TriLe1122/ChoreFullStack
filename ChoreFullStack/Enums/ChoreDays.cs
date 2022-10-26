using System.Text.Json.Serialization;
namespace Chore.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]

public enum ChoreDays
{
  Monday,
  Tuesday,
  Wednesday,
  Thursday,
  Friday
}