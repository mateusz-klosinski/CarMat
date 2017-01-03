(function () {
    
    // $(".notifications").popover();


    function generateContentForNotifications(notifications) {
        content = "<ul>";

        notifications.forEach(function (element, index, array) {
            content += "<li><span class=\"notification-time\">"+ moment(element.notificationTime).format("DD-MM-YYYY HH:MM") +"</span>"+ element.description +"</li>"
        });

        content += "</ul>";

        return content;
    }

    $(document).ready(function () {
        $.get("/api/Notifications/GetNotifications")
        .done(function (data) {


            if (data.length === 0) {
                $(".notifications").popover({
                    content: "Brak nowych powiadomień."
                });
                return;
            }

            $(".notifications .badge")
                .text(data.length)
                .removeClass("hidden")


            $(".notifications").popover({
                html: true,
                content: generateContentForNotifications(data)
            }).on("shown.bs.popover", function () {
                $.post("/api/Notifications/ReadNotifications")
                .done(function () {
                    $(".notifications .badge").fadeOut(400);
                });
            });
        });
    });


})();