let nameInput = document.getElementById('name-input');
let res = document.getElementById("result");
let search_terms = [];

window.onload = async function () {
    search_terms = await getAllName();
}

function autocompleteMatch(input) {
    res.hidden = false;
    if (input === '') {
        return [];
    }

    let reg = new RegExp(input);
    return search_terms.filter(function (term) {
        if (term.match(reg)) {
            return term;
        }
    });
}

function showResults(val) {
    res.innerHTML = '';
    let list = '';
    let terms = autocompleteMatch(val);
    for (let i = 0; i < terms.length; i++) {
        list += '<li onclick="complete(this)">' + terms[i] + '</li>';
    }
    res.innerHTML = '<ul>' + list + '</ul>';

    if (res.textContent === '') {
        res.hidden = true;
    }
}

function complete(element) {
    nameInput.value = element.innerHTML;
    res.hidden = true;
}