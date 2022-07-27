namespace contracted.Models
{
  public class Contractor
  {
    public int id { get; set; }
    public string name { get; set; }
  }

  public class ContractorJobViewModel : Contractor
  {
    public int jobId { get; set; }
    // public string banana { get; set; }
  }
}