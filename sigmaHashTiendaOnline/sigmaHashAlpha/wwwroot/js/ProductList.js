$(document).ready(function () {

    $('#searchbox').on('focus', () => {

        $('.searchbtn').css('transform','translate(852%, -1%)');
        $('.searchmagn').css('transform', 'rotate(359deg)');
    });


    const vals = ['510px','50px', 180, 0]
    var j = 0;
    $('#opencloser').click(function () {
        $('.filter').css('height', vals[j]);
        $('#filterarrow').css('transform', 'rotate(' + vals[j + 2].toString() + 'deg)');
        
        if (j === 1) {
            j = -1;
        }
        j++;
    });

    var i = 0;
    const catlist = [];
    var lastclicked;
    $('.cattitle').each(function () {
        let c = i;
        catlist.push(1);
        let temp = this;
        this.addEventListener( 'click', function () {     
            if (lastclicked != temp) {
                $('.cattitle').parent().each(function () {
                    this.classList.remove('catheight');
                });
            }
            if (lastclicked === temp) {
                if (temp.parentElement.classList.contains('catheight')) {
                    temp.parentElement.classList.remove('catheight');
                }
               else{
                    this.parentElement.classList.add('catheight');
                }
            }
            if (lastclicked != temp ){
                this.parentElement.classList.add('catheight');
            }
            lastclicked = temp;
        });
        i++;
    });



    




});