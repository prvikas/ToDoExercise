export const logger = {
    log: (action, data) => {
        console.log(`[${new Date().toISOString()}] ${action}:`, data);
    },
    error: (action, error) => {
        console.error(`[${new Date().toISOString()}] ERROR - ${action}:`, error);
    }
};
