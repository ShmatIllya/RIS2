package lw1_build2.spring.service;

import lw1_build2.spring.model.Bike;
import lw1_build2.spring.dao.BikeDAO;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
public class BikeServiceImpl implements BikeService {
    private BikeDAO bikeDAO;

    public void setBikeDAO(BikeDAO bikeDAO) {
        this.bikeDAO = bikeDAO;
    }

    @Override
    @Transactional
    public void addBike(Bike bike) {
        this.bikeDAO.addBike(bike);
    }

    @Override
    @Transactional
    public void updateBike(Bike bike) {
        this.bikeDAO.updateBike(bike);
    }

    @Override
    @Transactional
    public void removeBike(int id) {
        this.bikeDAO.removeBike(id);
    }

    @Override
    @Transactional
    public List<Bike> listBikes() {
        return this.bikeDAO.listBikes();
    }

    @Override
    @Transactional
    public Bike getBikeById(int id) {
        return this.bikeDAO.getBikeById(id);
    }
}
