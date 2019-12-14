// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
Date.prototype.getWeekNumber = function () {

    var oneJan =
        new Date(this.getFullYear(), 0, 1);

    // calculating number of days  
    //in given year before given date 

    var numberOfDays =
        Math.floor((this - oneJan) / (24 * 60 * 60 * 1000));

    // adding 1 since this.getDay() 
    //returns value starting from 0 

    return Math.ceil((this.getDay() + 1 + numberOfDays) / 7);

}

function printWeekNumber() {
    var dateInput = document.getElementById("dateInput").value;
    var date = new Date(dateInput);
    var result = date.getWeekNumber();
    var days = ["Søndag", "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "lørdag"];
    document.getElementById("uge").value = result;
    document.getElementById("ugeNavn").value = days[date.getDay()]
    document.getElementById("Status").value = "Ny"
}

function madTilHjem() {
    
    document.getElementById("HjemMad").value = document.getElementById("Menu").value
}

