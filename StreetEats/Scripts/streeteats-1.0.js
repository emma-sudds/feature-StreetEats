$(function () {
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
 
    $('#reused_form').submit(function (e) {
        e.preventDefault();
        $form = $(this);
        var url = $(this).data('request-url');
        //show some response on the button
        $('button[type="submit"]', $form).each(function () {
            $btn = $(this);
            $btn.prop('type', 'button');
            $btn.prop('orig_label', $btn.text());
            $btn.text('Sending ...');
        });


        $.ajax({
            type: "POST",
            url: url,
            data: $form.serialize(),
            success: after_form_submitted,
            dataType: 'json',
            error: errorSendingForm
        });

    });
});