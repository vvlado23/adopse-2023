$(document).ready(
    function () {
        var $items = [
            'C',
            'B',
            'V',
            'R'
        ];

        $($items).each(
            function () {
                $('ul').append("<li>" + this + "</li>");
            }
        );
    }
);