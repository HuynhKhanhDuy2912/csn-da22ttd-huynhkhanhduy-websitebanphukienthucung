$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        // Kiểm tra xem người dùng đã đăng nhập chưa (ví dụ kiểm tra sự tồn tại của session)
        var isAuthenticated = $('#isAuthenticated').val();  // Giả sử bạn lưu giá trị này trong một input ẩn trên trang

        if (!isAuthenticated) {
            alert("Bạn chưa đăng nhập tài khoản. Vui lòng đăng nhập để thêm sản phẩm vào giỏ hàng!");
            window.location.href = '/account/login';
            return;
        }

        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quantity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var conf = confirm('Bạn có chắc muốn xóa sản phẩm này khỏi giỏ hàng không?');
        if (conf == true) {
            $.ajax({
                url: '/shoppingcart/delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow' + id).remove();
                        LoadCart(); 
                    }
                }
            });
        }
    });

    $('body').on('click', '.btnDeleteAll', function (e) {
        e.preventDefault();
        var conf = confirm('Bạn có chắc muốn xóa hết sản phẩm trong giỏ hàng không?');
        if (conf == true) {
            DeleteAll();
            location.reload();
        }
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data("id");
        var quantity = $('#Quantity_' + id).val();
        Update(id,quantity);
    });
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/showcount',
        type: 'GET',
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
        }
    });
}

function Update(id,quantity) {
    $.ajax({
        url: '/shoppingcart/update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function DeleteAll() {
    $.ajax({
        url: '/shoppingcart/deleteall',
        type: 'POST',
        success: function (rs) {
            if (rs.Success) {
                LoadCart();
            }
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/shoppingcart/partial_item_cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}