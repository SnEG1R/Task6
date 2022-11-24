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
        recipientName: name, header: header, body: body
    });
}

function setMessageToList(message) {
    let messageContainer = document.querySelector('.message-container');

    let date = new Date(message.dateSend);

    let dateSend = `${date.getMonth() + 1}.${date.getDate()}.${date.getFullYear()} ${date.getHours()}:${date.getMinutes()}`;

    let messageHtml = `
                <div class="list-group mb-1" data-bs-toggle="modal" data-bs-target="#exampleModalScrollable">
                    <div onclick="openMessage(this);removeMessageHighlight(this)" class="bg-success text-white list-group-item list-group-item-action" aria-current="true">
                        <div class="d-flex w-100 justify-content-between">
                        <h6 class="mb-1 title-message">${message.header}</h6>
                        <small class="date-send-message">${dateSend}</small>
                        </div>
                        <p class="mb-1 sender-message">${message.sender}</p>
                        <div class="body-message" hidden="hidden">${message.body}</div>
                    </div>
                </div>
                `;

    let messagesHtml = messageContainer.innerHTML;

    messageHtml += messagesHtml;
    messageContainer.innerHTML = messageHtml;
}

function removeMessageHighlight(message) {
    message.classList.remove("bg-success");
    message.classList.remove("text-white");
}