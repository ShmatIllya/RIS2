package lw1_build2.spring.dao;

import lw1_build2.spring.model.Customer;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

@Repository
public class CustomerDAOImpl implements CustomerDAO {

    private static final Logger logger = LoggerFactory.getLogger(CustomerDAOImpl.class);
    private SessionFactory sessionFactory;
    public void setSessionFactory(SessionFactory sf){
        this.sessionFactory = sf;
    }

    @Override
    public void addCustomer(Customer customer) {
        Session session = this.sessionFactory.getCurrentSession();
        session.persist(customer);
        logger.info("Customer saved successfully, Customer Details=" + customer);
    }

    @Override
    public void updateCustomer(Customer customer) {
        Session session = this.sessionFactory.getCurrentSession();
        session.merge(customer);
        logger.info("Customer updated successfully, Customer Details=" + customer);
    }

    @Override
    public void removeCustomer(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Customer customer = (Customer) session.getReference(Customer.class, id);
        if(null != customer){
            session.remove(customer);
        }
        logger.info("Customer deleted successfully, customer details = " + customer);
    }

    @SuppressWarnings("unchecked")
    @Override
    public List<Customer> listCustomers() {
        Session session = this.sessionFactory.getCurrentSession();
        List<Customer> customersList = session.createQuery("from Customer").list();
        for(Customer customer : customersList){
            logger.info("Customer List :: " + customer);
        }
        return customersList;
    }

    @Override
    public Customer getCustomerById(int id) {
        Session session = this.sessionFactory.getCurrentSession();
        Customer customer = (Customer) session.getReference(Customer.class, id);
        logger.info("Customer loaded successfully, Customer details=" + customer);
        return customer;
    }
}
