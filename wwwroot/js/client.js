$(function(){
    // preload audio
    var toast = new Audio('toast.wav');
    
    $(this).on('keydown', function(){
        if (event.keyCode == 27){
            $('#toast').toast('hide');
        }
    })
    

    $('.code').on('click', function (e) {
        //alert($(this).data('product'));
        // first pause the audio (in case it is still playing)
        toast.pause();
        // reset the audio
        toast.currentTime = 0;
        
        e.preventDefault();
         // play audio
         toast.play();
         $('#product').html($(this).data('product'));
         $('#code').html($(this).data('code'));
        $('#toast').toast({ autohide: false }).toast('show');
    });
});
