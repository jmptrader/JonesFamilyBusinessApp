namespace JonesFamilyBusinessApp.Models
{
    /// <summary>
    /// Exposes only methods needed for all the models
    /// </summary>
    public interface IModel
    {

        // return string to perform insert in SQL Server DB
        string getInsertQuery();
        
        // return string to perform select in SQL Server DB and get all items related to model
        string getSelectQuery();
    }
}
