using JonesFamilyBusinessApp.Models.ModelsValidation;
using System;
using System.Collections.Generic;

namespace JonesFamilyBusinessApp.ViewModel
{
    /// <summary>
    /// Used to store data from index view, validate properties and build TimeModel
    /// When an error occurs, store error data and show it in view
    /// </summary>
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            errors = new Dictionary<string, string>();
        }
        [TimeValidation]
        public TimeSpan startTime { get; set; }
        [HoursValidation]
        public decimal hours { get; set; }
        [TimeValidation]
        public TimeSpan endTime { get; set; }
        public Dictionary<string,string> errors { get; set; }
    }
}