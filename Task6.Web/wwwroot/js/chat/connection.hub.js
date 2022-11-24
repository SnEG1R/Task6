const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/chat-hub")
    .build();

hubConnection.on("GetMessage", function (message) {
    setMessageToList(message);
});