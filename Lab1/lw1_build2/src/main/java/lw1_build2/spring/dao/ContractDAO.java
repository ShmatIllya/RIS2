package lw1_build2.spring.dao;

import lw1_build2.spring.model.Contract;

import java.util.List;

public interface ContractDAO {
    public void addContract(Contract contract);
    public void updateContract(Contract contract);
    public void removeContract(int id);
    public List<Contract> listContracts();
    public Contract getContractById(int id);
}
