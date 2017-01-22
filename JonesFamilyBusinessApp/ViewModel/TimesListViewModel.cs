using System.Data;

namespace JonesFamilyBusinessApp.ViewModel
{
    /// <summary>
    /// Data structure needed to show times in TimesList partial view
    /// </summary>
    public class TimesListViewModel
    {
        public TimesListViewModel()
        {
            dt = new DataTable();
        }
        public DataTable dt { get; set; }
    }
}