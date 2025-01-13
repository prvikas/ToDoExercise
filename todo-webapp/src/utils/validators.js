import { z } from 'zod';
export const toDoSchema = z.object({ title: z.string().min(1, 'Task name is required').max(50, 'Task name must be less than 50 characters') });