function openMessage(messageBlock) {
    let title = messageBlock.querySelector('.title-message');
    let dateSendMessage = messageBlock.querySelector('.date-send-message');
    let senderMessage = messageBlock.querySelector('.sender-message');
    let bodyMessage = messageBlock.querySelector('.body-message');
    
    document.querySelector('.modal-title').innerHTML = title.innerHTML;
    document.querySelector('.modal-sender').innerHTML = senderMessage.innerHTML;
    document.querySelector('.modal-data').innerHTML = dateSendMessage.innerHTML;
    document.querySelector('.modal-body').innerHTML = bodyMessage.innerHTML;
}