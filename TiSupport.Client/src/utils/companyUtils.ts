import httpClient from "./httpClient.ts";

export interface Company {
    id?: number;
    name?: string;
}

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