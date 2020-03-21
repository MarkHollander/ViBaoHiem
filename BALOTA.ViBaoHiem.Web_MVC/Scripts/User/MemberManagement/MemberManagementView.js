var createAgencyFormFlag = true;

function OnCallCreateAgencyBegin() {
    let alertText = "";
    let emptyStringInputArr = ['Username', 'FullName', 'Password', 'Email', 'Mobile'];
    let emptyStringOutputArr = [];
    emptyStringInputArr.forEach(function (currentValue) {
        if (IsEmptyInput(currentValue)) {
            emptyStringOutputArr.push(currentValue);
            createAgencyFormFlag = false;
        };
    });

    if (emptyStringOutputArr.length > 0) {
        alertText = emptyStringOutputArr.toString();
        if (emptyStringOutputArr.length > 1) alertText += " are required";
        else alertText += " is required";
        $('#CreateAgencyAlert').text(alertText);
        $('#CreateAgencyAlert').removeClass('d-none');
    }
    if (createAgencyFormFlag) {
        createAgencyFormFlag = $('#Password').val() === $('#Pass2').val();
        alertText = "Confirmed Password do not match Password";
        $('#CreateAgencyAlert').text(alertText);
        $('#CreateAgencyAlert').removeClass('d-none');
    };    
    return createAgencyFormFlag;
};

function OnCallCreateAgencySuccess(data) {    
    $('#CreateAgencyAlert').text(data.result);
    $('#CreateAgencyAlert').removeClass('d-none');
    if (data.memberid > 0) setTimeout(CloseMemberManagementModal, 3000);
};

function OnCallUpdateAgencySuccess(data) {
    $('#UpdateAgencyAlert').text(data.result);
    $('#UpdateAgencyAlert').removeClass('d-none');
    if (data.memberid > 0) setTimeout(CloseMemberManagementModal, 3000);
};

function CloseMemberManagementModal() {
    $("#MemberManagementModal").modal('hide');
    location.reload();
}

function OnCallCreateAgencyFailure(error) {
    $('#CreateAgencyAlert').text("Không gọi được server. Xin kiểm tra lại đường truyền");
    $('#CreateAgencyAlert').removeClass('d-none');
}

function OnCallUpdateAgencyFailure(error) {
    $('#UpdateAgencyAlert').text("Không gọi được server. Xin kiểm tra lại đường truyền");
    $('#UpdateAgencyAlert').removeClass('d-none');
}

function IsEmptyInput(input) {
    if (!!$('#' + input).val().trim()) {
        return false;
    }
    $('#' + input).addClass("is-invalid");
    return true;
};

//$('#CreateAgencyForm').on('submit', function (evt) {
//    let form = $(this);
    
//    evt.preventDefault();
//    if (OnCallCreateAgencyBegin()) {
//        $.ajax({
//            type: "POST",
//            url: "/MemberList/MemberList_CreateNewAgency",
//            data: form.serialize(),
//            dataType: "json",
//            success: OnCallCreateAgencySuccess(data),
//            failure: OnCallCreateAgencyFailure(error),
//            error: function (response) {
//                alert(response.responseText);
//            }
//        });
//    }
//    else return false;
//})


$(document).ready(function () {
    $("#MemberManagementModal").on('show.bs.modal', function (event) {
        $('#CreateAgencyAlert').addClass('d-none');
        var button = $(event.relatedTarget);
        let renderPartialView = button.data('renderpartialview');
        let inputId = button.data('inputid');
        switch (renderPartialView) {
            case 1: $.ajax({
                type: "POST",
                url: '/MemberList/MemberList_UpdateAgencyPopup',
                data: { "inputId": inputId },
                dataType: "html",
                success: function (response) {
                    $('#modal-content').html(response);
                },
                failure: function (response) {
                    $('#modal-content').html(response.responseText);
                },
                error: function (response) {
                    $('#modal-content').html(response.responseText);
                }
            }); break;
            case 2: $.ajax({
                type: "POST",
                url: '/MemberList/MemberList_ConfirmDeletePopup',
                data: { "inputId": inputId },
                dataType: "html",
                success: function (response) {
                    $('#modal-content').html(response);
                },
                failure: function (response) {
                    $('#modal-content').html(response.responseText);
                },
                error: function (response) {
                    $('#modal-content').html(response.responseText);
                }
            }); break;
            case 3: $.ajax({
                type: "POST",
                url: '/MemberList/MemberList_AddBalancePopup',
                data: { "inputId": inputId },
                dataType: "html",
                success: function (response) {
                    $('#modal-content').html(response);
                },
                failure: function (response) {
                    $('#modal-content').html(response.responseText);
                },
                error: function (response) {
                    $('#modal-content').html(response.responseText);
                }
            }); break;
            case 4: $.ajax({
                type: "POST",
                url: '/MemberList/MemberList_SubtractBalancePopup',
                data: { "inputId": inputId },
                dataType: "html",
                success: function (response) {
                    $('#modal-content').html(response);
                },
                failure: function (response) {
                    $('#modal-content').html(response.responseText);
                },
                error: function (response) {
                    $('#modal-content').html(response.responseText);
                }
            }); break;
            case 5: $.ajax({
                type: "POST",
                url: '/MemberList/MemberList_CreateAgencyPopup',
                dataType: "html",
                success: function (response) {
                    $('#modal-content').html(response);
                },
                failure: function (response) {
                    $('#modal-content').html(response.responseText);
                },
                error: function (response) {
                    $('#modal-content').html(response.responseText);
                }
            }); break;
        }
    });

    //$("#CreateAgencyModal").on('show.bs.modal', function (event) {
        
    //     $.ajax({
    //            type: "POST",
    //            url: '/MemberList/MemberList_CreateAgencyPopup',                
    //            dataType: "html",
    //            success: function (response) {
    //                $('#CreateAgencyModal-content').html(response);
    //            },
    //            failure: function (response) {
    //                alert(response.responseText);
    //            },
    //            error: function (response) {
    //                alert(response.responseText);
    //            }
    //        });
    //});

    $('#example2').DataTable();
});