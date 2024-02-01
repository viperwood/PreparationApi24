using PreparationApi.Context;

namespace PreparationApi;

public class Helper
{
    public static readonly PostgresContext Database = new PostgresContext();
}