const uri = 'api/Collections';
let collections = [];

function getCollections() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayCollections(data))
        .catch(error => console.error("Колекції не знайдені", error));
}

function addCollection() {
    const addNameTextbox = document.getElementById('add-name');

    const collection = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(collection)
    })
        .then(response => response.json())
        .then(() => {
            getCollections();
            addNameTextBox.value = '';
        })
        .catch(error => console.error('Не вдалося додати колекцію', error));
    document.getElementById('add-name').value = '';
}

function deleteCollection(id) {
    const collection = collections.find(collection => collection.id === id);
    if (confirm(`Ви справді бажаєте видалити колекцію '${collection.name}' ?`)) {
        fetch(`${uri}/${id}`, {
            method: 'DELETE'
        })
            .then(() => getCollections())
            .catch(error => console.error('Не вдалося видалити колекцію'), error);
    }
}

function displayEditForm(id) {
    const collection = collections.find(collection => collection.id === id);

    document.getElementById('edit-id').value = collection.id;
    document.getElementById('edit-name').value = collection.name;
    document.getElementById('editForm').style.display = 'block';
}

function updateCollection() {
    const collectionid = document.getElementById('edit-id').value;
    const collection = {
        id: parseInt(collectionid, 10),
        name: document.getElementById('edit-name').value.trim()
    }

    fetch(`${uri}/${collectionid}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(collection)
    })
        .then(() => getCollections())
        .catch(error => console.error('Не вдалось змінити інформацію про колекцію', error));

    document.getElementById('edit-id').value = 0;
    document.getElementById('edit-name').value = '';
    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCollections(data) {
    const tBody = document.getElementById('collections');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(collection => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Редагувати';
        editButton.setAttribute('onclick', `displayEditForm(${collection.id})`);
        editButton.setAttribute('class', 'edit');

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Видалити';
        deleteButton.setAttribute('onclick', `deleteCollection(${collection.id})`);
        deleteButton.setAttribute('class', 'delete');

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(collection.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        td2.appendChild(editButton);

        let td3 = tr.insertCell(2);
        td3.appendChild(deleteButton);
    });

    collections = data;
}

