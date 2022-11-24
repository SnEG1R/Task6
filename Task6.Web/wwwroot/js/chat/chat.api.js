async function getAllName() {
    let names = [];

    let response = await fetch('Chat/GetAllName/');

    await response.json().then(function (value) {
        names = value;
    });

    return names;
}