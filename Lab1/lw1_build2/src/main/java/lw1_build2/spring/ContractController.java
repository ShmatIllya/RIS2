package lw1_build2.spring;

import lw1_build2.spring.model.Contract;
import lw1_build2.spring.service.ContractService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class ContractController {
    private ContractService contractService;

    @Autowired(required = true)
    @Qualifier(value = "contractService")
    public void setContractService(ContractService contractService) {
        this.contractService = contractService;
    }

    @RequestMapping(value = "/contracts", method = RequestMethod.GET)
    public String listContracts(Model model) {
        model.addAttribute("contract", new Contract());
        model.addAttribute("listContracts", this.contractService.listContracts());
        return "contract";
    }

    @RequestMapping(value = "/contract/add", method = RequestMethod.POST)
    public String addPerson(@ModelAttribute("contract") Contract contract) {
        if(contract.getId() == 0) {
            this.contractService.addContract(contract);
        } else {
            this.contractService.updateContract(contract);
        }

        return "redirect:/contracts";
    }

    @RequestMapping("/contract/remove/{id}")
    public String removeContract(@PathVariable("id") int id) {
        this.contractService.removeContract(id);
        return "redirect:/contracts";
    }

    @RequestMapping("/contract/edit/{id}")
    public String editContract(@PathVariable("id") int id, Model model) {
        model.addAttribute("contract", this.contractService.getContractById(id));
        model.addAttribute("listContracts", this.contractService.listContracts());
        return "contract";
    }
}
