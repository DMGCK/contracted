namespace contracted.Models
{
  public class Company
  {
    public int id { get; set; }
    public string name { get; set; }
  }

  public class CompanyJobViewModel : Company
  {
    public int jobId { get; set; }
    // public string contractorName { get; set; }
  }
}