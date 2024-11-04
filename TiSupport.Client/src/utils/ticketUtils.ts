import httpClient from "./httpClient.ts";

export interface Ticket {
    id: number;
    name: string;
    status: TicketStatus | null;
    priority: TicketPriority | null;
    category: TicketCategory | null;
    created: Date | null;
    content: string | null;
    attachments: number[] | null;
    userId: number | null;
    commentIds: number[] | null;
}

export enum TicketStatus {
    New = 0,
    InProgress = 1,
    Closed = 2,
}

export enum TicketPriority
{
    Low = 0,
    Medium = 1,
    High = 2,
    Critical = 3,
}

export enum TicketCategory
{
    General = 0,
    Technical = 1,
    Maintenance = 2,
    Administration = 3,
}

export const getAllTickets = async (): Promise<Ticket[]> => {
    try {
        const response = await httpClient.get('/ticket');
        console.log('Ticket retrieved successfully:', response.data);
        return response.data;
    } catch (error) {
        console.log('Error retrieving ticket:', error);
        throw error;
    }
};

export const createTicket = async (ticket: Ticket) => {
    try {
        const response = await httpClient.post('/ticket', ticket, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Ticket created successfully:', response.data);
    } catch (error) {
        console.error('Error creating ticket:', error);
    }
};

export const updateTicket = async (ticket: Ticket) => {
    try {
        const response = await httpClient.put('/ticket', ticket, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Ticket updated successfully:', response.data);
    } catch (error) {
        console.error('Error updating ticket:', error);
    }
};

export const deleteTicket = async (ticket: Ticket) => {
    try {
        const response = await httpClient.delete(`/ticket/${ticket.id}`, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Ticket deleted successfully:', response.data);
    } catch (error) {
        console.error('Error deleting ticket:', error);
    }
};