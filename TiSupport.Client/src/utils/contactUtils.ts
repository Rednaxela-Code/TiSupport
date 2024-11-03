import httpClient from '../utils/httpClient.ts';

export interface Contact {
    id: number;
    name: string;
    email: string | null;
    fullName: string | null;
    firstName: string | null;
    lastName: string | null;
    addressId: number | null;
    phone: string | null;
    ticketIds: number[] | null;
    companyIds: number[] | null;
}

export const getAllContacts = async (): Promise<Contact[]> => {
    try {
        const response = await httpClient.get('/contact');
        console.log('Contact retrieved successfully:', response.data);
        return response.data;
    } catch (error) {
        console.log('Error retrieving contact:', error);
        throw error;
    }
};

export const createContact = async (contact: Contact) => {
    try {
        const response = await httpClient.post('/contact', contact, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Contact created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};