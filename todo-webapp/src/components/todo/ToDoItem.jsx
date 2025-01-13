import React, { memo } from 'react';
import { CheckCircle2, Circle, Trash2 } from 'lucide-react';

export const ToDoItem = memo(({ todo, onToggle, onDelete }) => {
  return (
    <div className="flex items-center justify-between p-3 bg-white rounded shadow">
      <div className="flex items-center gap-3">
        <button
          onClick={() => onToggle(todo.id)}
          className="text-gray-500 hover:text-blue-500"
        >
          {todo.completed ? (
            <CheckCircle2 className="h-5 w-5 text-green-500" />
          ) : (
            <Circle className="h-5 w-5" />
          )}
        </button>
        <span className={todo.completed ? 'line-through text-gray-500' : ''}>
          {todo.text}
        </span>
      </div>
      <button
        onClick={() => onDelete(todo.id)}
        className="text-red-500 hover:text-red-700"
      >
        <Trash2 className="h-5 w-5" />
      </button>
    </div>
  );
});