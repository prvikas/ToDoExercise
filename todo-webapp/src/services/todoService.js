import axios from 'axios';

const GET_API_URL = ' http://localhost:7155/api';
const API_URL = ' https://localhost:7006/api';

const get_api = axios.create({
    baseURL: GET_API_URL
});

const api = axios.create({
    baseURL: API_URL
});

export const toDoApi = {
    getToDos: () => { return get_api.get('/todos') },
    addToDo: (toDo) => api.post('/todo', toDo),
    updateToDo: (id, toDo) => api.put(`/todo/${id}`, toDo),
    updateStatusToDo: (id, toDo) => api.patch(`/todo/${id}/status`, toDo),
    deleteToDo: (id) => api.delete(`/todo/${id}`)
};