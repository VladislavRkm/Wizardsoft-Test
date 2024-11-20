const apiUrl = 'https://localhost:5001/swagger/index.html'; 


function createCategory() {
    const categoryName = document.getElementById('categoryName').value;

    fetch(`${apiUrl}/Category`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name: categoryName, parentId: null })
    })
        .then(response => response.json())
        .then(data => {
            console.log('Category created:', data);
            loadCategories();
        })
        .catch(error => console.error('Error:', error));
}

function loadCategories() {
    fetch(`${apiUrl}/Category`)
        .then(response => response.json())
        .then(data => {
            const categoriesList = document.getElementById('categoriesList');
            categoriesList.innerHTML = '';
            data.forEach(category => {
                const li = document.createElement('li');
                li.textContent = `${category.id} - ${category.name}`;
                categoriesList.appendChild(li);
            });
        })
        .catch(error => console.error('Error:', error));
}

function getCategoryById(id) {
    fetch(`${apiUrl}/Category/${id}`)
        .then(response => response.json())
        .then(data => {
            console.log('Category:', data);
        })
        .catch(error => console.error('Error:', error));
}


function updateCategory(id, newName) {
    fetch(`${apiUrl}/Category/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: id, name: newName, parentId: null })
    })
        .then(response => response.json())
        .then(data => {
            console.log('Category updated:', data);
            loadCategories();
        })
        .catch(error => console.error('Error:', error));
}


function deleteCategory(id) {
    fetch(`${apiUrl}/Category/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log('Category deleted:', data);
            loadCategories();
        })
        .catch(error => console.error('Error:', error));
}


function createEvent() {
    const eventTitle = document.getElementById('eventTitle').value;
    const eventDescription = document.getElementById('eventDescription').value;
    const eventStartDate = document.getElementById('eventStartDate').value;
    const eventEndDate = document.getElementById('eventEndDate').value;
    const eventCategoryId = parseInt(document.getElementById('eventCategoryId').value);

    fetch(`${apiUrl}/Event`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            title: eventTitle,
            description: eventDescription,
            startDate: eventStartDate,
            endDate: eventEndDate,
            categoryId: eventCategoryId
        })
    })
        .then(response => response.json())
        .then(data => {
            console.log('Event created:', data);
            loadEvents();
        })
        .catch(error => console.error('Error:', error));
}

function loadEvents() {
    fetch(`${apiUrl}/Event`)
        .then(response => response.json())
        .then(data => {
            const eventsList = document.getElementById('eventsList');
            eventsList.innerHTML = '';
            data.forEach(event => {
                const li = document.createElement('li');
                li.textContent = `${event.id} - ${event.title} (${event.startDate})`;
                eventsList.appendChild(li);
            });
        })
        .catch(error => console.error('Error:', error));
}

function getEventById(id) {
    fetch(`${apiUrl}/Event/${id}`)
        .then(response => response.json())
        .then(data => {
            console.log('Event:', data);
        })
        .catch(error => console.error('Error:', error));
}

function updateEvent(id, newTitle, newDescription, newStartDate, newEndDate, newCategoryId) {
    fetch(`${apiUrl}/Event/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: id,
            title: newTitle,
            description: newDescription,
            startDate: newStartDate,
            endDate: newEndDate,
            categoryId: newCategoryId
        })
    })
        .then(response => response.json())
        .then(data => {
            console.log('Event updated:', data);
            loadEvents();
        })
        .catch(error => console.error('Error:', error));
}

function deleteEvent(id) {
    fetch(`${apiUrl}/Event/${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log('Event deleted:', data);
            loadEvents();
        })
        .catch(error => console.error('Error:', error));
}

document.addEventListener('DOMContentLoaded', () => {
    loadCategories();
    loadEvents();
});
