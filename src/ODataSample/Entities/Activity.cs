namespace ODataSample.Entities
{
  public class Activity : EntityBase
  {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<CustomerActivity> CustomerActivities { get; set; } = new List<CustomerActivity>();
  }

}
