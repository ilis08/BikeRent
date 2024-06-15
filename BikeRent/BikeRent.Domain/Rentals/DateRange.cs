namespace BikeRent.Domain.Rentals;

public record DateRange
{
    private DateRange()
    {

    }

    public DateTime Start { get; init; }
    public DateTime End { get; init; }

    public TimeSpan Duration => End - Start;

    public static DateRange Create(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new ApplicationException("End date precedes start date");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}
