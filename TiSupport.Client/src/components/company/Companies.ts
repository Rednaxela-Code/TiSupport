import { ref, onMounted, defineExpose } from "vue";
import { Company, getAllCompanies } from "../../utils/companyUtils.ts";

export function companiesLogic() {
    const companies = ref<Company[]>([]);

    const fetchCompanies = async () => {
        try {
            companies.value = await getAllCompanies();
        } catch (error) {
            console.error("Failed to fetch companies:", error);
        }
    };

    defineExpose({
        refreshData: fetchCompanies,
    });

    onMounted(() => {
        fetchCompanies();
    });

    return {
        companies,
        fetchCompanies,
    };
}
