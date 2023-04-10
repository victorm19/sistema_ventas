namespace POS.Infraestructure.Commons.Bases.Request;

public class BasePaginationRequest
{
    public int NumberPage { get; set; } = 1;
    public int NumberRecordPage { get; set; } = 10;
    private readonly int _numberMaxRecordPage = 50;
    public string Order { get; set; } = "asc";
    public string? Sort { get; set; }
    public int Records { 
        get => NumberRecordPage; 
        set
        {
            NumberRecordPage = (value > _numberMaxRecordPage) ? _numberMaxRecordPage : value;
        }
    }
}
