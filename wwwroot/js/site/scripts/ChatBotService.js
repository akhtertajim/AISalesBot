var ChatBotService = {
    synthService: new SpeechService(),
    ProdId: "",
    Product: {},
    NegotiationTemplate: {},
    CurrentAction: "",
    slabs: "Level1",
    acceptedOffer: 0,
    maxTry: 0,
   
    init: function () {
        synthService = new SpeechService();
        synthService.speak('Testing');
    },
    startProductIntroduction: function (element) {
        let prodid = $(element).data("prodid");
      
        $.ajax({
            url: "/Product/GetSpeech/" + prodid,
            success: function (data, response) {
                console.log(data);
                ChatBotService.synthService.speak(data.speechText);
                ChatTextServices.PassChatBotMessage(data.speechText);
                ChatBotService.priceNegotiation(data);
            },
            error: function (xhr, e, m) {
                console.log(xhr);
            }
        })
    },
    priceNegotiation: function (data) {
        if (data.priceNegotiationAllowed) {
            ChatBotService.synthService.speak("We care for you, if you are interested in this product we can negotiate price on this");
            ChatTextServices.PassChatBotMessage('Type "Yes" to negotiate the Price');
        }
        else
        {
            ChatBotService.synthService.speak("To check more details on the product, please navigate the product details wibdow.");
        }
    },
    ProductDetailsPage: function (prodId, UserName) {
        
        ChatBotService.ProdId = prodId;
        ChatTextServices.PassChatBotMessage("Welcome, " + UserName);
        ChatTextServices.PassChatBotMessage("On this window, you can explore about the product");

        $.ajax({
            url: "/BOT/GetNegotiationTemplate?prodId=" + ChatBotService.ProdId,
            success: function (data, response) {
                console.log(data);
                console.log(data.product);
                var text = "This is a fixed price item, negotiation is not applicable.";
                if (data.allNegotiation) {
                    ChatBotService.NegotiationTemplate = data;
                    ChatBotService.Product = data.product;
                    ChatBotService.CurrentAction = "OfferedByBot";
                    ChatBotService.slabs = "Level1";
                    text = "We offer you a " + data.negotiationSlabsFirst + "% off on the item. Its a good deal for both of us.";
                    
                }
                ChatBotService.synthService.speak(text);               
                ChatTextServices.PassChatBotMessage(text);
                if (data.allNegotiation) {
                    ChatTextServices.PassChatBotMessage("If interested Type Yes else type No");
                }
            },
            error: function (xhr, e, m) {
                console.log(xhr);
            }

        })
    },

    ChatBotReplyNegotiation: function (msg) {
        console.log('ChatBotReplyNegotiation', msg)
        if (ChatBotService.maxTry >= 5) {
            return;
        }
        if (ChatBotService.CurrentAction == "OfferedByBot") {
            console.log('ChatBotReplyNegotiation:OfferedByBot', msg)
            switch (msg) {
                case "Yes": {
                    ChatTextServices.PassChatBotMessage("Excellant, we appreciate your decision and negotiation skills.");
                    var cost = ChatBotService.calCulateDiscount();
                    var text = "Now cost of the project for item is " + (ChatBotService.Product.unitPrice - cost);
                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    ChatBotService.ApplyDiscount(cost);
                    break;
                }
                case "No": {
                    ChatBotService.maxTry++;
                    ChatBotService.CurrentAction = "CheckCustomerOffer"
                    var text = 'Ok, I would like to hear your offer price';
                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    if (ChatBotService.maxTry >= 4) {
                        var text = 'It was final offer from my end. I stop negotiation here';
                        ChatTextServices.PassChatBotMessage(text);
                        ChatBotService.synthService.speak(text);
                    }
                    break;
                }
            }
        }
        else if (ChatBotService.CurrentAction == "CheckCustomerOffer") {
            console.log('ChatBotReplyNegotiation:CheckCustomerOffer', msg)
            if (ChatBotService.slabs == "Level1") {
                console.log('ChatBotReplyNegotiation:CheckCustomerOffer:Level1', msg, ChatBotService.NegotiationTemplate.negotiationSlabsSecond)
                if (parseInt(msg) > parseInt(ChatBotService.NegotiationTemplate.negotiationSlabsSecond)) {
                    var text = "Sorry Sir, I cannot sell on this price. I have found another offer for you. What about " + ChatBotService.NegotiationTemplate.negotiationSlabsSecond + " % off on this product.";

                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    ChatBotService.slabs = "Level2"
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    ChatBotService.CurrentAction = "OfferedByBot";
                    ChatTextServices.PassChatBotMessage("If interested Type Yes else type No");
                }
                else {
                    ChatBotService.acceptedOffer = parseInt(msg);
                    ChatTextServices.PassChatBotMessage(text);
           
                    ChatBotService.synthService.speak(text);
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    var text3 = "We have updated price in your cart, please check your cart and checkout to avail this offer.";
                    ChatTextServices.PassChatBotMessage(text3);
                    ChatBotService.synthService.speak(text3);

                    ChatBotService.ApplyDiscount(disc);
                }
            }
            else if (ChatBotService.slabs == "Level2") {
                console.log('ChatBotReplyNegotiation:CheckCustomerOffer:Level2', msg, ChatBotService.NegotiationTemplate.negotiationSlabsSecond);

                if (parseInt(msg) > parseInt(ChatBotService.NegotiationTemplate.negotiationSlabsFinal)) {
                    var text = "Sorry Sir, I cannot sell on this price. I have found another offer for you. What about " + ChatBotService.NegotiationTemplate.negotiationSlabsSecond + " % off on this product.";

                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    ChatBotService.slabs = "Level3"
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    ChatBotService.CurrentAction = "OfferedByBot";
                    ChatTextServices.PassChatBotMessage("If interested Type Yes else type No");
                }
                else {
                    ChatBotService.acceptedOffer = parseInt(msg);
              
                    var text = "I realy liked your negotiation skills. I accepted your offer, we can close deal on " + msg+"% off.";

                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    var text3 = "We have updated price in your cart, please check your cart and checkout to avail this offer.";
                    ChatTextServices.PassChatBotMessage(text3);
                    ChatBotService.synthService.speak(text3);

                    ChatBotService.ApplyDiscount(disc);
                }

            }
            else if(ChatBotService.slabs == "Level3") {
                console.log('ChatBotReplyNegotiation:CheckCustomerOffer:Level3', msg, ChatBotService.NegotiationTemplate.negotiationSlabsSecond);

                if (parseInt(msg) > parseInt(ChatBotService.NegotiationTemplate.negotiationSlabsFinal)) {
                    var text = "Sorry Sir, I cannot sell on this price. I have found another offer for you. What about " + ChatBotService.NegotiationTemplate.negotiationSlabsFinal + " % off on this product.";

                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    //ChatBotService.slabs = "Level3"
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    ChatBotService.CurrentAction = "OfferedByBot";
                    ChatTextServices.PassChatBotMessage("If interested Type Yes else type No");
                }
                else {
                    ChatBotService.acceptedOffer = parseInt(msg);                 
                    var text = "I realy liked your negotiation skills. I accepted your offer, we can close deal on " + msg + "% off.";
                   
                    ChatTextServices.PassChatBotMessage(text);
                    ChatBotService.synthService.speak(text);
                    var disc = ChatBotService.calCulateDiscount();
                    var text1 = 'You will save ' + disc + ' and total cost of the product would be ' + (ChatBotService.Product.unitPrice - disc) + ' for you.';
                    ChatTextServices.PassChatBotMessage(text1);
                    ChatBotService.synthService.speak(text1);
                    var text3 = "We have updated price in your cart, please check your cart and checkout to avail this offer.";
                    ChatTextServices.PassChatBotMessage(text3);
                    ChatBotService.synthService.speak(text3);

                    ChatBotService.ApplyDiscount(disc);
                }
            }
        }
    },
    calCulateDiscount: function (offer) {       
        var price = ChatBotService.NegotiationTemplate.product.unitPrice;
        var discount = 0;
       
        if (offer!=null) {
            discount = offer;
        }
        else if (ChatBotService.acceptedOffer > 0) {
            discount = ChatBotService.acceptedOffer;
        }
        else {
            if (ChatBotService.slabs == "Level1") {
                discount = ChatBotService.NegotiationTemplate.negotiationSlabsFirst;

            }
            else if (ChatBotService.slabs == "Level2") {
                discount = ChatBotService.NegotiationTemplate.negotiationSlabsSecond;

            }
            else if (ChatBotService.slabs == "Level3") {
                discount = ChatBotService.NegotiationTemplate.negotiationSlabsFinal;

            }
        }
        var cost = price * discount / 100;
        return cost;
       
    },

    BindUserEvent: function () {
        $("#btn-postusermsg").on("click", function () {
            var msg = $("#chatinput").val();
            ChatTextServices.PassUserMessage(msg);
            ChatBotService.ChatBotReplyNegotiation(msg);
           // alert(msg)
            $("#chatinput").val('');
        });
    },
    ApplyDiscount: function (dis) {
        alert(dis)
        $.ajax({
            url: "/Cart/ApplyDiscount",
            method: "post",
            data: {
                prodId: ChatBotService.ProdId,
                disc: dis
            },
            success: function (data, response) {
                console.log(data);
               
            },
            error: function (xhr, e, m) {
                alert('An error occured')
                console.log(xhr);
            }
        })
    }

}