import React, { useState, useEffect, lazy, Suspense } from "react";
import { ToDoForm } from "./components/todo/ToDoForm";
import { toDoApi } from "./services/todoService";
import { logger } from "./utils/logger";

// Lazy load ToDoList
const ToDoList = lazy(() => import("./components/todo/ToDoList"));

const FILTERS = {
  ALL: "all",
  ACTIVE: "active",
  COMPLETED: "completed",
};

export default function App() {
  const [toDos, setToDos] = useState([]);
  const [filter, setFilter] = useState(FILTERS.ALL);
  const [error, setError] = useState(null);

  useEffect(() => {
    setTimeout(async () => {
      const fetchToDos = async () => {
        try {
          const response = await toDoApi.getToDos();
          setToDos(response.data);
          logger.log("ToDos fetched", response.data);
        } catch (error) {
          setError("Failed to fetch ToDos");
          logger.error(error, "Fetching ToDos");
        }
      };

      await fetchToDos();
    }, 0);
  }, []);

  const filteredToDos = React.useMemo(() => {
    switch (filter) {
      case FILTERS.ACTIVE:
        return toDos.filter((toDo) => !toDo.isCompleted);
      case FILTERS.COMPLETED:
        return toDos.filter((toDo) => toDo.isCompleted);
      default:
        return toDos;
    }
  }, [toDos, filter]);

  const handleAddToDo = async (toDo) => {
    try {
      const response = await toDoApi.addToDo(toDo); // Ensure response is correctly assigned
      setToDos((prev) => [...prev, response.data]);
      logger.log("ToDo added", response.data);
    } catch (error) {
      setError("Failed to add ToDo");
      logger.error(error, "Adding ToDo");
    }
  };

  const handleToggleToDo = async (id) => {
    const toDo = toDos.find((t) => t.id === id);
    try {
      const response = await toDoApi.updateStatusToDo(id, {
        ...toDo,
        completed: !toDo.isCompleted,
      });
      if (response.data) {
        setToDos((prev) =>
          prev.map((t) => {
            if (t.id === id) {
              return { ...t, isCompleted: !t.isCompleted };
            }
            return t;
          })
        );
      }
      logger.log("Task status changed", { id });
    } catch (error) {
      setError("Failed to update ToDo");
      logger.error(error, "Toggling ToDo");
    }
  };

  const handleDeleteToDo = async (id) => {
    try {
      await toDoApi.deleteToDo(id);
      setToDos((prev) => prev.filter((t) => t.id !== id));
      logger.log("ToDo deleted", { id });
    } catch (error) {
      setError("Failed to delete ToDo");
      logger.error(error, "Deleting ToDo");
    }
  };

  return (
    <div className="container">
      <h1 className="todo-app">ToDo List</h1>

      {error && <div className="error-message">{error}</div>}

      <ToDoForm onAdd={handleAddToDo} />

      <div className="filter-container">
        {Object.values(FILTERS).map((filterValue) => (
          <button
            key={filterValue}
            onClick={() => setFilter(filterValue)}
            className={`${
              filter === filterValue ? "filter-button active" : "filter-button"
            }`}
          >
            {filterValue.charAt(0).toUpperCase() + filterValue.slice(1)}
          </button>
        ))}
      </div>

      <Suspense fallback={<div>Loading ToDos...</div>}>
        <ToDoList
          toDos={filteredToDos}
          onToggle={handleToggleToDo}
          onDelete={handleDeleteToDo}
        />
      </Suspense>
    </div>
  );
}
