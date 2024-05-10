package lw1_build2.spring.service;

import lw1_build2.spring.model.Customer;
import lw1_build2.spring.dao.CustomerDAO;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

public class CustomerServiceImpl implements CustomerService {
    private CustomerDAO customerDAO;

    public void setCustomerDAO(CustomerDAO customerDAO) {
        this.customerDAO = customerDAO;
    }

    @Override
    @Transactional
    public void addCustomer(Customer customer) {
        this.customerDAO.addCustomer(customer);
    }

    @Override
    @Transactional
    public void updateCustomer(Customer customer) {
        this.customerDAO.updateCustomer(customer);
    }

    @Override
    @Transactional
    public void removeCustomer(int id) {
        this.customerDAO.removeCustomer(id);
    }

    @Override
    @Transactional
    public List<Customer> listCustomers() {
        return this.customerDAO.listCustomers();
    }

    @Override
    @Transactional
    public Customer getCustomerById(int id) {
        return this.customerDAO.getCustomerById(id);
    }
}
