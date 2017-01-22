using System;

namespace JonesFamilyBusinessApp.Models
{
    /// <summary>
    /// Stores data for index form
    /// </summary>
    public class TimeModel:IModel
    {
        public TimeSpan startTime { get; set; }
        public decimal hours { get; set; }
        public TimeSpan endTime { get; set; }


        #region Persistence
        private string tableName = "time";
        public string getInsertQuery()
        {

            return string.Format("INSERT INTO {0}.dbo.{1} ({2}) VALUES ({3});"
                , SystemConstants.DbName
                , tableName
                , "startTime,hour,endTime"
                , "'" + startTime.ToString("hh\\:mm") + "','" + hours + "','" + endTime.ToString("hh\\:mm") +"'");
        }
        public string getSelectQuery()
        {
            return string.Format("SELECT * FROM {0}.dbo.{1}"
                ,SystemConstants.DbName
                ,tableName );
        }
        #endregion
    }
}