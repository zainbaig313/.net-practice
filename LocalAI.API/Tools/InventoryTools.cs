
public class InventoryTools
{
    public Task<int> GetProductCountAsync()
    {
        // Temporary hardcoded value.
        // Later, we will retrieve this from SQL Server.

        return Task.FromResult(125);
    }
}
