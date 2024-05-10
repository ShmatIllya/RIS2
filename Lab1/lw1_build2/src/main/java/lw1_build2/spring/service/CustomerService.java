package lw1_build2.spring.service;

import lw1_build2.spring.model.Customer;

import java.util.List;

public interface CustomerService {
    public void addCustomer(Customer customer);
    public void updateCustomer(Customer customer);
    public void removeCustomer(int id);
    public List<Customer> listCustomers();
    public Customer getCustomerById(int id);
}
