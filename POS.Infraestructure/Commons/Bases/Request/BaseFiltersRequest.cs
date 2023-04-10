namespace POS.Infraestructure.Commons.Bases.Request;

public class BaseFiltersRequest : BasePaginationRequest
{
    public int? NumFilter { get; set; }
    public string? TextFilter { get; set; }
    public int? StateFilter { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool Download { get; set; }
}

