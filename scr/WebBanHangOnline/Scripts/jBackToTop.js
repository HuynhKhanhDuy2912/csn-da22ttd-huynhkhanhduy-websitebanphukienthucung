$(document).ready(function () {
    // Khi người dùng cuộn xuống 100px từ đầu trang, hiển thị nút
    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('#backToTop').fadeIn();
        } else {
            $('#backToTop').fadeOut();
        }
    });

    // Khi người dùng nhấn nút, cuộn lên đầu trang
    $('#backToTop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 500); // Cuộn lên đầu trang trong 500ms
        return false; // Ngừng sự kiện click mặc định
    });
});
