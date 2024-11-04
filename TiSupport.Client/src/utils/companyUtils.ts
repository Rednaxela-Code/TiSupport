import httpClient from '../utils/httpClient.ts';

export interface Company {
    id: number;
    name: string;
    employees: number[] | null; // List of integers or null
}

export const getAllCompanies = async (): Promise<Company[]> => {
    try {
        const response = await httpClient.get<Company[]>('/company');
        console.log('Companies retrieved successfully:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error retrieving companies:', error);
        throw error; // Rethrow to handle errors in calling code
    }
};
export const createCompany = async (company: Company) => {
    try {
        const response = await httpClient.post('/company', company, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};

export const updateCompany = async (company: Company) => {
    try {
        const response = await httpClient.put('/company', company, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};

export const deleteCompany = async (company: Company) => {
    try {
        const response = await httpClient.delete(`/company/${company.id}`, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company deleted successfully:', response.data);
    } catch (error) {
        console.error('Error deleting company:', error);
    }
};