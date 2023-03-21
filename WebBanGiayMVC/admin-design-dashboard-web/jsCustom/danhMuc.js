R.DanhMuc = {
    Init: function () {
        R.DanhMuc.InitCkEditor();
        R.DanhMuc.RegisterEvent();
    },
    RegisterEvent: function () {
        $('.create-danhmuc').off('click').on('click', function () {
           
            var tenDanhMuc = $('#TenDanhMuc').val();
            //var moTaDanhmuc = $('#MoTaDanhmuc').val();
            var moTa = CKEDITOR.instances.ckMotaDanhMuc.getData();
            var bannerDanhMuc = $('#BannerDanhMuc').val();
            var avatarDanhMuc = $('#AvatarDanhMuc').val();
            var loai = $('#Loai').val();
            var trangThai = $('#TrangThai').val();

            var params = {
                Id: 0,
                TenDanhMuc: tenDanhMuc,
                BannerDanhMuc: bannerDanhMuc,
                AvatarDanhMuc: avatarDanhMuc,
                Loai: loai,
                TrangThai: trangThai,
                MoTaDanhmuc: moTa
            }
            R.DanhMuc.CreateDanhMuc(params);
        })
    },
    InitCkEditor: function () {
        CKEDITOR.replace('ckMotaDanhMuc');
        R.DanhMuc.RegisterEvent();
    },
    CreateDanhMuc: function (params) {
        $.post('/DanhMucs/Create', params, function (response) {
            alert('Them moi thanh cong!');
            window.location.href = "/DanhMucs/Index"
            R.DanhMuc.RegisterEvent();
        })
    }

}
R.DanhMuc.Init();