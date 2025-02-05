package lw1_build2.spring;

import lw1_build2.spring.model.Customer;
import lw1_build2.spring.service.CustomerService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class CustomerController {
    private CustomerService customerService;

    @Autowired(required = true)
    @Qualifier(value = "customerService")
    public void setCustomerService(CustomerService customerService) {
        this.customerService = customerService;
    }

    @RequestMapping(value = "/customers", method = RequestMethod.GET)
    public String listCustomers(Model model) {
        model.addAttribute("customer", new Customer());
        model.addAttribute("listCustomers", this.customerService.listCustomers());
        return "customer";
    }

    @RequestMapping(value = "/customer/add", method = RequestMethod.POST)
    public String addPerson(@ModelAttribute("customer") Customer customer) {
        if(customer.getId() == 0) {
            this.customerService.addCustomer(customer);
        } else {
            this.customerService.updateCustomer(customer);
        }

        return "redirect:/customers";
    }

    @RequestMapping("/customer/remove/{id}")
    public String removeCustomer(@PathVariable("id") int id) {
        this.customerService.removeCustomer(id);
        return "redirect:/customers";
    }

    @RequestMapping("/customer/edit/{id}")
    public String editCustomer(@PathVariable("id") int id, Model model) {
        model.addAttribute("customer", this.customerService.getCustomerById(id));
        model.addAttribute("listCustomers", this.customerService.listCustomers());
        return "customer";
    }
}