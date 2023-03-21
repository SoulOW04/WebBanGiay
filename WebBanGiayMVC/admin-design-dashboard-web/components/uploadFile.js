R.UploadFile = {
    Init: function () {
        R.UploadFile.RegisterEvent();
    },
    RegisterEvent: function () {
        $('.upload-single-input').off('change').on('change', function () {
            var dt = new FormData();
            dt.append('file', $(this)[0].files[0]);
            R.UploadFile.DoUpload(dt, $(this));
        })
    },
    DoUpload: function (dt, element) {
        $.ajax({
            method: 'post',
            url: '/UploadFiles/UploadSingleFile',
            data: dt,
            contentType: false,
            processData: false,
            success: function (response) {
                var url = response.replace('\\', '/')
                R.UploadFile.ShowImageAfterUpload(element, url);
            },
            error: function (err) {
                console.log(err)
            }
        })
    },
    ShowImageAfterUpload: function (element, url) {
        $(element).parent().find('.preview-picture').attr('src', url)
    }
}
R.UploadFile.Init();