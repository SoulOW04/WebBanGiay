R.CauHinh = {
    Init: function () {
        R.CauHinh.InitCkEditor();
        R.CauHinh.RegisterEvent();
    },
    RegisterEvent: function () {
        
            $('.create-cauhinh').off('click').on('click', function () {
            var tenCauHinh = $('#TenCauHinh').val();
            var maCauHinh = $('#MaCauHinh').val();
            var giaTriCauHinh = $('#GiaTriCauHinh').attr('src');
            var parentId = $('#ParentId').val();
            var loai = $('#Loai').val();
            var trangThai = $('#TrangThai').val();
            var moTa = CKEDITOR.instances.ckMota.getData();
            var params = {
                Id: 0,
            TenCauHinh: tenCauHinh,
            MaCauhinh: maCauHinh,
            GiaTriCauhinh: giaTriCauHinh,
            Loai: loai,
            TrangThai: trangThai,
            MoTa: moTa,
            ParentId: parentId
            }

            $.post('/CauHinhs/Create', params, function (response) {
                
            window.location.href = "/CauHinhs/Index"
            })

            })

        $('.edit-cauhinh').off('click').on('click', function () {
            debugger
            var tenCauHinh = $('#TenCauHinh').val();
            var maCauHinh = $('#MaCauHinh').val();
            var giaTriCauHinh = $('#GiaTriCauHinh').attr('src');
            var parentId = $('#ParentId').val();
            var loai = $('#Loai').val();
            var trangThai = $('#TrangThai').val();
            var moTa = CKEDITOR.instances.ckMota.getData();
            var params = {
                Id: $('.id-sp').val(),
                TenCauHinh: tenCauHinh,
                MaCauhinh: maCauHinh,
                GiaTriCauhinh: giaTriCauHinh,
                Loai: loai,
                TrangThai: trangThai,
                MoTa: moTa,
                ParentId: parentId
            }

            $.post('/CauHinhs/Edit', params, function (response) {
                alert('Chỉnh sửa thành công!');
                window.location.href = "/CauHinhs/Index"
            })

        })
        
    },
    InitCkEditor: function () {
        CKEDITOR.replace('ckMota');
        R.CauHinh.RegisterEvent();
    },
    CreateCauHinh: function (params) {
        $.post('/CauHinhs/Create', params, function (response) {
            alert('Them moi thanh cong!');
            window.location.href = "/CauHinhs/Index"
            R.CauHinh.RegisterEvent();
        })
    }

}
R.CauHinh.Init();