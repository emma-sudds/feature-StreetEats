function isChrome() {

    // Chrome's unsolved bug
    // http://code.google.com/p/chromium/issues/detail?id=128488

    return navigator.userAgent.indexOf('Chrome') != -1;

}

function loadApp() {

    var flipbook = $('.sample-docs');

    // Check if the CSS was already loaded

    if (flipbook.width() == 0 || flipbook.height() == 0) {
        setTimeout(loadApp, 10);
        return;
    }

    // Mousewheel

    $('#book-zoom').mousewheel(function (event, delta, deltaX, deltaY) {

        var data = $(this).data(),
            step = 30,
            flipbook = $('.sample-docs'),
            actualPos = $('#slider').slider('value') * step;

        if (typeof (data.scrollX) === 'undefined') {
            data.scrollX = actualPos;
            data.scrollPage = flipbook.turn('page');
        }

        data.scrollX = Math.min($("#slider").slider('option', 'max') * step,
            Math.max(0, data.scrollX + deltaX));

        var actualView = Math.round(data.scrollX / step),
            page = Math.min(flipbook.turn('pages'), Math.max(1, actualView * 2 - 2));

        if ($.inArray(data.scrollPage, flipbook.turn('view', page)) == -1) {
            data.scrollPage = page;
            flipbook.turn('page', page);
        }

        if (data.scrollTimer)
            clearInterval(data.scrollTimer);

        data.scrollTimer = setTimeout(function () {
            data.scrollX = undefined;
            data.scrollPage = undefined;
            data.scrollTimer = undefined;
        }, 1000);

    });


    // URIs

    Hash.on('^page\/([0-9]*)$', {
        yep: function (path, parts) {
            var page = parts[1];

            if (page !== undefined) {
                if ($('.sample-docs').turn('is'))
                    $('.sample-docs').turn('page', page);
            }

        },
        nop: function (path) {

            if ($('.sample-docs').turn('is'))
                $('.sample-docs').turn('page', 1);
        }
    });

    // Arrows

    $(document).keydown(function (e) {

        var previous = 37, next = 39;

        switch (e.keyCode) {
            case previous:

                $('.sample-docs').turn('previous');

                break;
            case next:

                $('.sample-docs').turn('next');

                break;
        }

    });

    // Create the flipbook

    flipbook.turn({
        elevation: 50,
        acceleration: false,
        gradients: true,
        autoCenter: true,
        duration: 1000,
        pages: 5,
        when: {

            turning: function (e, page, view) {

                var book = $(this),
                    currentPage = book.turn('page'),
                    pages = book.turn('pages');

                if (currentPage > 3 && currentPage < pages - 3) {
                    if (page == 1) {
                        book.turn('page', 2).turn('stop').turn('page', page);
                        e.preventDefault();
                        return;
                    } else if (page == pages) {
                        book.turn('page', pages - 1).turn('stop').turn('page', page);
                        e.preventDefault();
                        return;
                    }
                } else if (page > 3 && page < pages - 3) {
                    if (currentPage == 1) {
                        book.turn('page', 2).turn('stop').turn('page', page);
                        e.preventDefault();
                        return;
                    } else if (currentPage == pages) {
                        book.turn('page', pages - 1).turn('stop').turn('page', page);
                        e.preventDefault();
                        return;
                    }
                }

                Hash.go('page/' + page).update();

                if (page == 1 || page == pages)
                    $('.sample-docs .tabs').hide();


            },

            turned: function (e, page, view) {

                var book = $(this);
               
                if (page != 1 && page != book.turn('pages'))
                    $('.sample-docs .tabs').fadeIn(500);
                else
                    $('.sample-docs .tabs').hide();

                book.turn('center');
                //updateTabs();

            },

            start: function (e, pageObj) {

                moveBar(true);

            },

            end: function (e, pageObj) {

                var book = $(this);
                moveBar(false);

            }
        }
    }).turn('page', 2);



    flipbook.addClass('animated');


    // Show canvas

    $('#canvas').css({ visibility: 'visible' });
}
function loadPage(page) {

    var img = $('<img />');
    img.on("load", function () {
        var container = $('.sample-docs .p' + page);
        img.css({ width: container.width(), height: container.height() });
        img.appendTo($('.sample-docs .p' + page));
        container.find('.loader').remove();
    });

    img.attr('src', '../../Content/Images/menu/pages/' + (page - 2) + '.jpg');

}

function addPage(page, book) {

    var id, pages = book.turn('pages');

    var element = $('<div />', {});

    if (book.turn('addPage', element, page)) {
        if (page < 28) {
            element.html('<div class="gradient"></div><div class="loader"></div>');
            loadPage(page);
        }
    }
}

//function updateTabs() {

//    var tabs = { 7: 'Clases', 12: 'Constructor', 14: 'Properties', 16: 'Methods', 23: 'Events' },
//        left = [],
//        right = [],
//        book = $('.sample-docs'),
//        actualPage = book.turn('page'),
//        view = book.turn('view');

//    for (var page in tabs) {
//        var isHere = $.inArray(parseInt(page, 10), view) != -1;

//        if (page > actualPage && !isHere)
//            right.push('<a href="#page/' + page + '">' + tabs[page] + '</a>');
//        else if (isHere) {

//            if (page % 2 === 0)
//                left.push('<a href="#page/' + page + '" class="on">' + tabs[page] + '</a>');
//            else
//                right.push('<a href="#page/' + page + '" class="on">' + tabs[page] + '</a>');
//        } else
//            left.push('<a href="#page/' + page + '">' + tabs[page] + '</a>');

//    }

//    $('.sample-docs .tabs .left').html(left.join(''));
//    $('.sample-docs .tabs .right').html(right.join(''));

//}


function numberOfViews(book) {
    return book.turn('pages') / 2 + 1;
}


function getViewNumber(book, page) {
    return parseInt((page || book.turn('page')) / 2 + 1, 10);
}


function moveBar(yes) {
    if (Modernizr && Modernizr.csstransforms) {
        $('#slider .ui-slider-handle').css({ zIndex: yes ? -1 : 10000 });
    }
}

function setPreview(view) {

    var previewWidth = 115,
        previewHeight = 73,
        previewSrc = 'pics/preview.jpg',
        preview = $(_thumbPreview.children(':first')),
        numPages = (view == 1 || view == $('#slider').slider('option', 'max')) ? 1 : 2,
        width = (numPages == 1) ? previewWidth / 2 : previewWidth;

    _thumbPreview.
        addClass('no-transition').
        css({
            width: width + 15,
            height: previewHeight + 15,
            top: -previewHeight - 30,
            left: ($($('#slider').children(':first')).width() - width - 15) / 2
        });

    preview.css({
        width: width,
        height: previewHeight
    });

    if (preview.css('background-image') === '' ||
        preview.css('background-image') == 'none') {

        preview.css({ backgroundImage: 'url(' + previewSrc + ')' });

        setTimeout(function () {
            _thumbPreview.removeClass('no-transition');
        }, 0);

    }

    preview.css({
        backgroundPosition:
            '0px -' + ((view - 1) * previewHeight) + 'px'
    });
}

$(function () {
    
    loadApp();
});
