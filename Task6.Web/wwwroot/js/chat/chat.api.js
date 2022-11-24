async function getAllName() {
    let names = [];

    let response = await fetch('Chat/GetAllName/');

    await response.json().then(function (value) {
        names = value;
    });

    return names;
}

async function getUserMessage() {
    let messages = [];

    let response = await fetch('Chat/GetUserMessages/');

    await response.json().then(function (value) {
        messages = value;
    });

    return messages;
}