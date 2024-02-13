namespace Domain.Contracts.RepositoryRelated;

public interface IRequestParameters
{
    int PageIndex { get; set; }

    int ItemQuantity { get; set; }
    
    string SortingType { get; set; }
}