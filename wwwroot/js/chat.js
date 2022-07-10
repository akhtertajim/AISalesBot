class chatWindow{
    constructor(){
        this.bindEvents()
    }

   
    bindEvents(params) {

        $(".chatbox-top").on("click",function(){    
            $(this).closest('.chatbox').toggleClass('chatbox-min');
        });
          
        $(".fa-close").on("click",function(){    
            $(this).closest('.chatbox').hide();
        });
    }

}