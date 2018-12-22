function isChrome() {

    // Chrome's unsolved bug
    // http://code.google.com/p/chromium/issues/detail?id=128488

    return navigator.userAgent.indexOf('Chrome') != -1;

}

function loadApp() {

    var flipbook = $('.t');

    //$(document).keydown(function (e) {

    //    var previous = 37, next = 39;

    //    switch (e.keyCode) {
    //        case previous:

    //            $('.sample-docs').turn('previous');

    //            break;
    //        case next:

    //            $('.sample-docs').turn('next');

    //            break;
    //    }

    //});

    // Create the flipbook

    flipbook.turn({
        elevation: 50,
        acceleration: false,
        gradients: true,
        autoCenter: true,
        duration: 1000,
        pages: 4
    }).turn('page', 2);

    flipbook.addClass('animated');

    // Show canvas

    $('.t').css({ visibility: 'visible' });
}


$(function () {

    $(".t").turn({
        autoCenter: true
    });
    //loadApp();
    var module = {
        ratio: 1.38,
        init: function (id) {
            var me = this;

            // if older browser then don't run javascript
            if (document.addEventListener) {
                this.el = document.getElementById(id);
                this.resize();
                this.plugins();

                // on window resize, update the plugin size
                window.addEventListener('resize', function (e) {
                    var size = me.resize();
                    $(me.el).turn('size', size.width, size.height);
                });
            }
        },
        resize: function () {
            // reset the width and height to the css defaults
            this.el.style.width = '';
            this.el.style.height = '';

            var width = this.el.clientWidth,
                height = Math.round(width / this.ratio),
                padded = Math.round(document.body.clientHeight * 0.9);

            // if the height is too big for the window, constrain it
            if (height > padded) {
                height = padded;
                width = Math.round(height * this.ratio);
            }

            // set the width and height matching the aspect ratio
            this.el.style.width = width + 'px';
            this.el.style.height = height + 'px';

            return {
                width: width,
                height: height
            };
        },
        plugins: function () {
            // run the plugin
            $(this.el).turn({
                gradients: true,
                acceleration: true
            });
            // hide the body overflow
            document.body.className = 'hide-overflow';
        }
    };

    module.init('book');
});
