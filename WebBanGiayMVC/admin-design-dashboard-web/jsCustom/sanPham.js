R.SanPham = {
    Init: function () {
        R.SanPham.InitCkEditor();
        R.SanPham.InitSelect2();
        R.SanPham.SetValueSelect2();
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

            var thongSoSanPham = [];
            $('.thong-so-item').each((index, element) => {
                //id thong so
                var id = $(element).find('.thong-so-sp').val();
                var giaTri = $(element).find('.gia-tri').val();
                var obj = {
                    ThongSoId: id,
                    GiaTri: giaTri
                }
                thongSoSanPham.push(obj);
            })


            var params = {
                Id: $('.id-sp').val(),
                TenSanPham: tenSanPham,
                MoTaSanPham: moTaSanPham,
                GiaSanPham: giaSanPham,
                AvatarSanPham: avatarSanPham,
                DanhSachAnhSanPham: danhSachAnhSanPham,
                NoiDungSanPham: noiDungSanPham,
                HangSanPham: hangSanPham,
                Loai: loai,
                TrangThai: trangThai,
                DanhSachDanhMucs: danhSachDanhMuc,
                ThongSoInsertUpdates: thongSoSanPham
            }
            console.log(params);
            R.SanPham.SaveSanPham(params);
        })
        $('.add-thong-so').off('click').on('click', function () {
            /*R.SanPham.ThemMoiThongSoKyThuat();*/
            var cloneTemplate = $('.template').clone();
            cloneTemplate.removeClass('template');
            cloneTemplate.addClass('thong-so-item');
            cloneTemplate.removeAttr('style')
            $('.html-thong-so').append(cloneTemplate);
            R.SanPham.RegisterEvent();
        })
        $('.remove-thong-so').off('click').on('click', function () {
            $(this).closest('.thong-so-item').remove();
        })
    },
    InitCkEditor: function () {
        CKEDITOR.replace('ckMotaSanPham');
        R.SanPham.RegisterEvent();
    },
    SaveSanPham: function (params) {
        $.post('/SanPhams/SaveSP', params, function (response) {
            alert('Them moi thanh cong!');
            window.location.href = "/SanPhams/AdminIndex"
            R.SanPham.RegisterEvent();
        })
    },
    InitSelect2: function () {
        
        $('.dsDanhMuc').select2();
        R.SanPham.RegisterEvent();
        
    },
    SetValueSelect2: function () {
        var dtDanhMuc = $('.dsDanhMuc').attr("data-value");
        var arrSelected = [];
        var splitted = dtDanhMuc.split(',');
        splitted.forEach(element => {
            arrSelected.push(parseInt(element))
        })
        $('.dsDanhMuc').val(arrSelected).change();
    },
    ThemMoiThongSoKyThuat: function () {
        
    }

}
R.SanPham.Init();