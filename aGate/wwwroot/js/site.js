window.addEventListener('DOMContentLoaded', (event) => {
    const alertBox = document.getElementById('successAlert');
    if (alertBox) {
        setTimeout(() => {
            // Bootstrap 5 alert objesi oluştur
            const bsAlert = new bootstrap.Alert(alertBox);
            bsAlert.close(); // otomatik kapat
        }, 3000); // 3000ms = 3 saniye
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const tooltipTriggerList = [].slice.call(
        document.querySelectorAll('[data-bs-toggle="tooltip"]')
    );
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
});