import React, { useState } from "react";
import { toDoSchema } from "../../utils/validators";
import { logger } from "../../utils/logger";

export const ToDoForm = ({ onAdd }) => {
  const [title, setTitle] = useState("");
  const [error, setError] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();
    try {
      toDoSchema.parse({ title });
      onAdd({ title, completed: false });
      setTitle("");
      setError("");
      logger.log("ToDo added", { title });
    } catch (error) {
      setError(error.errors[0].message);
      logger.error(error, "ToDo validation");
    }
  };

  return (
    <form onSubmit={handleSubmit} className="todo-item">
      <input
        type="text"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        placeholder="Add new Task name..."
        className="form-input"
      />
      <button type="submit" className="button button-primary">
        Add
      </button>
      {error && <p className="error-message">{error}</p>}
    </form>
  );
};
