$(function () {

    $(".collapsible").click(function () {
        $(this).next(".content").slideToggle(500);
        if ($(this).find('span').hasClass('glyphicon-chevron-right')) {
            $(this).find('span').addClass('glyphicon-chevron-down').removeClass('glyphicon-chevron-right');
        }
        else {
            $(this).find('span').addClass('glyphicon-chevron-right').removeClass('glyphicon-chevron-down');
        }
    });
    createNoty('We use cookies on our website. By continuing to use this website ' +
        'you consent to their use. For more information on cookies and our ' +
        'privacy policy click <a href="/Privacy">here</a>', 'info');
    $('.page-alert .close').click(function (e) {
        e.preventDefault();
        sessionStorage.Alert = "Confirmed";
        $(this).closest('.page-alert').slideUp();
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('#back-to-top').fadeIn();
        } else {
            $('#back-to-top').fadeOut();
        }
    });
    // scroll body to 0px on click
    $('#back-to-top').click(function () {
        $('#back-to-top').tooltip('hide');
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });

$('#back-to-top').tooltip('show');
    $(window).on('resize', function () {
        var win = $(this);
        if (win.height() >= 768) {
            $('.navbar.navbar-inverse.navbar-fixed-top').removeClass('collapsedTopNav');
            $('.navbar-side').removeClass('active');
        }
    });
    $('.navSideBar').click(function (e) {
        if ($('.navbar-side').hasClass('active')) {
            $('.navbar-side').removeClass('active');
            $('.navbar.navbar-inverse.navbar-fixed-top').removeClass('collapsedTopNav');
        }
        else {
            $('.navbar-side').addClass('active');
            $('.navbar.navbar-inverse.navbar-fixed-top').addClass('collapsedTopNav');
        }
    });

    var selectedClass = "";
    $(".filter").click(function () {
        $(".filter").removeClass("filtered");
        $(this).addClass("filtered");
        selectedClass = $(this).attr("data-rel");
        $("#gallery").fadeTo(100, 0.1);
        $(".tz-gallery > .row >.col-sm-6").not("." + selectedClass).css("display", "none");
        setTimeout(function () {
            $("." + selectedClass).css("display", "block");
            $("#gallery").fadeTo(300, 1);
        }, 300);
    });
    $(".col-sm-6.col-md-4").not(".all").css("display", "none");
    baguetteBox.run('.tz-gallery');
    function doAnimations(elems) {
        //Cache the animationend event in a variable
        var animEndEv = "webkitAnimationEnd animationend";

        elems.each(function () {
            var $this = $(this),
                $animationType = $this.data("animation");
            $this.addClass($animationType).one(animEndEv, function () {
                $this.removeClass($animationType);
            });
        });
    }

    //Variables on page load
    var $myCarousel = $("#carouselExampleIndicators"),
        $firstAnimatingElems = $myCarousel
            .find(".item:first")
            .find("[data-animation ^= 'animated']");

    //Initialize carousel
    $myCarousel.carousel();

    //Animate captions in first slide on page load
    doAnimations($firstAnimatingElems);

    //Other slides to be animated on carousel slide event
    $myCarousel.on("slide.bs.carousel", function (e) {
        var $animatingElems = $(e.relatedTarget).find(
            "[data-animation ^= 'animated']"
        );
        doAnimations($animatingElems);
    });

    function createNoty(message, type) {
        var html = '<div class="alert alert-' + type + ' alert-dismissable page-alert" style="display:none">';
        html += '<button type="button" class="close"><span aria-hidden="true">x</span><span class="sr-only">Close</span></button>';
        html += message;
        html += '</div>';
        $(html).hide().prependTo('#noty-holder');

        if (sessionStorage.Alert !== 'Confirmed') {
            $('.page-alert').slideDown();
        }
    };

    function after_form_submitted(data) {
            $('form#reused_form').hide();
            $('#success_message').show();
            $('#error_message').hide();
    }


    function errorSendingForm() {
        $('#error_message').append('<ul></ul>');

        jQuery.each(data.errors, function (key, val) {
            $('#error_message ul').append('<li>' + key + ':' + val + '</li>');
        });
        $('#success_message').hide();
        $('#error_message').show();

        //reverse the response on the button
        $('button[type="button"]', $form).each(function () {
            $btn = $(this);
            label = $btn.prop('orig_label');
            if (label) {
                $btn.prop('type', 'submit');
                $btn.text(label);
                $btn.prop('orig_label', '');
            }
        });

    }

    $('.feedbackButton').click(function (e) {
        $('form#feedbackForm').trigger("reset");
        $('#feedBackSuccessMessage').hide();
        $('#feedbackErrorMessage').hide();
        $('#btnFeedback').text('Post It! →');
        $('#feedbackModal').modal('show');
        $('form#feedbackForm').show();
    });

    $('.contactButton').click(function (e) {
        $('form#contactForm').trigger("reset");
        $('#contactSuccessMessage').hide();
        $('#contactErrorMessage').hide();
        $('#btnContactUs').text('Post It! →');
        $('#contactModal').modal('show');
        $('form#contactForm').show();
    });

    $('#btnContactUs').click(function (e) {
        e.preventDefault();
        var url = $('#contactForm').data('request-url');
        //show some response on the button
        $('button[type="submit"]', $('#contactForm')).each(function () {
            $btn = $(this);
            $btn.prop('type', 'button');
            $btn.prop('orig_label', $btn.text());
            $btn.text('Sending ...');
        });


        $.ajax({
            type: "POST",
            url: url,
            data: $('#contactForm').serialize(),
            success: function (data) {
                $('form#contactForm').hide();
                $('#contactSuccessMessage').show();
                $('#contactErrorMessage').hide();
            },
            dataType: 'json',
            error: function (data) {
                $('#contactErrorMessage').append('<ul></ul>');

                jQuery.each(data.errors, function (key, val) {
                    $('#contactErrorMessage ul').append('<li>' + key + ':' + val + '</li>');
                });
                $('#contactSuccessMessage').hide();
                $('#contactErrorMessage').show();

                //reverse the response on the button
                $('button[type="button"]', $('form#contactForm')).each(function () {
                    $btn = $(this);
                    label = $btn.prop('orig_label');
                    if (label) {
                        $btn.prop('type', 'submit');
                        $btn.text(label);
                        $btn.prop('orig_label', '');
                    }
                });

            }
        });

    });

    $('#btnFeedback').click(function (e) {
        e.preventDefault();
        var url = $('#feedbackForm').data('request-url');
        $('#btnFeedback').text('Sending ...');

        $.ajax({
            type: "POST",
            url: url,
            data: $('#feedbackForm').serialize(),
            success: function (data) {
                $('form#feedbackForm').hide();
                $('#feedBackSuccessMessage').show();
                $('#feedbackErrorMessage').hide();
            },
            dataType: 'json',
            error: function (data) {
                $('#feedbackErrorMessage').append('<ul></ul>');

                jQuery.each(data.errors, function (key, val) {
                    $('#feedbackErrorMessage ul').append('<li>' + key + ':' + val + '</li>');
                });
                $('#feedBackSuccessMessage').hide();
                $('#feedbackErrorMessage').show();

                //reverse the response on the button
                $('button[type="button"]', $('form#feedbackForm')).each(function () {
                    $btn = $(this);
                    label = $btn.prop('orig_label');
                    if (label) {
                        $btn.prop('type', 'submit');
                        $btn.text(label);
                        $btn.prop('orig_label', '');
                    }
                });

            }
        });

    });

});