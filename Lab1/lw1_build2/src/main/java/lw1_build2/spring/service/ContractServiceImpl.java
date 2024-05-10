package lw1_build2.spring.service;

import lw1_build2.spring.model.Contract;
import lw1_build2.spring.dao.ContractDAO;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public class ContractServiceImpl implements ContractService {
    private ContractDAO contractDAO;

    public void setContractDAO(ContractDAO contractDAO) {
        this.contractDAO = contractDAO;
    }

    @Override
    @Transactional
    public void addContract(Contract contract) {
        this.contractDAO.addContract(contract);
    }

    @Override
    @Transactional
    public void updateContract(Contract contract) {
        this.contractDAO.updateContract(contract);
    }

    @Override
    @Transactional
    public void removeContract(int id) {
        this.contractDAO.removeContract(id);
    }

    @Override
    @Transactional
    public List<Contract> listContracts() {
        return this.contractDAO.listContracts();
    }

    @Override
    @Transactional
    public Contract getContractById(int id) {
        return this.contractDAO.getContractById(id);
    }
}
