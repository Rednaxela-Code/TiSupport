import axios from "axios";

export interface Company {
    id?: number;
    name?: string;
}

export const createCompany = async (company: Company) => {
    try {
        const response = await axios.post('https://localhost:7151/company', company, {
            headers: {
                'Content-Type': 'application/json'
            },
            timeout: 15000
        });
        console.log('Company created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};