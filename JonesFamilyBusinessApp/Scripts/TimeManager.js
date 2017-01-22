//Exposes time functions

//Add hours to startTime and return it
function TimeCalculator(startTime, hours)
{
    var startDate = new Date();
    var hour = startTime.split(":")[0];
    var min = startTime.split(":")[1];
    startDate.setHours(hour, min);
    var minutesToAdd = hours * 60;
    var endDate = new Date(startDate.getTime() + minutesToAdd * 60000);
    var time = ("0" + endDate.getHours()).slice(-2) + ":" + ("0" + endDate.getMinutes()).slice(-2);
    return time;
}

//Changes value of an Dom element. Insert endTime from startTime + Hours
function ChangeTime(startTimeId, hoursId, endTimeId) {
    var startTime = document.getElementById(startTimeId).value;
    var hours = document.getElementById(hoursId).value;
    document.getElementById(endTimeId).value = TimeCalculator(startTime, hours);
}