R.SanPham = {
    Init: function () {
        R.SanPham.InitCkEditor();
        R.SanPham.InitSelect2();
        R.SanPham.RegisterEvent();

    },
    RegisterEvent: function () {
        $('.create-sanpham').off('click').on('click', function () {
            
            var tenSanPham = $('#TenSanPham').val();
            //var moTaDanhmuc = $('#MoTaDanhmuc').val();
            var moTaSanPham = CKEDITOR.instances.ckMotaSanPham.getData();
            var giaSanPham = $('#GiaSanPham').val();
            var avatarSanPham = $('#AvatarSanPham').attr('src'); 
            var danhSachAnhSanPham = $('#DanhSachAnhSanPham').attr('src');
            var noiDungSanPham = $('#NoiDungSanPham').val();
            var hangSanPham = $('#HangSanPham').val();
            var loai = $('#Loai').val();
            var trangThai = $('#TrangThai').val();
            var danhSachDanhMuc = $('.dsDanhMuc').val().toString();

            var params = {
                Id: 0,
                TenSanPham: tenSanPham,
                MoTaSanPham: moTaSanPham,
                GiaSanPham: giaSanPham,
                AvatarSanPham: avatarSanPham,
                DanhSachAnhSanPham: danhSachAnhSanPham,
                NoiDungSanPham: noiDungSanPham,
                HangSanPham: hangSanPham,
                Loai: loai,
                TrangThai: trangThai,
                DanhSachDanhMucs: danhSachDanhMuc
            }
            //console.log(params);
            R.SanPham.CreateSanPham(params);
        })
    },
    InitCkEditor: function () {
        CKEDITOR.replace('ckMotaSanPham');
        R.SanPham.RegisterEvent();
    },
    CreateSanPham: function (params) {
        $.post('/SanPhams/CreateWithDanhMuc', params, function (response) {
            alert('Them moi thanh cong!');
            window.location.href = "/SanPhams/AdminIndex"
            R.SanPham.RegisterEvent();
        })
    },
    InitSelect2: function () {
        $('.dsDanhMuc').select2();
    }

}
R.SanPham.Init();