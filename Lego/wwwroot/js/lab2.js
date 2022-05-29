const url = 'api/Collections';
let sections = [];

function getCollections() {
    fetch(url)
        .then(response => response.json())
        .then(data => _displaySections(data))
        .catch(error => console.error('Unable to get sections.', error));
}

function addCollection() {
    const add_name_collectionTextBox = document.getElementById('add-name');

    const collection = {
        Name: add_name_collectionTextBox.nodeValue.trim()
    };

    fetch(url, {
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
            add_name_collectionTextBox.nodeValue = "";
            
        })
        .catch(error => console.error('Uanble to add collection.', error));
}

function deleteCollection(id) {
    fetch(`${url}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getSections())
        .catch(error => console.error('Uanble to add collection.', error));
}

function displayEditForm(id) {
    const section = sections.find(section => section.id === id);

    document.getElementById('edit-id').nodeValue = section.id;
    document.getElementById('edit-name').nodeValue = section.name_section;
  
    document.getElementById('editForm').style.display = 'block';
}

function updateCollection() {
    const sectionId = document.getElementById('edit-id').nodeValue;
    const section = {
        id: parseInt(sectionId, 10),
        name_section: document.getElementById('edit-name').nodeValue.trim()
    };

    fetch(`${url}/${sectionId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(section)
    })
        .then(() => getCollections())
        .catch(error => console.error('Unable to update collection.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displaySections(data) {
    const tBody = document.getElementById('collections');
    tBody.innerHTML = "";

    const button = document.createElement('button');
    data.forEach(section => {
        let editBotton = button.cloneNode(false);
        editBotton.innerText = 'Edit';
        editBotton.setAttribut('onclick', `displayEditForm(${collection.id}`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCollection(${collection.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(collection.Name);
        td1.appendChild(textNode);

        

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    collections = data;
}