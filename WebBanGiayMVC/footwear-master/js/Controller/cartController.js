var cart = {
    init: function () {
        cart.regEvents();
    },

    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        //$('.btn-delete').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    $.ajax({
        //        data: { id: $(this).data('id') },
        //        url: 'GioHang/Delete',
        //        dataType: 'Json',
        //        type: 'POST',
        //        success: function (res) {
        //            if (res.status == true) {
        //                window.location.href = "/GioHang/Cart";
        //            }
        //        }

        //    })
        //});
    }

    


}
cart.init();