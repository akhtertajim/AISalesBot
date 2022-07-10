var ChatTextServices = {
    PassChatBotMessage: function (msg) {
        $("#chat-message-body").append(ChatTextServices.GetHtmlChatBotMessage(msg));
    },
    PassUserMessage: function (msg) {
        $("#chat-message-body").append(ChatTextServices.GetHtmlUser(msg));
    },
    GetHtmlChatBotMessage: function (msg) {
        return '<div class="message-box-holder"> <div class="message-box">#$msg$#</div></div>'.replace('#$msg$#', msg);
    },
    GetHtmlUser: function (msg) {
        return '<div class="message-box-holder"> <div class="message-box message-partner">#$msg$#</div></div>'.replace('#$msg$#', msg);
    }

}