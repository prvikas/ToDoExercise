import React, { memo } from "react";
const ToDoList = memo(({ toDos, onToggle, onDelete }) => {
  return (
    <div className="todo-list">
      {toDos.map((toDo) => (
        <div key={toDo.id} className="todo-item">
          <input
            type="checkbox"
            checked={toDo.isCompleted}
            onChange={() => onToggle(toDo.id)}
            className="todo-checkbox"
          />
          <span className={`todo-text ${toDo.isCompleted ? "completed" : ""}`}>
            {toDo.title}
          </span>
          <button onClick={() => onDelete(toDo.id)} className="delete-button">
            Delete
          </button>
        </div>
      ))}
    </div>
  );
});
export default ToDoList;
