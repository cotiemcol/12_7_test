// Lấy danh sách các tin nhắn
var messageItems = document.querySelectorAll('.dropdown-item');
var currentIndex = 0;

// Hiển thị 3 tin nhắn ban đầu
for (var i = 0; i < 3; i++) {
    if (currentIndex < messageItems.length) {
        messageItems[currentIndex].style.display = 'block';
        currentIndex++;
    }
}

// Hàm thay đổi tin nhắn hiển thị
function changeMessage() {
    // Ẩn tất cả các tin nhắn
    messageItems.forEach(function (item) {
        item.style.display = 'none';
    });

    // Hiển thị 3 tin nhắn tiếp theo
    for (var i = 0; i < 3; i++) {
        if (currentIndex < messageItems.length) {
            messageItems[currentIndex].style.display = 'block';
            currentIndex++;
        } else {
            // Nếu đã hiển thị hết tin nhắn, quay lại tin nhắn đầu tiên
            currentIndex = 0;
            messageItems[currentIndex].style.display = 'block';
            currentIndex++;
        }
    }
}

// Gọi hàm thay đổi tin nhắn sau mỗi 3 giây
setInterval(changeMessage, 3000);
