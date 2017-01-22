// Manages styles of index View
// This library is used instead of use unobtrusive to show error
// Allows to have more control over the UI
var UIControler = (function () {

    // UI Constants
    var DOMstrings = {
        formGroupError: 'has-error',
        columnErrorAlert: 'alert',
        columnErrorAlertDanger: 'alert-danger',
        columnErrorId: 'ErrorColumn'
    }

    return {

        // Add Error styles for elementID
        addError: function (elementId, errorString) {

            //Add Error class on form group
            var input = document.getElementById(elementId);
            input.parentNode.parentNode.classList.add(DOMstrings.formGroupError);

            //Get Column error from elementId
            var errorColumn = document.getElementById(elementId + DOMstrings.columnErrorId);

            // Add class to error column
            errorColumn.classList.add(DOMstrings.columnErrorAlert,DOMstrings.columnErrorAlertDanger);

            //Show error in last column
            var html = '<span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>'
                    + '<span class="sr-only">Error:</span>'
                    + errorString;
            errorColumn.insertAdjacentHTML('beforeend', html);
        },

        // Remove error styles from elementId
        removeError: function (elementId) {
            // Remove error class on form group
            var input = document.getElementById(elementId);
            input.parentNode.parentNode.classList.remove(DOMstrings.formGroupError);

            //Get Column error from elementId
            var errorColumn = document.getElementById(elementId + DOMstrings.columnErrorId);

            // Remove content
            while (errorColumn.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }

            //Remove class error
            errorColumn.classList.remove(DOMstrings.columnError);
        }
    }
})();