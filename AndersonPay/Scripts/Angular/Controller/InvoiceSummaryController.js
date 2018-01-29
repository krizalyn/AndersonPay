//app.controller("myCtrl", function ($scope, $http) {
//    //Download a pdf
//    $scope.downloadPdf = function (InvoiceId) {
//        var isOkay = true;
//        if (InvoiceId !== undefined) {
      
//            var data = {
//                AmountDue: $scope.AmountDue
//            }
//            $http.post('/Invoice/DownloadPdf', data)
//                .then(window.open('/Invoice/InvoiceSummary'));

//        } else {
//            toastr.warning("There must be no zero (0) value of unit price.", "Invalid Unit Price");
//        }
//}