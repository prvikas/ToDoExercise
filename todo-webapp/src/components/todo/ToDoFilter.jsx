import React from 'react';

const ToDoFilters = ({ activeFilter, onFilterChange }) => (
    <div className="flex gap-2 mb-4">
        {['all', 'active', 'completed'].map((filter) => (
            <button
                key={filter}
                className={`px-3 py-1 rounded ${activeFilter === filter ? 'bg-blue-500 text-white' : 'bg-gray-200'
                    }`}
                onClick={() => onFilterChange(filter)}
            >
                {filter.charAt(0).toUpperCase() + filter.slice(1)}
            </button>
        ))}
    </div>
);

export default ToDoFilters;