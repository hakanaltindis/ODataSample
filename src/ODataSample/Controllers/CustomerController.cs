using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataSample.Data;
using ODataSample.Entities;

namespace ODataSample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CustomerController : ODataController
  {
    private readonly ODataDbContext _dbContext;

    public CustomerController(ODataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth = 6, MaxAnyAllExpressionDepth = 4)]
    public virtual IActionResult Get(ODataQueryOptions<Customer> options)
    {
      return Ok(options.ApplyTo(_dbContext.Customers, AllowedQueryOptions.All));
    }
  }

  [Route("[controller]")]
  [ApiController]
  public class ActivityController : ODataController
  {
    private readonly ODataDbContext _dbContext;

    public ActivityController(ODataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth = 6, MaxAnyAllExpressionDepth = 4)]
    public virtual IActionResult Get(ODataQueryOptions<Activity> options)
    {
      return Ok(options.ApplyTo(_dbContext.Activities, AllowedQueryOptions.All));
    }
  }

  [Route("[controller]")]
  [ApiController]
  public class CustomerActivityController : ODataController
  {
    private readonly ODataDbContext _dbContext;

    public CustomerActivityController(ODataDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth = 6, MaxAnyAllExpressionDepth = 4)]
    public virtual IActionResult Get(ODataQueryOptions<CustomerActivity> options)
    {
      return Ok(options.ApplyTo(_dbContext.CustomerActivities, AllowedQueryOptions.All));
    }
  }
}
