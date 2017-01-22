using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace JonesFamilyBusinessApp.Models.ModelsValidation
{
    // Server side validations. Used as annotation in model

    /// <summary>
    /// Validate time with format hh:mm where hh between 0 and 23 and mm between 0 and 59 dividable by 15
    /// </summary>
    public class TimeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide Time");
            }
            else
            {
                if (!Regex.IsMatch(value.ToString(), @"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:00$"))
                {
                    return new ValidationResult("Format Incorrect");
                }
                else
                {
                    TimeSpan ts = new TimeSpan();
                    if (!TimeSpan.TryParse(value.ToString(), out ts))
                    {
                        return new ValidationResult("Format Incorrect");
                    }
                    else
                    {
                        if (ts.Hours < 0)
                        {
                            return new ValidationResult("Start time must be greater or equal than 0");
                        }
                        if (ts.Minutes % 15 != 0)
                        {
                            return new ValidationResult("Minutes must be dividable for 15");
                        }
                    }
                }
                return ValidationResult.Success;
            }
        }
    }

    /// <summary>
    /// Validate hours with format #.## or #,## where hours is dividable by 0.25. first part between 0 and 11
    /// </summary>
    public class HoursValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide Hours");
            }
            else
            {
                if (!Regex.IsMatch(value.ToString(), @"^(\d|1[0-1]?)([.|,](((00|25)|50)|75))?$"))
                {
                    return new ValidationResult("Format Incorrect");
                }
                else
                {
                    decimal number = 0;
                    if (!decimal.TryParse(value.ToString(), out number))
                    {
                        return new ValidationResult("Format Incorrect");
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}