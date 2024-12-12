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

export let companyTypeOptions = computed(() => {
    return Object.keys(CompanyType)
        .filter(key => isNaN(Number(key)))
        .map(key => ({ name: key, value: CompanyType[key as keyof typeof CompanyType] }));
});

export let getAllCompanies = async (): Promise<Company[]> => {
    try {
        let response = await httpClient.get<Company[]>('/company');
        console.log('Companies retrieved successfully:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error retrieving companies:', error);
        throw error; // Rethrow to handle errors in calling code
    }
};
export let createCompany = async (company: Company) => {
    try {
        let response = await httpClient.post('/company', company, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};

export let updateCompany = async (company: Company) => {
    try {
        let response = await httpClient.put('/company', company, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company created successfully:', response.data);
    } catch (error) {
        console.error('Error creating company:', error);
    }
};

export let deleteCompany = async (company: Company) => {
    try {
        let response = await httpClient.delete(`/company/${company.id}`, {
            headers: {
                'Content-Type': 'application/json'
            },
        });
        console.log('Company deleted successfully:', response.data);
    } catch (error) {
        console.error('Error deleting company:', error);
    }
};