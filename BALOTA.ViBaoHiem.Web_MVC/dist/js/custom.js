function ShowErrorModalPopup(title, message, urlToRedirect) {
    BootstrapDialog.show({
        title: title,
        message: message,
        buttons: [{
            label: 'Đóng',
            action: function (dialog) {
                dialog.close();
                if (urlToRedirect != null && urlToRedirect != 'undefined' && urlToRedirect != '') {
                    window.location = urlToRedirect;
                }
            }
        }]
    });
}
function ShowModalAlertMessageWithCallbackButton(title, message, callbackButtonLabel, callbackFunction, cancelCallbackFunction) {
    BootstrapDialog.show({
        title: title,
        message: message,
        buttons: [{
            label: callbackButtonLabel,
            cssClass: 'btn-primary',
            action: function (dialog) {
                dialog.close();
                if (callbackFunction != null && callbackFunction != 'undefined' && callbackFunction != '') {
                    eval(callbackFunction);
                }
            }
        }, {
            label: 'Đóng',
            action: function (dialog) {
                dialog.close();
                if (cancelCallbackFunction != null && cancelCallbackFunction != 'undefined' && cancelCallbackFunction != '') {
                    eval(cancelCallbackFunction);
                }
            }
        }]
    });
}
