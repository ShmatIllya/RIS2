package lw1_build2.spring.dao;

import lw1_build2.spring.model.Bike;
import lw1_build2.spring.model.Contract;
import lw1_build2.spring.model.enums.BikeStatus;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

@Repository
public class ContractDAOImpl implements ContractDAO {

    private static final Logger logger = LoggerFactory.getLogger(ContractDAOImpl.class);
    private SessionFactory sessionFactory;
    public void setSessionFactory(SessionFactory sf){
        this.sessionFactory = sf;
    }

    @Override
    public void addContract(Contract contract) {
        Session session = this.sessionFactory.getCurrentSession();
        Bike bike = (Bike) session.getReference(Bike.class, contract.getBikeIDInt());
        bike.setStatus(BikeStatus.rented);
        session.merge(bike);
        session.persist(contract);
        logger.info("Contract saved successfully, Contract Details=" + contract);
    }

    @Override
    public void updateContract(Contract contract) {
        Session session = this.sessionFactory.getCurrentSession();
        session.merge(contract);
        logger.info("Contract updated successfully, Contract Details=" + contract);
    }

    @Override
    public void removeContract(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Contract contract = (Contract) session.getReference(Contract.class, id);
        if(null != contract){
            Bike bike = (Bike) session.getReference(Bike.class, contract.getBikeIDInt());
            bike.setStatus(BikeStatus.available);
            session.merge(bike);
            session.remove(contract);
        }
        logger.info("Contract deleted successfully, contract details = " + contract);
    }

    @SuppressWarnings("unchecked")
    @Override
    public List<Contract> listContracts() {
        Session session = this.sessionFactory.getCurrentSession();
        List<Contract> contractsList = session.createQuery("SELECT e from Contract e").list();
        for(Contract contract : contractsList){
            logger.info("Contract List :: " + contract);
        }
        return contractsList;
    }

    @Override
    public Contract getContractById(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Contract contract = (Contract) session.getReference(Contract.class, id);
        logger.info("Contract loaded successfully, Contract details=" + contract);
        return contract;
    }
}
