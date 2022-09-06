namespace ODataSample.Entities
{
  public class CustomerActivity : EntityBase
  {
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public int ActivityId { get; set; }
    public Activity? Activity { get; set; }
  }

}
