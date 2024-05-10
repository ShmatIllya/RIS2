package lw1_build2.spring;

import lw1_build2.spring.model.Bike;
import lw1_build2.spring.service.BikeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class BikeController {
    private BikeService bikeService;

    @Autowired(required = true)
    @Qualifier(value = "bikeService")
    public void setBikeService(BikeService bikeService) {
        this.bikeService = bikeService;
    }

    @RequestMapping(value = "/bikes", method = RequestMethod.GET)
    public String listBikes(Model model) {
        model.addAttribute("bike", new Bike());
        model.addAttribute("listBikes", this.bikeService.listBikes());
        return "bike";
    }

    @RequestMapping(value = "/bike/add", method = RequestMethod.POST)
    public String addBike(@ModelAttribute("bike") Bike bike) {
        if(bike.getId() == null) {
            this.bikeService.addBike(bike);
        } else {
            this.bikeService.updateBike(bike);
        }

        return "redirect:/bikes";
    }

    @RequestMapping("/bike/remove/{id}")
    public String removeBike(@PathVariable("id") int id) {
        this.bikeService.removeBike(id);
        return "redirect:/bikes";
    }

    @RequestMapping("/bike/edit/{id}")
    public String editBike(@PathVariable("id") int id, Model model) {
        model.addAttribute("bike", this.bikeService.getBikeById(id));
        model.addAttribute("listBikes", this.bikeService.listBikes());
        return "bike";
    }
}
