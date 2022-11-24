let sendBtn = document.getElementById('send');

sendBtn.addEventListener('click', async () => {
    await SendMessage();
});

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

async function SendMessage() {
    let name = document.getElementById('name-input').value;
    let header = document.getElementById('header-input').value;
    let body = document.getElementById('body-input').value;

    await hubConnection.invoke("Send", {
        recipientName: name,
        header: header,
        body: body
    });
}

function setMessageToList(message) {
    let messageContainer = document.querySelector('.message-container');

    let html = `
                <div class="list-group mb-1" data-bs-toggle="modal" data-bs-target="#exampleModalScrollable">
                    <div onclick="openMessage(this)" class="list-group-item list-group-item-action" aria-current="true">
                        <div class="d-flex w-100 justify-content-between">
                        <h6 class="mb-1 title-message">${message.header}</h6>
                        <small class="date-send-message">${message.dateSend}</small>
                        </div>
                        <p class="mb-1 sender-message">${message.sender}</p>
                        <div class="body-message" hidden="hidden">${message.body}</div>
                    </div>
                </div>
                `;

    messageContainer.innerHTML += html;
}