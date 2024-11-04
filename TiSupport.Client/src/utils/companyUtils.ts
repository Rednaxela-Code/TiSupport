import httpClient from '../utils/httpClient.ts';
import {computed} from "vue";

export interface Company {
    id: number;
    name: string;
    employees: number[] | null; // List of integers or null
    companyType: number | null;
}

export enum CompanyType
{
    None = 0,
    Supplier = 1,
    Partner = 2,
    Distributor = 3,
    Manufacturer = 4,
    Retailer = 5,
    Consultant = 6,
    Contractor = 7,
    Vendor = 8,
    Wholesaler = 9,
    Affiliate = 10,
}

export const companyTypeOptions = computed(() => {
    return Object.keys(CompanyType)
        .filter(key => isNaN(Number(key)))
        .map(key => ({ name: key, value: CompanyType[key as keyof typeof CompanyType] }));
});

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