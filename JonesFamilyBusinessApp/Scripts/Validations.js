//Client side validations

// Validate if value is a valid time. Uses fieldName to set the message of error
// Validate time with format hh:mm where hh between 0 and 23 and mm between 0 and 59 dividable by 15
function TimeValidation(value, fieldName) {
    if (value == null) // Checking for Empty Value
    {
        return 'Please Provide Start Time';
    }
    else {
        var patt = new RegExp('^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$');
        var res = patt.test(value);

        if (!res) {
            return fieldName +': Format Incorrect';
        }
        else {
            var hour = value.split(':')[0];
            var minutes = value.split(':')[1];

            if (hour == null || minutes == null) {
                return fieldName + ': Format Incorrect'
            }
            else {
                if (hour < 0) {
                    return fieldName + ': must be greater or equal than 0';
                }
                if (minutes % 15 != 0) {
                    return fieldName + ': Minutes must be dividable for 15';
                }
            }
        }
    }
    return '';
}

// Validate hours with format #.## or #,## where hours is dividable by 0.25. first part between 0 and 11
function HoursValidation(value) {
    if (value == null) // Checking for Empty Value
    {
        return 'Please Provide Hours';
    }
    else {
        var patt = new RegExp('^([0-9]|1[0-1]?)([.|,](((00?|25)|50?)|75))?$');
        var res = patt.test(value);

        if (!res) {
            return 'Hours: Format Incorrect';
        }
        else {

            if (isNaN(value)) {
                return 'Hours: Is not a number';
            }
        }
    }
    return '';
}

// Validate form in index view
function IsValidForm() {

    var startTimeIsValid = TimeValidation(document.getElementById(DOMstrings.startTimeId).value.replace(/['"]+/g, ''),"Start Time");
    var endTimeIsValid = TimeValidation(document.getElementById(DOMstrings.endTimeId).value.replace(/['"]+/g, ''), "End Time");
    var hoursIsValid = HoursValidation(document.getElementById(DOMstrings.hoursId).value.replace(/['"]+/g, ''));


    var FinalErrorMessage = 'Errors:';
    if (startTimeIsValid != '')
    {
        FinalErrorMessage += '\n' + startTimeIsValid;
    }
    if (endTimeIsValid != '')
    {
        FinalErrorMessage += '\n' + endTimeIsValid;
    }
    if (hoursIsValid != '') {
        FinalErrorMessage += '\n' + hoursIsValid;
    }

    if(FinalErrorMessage != 'Errors:')
    {
        alert(FinalErrorMessage);
        return false;
    }
    else
    {
        return true;
    }
}

// Dom constants
var DOMstrings = {
    startTimeId: 'startTime',
    hoursId: 'hours',
    endTimeId: 'endTime'
}