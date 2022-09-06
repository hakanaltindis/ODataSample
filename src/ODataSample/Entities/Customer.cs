namespace ODataSample.Entities
{
  public class Customer : EntityBase
  {
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public List<CustomerActivity> CustomerActivities { get; set; } = new List<CustomerActivity>();
  }

}
